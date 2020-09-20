using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
using ParquetClassLibrary.EditorSupport;
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
        #endregion

        #region Cached Controls
        /// <summary>Tag identifying controls whose color is not managed via <see cref="Settings.Default.EditorTheme"/>.</summary>
        public static string UnthemedControl = "Unthemed Control";

        /// <summary>Tag identifying controls whose color indicates that its text cannot be edited.</summary>
        public static string UneditableTextBox = "Uneditable TextBox";

        /// <summary>Tag identifying controls whose changes are not managed via <see cref="ContentAlteredEventHandler"/>.</summary>
        public static string UntrackedControl = "Untracked Control";

        /// <summary>
        /// A collection of all editable <see cref="PictureBox"/>es in the <see cref="MainEditorForm"/>.
        /// </summary>
        private readonly List<PictureBox> PictureBoxes;

        /// <summary>
        /// A collection of all themed <see cref="Control"/>s in the <see cref="MainEditorForm"/>.
        /// </summary>
        private readonly Dictionary<Type, List<Control>> ThemedControls;

        /// <summary>Used to determine if the <see cref="Settings.Default.CurrentEditorTheme"/> has changed.</summary>
        private static string oldTheme = Settings.Default.CurrentEditorTheme;

        /// <summary>
        /// A collection of all editable <see cref="Control"/>s in the <see cref="MainEditorForm"/>
        /// together with the game data they currently represent, organized by <see cref="Type"/>.
        /// </summary>
        /// <remarks>
        /// Whenever a <see cref="Form"/> reports a control's value as having been changed, the new value may
        /// be compared against the value stored here to see if the change was substantive.  In other worse, WinForms
        /// regards TextBox.Text='2' -> TextBox.Text='4' -> TextBox.Text='2' as a change; however, the initial and
        /// end states are indistinquishable and the <see cref="ChangeManager"/> should not consider this a <see cref="Change"/>.
        /// </remarks>
        private readonly Dictionary<Type, Dictionary<Control, object>> EditableControls;
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

        #region Initialization
        /// <summary>
        /// Constructs a new instance of the main editor UI.
        /// </summary>
        public MainEditorForm()
        {
            InitializeComponent();

            HasUnsavedChanges = false;

            PictureBoxes = EditorTabs.GetAllChildrenExactlyOfType<PictureBox>().ToList();
            ThemedControls = GetThemedControls();
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
            UpdateDisplay();
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

        #region Cache Controls
        /// <summary>
        /// Finds all themed <see cref="Control"/>s in the <see cref="MainEditorForm"/>.
        /// </summary>
        /// <returns>A dictionary containing lists of controls, organized by type.</returns>
        private Dictionary<Type, List<Control>> GetThemedControls()
        {
            var themed = new Dictionary<Type, List<Control>>
            {
                [typeof(GroupBox)] = new List<Control>(),
                [typeof(ListBox)] = new List<Control>(),
                [typeof(ComboBox)] = new List<Control>(),
                [typeof(TextBox)] = new List<Control>(),
                [typeof(CheckBox)] = new List<Control>(),
                [typeof(Button)] = new List<Control>(),
            };

            foreach (var groupBox in this.GetAllChildrenExactlyOfType<GroupBox>())
            {
                if (!groupBox.Tag?.ToString().Contains(UnthemedControl) ?? true)
                {
                    themed[typeof(GroupBox)].Add(groupBox);
                }
            }
            foreach (var listbox in this.GetAllChildrenExactlyOfType<ListBox>())
            {
                if (!listbox.Tag?.ToString().Contains(UnthemedControl) ?? true)
                {
                    themed[typeof(ListBox)].Add(listbox);
                }
            }
            foreach (var combobox in this.GetAllChildrenExactlyOfType<ComboBox>())
            {
                if (!combobox.Tag?.ToString().Contains(UnthemedControl) ?? true)
                {
                    themed[typeof(ComboBox)].Add(combobox);
                }
            }
            foreach (var textbox in this.GetAllChildrenExactlyOfType<TextBox>())
            {
                if (!textbox.Tag?.ToString().Contains(UnthemedControl) ?? true)
                {
                    themed[typeof(TextBox)].Add(textbox);
                }
            }
            foreach (var checkbox in this.GetAllChildrenExactlyOfType<CheckBox>())
            {
                if (!checkbox.Tag?.ToString().Contains(UnthemedControl) ?? true)
                {
                    themed[typeof(CheckBox)].Add(checkbox);
                }
            }
            foreach (var button in this.GetAllChildrenExactlyOfType<Button>())
            {
                if (!button.Tag?.ToString().Contains(UnthemedControl) ?? true)
                {
                        themed[typeof(Button)].Add(button);
                }
            }

            return themed;
        }

        /// <summary>
        /// Finds all editable <see cref="Control"/>s in the <see cref="MainEditorForm"/> that represent editable game data.
        /// </summary>
        /// <returns>A dictionary containing lists of controls, organized by type.</returns>
        private Dictionary<Type, Dictionary<Control, object>> GetEditableControls()
        {
            var editables = new Dictionary<Type, Dictionary<Control, object>>
            {
                [typeof(TextBox)] = new Dictionary<Control, object>(),
                [typeof(CheckBox)] = new Dictionary<Control, object>(),
                [typeof(ComboBox)] = new Dictionary<Control, object>(),
                [typeof(ListBox)] = new Dictionary<Control, object>(),
            };

            foreach (var textbox in EditorTabs.GetAllChildrenExactlyOfType<TextBox>())
            {
                if (!textbox.Tag?.ToString().Contains(UntrackedControl) ?? true)
                {
                    editables[typeof(TextBox)][textbox] = textbox.Text;
                }
            }
            foreach (var checkbox in EditorTabs.GetAllChildrenExactlyOfType<CheckBox>())
            {
                if (!checkbox.Tag?.ToString().Contains(UntrackedControl) ?? true)
                {
                    editables[typeof(CheckBox)][checkbox] = (bool?)checkbox.Checked;
                }
            }
            foreach (var combobox in EditorTabs.GetAllChildrenExactlyOfType<ComboBox>())
            {
                if (!combobox.Tag?.ToString().Contains(UntrackedControl) ?? true)
                {
                    editables[typeof(ComboBox)][combobox] = combobox.SelectedItem;
                }
            }
            foreach (var listbox in EditorTabs.GetAllChildrenExactlyOfType<ListBox>())
            {
                if (!listbox.Tag?.ToString().Contains(UntrackedControl) ?? true)
                {
                    editables[typeof(ListBox)][listbox] = listbox.SelectedItem;
                }
            }

            return editables;
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

        #region Conversion Functions
        /// <summary>
        /// Transforms an <c>object</c> into an <c>bool</c>, parsing if needed.
        /// </summary>
        /// <param name="input">A boxed <c>bool</c> or a <c>string</c> representing an <c>bool</c>.</param>
        /// <returns>The Boolean value given, or <c>false</c> if no value could be parsed.</returns>
        private static bool ValueToBool(object input)
            => input as bool?
            ?? (bool.TryParse(input?.ToString() ?? "", out var parsedBool) && parsedBool);

        /// <summary>
        /// Transforms an <c>object</c> into an <c>int</c>, parsing if needed.
        /// </summary>
        /// <param name="input">A boxed <c>int</c> or a <c>string</c> representing an <c>int</c>.</param>
        /// <returns>The integer value given, or 0 if no value could be parsed.</returns>
        private static int ValueToInt(object input)
            => input as int?
            ?? (int.TryParse(input?.ToString() ?? "", NumberStyles.Integer, null, out var parsedInt)
                ? parsedInt
                : 0);

        /// <summary>
        /// Transforms an <c>object</c> into an <see cref="ModelID">, parsing if needed.
        /// </summary>
        /// <param name="input">A boxed <see cref="ModelID.None"> or a <c>string</c> representing an <see cref="ModelID">.</param>
        /// <returns>The identifier given, or <see cref="ModelID.None"> if no ID could be parsed.</returns>
        private static ModelID ValueToID(object input)
            => (input as Model)?.ID
            ?? input as ModelID?
            ?? input as int?
            ?? (int.TryParse(input?.ToString() ?? "", NumberStyles.Integer, null, out var parsedInt)
                ? (ModelID)parsedInt
                : ModelID.None);

        /// <summary>
        /// Transforms an <c>object</c> into an <c>enum</c>, parsing if needed.
        /// </summary>
        /// <typeparam name="TEnum">An enumeration.</typeparam>
        /// <param name="input">A boxed <c>enum</c> or a <c>string</c> representing an <see cref="ModelID">.</param>
        /// <returns>The enumeration value given, or the default value for that enumeration if no value could be parsed.</returns>
        private static TEnum ValueToEnum<TEnum>(object input)
            where TEnum : struct, Enum, IConvertible
            => input as TEnum?
            ?? (input is TEnum enumerationValue
                ? enumerationValue
                : (Enum.TryParse<TEnum>(input?.ToString() ?? "", true, out var parsedInt)
                    ? parsedInt
                    : default(TEnum)));
        #endregion

        /// <summary>
        /// Given the index of an editor tab, return the <see cref="PictureBox"/> for the content it edits.
        /// </summary>
        /// <param name="inTabIndex">The index of the tab sought.</param>
        /// <returns>The PictureBox instance.</returns>
        private PictureBox GetPictureBoxForTab(int inTabIndex)
            => inTabIndex switch
            {
                GamesTabIndex => GameIconPictureBox,
                BlocksTabIndex => BlockPictureBox,
                FloorsTabIndex => FloorPictureBox,
                FurnishingsTabIndex => FurnishingPictureBox,
                CollectiblesTabIndex => CollectiblePictureBox,
                CharactersTabIndex => CharacterPictureBox,
                CrittersTabIndex => CritterPictureBox,
                ItemsTabIndex => ItemPictureBox,
                BiomeRecipesTabIndex => BiomePictureBox,
                CraftingRecipesTabIndex => CraftingPictureBox,
                RoomRecipesTabIndex => RoomPictureBox,
                MapsTabIndex => null,
                ScriptsTabIndex => null,
                _ => null,
            };

        /// <summary>
        /// Given the index of an editor tab, return the corresponding primary <see cref="ListBox"/>.
        /// </summary>
        /// <param name="inTabIndex">The index of the tab of the ListBox sought.</param>
        /// <returns>The ListBox used to select models to work with, or <c>null</c> if none exists for this tab.</returns>
        private ListBox GetPrimaryListBoxForTab(int inTabIndex)
            => inTabIndex switch
            {
                GamesTabIndex => GameListBox,
                BlocksTabIndex => BlockListBox,
                FloorsTabIndex => FloorListBox,
                FurnishingsTabIndex => FurnishingListBox,
                CollectiblesTabIndex => CollectibleListBox,
                CharactersTabIndex => CharacterListBox,
                CrittersTabIndex => CritterListBox,
                ItemsTabIndex => ItemListBox,
                BiomeRecipesTabIndex => BiomeListBox,
                CraftingRecipesTabIndex => CraftingListBox,
                RoomRecipesTabIndex => RoomListBox,
                MapsTabIndex => null,
                ScriptsTabIndex => null,
                _ => null,
            };

        /// <summary>
        /// Given the index of an editor tab, return the default <see cref="ModelID"/> for the content it edits.
        /// </summary>
        /// <param name="inTabIndex">The index of the tab sought.</param>
        /// <returns>The corresponding ID, or <see cref="ModelID.None"/> on out of range input.</returns>
        // TODO If this is still not being used at 1.0, remove it.
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
            => inTabIndex switch
            {
                GamesTabIndex => GameListBox.SelectedItem as GameModel,
                BlocksTabIndex => BlockListBox.SelectedItem as BlockModel,
                FloorsTabIndex => FloorListBox.SelectedItem as FloorModel,
                FurnishingsTabIndex => FurnishingListBox.SelectedItem as FurnishingModel,
                CollectiblesTabIndex => CollectibleListBox.SelectedItem as CollectibleModel,
                CharactersTabIndex => CharacterListBox.SelectedItem as CharacterModel,
                CrittersTabIndex => CritterListBox.SelectedItem as CritterModel,
                ItemsTabIndex => ItemListBox.SelectedItem as ItemModel,
                BiomeRecipesTabIndex => BiomeListBox.SelectedItem as BiomeRecipe,
                CraftingRecipesTabIndex => CraftingListBox.SelectedItem as CraftingRecipe,
                RoomRecipesTabIndex => RoomListBox.SelectedItem as RoomRecipe,
                MapsTabIndex => throw new NotImplementedException(),
                ScriptsTabIndex => throw new NotImplementedException(),
                _ => null,
            };

        /// <summary>Given the index of an editor tab and an editor <see cref="Control"/>, return the corresponding property accessor.</summary>
        /// <param name="inTabIndex">The index of an editor tab.</param>
        /// <param name="inControl">The <see cref="Control"/> corresponding to the property sought.</param>
        /// <returns>A method for editing the property's value, or <c>null</c> if the input combination is not defined.</returns>
        private Action<object> GetPropertyAccessorForTabAndControl(int inTabIndex, Control inControl)
            => null == inControl
            ? null
            : (inTabIndex, inControl.Name) switch
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
            => null == inModel
            ? (Action<object>)null
            : (inTabIndex, inControl.Name) switch
            {
                #region GameModels
                (GamesTabIndex, "GameNameTextBox")
                    => (input) => (inModel as IGameModelEdit).Name = input.ToString(),
                (GamesTabIndex, "GameDescriptionTextBox")
                    => (input) => (inModel as IGameModelEdit).Description = input.ToString(),
                (GamesTabIndex, "GameCommentTextBox")
                    => (input) => (inModel as IGameModelEdit).Comment = input.ToString(),
                (GamesTabIndex, "GameIsEpisodeCheckBox")
                    => (input) => (inModel as IGameModelEdit).IsEpisode = ValueToBool(input),
                (GamesTabIndex, "GameEpisodeTitleTextBox")
                    => (input) => (inModel as IGameModelEdit).EpisodeTitle = input.ToString(),
                (GamesTabIndex, "GameEpisodeNumberTextBox")
                    => (input) => (inModel as IGameModelEdit).EpisodeNumber = ValueToInt(input),
                (GamesTabIndex, "GamePlayerCharacterComboBox")
                    => (input) => (inModel as IGameModelEdit).PlayerCharacterID = ValueToID(input),
                (GamesTabIndex, "GameFirstScriptComboBox")
                    => (input) => (inModel as IGameModelEdit).FirstScriptID = ValueToID(input),
                #endregion

                #region BlockModels
                (BlocksTabIndex, "BlockNameTextBox")
                    => (input) => (inModel as IBlockModelEdit).Name = input.ToString(),
                (BlocksTabIndex, "BlockDescriptionTextBox")
                    => (input) => (inModel as IBlockModelEdit).Description = input.ToString(),
                (BlocksTabIndex, "BlockCommentTextBox")
                    => (input) => (inModel as IBlockModelEdit).Comment = input.ToString(),
                (BlocksTabIndex, "BlockMaxToughnessTextBox")
                    => (input) => (inModel as IBlockModelEdit).MaxToughness = ValueToInt(input),
                (BlocksTabIndex, "BlockIsFlammableCheckBox")
                    => (input) => (inModel as IBlockModelEdit).IsFlammable = ValueToBool(input),
                (BlocksTabIndex, "BlockIsLiquidCheckBox")
                    => (input) => (inModel as IBlockModelEdit).IsLiquid = ValueToBool(input),
                (BlocksTabIndex, "BlockGatherToolComboBox")
                    => (input) => (inModel as IBlockModelEdit).GatherTool = ValueToEnum<GatheringTool>(input),
                (BlocksTabIndex, "BlockGatherEffectComboBox")
                    => (input) => (inModel as IBlockModelEdit).GatherEffect = ValueToEnum<GatheringEffect>(input),
                (BlocksTabIndex, "BlockDroppedCollectibleIDComboBox")
                    => (input) => (inModel as IBlockModelEdit).CollectibleID = ValueToID(input),
                (BlocksTabIndex, "BlockEquivalentItemComboBox")
                    => (input) => (inModel as IBlockModelEdit).ItemID = ValueToID(input),
                #endregion

                #region FloorModels
                (FloorsTabIndex, "FloorNameTextBox")
                    => (input) => (inModel as IFloorModelEdit).Name = input.ToString(),
                (FloorsTabIndex, "FloorDescriptionTextBox")
                    => (input) => (inModel as IFloorModelEdit).Description = input.ToString(),
                (FloorsTabIndex, "FloorCommentTextBox")
                    => (input) => (inModel as IFloorModelEdit).Comment = input.ToString(),
                (FloorsTabIndex, "FloorTrenchNameTextBox")
                    => (input) => (inModel as IFloorModelEdit).TrenchName = input.ToString(),
                (FloorsTabIndex, "FloorlItemIDComboBox")
                    => (input) => (inModel as IFloorModelEdit).ItemID = ValueToID(input),
                (FloorsTabIndex, "FloorModificationToolComboBox")
                    => (input) => (inModel as IFloorModelEdit).ModTool = ValueToEnum<ModificationTool>(input),
                #endregion

                #region FurnishingModels
                (FurnishingsTabIndex, "FurnishingNameTextBox")
                    => (input) => (inModel as IFurnishingModelEdit).Name = input.ToString(),
                (FurnishingsTabIndex, "FurnishingDescriptionTextBox")
                    => (input) => (inModel as IFurnishingModelEdit).Description = input.ToString(),
                (FurnishingsTabIndex, "FurnishingCommentTextBox")
                    => (input) => (inModel as IFurnishingModelEdit).Comment = input.ToString(),
                (FurnishingsTabIndex, "FurnishingEquivalentItemComboBox")
                    => (input) => (inModel as IFurnishingModelEdit).ItemID = ValueToID(input),
                (FurnishingsTabIndex, "FurnishingEntryTypeComboBox")
                    => (input) => (inModel as IFurnishingModelEdit).Entry = ValueToEnum<EntryType>(input),
                (FurnishingsTabIndex, "FurnishingSwapWithFurnishingComboBox")
                    => (input) => (inModel as IFurnishingModelEdit).SwapID = ValueToID(input),
                (FurnishingsTabIndex, "FurnishingIsEnclosingCheckBox")
                    => (input) => (inModel as IFurnishingModelEdit).IsEnclosing = ValueToBool(input),
                (FurnishingsTabIndex, "FurnishingIsFlammableCheckBox")
                    => (input) => (inModel as IFurnishingModelEdit).IsFlammable = ValueToBool(input),
                (FurnishingsTabIndex, "FurnishingIsWalkableCheckBox")
                    => (input) => (inModel as IFurnishingModelEdit).IsWalkable = ValueToBool(input),
                #endregion

                #region CollectibleModels
                (CollectiblesTabIndex, "CollectibleNameTextBox")
                    => (input) => (inModel as ICollectibleModelEdit).Name = input.ToString(),
                (CollectiblesTabIndex, "CollectibleDescriptionTextBox")
                    => (input) => (inModel as ICollectibleModelEdit).Description = input.ToString(),
                (CollectiblesTabIndex, "CollectibleCommentTextBox")
                    => (input) => (inModel as ICollectibleModelEdit).Comment = input.ToString(),
                (CollectiblesTabIndex, "CollectibleEffectAmountTextBox")
                    => (input) => (inModel as ICollectibleModelEdit).EffectAmount = ValueToInt(input),
                (CollectiblesTabIndex, "CollectibleCollectionEffectComboBox")
                    => (input) => (inModel as ICollectibleModelEdit).CollectionEffect = ValueToEnum<CollectingEffect>(input),
                (CollectiblesTabIndex, "CollectibleEquivalentItemComboBox")
                    => (input) => (inModel as ICollectibleModelEdit).ItemID = ValueToID(input),
                #endregion

                #region CharacterModels
                (CharactersTabIndex, "CharacterNameTextBox")
                    => (input) => (inModel as ICharacterModelEdit).Name = input.ToString(),
                (CharactersTabIndex, "CharacterDescriptionTextBox")
                    => (input) => (inModel as ICharacterModelEdit).Description = input.ToString(),
                (CharactersTabIndex, "CharacterCommentTextBox")
                    => (input) => (inModel as ICharacterModelEdit).Comment = input.ToString(),
                (CharactersTabIndex, "CharacterNativeBiomeComboBox")
                    => (input) => (inModel as ICharacterModelEdit).NativeBiomeID = ValueToID(input),
                (CharactersTabIndex, "CharacterPrimaryBehaviorComboBox")
                    => (input) => (inModel as ICharacterModelEdit).PrimaryBehaviorID = ValueToID(input),
                (CharactersTabIndex, "CharacterStoryIDTextBox")
                    => (input) => (inModel as ICharacterModelEdit).StoryCharacterID = input.ToString(),
                (CharactersTabIndex, "CharacterPronounComboBox")
                    => (input) => (inModel as ICharacterModelEdit).Pronouns = input.ToString(),
                (CharactersTabIndex, "CharacterStartingDialogueComboBox")
                    => (input) => (inModel as ICharacterModelEdit).StartingDialogueID = ValueToID(input),
                (CharactersTabIndex, "CharacterStartingInventoryComboBox")
                    => (input) =>
                    {
                        var editModel = inModel as CharacterModel;
                        var slots = (IList<InventorySlot>)input;
                        foreach (var slot in editModel.StartingInventory)
                        {
                            editModel.StartingInventory.Take(slot);
                        }
                        foreach (var slot in slots)
                        {
                            editModel.StartingInventory.Give(slot);
                        }
                    }
                ,
                (CharactersTabIndex, "CharacterStartingQuestsListBox")
                    => (input) =>
                    {
                        var editModel = inModel as ICharacterModelEdit;
                        editModel.StartingQuestIDs.Clear();
                        editModel.StartingQuestIDs.ToList().AddRange((IList<ModelID>)input);
                    },
                #endregion

                #region CritterModels
                (CrittersTabIndex, "CritterNameTextBox")
                    => (input) => (inModel as ICritterModelEdit).Name = input.ToString(),
                (CrittersTabIndex, "CritterDescriptionTextBox")
                    => (input) => (inModel as ICritterModelEdit).Description = input.ToString(),
                (CrittersTabIndex, "CritterCommentTextBox")
                    => (input) => (inModel as ICritterModelEdit).Comment = input.ToString(),
                (CrittersTabIndex, "CritterNativeBiomeComboBox")
                    => (input) => (inModel as ICritterModelEdit).NativeBiomeID = ValueToID(input),
                (CrittersTabIndex, "CritterPrimaryBehaviorComboBox")
                    => (input) => (inModel as ICritterModelEdit).PrimaryBehaviorID = ValueToID(input),
                    #endregion

                #region ItemModels
                (ItemsTabIndex, "ItemNameTextBox")
                    => (input) => (inModel as IItemModelEdit).Name = input.ToString(),
                (ItemsTabIndex, "ItemDescriptionTextBox")
                    => (input) => (inModel as IItemModelEdit).Description = input.ToString(),
                (ItemsTabIndex, "ItemCommentTextBox")
                    => (input) => (inModel as IItemModelEdit).Comment = input.ToString(),
                (ItemsTabIndex, "ItemSubtypeComboBox")
                    => (input) => (inModel as IItemModelEdit).Subtype = ValueToEnum<ItemType>(input),
                (ItemsTabIndex, "ItemPriceTextBox")
                    => (input) => (inModel as IItemModelEdit).Price = ValueToInt(input),
                (ItemsTabIndex, "ItemTagListBox")
                    => (input) =>
                    {
                        var editModel = inModel as IItemModelEdit;
                        editModel.ItemTags.ToList().Add((ModelTag)input);
                    },
                (ItemsTabIndex, "ItemStackMaxTextBox")
                    => (input) => (inModel as IItemModelEdit).StackMax = ValueToInt(input),
                (ItemsTabIndex, "ItemRarityTextBox")
                    => (input) => (inModel as IItemModelEdit).Rarity = ValueToInt(input),
                (ItemsTabIndex, "ItemEffectWhenUsedComboBox")
                    => (input) => (inModel as IItemModelEdit).EffectWhenUsedID = ValueToID(input),
                (ItemsTabIndex, "ItemEffectWhileHeldComboBox")
                    => (input) => (inModel as IItemModelEdit).EffectWhileHeldID = ValueToID(input),
                (ItemsTabIndex, "ItemEquivalentParquetComboBox")
                    => (input) => (inModel as IItemModelEdit).ParquetID = ValueToID(input),
                #endregion

                #region BiomeRecipes
                (BiomeRecipesTabIndex, "BiomeNameTextBox")
                    => (input) => (inModel as IBiomeRecipeEdit).Name = input.ToString(),
                (BiomeRecipesTabIndex, "BiomeDescriptionTextBox")
                    => (input) => (inModel as IBiomeRecipeEdit).Description = input.ToString(),
                (BiomeRecipesTabIndex, "BiomeCommentTextBox")
                    => (input) => (inModel as IBiomeRecipeEdit).Comment = input.ToString(),
                (BiomeRecipesTabIndex, "BiomeTierTextBox")
                    => (input) => (inModel as IBiomeRecipeEdit).Tier = ValueToInt(input),
                (BiomeRecipesTabIndex, "BiomeIsLiquidBasedCheckBox")
                    => (input) => (inModel as IBiomeRecipeEdit).IsLiquidBased = ValueToBool(input),
                (BiomeRecipesTabIndex, "BiomeIsRoomBasedCheckBox")
                    => (input) => (inModel as IBiomeRecipeEdit).IsRoomBased = ValueToBool(input),
                (BiomeRecipesTabIndex, "BiomeEntryRequirementsListBox")
                    => (input) =>
                    {
                        var editRecipe = inModel as IBiomeRecipeEdit;
                        editRecipe.EntryRequirements.ToList().Add((ModelTag)input);
                    },
                (BiomeRecipesTabIndex, "BiomeParquetCriteriaListBox")
                    => (input) =>
                    {
                        var editRecipe = inModel as IBiomeRecipeEdit;
                        editRecipe.ParquetCriteria.ToList().Add((ModelTag)input);
                    },
                #endregion

                #region CraftingRecipes
                (CraftingRecipesTabIndex, "CraftingNameTextBox")
                    => (input) => (inModel as ICraftingRecipeEdit).Name = input.ToString(),
                (CraftingRecipesTabIndex, "CraftingDescriptionTextBox")
                    => (input) => (inModel as ICraftingRecipeEdit).Description = input.ToString(),
                (CraftingRecipesTabIndex, "CraftingCommentTextBox")
                    => (input) => (inModel as ICraftingRecipeEdit).Comment = input.ToString(),
                (CraftingRecipesTabIndex, "CraftingIngredientsListBox")
                    => (input) =>
                    {
                        var editRecipe = inModel as ICraftingRecipeEdit;
                        editRecipe.Ingredients.Clear();
                        editRecipe.Ingredients.ToList().AddRange((IList<RecipeElement>)input);
                    },
                (CraftingRecipesTabIndex, "CraftingProductsListBox")
                    => (input) =>
                    {
                        var editRecipe = inModel as ICraftingRecipeEdit;
                        editRecipe.Products.Clear();
                        editRecipe.Products.ToList().AddRange((IList<RecipeElement>)input);
                    },
                #endregion
                
                #region RoomRecipes
                (RoomRecipesTabIndex, "RoomNameTextBox")
                    => (input) => (inModel as IRoomRecipeEdit).Name = input.ToString(),
                (RoomRecipesTabIndex, "RoomDescriptionTextBox")
                    => (input) => (inModel as IRoomRecipeEdit).Description = input.ToString(),
                (RoomRecipesTabIndex, "RoomCommentTextBox")
                    => (input) => (inModel as IRoomRecipeEdit).Comment = input.ToString(),
                (RoomRecipesTabIndex, "RoomMinimumWalkableSpacesTextBox")
                    => (input) => (inModel as IRoomRecipeEdit).MinimumWalkableSpaces = ValueToInt(input),
                (RoomRecipesTabIndex, "RoomRequiredFurnishingsListBox")
                    => (input) =>
                    {
                        var editRecipe = inModel as IRoomRecipeEdit;
                        editRecipe.OptionallyRequiredFurnishings.Clear();
                        editRecipe.OptionallyRequiredFurnishings.ToList().AddRange((IList<RecipeElement>)input);
                    },
                (RoomRecipesTabIndex, "RoomRequiredBlocksListBox")
                    => (input) =>
                    {
                        var editRecipe = inModel as IRoomRecipeEdit;
                        editRecipe.OptionallyRequiredPerimeterBlocks.Clear();
                        editRecipe.OptionallyRequiredPerimeterBlocks.ToList().AddRange((IList<RecipeElement>)input);
                    },
                (RoomRecipesTabIndex, "RoomRequiredFloorsListBox")
                    => (input) =>
                    {
                        var editRecipe = inModel as IRoomRecipeEdit;
                        editRecipe.OptionallyRequiredWalkableFloors.Clear();
                        editRecipe.OptionallyRequiredWalkableFloors.ToList().AddRange((IList<RecipeElement>)input);
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

        #region Update Main Display
        /// <summary>
        /// Updates the form when it receives focus, for example after closing the options dialogue box.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void MainEditorForm_Activated(object sender, EventArgs e)
        {
            FlavorFilterGroupBox.Enabled = Settings.Default.UseFlavorFilters;
            FlavorFilterGroupBox.Visible = Settings.Default.UseFlavorFilters;
            if (oldTheme != Settings.Default.CurrentEditorTheme)
            {
                UpdateEditorTheme();
            }

            // Select current tab.
            EditorTabs.SelectedTab?.Select();
            // If possible, select default model in current tab.
            if (null == GetSelectedModelForTab(EditorTabs.SelectedIndex))
            {
                var selectedListBox = GetPrimaryListBoxForTab(EditorTabs.SelectedIndex);
                if (null != selectedListBox)
                {
                    selectedListBox.SelectedItem = (selectedListBox.Items as IList<object>)?.ElementAtOrDefault(0);
                }
            }
        }

        /// <summary>
        /// Applies the current <see cref="EditorTheme"/> to <see cref="MainEditorForm"/> and its <see cref="Control"/>s.
        /// </summary>
        private void UpdateEditorTheme()
        {
            Text = "UpdateEditorTheme";
            Color ControlBackgroundWhite;
            Color ControlBackgroundColor;
            Color UneditableBackgroundColor;
            Color HighlightColor;
            Color ControlForegroundColor;
            Color BorderColor;
            Color MouseDownColor;
            Color MouseOverColor;
            Color GamesTabColor;
            Color ParquetsTabColor;
            Color BeingsTabColor;
            Color ItemsTabColor;
            Color RecipesTabColor;
            Color MapsTabColor;
            Color ScriptsTabColor;

            #region Set Up Theme
            switch (Settings.Default.CurrentEditorTheme)
            {
                case nameof(EditorTheme.Femme):
                    ControlBackgroundWhite = Color.Snow;
                    ControlBackgroundColor = Color.MistyRose;
                    UneditableBackgroundColor = Color.Pink;
                    HighlightColor = Color.HotPink;
                    ControlForegroundColor = Color.Indigo;
                    BorderColor = Color.PaleVioletRed;
                    MouseDownColor = Color.PaleVioletRed;
                    MouseOverColor = Color.LightPink;
                    GamesTabColor = Color.MistyRose;
                    ParquetsTabColor = Color.MistyRose;
                    BeingsTabColor = Color.MistyRose;
                    ItemsTabColor = Color.MistyRose;
                    RecipesTabColor = Color.MistyRose;
                    MapsTabColor = Color.MistyRose;
                    ScriptsTabColor = Color.MistyRose;
                    break;
                case nameof(EditorTheme.Colorful):
                    ControlBackgroundWhite = SystemColors.Window;
                    ControlBackgroundColor = SystemColors.Control;
                    UneditableBackgroundColor = SystemColors.ControlLight;
                    HighlightColor = SystemColors.Highlight;
                    ControlForegroundColor = SystemColors.ControlText;
                    BorderColor = Color.Empty;
                    MouseDownColor = Color.Empty;
                    MouseOverColor = Color.Empty;
                    GamesTabColor = SystemColors.Control;
                    ParquetsTabColor = SystemColors.Control;
                    BeingsTabColor = SystemColors.Control;
                    ItemsTabColor = SystemColors.Control;
                    RecipesTabColor = SystemColors.Control;
                    MapsTabColor = SystemColors.Control;
                    ScriptsTabColor = SystemColors.Control;
                    break;
                // EditorTheme.OSDefault:
                default:
                    ControlBackgroundWhite = SystemColors.Window;
                    ControlBackgroundColor = SystemColors.Control;
                    UneditableBackgroundColor = SystemColors.ControlLight;
                    HighlightColor = SystemColors.Highlight;
                    ControlForegroundColor = SystemColors.ControlText;
                    BorderColor = Color.Empty;
                    MouseDownColor = Color.Empty;
                    MouseOverColor = Color.Empty;
                    GamesTabColor = SystemColors.Control;
                    ParquetsTabColor = SystemColors.Control;
                    BeingsTabColor = SystemColors.Control;
                    ItemsTabColor = SystemColors.Control;
                    RecipesTabColor = SystemColors.Control;
                    MapsTabColor = SystemColors.Control;
                    ScriptsTabColor = SystemColors.Control;
                    break;
            }
            #endregion

            #region Apply Theme to Primary Form
            BackColor = ControlBackgroundColor;
            ForeColor = ControlForegroundColor;
            ToolStripProgressBar.BackColor = UneditableBackgroundColor;
            ToolStripProgressBar.ForeColor = HighlightColor;
            EditorStatusStrip.BackColor = ControlBackgroundColor;
            MainMenuBar.BackColor = ControlBackgroundColor;
            MainMenuBar.ForeColor = ControlForegroundColor;
            #endregion

            #region Apply Theme to Tabs
            GamesTabPage.BackColor = GamesTabColor;
            BlocksTabPage.BackColor =
                FloorsTabPage.BackColor =
                FurnishingsTabPage.BackColor =
                CollectiblesTabPage.BackColor = ParquetsTabColor;
            CharactersTabPage.BackColor =
                CrittersTabPage.BackColor = BeingsTabColor;
            ItemsTabPage.BackColor = ItemsTabColor;
            BiomesTabPage.BackColor =
                CraftingRecipesTabPage.BackColor =
                RoomRecipesTabPage.BackColor = RecipesTabColor;
            MapsTabPage.BackColor = MapsTabColor;
            ScriptsTabPage.BackColor = ScriptsTabColor;
            #endregion

            #region Apply Theme to Controls
            foreach (var groupBox in ThemedControls[typeof(GroupBox)])
            {
                groupBox.BackColor = ControlBackgroundColor;
                groupBox.ForeColor = ControlForegroundColor;
            }
            foreach (var pictureBox in PictureBoxes)
            {
                pictureBox.BackColor = UneditableBackgroundColor;
            }
            foreach (var listBox in ThemedControls[typeof(ListBox)])
            {
                listBox.BackColor = ControlBackgroundWhite;
                listBox.ForeColor = ControlForegroundColor;
            }
            foreach (var comboBox in ThemedControls[typeof(ComboBox)])
            {
                comboBox.BackColor = ControlBackgroundWhite;
                comboBox.ForeColor = ControlForegroundColor;
            }
            foreach (var textBox in ThemedControls[typeof(TextBox)])
            {
                textBox.BackColor = textBox.Tag?.ToString().Contains(UneditableTextBox) ?? false
                    ? UneditableBackgroundColor
                    : ControlBackgroundWhite;
                textBox.ForeColor = ControlForegroundColor;
            }
            foreach (var checkBox in ThemedControls[typeof(CheckBox)])
            {
                checkBox.BackColor = ControlBackgroundWhite;
                checkBox.ForeColor = ControlForegroundColor;
            }
            foreach (var button in ThemedControls[typeof(Button)])
            {
                ((Button)button).FlatAppearance.BorderColor = BorderColor;
                ((Button)button).FlatAppearance.MouseDownBackColor = MouseDownColor;
                ((Button)button).FlatAppearance.MouseOverBackColor = MouseOverColor;
            }
            #endregion
        }

        /// <summary>
        /// Clears and repopulates the primary and secondary lists after an update.
        /// </summary>
        private void UpdateDisplay()
        {
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
                    picturebox.Image = Resources.ImageNotFoundGraphic;
                    picturebox.Update();
                }
            }
            #endregion

            // TODO Remember to incrementally update Primary and Secondary lists after Add New and Remove button presses.

            #region Repopulate Primary List Boxes
            RepopulateListBox(GameListBox, All.Games);
            RepopulateListBox(CritterListBox, All.Critters);
            RepopulateListBox(CharacterListBox, All.Characters);
            RepopulateListBox(BiomeListBox, All.Biomes);
            RepopulateListBox(CraftingListBox, All.CraftingRecipes);
            RepopulateListBox(ItemListBox, All.Items);
            RepopulateListBox(FloorListBox, All.Floors);
            RepopulateListBox(BlockListBox, All.Blocks);
            RepopulateListBox(FurnishingListBox, All.Furnishings);
            RepopulateListBox(CollectibleListBox, All.Collectibles);
            RepopulateListBox(RoomListBox, All.RoomRecipes);
            #endregion

            #region Repopulat Secondary Combo Boxes
            RepopulateComboBox(GamePlayerCharacterComboBox, All.Characters);
            RepopulateComboBox(GameFirstScriptComboBox, All.Scripts);
            RepopulateComboBox(BlockEquivalentItemComboBox, All.Items);
            RepopulateComboBox(BlockGatherToolComboBox, Enumerable.Cast<object>(Enum.GetValues(typeof(GatheringTool))));
            RepopulateComboBox(BlockGatherEffectComboBox, Enumerable.Cast<object>(Enum.GetValues(typeof(GatheringEffect))));
            RepopulateComboBox(BlockDroppedCollectibleIDComboBox, All.Collectibles);
            RepopulateComboBox(FloorEquivalentItemComboBox, All.Items);
            RepopulateComboBox(FloorModificationToolComboBox, Enumerable.Cast<object>(Enum.GetValues(typeof(ModificationTool))));
            RepopulateComboBox(FurnishingEquivalentItemComboBox, All.Items);
            RepopulateComboBox(FurnishingEntryTypeComboBox, Enumerable.Cast<object>(Enum.GetValues(typeof(EntryType))));
            RepopulateComboBox(FurnishingSwapWithFurnishingComboBox, All.Furnishings);
            RepopulateComboBox(CollectibleEquivalentItemComboBox, All.Items);
            RepopulateComboBox(CollectibleCollectionEffectComboBox, Enumerable.Cast<object>(Enum.GetValues(typeof(CollectingEffect))));
            RepopulateComboBox(CharacterNativeBiomeComboBox, All.Biomes);
            RepopulateComboBox(CharacterPrimaryBehaviorComboBox, All.Scripts);
            RepopulateComboBox(CharacterPronounComboBox, All.PronounGroups);
            RepopulateComboBox(CharacterStartingDialogueComboBox, All.Scripts);
            RepopulateComboBox(CharacterStartingInventoryComboBox, All.Scripts);
            RepopulateComboBox(CritterNativeBiomeComboBox, All.Biomes);
            RepopulateComboBox(CritterPrimaryBehaviorComboBox, All.Scripts);
            RepopulateComboBox(ItemSubtypeComboBox, Enumerable.Cast<object>(Enum.GetValues(typeof(ItemType))));
            RepopulateComboBox(ItemEffectWhileHeldComboBox, All.Scripts);
            RepopulateComboBox(ItemEffectWhenUsedComboBox, All.Scripts);
            RepopulateComboBox(ItemEquivalentParquetComboBox, All.Parquets);
            // TODO Scripts
            #endregion
        }

        /// <summary>
        /// Repopulates the given list box with the given collection of <see cref="object"/>s.
        /// </summary>
        /// <param name="inListBox">The UI to repopulate.</param>
        /// <param name="inSource">The objects to populate the UI with.</param>
        /// <remarks>This should only be called if <see cref="All"/> has actually changed.</remarks>
        private void RepopulateListBox(ListBox inListBox, IEnumerable<Model> inSource)
        {
            if (null != inSource)
            {
                inListBox.SelectedItem = null;
                inListBox.BeginUpdate();
                inListBox.Items.Clear();
                inListBox.Items.AddRange(inSource.Where(model => model.ID != ModelID.None).ToArray<object>());
                inListBox.EndUpdate();
            }
        }

        /// <summary>
        /// Repopulates the given list box with the given collection of <see cref="object"/>s.
        /// </summary>
        /// <param name="inListBox">The UI to repopulate.</param>
        /// <param name="inSource">The objects to populate the UI with.</param>
        /// <remarks>This should only be called if <see cref="All"/> has actually changed.</remarks>
        private void RepopulateListBox(ListBox inListBox, IEnumerable<object> inSource)
        {
            if (null != inSource)
            {
                inListBox.SelectedItem = null;
                inListBox.BeginUpdate();
                inListBox.Items.Clear();
                // Ignore any input value that evaluates to "None".
                inListBox.Items.AddRange(inSource.Where(value => 0 != string.Compare(value.ToString(),
                                                                                     nameof(ModelID.None),
                                                                                     comparisonType: StringComparison.OrdinalIgnoreCase))
                                                 .ToArray());
                inListBox.EndUpdate();
            }
        }

        /// <summary>
        /// Repopulates the given combo box with the given collection.
        /// </summary>
        /// <param name="inComboBox">The UI to repopulate.</param>
        /// <param name="inSource">The objects to populate the UI with.</param>
        /// <remarks>This should only be called if <see cref="All"/> has actually changed.</remarks>
        private void RepopulateComboBox(ComboBox inComboBox, IEnumerable<object> inSource)
        {
            if (null != inSource)
            {
                inComboBox.SelectedItem = null;
                inComboBox.BeginUpdate();
                inComboBox.Items.Clear();
                foreach (var value in inSource)
                {
                    _ = inComboBox.Items.Add(value);
                }
                inComboBox.EndUpdate();
            }
        }
        #endregion

        #region Update Tab Display
        /// <summary>
        /// Loads the image associated with the given <see cref="ModelID"/> in the given <see cref="PictureBox"/>.
        /// </summary>
        /// <param name="inPictureBox">The PictureBox to load the image into.</param>
        /// <param name="inID">The ID of the model whose image will be loaded.</param>
        private void PictureBoxLoadFromStorage(PictureBox inPictureBox, ModelID inID)
        {
            var imagePathAndFilename = Path.Combine(EditorCommands.GetGraphicsPathForModelID(inID), $"{inID}.png");
            if (File.Exists(imagePathAndFilename))
            {
                using var imageStream = new MemoryStream(File.ReadAllBytes(imagePathAndFilename));
                inPictureBox.Image = Image.FromStream(imageStream);
            }
            else
            {
                inPictureBox.Image = Resources.ImageNotFoundGraphic;
            }
        }

        /// <summary>
        /// Populates the Games tab when a <see cref="GameModel"/> is selected in the GameListBox.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void GameListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (null == GameListBox.SelectedItem)
            {
                GameIDExample.Text = ModelID.None.ToString();
                GameNameTextBox.Text = "";
                GameDescriptionTextBox.Text = "";
                GameCommentTextBox.Text = "";
                GameIsEpisodeCheckBox.Checked = false;
                GameEpisodeTitleTextBox.Text = "";
                GameEpisodeNumberTextBox.Text = "";
                GamePlayerCharacterComboBox.SelectedItem = null;
                GameFirstScriptComboBox.SelectedItem = null;
                GameIconPictureBox.Image = Resources.ImageNotFoundGraphic;
            }
            else if (GameListBox.SelectedItem is GameModel model
                    && null != model)
            {
                GameIDExample.Text = model.ID.ToString();
                GameNameTextBox.Text = model.Name;
                GameDescriptionTextBox.Text = model.Description;
                GameCommentTextBox.Text = model.Comment;
                GameIsEpisodeCheckBox.Checked = model.IsEpisode;
                GameEpisodeTitleTextBox.Text = model.EpisodeTitle;
                GameEpisodeNumberTextBox.Text = model.EpisodeNumber.ToString();
                GamePlayerCharacterComboBox.SelectedItem = All.Characters.GetOrNull(model.PlayerCharacterID);
                GameFirstScriptComboBox.SelectedItem = All.Scripts.GetOrNull(model.FirstScriptID);
                PictureBoxLoadFromStorage(GameIconPictureBox, model.ID);
            }
        }

        /// <summary>
        /// Populates the Blocks tab when a <see cref="BlockModel"/> is selected in the BlockListBox.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void BlockListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            BlockAddsToBiomeListBox.SelectedItem = null;
            BlockAddsToRoomListBox.SelectedItem = null;
            if (null == BlockListBox.SelectedItem)
            {
                BlockIDExample.Text = ModelID.None.ToString();
                BlockNameTextBox.Text = "";
                BlockDescriptionTextBox.Text = "";
                BlockCommentTextBox.Text = "";
                BlockEquivalentItemComboBox.SelectedItem = null;
                BlockAddsToBiomeListBox.Items.Clear();
                BlockAddsToRoomListBox.Items.Clear();
                BlockGatherToolComboBox.SelectedItem = GatheringTool.None;
                BlockGatherEffectComboBox.SelectedItem = GatheringEffect.None;
                BlockDroppedCollectibleIDComboBox.SelectedItem = null;
                BlockIsFlammableCheckBox.Checked = false;
                BlockIsLiquidCheckBox.Checked = false;
                BlockMaxToughnessTextBox.Text = "";
                BlockPictureBox.Image = Resources.ImageNotFoundGraphic;
            }
            else if (BlockListBox.SelectedItem is BlockModel model
                    && null != model)
            {
                BlockIDExample.Text = model.ID.ToString();
                BlockNameTextBox.Text = model.Name;
                BlockDescriptionTextBox.Text = model.Description;
                BlockCommentTextBox.Text = model.Comment;
                BlockEquivalentItemComboBox.SelectedItem = All.Items.GetOrNull(model.ItemID);
                RepopulateListBox(BlockAddsToBiomeListBox, model.AddsToBiome);
                RepopulateListBox(BlockAddsToRoomListBox, model.AddsToRoom);
                BlockGatherToolComboBox.SelectedItem = model.GatherTool;
                BlockGatherEffectComboBox.SelectedItem = model.GatherEffect;
                BlockDroppedCollectibleIDComboBox.SelectedItem = All.Collectibles.GetOrNull(model.CollectibleID);
                BlockIsFlammableCheckBox.Checked = model.IsFlammable;
                BlockIsLiquidCheckBox.Checked = model.IsLiquid;
                BlockMaxToughnessTextBox.Text = model.MaxToughness.ToString();
                PictureBoxLoadFromStorage(BlockPictureBox, model.ID);
            }
        }

        /// <summary>
        /// Populates the Floors tab when a <see cref="FloorModel"/> is selected in the FloorListBox.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void FloorListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            FloorAddsToBiomeListBox.SelectedItem = null;
            FloorAddsToRoomListBox.SelectedItem = null;
            if (null == FloorListBox.SelectedItem)
            {
                FloorIDExample.Text = ModelID.None.ToString();
                FloorNameTextBox.Text = "";
                FloorDescriptionTextBox.Text = "";
                FloorCommentTextBox.Text = "";
                FloorEquivalentItemComboBox.SelectedItem = null;
                FloorAddsToBiomeListBox.Items.Clear();
                FloorAddsToRoomListBox.Items.Clear();
                FloorModificationToolComboBox.SelectedItem = ModificationTool.None;
                FloorTrenchNameTextBox.Text = "";
                FloorPictureBox.Image = Resources.ImageNotFoundGraphic;
            }
            else if (FloorListBox.SelectedItem is FloorModel model
                    && null != model)
            {
                FloorIDExample.Text = model.ID.ToString();
                FloorNameTextBox.Text = model.Name;
                FloorDescriptionTextBox.Text = model.Description;
                FloorCommentTextBox.Text = model.Comment;
                FloorEquivalentItemComboBox.SelectedItem = All.Items.GetOrNull(model.ItemID);
                RepopulateListBox(FloorAddsToBiomeListBox, model.AddsToBiome);
                RepopulateListBox(FloorAddsToRoomListBox, model.AddsToRoom);
                FloorModificationToolComboBox.SelectedItem = model.ModTool;
                FloorTrenchNameTextBox.Text = model.TrenchName;
                PictureBoxLoadFromStorage(FloorPictureBox, model.ID);
            }
        }

        /// <summary>
        /// Populates the Furnishings tab when a <see cref="FurnishingModel"/> is selected in the FurnishingListBox.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void FurnishingListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            FurnishingAddsToBiomeListBox.SelectedItem = null;
            FurnishingAddsToRoomListBox.SelectedItem = null;
            if (null == FurnishingListBox.SelectedItem)
            {
                FurnishingIDExample.Text = ModelID.None.ToString();
                FurnishingNameTextBox.Text = "";
                FurnishingDescriptionTextBox.Text = "";
                FurnishingCommentTextBox.Text = "";
                FurnishingEquivalentItemComboBox.SelectedItem = null;
                FurnishingAddsToBiomeListBox.Items.Clear();
                FurnishingAddsToRoomListBox.Items.Clear();
                FurnishingEntryTypeComboBox.SelectedItem = EntryType.None;
                FurnishingIsWalkableCheckBox.Checked = false;
                FurnishingIsEnclosingCheckBox.Checked = false;
                FurnishingIsFlammableCheckBox.Checked = false;
                FurnishingSwapWithFurnishingComboBox.SelectedItem = null;
                FurnishingPictureBox.Image = Resources.ImageNotFoundGraphic;
            }
            else if (FurnishingListBox.SelectedItem is FurnishingModel model
                    && null != model)
            {
                FurnishingIDExample.Text = model.ID.ToString();
                FurnishingNameTextBox.Text = model.Name;
                FurnishingDescriptionTextBox.Text = model.Description;
                FurnishingCommentTextBox.Text = model.Comment;
                FurnishingEquivalentItemComboBox.SelectedItem = All.Items.GetOrNull(model.ItemID);
                RepopulateListBox(FurnishingAddsToBiomeListBox, model.AddsToBiome);
                RepopulateListBox(FurnishingAddsToRoomListBox, model.AddsToRoom);
                FurnishingEntryTypeComboBox.SelectedItem = model.Entry;
                FurnishingIsWalkableCheckBox.Checked = model.IsWalkable;
                FurnishingIsEnclosingCheckBox.Checked = model.IsEnclosing;
                FurnishingIsFlammableCheckBox.Checked = model.IsFlammable;
                FurnishingSwapWithFurnishingComboBox.SelectedItem = All.Furnishings.GetOrNull(model.SwapID);
                PictureBoxLoadFromStorage(FurnishingPictureBox, model.ID);
            }
        }

        /// <summary>
        /// Populates the Collectibles tab when a <see cref="CollectibleModel"/> is selected in the CollectibleListBox.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void CollectibleListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            CollectibleAddsToBiomeListBox.SelectedItem = null;
            CollectibleAddsToRoomListBox.SelectedItem = null;
            if (null == CollectibleListBox.SelectedItem)
            {
                CollectibleIDExample.Text = ModelID.None.ToString();
                CollectibleNameTextBox.Text = "";
                CollectibleDescriptionTextBox.Text = "";
                CollectibleCommentTextBox.Text = "";
                CollectibleEquivalentItemComboBox.SelectedItem = null;
                CollectibleAddsToBiomeListBox.Items.Clear();
                CollectibleAddsToRoomListBox.Items.Clear();
                CollectibleCollectionEffectComboBox.SelectedItem = null;
                CollectibleEffectAmountTextBox.Text = "";
                CollectiblePictureBox.Image = Resources.ImageNotFoundGraphic;
            }
            else if (CollectibleListBox.SelectedItem is CollectibleModel model
                    && null != model)
            {
                CollectibleIDExample.Text = model.ID.ToString();
                CollectibleNameTextBox.Text = model.Name;
                CollectibleDescriptionTextBox.Text = model.Description;
                CollectibleCommentTextBox.Text = model.Comment;
                CollectibleEquivalentItemComboBox.SelectedItem = All.Items.GetOrNull(model.ItemID);
                RepopulateListBox(CollectibleAddsToBiomeListBox, model.AddsToBiome);
                RepopulateListBox(CollectibleAddsToRoomListBox, model.AddsToRoom);
                CollectibleCollectionEffectComboBox.SelectedItem = model.CollectionEffect;
                CollectibleEffectAmountTextBox.Text = model.EffectAmount.ToString();
                PictureBoxLoadFromStorage(CollectiblePictureBox, model.ID);
            }
        }

        /// <summary>
        /// Populates the Characters tab when a <see cref="CharacterModel"/> is selected in the CharacterListBox.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void CharacterListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            CharacterStartingQuestsListBox.SelectedItem = null;
            if (null == CharacterListBox.SelectedItem)
            {
                CharacterIDExample.Text = ModelID.None.ToString();
                CharacterPersonalNameTextBox.Text = "";
                CharacterFamilyNameTextBox.Text = "";
                CharacterDescriptionTextBox.Text = "";
                CharacterCommentTextBox.Text = "";
                CharacterNativeBiomeComboBox.SelectedItem = null;
                CharacterPrimaryBehaviorComboBox.SelectedItem = null;
                CharacterPronounComboBox.SelectedItem = null;
                CharacterStoryIDTextBox.Text = "";
                CharacterStartingQuestsListBox.Items.Clear();
                CharacterStartingDialogueComboBox.SelectedItem = null;
                CharacterStartingInventoryComboBox.SelectedItem = null;
                CharacterPictureBox.Image = Resources.ImageNotFoundGraphic;
            }
            else if (CharacterListBox.SelectedItem is CharacterModel model
                     && null != model)
            {
                CharacterIDExample.Text = model.ID.ToString();
                CharacterPersonalNameTextBox.Text = model.PersonalName;
                CharacterFamilyNameTextBox.Text = model.FamilyName;
                CharacterDescriptionTextBox.Text = model.Description;
                CharacterCommentTextBox.Text = model.Comment;
                CharacterNativeBiomeComboBox.SelectedItem = All.Biomes.GetOrNull(model.NativeBiomeID);
                CharacterPrimaryBehaviorComboBox.SelectedItem = All.Scripts.GetOrNull(model.PrimaryBehaviorID);
                CharacterStoryIDTextBox.Text = string.IsNullOrEmpty(model.StoryCharacterID) && Settings.Default.SuggestStoryIDs
                    ? $"{model.PersonalName.ToUpperInvariant()}_{model.FamilyName.ToUpperInvariant()}"
                    : model.StoryCharacterID;
                RepopulateListBox(CharacterStartingQuestsListBox, model.StartingQuestIDs
                                                                       .Select(id => All.Interactions.Get<InteractionModel>(id)));
                CharacterStartingDialogueComboBox.SelectedItem = model.StartingDialogueID;
                CharacterStartingInventoryComboBox.SelectedItem = model.StartingInventory;
                PictureBoxLoadFromStorage(CharacterPictureBox, model.ID);
            }
        }

        /// <summary>
        /// Populates the Critters tab when a <see cref="CritterModel"/> is selected in the CritterListBox.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void CritterListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (null == CritterListBox.SelectedItem)
            {
                CritterIDExample.Text = ModelID.None.ToString();
                CritterNameTextBox.Text = "";
                CritterDescriptionTextBox.Text = "";
                CritterCommentTextBox.Text = "";
                CritterNativeBiomeComboBox.SelectedItem = null;
                CritterPrimaryBehaviorComboBox.SelectedItem = null;
                CritterPictureBox.Image = Resources.ImageNotFoundGraphic;
            }
            else if (CritterListBox.SelectedItem is CritterModel model
                     && null != model)
            {
                CritterIDExample.Text = model.ID.ToString();
                CritterNameTextBox.Text = model.Name;
                CritterDescriptionTextBox.Text = model.Description;
                CritterCommentTextBox.Text = model.Comment;
                CritterNativeBiomeComboBox.SelectedItem = All.Biomes.GetOrNull(model.NativeBiomeID);
                CritterPrimaryBehaviorComboBox.SelectedItem = All.Scripts.GetOrNull(model.PrimaryBehaviorID);
                PictureBoxLoadFromStorage(CritterPictureBox, model.ID);
            }
        }

        /// <summary>
        /// Populates the Items tab when a <see cref="ItemModel"/> is selected in the ItemListBox.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void ItemListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            ItemTagListBox.SelectedItem = null;
            if (null == ItemListBox.SelectedItem)
            {
                ItemIDExample.Text = ModelID.None.ToString();
                ItemNameTextBox.Text = "";
                ItemDescriptionTextBox.Text = "";
                ItemCommentTextBox.Text = "";
                ItemSubtypeComboBox.SelectedItem = ItemType.Other;
                ItemPriceTextBox.Text = "";
                ItemRarityTextBox.Text = "";
                ItemStackMaxTextBox.Text = "";
                ItemEffectWhileHeldComboBox.SelectedItem = null;
                ItemEffectWhenUsedComboBox.SelectedItem = null;
                ItemEquivalentParquetComboBox.SelectedItem = null;
                ItemTagListBox.Items.Clear();
                ItemPictureBox.Image = Resources.ImageNotFoundGraphic;
            }
            else if (ItemListBox.SelectedItem is ItemModel model
                    && null != model)
            {
                ItemIDExample.Text = model.ID.ToString();
                ItemNameTextBox.Text = model.Name;
                ItemDescriptionTextBox.Text = model.Description;
                ItemCommentTextBox.Text = model.Comment;
                ItemSubtypeComboBox.SelectedItem = model.Subtype;
                ItemPriceTextBox.Text = model.Price.ToString();
                ItemRarityTextBox.Text = model.Rarity.ToString();
                ItemStackMaxTextBox.Text = model.StackMax.ToString();
                ItemEffectWhileHeldComboBox.SelectedItem = All.Scripts.GetOrNull(model.EffectWhileHeldID);
                ItemEffectWhenUsedComboBox.SelectedItem = All.Scripts.GetOrNull(model.EffectWhenUsedID);
                ItemEquivalentParquetComboBox.SelectedItem = All.Parquets.GetOrNull(model.ParquetID);
                RepopulateListBox(ItemTagListBox, model.ItemTags);
                PictureBoxLoadFromStorage(ItemPictureBox, model.ID);
            }
        }

        /// <summary>
        /// Populates the Biome Recipes tab when a <see cref="BiomeRecipe"/> is selected in the BiomeListBox.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void BiomeListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            BiomeParquetCriteriaListBox.SelectedItem = null;
            BiomeEntryRequirementsListBox.SelectedItem = null;
            if (null == BiomeListBox.SelectedItem)
            {
                BiomeIDExample.Text = ModelID.None.ToString();
                BiomeNameTextBox.Text = "";
                BiomeDescriptionTextBox.Text = "";
                BiomeCommentTextBox.Text = "";
                BiomeTierTextBox.Text = "";
                BiomeIsRoomBasedCheckBox.Checked = false;
                BiomeIsLiquidBasedCheckBox.Checked = false;
                BiomeParquetCriteriaListBox.Items.Clear();
                BiomeEntryRequirementsListBox.Items.Clear();
                BiomePictureBox.Image = Resources.ImageNotFoundGraphic;
            }
            else if (BiomeListBox.SelectedItem is BiomeRecipe recipe
                    && null != recipe)
            {
                BiomeIDExample.Text = recipe.ID.ToString();
                BiomeNameTextBox.Text = recipe.Name;
                BiomeDescriptionTextBox.Text = recipe.Description;
                BiomeCommentTextBox.Text = recipe.Comment;
                BiomeTierTextBox.Text = recipe.Tier.ToString();
                BiomeIsRoomBasedCheckBox.Checked = recipe.IsRoomBased;
                BiomeIsLiquidBasedCheckBox.Checked = recipe.IsLiquidBased;
                RepopulateListBox(BiomeParquetCriteriaListBox, recipe.ParquetCriteria);
                RepopulateListBox(BiomeEntryRequirementsListBox, recipe.EntryRequirements);
                PictureBoxLoadFromStorage(BiomePictureBox, recipe.ID);
            }
        }

        /// <summary>
        /// Populates the Crafting Recipes tab when a <see cref="CraftingRecipe"/> is selected in the CraftingListBox.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void CraftingListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            CraftingProductsListBox.SelectedItem = null;
            CraftingIngredientsListBox.SelectedItem = null;
            if (null == CraftingListBox.SelectedItem)
            {
                CraftingIDExample.Text = ModelID.None.ToString();
                CraftingNameTextBox.Text = "";
                CraftingDescriptionTextBox.Text = "";
                CraftingCommentTextBox.Text = "";
                CraftingProductsListBox.Items.Clear();
                CraftingIngredientsListBox.Items.Clear();
                CraftingPictureBox.Image = Resources.ImageNotFoundGraphic;
            }
            else if (CraftingListBox.SelectedItem is CraftingRecipe recipe
                    && null != recipe)
            {
                CraftingIDExample.Text = recipe.ID.ToString();
                CraftingNameTextBox.Text = recipe.Name;
                CraftingDescriptionTextBox.Text = recipe.Description;
                CraftingCommentTextBox.Text = recipe.Comment;
                RepopulateListBox(CraftingProductsListBox, recipe.Products);
                RepopulateListBox(CraftingIngredientsListBox, recipe.Ingredients);
                PictureBoxLoadFromStorage(CraftingPictureBox, recipe.ID);
            }
        }

        /// <summary>
        /// Populates the Room Recipes tab when a <see cref="RoomRecipe"/> is selected in the RoomListBox.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void RoomListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            RoomRequiredFurnishingsListBox.SelectedItem = null;
            RoomRequiredFloorsListBox.SelectedItem = null;
            RoomRequiredBlocksListBox.SelectedItem = null;
            if (null == RoomListBox.SelectedItem)
            {
                RoomIDExample.Text = ModelID.None.ToString();
                RoomNameTextBox.Text = "";
                RoomDescriptionTextBox.Text = "";
                RoomCommentTextBox.Text = "";
                RoomMinimumWalkableSpacesTextBox.Text = "";
                RoomRequiredFurnishingsListBox.Items.Clear();
                RoomRequiredFloorsListBox.Items.Clear();
                RoomRequiredBlocksListBox.Items.Clear();
                RoomPictureBox.Image = Resources.ImageNotFoundGraphic;
            }
            else if (RoomListBox.SelectedItem is RoomRecipe recipe
                    && null != recipe)
            {
                RoomIDExample.Text = recipe.ID.ToString();
                RoomNameTextBox.Text = recipe.Name;
                RoomDescriptionTextBox.Text = recipe.Description;
                RoomCommentTextBox.Text = recipe.Comment;
                RoomMinimumWalkableSpacesTextBox.Text = recipe.MinimumWalkableSpaces.ToString();
                RepopulateListBox(RoomRequiredFurnishingsListBox, recipe.OptionallyRequiredFurnishings);
                RepopulateListBox(RoomRequiredFloorsListBox, recipe.OptionallyRequiredWalkableFloors);
                RepopulateListBox(RoomRequiredBlocksListBox, recipe.OptionallyRequiredPerimeterBlocks);
                PictureBoxLoadFromStorage(RoomPictureBox, recipe.ID);
            }
        }

        // TODO Maps
        // TODO Scripts
        #endregion

        #region Handle Changes to Data
        /// <summary>
        /// Autosaves and/or marks the form dirty after an update.
        /// </summary>
        /// <param name="sender">The control whose content was changed.</param>
        /// <param name="e">Ignored.</param>
        private void ContentAlteredEventHandler(object sender, EventArgs e)
        {
            var alteredControl = sender as Control;
            var PropertyAccessor = GetPropertyAccessorForTabAndControl(EditorTabs.SelectedIndex, alteredControl);
            if (null == PropertyAccessor)
            {
                // Silently return if no model is selected or if a control is unsupported.
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
                     && checkbox.Checked != (EditableControls[typeof(CheckBox)][checkbox] as bool?))
            {
                var oldValue = (bool?)EditableControls[typeof(CheckBox)][checkbox];
                ChangeManager.AddAndExecute(new ChangeValue(oldValue, (bool?)checkbox.Checked, checkbox.Name,
                                            (object databaseValue) => { PropertyAccessor(databaseValue); HasUnsavedChanges = true; },
                                            (object displayValue) => checkbox.Checked = (bool)displayValue,
                                            (object oldValue) => EditableControls[typeof(CheckBox)][checkbox] = oldValue));
            }
            else if (alteredControl is ComboBox combobox
                     && combobox.SelectedItem != EditableControls[typeof(ComboBox)][combobox])
            {
                var oldValue = EditableControls[typeof(ComboBox)][combobox];
                ChangeManager.AddAndExecute(new ChangeValue(oldValue, combobox.SelectedItem, combobox.Name,
                                            (object databaseValue) => { PropertyAccessor(databaseValue); HasUnsavedChanges = true; },
                                            (object displayValue) => combobox.SelectedItem = displayValue,
                                            (object oldValue) => EditableControls[typeof(ComboBox)][combobox] = oldValue));
            }
            else if (alteredControl is ListBox listbox
                     && listbox.SelectedItem != EditableControls[typeof(ListBox)][listbox])
            {
                var oldValue = EditableControls[typeof(ListBox)][listbox];
                ChangeManager.AddAndExecute(new ChangeValue(oldValue, listbox.SelectedItem, listbox.Name,
                                            (object databaseValue) => { PropertyAccessor(databaseValue); HasUnsavedChanges = true; },
                                            (object displayValue) => listbox.SelectedItem = displayValue,
                                            (object oldValue) => EditableControls[typeof(ListBox)][listbox] = oldValue));
            }
        }

        #region Add/Remove Models
        /// <summary>
        /// Adds a new <see cref="Model"/> of the appropriate subtype to the given <see cref="ModelCollection"/> and <see cref="ListBox"/>.
        /// </summary>
        /// <typeparam name="TModel">The type of <see cref="Model"/> being added.</typeparam>
        /// <typeparam name="TCollected">The type of <see cref="Model"/> being collected.</typeparam>
        /// <param name="inDatabaseCollection">The backing collection.</param>
        /// <param name="inAllocateNewInstance">The means to produce a new <paramref="TModel"/>.</param>
        /// <param name="inIDRange">The range over which the <see cref="ModelID"/> is defined.</param>
        /// <param name="inListBox">The UI element representing the <see cref="ModelCollection{TCollected}"/>.</param>
        /// <param name="inModelTypeName">User-facing description of the type being added.</param>
        private void AddNewModel<TModel>(IEnumerable<TModel> inDatabaseCollection,
                                         Func<ModelID, TModel> inAllocateNewInstance,
                                         Range<ModelID> inIDRange, ListBox inListBox, string inModelTypeName)
            where TModel : Model
        {
            if (!All.CollectionsHaveBeenInitialized)
            {
                SystemSounds.Beep.Play();
                return;
            }

            var nextID = inDatabaseCollection.Count() > 0
                ? (ModelID)(inDatabaseCollection.Max(model => model?.ID ?? inIDRange.Minimum) + 1)
                : inIDRange.Minimum;
            if (nextID > inIDRange.Maximum)
            {
                SystemSounds.Beep.Play();
                _ = MessageBox.Show(Resources.ErrorMaximumIDReached, Resources.CaptionError,
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var modelToAdd = inAllocateNewInstance(nextID);
            ChangeManager.AddAndExecute(new ChangeList(modelToAdd, $"add new {inModelTypeName} definition",
                                        (object databaseValue) =>
                                        {
                                            ((IModelCollectionEdit<TModel>)inDatabaseCollection).Add((TModel)databaseValue);
                                            _ = inListBox.Items.Add(databaseValue);
                                            inListBox.SelectedItem = databaseValue;
                                            HasUnsavedChanges = true;
                                        },
                                        (object databaseValue) =>
                                        {
                                            ((IModelCollectionEdit<TModel>)inDatabaseCollection).Remove((TModel)databaseValue);
                                            inListBox.Items.Remove(databaseValue);
                                            inListBox.SelectedItem = null;
                                            HasUnsavedChanges = true;
                                        }));
        }

        /// <summary>
        /// Removes a <see cref="Model"/> of the appropriate subtype from the given <see cref="ModelCollection"/> and <see cref="ListBox"/>.
        /// </summary>
        /// <typeparam name="TModel">The type of <see cref="Model"/> being removed.</typeparam>
        /// <param name="inDatabaseCollection">The backing collection.</param>
        /// <param name="inListBox">The UI element representing the <see cref="ModelCollection{TCollected}"/>.</param>
        /// <param name="inModelTypeName">User-facing description of the type being removed.</param>
        private void RemoveModel<TModel>(IEnumerable<TModel> inDatabaseCollection, ListBox inListBox, string inModelTypeName)
            where TModel : Model
        {
            if (!All.CollectionsHaveBeenInitialized || inListBox.SelectedIndex == -1)
            {
                SystemSounds.Beep.Play();
                return;
            }

            var modelToRemove = (TModel)GetSelectedModelForTab(EditorTabs.SelectedIndex);
            if (null == modelToRemove)
            {
                SystemSounds.Beep.Play();
                return;
            }

            ChangeManager.AddAndExecute(new ChangeList(modelToRemove, $"remove {inModelTypeName} {modelToRemove.Name}",
                                        (object databaseValue) =>
                                        {
                                            ((IModelCollectionEdit<TModel>)inDatabaseCollection).Remove((TModel)databaseValue);
                                            inListBox.Items.Remove(databaseValue);
                                            inListBox.SelectedItem = null;
                                            HasUnsavedChanges = true;
                                        },
                                        (object databaseValue) =>
                                        {
                                            ((IModelCollectionEdit<TModel>)inDatabaseCollection).Add((TModel)databaseValue);
                                            _ = inListBox.Items.Add(databaseValue);
                                            inListBox.SelectedItem = databaseValue;
                                            HasUnsavedChanges = true;
                                        }));
        }
        #endregion

        #region Tag Adjustments
        /// <summary>
        /// Adds a new <see cref="ModelTag"/> to the selected <see cref="Model"/>, updating the given <see cref="ListBox"/>.
        /// </summary>
        /// <param name="inAddsToListBox">The UI element reflectling the collection being changed.</param>
        /// <param name="inGetTagListFromModel">The means, given a model, to find the correct tag collection.</param>
        private void AddTag<TInterface>(ListBox inAddsToListBox, Func<TInterface, IList<ModelTag>> inGetTagListFromModel)
            where TInterface : IModelEdit
        {
            if (!All.CollectionsHaveBeenInitialized)
            {
                SystemSounds.Beep.Play();
                return;
            }

            if (GetSelectedModelForTab(EditorTabs.SelectedIndex) is TInterface model
                && AddTagDialogue.ShowDialog() == DialogResult.OK)
            {
                if (inGetTagListFromModel(model).Any(tag => ((string)AddTagDialogue.ReturnNewTag).Equals(tag)))
                {
                    // Do not add duplicate tags.
                    // TODO Report this error in the status bar or something.
                    MessageBox.Show("Not adding duplicate tag.");
                    SystemSounds.Beep.Play();
                    return;
                }

                ChangeManager.AddAndExecute(new ChangeList(AddTagDialogue.ReturnNewTag,
                                            $"add tag {AddTagDialogue.ReturnNewTag} to {model.Name}",
                                            (object databaseValue) =>
                                            {
                                                inGetTagListFromModel(model).Add((ModelTag)databaseValue);
                                                _ = inAddsToListBox.Items.Add(databaseValue);
                                                inAddsToListBox.SelectedItem = databaseValue;
                                                HasUnsavedChanges = true;
                                            },
                                            (object databaseValue) =>
                                            {
                                                inGetTagListFromModel(model).Remove((ModelTag)databaseValue);
                                                inAddsToListBox.Items.Remove(databaseValue);
                                                inAddsToListBox.SelectedItem = null;
                                                HasUnsavedChanges = true;
                                            }));
            }
        }

        /// <summary>
        /// Removes the selected <see cref="ModelTag"/> from the selected <see cref="Model"/>, updating the given <see cref="ListBox"/>.
        /// </summary>
        /// <param name="inAddsToListBox">The UI element reflectling the collection being changed.</param>
        /// <param name="inGetTagListFromModel">The means, given a Model, to find the correct tag collection.</param>
        private void RemoveTag<TInterface>(ListBox inAddsToListBox, Func<TInterface, IList<ModelTag>> inGetTagListFromModel)
            where TInterface : IModelEdit
        {
            if (!All.CollectionsHaveBeenInitialized || null == inAddsToListBox.SelectedItem)
            {
                SystemSounds.Beep.Play();
                return;
            }

            if (GetSelectedModelForTab(EditorTabs.SelectedIndex) is TInterface model)
            {
                ChangeManager.AddAndExecute(new ChangeList((ModelTag)inAddsToListBox.SelectedItem,
                                            $"remove tag {inAddsToListBox.SelectedItem} from {model.Name}",
                                            (object databaseValue) =>
                                            {
                                                inGetTagListFromModel(model).Remove((ModelTag)databaseValue);
                                                inAddsToListBox.Items.Remove(databaseValue);
                                                inAddsToListBox.SelectedItem = null;
                                                HasUnsavedChanges = true;
                                            },
                                            (object databaseValue) =>
                                            {
                                                inGetTagListFromModel(model).Add((ModelTag)databaseValue);
                                                _ = inAddsToListBox.Items.Add(databaseValue);
                                                inAddsToListBox.SelectedItem = databaseValue;
                                                HasUnsavedChanges = true;
                                            }));
            }
        }
        #endregion

        #region Recipe Element Adjustments
        /// <summary>
        /// Adds a new <see cref="RecipeElement"/> to the selected <see cref="Model"/>, updating the given <see cref="ListBox"/>.
        /// </summary>
        /// <param name="inAddsToListBox">The UI element reflectling the collection being changed.</param>
        /// <param name="inGetElementListFromRecipe">The means, given a model, to find the correct Recipe Element collection.</param>
        private void AddRecipeElement<TInterface>(ListBox inAddsToListBox,
                                                  Func<TInterface, IList<RecipeElement>> inGetElementListFromRecipe)
            where TInterface : IModelEdit
        {
            if (!All.CollectionsHaveBeenInitialized)
            {
                SystemSounds.Beep.Play();
                return;
            }

            if (GetSelectedModelForTab(EditorTabs.SelectedIndex) is TInterface recipe
                && AddRecipeElementDialogue.ShowDialog() == DialogResult.OK)
            {
                if (inGetElementListFromRecipe(recipe).Any(element => AddRecipeElementDialogue.ReturnNewRecipeElement == element))
                {
                    // Do not add duplicate elements.
                    // TODO Report this error in the status bar or something.
                    MessageBox.Show("Not adding duplicate recipe element.");
                    SystemSounds.Beep.Play();
                    return;
                }

                ChangeManager.AddAndExecute(new ChangeList(AddRecipeElementDialogue.ReturnNewRecipeElement,
                                            $"add recipe element {AddRecipeElementDialogue.ReturnNewRecipeElement} to {recipe.Name}",
                                            (object databaseValue) =>
                                            {
                                                inGetElementListFromRecipe(recipe).Add((RecipeElement)databaseValue);
                                                _ = inAddsToListBox.Items.Add(databaseValue);
                                                inAddsToListBox.SelectedItem = databaseValue;
                                                HasUnsavedChanges = true;
                                            },
                                            (object databaseValue) =>
                                            {
                                                inGetElementListFromRecipe(recipe).Remove((RecipeElement)databaseValue);
                                                inAddsToListBox.Items.Remove(databaseValue);
                                                inAddsToListBox.SelectedItem = null;
                                                HasUnsavedChanges = true;
                                            }));
            }
        }

        /// <summary>
        /// Removes the selected <see cref="RecipeElement"/> from the selected <see cref="Model"/>,
        /// updating the given <see cref="ListBox"/>.
        /// </summary>
        /// <param name="inAddsToListBox">The UI element reflectling the collection being changed.</param>
        /// <param name="inGetElementListFromRecipe">The means, given a Model, to find the correct Recipe Element collection.</param>
        private void RemoveRecipeElement<TInterface>(ListBox inAddsToListBox,
                                                     Func<TInterface, IList<RecipeElement>> inGetElementListFromRecipe)
            where TInterface : IModelEdit
        {
            if (!All.CollectionsHaveBeenInitialized || null == inAddsToListBox.SelectedItem)
            {
                SystemSounds.Beep.Play();
                return;
            }

            if (GetSelectedModelForTab(EditorTabs.SelectedIndex) is TInterface recipe)
            {
                ChangeManager.AddAndExecute(new ChangeList((RecipeElement)inAddsToListBox.SelectedItem,
                                            $"remove recipe element {inAddsToListBox.SelectedItem} from {recipe.Name}",
                                            (object databaseValue) =>
                                            {
                                                inGetElementListFromRecipe(recipe).Remove((RecipeElement)databaseValue);
                                                inAddsToListBox.Items.Remove(databaseValue);
                                                inAddsToListBox.SelectedItem = null;
                                                HasUnsavedChanges = true;
                                            },
                                            (object databaseValue) =>
                                            {
                                                inGetElementListFromRecipe(recipe).Add((RecipeElement)databaseValue);
                                                _ = inAddsToListBox.Items.Add(databaseValue);
                                                inAddsToListBox.SelectedItem = databaseValue;
                                                HasUnsavedChanges = true;
                                            }));
            }
        }
        #endregion

        #region Games Tab
        /// <summary>
        /// Responds to the user clicking "Add New Game" on the Games tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void GameAddNewGameButton_Click(object sender, EventArgs e)
            => AddNewModel(All.Games, (ModelID id) => new GameModel(id, "New Game", "", ""), All.GameIDs, GameListBox, "Game");

        /// <summary>
        /// Responds to the user clicking "Remove Game" on the Games tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void GameRemoveGameButton_Click(object sender, EventArgs e)
            => RemoveModel(All.Games, GameListBox, "Game");
        #endregion

        #region Blocks Tab
        /// <summary>
        /// Responds to the user clicking "Add New Block" on the Blocks tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void BlockAddNewBlockButton_Click(object sender, EventArgs e)
            => AddNewModel(All.Blocks, (ModelID id) => new BlockModel(id, "New Block", "", ""), All.BlockIDs, BlockListBox, "Block");

        /// <summary>
        /// Responds to the user clicking "Remove Block" on the Blocks tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void BlockRemoveBlockButton_Click(object sender, EventArgs e)
            => RemoveModel(All.Blocks, BlockListBox, "Block");

        /// <summary>
        /// Registeres the user command to add a new biome tag to the current block.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void BlockAddBiomeTagButton_Click(object sender, EventArgs e)
            => AddTag(BlockAddsToBiomeListBox, (IParquetModelEdit model) => model.AddsToBiome);

        /// <summary>
        /// Registeres the user command to remove the selected biome tag from the current block.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void BlockRemoveBiomeTagButton_Click(object sender, EventArgs e)
            => RemoveTag(BlockAddsToBiomeListBox, (IParquetModelEdit model) => model.AddsToBiome);

        /// <summary>
        /// Registeres the user command to add a new room tag to the current block.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void BlockAddRoomTagButton_Click(object sender, EventArgs e)
            => AddTag(BlockAddsToRoomListBox, (IParquetModelEdit model) => model.AddsToRoom);

        /// <summary>
        /// Registeres the user command to remove the selected room tag from the current block.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void BlockRemoveRoomTagButton_Click(object sender, EventArgs e)
            => RemoveTag(BlockAddsToRoomListBox, (IParquetModelEdit model) => model.AddsToRoom);
        #endregion

        #region Floors Tab
        /// <summary>
        /// Responds to the user clicking "Add New Floor" on the Floors tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void FloorAddNewFloorButton_Click(object sender, EventArgs e)
            => AddNewModel(All.Floors, (ModelID id) => new FloorModel(id, "New Floor", "", ""), All.FloorIDs, FloorListBox, "Floor");

        /// <summary>
        /// Responds to the user clicking "Remove Floor" on the Floors tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void FloorRemoveFloorButton_Click(object sender, EventArgs e)
            => RemoveModel(All.Floors, FloorListBox, "Floor");

        /// <summary>
        /// Registeres the user command to add a new biome tag to the current floor.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void FloorAddBiomeTagButton_Click(object sender, EventArgs e)
            => AddTag(FloorAddsToBiomeListBox, (IParquetModelEdit model) => model.AddsToBiome);

        /// <summary>
        /// Registeres the user command to remove the selected biome tag from the current floor.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void FloorRemoveBiomeTagButton_Click(object sender, EventArgs e)
            => RemoveTag(FloorAddsToBiomeListBox, (IParquetModelEdit model) => model.AddsToBiome);

        /// <summary>
        /// Registeres the user command to add a new room tag to the current floor.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void FloorAddRoomTagButton_Click(object sender, EventArgs e)
            => AddTag(FloorAddsToRoomListBox, (IParquetModelEdit model) => model.AddsToRoom);

        /// <summary>
        /// Registeres the user command to remove the selected room tag from the current floor.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void FloorRemoveRoomTagButton_Click(object sender, EventArgs e)
            => RemoveTag(FloorAddsToRoomListBox, (IParquetModelEdit model) => model.AddsToRoom);
        #endregion

        #region Furnishings Tab
        /// <summary>
        /// Responds to the user clicking "Add New Furnishing" on the Furnishings tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void FurnishingAddNewFurnishingButton_Click(object sender, EventArgs e)
            => AddNewModel(All.Furnishings, (ModelID id) => new FurnishingModel(id, "New Furnishing", "", ""),
                           All.FurnishingIDs, FurnishingListBox, "Furnishing");

        /// <summary>
        /// Responds to the user clicking "Remove Furnishing" on the Furnishings tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void FurnishingRemoveFurnishingButton_Click(object sender, EventArgs e)
            => RemoveModel(All.Furnishings, FurnishingListBox, "Furnishing");

        /// <summary>
        /// Registeres the user command to add a new biome tag to the current furnishing.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void FurnishingAddBiomeTagButton_Click(object sender, EventArgs e)
            => AddTag(FurnishingAddsToBiomeListBox, (IParquetModelEdit model) => model.AddsToBiome);

        /// <summary>
        /// Registeres the user command to remove the selected biome tag from the current furnishing.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void FurnishingRemoveBiomeTagButton_Click(object sender, EventArgs e)
            => RemoveTag(FurnishingAddsToBiomeListBox, (IParquetModelEdit model) => model.AddsToBiome);

        /// <summary>
        /// Registeres the user command to add a new room tag to the current furnishing.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void FurnishingAddRoomTagButton_Click(object sender, EventArgs e)
            => AddTag(FurnishingAddsToRoomListBox, (IParquetModelEdit model) => model.AddsToRoom);

        /// <summary>
        /// Registeres the user command to remove the selected room tag from the current furnishing.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void FurnishingRemoveRoomTagButton_Click(object sender, EventArgs e)
            => RemoveTag(FurnishingAddsToRoomListBox, (IParquetModelEdit model) => model.AddsToRoom);
        #endregion

        #region Collectibles Tab
        /// <summary>
        /// Responds to the user clicking "Add New Collectible" on the Collectibles tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void CollectibleAddNewCollectibleButton_Click(object sender, EventArgs e)
            => AddNewModel(All.Collectibles, (ModelID id) => new CollectibleModel(id, "New Collectible", "", ""),
                           All.CollectibleIDs, CollectibleListBox, "Collectible");

        /// <summary>
        /// Responds to the user clicking "Remove Collectible" on the Collectibles tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void CollectibleRemoveCollectibleButton_Click(object sender, EventArgs e)
            => RemoveModel(All.Collectibles, CollectibleListBox, "Collectible");

        /// <summary>
        /// Registeres the user command to add a new biome tag to the current collectible.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void CollectibleAddBiomeTagButton_Click(object sender, EventArgs e)
            => AddTag(CollectibleAddsToBiomeListBox, (IParquetModelEdit model) => model.AddsToBiome);

        /// <summary>
        /// Registeres the user command to remove the selected biome tag from the current collectible.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void CollectibleRemoveBiomeTagButton_Click(object sender, EventArgs e)
            => RemoveTag(CollectibleAddsToBiomeListBox, (IParquetModelEdit model) => model.AddsToBiome);

        /// <summary>
        /// Registeres the user command to add a new room tag to the current collectible.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void CollectibleAddRoomTagButton_Click(object sender, EventArgs e)
            => AddTag(CollectibleAddsToRoomListBox, (IParquetModelEdit model) => model.AddsToRoom);

        /// <summary>
        /// Registeres the user command to remove the selected room tag from the current collectible.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void CollectibleRemoveRoomTagButton_Click(object sender, EventArgs e)
            => RemoveTag(CollectibleAddsToRoomListBox, (IParquetModelEdit model) => model.AddsToRoom);
        #endregion

        #region Characters Tab
        // TODO Characters
        #endregion

        #region Critters Tab
        /// <summary>
        /// Responds to the user clicking "Add New Critter" on the Critters tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void CritterAddNewCritterButton_Click(object sender, EventArgs e)
            => AddNewModel(All.Critters, (ModelID id) => new CritterModel(id, "New Critter", "", ""), All.CritterIDs, CritterListBox, "Critter");

        /// <summary>
        /// Responds to the user clicking "Remove Critter" on the Critters tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void CritterRemoveCritterButton_Click(object sender, EventArgs e)
            => RemoveModel(All.Critters, CritterListBox, "Critter");
        #endregion

        #region Items Tab
        /// <summary>
        /// Responds to the user clicking "Add New Item" on the Items tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void ItemAddNewItemButton_Click(object sender, EventArgs e)
            => AddNewModel(All.Items, (ModelID id) => new ItemModel(id, "New Item", "", ""), All.ItemIDs, ItemListBox, "Item");

        /// <summary>
        /// Responds to the user clicking "Remove Item" on the Items tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void ItemRemoveItemButton_Click(object sender, EventArgs e)
            => RemoveModel(All.Items, ItemListBox, "Item");

        /// <summary>
        /// Registeres the user command to add a new tag to the current item.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void ItemAddTagButton_Click(object sender, EventArgs e)
            => AddTag(ItemTagListBox, (IItemModelEdit model) => model.ItemTags);

        /// <summary>
        /// Registeres the user command to remove the selected tag from the current item.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void ItemRemoveTagButton_Click(object sender, EventArgs e)
            => RemoveTag(ItemTagListBox, (IItemModelEdit model) => model.ItemTags);
        #endregion

        #region Biomes Tab
        /// <summary>
        /// Responds to the user clicking "Add New Biome" on the Biomes tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void BiomeAddNewBiomeButton_Click(object sender, EventArgs e)
            => AddNewModel(All.Biomes, (ModelID id) => new BiomeRecipe(id, "New Biome Recipe", "", ""), All.BiomeIDs, BiomeListBox, "Biome Recipe");

        /// <summary>
        /// Responds to the user clicking "Remove Biome" on the Biomes tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void BiomeRemoveBiomeButton_Click(object sender, EventArgs e)
            => RemoveModel(All.Biomes, BiomeListBox, "Room Recipe");

        /// <summary>
        /// Registeres the user command to add a new parquet criterion tag to the current biome.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void BiomeAddParquetCriterionButton_Click(object sender, EventArgs e)
            => AddTag(BiomeParquetCriteriaListBox, (IBiomeRecipeEdit recipe) => recipe.ParquetCriteria);

        /// <summary>
        /// Registeres the user command to remove the selected parquet criterion tag from the current biome.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void BiomeRemoveParquetCriterionButton_Click(object sender, EventArgs e)
            => RemoveTag(BiomeParquetCriteriaListBox, (IBiomeRecipeEdit recipe) => recipe.ParquetCriteria);

        /// <summary>
        /// Registeres the user command to add a new entry requirement tag to the current biome.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void BiomeAddEntryRequirementButton_Click(object sender, EventArgs e)
            => AddTag(BiomeEntryRequirementsListBox, (IBiomeRecipeEdit recipe) => recipe.EntryRequirements);

        /// <summary>
        /// Registeres the user command to remove the selected entry requirement tag from the current biome.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void BiomeRemoveEntryRequirementButton_Click(object sender, EventArgs e)
            => RemoveTag(BiomeEntryRequirementsListBox, (IBiomeRecipeEdit recipe) => recipe.EntryRequirements);
        #endregion

        #region Crafting Tab
        /// <summary>
        /// Responds to the user clicking "Add New Crafting Recipe" on the Crafts tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void CraftingAddNewCraftingButton_Click(object sender, EventArgs e)
            => AddNewModel(All.CraftingRecipes, (ModelID id) => new CraftingRecipe(id, "New Crafting Recipe", "", ""), All.CraftingRecipeIDs, CraftingListBox, "Crafting Recipe");

        /// <summary>
        /// Responds to the user clicking "Remove Crafting Recipe" on the Rooms tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void CraftingRemoveCraftingButton_Click(object sender, EventArgs e)
            => RemoveModel(All.CraftingRecipes, CraftingListBox, "Crafting Recipe");

        /// <summary>
        /// Registeres the user command to add a new product to the current Crafting Recipe.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void CraftingAddProductButton_Click(object sender, EventArgs e)
            => AddRecipeElement(CraftingProductsListBox, (ICraftingRecipeEdit recipe) => recipe.Products);

        /// <summary>
        /// Registeres the user command to remove the selected product from the current Crafting Recipe.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void CraftingRemoveProductButton_Click(object sender, EventArgs e)
            => RemoveRecipeElement(CraftingProductsListBox, (ICraftingRecipeEdit recipe) => recipe.Products);

        /// <summary>
        /// Registeres the user command to add a new ingredient to the current Crafting Recipe.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void CraftingAddIngredientButton_Click(object sender, EventArgs e)
            => AddRecipeElement(CraftingIngredientsListBox, (ICraftingRecipeEdit recipe) => recipe.Ingredients);

        /// <summary>
        /// Registeres the user command to remove the selected ingredient from the current Crafting Recipe.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void CraftingRemoveIngredientButton_Click(object sender, EventArgs e)
            => RemoveRecipeElement(CraftingIngredientsListBox, (ICraftingRecipeEdit recipe) => recipe.Ingredients);
        #endregion

        #region Rooms Tab
        /// <summary>
        /// Responds to the user clicking "Add New Room" on the Rooms tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void RoomAddNewRoomButton_Click(object sender, EventArgs e)
            => AddNewModel(All.RoomRecipes, (ModelID id) => new RoomRecipe(id, "New Room Recipe", "", ""), All.RoomRecipeIDs, RoomListBox, "Room Recipe");

        /// <summary>
        /// Responds to the user clicking "Remove Room" on the Rooms tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void RoomRemoveRoomButton_Click(object sender, EventArgs e)
            => RemoveModel(All.RoomRecipes, RoomListBox, "Room Recipe");

        /// <summary>
        /// Registeres the user command to add a new Furnishing requirement to the current Room Recipe.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void RoomAddFurnishingButton_Click(object sender, EventArgs e)
            => AddRecipeElement(RoomRequiredFurnishingsListBox, (IRoomRecipeEdit recipe) => recipe.OptionallyRequiredFurnishings);

        /// <summary>
        /// Registeres the user command to remove the selected Furnishing requirement from the current Room Recipe.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void RoomRemoveFurnishingButton_Click(object sender, EventArgs e)
            => RemoveRecipeElement(BiomeParquetCriteriaListBox, (IRoomRecipeEdit recipe) => recipe.OptionallyRequiredFurnishings);

        /// <summary>
        /// Registeres the user command to add a new Floor requirement to the current Room Recipe.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void RoomAddFloorButton_Click(object sender, EventArgs e)
            => AddRecipeElement(RoomRequiredFurnishingsListBox, (IRoomRecipeEdit recipe) => recipe.OptionallyRequiredWalkableFloors);

        /// <summary>
        /// Registeres the user command to remove the selected Floor requirement from the current Room Recipe.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void RoomRemoveFloorButton_Click(object sender, EventArgs e)
            => RemoveRecipeElement(BiomeParquetCriteriaListBox, (IRoomRecipeEdit recipe) => recipe.OptionallyRequiredWalkableFloors);

        /// <summary>
        /// Registeres the user command to add a new Block requirement to the current Room Recipe.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void RoomAddBlockButton_Click(object sender, EventArgs e)
            => AddRecipeElement(RoomRequiredFurnishingsListBox, (IRoomRecipeEdit recipe) => recipe.OptionallyRequiredPerimeterBlocks);

        /// <summary>
        /// Registeres the user command to remove the selected Block requirement from the current Room Recipe.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="e">Ignored</param>
        private void RoomRemoveBlockButton_Click(object sender, EventArgs e)
            => RemoveRecipeElement(BiomeParquetCriteriaListBox, (IRoomRecipeEdit recipe) => recipe.OptionallyRequiredPerimeterBlocks);
        #endregion

        #region Maps Tab
        // TODO Maps
        #endregion

        #region Scripting Tab
        // TODO Scripts
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
            if (!EditorCommands.SelectProjectFolder(Resources.InfoMessageNew))
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
            if (!EditorCommands.SelectProjectFolder(Resources.InfoMessageLoad))
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
            Validate();
            if (EditorCommands.SaveDataFiles())
            {
                HasUnsavedChanges = false;
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
            oldTheme = Settings.Default.CurrentEditorTheme;
            OptionsDialogue.ShowDialog();
        }

        /// <summary>
        /// Responds to a user selecting the "Refresh Display" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="e">Addional event data.</param>
        private void RefreshStripMenuItem_Click(object sender, EventArgs e)
            => UpdateDisplay();

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
        /// Responds to a user selecting "Copy ID" context menu item from am ID example label.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="e">Addional event data.</param>
        private void CopyID_Click(object sender, EventArgs e)
        {
            var id = GetSelectedModelIDForTab(EditorTabs.SelectedIndex).ToString();
            if (!string.IsNullOrEmpty(id))
            {
                Clipboard.SetText(id);
            }
            else
            {
                SystemSounds.Beep.Play();
            }
        }
        #endregion

        #region Hybrid Events
        /// <summary>
        /// Spawns an external image editor with the image of the currently selected model.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="e">Addional event data.</param>
        private void EditImageExternally(object sender, EventArgs e)
        {
            var id = GetSelectedModelIDForTab(EditorTabs.SelectedIndex);
            if (id != ModelID.None)
            {
                var imagePathAndFilename = Path.Combine(EditorCommands.GetGraphicsPathForModelID(id), $"{id}.png");
                if (!File.Exists(imagePathAndFilename))
                {
                    Resources.ImageNotFoundGraphic.Save(imagePathAndFilename, ImageFormat.Png);
                }

                // TODO I am not sure how to handle this -- do we need to dispose of the Process returned here if
                // the image editor launched may outlive Scribe?
                _ = Settings.Default.EditInApp
                    ? Process.Start(Settings.Default.ImageEditor, $"\"{imagePathAndFilename}\"")
                    : Process.Start("explorer", $"\"{imagePathAndFilename}\"");
            }
            else
            {
                SystemSounds.Beep.Play();
            }
        }

        /// <summary>
        /// Responds to the player requesting a picture be reloaded.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void PictureBoxReload_Click(object sender, EventArgs e)
            => PictureBoxLoadFromStorage(GetPictureBoxForTab(EditorTabs.SelectedIndex),
                                           GetSelectedModelIDForTab(EditorTabs.SelectedIndex));
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
