using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using ParquetClassLibrary;
using ParquetClassLibrary.Beings;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Crafts;
using ParquetClassLibrary.Games;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Rooms;
using ParquetClassLibrary.Scripts;
using Scribe.ChangeHistory;
using Scribe.Properties;

namespace Scribe
{
    /// <summary>
    /// The primary editing interface.
    /// </summary>
    public partial class MainEditorForm : Form
    {
        /// <summary>Tag identifying controls whose changes are not managed via the ContentAlteredEventHandler.</summary>
        public static string PrimaryListBox = "Primary List Box";

        #region Child Forms
        /// <summary>Dialogue displaying information about the application.</summary>
        private readonly AboutBox AboutDialogue = new AboutBox();

        /// <summary>Dialogue for adding a quest to a collection.</summary>
        private readonly AddQuestBox AddQuestDialogue = new AddQuestBox();

        /// <summary>Dialogue for adding a <see cref="RecipeElement"/> to a collection.</summary>
        private readonly AddRecipeElementBox AddRecipeElementDialogue = new AddRecipeElementBox();

        /// <summary>Dialogue for adding a <see cref="InventorySlot"/> to an <see cref="Inventory"/>.</summary>
        private readonly AddSlotBox AddSlotDialogue = new AddSlotBox();

        /// <summary>Dialogue for adding a <see cref="ModelTag"/> to a collection.</summary>
        private readonly AddTagBox AddTagDialogue = new AddTagBox();

        /// <summary>Window for editing an <see cref="Inventory"/>.</summary>
        private readonly InventoryEditorForm InventoryEditorWindow = new InventoryEditorForm();

        /// <summary>Dialogue allowing customization of the application's behavior.</summary>
        private readonly OptionsBox OptionsDialogue = new OptionsBox();

        /// <summary>Window for editing <see cref="StrikePanelGrid"/>s.</summary>
        private readonly StrikePatternEditorForm StrikePatternEditorWindow = new StrikePatternEditorForm();

        /// <summary>Dialogue for selecting the project folder to work in.</summary>
        private readonly FolderBrowserDialog FolderBrowserDialogue = new FolderBrowserDialog();
        #endregion

        #region Cached Controls
        /// <summary>
        /// A collection of all editable <see cref="Control"/>s in the <see cref="MainEditorForm"/>
        /// together with the game data they currently represent, organized by <see cref="Type"/>.
        /// </summary>
        private readonly Dictionary<Type, Dictionary<Control, object>> EditableControls;

        /// <summary>
        /// A collection of all editable <see cref="PictureBox"/>es in the <see cref="MainEditorForm"/>.
        /// </summary>
        private readonly List<PictureBox> PictureBoxes;
        #endregion

        #region Autosave and Save Tracking
        /// <summary>
        /// The moment at which the game content was most recently saved.
        /// </summary>
        private DateTime TimeOfLastSync;

        /// <summary>Backing field for <see cref="HasUnsavedChanges"/>.</summary>
        private bool _hasUnsavedChanges;

        /// <summary>
        /// Determines if <see cref="All"/> out to be written to storage.
        /// </summary>
        /// <returns><c>true</c> if the application needs to save, <c>false</c> otherwise.</returns>
        private bool IsTimeToAutoSave()
            => Settings.Default.AutoSaveInterval > 0
            && DateTime.Now.AddMinutes(-Settings.Default.AutoSaveInterval) > TimeOfLastSync;

