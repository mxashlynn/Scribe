using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public const string UnthemedControl = "Unthemed Control";

        /// <summary>Tag identifying controls whose color indicates that its text cannot be edited.</summary>
        public const string ThemedLabel = "Themed";

        /// <summary>Tag identifying controls whose changes are not managed via <see cref="ContentAlteredEventHandler"/>.</summary>
        public const string UntrackedControl = "Untracked Control";

        /// <summary>The currently active <see cref="TextBox"/> or <see cref="ComboBox"/>, if any.</summary>
        private EditableBox SourceBox;

        /// <summary>
        /// A collection of all editable <see cref="PictureBox"/>es in the <see cref="MainEditorForm"/>.
        /// </summary>
        private readonly List<PictureBox> PictureBoxes;

        /// <summary>
        /// A collection of all themed <see cref="Component"/>s in the <see cref="MainEditorForm"/>.
        /// </summary>
        private readonly Dictionary<Type, List<Component>> ThemedComponents;

        /// <summary>
        /// A collection of all <see cref="Control"/>s whose content is displayed in a <see cref="ListBox"/>
        /// that is visible at the same time the control itself is visible, so that the ListBox can be updated
        /// on changes to the control's content.
        /// </summary>
        private readonly Dictionary<Control, ListBox> ControlsWhoseContentIsListed;

        /// <summary>Used to determine if the <see cref="Settings.Default.CurrentEditorTheme"/> has changed.</summary>
        private static string oldTheme = "";

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

            #region Cache Controls
            PictureBoxes = EditorTabs.GetAllChildrenExactlyOfType<PictureBox>().ToList();
            ThemedComponents = GetThemedComponents();
            foreach (var component in ThemedComponents[typeof(ToolStripItem)])
            {
                if (component is ToolStripSeparator separator)
                {
                    separator.Paint += ToolStripSeparator_Paint;
                }
            }
            typeof(Control).GetMethod("SetStyle", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                           .Invoke(ToolStripProgressBar.ProgressBar,
                                   new object[] { ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true });
            ToolStripProgressBar.ProgressBar.Paint += ProgressBar_Paint;

            EditableControls = GetEditableControls();
            var flatListOfEditableControls = EditableControls.Values.SelectMany(dictionary => dictionary.Keys);
            foreach (var editableControl in flatListOfEditableControls)
            {
                editableControl.Validated += ContentAlteredEventHandler;
            }

            var listOfControlsWithTextEntry =
                EditableControls[typeof(TextBox)].Keys
                                                 .Concat(EditableControls[typeof(ComboBox)].Keys);
            foreach (var textEntryControl in listOfControlsWithTextEntry)
            {
                textEntryControl.ContextMenuStrip = ContextMenuStripForTextEntries;
            }

            // NOTE that this section must be updated by hand whenever listed controls are adjusted.
            ControlsWhoseContentIsListed = new Dictionary<Control, ListBox>
            {
                [GameNameTextBox] = GameListBox,
                [FloorNameTextBox] = FloorListBox,
                [BlockNameTextBox] = BlockListBox,
                [FurnishingNameTextBox] = FurnishingListBox,
                [CollectibleNameTextBox] = CollectibleListBox,
                [CritterNameTextBox] = CritterListBox,
                //[CharacterPersonalNameTextBox] = CharacterListBox;
                //[CharacterFamilyNameTextBox] = CharacterListBox;
                [CharacterPronounSubjectiveTextBox] = CharacterPronounListBox,
                [CharacterPronounObjectiveTextBox] = CharacterPronounListBox,
                [CharacterPronounDeterminerTextBox] = CharacterPronounListBox,
                [CharacterPronounPossessiveTextBox] = CharacterPronounListBox,
                [CharacterPronounReflexiveTextBox] = CharacterPronounListBox,
                [ItemNameTextBox] = ItemListBox,
                [BiomeNameTextBox] = BiomeListBox,
                [CraftingNameTextBox] = CraftingListBox,
                [RoomNameTextBox] = RoomListBox,
                // TODO Maps?
                // TODO Scripts?
            };
            #endregion

            FormClosing += FormClosingEventHandler;

            #region Set Up Current Theme
            if (Enum.TryParse<EditorTheme>(Settings.Default.CurrentEditorTheme, out var theme))
            {
                CurrentTheme.SetUpTheme(theme);
            }
            else
            {
                SystemSounds.Beep.Play();
                var message = string.Format(CultureInfo.CurrentCulture, Resources.ErrorParseFailed,
                                            nameof(Settings.Default.CurrentEditorTheme));
                _ = MessageBox.Show(message, Resources.CaptionError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
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
            UpdateFromSettings();
        }

        /// <summary>
        /// Updates the form when it receives focus, for example after closing the options dialogue box.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void MainEditorForm_Activated(object sender, EventArgs eventArguments)
            => UpdateFromSettings();

        /// <summary>
        /// Finds all themed <see cref="Component"/>s in the <see cref="MainEditorForm"/>.
        /// </summary>
        /// <returns>A dictionary containing lists of components, organized by type.</returns>
        private Dictionary<Type, List<Component>> GetThemedComponents()
        {
            var themed = new Dictionary<Type, List<Component>>
            {
                [typeof(ToolStripItem)] = new List<Component>(),
                [typeof(GroupBox)] = new List<Component>(),
                [typeof(ListBox)] = new List<Component>(),
                [typeof(ComboBox)] = new List<Component>(),
                [typeof(TextBox)] = new List<Component>(),
                [typeof(Label)] = new List<Component>(),
                [typeof(Button)] = new List<Component>(),
            };
            themed[typeof(ToolStripItem)].AddRange(MainMenuBar.Items.GetAllChildren());
            themed[typeof(ToolStripItem)].AddRange(ContextMenuStripPictureBoxes.Items.GetAllChildren());
            themed[typeof(ToolStripItem)].AddRange(ContextMenuStripIDExamples.Items.GetAllChildren());
            themed[typeof(GroupBox)].AddRange(this.GetAllChildrenExactlyOfType<GroupBox>()
                                    .Where(groupBox => null == groupBox.Tag || !groupBox.Tag.ToString().Contains(UnthemedControl)));
            themed[typeof(ListBox)].AddRange(this.GetAllChildrenExactlyOfType<ListBox>()
                                    .Where(listbox => null == listbox.Tag || !listbox.Tag.ToString().Contains(UnthemedControl)));
            themed[typeof(ComboBox)].AddRange(this.GetAllChildrenExactlyOfType<ComboBox>()
                                    .Where(combobox => null == combobox.Tag || !combobox.Tag.ToString().Contains(UnthemedControl)));
            themed[typeof(TextBox)].AddRange(this.GetAllChildrenExactlyOfType<TextBox>()
                                    .Where(textbox => null == textbox.Tag || !textbox.Tag.ToString().Contains(UnthemedControl)));
            themed[typeof(Label)].AddRange(this.GetAllChildrenExactlyOfType<Label>()
                                    .Where(label => null != label.Tag && label.Tag.ToString().Contains(ThemedLabel)));
            themed[typeof(Button)].AddRange(this.GetAllChildrenExactlyOfType<Button>()
                                    .Where(button => null == button.Tag || !button.Tag.ToString().Contains(UnthemedControl)));
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
                [typeof(ListBox)] = new Dictionary<Control, object>(),
                [typeof(ComboBox)] = new Dictionary<Control, object>(),
                [typeof(TextBox)] = new Dictionary<Control, object>(),
                [typeof(CheckBox)] = new Dictionary<Control, object>(),
            };

            editables[typeof(ListBox)].CacheControls(EditorTabs.GetAllChildrenExactlyOfType<ListBox>()
                                      .Where(listbox => null == listbox.Tag || !listbox.Tag.ToString().Contains(UnthemedControl))
                                      .Cast<Control>());
            editables[typeof(ComboBox)].CacheControls(EditorTabs.GetAllChildrenExactlyOfType<ComboBox>()
                                       .Where(combobox => null == combobox.Tag || !combobox.Tag.ToString().Contains(UnthemedControl))
                                       .Cast<Control>());
            editables[typeof(TextBox)].CacheControls(EditorTabs.GetAllChildrenExactlyOfType<TextBox>()
                                      .Where(textbox => null == textbox.Tag || !textbox.Tag.ToString().Contains(UnthemedControl))
                                      .Cast<Control>());
            editables[typeof(CheckBox)].CacheControls(EditorTabs.GetAllChildrenExactlyOfType<CheckBox>()
                                       .Where(checkbox => null == checkbox.Tag || !checkbox.Tag.ToString().Contains(UnthemedControl))
                                       .Cast<Control>());
            return editables;
        }
        #endregion

        #region Tab Management
        #region Tab Indices
        private const int GamesTabIndex = 0;
        private const int FloorsTabIndex = 1;
        private const int BlocksTabIndex = 2;
        private const int FurnishingsTabIndex = 3;
        private const int CollectiblesTabIndex = 4;
        private const int CrittersTabIndex = 5;
        private const int CharactersTabIndex = 6;
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
                GamesTabIndex => (GameModel)GameListBox.SelectedItem,
                BlocksTabIndex => (BlockModel)BlockListBox.SelectedItem,
                FloorsTabIndex => (FloorModel)FloorListBox.SelectedItem,
                FurnishingsTabIndex => (FurnishingModel)FurnishingListBox.SelectedItem,
                CollectiblesTabIndex => (CollectibleModel)CollectibleListBox.SelectedItem,
                CharactersTabIndex => (CharacterModel)CharacterListBox.SelectedItem,
                CrittersTabIndex => (CritterModel)CritterListBox.SelectedItem,
                ItemsTabIndex => (ItemModel)ItemListBox.SelectedItem,
                BiomeRecipesTabIndex => (BiomeRecipe)BiomeListBox.SelectedItem,
                CraftingRecipesTabIndex => (CraftingRecipe)CraftingListBox.SelectedItem,
                RoomRecipesTabIndex => (RoomRecipe)RoomListBox.SelectedItem,
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
                    => (input) => ((IMutablePronounGroup)CharacterPronounListBox.SelectedItem).Subjective = input.ToString(),
                (CharactersTabIndex, "CharacterPronounObjectiveTextBox")
                    => (input) => ((IMutablePronounGroup)CharacterPronounListBox.SelectedItem).Objective = input.ToString(),
                (CharactersTabIndex, "CharacterPronounDeterminerTextBox")
                    => (input) => ((IMutablePronounGroup)CharacterPronounListBox.SelectedItem).Determiner = input.ToString(),
                (CharactersTabIndex, "CharacterPronounPossessiveTextBox")
                    => (input) => ((IMutablePronounGroup)CharacterPronounListBox.SelectedItem).Possessive = input.ToString(),
                (CharactersTabIndex, "CharacterPronounReflexiveTextBox")
                    => (input) => ((IMutablePronounGroup)CharacterPronounListBox.SelectedItem).Reflexive = input.ToString(),
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
                    => (input) => ((IMutableGameModel)inModel).Name = input.ToString(),
                (GamesTabIndex, "GameDescriptionTextBox")
                    => (input) => ((IMutableGameModel)inModel).Description = input.ToString(),
                (GamesTabIndex, "GameCommentTextBox")
                    => (input) => ((IMutableGameModel)inModel).Comment = input.ToString(),
                (GamesTabIndex, "GameIsEpisodeCheckBox")
                    => (input) => ((IMutableGameModel)inModel).IsEpisode = ValueToBool(input),
                (GamesTabIndex, "GameEpisodeTitleTextBox")
                    => (input) => ((IMutableGameModel)inModel).EpisodeTitle = input.ToString(),
                (GamesTabIndex, "GameEpisodeNumberTextBox")
                    => (input) => ((IMutableGameModel)inModel).EpisodeNumber = ValueToInt(input),
                (GamesTabIndex, "GamePlayerCharacterComboBox")
                    => (input) => ((IMutableGameModel)inModel).PlayerCharacterID = ValueToID(input),
                (GamesTabIndex, "GameFirstScriptComboBox")
                    => (input) => ((IMutableGameModel)inModel).FirstScriptID = ValueToID(input),
                #endregion

                #region BlockModels
                (BlocksTabIndex, "BlockNameTextBox")
                    => (input) => ((IMutableBlockModel)inModel).Name = input.ToString(),
                (BlocksTabIndex, "BlockDescriptionTextBox")
                    => (input) => ((IMutableBlockModel)inModel).Description = input.ToString(),
                (BlocksTabIndex, "BlockCommentTextBox")
                    => (input) => ((IMutableBlockModel)inModel).Comment = input.ToString(),
                (BlocksTabIndex, "BlockMaxToughnessTextBox")
                    => (input) => ((IMutableBlockModel)inModel).MaxToughness = ValueToInt(input),
                (BlocksTabIndex, "BlockIsFlammableCheckBox")
                    => (input) => ((IMutableBlockModel)inModel).IsFlammable = ValueToBool(input),
                (BlocksTabIndex, "BlockIsLiquidCheckBox")
                    => (input) => ((IMutableBlockModel)inModel).IsLiquid = ValueToBool(input),
                (BlocksTabIndex, "BlockGatherToolComboBox")
                    => (input) => ((IMutableBlockModel)inModel).GatherTool = ValueToEnum<GatheringTool>(input),
                (BlocksTabIndex, "BlockGatherEffectComboBox")
                    => (input) => ((IMutableBlockModel)inModel).GatherEffect = ValueToEnum<GatheringEffect>(input),
                (BlocksTabIndex, "BlockDroppedCollectibleIDComboBox")
                    => (input) => ((IMutableBlockModel)inModel).CollectibleID = ValueToID(input),
                (BlocksTabIndex, "BlockEquivalentItemComboBox")
                    => (input) => ((IMutableBlockModel)inModel).ItemID = ValueToID(input),
                #endregion

                #region FloorModels
                (FloorsTabIndex, "FloorNameTextBox")
                    => (input) => ((IMutableFloorModel)inModel).Name = input.ToString(),
                (FloorsTabIndex, "FloorDescriptionTextBox")
                    => (input) => ((IMutableFloorModel)inModel).Description = input.ToString(),
                (FloorsTabIndex, "FloorCommentTextBox")
                    => (input) => ((IMutableFloorModel)inModel).Comment = input.ToString(),
                (FloorsTabIndex, "FloorTrenchNameTextBox")
                    => (input) => ((IMutableFloorModel)inModel).TrenchName = input.ToString(),
                (FloorsTabIndex, "FloorlItemIDComboBox")
                    => (input) => ((IMutableFloorModel)inModel).ItemID = ValueToID(input),
                (FloorsTabIndex, "FloorModificationToolComboBox")
                    => (input) => ((IMutableFloorModel)inModel).ModTool = ValueToEnum<ModificationTool>(input),
                #endregion

                #region FurnishingModels
                (FurnishingsTabIndex, "FurnishingNameTextBox")
                    => (input) => ((IMutableFurnishingModel)inModel).Name = input.ToString(),
                (FurnishingsTabIndex, "FurnishingDescriptionTextBox")
                    => (input) => ((IMutableFurnishingModel)inModel).Description = input.ToString(),
                (FurnishingsTabIndex, "FurnishingCommentTextBox")
                    => (input) => ((IMutableFurnishingModel)inModel).Comment = input.ToString(),
                (FurnishingsTabIndex, "FurnishingEquivalentItemComboBox")
                    => (input) => ((IMutableFurnishingModel)inModel).ItemID = ValueToID(input),
                (FurnishingsTabIndex, "FurnishingEntryTypeComboBox")
                    => (input) => ((IMutableFurnishingModel)inModel).Entry = ValueToEnum<EntryType>(input),
                (FurnishingsTabIndex, "FurnishingSwapWithFurnishingComboBox")
                    => (input) => ((IMutableFurnishingModel)inModel).SwapID = ValueToID(input),
                (FurnishingsTabIndex, "FurnishingIsEnclosingCheckBox")
                    => (input) => ((IMutableFurnishingModel)inModel).IsEnclosing = ValueToBool(input),
                (FurnishingsTabIndex, "FurnishingIsFlammableCheckBox")
                    => (input) => ((IMutableFurnishingModel)inModel).IsFlammable = ValueToBool(input),
                (FurnishingsTabIndex, "FurnishingIsWalkableCheckBox")
                    => (input) => ((IMutableFurnishingModel)inModel).IsWalkable = ValueToBool(input),
                #endregion

                #region CollectibleModels
                (CollectiblesTabIndex, "CollectibleNameTextBox")
                    => (input) => ((IMutableCollectibleModel)inModel).Name = input.ToString(),
                (CollectiblesTabIndex, "CollectibleDescriptionTextBox")
                    => (input) => ((IMutableCollectibleModel)inModel).Description = input.ToString(),
                (CollectiblesTabIndex, "CollectibleCommentTextBox")
                    => (input) => ((IMutableCollectibleModel)inModel).Comment = input.ToString(),
                (CollectiblesTabIndex, "CollectibleEffectAmountTextBox")
                    => (input) => ((IMutableCollectibleModel)inModel).EffectAmount = ValueToInt(input),
                (CollectiblesTabIndex, "CollectibleCollectionEffectComboBox")
                    => (input) => ((IMutableCollectibleModel)inModel).CollectionEffect = ValueToEnum<CollectingEffect>(input),
                (CollectiblesTabIndex, "CollectibleEquivalentItemComboBox")
                    => (input) => ((IMutableCollectibleModel)inModel).ItemID = ValueToID(input),
                #endregion

                #region CharacterModels
                (CharactersTabIndex, "CharacterNameTextBox")
                    => (input) => ((IMutableCharacterModel)inModel).Name = input.ToString(),
                (CharactersTabIndex, "CharacterDescriptionTextBox")
                    => (input) => ((IMutableCharacterModel)inModel).Description = input.ToString(),
                (CharactersTabIndex, "CharacterCommentTextBox")
                    => (input) => ((IMutableCharacterModel)inModel).Comment = input.ToString(),
                (CharactersTabIndex, "CharacterNativeBiomeComboBox")
                    => (input) => ((IMutableCharacterModel)inModel).NativeBiomeID = ValueToID(input),
                (CharactersTabIndex, "CharacterPrimaryBehaviorComboBox")
                    => (input) => ((IMutableCharacterModel)inModel).PrimaryBehaviorID = ValueToID(input),
                (CharactersTabIndex, "CharacterStoryIDTextBox")
                    => (input) => ((IMutableCharacterModel)inModel).StoryCharacterID = input.ToString(),
                (CharactersTabIndex, "CharacterPronounComboBox")
                    => (input) => ((IMutableCharacterModel)inModel).PronounKey = input.ToString(),
                (CharactersTabIndex, "CharacterStartingDialogueComboBox")
                    => (input) => ((IMutableCharacterModel)inModel).StartingDialogueID = ValueToID(input),
                (CharactersTabIndex, "CharacterStartingQuestsListBox")
                    => (input) =>
                    {
                        var editModel = (IMutableCharacterModel)inModel;
                        editModel.StartingQuestIDs.Clear();
                        editModel.StartingQuestIDs.ToList().AddRange(input.ToEnumerable<ModelID>());
                    },
                #endregion

                #region CritterModels
                (CrittersTabIndex, "CritterNameTextBox")
                    => (input) => ((IMutableCritterModel)inModel).Name = input.ToString(),
                (CrittersTabIndex, "CritterDescriptionTextBox")
                    => (input) => ((IMutableCritterModel)inModel).Description = input.ToString(),
                (CrittersTabIndex, "CritterCommentTextBox")
                    => (input) => ((IMutableCritterModel)inModel).Comment = input.ToString(),
                (CrittersTabIndex, "CritterNativeBiomeComboBox")
                    => (input) => ((IMutableCritterModel)inModel).NativeBiomeID = ValueToID(input),
                (CrittersTabIndex, "CritterPrimaryBehaviorComboBox")
                    => (input) => ((IMutableCritterModel)inModel).PrimaryBehaviorID = ValueToID(input),
                #endregion

                #region ItemModels
                (ItemsTabIndex, "ItemNameTextBox")
                    => (input) => ((IMutableItemModel)inModel).Name = input.ToString(),
                (ItemsTabIndex, "ItemDescriptionTextBox")
                    => (input) => ((IMutableItemModel)inModel).Description = input.ToString(),
                (ItemsTabIndex, "ItemCommentTextBox")
                    => (input) => ((IMutableItemModel)inModel).Comment = input.ToString(),
                (ItemsTabIndex, "ItemSubtypeComboBox")
                    => (input) => ((IMutableItemModel)inModel).Subtype = ValueToEnum<ItemType>(input),
                (ItemsTabIndex, "ItemPriceTextBox")
                    => (input) => ((IMutableItemModel)inModel).Price = ValueToInt(input),
                (ItemsTabIndex, "ItemTagListBox")
                    => (input) => ((IMutableItemModel)inModel).ItemTags.ToList().Add((ModelTag)input),
                (ItemsTabIndex, "ItemStackMaxTextBox")
                    => (input) => ((IMutableItemModel)inModel).StackMax = ValueToInt(input),
                (ItemsTabIndex, "ItemRarityTextBox")
                    => (input) => ((IMutableItemModel)inModel).Rarity = ValueToInt(input),
                (ItemsTabIndex, "ItemEffectWhenUsedComboBox")
                    => (input) => ((IMutableItemModel)inModel).EffectWhenUsedID = ValueToID(input),
                (ItemsTabIndex, "ItemEffectWhileHeldComboBox")
                    => (input) => ((IMutableItemModel)inModel).EffectWhileHeldID = ValueToID(input),
                (ItemsTabIndex, "ItemEquivalentParquetComboBox")
                    => (input) => ((IMutableItemModel)inModel).ParquetID = ValueToID(input),
                #endregion

                #region BiomeRecipes
                (BiomeRecipesTabIndex, "BiomeNameTextBox")
                    => (input) => ((IMutableBiomeRecipe)inModel).Name = input.ToString(),
                (BiomeRecipesTabIndex, "BiomeDescriptionTextBox")
                    => (input) => ((IMutableBiomeRecipe)inModel).Description = input.ToString(),
                (BiomeRecipesTabIndex, "BiomeCommentTextBox")
                    => (input) => ((IMutableBiomeRecipe)inModel).Comment = input.ToString(),
                (BiomeRecipesTabIndex, "BiomeTierTextBox")
                    => (input) => ((IMutableBiomeRecipe)inModel).Tier = ValueToInt(input),
                (BiomeRecipesTabIndex, "BiomeIsLiquidBasedCheckBox")
                    => (input) => ((IMutableBiomeRecipe)inModel).IsLiquidBased = ValueToBool(input),
                (BiomeRecipesTabIndex, "BiomeIsRoomBasedCheckBox")
                    => (input) => ((IMutableBiomeRecipe)inModel).IsRoomBased = ValueToBool(input),
                (BiomeRecipesTabIndex, "BiomeEntryRequirementsListBox")
                    => (input) =>
                    {
                        var editRecipe = (IMutableBiomeRecipe)inModel;
                        editRecipe.EntryRequirements.ToList().Add((ModelTag)input);
                    },
                (BiomeRecipesTabIndex, "BiomeParquetCriteriaListBox")
                    => (input) =>
                    {
                        var editRecipe = (IMutableBiomeRecipe)inModel;
                        editRecipe.ParquetCriteria.ToList().Add((ModelTag)input);
                    },
                #endregion

                #region CraftingRecipes
                (CraftingRecipesTabIndex, "CraftingNameTextBox")
                    => (input) => ((IMutableCraftingRecipe)inModel).Name = input.ToString(),
                (CraftingRecipesTabIndex, "CraftingDescriptionTextBox")
                    => (input) => ((IMutableCraftingRecipe)inModel).Description = input.ToString(),
                (CraftingRecipesTabIndex, "CraftingCommentTextBox")
                    => (input) => ((IMutableCraftingRecipe)inModel).Comment = input.ToString(),
                (CraftingRecipesTabIndex, "CraftingIngredientsListBox")
                    => (input) =>
                    {
                        var editRecipe = (IMutableCraftingRecipe)inModel;
                        editRecipe.Ingredients.Clear();
                        editRecipe.Ingredients.ToList().AddRange(input.ToEnumerable<RecipeElement>());
                    },
                (CraftingRecipesTabIndex, "CraftingProductsListBox")
                    => (input) =>
                    {
                        var editRecipe = (IMutableCraftingRecipe)inModel;
                        editRecipe.Products.Clear();
                        editRecipe.Products.ToList().AddRange(input.ToEnumerable<RecipeElement>());
                    },
                #endregion

                #region RoomRecipes
                (RoomRecipesTabIndex, "RoomNameTextBox")
                    => (input) => ((IMutableRoomRecipe)inModel).Name = input.ToString(),
                (RoomRecipesTabIndex, "RoomDescriptionTextBox")
                    => (input) => ((IMutableRoomRecipe)inModel).Description = input.ToString(),
                (RoomRecipesTabIndex, "RoomCommentTextBox")
                    => (input) => ((IMutableRoomRecipe)inModel).Comment = input.ToString(),
                (RoomRecipesTabIndex, "RoomMinimumWalkableSpacesTextBox")
                    => (input) => ((IMutableRoomRecipe)inModel).MinimumWalkableSpaces = ValueToInt(input),
                (RoomRecipesTabIndex, "RoomRequiredFurnishingsListBox")
                    => (input) =>
                    {
                        var editRecipe = (IMutableRoomRecipe)inModel;
                        editRecipe.OptionallyRequiredFurnishings.Clear();
                        editRecipe.OptionallyRequiredFurnishings.ToList().AddRange(input.ToEnumerable<RecipeElement>());
                    },
                (RoomRecipesTabIndex, "RoomRequiredBlocksListBox")
                    => (input) =>
                    {
                        var editRecipe = (IMutableRoomRecipe)inModel;
                        editRecipe.OptionallyRequiredPerimeterBlocks.Clear();
                        editRecipe.OptionallyRequiredPerimeterBlocks.ToList().AddRange(input.ToEnumerable<RecipeElement>());
                    },
                (RoomRecipesTabIndex, "RoomRequiredFloorsListBox")
                    => (input) =>
                    {
                        var editRecipe = (IMutableRoomRecipe)inModel;
                        editRecipe.OptionallyRequiredWalkableFloors.Clear();
                        editRecipe.OptionallyRequiredWalkableFloors.ToList().AddRange(input.ToEnumerable<RecipeElement>());
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

                _ => (Action<object>)null,
            };
        #endregion

        #region Update Main Display
        /// <summary>
        /// Brings the <see cref="MainEditorForm"/> in line with the <see cref="Settings.Default"/> profile.
        /// </summary>
        private void UpdateFromSettings()
        {
            #region Update Filter Display
            FlavorFilterGroupBox.Enabled =
                FlavorFilterGroupBox.Visible = Settings.Default.UseFlavorFilters;
            #endregion

            #region Update Theming
            if (oldTheme != Settings.Default.CurrentEditorTheme)
            {
                ApplyCurrentTheme();
            }
            #endregion

            #region Select Default Model
            if (null == GetSelectedModelForTab(EditorTabs.SelectedIndex))
            {
                var selectedListBox = GetPrimaryListBoxForTab(EditorTabs.SelectedIndex);
                if (null != selectedListBox)
                {
                    selectedListBox.SelectedItem = selectedListBox.Items.Cast<Model>().ElementAtOrDefault(0);
                }
            }
            #endregion
        }

        /// <summary>
        /// Occurs whenever a <see cref="ToolStripSeparator"/> needs to be painted.
        /// Paints each manually so that the separator has the same color as its menu.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Used to draw the separator.</param>
        private void MainToolStripStatusLabel_TextChanged(object sender, EventArgs eventArguments)
            => EditorStatusStrip.Update();

        /// <summary>
        /// Applies the <see cref="CurrentTheme"/> to the <see cref="MainEditorForm"/> and its <see cref="Control"/>s.
        /// </summary>
        private void ApplyCurrentTheme()
        {
            #region Apply Theme to Primary Form
            BackColor = CurrentTheme.ControlBackgroundColor;
            ForeColor = CurrentTheme.ControlForegroundColor;
            ToolStripProgressBar.BackColor = CurrentTheme.UneditableBackgroundColor;
            ToolStripProgressBar.ForeColor = CurrentTheme.HighlightColor;
            EditorStatusStrip.BackColor = CurrentTheme.ControlBackgroundColor;
            MainMenuBar.BackColor = CurrentTheme.ControlBackgroundColor;
            MainMenuBar.ForeColor = CurrentTheme.ControlForegroundColor;
            #endregion

            #region Apply Theme to Controls
            foreach (var pictureBox in PictureBoxes)
            {
                pictureBox.BackColor = CurrentTheme.UneditableBackgroundColor;
            }
            foreach (var toolStripItem in ThemedComponents[typeof(ToolStripItem)])
            {
                ((ToolStripItem)toolStripItem).BackColor = CurrentTheme.ControlBackgroundColor;
                ((ToolStripItem)toolStripItem).ForeColor = CurrentTheme.ControlForegroundColor;
            }
            foreach (var groupBox in ThemedComponents[typeof(GroupBox)])
            {
                ((GroupBox)groupBox).BackColor = CurrentTheme.ControlBackgroundColor;
                ((GroupBox)groupBox).ForeColor = CurrentTheme.ControlForegroundColor;
            }
            foreach (var listBox in ThemedComponents[typeof(ListBox)])
            {
                ((ListBox)listBox).BackColor = CurrentTheme.ControlBackgroundWhite;
                ((ListBox)listBox).ForeColor = CurrentTheme.ControlForegroundColor;
            }
            foreach (var comboBox in ThemedComponents[typeof(ComboBox)])
            {
                ((ComboBox)comboBox).BackColor = CurrentTheme.ControlBackgroundWhite;
                ((ComboBox)comboBox).ForeColor = CurrentTheme.ControlForegroundColor;
            }
            foreach (var textBox in ThemedComponents[typeof(TextBox)])
            {
                ((TextBox)textBox).BackColor = CurrentTheme.ControlBackgroundWhite;
                ((TextBox)textBox).ForeColor = CurrentTheme.ControlForegroundColor;
            }
            foreach (var label in ThemedComponents[typeof(Label)])
            {
                ((Label)label).BackColor = CurrentTheme.UneditableBackgroundColor;
                ((Label)label).ForeColor = CurrentTheme.ControlForegroundColor;
            }
            foreach (var button in ThemedComponents[typeof(Button)])
            {
                ((Button)button).BackColor = CurrentTheme.ControlBackgroundColor;
                ((Button)button).FlatAppearance.BorderColor = CurrentTheme.BorderColor;
                ((Button)button).FlatAppearance.MouseDownBackColor = CurrentTheme.MouseDownColor;
                ((Button)button).FlatAppearance.MouseOverBackColor = CurrentTheme.MouseOverColor;
            }
            #endregion

            #region Apply Theme to Tabs
            GamesTabPage.BackColor =
                FileFormatGroupBox.BackColor =
                LibraryInfoGroupBox.BackColor = CurrentTheme.GamesTabColor;
            BlocksTabPage.BackColor =
                BlockConfigGroupBox.BackColor =
                FloorsTabPage.BackColor =
                FloorConfigGroupBox.BackColor =
                FurnishingsTabPage.BackColor =
                FurnishingConfigGroupBox.BackColor =
                CollectiblesTabPage.BackColor =
                CollectibleConfigGroupBox.BackColor = CurrentTheme.ParquetsTabColor;
            CharactersTabPage.BackColor =
                CharacterPronounGroupBox.BackColor =
                CrittersTabPage.BackColor =
                CritterConfigGroupBox.BackColor = CurrentTheme.BeingsTabColor;
            ItemsTabPage.BackColor =
                ItemInventoriesGroupBox.BackColor = CurrentTheme.ItemsTabColor;
            BiomesTabPage.BackColor =
                BiomeConfigGroupBox.BackColor =
                CraftingRecipesTabPage.BackColor =
                CraftingConfigGroupBox.BackColor =
                RoomRecipesTabPage.BackColor =
                RoomConfigGroupBox.BackColor = CurrentTheme.RecipesTabColor;
            MapsTabPage.BackColor = CurrentTheme.MapsTabColor;
            ScriptsTabPage.BackColor = CurrentTheme.ScriptsTabColor;
            #endregion
        }

        /// <summary>
        /// Occurs whenever a <see cref="ToolStripSeparator"/> needs to be painted.
        /// Paints each manually so that the separator has the same color as its menu.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Used to draw the separator.</param>
        private void ToolStripSeparator_Paint(object sender, PaintEventArgs eventArguments)
        {
            var separator = (ToolStripSeparator)sender;
            var backgroundBrush = new SolidBrush(CurrentTheme.ControlBackgroundColor);
            var foregroundPen = new Pen(CurrentTheme.ControlForegroundColor);
            eventArguments.Graphics.FillRectangle(backgroundBrush, 0, 0, separator.Width, separator.Height);
            eventArguments.Graphics.DrawLine(foregroundPen, 30, separator.Height / 2, separator.Width - 4, separator.Height / 2);
        }

        /// <summary>
        /// Occurs whenever a <see cref="ProgressBar"/> needs to be painted.
        /// Paints each manually so that the bar has the correct colors.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Used to draw the bar.</param>
        private void ProgressBar_Paint(object sender, PaintEventArgs eventArguments)
        {
            var highlightBrush = new SolidBrush(CurrentTheme.HighlightColor);
            var uneditableBackgroundBrush = new SolidBrush(CurrentTheme.UneditableBackgroundColor);
            var bar = (ProgressBar)sender;
            var percent = (float)bar.Value / bar.Maximum;
            var widthOfFilledPortion = percent * bar.Width;
            var filledRectangle = new RectangleF(2.0f, 2.0f, widthOfFilledPortion, bar.Height - 4);
            eventArguments.Graphics.FillRectangle(uneditableBackgroundBrush, 0, 0, bar.Width, bar.Height);
            eventArguments.Graphics.FillRectangle(highlightBrush, filledRectangle);
            ControlPaint.DrawBorder3D(eventArguments.Graphics, bar.ClientRectangle, Border3DStyle.SunkenOuter);
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

            RepopulateVisibleControls();

            // TODO Remove this and set up real progress bar animation (e.g. file i/o).
            ToolStripProgressBar.Value = 35;
            EditorStatusStrip.Update();
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
        /// Occurs whenever a particular tab and tab-page needs to be painted.
        /// Paints each manually so that the tab itself has the same color as its page.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Used to draw the tab and content.</param>
        private void EditorTabs_DrawItem(object sender, DrawItemEventArgs eventArguments)
        {
            var tab = EditorTabs.TabPages[eventArguments.Index];
            var textBounds = eventArguments.Bounds;
            var textOffsetY = (eventArguments.State == DrawItemState.Selected)
                ? -2
                : 1;
            eventArguments.Graphics.FillRectangle(new SolidBrush(tab.BackColor), eventArguments.Bounds);
            textBounds.Offset(1, textOffsetY);
            TextRenderer.DrawText(eventArguments.Graphics, tab.Text, eventArguments.Font, textBounds, tab.ForeColor);
        }

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
        /// Updates only those <see cref="Control"/>s that are on the currently selected <see cref="TabPage"/>.
        /// </summary>
        private void RepopulateVisibleControls()
        {
            switch (EditorTabs.SelectedIndex)
            {
                // TODO Add secondary container controls that may be out of date for each tab.
                case GamesTabIndex:
                    RepopulateListBox(GameListBox, All.Games);
                    RepopulateComboBox(GamePlayerCharacterComboBox, All.Characters);
                    RepopulateComboBox(GameFirstScriptComboBox, All.Scripts);
                    break;
                case BlocksTabIndex:
                    RepopulateListBox(BlockListBox, All.Blocks);
                    RepopulateComboBox(BlockEquivalentItemComboBox, All.Items);
                    RepopulateComboBox(BlockGatherToolComboBox, Enumerable.Cast<object>(Enum.GetValues(typeof(GatheringTool))));
                    RepopulateComboBox(BlockGatherEffectComboBox, Enumerable.Cast<object>(Enum.GetValues(typeof(GatheringEffect))));
                    RepopulateComboBox(BlockDroppedCollectibleIDComboBox, All.Collectibles);
                    break;
                case FloorsTabIndex:
                    RepopulateListBox(FloorListBox, All.Floors);
                    RepopulateComboBox(FloorEquivalentItemComboBox, All.Items);
                    RepopulateComboBox(FloorModificationToolComboBox, Enumerable.Cast<object>(Enum.GetValues(typeof(ModificationTool))));
                    break;
                case FurnishingsTabIndex:
                    RepopulateListBox(FurnishingListBox, All.Furnishings);
                    RepopulateComboBox(FurnishingEquivalentItemComboBox, All.Items);
                    RepopulateComboBox(FurnishingEntryTypeComboBox, Enumerable.Cast<object>(Enum.GetValues(typeof(EntryType))));
                    RepopulateComboBox(FurnishingSwapWithFurnishingComboBox, All.Furnishings);
                    break;
                case CollectiblesTabIndex:
                    RepopulateListBox(CollectibleListBox, All.Collectibles);
                    RepopulateComboBox(CollectibleEquivalentItemComboBox, All.Items);
                    RepopulateComboBox(CollectibleCollectionEffectComboBox, Enumerable.Cast<object>(Enum.GetValues(typeof(CollectingEffect))));
                    break;
                case CrittersTabIndex:
                    RepopulateListBox(CritterListBox, All.Critters);
                    RepopulateComboBox(CritterNativeBiomeComboBox, All.BiomeRecipes);
                    RepopulateComboBox(CritterPrimaryBehaviorComboBox, All.Scripts);
                    break;
                case CharactersTabIndex:
                    RepopulateListBox(CharacterListBox, All.Characters);
                    RepopulateComboBox(CharacterNativeBiomeComboBox, All.BiomeRecipes);
                    RepopulateComboBox(CharacterPrimaryBehaviorComboBox, All.Scripts);
                    RepopulateComboBox(CharacterPronounComboBox, All.PronounGroups.Select(pronounGroup => pronounGroup.GetKey()));
                    RepopulateComboBox(CharacterStartingDialogueComboBox, All.Interactions);
                    RepopulateListBox(CharacterPronounListBox, All.PronounGroups);
                    break;
                case ItemsTabIndex:
                    RepopulateListBox(ItemListBox, All.Items);
                    RepopulateComboBox(ItemSubtypeComboBox, Enumerable.Cast<object>(Enum.GetValues(typeof(ItemType))));
                    RepopulateComboBox(ItemEffectWhileHeldComboBox, All.Scripts);
                    RepopulateComboBox(ItemEffectWhenUsedComboBox, All.Scripts);
                    RepopulateComboBox(ItemEquivalentParquetComboBox, All.Parquets);
                    RepopulateListBox(ItemInventoryListBox, All.Characters);
                    break;
                case BiomeRecipesTabIndex:
                    RepopulateListBox(BiomeListBox, All.BiomeRecipes);
                    // TODO Biomes
                    break;
                case CraftingRecipesTabIndex:
                    RepopulateListBox(CraftingListBox, All.CraftingRecipes);
                    // TODO Crafting
                    break;
                case RoomRecipesTabIndex:
                    RepopulateListBox(RoomListBox, All.RoomRecipes);
                    // TODO Recipes
                    break;
                case MapsTabIndex:
                    // TODO Maps
                    break;
                case ScriptsTabIndex:
                    // TODO Scripts
                    break;
            }
        }

        /// <summary>
        /// Updates per-tab <see cref="Control"/>s when the <see cref="TabPage"/>s become visible.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void EditorTabs_SelectedIndexChanged(object sender, EventArgs e)
            => RepopulateVisibleControls();

        /// <summary>
        /// Populates the Games tab when a <see cref="GameModel"/> is selected in the GameListBox.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void GameListBox_SelectedValueChanged(object sender, EventArgs eventArguments)
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
        /// <param name="eventArguments">Ignored.</param>
        private void BlockListBox_SelectedValueChanged(object sender, EventArgs eventArguments)
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
        /// <param name="eventArguments">Ignored.</param>
        private void FloorListBox_SelectedValueChanged(object sender, EventArgs eventArguments)
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
        /// <param name="eventArguments">Ignored.</param>
        private void FurnishingListBox_SelectedValueChanged(object sender, EventArgs eventArguments)
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
        /// <param name="eventArguments">Ignored.</param>
        private void CollectibleListBox_SelectedValueChanged(object sender, EventArgs eventArguments)
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
        /// <param name="eventArguments">Ignored.</param>
        private void CharacterListBox_SelectedValueChanged(object sender, EventArgs eventArguments)
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
                CharacterStartingInventoryExample.Text = "0 Items";
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
                CharacterNativeBiomeComboBox.SelectedItem = All.BiomeRecipes.GetOrNull(model.NativeBiomeID);
                CharacterPrimaryBehaviorComboBox.SelectedItem = All.Scripts.GetOrNull(model.PrimaryBehaviorID);
                CharacterPronounComboBox.SelectedItem = model.PronounKey;
                CharacterStoryIDTextBox.Text = string.IsNullOrEmpty(model.StoryCharacterID) && Settings.Default.SuggestStoryIDs
                    ? $"{model.PersonalName.ToUpperInvariant()}_{model.FamilyName.ToUpperInvariant()}"
                    : model.StoryCharacterID;
                RepopulateListBox(CharacterStartingQuestsListBox, model.StartingQuestIDs
                                                                       .Select(id => All.Interactions.Get<InteractionModel>(id)));
                CharacterStartingDialogueComboBox.SelectedItem = ModelID.None == model.StartingDialogueID
                    ? null
                    : All.Interactions.Get<InteractionModel>(model.StartingDialogueID);
                CharacterStartingInventoryExample.Text = $"{model.StartingInventory?.ItemCount ?? 0} Items";
                PictureBoxLoadFromStorage(CharacterPictureBox, model.ID);
            }
        }

        /// <summary>
        /// Populates the Pronouns panel when a <see cref="PronounGroup"/> is selected in the CharacterPronounListBox.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void CharacterPronounListBox_SelectedIndexChanged(object sender, EventArgs eventArguments)
        {
            if (null == CharacterPronounListBox.SelectedItem)
            {
                CharacterPronounKeyExample.Text = PronounGroup.DefaultKey;
                CharacterPronounSubjectiveTextBox.Text = "";
                CharacterPronounObjectiveTextBox.Text = "";
                CharacterPronounDeterminerTextBox.Text = "";
                CharacterPronounPossessiveTextBox.Text = "";
                CharacterPronounReflexiveTextBox.Text = "";
            }
            else if (CharacterPronounListBox.SelectedItem is PronounGroup group
                     && null != group)
            {
                CharacterPronounKeyExample.Text = group.GetKey();
                CharacterPronounSubjectiveTextBox.Text = group.Subjective;
                CharacterPronounObjectiveTextBox.Text = group.Objective;
                CharacterPronounDeterminerTextBox.Text = group.Determiner;
                CharacterPronounPossessiveTextBox.Text = group.Possessive;
                CharacterPronounReflexiveTextBox.Text = group.Reflexive;
            }
        }

        /// <summary>
        /// Populates the Critters tab when a <see cref="CritterModel"/> is selected in the CritterListBox.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void CritterListBox_SelectedValueChanged(object sender, EventArgs eventArguments)
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
                CritterNativeBiomeComboBox.SelectedItem = All.BiomeRecipes.GetOrNull(model.NativeBiomeID);
                CritterPrimaryBehaviorComboBox.SelectedItem = All.Scripts.GetOrNull(model.PrimaryBehaviorID);
                PictureBoxLoadFromStorage(CritterPictureBox, model.ID);
            }
        }

        /// <summary>
        /// Populates the Items tab when a <see cref="ItemModel"/> is selected in the ItemListBox.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void ItemListBox_SelectedValueChanged(object sender, EventArgs eventArguments)
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
        /// <param name="eventArguments">Ignored.</param>
        private void BiomeListBox_SelectedValueChanged(object sender, EventArgs eventArguments)
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
        /// <param name="eventArguments">Ignored.</param>
        private void CraftingListBox_SelectedValueChanged(object sender, EventArgs eventArguments)
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
                CraftingPanelsCountExample.Text = $"0 Panels";
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
                CraftingPanelsCountExample.Text = $"{recipe.PanelPattern?.Count ?? 0} Panels";
                PictureBoxLoadFromStorage(CraftingPictureBox, recipe.ID);
            }
        }

        /// <summary>
        /// Populates the Room Recipes tab when a <see cref="RoomRecipe"/> is selected in the RoomListBox.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void RoomListBox_SelectedValueChanged(object sender, EventArgs eventArguments)
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
        /// <param name="eventArguments">Ignored.</param>
        private void ContentAlteredEventHandler(object sender, EventArgs eventArguments)
        {
            if (!(sender is Control alteredControl))
            {
                // Silently return if nothing was modified or if sender was not a Control.
                return;
            }
            var PropertyAccessor = GetPropertyAccessorForTabAndControl(EditorTabs.SelectedIndex, alteredControl);
            if (null == PropertyAccessor)
            {
                // Silently return if no model is selected or if the Control is unsupported.
                return;
            }

            if (alteredControl is TextBox textbox
                && string.Compare(textbox.Text,
                                  (string)EditableControls[typeof(TextBox)][textbox],
                                  comparisonType: StringComparison.OrdinalIgnoreCase) != 0)
            {
                ChangeManager.AddAndExecute(new ChangeValue(EditableControls[typeof(TextBox)][textbox], textbox.Text, textbox.Name,
                                            (object databaseValue) => { PropertyAccessor(databaseValue); HasUnsavedChanges = true; },
                                            (object displayValue) => textbox.Text = displayValue.ToString(),
                                            (object oldValue) => EditableControls[typeof(TextBox)][textbox] = oldValue));
            }
            else if (alteredControl is CheckBox checkbox
                     && checkbox.Checked != (bool?)EditableControls[typeof(CheckBox)][checkbox])
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

            // Update the model name representing the alteredControl if needed.
            if (ControlsWhoseContentIsListed.ContainsKey(alteredControl))
            {
                var listToUpdate = ControlsWhoseContentIsListed[alteredControl];
                listToUpdate.Items[listToUpdate.SelectedIndex] = listToUpdate.SelectedItem;
            }
        }

        #region Model Collection Adjustments
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
                MainToolStripStatusLabel.Text = Resources.ErrorMaximumIDReached;
                SystemSounds.Beep.Play();
                return;
            }

            var modelToAdd = inAllocateNewInstance(nextID);
            ChangeManager.AddAndExecute(new ChangeList(modelToAdd, $"add new {inModelTypeName} definition",
                                        (object databaseValue) =>
                                        {
                                            ((IMutableModelCollection<TModel>)inDatabaseCollection).Add((TModel)databaseValue);
                                            _ = inListBox.Items.Add(databaseValue);
                                            inListBox.SelectedItem = databaseValue;
                                            HasUnsavedChanges = true;
                                        },
                                        (object databaseValue) =>
                                        {
                                            ((IMutableModelCollection<TModel>)inDatabaseCollection).Remove((TModel)databaseValue);
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
                                            ((IMutableModelCollection<TModel>)inDatabaseCollection).Remove((TModel)databaseValue);
                                            inListBox.Items.Remove(databaseValue);
                                            inListBox.SelectedItem = null;
                                            HasUnsavedChanges = true;
                                        },
                                        (object databaseValue) =>
                                        {
                                            ((IMutableModelCollection<TModel>)inDatabaseCollection).Add((TModel)databaseValue);
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
            where TInterface : IMutableModel
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
                    MainToolStripStatusLabel.Text = string.Format(CultureInfo.CurrentCulture, Resources.WarningNotAddingDuplicate,
                                                                  nameof(ModelTag));
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
            where TInterface : IMutableModel
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
            where TInterface : IMutableModel
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
                    MainToolStripStatusLabel.Text = string.Format(CultureInfo.CurrentCulture, Resources.WarningNotAddingDuplicate,
                                                                  nameof(RecipeElement));
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
            where TInterface : IMutableModel
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

        #region Quest Adjustments
        /// <summary>
        /// Adds a new <see cref="ModelID"/> to the selected <see cref="CharacterModel"/>, updating the given <see cref="ListBox"/>.
        /// </summary>
        /// <param name="inAddsToListBox">The UI element reflectling the collection being changed.</param>
        /// <param name="inGetQuestListFromModel">The means, given a model, to find the correct ID collection.</param>
        private void AddQuest(ListBox inAddsToListBox, Func<IMutableCharacterModel, IList<ModelID>> inGetQuestListFromModel)
        {
            if (!All.CollectionsHaveBeenInitialized)
            {
                SystemSounds.Beep.Play();
                return;
            }

            if (GetSelectedModelForTab(EditorTabs.SelectedIndex) is IMutableCharacterModel character
                && AddQuestDialogue.ShowDialog() == DialogResult.OK)
            {
                if (inGetQuestListFromModel(character).Contains(AddQuestDialogue.ReturnNewQuestID))
                {
                    MainToolStripStatusLabel.Text = string.Format(CultureInfo.CurrentCulture, Resources.WarningNotAddingDuplicate,
                                                                  nameof(InteractionModel));
                    SystemSounds.Beep.Play();
                    return;
                }

                ChangeManager.AddAndExecute(new ChangeList(AddQuestDialogue.ReturnNewQuestID,
                                            $"add tag quest to {character.Name}",
                                            (object databaseValue) =>
                                            {
                                                inGetQuestListFromModel(character).Add((ModelID)databaseValue);
                                                _ = inAddsToListBox.Items.Add(databaseValue);
                                                inAddsToListBox.SelectedItem = databaseValue;
                                                HasUnsavedChanges = true;
                                            },
                                            (object databaseValue) =>
                                            {
                                                inGetQuestListFromModel(character).Remove((ModelID)databaseValue);
                                                inAddsToListBox.Items.Remove(databaseValue);
                                                inAddsToListBox.SelectedItem = null;
                                                HasUnsavedChanges = true;
                                            }));
            }
        }

        /// <summary>
        /// Removes the selected <see cref="ModelID"/> from the selected <see cref="CharacterModel"/>,
        /// updating the given <see cref="ListBox"/>.
        /// </summary>
        /// <param name="inAddsToListBox">The UI element reflectling the collection being changed.</param>
        /// <param name="inGetTagListFromModel">The means, given a Model, to find the correct ID collection.</param>
        private void RemoveQuest(ListBox inAddsToListBox, Func<IMutableCharacterModel, IList<ModelID>> inGetTagListFromModel)
        {
            if (!All.CollectionsHaveBeenInitialized || null == inAddsToListBox.SelectedItem)
            {
                SystemSounds.Beep.Play();
                return;
            }

            if (GetSelectedModelForTab(EditorTabs.SelectedIndex) is IMutableCharacterModel character)
            {
                ChangeManager.AddAndExecute(new ChangeList((ModelTag)inAddsToListBox.SelectedItem,
                                            $"remove tag {inAddsToListBox.SelectedItem} from {character.Name}",
                                            (object databaseValue) =>
                                            {
                                                inGetTagListFromModel(character).Remove((ModelID)databaseValue);
                                                inAddsToListBox.Items.Remove(databaseValue);
                                                inAddsToListBox.SelectedItem = null;
                                                HasUnsavedChanges = true;
                                            },
                                            (object databaseValue) =>
                                            {
                                                inGetTagListFromModel(character).Add((ModelID)databaseValue);
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
        /// <param name="eventArguments">Ignored.</param>
        private void GameAddNewGameButton_Click(object sender, EventArgs eventArguments)
            => AddNewModel(All.Games, (ModelID id) => new GameModel(id, "New Game", "", ""), All.GameIDs, GameListBox, "Game");

        /// <summary>
        /// Responds to the user clicking "Remove Game" on the Games tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void GameRemoveGameButton_Click(object sender, EventArgs eventArguments)
            => RemoveModel(All.Games, GameListBox, "Game");
        #endregion

        #region Blocks Tab
        /// <summary>
        /// Responds to the user clicking "Add New Block" on the Blocks tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void BlockAddNewBlockButton_Click(object sender, EventArgs eventArguments)
            => AddNewModel(All.Blocks, (ModelID id) => new BlockModel(id, "New Block", "", ""), All.BlockIDs, BlockListBox, "Block");

        /// <summary>
        /// Responds to the user clicking "Remove Block" on the Blocks tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void BlockRemoveBlockButton_Click(object sender, EventArgs eventArguments)
            => RemoveModel(All.Blocks, BlockListBox, "Block");

        /// <summary>
        /// Registers the user command to add a new biome tag to the current block.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void BlockAddBiomeTagButton_Click(object sender, EventArgs eventArguments)
            => AddTag(BlockAddsToBiomeListBox, (IMutableParquetModel model) => model.AddsToBiome);

        /// <summary>
        /// Registers the user command to remove the selected biome tag from the current block.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void BlockRemoveBiomeTagButton_Click(object sender, EventArgs eventArguments)
            => RemoveTag(BlockAddsToBiomeListBox, (IMutableParquetModel model) => model.AddsToBiome);

        /// <summary>
        /// Registers the user command to add a new room tag to the current block.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void BlockAddRoomTagButton_Click(object sender, EventArgs eventArguments)
            => AddTag(BlockAddsToRoomListBox, (IMutableParquetModel model) => model.AddsToRoom);

        /// <summary>
        /// Registers the user command to remove the selected room tag from the current block.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void BlockRemoveRoomTagButton_Click(object sender, EventArgs eventArguments)
            => RemoveTag(BlockAddsToRoomListBox, (IMutableParquetModel model) => model.AddsToRoom);
        #endregion

        #region Floors Tab
        /// <summary>
        /// Responds to the user clicking "Add New Floor" on the Floors tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void FloorAddNewFloorButton_Click(object sender, EventArgs eventArguments)
            => AddNewModel(All.Floors, (ModelID id) => new FloorModel(id, "New Floor", "", ""), All.FloorIDs, FloorListBox, "Floor");

        /// <summary>
        /// Responds to the user clicking "Remove Floor" on the Floors tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void FloorRemoveFloorButton_Click(object sender, EventArgs eventArguments)
            => RemoveModel(All.Floors, FloorListBox, "Floor");

        /// <summary>
        /// Registers the user command to add a new biome tag to the current floor.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void FloorAddBiomeTagButton_Click(object sender, EventArgs eventArguments)
            => AddTag(FloorAddsToBiomeListBox, (IMutableParquetModel model) => model.AddsToBiome);

        /// <summary>
        /// Registers the user command to remove the selected biome tag from the current floor.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void FloorRemoveBiomeTagButton_Click(object sender, EventArgs eventArguments)
            => RemoveTag(FloorAddsToBiomeListBox, (IMutableParquetModel model) => model.AddsToBiome);

        /// <summary>
        /// Registers the user command to add a new room tag to the current floor.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void FloorAddRoomTagButton_Click(object sender, EventArgs eventArguments)
            => AddTag(FloorAddsToRoomListBox, (IMutableParquetModel model) => model.AddsToRoom);

        /// <summary>
        /// Registers the user command to remove the selected room tag from the current floor.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void FloorRemoveRoomTagButton_Click(object sender, EventArgs eventArguments)
            => RemoveTag(FloorAddsToRoomListBox, (IMutableParquetModel model) => model.AddsToRoom);
        #endregion

        #region Furnishings Tab
        /// <summary>
        /// Responds to the user clicking "Add New Furnishing" on the Furnishings tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void FurnishingAddNewFurnishingButton_Click(object sender, EventArgs eventArguments)
            => AddNewModel(All.Furnishings, (ModelID id) => new FurnishingModel(id, "New Furnishing", "", ""),
                           All.FurnishingIDs, FurnishingListBox, "Furnishing");

        /// <summary>
        /// Responds to the user clicking "Remove Furnishing" on the Furnishings tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void FurnishingRemoveFurnishingButton_Click(object sender, EventArgs eventArguments)
            => RemoveModel(All.Furnishings, FurnishingListBox, "Furnishing");

        /// <summary>
        /// Registers the user command to add a new biome tag to the current furnishing.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void FurnishingAddBiomeTagButton_Click(object sender, EventArgs eventArguments)
            => AddTag(FurnishingAddsToBiomeListBox, (IMutableParquetModel model) => model.AddsToBiome);

        /// <summary>
        /// Registers the user command to remove the selected biome tag from the current furnishing.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void FurnishingRemoveBiomeTagButton_Click(object sender, EventArgs eventArguments)
            => RemoveTag(FurnishingAddsToBiomeListBox, (IMutableParquetModel model) => model.AddsToBiome);

        /// <summary>
        /// Registers the user command to add a new room tag to the current furnishing.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void FurnishingAddRoomTagButton_Click(object sender, EventArgs eventArguments)
            => AddTag(FurnishingAddsToRoomListBox, (IMutableParquetModel model) => model.AddsToRoom);

        /// <summary>
        /// Registers the user command to remove the selected room tag from the current furnishing.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void FurnishingRemoveRoomTagButton_Click(object sender, EventArgs eventArguments)
            => RemoveTag(FurnishingAddsToRoomListBox, (IMutableParquetModel model) => model.AddsToRoom);
        #endregion

        #region Collectibles Tab
        /// <summary>
        /// Responds to the user clicking "Add New Collectible" on the Collectibles tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void CollectibleAddNewCollectibleButton_Click(object sender, EventArgs eventArguments)
            => AddNewModel(All.Collectibles, (ModelID id) => new CollectibleModel(id, "New Collectible", "", ""),
                           All.CollectibleIDs, CollectibleListBox, "Collectible");

        /// <summary>
        /// Responds to the user clicking "Remove Collectible" on the Collectibles tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void CollectibleRemoveCollectibleButton_Click(object sender, EventArgs eventArguments)
            => RemoveModel(All.Collectibles, CollectibleListBox, "Collectible");

        /// <summary>
        /// Registers the user command to add a new biome tag to the current collectible.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void CollectibleAddBiomeTagButton_Click(object sender, EventArgs eventArguments)
            => AddTag(CollectibleAddsToBiomeListBox, (IMutableParquetModel model) => model.AddsToBiome);

        /// <summary>
        /// Registers the user command to remove the selected biome tag from the current collectible.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void CollectibleRemoveBiomeTagButton_Click(object sender, EventArgs eventArguments)
            => RemoveTag(CollectibleAddsToBiomeListBox, (IMutableParquetModel model) => model.AddsToBiome);

        /// <summary>
        /// Registers the user command to add a new room tag to the current collectible.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void CollectibleAddRoomTagButton_Click(object sender, EventArgs eventArguments)
            => AddTag(CollectibleAddsToRoomListBox, (IMutableParquetModel model) => model.AddsToRoom);

        /// <summary>
        /// Registers the user command to remove the selected room tag from the current collectible.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void CollectibleRemoveRoomTagButton_Click(object sender, EventArgs eventArguments)
            => RemoveTag(CollectibleAddsToRoomListBox, (IMutableParquetModel model) => model.AddsToRoom);
        #endregion

        #region Characters Tab
        /// <summary>
        /// Responds to the user clicking "Add New Character" on the Characters tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void CharacterAddNewCharacterButton_Click(object sender, EventArgs eventArguments)
            => AddNewModel(All.Characters, (ModelID id) => new CharacterModel(id, "New Character", "", ""), All.CharacterIDs, CharacterListBox, "Character");

        /// <summary>
        /// Responds to the user clicking "Remove Character" on the Characters tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void CharacterRemoveCharacterButton_Click(object sender, EventArgs eventArguments)
            => RemoveModel(All.Characters, CharacterListBox, "Character");

        /// <summary>
        /// Registers the user command to add a new quest to the current character.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void CharacterAddQuestButton_Click(object sender, EventArgs eventArguments)
            => AddQuest(CharacterStartingQuestsListBox, (IMutableCharacterModel model) => model.StartingQuestIDs);

        /// <summary>
        /// Registers the user command to remove the selected quest from the current character.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void CharacterRemoveQuestButton_Click(object sender, EventArgs eventArguments)
            => RemoveQuest(CollectibleAddsToBiomeListBox, (IMutableCharacterModel model) => model.StartingQuestIDs);

        /// <summary>
        /// Invokes the <see cref="InventoryEditorForm"/> for the currently selected <see cref="CharacterModel"/>.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void CharacterOpenInventoryEditorButton_Click(object sender, EventArgs eventArguments)
        {
            var currentCharacter = (CharacterModel)GetSelectedModelForTab(EditorTabs.SelectedIndex);
            InventoryEditorWindow.CurrentCharacter = currentCharacter;
            var result = InventoryEditorWindow.ShowDialog();
            if (result == DialogResult.OK)
            {
                CharacterStartingInventoryExample.Text = $"{currentCharacter.StartingInventory?.ItemCount ?? 0} Items";
            }
            else if (result == DialogResult.Abort)
            {
                MainToolStripStatusLabel.Text = Resources.WarningNothingSelected;
                SystemSounds.Beep.Play();
            }
        }

        /// <summary>
        /// Provides a suggested <see cref="CharacterModel.StoryCharacterID"/> if needed.
        /// </summary>
        /// <param name="sender">The <see cref="this.PersonalNameTextBox"/>.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void CharacterPersonalNameTextBox_TextChanged(object sender, EventArgs eventArguments)
        {
            if (Settings.Default.SuggestStoryIDs)
            {
                var model = (CharacterModel)GetSelectedModelForTab(EditorTabs.SelectedIndex);
                if (sender is TextBox alteredControl
                    && null != model
                    && string.IsNullOrEmpty(model.StoryCharacterID)
                    && !string.IsNullOrEmpty(model.FamilyName)
                    && !string.IsNullOrEmpty(alteredControl.Text))
                {
                    CharacterStoryIDTextBox.Text = ((IMutableCharacterModel)model).StoryCharacterID =
                        $"{alteredControl.Text.ToUpperInvariant()}_{model.FamilyName.ToUpperInvariant()}";
                }
            }
        }

        /// <summary>
        /// Provides a suggested <see cref="CharacterModel.StoryCharacterID"/> if needed.
        /// </summary>
        /// <param name="sender">The <see cref="this.FamilyNameTextBox"/>.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void CharacterFamilyNameTextBox_TextChanged(object sender, EventArgs eventArguments)
        {
            if (Settings.Default.SuggestStoryIDs)
            {
                var model = (CharacterModel)GetSelectedModelForTab(EditorTabs.SelectedIndex);
                if (sender is TextBox alteredControl
                    && null != model
                    && string.IsNullOrEmpty(model.StoryCharacterID)
                    && !string.IsNullOrEmpty(model.PersonalName)
                    && !string.IsNullOrEmpty(alteredControl.Text))
                {
                    CharacterStoryIDTextBox.Text = ((IMutableCharacterModel)model).StoryCharacterID =
                        $"{model.PersonalName.ToUpperInvariant()}_{alteredControl.Text.ToUpperInvariant()}";
                }
            }
        }

        /// <summary>
        /// Responds to the user clicking "Add New Pronoun Group" on the Characters tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void CharacterPronounAddNewPronoungGroupButton_Click(object sender, EventArgs eventArguments)
        {
            if (!All.CollectionsHaveBeenInitialized)
            {
                SystemSounds.Beep.Play();
                return;
            }

            var groupToAdd = new PronounGroup("-", "-", "-", "-", "-");
            ChangeManager.AddAndExecute(new ChangeList(groupToAdd, $"add new Pronoun Group definition",
                                        (object databaseValue) =>
                                        {
                                            ((ICollection<PronounGroup>)All.PronounGroups).Add((PronounGroup)databaseValue);
                                            _ = CharacterPronounListBox.Items.Add(databaseValue);
                                            CharacterPronounListBox.SelectedItem = databaseValue;
                                            HasUnsavedChanges = true;
                                        },
                                        (object databaseValue) =>
                                        {
                                            ((ICollection<PronounGroup>)All.PronounGroups).Remove((PronounGroup)databaseValue);
                                            CharacterPronounListBox.Items.Remove(databaseValue);
                                            CharacterPronounListBox.SelectedItem = null;
                                            HasUnsavedChanges = true;
                                        }));
        }

        /// <summary>
        /// Responds to the user clicking "Remove Pronoun Group" on the Characters tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void CharacterPronounRemovePronoungGroupButton_Click(object sender, EventArgs eventArguments)
        {
            if (!All.CollectionsHaveBeenInitialized || CharacterPronounListBox.SelectedIndex == -1)
            {
                SystemSounds.Beep.Play();
                return;
            }

            if (!(CharacterPronounListBox.SelectedItem is PronounGroup groupToRemove))
            {
                SystemSounds.Beep.Play();
                return;
            }

            ChangeManager.AddAndExecute(new ChangeList(groupToRemove, $"remove Pronoun Group {groupToRemove.GetKey()}",
                                        (object databaseValue) =>
                                        {
                                            ((ICollection<PronounGroup>)All.PronounGroups).Remove((PronounGroup)databaseValue);
                                            CharacterPronounListBox.Items.Remove(databaseValue);
                                            CharacterPronounListBox.SelectedItem = null;
                                            HasUnsavedChanges = true;
                                        },
                                        (object databaseValue) =>
                                        {
                                            ((ICollection<PronounGroup>)All.Characters).Add((PronounGroup)databaseValue);
                                            _ = CharacterPronounListBox.Items.Add(databaseValue);
                                            CharacterPronounListBox.SelectedItem = databaseValue;
                                            HasUnsavedChanges = true;
                                        }));
        }
        #endregion

        #region Critters Tab
        /// <summary>
        /// Responds to the user clicking "Add New Critter" on the Critters tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void CritterAddNewCritterButton_Click(object sender, EventArgs eventArguments)
            => AddNewModel(All.Critters, (ModelID id) => new CritterModel(id, "New Critter", "", ""), All.CritterIDs, CritterListBox, "Critter");

        /// <summary>
        /// Responds to the user clicking "Remove Critter" on the Critters tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void CritterRemoveCritterButton_Click(object sender, EventArgs eventArguments)
            => RemoveModel(All.Critters, CritterListBox, "Critter");
        #endregion

        #region Items Tab
        /// <summary>
        /// Responds to the user clicking "Add New Item" on the Items tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void ItemAddNewItemButton_Click(object sender, EventArgs eventArguments)
            => AddNewModel(All.Items, (ModelID id) => new ItemModel(id, "New Item", "", ""), All.ItemIDs, ItemListBox, "Item");

        /// <summary>
        /// Responds to the user clicking "Remove Item" on the Items tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void ItemRemoveItemButton_Click(object sender, EventArgs eventArguments)
            => RemoveModel(All.Items, ItemListBox, "Item");

        /// <summary>
        /// Registers the user command to add a new tag to the current item.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void ItemAddTagButton_Click(object sender, EventArgs eventArguments)
            => AddTag(ItemTagListBox, (IMutableItemModel model) => model.ItemTags);

        /// <summary>
        /// Registers the user command to remove the selected tag from the current item.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void ItemRemoveTagButton_Click(object sender, EventArgs eventArguments)
            => RemoveTag(ItemTagListBox, (IMutableItemModel model) => model.ItemTags);

        /// <summary>
        /// Invokes the <see cref="InventoryEditorForm"/> for the currently selected <see cref="CharacterModel"/>.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void ItemOpenInvetoryEditorButton_Click(object sender, EventArgs eventArguments)
        {
            var currentCharacter = (CharacterModel)ItemInventoryListBox.SelectedItem;
            InventoryEditorWindow.CurrentCharacter = currentCharacter;
            if (null == currentCharacter ||
                InventoryEditorWindow.ShowDialog() == DialogResult.Abort)
            {
                MainToolStripStatusLabel.Text = Resources.WarningNothingSelected;
                SystemSounds.Beep.Play();
            }
        }
        #endregion

        #region Biomes Tab
        /// <summary>
        /// Responds to the user clicking "Add New Biome" on the Biomes tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void BiomeAddNewBiomeButton_Click(object sender, EventArgs eventArguments)
            => AddNewModel(All.BiomeRecipes, (ModelID id) => new BiomeRecipe(id, "New Biome Recipe", "", ""), All.BiomeRecipeIDs, BiomeListBox, "Biome Recipe");

        /// <summary>
        /// Responds to the user clicking "Remove Biome" on the Biomes tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void BiomeRemoveBiomeButton_Click(object sender, EventArgs eventArguments)
            => RemoveModel(All.BiomeRecipes, BiomeListBox, "Room Recipe");

        /// <summary>
        /// Registers the user command to add a new parquet criterion tag to the current biome.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void BiomeAddParquetCriterionButton_Click(object sender, EventArgs eventArguments)
            => AddTag(BiomeParquetCriteriaListBox, (IMutableBiomeRecipe recipe) => recipe.ParquetCriteria);

        /// <summary>
        /// Registers the user command to remove the selected parquet criterion tag from the current biome.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void BiomeRemoveParquetCriterionButton_Click(object sender, EventArgs eventArguments)
            => RemoveTag(BiomeParquetCriteriaListBox, (IMutableBiomeRecipe recipe) => recipe.ParquetCriteria);

        /// <summary>
        /// Registers the user command to add a new entry requirement tag to the current biome.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void BiomeAddEntryRequirementButton_Click(object sender, EventArgs eventArguments)
            => AddTag(BiomeEntryRequirementsListBox, (IMutableBiomeRecipe recipe) => recipe.EntryRequirements);

        /// <summary>
        /// Registers the user command to remove the selected entry requirement tag from the current biome.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void BiomeRemoveEntryRequirementButton_Click(object sender, EventArgs eventArguments)
            => RemoveTag(BiomeEntryRequirementsListBox, (IMutableBiomeRecipe recipe) => recipe.EntryRequirements);
        #endregion

        #region Crafting Tab
        /// <summary>
        /// Responds to the user clicking "Add New Crafting Recipe" on the Crafts tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void CraftingAddNewCraftingButton_Click(object sender, EventArgs eventArguments)
            => AddNewModel(All.CraftingRecipes, (ModelID id) => new CraftingRecipe(id, "New Crafting Recipe", "", ""), All.CraftingRecipeIDs, CraftingListBox, "Crafting Recipe");

        /// <summary>
        /// Responds to the user clicking "Remove Crafting Recipe" on the Rooms tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void CraftingRemoveCraftingButton_Click(object sender, EventArgs eventArguments)
            => RemoveModel(All.CraftingRecipes, CraftingListBox, "Crafting Recipe");

        /// <summary>
        /// Registers the user command to add a new product to the current Crafting Recipe.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void CraftingAddProductButton_Click(object sender, EventArgs eventArguments)
            => AddRecipeElement(CraftingProductsListBox, (IMutableCraftingRecipe recipe) => recipe.Products);

        /// <summary>
        /// Registers the user command to remove the selected product from the current Crafting Recipe.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void CraftingRemoveProductButton_Click(object sender, EventArgs eventArguments)
            => RemoveRecipeElement(CraftingProductsListBox, (IMutableCraftingRecipe recipe) => recipe.Products);

        /// <summary>
        /// Registers the user command to add a new ingredient to the current Crafting Recipe.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void CraftingAddIngredientButton_Click(object sender, EventArgs eventArguments)
            => AddRecipeElement(CraftingIngredientsListBox, (IMutableCraftingRecipe recipe) => recipe.Ingredients);

        /// <summary>
        /// Registers the user command to remove the selected ingredient from the current Crafting Recipe.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void CraftingRemoveIngredientButton_Click(object sender, EventArgs eventArguments)
            => RemoveRecipeElement(CraftingIngredientsListBox, (IMutableCraftingRecipe recipe) => recipe.Ingredients);

        /// <summary>
        /// Invokes the <see cref="StrikePatternEditorForm"/> for the currently selected <see cref="CraftingRecipe"/>.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void CraftingOpenPatternEditorButton_Click(object sender, EventArgs eventArguments)
        {
            StrikePatternEditorWindow.CurrentCraft = (CraftingRecipe)GetSelectedModelForTab(EditorTabs.SelectedIndex);
            if (StrikePatternEditorWindow.ShowDialog() == DialogResult.Abort)
            {
                MainToolStripStatusLabel.Text = Resources.WarningNothingSelected;
                SystemSounds.Beep.Play();
            }
        }

        #endregion

        #region Rooms Tab
        /// <summary>
        /// Responds to the user clicking "Add New Room" on the Rooms tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void RoomAddNewRoomButton_Click(object sender, EventArgs eventArguments)
            => AddNewModel(All.RoomRecipes, (ModelID id) => new RoomRecipe(id, "New Room Recipe", "", ""), All.RoomRecipeIDs, RoomListBox, "Room Recipe");

        /// <summary>
        /// Responds to the user clicking "Remove Room" on the Rooms tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void RoomRemoveRoomButton_Click(object sender, EventArgs eventArguments)
            => RemoveModel(All.RoomRecipes, RoomListBox, "Room Recipe");

        /// <summary>
        /// Registers the user command to add a new Furnishing requirement to the current Room Recipe.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void RoomAddFurnishingButton_Click(object sender, EventArgs eventArguments)
            => AddRecipeElement(RoomRequiredFurnishingsListBox, (IMutableRoomRecipe recipe) => recipe.OptionallyRequiredFurnishings);

        /// <summary>
        /// Registers the user command to remove the selected Furnishing requirement from the current Room Recipe.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void RoomRemoveFurnishingButton_Click(object sender, EventArgs eventArguments)
            => RemoveRecipeElement(BiomeParquetCriteriaListBox, (IMutableRoomRecipe recipe) => recipe.OptionallyRequiredFurnishings);

        /// <summary>
        /// Registers the user command to add a new Floor requirement to the current Room Recipe.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void RoomAddFloorButton_Click(object sender, EventArgs eventArguments)
            => AddRecipeElement(RoomRequiredFurnishingsListBox, (IMutableRoomRecipe recipe) => recipe.OptionallyRequiredWalkableFloors);

        /// <summary>
        /// Registers the user command to remove the selected Floor requirement from the current Room Recipe.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void RoomRemoveFloorButton_Click(object sender, EventArgs eventArguments)
            => RemoveRecipeElement(BiomeParquetCriteriaListBox, (IMutableRoomRecipe recipe) => recipe.OptionallyRequiredWalkableFloors);

        /// <summary>
        /// Registers the user command to add a new Block requirement to the current Room Recipe.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void RoomAddBlockButton_Click(object sender, EventArgs eventArguments)
            => AddRecipeElement(RoomRequiredFurnishingsListBox, (IMutableRoomRecipe recipe) => recipe.OptionallyRequiredPerimeterBlocks);

        /// <summary>
        /// Registers the user command to remove the selected Block requirement from the current Room Recipe.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void RoomRemoveBlockButton_Click(object sender, EventArgs eventArguments)
            => RemoveRecipeElement(BiomeParquetCriteriaListBox, (IMutableRoomRecipe recipe) => recipe.OptionallyRequiredPerimeterBlocks);
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
        /// <param name="eventArguments">Addional event data.</param>
        private void NewToolStripMenuItem_Click(object sender, EventArgs eventArguments)
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
        /// <param name="eventArguments">Addional event data.</param>
        private void LoadToolStripMenuItem_Click(object sender, EventArgs eventArguments)
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
        /// <param name="eventArguments">Addional event data.</param>
        private void ReloadToolStripMenuItem_Click(object sender, EventArgs eventArguments)
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
        /// <param name="eventArguments">Addional event data.</param>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs eventArguments)
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
        /// <param name="eventArguments">Addional event data.</param>
        private void OpenProjectFolderToolStripMenuItem_Click(object sender, EventArgs eventArguments)
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
        /// <param name="eventArguments">Addional event data.</param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs eventArguments)
            => Close();

        /// <summary>
        /// Responds to a user selecting the "Undo" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Addional event data.</param>
        private void UndoToolStripMenuItem_Click(object sender, EventArgs eventArguments)
            => ChangeManager.Undo();

        /// <summary>
        /// Responds to a user selecting the "Redo" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Addional event data.</param>
        private void RedoToolStripMenuItem_Click(object sender, EventArgs eventArguments)
            => ChangeManager.Redo();

        /// <summary>
        /// Responds to a user selecting the "Cut" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Addional event data.</param>
        private void CutToolStripMenuItem_Click(object sender, EventArgs eventArguments)
            => throw new NotImplementedException();

        /// <summary>
        /// Responds to a user selecting the "Copy" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Addional event data.</param>
        private void CopyToolStripMenuItem_Click(object sender, EventArgs eventArguments)
            => throw new NotImplementedException();

        /// <summary>
        /// Responds to a user selecting the "Paste" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Addional event data.</param>
        private void PasteToolStripMenuItem_Click(object sender, EventArgs eventArguments)
            => throw new NotImplementedException();

        /// <summary>
        /// Responds to a user selecting the "Select All" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Addional event data.</param>
        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs eventArguments)
            => throw new NotImplementedException();

        /// <summary>
        /// Responds to a user selecting the "Check Map" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Addional event data.</param>
        private void CheckMapStripMenuItem_Click(object sender, EventArgs eventArguments)
            => throw new NotImplementedException();

        /// <summary>
        /// Responds to a user selecting the "List Naming Collisions" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Addional event data.</param>
        private void ListNameCollisionsStripMenuItem_Click(object sender, EventArgs eventArguments)
            => throw new NotImplementedException();

        /// <summary>
        /// Responds to a user selecting the "List ID Ranges" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Addional event data.</param>
        private void ListIDRangesToolStripMenuItem_Click(object sender, EventArgs eventArguments)
            => throw new NotImplementedException();

        /// <summary>
        /// Responds to a user selecting the "List Max IDs" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Addional event data.</param>
        private void ListMaxIDsToolStripMenuItem_Click(object sender, EventArgs eventArguments)
            => throw new NotImplementedException();

        /// <summary>
        /// Responds to a user selecting the "List Tags" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Addional event data.</param>
        private void ListTagsToolStripMenuItem_Click(object sender, EventArgs eventArguments)
            => throw new NotImplementedException();

        /// <summary>
        /// Responds to a user selecting the "Options" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Addional event data.</param>
        private void OptionsToolStripMenuItem_Click(object sender, EventArgs eventArguments)
        {
            oldTheme = Settings.Default.CurrentEditorTheme;
            OptionsDialogue.ShowDialog();
        }

        /// <summary>
        /// Responds to a user selecting the "Refresh Display" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Addional event data.</param>
        private void RefreshStripMenuItem_Click(object sender, EventArgs eventArguments)
        {
            UpdateDisplay();
            ApplyCurrentTheme();
        }

        /// <summary>
        /// Responds to a user selecting the "Scribe Help" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Addional event data.</param>
        private void ScribeHelpToolStripMenuItem_Click(object sender, EventArgs eventArguments)
            => throw new NotImplementedException();

        /// <summary>
        /// Responds to a user selecting the "Documentation" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Addional event data.</param>
        private void DocumentationToolStripMenuItem_Click(object sender, EventArgs eventArguments)
            => throw new NotImplementedException();

        /// <summary>
        /// Responds to a user selecting the "About" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Addional event data.</param>
        private void AboutMenuItem_Click(object sender, EventArgs eventArguments)
            => AboutDialogue.ShowDialog();

        /// <summary>
        /// Responds to a user selecting "Open Containing Folder" context menu item from a picture box.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Addional event data.</param>
        private void OpenContainingFolderMenuItem_Click(object sender, EventArgs eventArguments)
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
        /// <param name="eventArguments">Addional event data.</param>
        private void CopyID_Click(object sender, EventArgs eventArguments)
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

        /// <summary>
        /// Sets the state of menu items as the menu opens.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Addional event data.</param>
        private void ContextMenuStripForTextEntries_Opening(object sender, CancelEventArgs eventArguments)
        {
            if (sender is ContextMenuStrip stripWithControl
                && (SourceBox = new EditableBox(stripWithControl)).IsEditable)
            {
                ToolStripMenuItemContextPaste.Enabled = Clipboard.ContainsText();
                ToolStripMenuItemContextClear.Enabled =
                ToolStripMenuItemContextSelectAll.Enabled = SourceBox.Text.Length > 0;
                ToolStripMenuItemContextCut.Enabled =
                ToolStripMenuItemContextCopy.Enabled = SourceBox.SelectedText.Length > 0;
            }
            else
            {
                eventArguments.Cancel = true;
            }
        }

        /// <summary>
        /// Cuts the selected text from the currently active <see cref="TextBox"/> or <see cref="ComboBox"/>.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Addional event data.</param>
        private void ToolStripMenuItemContextCut_OnClick(object sender, EventArgs eventArguments)
            => ContentAlteredEventHandler(SourceBox?.Cut(), eventArguments);

        /// <summary>
        /// Copies the selected text from the currently active <see cref="TextBox"/> or <see cref="ComboBox"/>.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Addional event data.</param>
        private void ToolStripMenuItemContextCopy_OnClick(object sender, EventArgs eventArguments)
            => SourceBox?.Copy();

        /// <summary>
        /// Pastes text to the currently active <see cref="TextBox"/> or <see cref="ComboBox"/>.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Addional event data.</param>
        private void ToolStripMenuItemContextPaste_OnClick(object sender, EventArgs eventArguments)
            => ContentAlteredEventHandler(SourceBox?.Paste(), eventArguments);

        /// <summary>
        /// Clears all text from the currently active <see cref="TextBox"/> or <see cref="ComboBox"/>.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Addional event data.</param>
        private void ToolStripMenuItemContextClear_OnClick(object sender, EventArgs eventArguments)
            => ContentAlteredEventHandler(SourceBox?.ClearAll(), eventArguments);

        /// <summary>
        /// Selects all text in the currently active <see cref="TextBox"/> or <see cref="ComboBox"/>.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Addional event data.</param>
        private void ToolStripMenuItemContextSelectAll_OnClick(object sender, EventArgs eventArguments)
            => SourceBox?.SelectAll();
        #endregion

        #region Hybrid Events
        /// <summary>
        /// Spawns an external image editor with the image of the currently selected model.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Addional event data.</param>
        private void EditImageExternally(object sender, EventArgs eventArguments)
        {
            var id = GetSelectedModelIDForTab(EditorTabs.SelectedIndex);
            if (id != ModelID.None)
            {
                var imagePathAndFilename = Path.Combine(EditorCommands.GetGraphicsPathForModelID(id), $"{id}.png");
                if (!File.Exists(imagePathAndFilename))
                {
                    Resources.ImageNotFoundGraphic.Save(imagePathAndFilename, ImageFormat.Png);
                }
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
        /// <param name="eventArguments">Ignored.</param>
        private void PictureBoxReload_Click(object sender, EventArgs eventArguments)
            => PictureBoxLoadFromStorage(GetPictureBoxForTab(EditorTabs.SelectedIndex),
                                         GetSelectedModelIDForTab(EditorTabs.SelectedIndex));
        #endregion

        #region Quit Editor Event
        /// <summary>
        /// Intercepts events that would close the editor to double-check that this is desired.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Used to cancel the close event if it was not desired.</param>
        private void FormClosingEventHandler(object sender, FormClosingEventArgs eventArguments)
        {
            if (HasUnsavedChanges)
            {
                if (MessageBox.Show(Resources.WarningMessageExit,
                                    Resources.CaptionExitWarning,
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning) == DialogResult.No)
                {
                    eventArguments.Cancel = true;
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