        /// <summary>
        /// If <c>true</c> then the <see cref="MainEditorForm"/> contains unsaved data.
        /// </summary>
        public bool HasUnsavedChanges
        {
            get => _hasUnsavedChanges;
            private set
            {
                if (value)
                {
                    // All is about to go out of sync with storage, check if it's time to autosave.
                    if (IsTimeToAutoSave())
                    {
                        if (EditorCommands.SaveDataFiles())
                        {
                            _hasUnsavedChanges = false;
                            UpdateDisplay();
                        }
                        else
                        {
                            SystemSounds.Beep.Play();
                            _ = MessageBox.Show(Resources.ErrorSaveFailed, Resources.CaptionError,
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            _hasUnsavedChanges = true;
                        }
                    }
                    else
                    {
                        _hasUnsavedChanges = true;
                    }
                }
                else
                {
                    // All is now in sync with storage.
                    TimeOfLastSync = DateTime.Now;
                    _hasUnsavedChanges = false;
                }

                Text = _hasUnsavedChanges
                    ? Resources.CaptionMainEditorFormDirty
                    : Resources.CaptionMainEditorFormClean;
            }
        }
        #endregion

        // TODO Use this when setting up Character tab:  Settings.Default.SuggestStoryIDs;

        #region Initialization
        /// <summary>
        /// Constructs a new instance of the main editor UI.
        /// </summary>
        public MainEditorForm()
        {
            InitializeComponent();

            HasUnsavedChanges = false;

            PictureBoxes = EditorTabs.GetAllChildrenOfType<PictureBox>().ToList<PictureBox>();
            EditableControls = GetEditableControls();
            foreach (var kvp in EditableControls)
            {
                foreach (var childControl in kvp.Value)
                {
                    childControl.Key.Validated += ContentAlteredEventHandler;
                }
            }
            FormClosing += FormClosingEventHandler;
        }

        /// <summary>
        /// Sets up the main editor UI.
        /// </summary>
        /// <param name="EventData">Handled by parent.</param>
        protected override void OnLoad(EventArgs EventData)
        {
            base.OnLoad(EventData);
            UpdateLibraryDataDisplay();
            UpdateFileFormatDisplay();
        }

        /// <summary>
        /// Finds all editable <see cref="Control"/>s in the <see cref="MainEditorForm"/> that represent editable game data.
        /// </summary>
        /// <returns>A dictionary containing lists of controls, organized by type.</returns>
        private Dictionary<Type, Dictionary<Control, object>> GetEditableControls()
        {
            var editables = new Dictionary<Type, Dictionary<Control, object>>();

            editables[typeof(TextBox)] = new Dictionary<Control, object>();
            foreach (var textbox in EditorTabs.GetAllChildrenOfType<TextBox>())
            {
                editables[typeof(TextBox)][textbox] = textbox.Text;
            }
            editables[typeof(CheckBox)] = new Dictionary<Control, object>();
            foreach (var checkbox in EditorTabs.GetAllChildrenOfType<CheckBox>())
            {
                editables[typeof(CheckBox)][checkbox] = (bool?)checkbox.Checked;
            }
            editables[typeof(ComboBox)] = new Dictionary<Control, object>();
            foreach (var combobox in EditorTabs.GetAllChildrenOfType<ComboBox>())
            {
                editables[typeof(ComboBox)][combobox] = (int?)combobox.SelectedIndex;
            }
            editables[typeof(ListBox)] = new Dictionary<Control, object>();
            foreach (var listbox in EditorTabs.GetAllChildrenOfType<ListBox>())
            {
                editables[typeof(ListBox)][listbox] = (int?)listbox.SelectedIndex;
            }

            return editables;
        }
        #endregion

        #region Setting Up FolderBrowserDialogue
        /// <summary>
        /// Opens a dialogue allowing the user to select the folder in which to data files are stored.
        /// </summary>
        /// <remarks>
        /// Ideally this should have been handled via sub-classing, but since <see cref="FolderBrowserDialogue"/>
        /// is <c>sealed</c> we take care of it here.
        /// </remarks>
        /// <param name="in_message">A prompt to the user, differentiating between loading existing files and creating new blank ones.</param>
        /// <returns>True if the user selected a folder.</returns>
        private bool SelectProjectFolder(string in_message)
        {
            FolderBrowserDialogue.ShowNewFolderButton = true;
            FolderBrowserDialogue.RootFolder = Settings.Default.DesktopIsDefaultDirectory
                ? Environment.SpecialFolder.Desktop
                : Environment.SpecialFolder.MyDocuments;
            FolderBrowserDialogue.Description = in_message;
            FolderBrowserDialogue.SelectedPath = All.ProjectDirectory;

            var response = FolderBrowserDialogue.ShowDialog();
            if (response == DialogResult.OK)
            {
                All.ProjectDirectory = FolderBrowserDialogue.SelectedPath;
                return true;
            }
            return false;
        }
        #endregion

        #region Tab Management
        #region Tab Indices
        private const int GamesTabIndex = 0;
        private const int BlocksTabIndex = 1;
        private const int FloorsTabIndex = 2;
        private const int FurnishingsTabIndex = 3;
        private const int CollectiblesTabIndex = 4;
        private const int CharactersTabIndex = 5;
        private const int CrittersTabIndex = 6;
        private const int ItemsTabIndex = 7;
        private const int BiomeRecipesTabIndex = 8;
        private const int CraftingRecipesTabIndex = 9;
        private const int RoomRecipesTabIndex = 10;
        private const int MapsTabIndex = 11;
        private const int ScriptsTabIndex = 12;
        #endregion

        /// <summary>
        /// Given the index of an editor tab, return the default <see cref="ModelID"/> for the content it edits.
        /// </summary>
        /// <param name="inTabIndex">The index of the tab sought.</param>
        /// <returns>The corresponding ID, or <see cref="ModelID.None"/> on out of range input.</returns>
        private ModelID GetDefaultIDForTab(int inTabIndex)
            => inTabIndex switch
            {
                GamesTabIndex => All.GameIDs.Minimum,
                BlocksTabIndex => All.BlockIDs.Minimum,
                FloorsTabIndex => All.FloorIDs.Minimum,
                FurnishingsTabIndex => All.FurnishingIDs.Minimum,
                CollectiblesTabIndex => All.CollectibleIDs.Minimum,
                CharactersTabIndex => All.CharacterIDs.Minimum,
                CrittersTabIndex => All.CritterIDs.Minimum,
                ItemsTabIndex => All.ItemIDs.Minimum,
                BiomeRecipesTabIndex => All.BiomeIDs.Minimum,
                CraftingRecipesTabIndex => All.CraftingRecipeIDs.Minimum,
                RoomRecipesTabIndex => All.RoomRecipeIDs.Minimum,
                MapsTabIndex => All.MapRegionIDs.Minimum,
                ScriptsTabIndex => All.ScriptIDs.Minimum,
                _ => ModelID.None,
            };

        /// <summary>
        /// Given the index of an editor tab, return the <see cref="ModelID"/> for the game model currently selected on that tab.
        /// </summary>
        /// <param name="inTabIndex">The index of the tab housing the model sought.</param>
        /// <returns>The identifier, or <see cref="ModelID.None"/> on out of range input.</returns>
        private ModelID GetSelectedModelIDForTab(int inTabIndex)
            => inTabIndex switch
            {
                GamesTabIndex => (GameListBox.SelectedItem as GameModel)?.ID ?? ModelID.None,
                BlocksTabIndex => (BlockListBox.SelectedItem as BlockModel)?.ID ?? ModelID.None,
                FloorsTabIndex => (FloorListBox.SelectedItem as FloorModel)?.ID ?? ModelID.None,
                FurnishingsTabIndex => (FurnishingListBox.SelectedItem as FurnishingModel)?.ID ?? ModelID.None,
                CollectiblesTabIndex => (CollectibleListBox.SelectedItem as CollectibleModel)?.ID ?? ModelID.None,
                CharactersTabIndex => (CharacterListBox.SelectedItem as CharacterModel)?.ID ?? ModelID.None,
                CrittersTabIndex => (CritterListBox.SelectedItem as CritterModel)?.ID ?? ModelID.None,
                ItemsTabIndex => (ItemListBox.SelectedItem as ItemModel)?.ID ?? ModelID.None,
                BiomeRecipesTabIndex => (BiomeListBox.SelectedItem as BiomeRecipe)?.ID ?? ModelID.None,
                CraftingRecipesTabIndex => (CraftingListBox.SelectedItem as CraftingRecipe)?.ID ?? ModelID.None,
                RoomRecipesTabIndex => (RoomListBox.SelectedItem as RoomRecipe)?.ID ?? ModelID.None,
                MapsTabIndex => throw new NotImplementedException(),
                ScriptsTabIndex => throw new NotImplementedException(),
                _ => ModelID.None,
            };

        /// <summary>
        /// Given the index of an editor tab, return the corresponding <see cref="Model"/> from
        /// from the appropriate <see cref="ModelCollection"/> in <see cref="All"/>.
        /// </summary>
        /// <param name="inTabIndex">The index of the tab sought.</param>
        /// <returns>The model, or <c>null</c> on out of range input.</returns>
        private Model GetSelectedModelForTab(int inTabIndex)
        {
            var id = GetSelectedModelIDForTab(inTabIndex);
            return id == ModelID.None
                ? (Model)null
                : inTabIndex switch
                {
                    GamesTabIndex => All.Games.Get<GameModel>(id),
                    BlocksTabIndex => All.Parquets.Get<BlockModel>(id),
                    FloorsTabIndex => All.Parquets.Get<FloorModel>(id),
                    FurnishingsTabIndex => All.Parquets.Get<FurnishingModel>(id),
                    CollectiblesTabIndex => All.Parquets.Get<CollectibleModel>(id),
                    CharactersTabIndex => All.Beings.Get<CharacterModel>(id),
                    CrittersTabIndex => All.Beings.Get<CritterModel>(id),
                    ItemsTabIndex => All.Items.Get<ItemModel>(id),
                    BiomeRecipesTabIndex => All.Biomes.Get<BiomeRecipe>(id),
                    CraftingRecipesTabIndex => All.CraftingRecipes.Get<CraftingRecipe>(id),
                    RoomRecipesTabIndex => All.RoomRecipes.Get<RoomRecipe>(id),
                    MapsTabIndex => throw new NotImplementedException(),
                    ScriptsTabIndex => throw new NotImplementedException(),
                    _ => null,
                };
        }

        /// <summary>Given the index of an editor tab and an editor <see cref="Control"/>, return the corresponding property accessor.</summary>
        /// <param name="inTabIndex">The index of an editor tab.</param>
        /// <param name="inControl">The <see cref="Control"/> corresponding to the property sought.</param>
        /// <returns>A method for editing the property's value, or <c>null</c> if the input combination is not defined.</returns>
        private Action<object> GetPropertyAccessorForTabAndControl(int inTabIndex, Control inControl)
            => (inTabIndex, inControl.Name) switch
            {
                #region Pronouns
                (CharactersTabIndex, "CharacterPronounSubjectiveTextBox")
                    => (input) => (CharacterPronounListBox.SelectedItem as IPronounGroupEdit).Subjective = input.ToString(),
                (CharactersTabIndex, "CharacterPronounObjectiveTextBox")
                    => (input) => (CharacterPronounListBox.SelectedItem as IPronounGroupEdit).Objective = input.ToString(),
                (CharactersTabIndex, "CharacterPronounDeterminerTextBox")
                    => (input) => (CharacterPronounListBox.SelectedItem as IPronounGroupEdit).Determiner = input.ToString(),
                (CharactersTabIndex, "CharacterPronounPossessiveTextBox")
                    => (input) => (CharacterPronounListBox.SelectedItem as IPronounGroupEdit).Possessive = input.ToString(),
                (CharactersTabIndex, "CharacterPronounReflexiveTextBox")
                    => (input) => (CharacterPronounListBox.SelectedItem as IPronounGroupEdit).Reflexive = input.ToString(),
                #endregion

                #region Configuration
                (BiomeRecipesTabIndex, "BiomeLandThresholdTextBox")
                    => (input) => BiomeConfiguration.LandThresholdFactor = (double)input,
                (BiomeRecipesTabIndex, "BiomeLiquidThresholdFactorTextBox")
                    => (input) => BiomeConfiguration.LiquidThresholdFactor = (double)input,
                (BiomeRecipesTabIndex, "BiomeRoomThresholdFactorTextBox")
                    => (input) => BiomeConfiguration.RoomThresholdFactor = (double)input,

                (CraftingRecipesTabIndex, "CraftingMinIngredientCountTextBox")
                    => (input) => CraftConfiguration.IngredientCount = new Range<int>((int)input, CraftConfiguration.IngredientCount.Maximum),
                (CraftingRecipesTabIndex, "CraftingMaxIngredientCountTextBox")
                    => (input) => CraftConfiguration.IngredientCount = new Range<int>(CraftConfiguration.ProductCount.Minimum, (int)input),
                (CraftingRecipesTabIndex, "CraftingMinProductCountTextBox")
                    => (input) => CraftConfiguration.ProductCount = new Range<int>((int)input, CraftConfiguration.ProductCount.Maximum),
                (CraftingRecipesTabIndex, "CraftingMaxProductCountTextBox")
                    => (input) => CraftConfiguration.ProductCount = new Range<int>(CraftConfiguration.ProductCount.Minimum, (int)input),

                (RoomRecipesTabIndex, "RoomMinWalkableSpacesTextBox")
                    => (input) => RoomConfiguration.MinWalkableSpaces = (int)input,
                (RoomRecipesTabIndex, "RoomMaxWalkableSpacesTextBox")
                    => (input) => RoomConfiguration.MaxWalkableSpaces = (int)input,
                #endregion

                _ => GetPropertyAccessorForModelAndTabAndControl(GetSelectedModelForTab(inTabIndex), inTabIndex, inControl),
            };

        /// <summary>
        /// Given a <see cref="Model"/> and an editor <see cref="Control"/>, return the corresponding <see cref="Model"/> from
        /// from the appropriate <see cref="ModelCollection"/> in <see cref="All"/>.
        /// </summary>
        /// <param name="inTabIndex">The index of an editor tab.</param>
        /// <param name="inControl">The <see cref="Control"/> corresponding to the property sought.</param>
        /// <returns>A method for editing the property's value, or <c>null</c> if the input combination is not defined.</returns>
        /// <remarks>This method binds data in models to controls in the user interface.</remarks>
        private Action<object> GetPropertyAccessorForModelAndTabAndControl(Model inModel, int inTabIndex, Control inControl)
            => (inTabIndex, inControl.Name) switch
            {
                #region GameModels
                (GamesTabIndex, "GameNameTextBox")
                    => (input) => (inModel as IGameModelEdit).Name = (string)input,
                (GamesTabIndex, "GameDescriptionTextBox")
                    => (input) => (inModel as IGameModelEdit).Description = (string)input,
                (GamesTabIndex, "GameCommentTextBox")
                    => (input) => (inModel as IGameModelEdit).Comment = (string)input,
                (GamesTabIndex, "GameIsEpisodeCheckBox")
                    => (input) => (inModel as IGameModelEdit).IsEpisode = input as bool? ?? bool.Parse((string)input),
                (GamesTabIndex, "GameEpisodeTitleTextBox")
                    => (input) => (inModel as IGameModelEdit).EpisodeTitle = (string)input,
                (GamesTabIndex, "GameEpisodeNumberTextBox")
                    => (input) => (inModel as IGameModelEdit).EpisodeNumber = input as int? ?? int.Parse((string)input, NumberStyles.Integer),
                (GamesTabIndex, "GamePlayerCharacterTextBox")
                    => (input) => (inModel as IGameModelEdit).PlayerCharacterID = input as ModelID? ?? int.Parse((string)input, NumberStyles.Integer),
                (GamesTabIndex, "GameFirstScriptTextBox")
                    => (input) => (inModel as IGameModelEdit).FirstScriptID = input as ModelID? ?? int.Parse((string)input, NumberStyles.Integer),
                #endregion

                #region BlockModels
                (BlocksTabIndex, "BlockNameTextBox")
                    => (input) => (inModel as IBlockModelEdit).Name = (string)input,
                (BlocksTabIndex, "BlockDescriptionTextBox")
                    => (input) => (inModel as IBlockModelEdit).Description = (string)input,
                (BlocksTabIndex, "BlockCommentTextBox")
                    => (input) => (inModel as IBlockModelEdit).Comment = (string)input,
                (BlocksTabIndex, "BlockMaxToughnessTextBox")
                    => (input) => (inModel as IBlockModelEdit).MaxToughness = input as int? ?? int.Parse((string)input, NumberStyles.Integer),
                (BlocksTabIndex, "BlockIsFlammableCheckBox")
                    => (input) => (inModel as IBlockModelEdit).IsFlammable = input as bool? ?? bool.Parse((string)input),
                (BlocksTabIndex, "BlockIsLiquidCheckBox")
                    => (input) => (inModel as IBlockModelEdit).IsLiquid = input as bool? ?? bool.Parse((string)input),
                (BlocksTabIndex, "BlockGatherToolComboBox")
                    => (input) => (inModel as IBlockModelEdit).GatherTool = input as GatheringTool? ?? Enum.Parse<GatheringTool>((string)input, true),
                (BlocksTabIndex, "BlockDroppedCollectibleIDComboBox")
                    => (input) => (inModel as IBlockModelEdit).CollectibleID = input as ModelID? ?? int.Parse((string)input, NumberStyles.Integer),
                (BlocksTabIndex, "BlockGatherEffectComboBox")
                    => (input) => (inModel as IBlockModelEdit).GatherEffect = input as GatheringEffect? ?? Enum.Parse<GatheringEffect>((string)input, true),
                (BlocksTabIndex, "BlockEquivalentItemComboBox")
                    => (input) => (inModel as IBlockModelEdit).ItemID = input as ModelID? ?? int.Parse((string)input, NumberStyles.Integer),
                #endregion

                #region FloorModels
                (FloorsTabIndex, "FloorNameTextBox")
                    => (input) => (inModel as IFloorModelEdit).Name = (string)input,
                (FloorsTabIndex, "FloorDescriptionTextBox")
                    => (input) => (inModel as IFloorModelEdit).Description = (string)input,
                (FloorsTabIndex, "FloorCommentTextBox")
                    => (input) => (inModel as IFloorModelEdit).Comment = (string)input,
                (FloorsTabIndex, "FloorTrenchNameTextBox")
                    => (input) => (inModel as IFloorModelEdit).TrenchName = (string)input,
                (FloorsTabIndex, "FloorlItemIDComboBox")
                    => (input) => (inModel as IFloorModelEdit).ItemID = input as ModelID? ?? int.Parse((string)input, NumberStyles.Integer),
                (FloorsTabIndex, "FloorModificationToolComboBox")
                    => (input) => (inModel as IFloorModelEdit).ModTool = input as ModificationTool? ?? Enum.Parse<ModificationTool>((string)input, true),
                (FloorsTabIndex, "FloorAddsToBiomeListBox")
                    => (input) => (inModel as IFloorModelEdit).AddsToBiome = input as ModelTag ?? (string)input,
                (FloorsTabIndex, "FloorAddsToRoomListBox")
                    => (input) => (inModel as IFloorModelEdit).Comment = input as ModelTag ?? (string)input,
                #endregion

                #region FurnishingModels
                (FurnishingsTabIndex, "FurnishingNameTextBox")
                    => (input) => (inModel as IFurnishingModelEdit).Name = (string)input,
                (FurnishingsTabIndex, "FurnishingDescriptionTextBox")
                    => (input) => (inModel as IFurnishingModelEdit).Description = (string)input,
                (FurnishingsTabIndex, "FurnishingCommentTextBox")
                    => (input) => (inModel as IFurnishingModelEdit).Comment = (string)input,
                (FurnishingsTabIndex, "FurnishingEquivalentItemComboBox")
                    => (input) => (inModel as IFurnishingModelEdit).ItemID = input as ModelID? ?? int.Parse((string)input, NumberStyles.Integer),
                (FurnishingsTabIndex, "FurnishingEntryTypeComboBox")
                    => (input) => (inModel as IFurnishingModelEdit).Entry = input as EntryType? ?? Enum.Parse<EntryType>((string)input, true),
                (FurnishingsTabIndex, "FurnishingSwapWithFurnishingComboBox")
                    => (input) => (inModel as IFurnishingModelEdit).SwapID = input as ModelID? ?? int.Parse((string)input, NumberStyles.Integer),
                (FurnishingsTabIndex, "FurnishingIsEnclosingCheckBox")
                    => (input) => (inModel as IFurnishingModelEdit).IsEnclosing = input as bool? ?? bool.Parse((string)input),
                (FurnishingsTabIndex, "FurnishingIsFlammableCheckBox")
                    => (input) => (inModel as IFurnishingModelEdit).IsFlammable = input as bool? ?? bool.Parse((string)input),
                (FurnishingsTabIndex, "FurnishingIsWalkableCheckBox")
                    => (input) => (inModel as IFurnishingModelEdit).IsWalkable = input as bool? ?? bool.Parse((string)input),
                #endregion

                #region CollectibleModels
                (CollectiblesTabIndex, "CollectibleNameTextBox")
                    => (input) => (inModel as ICollectibleModelEdit).Name = (string)input,
                (CollectiblesTabIndex, "CollectibleDescriptionTextBox")
                    => (input) => (inModel as ICollectibleModelEdit).Description = (string)input,
                (CollectiblesTabIndex, "CollectibleCommentTextBox")
                    => (input) => (inModel as ICollectibleModelEdit).Comment = (string)input,
                (CollectiblesTabIndex, "CollectibleEffectAmountTextBox")
                    => (input) => (inModel as ICollectibleModelEdit).EffectAmount = input as int? ?? int.Parse((string)input, NumberStyles.Integer),
                (CollectiblesTabIndex, "CollectibleCollectionEffectComboBox")
                    => (input) => (inModel as ICollectibleModelEdit).CollectionEffect = input as CollectingEffect? ?? Enum.Parse<CollectingEffect>((string)input, true),
                (CollectiblesTabIndex, "CollectibleEquivalentItemComboBox")
                    => (input) => (inModel as ICollectibleModelEdit).ItemID = input as ModelID? ?? int.Parse((string)input, NumberStyles.Integer),
                #endregion

                #region CharacterModels
                (CharactersTabIndex, "CharacterNameTextBox")
                    => (input) => (inModel as ICharacterModelEdit).Name = (string)input,
                (CharactersTabIndex, "CharacterDescriptionTextBox")
                    => (input) => (inModel as ICharacterModelEdit).Description = (string)input,
                (CharactersTabIndex, "CharacterCommentTextBox")
                    => (input) => (inModel as ICharacterModelEdit).Comment = (string)input,
                (CharactersTabIndex, "CharacterNativeBiomeComboBox")
                    => (input) => (inModel as ICharacterModelEdit).NativeBiome = input as ModelID? ?? int.Parse((string)input, NumberStyles.Integer),
                (CharactersTabIndex, "CharacterPrimaryBehaviorComboBox")
                    => (input) => (inModel as ICharacterModelEdit).PrimaryBehavior = input as ModelID? ?? int.Parse((string)input, NumberStyles.Integer),
                (CharactersTabIndex, "CharacterStoryIDTextBox")
                    => (input) => (inModel as ICharacterModelEdit).StoryCharacterID = (string)input,
                (CharactersTabIndex, "CharacterPronounComboBox")
                    => (input) => (inModel as ICharacterModelEdit).Pronouns = (string)input,
                (CharactersTabIndex, "CharacterStartingDialogueComboBox")
                    => (input) =>
                    {
                        var editModel = inModel as ICharacterModelEdit;
                        editModel.StartingDialogue.Clear();
                        editModel.StartingDialogue.ToList().AddRange((IList<ModelID>)input);
                    },
                (CharactersTabIndex, "StartingInventoryComboBox")
                    => (input) =>
                    {
                        var editModel = inModel as ICharacterModelEdit;
                        editModel.StartingInventory.Clear();
                        editModel.StartingInventory.ToList().AddRange((IList<ModelID>)input);
                    },
                (CharactersTabIndex, "CharacterStartingQuestsListBox")
                    => (input) =>
                    {
                        var editModel = inModel as ICharacterModelEdit;
                        editModel.StartingQuests.Clear();
                        editModel.StartingQuests.ToList().AddRange((IList<ModelID>)input);
                    },
                #endregion

                #region CritterModels
                (CrittersTabIndex, "CritterNameTextBox")
                    => (input) => (inModel as ICritterModelEdit).Name = (string)input,
                (CrittersTabIndex, "CritterDescriptionTextBox")
                    => (input) => (inModel as ICritterModelEdit).Description = (string)input,
                (CrittersTabIndex, "CritterCommentTextBox")
                    => (input) => (inModel as ICritterModelEdit).Comment = (string)input,
                (CrittersTabIndex, "CritterNativeBiomeComboBox")
                    => (input) => (inModel as ICritterModelEdit).NativeBiome = input as ModelID? ?? int.Parse((string)input, NumberStyles.Integer),
                (CrittersTabIndex, "CritterPrimaryBehaviorComboBox")
                    => (input) => (inModel as ICritterModelEdit).PrimaryBehavior = input as ModelID? ?? int.Parse((string)input, NumberStyles.Integer),
                #endregion

                #region ItemModels
                (ItemsTabIndex, "ItemNameTextBox")
                    => (input) => (inModel as IItemModelEdit).Name = (string)input,
                (ItemsTabIndex, "ItemDescriptionTextBox")
                    => (input) => (inModel as IItemModelEdit).Description = (string)input,
                (ItemsTabIndex, "ItemCommentTextBox")
                    => (input) => (inModel as IItemModelEdit).Comment = (string)input,
                (ItemsTabIndex, "ItemSubtypeComboBox")
                    => (input) => (inModel as IItemModelEdit).Subtype = input as ItemType? ?? Enum.Parse<ItemType>((string)input, true),
                (ItemsTabIndex, "ItemPriceTextBox")
                    => (input) => (inModel as IItemModelEdit).Price = input as int? ?? int.Parse((string)input, NumberStyles.Integer),
                (ItemsTabIndex, "ItemTagListBox")
                    => (input) =>
                    {
                        var editModel = inModel as IItemModelEdit;
                        editModel.ItemTags.Clear();
                        editModel.ItemTags.ToList().AddRange((IList<ModelTag>)input);
                    },
                (ItemsTabIndex, "ItemStackMaxTextBox")
                    => (input) => (inModel as IItemModelEdit).StackMax = input as int? ?? int.Parse((string)input, NumberStyles.Integer),
                (ItemsTabIndex, "ItemRarityTextBox")
                    => (input) => (inModel as IItemModelEdit).Rarity = input as int? ?? int.Parse((string)input, NumberStyles.Integer),
                (ItemsTabIndex, "ItemEffectWhenUsedComboBox")
                    => (input) => (inModel as IItemModelEdit).EffectWhenUsed = input as ModelID? ?? int.Parse((string)input, NumberStyles.Integer),
                (ItemsTabIndex, "ItemEffectWhileHeldComboBox")
                    => (input) => (inModel as IItemModelEdit).EffectWhenUsed = input as ModelID? ?? int.Parse((string)input, NumberStyles.Integer),
                (ItemsTabIndex, "ItemEquivalentParquetComboBox")
                    => (input) => (inModel as IItemModelEdit).ParquetID = input as ModelID? ?? int.Parse((string)input, NumberStyles.Integer),
                #endregion

                #region BiomeRecipes
                (BiomeRecipesTabIndex, "BiomeNameTextBox")
                    => (input) => (inModel as IBiomeRecipeEdit).Name = (string)input,
                (BiomeRecipesTabIndex, "BiomeDescriptionTextBox")
                    => (input) => (inModel as IBiomeRecipeEdit).Description = (string)input,
                (BiomeRecipesTabIndex, "BiomeCommentTextBox")
                    => (input) => (inModel as IBiomeRecipeEdit).Comment = (string)input,
                (BiomeRecipesTabIndex, "BiomeTierTextBox")
                    => (input) => (inModel as IBiomeRecipeEdit).Tier = input as int? ?? int.Parse((string)input, NumberStyles.Integer),
                (BiomeRecipesTabIndex, "BiomeIsLiquidBasedCheckBox")
                    => (input) => (inModel as IBiomeRecipeEdit).IsLiquidBased = input as bool? ?? bool.Parse((string)input),
                (BiomeRecipesTabIndex, "BiomeIsRoomBasedCheckBox")
                    => (input) => (inModel as IBiomeRecipeEdit).IsRoomBased = input as bool? ?? bool.Parse((string)input),
                (BiomeRecipesTabIndex, "BiomeEntryRequirementsListBox")
                    => (input) =>
                    {
                        var editModel = inModel as IBiomeRecipeEdit;
                        editModel.EntryRequirements.Clear();
                        editModel.EntryRequirements.ToList().AddRange((IList<ModelTag>)input);
                    },
                (BiomeRecipesTabIndex, "BiomeParquetCriteriaListBox")
                    => (input) =>
                    {
                        var editModel = inModel as IBiomeRecipeEdit;
                        editModel.ParquetCriteria.Clear();
                        editModel.ParquetCriteria.ToList().AddRange((IList<ModelTag>)input);
                    },
                #endregion

                #region CraftingRecipes
                (CraftingRecipesTabIndex, "CraftingNameTextBox")
                    => (input) => (inModel as ICraftingRecipeEdit).Name = (string)input,
                (CraftingRecipesTabIndex, "CraftingDescriptionTextBox")
                    => (input) => (inModel as ICraftingRecipeEdit).Description = (string)input,
                (CraftingRecipesTabIndex, "CraftingCommentTextBox")
                    => (input) => (inModel as ICraftingRecipeEdit).Comment = (string)input,
                (CraftingRecipesTabIndex, "CraftingIngredientsBox")
                    => (input) =>
                    {
                        var editModel = inModel as ICraftingRecipeEdit;
                        editModel.Ingredients.Clear();
                        editModel.Ingredients.ToList().AddRange((IList<RecipeElement>)input);
                    },
                (CraftingRecipesTabIndex, "CraftingProductsListBox")
                    => (input) =>
                    {
                        var editModel = inModel as ICraftingRecipeEdit;
                        editModel.Products.Clear();
                        editModel.Products.ToList().AddRange((IList<RecipeElement>)input);
                    },
                #endregion

                #region RoomRecipes
                (RoomRecipesTabIndex, "RoomNameTextBox")
                    => (input) => (inModel as ICraftingRecipeEdit).Name = (string)input,
                (RoomRecipesTabIndex, "RoomDescriptionTextBox")
                    => (input) => (inModel as ICraftingRecipeEdit).Description = (string)input,
                (RoomRecipesTabIndex, "RoomCommentTextBox")
                    => (input) => (inModel as ICraftingRecipeEdit).Comment = (string)input,
                (RoomRecipesTabIndex, "RoomMinimumWalkableSpacesTextBox")
                    => (input) => (inModel as IRoomRecipeEdit).MinimumWalkableSpaces = input as int? ?? int.Parse((string)input, NumberStyles.Integer),
                (RoomRecipesTabIndex, "RoomRequiredFurnishingsListBox")
                    => (input) =>
                    {
                        var editModel = inModel as IRoomRecipeEdit;
                        editModel.OptionallyRequiredFurnishings.Clear();
                        editModel.OptionallyRequiredFurnishings.ToList().AddRange((IList<RecipeElement>)input);
                    },
                (RoomRecipesTabIndex, "RoomRequiredBlocksListBox")
                    => (input) =>
                    {
                        var editModel = inModel as IRoomRecipeEdit;
                        editModel.OptionallyRequiredPerimeterBlocks.Clear();
                        editModel.OptionallyRequiredPerimeterBlocks.ToList().AddRange((IList<RecipeElement>)input);
                    },
                (RoomRecipesTabIndex, "RoomRequiredFloorsListBox")
                    => (input) =>
                    {
                        var editModel = inModel as IRoomRecipeEdit;
                        editModel.OptionallyRequiredWalkableFloors.Clear();
                        editModel.OptionallyRequiredWalkableFloors.ToList().AddRange((IList<RecipeElement>)input);
                    },
                #endregion

                #region Mapping
                // TODO Implement Maps.
                (MapsTabIndex, _) => throw new NotImplementedException(),
                #endregion

                #region Scripting
                // TODO Implement Scripts and Interactions.
                (ScriptsTabIndex, _) => throw new NotImplementedException(),
                #endregion

                _ => null,
            };
        #endregion

        #region Editor Display Update Methods
        /// <summary>
        /// Updates the form when it receives focus, for example after closing the options dialogue box.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void MainEditorForm_Activated(object sender, EventArgs e)
        {
            FlavorFilterGroupBox.Enabled = Settings.Default.UseFlavorFilters;
            FlavorFilterGroupBox.Visible = Settings.Default.UseFlavorFilters;
            // TODO UpdateEditorTheme(Settings.Default.UseColorfulEditorTheme);

            EditorTabs.TabPages[EditorTabs.SelectedIndex]?.Select();
        }

        /// <summary>
        /// Repopulates the given list with the <see cref="Model"/>s in the given collection.
        /// </summary>
        /// <typeparam name="T">A model type.</typeparam>
        /// <param name="in_listbox">The UI to repopulate.</param>
        /// <param name="in_source">The objects to populate the UI with.</param>
        private void UpdateDisplay()
        {
            UpdateLibraryDataDisplay();

            #region Clear Lists and Containers
            foreach (var textbox in EditableControls[typeof(TextBox)])
            {
                ((TextBox)textbox.Key)?.Clear();
            }
            foreach (var checkbox in EditableControls[typeof(CheckBox)])
            {
                var nonNullCheckbox = (CheckBox)checkbox.Key;
                if (nonNullCheckbox != null)
                {
                    nonNullCheckbox.Checked = false;
                }
            }
            foreach (var combobox in EditableControls[typeof(ComboBox)])
            {
                var nonNullCombobox = (ComboBox)combobox.Key;
                if (nonNullCombobox != null)
                {
                    nonNullCombobox.SelectedItem = null;
                    nonNullCombobox.Items.Clear();
                }
            }
            foreach (var listbox in EditableControls[typeof(ListBox)])
            {
                var nonNullListbox = (ListBox)listbox.Key;
                if (nonNullListbox != null)
                {
                    nonNullListbox.SelectedItem = null;
                    nonNullListbox.Items.Clear();
                }
            }

            foreach (var picturebox in PictureBoxes)
            {
                if (picturebox != null)
                {
                    picturebox.Image?.Dispose();
                    picturebox.Image = null;
                    picturebox.Update();
                }
            }
            #endregion

            #region Repopulate Primary List Boxes
            RepopulateListBox(GameListBox, All.Games);
            RepopulateListBox(CritterListBox, All.Beings.OfType<CritterModel>());
            RepopulateListBox(CharacterListBox, All.Beings.OfType<CharacterModel>());
            RepopulateListBox(BiomeListBox, All.Biomes);
            RepopulateListBox(CraftingListBox, All.CraftingRecipes);
            RepopulateListBox(ItemListBox, All.Items);
            RepopulateListBox(FloorListBox, All.Parquets.OfType<FloorModel>());
            RepopulateListBox(BlockListBox, All.Parquets.OfType<BlockModel>());
            RepopulateListBox(FurnishingListBox, All.Parquets.OfType<FurnishingModel>());
            RepopulateListBox(CollectibleListBox, All.Parquets.OfType<CollectibleModel>());
            RepopulateListBox(RoomListBox, All.RoomRecipes);
            #endregion

            #region Reload Active Picture Box
            // TODO Right now this loads sample graphics, change it to real graphics or remove it.
            var id = GetDefaultIDForTab(EditorTabs.SelectedIndex);
            if (EditorCommands.IDHasGraphics(id))
            {
                var picturebox = EditorTabs.TabPages[EditorTabs.SelectedIndex]?.Controls
                                                                               .Cast<Control>()
                                                                               .OfType<PictureBox>()
                                                                               .FirstOrDefault();
                if (null != picturebox)
                {
                    var path = Path.Combine(EditorCommands.GetGraphicsPathForModelID(id), $"{id}.png");
                    if (File.Exists(path))
                    {
                        picturebox.Load(path);
                    }
                    else
                    {
                        picturebox.Image = Resources.ImageNotFoundGraphic;
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// Repopulates the given list with the <see cref="Model"/>s in the given collection.
        /// </summary>
        /// <typeparam name="T">A model type.</typeparam>
        /// <param name="in_listbox">The UI to repopulate.</param>
        /// <param name="in_source">The objects to populate the UI with.</param>
        /// <remarks>This should only be called if <see cref="All"/> has actually changed.</remarks>
        private void RepopulateListBox<T>(ListBox in_listbox, IEnumerable<T> in_source)
            where T : Model
        {
            if (null != in_source)
            {
                in_listbox.ClearSelected();
                in_listbox.BeginUpdate();
                in_listbox.Items.Clear();
                foreach (var game in in_source)
                {
                    _ = in_listbox.Items.Add(game);
                }
                in_listbox.EndUpdate();
            }
        }

        /// <summary>
        /// Sets the text used to describe the format of the saved data files the editor works with.
        /// </summary>
        private void UpdateFileFormatDisplay()
        {
            FileFormatPrimaryDelimiterExample.Text = Delimiters.PrimaryDelimiter;
            FileFormatSecondaryDelimiterExample.Text = Delimiters.SecondaryDelimiter;
            FileFormatInternalDelimiterExample.Text = Delimiters.InternalDelimiter;
            FileFormatElementDelimiterExample.Text = Delimiters.ElementDelimiter;
            FileFormatNameDelimiterExample.Text = Delimiters.NameDelimiter;
            FileFormatPronounDelimiterExample.Text = Delimiters.PronounDelimiter;
            FileFormatDimensionalDelimiterExample.Text = Delimiters.DimensionalDelimiter;
            FileFormatDimensionalTerminatorExample.Text = Delimiters.DimensionalTerminator;
        }

        /// <summary>
        /// Sets the text used to describe the library the editor supports.
        /// </summary>
        private void UpdateLibraryDataDisplay()
        {
            LibraryVersionExample.Text = ParquetClassLibrary.AssemblyInfo.LibraryVersion;
            LibraryProjectPathExample.Text = All.ProjectDirectory;
        }
        #endregion

        #region Tab Display Update Methods
        /// <summary>
        /// Populates the Games tab when a <see cref="GameModel"/> is selected in the GameListBox.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void GameListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (GameListBox.SelectedIndex == -1)
            {
                GameIDTextBox.Text = "";
                GameNameTextBox.Text = "";
                GameDescriptionTextBox.Text = "";
                GameCommentTextBox.Text = "";
                GameIsEpisodeCheckBox.Checked = false;
                GameEpisodeTitleTextBox.Text = "";
                GameEpisodeNumberTextBox.Text = "";
                GamePlayerCharacterTextBox.Text = "";
                GameFirstScriptTextBox.Text = "";
                GameIconPictureBox.Image = Resources.ImageNotFoundGraphic;
            }
            else if (GameListBox.SelectedItem is GameModel model
                    && null != model)
            {
                GameIDTextBox.Text = model.ID.ToString();
                GameNameTextBox.Text = model.Name;
                GameDescriptionTextBox.Text = model.Description;
                GameCommentTextBox.Text = model.Comment;
                GameIsEpisodeCheckBox.Checked = model.IsEpisode;
                GameEpisodeTitleTextBox.Text = model.EpisodeTitle;
                GameEpisodeNumberTextBox.Text = model.EpisodeNumber.ToString();
                GamePlayerCharacterTextBox.Text = model.PlayerCharacterID.ToString();
                GameFirstScriptTextBox.Text = model.FirstScriptID.ToString();

                var imagePath = Path.Combine(EditorCommands.GetGraphicsPathForModelID(model.ID), $"{model.ID}.png");
                if (File.Exists(imagePath))
                {
                    GameIconPictureBox.Load(imagePath);
                }
                else
                {
                    GameIconPictureBox.Image = Resources.ImageNotFoundGraphic;
                }
            }
        }

        /// <summary>
        /// Populates the Critters tab when a <see cref="CritterModel"/> is selected in the CritterListBox.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void CritterListBox_SelectedValueChanged_1(object sender, EventArgs e)
        {
            if (CritterListBox.SelectedIndex == -1)
            {
                CritterIDTextBox.Text = "";
                CritterNameTextBox.Text = "";
                CritterDescriptionTextBox.Text = "";
                CritterCommentTextBox.Text = "";
                CritterNativeBiomeComboBox.SelectedIndex = -1;
                CritterPrimaryBehaviorComboBox.SelectedIndex = -1;
                CritterPictureBox.Image = Resources.ImageNotFoundGraphic;
            }
            else if (CritterListBox.SelectedItem is CritterModel model
                    && null != model)
            {
                CritterIDTextBox.Text = model.ID.ToString();
                CritterNameTextBox.Text = model.Name;
                CritterDescriptionTextBox.Text = model.Description;
                CritterCommentTextBox.Text = model.Comment;
                // TODO Populate these combo boxes on load, new, etc.
                CritterNativeBiomeComboBox.SelectedValue = model.NativeBiome;
                CritterPrimaryBehaviorComboBox.SelectedValue = model.PrimaryBehavior;

                var imagePath = Path.Combine(EditorCommands.GetGraphicsPathForModelID(model.ID), $"{model.ID}.png");
                if (File.Exists(imagePath))
                {
                    CritterPictureBox.Load(imagePath);
                }
                else
                {
                    CritterPictureBox.Image = Resources.ImageNotFoundGraphic;
                }
            }
        }
        #endregion

        #region Handle Changes to Data
        /// <summary>
        /// Autosaves and/or marks the form dirty after an update.
        /// </summary>
        /// <param name="sender">The control whose content was changed.</param>
        /// <param name="e">Ignored.</param>
        private void ContentAlteredEventHandler(object sender, EventArgs e)
        {
            if (!(sender is Control alteredControl) || PrimaryListBox.Equals((string)alteredControl.Tag))
            {
                // Silently return if a primary list box is altered -- changes in these boxes are handled via buttons.
                return;
            }

            var PropertyAccessor = GetPropertyAccessorForTabAndControl(EditorTabs.SelectedIndex, alteredControl);
            if (null == PropertyAccessor)
            {
                // TODO Remove this debug statement, or change it to a logging statement.
                _ = MessageBox.Show($"Unsupported control {alteredControl.Name} on tab index {EditorTabs.SelectedIndex}.");
                return;
            }

            if (alteredControl is TextBox textbox
                && string.Compare(textbox.Text,
                                  EditableControls[typeof(TextBox)][textbox] as string,
                                  comparisonType: StringComparison.OrdinalIgnoreCase) != 0)
            {
                ChangeManager.AddAndExecute(new ChangeValue(EditableControls[typeof(TextBox)][textbox], textbox.Text, textbox.Name,
                                            (object databaseValue) => { PropertyAccessor(databaseValue); HasUnsavedChanges = true; },
                                            (object displayValue) => textbox.Text = displayValue.ToString(),
                                            (object oldValue) => EditableControls[typeof(TextBox)][textbox] = oldValue));
            }
            else if (alteredControl is CheckBox checkbox
                     && checkbox.Checked == (EditableControls[typeof(CheckBox)][checkbox] as bool?))
            {
                var oldValue = (bool?)EditableControls[typeof(CheckBox)][checkbox];
                ChangeManager.AddAndExecute(new ChangeValue(oldValue, (bool?)checkbox.Checked, checkbox.Name,
                                            (object databaseValue) => { PropertyAccessor(databaseValue); HasUnsavedChanges = true; },
                                            (object displayValue) => checkbox.Checked = (bool)displayValue,
                                            (object oldValue) => EditableControls[typeof(CheckBox)][checkbox] = oldValue));
            }
            else if (alteredControl is ComboBox combobox
                     && combobox.SelectedIndex == (EditableControls[typeof(ComboBox)][combobox] as int?))
            {
                var oldValue = (int?)EditableControls[typeof(ComboBox)][combobox];
                ChangeManager.AddAndExecute(new ChangeValue(oldValue, (int?)combobox.SelectedIndex, combobox.Name,
                                            (object databaseValue) => { PropertyAccessor(databaseValue); HasUnsavedChanges = true; },
                                            (object displayValue) => combobox.SelectedIndex = (int)displayValue,
                                            (object oldValue) => EditableControls[typeof(ComboBox)][combobox] = oldValue));
            }
            else if (alteredControl is ListBox listbox
                     && listbox.SelectedIndex == (EditableControls[typeof(ListBox)][listbox] as int?))
            {
                var oldValue = (int?)EditableControls[typeof(ListBox)][listbox];
                ChangeManager.AddAndExecute(new ChangeValue(oldValue, (int?)listbox.SelectedIndex, listbox.Name,
                                            (object databaseValue) => { PropertyAccessor(databaseValue); HasUnsavedChanges = true; },
                                            (object displayValue) => listbox.SelectedIndex = (int)displayValue,
                                            (object oldValue) => EditableControls[typeof(ListBox)][listbox] = oldValue));
            }
        }

        #region Game Tab
        /// <summary>
        /// Responds to the user clicking "Add New Game" on the Games tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void GameAddNewGameButton_Click(object sender, EventArgs e)
        {
            if (!All.CollectionsHaveBeenInitialized)
            {
                SystemSounds.Beep.Play();
                return;
            }

            var nextGameID = All.Games.Count > 0
                ? (ModelID)(All.Games.Max(model => model?.ID ?? All.GameIDs.Minimum) + 1)
                : All.GameIDs.Minimum;
            if (nextGameID > All.GameIDs.Maximum)
            {
                SystemSounds.Beep.Play();
                _ = MessageBox.Show(Resources.ErrorMaximumIDReached, Resources.CaptionError,
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var modelToAdd = new GameModel(nextGameID, "New Game", "", "", false, "", 0, ModelID.None, ModelID.None);
            ChangeManager.AddAndExecute(new ChangeList(modelToAdd, "add new game definition",
                                        (object databaseValue) =>
                                        {
                                           ((IModelCollectionEdit<GameModel>)All.Games).Add((GameModel)databaseValue);
                                            _ = GameListBox.Items.Add(databaseValue);
                                            HasUnsavedChanges = true;
                                        },
                                        (object databaseValue) =>
                                        {
                                            ((IModelCollectionEdit<GameModel>)All.Games).Remove((GameModel)databaseValue);
                                            GameListBox.Items.Remove(databaseValue);
                                            GameListBox.SelectedIndex = -1;
                                            HasUnsavedChanges = true;
                                        }));
        }

        /// <summary>
        /// Responds to the user clicking "Remove Game" on the Games tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void GameRemoveGameButton_Click(object sender, EventArgs e)
        {
            if (!All.CollectionsHaveBeenInitialized || GameListBox.SelectedIndex == -1)
            {
                SystemSounds.Beep.Play();
                return;
            }

            var modelToRemove = (GameModel)GetSelectedModelForTab(EditorTabs.SelectedIndex);
            if (null == modelToRemove)
            {
                SystemSounds.Beep.Play();
                return;
            }

            ChangeManager.AddAndExecute(new ChangeList(modelToRemove, $"remove {modelToRemove.Name}",
                                        (object databaseValue) =>
                                        {
                                            ((IModelCollectionEdit<GameModel>)All.Games).Remove((GameModel)databaseValue);
                                            GameListBox.Items.Remove(databaseValue);
                                            GameListBox.SelectedIndex = -1;
                                            HasUnsavedChanges = true;
                                        },
                                        (object databaseValue) =>
                                        {
                                            ((IModelCollectionEdit<GameModel>)All.Games).Add((GameModel)databaseValue);
                                            _ = GameListBox.Items.Add(databaseValue);
                                            HasUnsavedChanges = true;
                                        }));
        }
        #endregion

        #region Blocks Tab
        #endregion

        #region Floors Tab
        #endregion

        #region Furnishings Tab
        #endregion

        #region Collectibles Tab
        #endregion

        #region Characters Tab
        #endregion

        #region Critters Tab
        /// <summary>
        /// Responds to the user clicking "Add New Critter" on the Critters tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void CritterAddNewCritterButton_Click(object sender, EventArgs e)
        {
            if (!All.CollectionsHaveBeenInitialized)
            {
                SystemSounds.Beep.Play();
                return;
            }

            var nextCritterID = All.Beings.Count > 0
                ? (ModelID)(All.Beings.Where(model => model is CritterModel).Max(model => model?.ID ?? All.CritterIDs.Minimum) + 1)
                : All.CritterIDs.Minimum;
            if (nextCritterID > All.CritterIDs.Maximum)
            {
                SystemSounds.Beep.Play();
                _ = MessageBox.Show(Resources.ErrorMaximumIDReached, Resources.CaptionError,
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var modelToAdd = new CritterModel(nextCritterID, "New Critter", "", "", ModelID.None, ModelID.None);
            ChangeManager.AddAndExecute(new ChangeList(modelToAdd, "add new critter definition",
                                        (object databaseValue) =>
                                        {
                                            ((IModelCollectionEdit<BeingModel>)All.Beings).Add((CritterModel)databaseValue);
                                            _ = CritterListBox.Items.Add(databaseValue);
                                            HasUnsavedChanges = true;
                                        },
                                        (object databaseValue) =>
                                        {
                                            ((IModelCollectionEdit<BeingModel>)All.Beings).Remove((CritterModel)databaseValue);
                                            CritterListBox.Items.Remove(databaseValue);
                                            CritterListBox.SelectedIndex = -1;
                                            HasUnsavedChanges = true;
                                        }));
        }

        /// <summary>
        /// Responds to the user clicking "Remove Critter" on the Critters tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void CritterRemoveCritterButton_Click(object sender, EventArgs e)
        {
            if (!All.CollectionsHaveBeenInitialized || CritterListBox.SelectedIndex == -1)
            {
                SystemSounds.Beep.Play();
                return;
            }

            var modelToRemove = (CritterModel)GetSelectedModelForTab(EditorTabs.SelectedIndex);
            if (null == modelToRemove)
            {
                SystemSounds.Beep.Play();
                return;
            }

            ChangeManager.AddAndExecute(new ChangeList(modelToRemove, $"remove {modelToRemove.Name}",
                                        (object databaseValue) =>
                                        {
                                            ((IModelCollectionEdit<BeingModel>)All.Beings).Remove((CritterModel)databaseValue);
                                            CritterListBox.Items.Remove(databaseValue);
                                            CritterListBox.SelectedIndex = -1;
                                            HasUnsavedChanges = true;
                                        },
                                        (object databaseValue) =>
                                        {
                                            ((IModelCollectionEdit<BeingModel>)All.Beings).Add((CritterModel)databaseValue);
                                            _ = CritterListBox.Items.Add(databaseValue);
                                            HasUnsavedChanges = true;
                                        }));
        }
        #endregion

        #region Items Tab
        #endregion

        #region Biomes Tab
        #endregion

        #region Crafting Tab
        #endregion

        #region Rooms Tab
        #endregion

        #region Maps Tab
        #endregion

        #region Scripting Tab
        #endregion
        #endregion

        #region Menu Item Events
        /// <summary>
        /// Responds to a user selecting the "New" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="e">Addional event data.</param>
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!SelectProjectFolder(Resources.InfoMessageNew))
            {
                return;
            }

            if (EditorCommands.CreateTemplatesInProjectFolder()
                && EditorCommands.LoadDataFiles())
            {
                HasUnsavedChanges = false;
                UpdateDisplay();
            }
            else
            {
                SystemSounds.Beep.Play();
                _ = MessageBox.Show(Resources.ErrorNewFailed, Resources.CaptionError,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Responds to a user selecting the "Load" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="e">Addional event data.</param>
        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!SelectProjectFolder(Resources.InfoMessageLoad))
            {
                return;
            }

            if (EditorCommands.LoadDataFiles())
            {
                HasUnsavedChanges = false;
                UpdateDisplay();
            }
            else
            {
                SystemSounds.Beep.Play();
                _ = MessageBox.Show(Resources.ErrorLoadFailed, Resources.CaptionError,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Responds to a user selecting the "Reload" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="e">Addional event data.</param>
        private void ReloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resources.WarningMessageReload,
                                Resources.CaptionReloadWarning,
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (EditorCommands.LoadDataFiles())
                {
                    HasUnsavedChanges = false;
                    UpdateDisplay();
                }
                else
                {
                    SystemSounds.Beep.Play();
                    _ = MessageBox.Show(Resources.ErrorLoadFailed, Resources.CaptionError,
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Responds to a user selecting the "Save" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="e">Addional event data.</param>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (EditorCommands.SaveDataFiles())
            {
                HasUnsavedChanges = false;
                UpdateDisplay();
            }
            else
            {
                SystemSounds.Beep.Play();
                _ = MessageBox.Show(Resources.ErrorSaveFailed, Resources.CaptionError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Responds to a user selecting "Open Project Folder" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="e">Addional event data.</param>
        private void OpenProjectFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(All.ProjectDirectory))
            {
                _ = Process.Start("explorer", $"\"{All.ProjectDirectory}\"");
            }
            else
            {
                SystemSounds.Beep.Play();
            }
        }

        /// <summary>
        /// Responds to a user selecting the "Exit" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="e">Addional event data.</param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
            => Close();

        /// <summary>
        /// Responds to a user selecting the "Undo" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="e">Addional event data.</param>
        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
            => ChangeManager.Undo();

        /// <summary>
        /// Responds to a user selecting the "Redo" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="e">Addional event data.</param>
        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
            => ChangeManager.Redo();

        /// <summary>
        /// Responds to a user selecting the "Cut" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="e">Addional event data.</param>
        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
            => throw new NotImplementedException();

        /// <summary>
        /// Responds to a user selecting the "Copy" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="e">Addional event data.</param>
        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
            => throw new NotImplementedException();

        /// <summary>
        /// Responds to a user selecting the "Paste" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="e">Addional event data.</param>
        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
            => throw new NotImplementedException();

        /// <summary>
        /// Responds to a user selecting the "Select All" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="e">Addional event data.</param>
        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
            => throw new NotImplementedException();

        /// <summary>
        /// Responds to a user selecting the "Check Map" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="e">Addional event data.</param>
        private void CheckMapStripMenuItem_Click(object sender, EventArgs e)
            => throw new NotImplementedException();

        /// <summary>
        /// Responds to a user selecting the "List Naming Collisions" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="e">Addional event data.</param>
        private void ListNameCollisionsStripMenuItem_Click(object sender, EventArgs e)
            => throw new NotImplementedException();

        /// <summary>
        /// Responds to a user selecting the "List ID Ranges" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="e">Addional event data.</param>
        private void ListIDRangesToolStripMenuItem_Click(object sender, EventArgs e)
            => throw new NotImplementedException();

        /// <summary>
        /// Responds to a user selecting the "List Max IDs" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="e">Addional event data.</param>
        private void ListMaxIDsToolStripMenuItem_Click(object sender, EventArgs e)
            => throw new NotImplementedException();

        /// <summary>
        /// Responds to a user selecting the "List Tags" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="e">Addional event data.</param>
        private void ListTagsToolStripMenuItem_Click(object sender, EventArgs e)
            => throw new NotImplementedException();

        /// <summary>
        /// Responds to a user selecting the "Options" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="e">Addional event data.</param>
        private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OptionsDialogue.ShowDialog() == DialogResult.OK)
            {
                UpdateDisplay();
            }
        }

        /// <summary>
        /// Responds to a user selecting the "Scribe Help" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="e">Addional event data.</param>
        private void ScribeHelpToolStripMenuItem_Click(object sender, EventArgs e)
            => throw new NotImplementedException();

        /// <summary>
        /// Responds to a user selecting the "Documentation" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="e">Addional event data.</param>
        private void DocumentationToolStripMenuItem_Click(object sender, EventArgs e)
            => throw new NotImplementedException();

        /// <summary>
        /// Responds to a user selecting the "About" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="e">Addional event data.</param>
        private void AboutMenuItem_Click(object sender, EventArgs e)
            => AboutDialogue.ShowDialog();

        /// <summary>
        /// Responds to a user selecting "Open Containing Folder" context menu item from a picture box.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="e">Addional event data.</param>
        private void OpenContainingFolderMenuItem_Click(object sender, EventArgs e)
        {
            var path = ((PictureBox)((ContextMenuStrip)((ToolStripItem)sender)?.Owner)?.SourceControl)?.ImageLocation;
            path = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(path))
            {
                _ = Process.Start("explorer", $"\"{path}\"");
            }
            else
            {
                SystemSounds.Beep.Play();
            }
        }

        /// <summary>
        /// Responds to a user selecting "Edit in External Program" context menu item from a picture box.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="e">Addional event data.</param>
        private void ToolStripMenuItemEditExternal_Click(object sender, EventArgs e)
        {
            var picturebox = (PictureBox)((ContextMenuStrip)((ToolStripItem)sender)?.Owner)?.SourceControl;
            if (picturebox.Image != Resources.ImageNotFoundGraphic &&
                !string.IsNullOrEmpty(picturebox.ImageLocation))
            {
                // Make this application specifiable via options, maybe?
                _ = Process.Start("explorer", $"\"{picturebox.ImageLocation}\"");
            }
            else
            {
                SystemSounds.Beep.Play();
            }
        }
        #endregion

        #region Edit Image Button Events
        /// <summary>
        /// Given a <see cref="PictureBox"/>, spawns an external image editor with the image currently loaded in the box.
        /// </summary>
        /// <param name="inPictureBox">The picture box whose contents should be edited.</param>
        private void IconEditButtonClick(PictureBox inPictureBox)
        {
            var id = GetSelectedModelIDForTab(EditorTabs.SelectedIndex);
            if (id != ModelID.None)
            {
                var pathAndFileName = Path.Combine(EditorCommands.GetGraphicsPathForModelID(id), $"{id}.png");
                if (!File.Exists(pathAndFileName))
                {
                    Resources.ImageNotFoundGraphic.Save(pathAndFileName, ImageFormat.Png);
                }

                // TODO Properly manage this resource:  See return here:  https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.process.start?view=netcore-3.1
                _ = Settings.Default.EditInApp
                    ? Process.Start(Settings.Default.ImageEditor, $"\"{pathAndFileName}\"")
                    : Process.Start("explorer", $"\"{pathAndFileName}\"");

                inPictureBox.Load(pathAndFileName);
            }
            else
            {
                SystemSounds.Beep.Play();
            }
        }

        /// <summary>
        /// Registers the user command for editing the loaded game icon.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void GameIconEditButton_Click(object sender, EventArgs e)
            => IconEditButtonClick(GameIconPictureBox);

        /// <summary>
        /// Registers the user command for editing the loaded block image.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void BlockEditImageButton_Click(object sender, EventArgs e)
            => IconEditButtonClick(BlockPictureBox);

        /// <summary>
        /// Registers the user command for editing the loaded floor image.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void FloorEditImageButton_Click(object sender, EventArgs e)
            => IconEditButtonClick(FloorPictureBox);

        /// <summary>
        /// Registers the user command for editing the loaded furnishing image.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void FurnishingEditImageButton_Click(object sender, EventArgs e)
            => IconEditButtonClick(FurnishingPictureBox);

        /// <summary>
        /// Registers the user command for editing the loaded collectible image.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void CollectibleEditImageButton_Click(object sender, EventArgs e)
            => IconEditButtonClick(CollectiblePictureBox);

        /// <summary>
        /// Registers the user command for editing the loaded character image.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void CharacterEditImageButton_Click(object sender, EventArgs e)
            => IconEditButtonClick(CharacterPictureBox);

        /// <summary>
        /// Registers the user command for editing the loaded critter image.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void CritterEditImageButton_Click(object sender, EventArgs e)
            => IconEditButtonClick(CritterPictureBox);

        /// <summary>
        /// Registers the user command for editing the loaded item image.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void ItemPictureEditButton_Click(object sender, EventArgs e)
            => IconEditButtonClick(ItemPictureBox);

        /// <summary>
        /// Registers the user command for editing the loaded biome icon.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void BiomePictureEditButton_Click(object sender, EventArgs e)
            => IconEditButtonClick(BiomePictureBox);

        /// <summary>
        /// Registers the user command for editing the loaded crating recipe image.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void CraftingPictureEditButton_Click(object sender, EventArgs e)
            => IconEditButtonClick(CraftingPictureBox);

        /// <summary>
        /// Registers the user command for editing the loaded room image.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void RoomPictureEditButton_Click(object sender, EventArgs e)
            => IconEditButtonClick(RoomPictureBox);
        #endregion

        #region Quit Editor Event
        /// <summary>
        /// Intercepts events that would close the editor to double-check that this is desired.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Used to cancel the close event if it was not desired.</param>
        private void FormClosingEventHandler(object sender, FormClosingEventArgs e)
        {
            if (HasUnsavedChanges)
            {
                if (MessageBox.Show(Resources.WarningMessageExit,
                                    Resources.CaptionExitWarning,
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    FormClosing -= FormClosingEventHandler;
                }
            }
        }
        #endregion
    }
}
