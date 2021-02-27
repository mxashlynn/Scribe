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
using System.Text;
using System.Windows.Forms;
using Parquet;
using Parquet.Beings;
using Parquet.Biomes;
using Parquet.Crafts;
using Parquet.Games;
using Parquet.Items;
using Parquet.Parquets;
using Parquet.Regions;
using Parquet.Rooms;
using Parquet.Scripts;
using Roller;
using Scribe.ChangeHistory;
using Scribe.Properties;

// TODO 1) [MAP] Update API to Parquet 0.4.
// TODO 2.1) [GLOBALIZATION] Make sure we are using ToString in an Ordinal way.
// TODO 2.2) [GLOBALIZATION] Make sure we are using String.Compare(OrdinalCaseInsensitive) wherever needed.
// TODO 3) [UI] [TAGS] Add missing UI to adjust tags for each type of model.
// TODO 4) [UI] [TAGS] Add missing UI to adjust flavor tags for each type of model.


namespace Scribe.Forms
{
    /// <summary>
    /// The primary editing interface.
    /// </summary>
    public partial class MainEditorForm : Form
    {
        #region Roller Dependency
        /// <summary>Full command to invoke Roller.</summary>
        // [ROLLER] [UI] Add option to specify Roller's path from the options menu.
        internal static string RollerCommand { get; } = Path.Combine(GetRollerFullPath(), "roller.exe");

        /// <summary>
        /// Finds the location of the Roller command line app on the user's system.
        /// - If Scribe is compiled in debug mode, the bin directory from within the Roller project is used.
        /// - If Roller can be found by Windows, the path Windows supplied is used.
        /// - If Roller cannot be found, the current directory is used.
        /// </summary>
        /// <returns>The location of the Roller command line tool.</returns>
        private static string GetRollerFullPath()
        {
            if (ScribeProgram.IsDebugMode)
            {
                // Return the binary executable directory from the compiled Roller project.
                Logger.Log(LogLevel.Debug, Resources.LogGetDebugBuild);
                return Path.GetFullPath($"{Directory.GetCurrentDirectory()}/../../../../Roller/bin/Debug/net5.0");
            }
            else
            {
                try
                {
                    // Ask Windows to find roller using the 'where' command.
                    Logger.Log(LogLevel.Debug, nameof(GetRollerFullPath));
                    using var whereProcess = new Process();
                    whereProcess.StartInfo.UseShellExecute = false;
                    whereProcess.StartInfo.CreateNoWindow = true;
                    whereProcess.StartInfo.FileName = "where";
                    whereProcess.StartInfo.Arguments = "roller";
                    whereProcess.StartInfo.RedirectStandardOutput = true;
                    whereProcess.Start();

                    var output = whereProcess.StandardOutput.ReadToEnd();
                    whereProcess.WaitForExit();

                    var exitCode = (ExitCode)whereProcess.ExitCode;
                    return exitCode == ExitCode.Success
                        ? output.Substring(0, output.IndexOf(Environment.NewLine, StringComparison.OrdinalIgnoreCase))
                        : Path.GetFullPath(Directory.GetCurrentDirectory());
                }
                catch (Win32Exception)
                {
                    // Fall back to the current directory.
                    Logger.Log(LogLevel.Debug, nameof(Directory.GetCurrentDirectory));
                    return Path.GetFullPath(Directory.GetCurrentDirectory());
                }
            }
        }

        /// <summary>
        /// Executes the Roller companion command line app, and displays its output.
        /// </summary>
        /// <param name="inRollerArguments">The arguments to supply to Roller.</param>
        private void RunRoller(string inRollerArguments)
        {
            try
            {
                var inputText = $"roller {inRollerArguments}";
                Logger.Log(LogLevel.Info, inputText);

                using var rollerProcess = new Process();
                rollerProcess.StartInfo.UseShellExecute = false;
                rollerProcess.StartInfo.CreateNoWindow = true;
                rollerProcess.StartInfo.RedirectStandardOutput = true;
                rollerProcess.StartInfo.FileName = RollerCommand;
                rollerProcess.StartInfo.Arguments = inRollerArguments;
                rollerProcess.StartInfo.WorkingDirectory = All.ProjectDirectory;
                rollerProcess.Start();

                var output = rollerProcess.StandardOutput.ReadToEnd();
                rollerProcess.WaitForExit();

                var exitCode = (ExitCode)rollerProcess.ExitCode;
                var resultsText = exitCode == ExitCode.Success
                    ? output
                    : exitCode.ToStatusMessage();
                RollerResultsBox.TextOnDisplay = $"{inputText}{Environment.NewLine}{resultsText}";
                RollerResultsBox.ShowDialog();
            }
            catch (Win32Exception winException)
            {
                Logger.Log(LogLevel.Error, string.Format(CultureInfo.CurrentCulture, Resources.ErrorAccessingRoller,
                                                         winException.Message), winException);
            }
        }
        #endregion

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

        /// <summary>Dialogue displaying the results of a roller command.</summary>
        private readonly RollerOutputBox RollerResultsBox = new RollerOutputBox();
        #endregion

        #region Logging
        /// <summary>Logs messages to file and presents them to the user when necessary.</summary>
        private LoggerUI UILogger { get; init; }

        /// <summary>Clears the status text as needed from the <see cref="ToolStrip"/>.</summary>
        private readonly Timer ClearStatusTimer = new Timer();
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
        /// end states are indistinguishable and the <see cref="ChangeManager"/> should not consider this a <see cref="Change"/>.
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
                        Logger.Log(LogLevel.Info, Resources.LogAutoSaving);
                        if (EditorCommands.SaveDataFiles())
                        {
                            _hasUnsavedChanges = false;
                            UpdateDisplay();
                        }
                        else
                        {
                            SystemSounds.Beep.Play();
                            Logger.Log(LogLevel.Warning, Resources.ErrorSaveFailed);
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

            #region Logging
            UILogger = new LoggerUI(new StreamWriter("scribe.log", false, new UTF8Encoding(true, true)),
                                    MainToolStripStatusLabel);
            Logger.SetLogger(UILogger);
            Logger.Log(LogLevel.Info, Resources.LogScribeOpening);

            ClearStatusTimer.Interval = 30000;
            ClearStatusTimer.Tick += ClearStatusTimer_Tick;
            ClearStatusTimer.Stop();
            MainToolStripStatusLabel.TextChanged += MainToolStripStatusLabel_TextChanged;
            #endregion

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
                [CharacterPersonalNameTextBox] = CharacterListBox,
                [CharacterFamilyNameTextBox] = CharacterListBox,
                [CharacterPronounSubjectiveTextBox] = CharacterPronounListBox,
                [CharacterPronounObjectiveTextBox] = CharacterPronounListBox,
                [CharacterPronounDeterminerTextBox] = CharacterPronounListBox,
                [CharacterPronounPossessiveTextBox] = CharacterPronounListBox,
                [CharacterPronounReflexiveTextBox] = CharacterPronounListBox,
                [ItemNameTextBox] = ItemListBox,
                [BiomeNameTextBox] = BiomeListBox,
                [CraftingNameTextBox] = CraftingListBox,
                [RoomNameTextBox] = RoomListBox,
                [MapNameTextBox] = MapListBox,
                // TODO [SCRIPTS] [UI] Add Scripts tab to ControlsWhoseContentIsListed.
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
                Logger.Log(LogLevel.Error, string.Format(CultureInfo.CurrentCulture, Resources.ErrorParseFailed,
                                                           nameof(Settings.Default.CurrentEditorTheme)));
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
            // NOTE: Currently the progress bar doesn't do anything.
            // If any task ever becomes slow or blocks the GUI thread, it should be implemented.
            Logger.Log(LogLevel.Info, Resources.LogReady);
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
            themed[typeof(ToolStripItem)].AddRange(ContextMenuStripIDStatics.Items.GetAllChildren());
            themed[typeof(GroupBox)].AddRange(this.GetAllChildrenExactlyOfType<GroupBox>()
                                    .Where(groupBox => groupBox.Tag is null || !groupBox.Tag.ToString().Contains(UnthemedControl)));
            themed[typeof(ListBox)].AddRange(this.GetAllChildrenExactlyOfType<ListBox>()
                                    .Where(listbox => listbox.Tag is null || !listbox.Tag.ToString().Contains(UnthemedControl)));
            themed[typeof(ComboBox)].AddRange(this.GetAllChildrenExactlyOfType<ComboBox>()
                                    .Where(combobox => combobox.Tag is null || !combobox.Tag.ToString().Contains(UnthemedControl)));
            themed[typeof(TextBox)].AddRange(this.GetAllChildrenExactlyOfType<TextBox>()
                                    .Where(textbox => textbox.Tag is null || !textbox.Tag.ToString().Contains(UnthemedControl)));
            themed[typeof(Label)].AddRange(this.GetAllChildrenExactlyOfType<Label>()
                                    .Where(label => label.Tag is not null && label.Tag.ToString().Contains(ThemedLabel)));
            themed[typeof(Button)].AddRange(this.GetAllChildrenExactlyOfType<Button>()
                                    .Where(button => button.Tag is null || !button.Tag.ToString().Contains(UnthemedControl)));
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

            editables[typeof(ListBox)].CacheControlsWithText(EditorTabs.GetAllChildrenExactlyOfType<ListBox>()
                                      .Where(listbox => null == listbox.Tag || !listbox.Tag.ToString().Contains(UntrackedControl))
                                      .Cast<Control>());
            editables[typeof(ComboBox)].CacheControlsWithText(EditorTabs.GetAllChildrenExactlyOfType<ComboBox>()
                                       .Where(combobox => null == combobox.Tag || !combobox.Tag.ToString().Contains(UntrackedControl))
                                       .Cast<Control>());
            editables[typeof(TextBox)].CacheControlsWithText(EditorTabs.GetAllChildrenExactlyOfType<TextBox>()
                                      .Where(textbox => null == textbox.Tag || !textbox.Tag.ToString().Contains(UntrackedControl))
                                      .Cast<Control>());
            editables[typeof(CheckBox)].CacheCheckBoxes(EditorTabs.GetAllChildrenExactlyOfType<CheckBox>()
                                       .Where(checkbox => null == checkbox.Tag || !checkbox.Tag.ToString().Contains(UntrackedControl))
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
        /// Transforms an <c>object</c> into a <c>double</c>, parsing if needed.
        /// </summary>
        /// <param name="input">A boxed <c>double</c> or a <c>string</c> representing a <c>double</c>.</param>
        /// <returns>The integer value given, or 0.0 if no value could be parsed.</returns>
        private static double ValueToDouble(object input)
            => input as double?
            ?? (double.TryParse(input?.ToString() ?? "", NumberStyles.Number, null, out var parsedDouble)
                ? parsedDouble
                : 0.0);

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
        /// Given the index of an editor tab, return the Roller argument corresponding to the content it edits.
        /// </summary>
        /// <param name="inTabIndex">The index of the tab sought.</param>
        /// <returns>The argument corresponding to the tab.</returns>
        private static string GetRollerArgumentForTab(int inTabIndex)
            => inTabIndex switch
            {
                GamesTabIndex => "all",
                BlocksTabIndex => "blocks",
                FloorsTabIndex => "floors",
                FurnishingsTabIndex => "furnishings",
                CollectiblesTabIndex => "collectibles",
                CharactersTabIndex => "characters",
                CrittersTabIndex => "critters",
                ItemsTabIndex => "items",
                BiomeRecipesTabIndex => "biomes",
                CraftingRecipesTabIndex => "crafts",
                RoomRecipesTabIndex => "rooms",
                MapsTabIndex => "maps",
                ScriptsTabIndex => "", // TODO [SCRIPTS] [ROLLER] Add Games and Scripts categories to Roller.
                _ => "",
            };

        /// <summary>
        /// Given the index of an editor tab, return the <see cref="PictureBox"/> for the content it edits.
        /// </summary>
        /// <param name="inTabIndex">The index of the tab sought.</param>
        /// <returns>The PictureBox instance.</returns>
        private PictureBox GetPictureBoxForTab(int inTabIndex)
            => inTabIndex switch
            {
                GamesTabIndex => GameIconPixelBox,
                BlocksTabIndex => BlockPixelBox,
                FloorsTabIndex => FloorDugOutPixelBox,
                FurnishingsTabIndex => FurnishingPixelBox,
                CollectiblesTabIndex => CollectiblePixelBox,
                CharactersTabIndex => CharacterPixelBox,
                CrittersTabIndex => CritterPixelBox,
                ItemsTabIndex => ItemPixelBox,
                BiomeRecipesTabIndex => BiomePixelBox,
                CraftingRecipesTabIndex => CraftingPixelBox,
                RoomRecipesTabIndex => RoomPixelBox,
                MapsTabIndex => MapPixelBox,
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
                MapsTabIndex => (MapListBox.SelectedItem as RegionModel)?.ID ?? ModelID.None,
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
                MapsTabIndex => (RegionModel)MapListBox.SelectedItem,
                ScriptsTabIndex => throw new NotImplementedException(),
                _ => null,
            };

        /// <summary>Given the index of an editor tab and an editor <see cref="Control"/>, return the corresponding property accessor.</summary>
        /// <param name="inTabIndex">The index of an editor tab.</param>
        /// <param name="inControl">The <see cref="Control"/> corresponding to the property sought.</param>
        /// <returns>A method for editing the property's value, or <c>null</c> if the input combination is not defined.</returns>
        private Action<object> GetPropertyAccessorForTabAndControl(int inTabIndex, Control inControl)
            => inControl is null
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
                    => (input) => BiomeConfiguration.LandThresholdFactor = ValueToDouble(input),
                (BiomeRecipesTabIndex, "BiomeLiquidThresholdFactorTextBox")
                    => (input) => BiomeConfiguration.LiquidThresholdFactor = ValueToDouble(input),
                (BiomeRecipesTabIndex, "BiomeRoomThresholdFactorTextBox")
                    => (input) => BiomeConfiguration.RoomThresholdFactor = ValueToDouble(input),

                (CraftingRecipesTabIndex, "CraftingMinIngredientCountTextBox")
                    => (input) => CraftConfiguration.IngredientCount = new Range<int>(ValueToInt(input), CraftConfiguration.IngredientCount.Maximum),
                (CraftingRecipesTabIndex, "CraftingMaxIngredientCountTextBox")
                    => (input) => CraftConfiguration.IngredientCount = new Range<int>(CraftConfiguration.ProductCount.Minimum, ValueToInt(input)),
                (CraftingRecipesTabIndex, "CraftingMinProductCountTextBox")
                    => (input) => CraftConfiguration.ProductCount = new Range<int>(ValueToInt(input), CraftConfiguration.ProductCount.Maximum),
                (CraftingRecipesTabIndex, "CraftingMaxProductCountTextBox")
                    => (input) => CraftConfiguration.ProductCount = new Range<int>(CraftConfiguration.ProductCount.Minimum, ValueToInt(input)),

                (RoomRecipesTabIndex, "RoomMinWalkableSpacesTextBox")
                    => (input) => RoomConfiguration.MinWalkableSpaces = ValueToInt(input),
                (RoomRecipesTabIndex, "RoomMaxWalkableSpacesTextBox")
                    => (input) => RoomConfiguration.MaxWalkableSpaces = ValueToInt(input),
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
        private static Action<object> GetPropertyAccessorForModelAndTabAndControl(Model inModel, int inTabIndex, Control inControl)
            => inModel is null
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
                (FloorsTabIndex, "FloorEquivalentItemComboBox")
                    => (input) => ((IMutableFloorModel)inModel).ItemID = ValueToID(input),
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
                (CharactersTabIndex, "CharacterPersonalNameTextBox")
                    => (input) => ((IMutableCharacterModel)inModel).PersonalName = input.ToString(),
                (CharactersTabIndex, "CharacterFamilyNameTextBox")
                    => (input) => ((IMutableCharacterModel)inModel).FamilyName = input.ToString(),
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
                    => (input) => ((IMutableItemModel)inModel).Tags.ToList().Add((ModelTag)input),
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
                (BiomeRecipesTabIndex, "BiomeParquetCriteriaTextBox")
                    => (input) => ((IMutableBiomeRecipe)inModel).ParquetCriteria = input.ToString(),
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
                /* TODO [MAP] Set up GetPropertyAccessor for Maps tab.
                (MapsTabIndex, "MapNameTextBox")
                    => (input) => ((IMutableMapRecipe)inModel).Name = input.ToString(),
                (MapsTabIndex, "MapDescriptionTextBox")
                    => (input) => ((IMutableMapRecipe)inModel).Description = input.ToString(),
                (MapsTabIndex, "MapCommentTextBox")
                    => (input) => ((IMutableMapRecipe)inModel).Comment = input.ToString(),
                (MapsTabIndex, "MapBackgroundColorStatic")
                    => (input) => ((IMutableMapRecipe)inModel).BackgroundColor = ValueToColorHexString(input),
                (MapsTabIndex, "MapExitNorthComboBox")
                    => (input) => ((IMutableMapRecipe)inModel).RegionToTheNorth = ValueToID(input),
                (MapsTabIndex, "MapExitSouthComboBox")
                    => (input) => ((IMutableMapRecipe)inModel).RegionToTheSouth = ValueToID(input),
                (MapsTabIndex, "MapExitEastComboBox")
                    => (input) => ((IMutableMapRecipe)inModel).RegionToTheEast = ValueToID(input),
                (MapsTabIndex, "MapExitWestComboBox")
                    => (input) => ((IMutableMapRecipe)inModel).RegionToTheWest = ValueToID(input),
                (MapsTabIndex, "MapExitUpComboBox")
                    => (input) => ((IMutableMapRecipe)inModel).RegionToTheAbove = ValueToID(input),
                (MapsTabIndex, "MapExitDownComboBox")
                    => (input) => ((IMutableMapRecipe)inModel).RegionToTheBelow = ValueToID(input),
                */
                #endregion

                #region Scripting
                // TODO [SCRIPTS] Set up GetPropertyAccessor for Scripts tab.
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
            if (GetSelectedModelForTab(EditorTabs.SelectedIndex) is null)
            {
                var selectedListBox = GetPrimaryListBoxForTab(EditorTabs.SelectedIndex);
                if (selectedListBox is not null)
                {
                    selectedListBox.SelectedItem = selectedListBox.Items.Cast<Model>().ElementAtOrDefault(0);
                }
            }
            #endregion
        }

        /// <summary>
        /// Occurs whenever a <see cref="MainToolStripStatusLabel"/> needs to be painted.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Used to draw the separator.</param>
        private void MainToolStripStatusLabel_TextChanged(object sender, EventArgs eventArguments)
        {
            // Paints manually so that the label has the correct theme color.
            // TODO [UI] Verify that EditorStatusStrip.Update is actually needed on StripLabel_TextChanged.
            // EditorStatusStrip.Update();

            // Also restarts the text-clearing timer.
            if (sender is ToolStripStatusLabel statusLabel
                && !string.IsNullOrEmpty(statusLabel.Text)
                // TODO [GLOBALIZATION] Make sure we are using String.Compate(Ordinal) or whichever is appropriate in this instance.
                && statusLabel.Text.CompareTo(Resources.LogReady) != 0)
            {
                ClearStatusTimer.Stop();
                ClearStatusTimer.Start();
            }
        }

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
            FileFormatPrimaryDelimiterStatic.Text = Delimiters.PrimaryDelimiter;
            FileFormatSecondaryDelimiterStatic.Text = Delimiters.SecondaryDelimiter;
            FileFormatInternalDelimiterStatic.Text = Delimiters.InternalDelimiter;
            FileFormatElementDelimiterStatic.Text = Delimiters.ElementDelimiter;
            FileFormatNameDelimiterStatic.Text = Delimiters.NameDelimiter;
            FileFormatPronounDelimiterStatic.Text = Delimiters.PronounDelimiter;
            FileFormatDimensionalDelimiterStatic.Text = Delimiters.DimensionalDelimiter;
            FileFormatDimensionalTerminatorStatic.Text = Delimiters.DimensionalTerminator;
        }

        /// <summary>
        /// Sets the text used to describe the library the editor supports.
        /// </summary>
        private void UpdateLibraryDataDisplay()
        {
            LibraryVersionStatic.Text = Parquet.AssemblyInfo.LibraryVersion;
            LibraryProjectPathStatic.Text = All.ProjectDirectory;
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
                if (nonNullCheckbox is not null)
                {
                    nonNullCheckbox.Checked = false;
                }
            }
            foreach (var combobox in EditableControls[typeof(ComboBox)])
            {
                var nonNullCombobox = (ComboBox)combobox.Key;
                if (nonNullCombobox is not null)
                {
                    nonNullCombobox.SelectedItem = null;
                    nonNullCombobox.Items.Clear();
                }
            }
            foreach (var listbox in EditableControls[typeof(ListBox)])
            {
                var nonNullListbox = (ListBox)listbox.Key;
                if (nonNullListbox is not null)
                {
                    nonNullListbox.SelectedItem = null;
                    nonNullListbox.Items.Clear();
                }
            }

            foreach (var picturebox in PictureBoxes)
            {
                if (picturebox is not null)
                {
                    picturebox.Image?.Dispose();
                    picturebox.Image = Resources.ImageNotFound;
                    picturebox.Update();
                }
            }
            #endregion

            RepopulateVisibleControls();
        }

        /// <summary>
        /// Repopulates the given list box with the given collection of <see cref="object"/>s.
        /// </summary>
        /// <param name="inListBox">The UI to repopulate.</param>
        /// <param name="inSource">The objects to populate the UI with.</param>
        /// <remarks>This should only be called if <see cref="All"/> has actually changed.</remarks>
        private static void RepopulateListBox(ListBox inListBox, IEnumerable<Model> inSource)
        {
            if (inSource is not null)
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
        private static void RepopulateListBox(ListBox inListBox, IEnumerable<object> inSource)
        {
            if (inSource is not null)
            {
                inListBox.SelectedItem = null;
                inListBox.BeginUpdate();
                inListBox.Items.Clear();
                // Ignore any input value that evaluates to "None".
                inListBox.Items.AddRange(inSource.Where(value => value is not null
                                                               && 0 != string.Compare(value.ToString(),
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
        private static void RepopulateComboBox(ComboBox inComboBox, IEnumerable<object> inSource)
        {
            if (inSource is not null)
            {
                inComboBox.SelectedItem = null;
                inComboBox.BeginUpdate();
                inComboBox.Items.Clear();
                // Ignore any input value that evaluates to "None".
                inComboBox.Items.AddRange(inSource.Where(value => value is not null
                                                               && 0 != string.Compare(value.ToString(),
                                                                                     nameof(ModelID.None),
                                                                                     comparisonType: StringComparison.OrdinalIgnoreCase))
                                                 .ToArray());
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
        private static void PictureBoxLoadFromStorage(PictureBox inPictureBox, ModelID inID)
        {
            var imagePathAndFilename = Path.Combine(EditorCommands.GetGraphicsPathForModelID(inID), $"{inID}.png");
            if (File.Exists(imagePathAndFilename))
            {
                using var imageStream = new MemoryStream(File.ReadAllBytes(imagePathAndFilename));
                inPictureBox.Image = Image.FromStream(imageStream);
            }
            else
            {
                inPictureBox.Image = Resources.ImageNotFound;
            }
        }

        /// <summary>
        /// Updates only those <see cref="Control"/>s that are on the currently selected <see cref="TabPage"/>.
        /// </summary>
        private void RepopulateVisibleControls()
        {
            switch (EditorTabs.SelectedIndex)
            {
                case GamesTabIndex:
                    RepopulateListBox(GameListBox, All.Games);
                    RepopulateComboBox(GamePlayerCharacterComboBox, All.Characters);
                    RepopulateComboBox(GameFirstScriptComboBox, All.Scripts);
                    break;
                case FloorsTabIndex:
                    RepopulateListBox(FloorListBox, All.Floors);
                    RepopulateComboBox(FloorEquivalentItemComboBox, All.Items);
                    RepopulateComboBox(FloorModificationToolComboBox, Enumerable.Cast<object>(Enum.GetValues(typeof(ModificationTool))));
                    break;
                case BlocksTabIndex:
                    RepopulateListBox(BlockListBox, All.Blocks);
                    RepopulateComboBox(BlockEquivalentItemComboBox, All.Items);
                    RepopulateComboBox(BlockGatherToolComboBox, Enumerable.Cast<object>(Enum.GetValues(typeof(GatheringTool))));
                    RepopulateComboBox(BlockGatherEffectComboBox, Enumerable.Cast<object>(Enum.GetValues(typeof(GatheringEffect))));
                    RepopulateComboBox(BlockDroppedCollectibleIDComboBox, All.Collectibles);
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
                    RepopulateComboBox(CharacterPronounComboBox, All.PronounGroups.Select(pronounGroup => pronounGroup.Key));
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
                    BiomeLandThresholdTextBox.Text = BiomeConfiguration.LandThresholdFactor.ToString();
                    BiomeLiquidThresholdFactorTextBox.Text = BiomeConfiguration.LiquidThresholdFactor.ToString();
                    BiomeRoomThresholdFactorTextBox.Text = BiomeConfiguration.RoomThresholdFactor.ToString();
                    break;
                case CraftingRecipesTabIndex:
                    RepopulateListBox(CraftingListBox, All.CraftingRecipes);
                    CraftingMinIngredientCountTextBox.Text = CraftConfiguration.IngredientCount.Minimum.ToString();
                    CraftingMaxIngredientCountTextBox.Text = CraftConfiguration.IngredientCount.Maximum.ToString();
                    CraftingMinProductCountTextBox.Text = CraftConfiguration.ProductCount.Minimum.ToString();
                    CraftingMaxProductCountTextBox.Text = CraftConfiguration.ProductCount.Maximum.ToString();
                    break;
                case RoomRecipesTabIndex:
                    RepopulateListBox(RoomListBox, All.RoomRecipes);
                    RoomMinWalkableSpacesTextBox.Text = RoomConfiguration.MinWalkableSpaces.ToString();
                    RoomMaxWalkableSpacesTextBox.Text = RoomConfiguration.MaxWalkableSpaces.ToString();
                    break;
                case MapsTabIndex:
                    RepopulateListBox(MapListBox, All.RegionModels);
                    RepopulateComboBox(MapExitNorthComboBox, All.RegionModels);
                    RepopulateComboBox(MapExitSouthComboBox, All.RegionModels);
                    RepopulateComboBox(MapExitEastComboBox, All.RegionModels);
                    RepopulateComboBox(MapExitWestComboBox, All.RegionModels);
                    RepopulateComboBox(MapExitUpComboBox, All.RegionModels);
                    RepopulateComboBox(MapExitDownComboBox, All.RegionModels);
                    break;
                case ScriptsTabIndex:
                    // TODO [SCRIPTS] [UI] Add scripts tab to RepopulateVisibleControls
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
            if (GameListBox.SelectedItem is null)
            {
                GameIDStatic.Text = ModelID.None.ToString();
                GameNameTextBox.Text = "";
                GameDescriptionTextBox.Text = "";
                GameCommentTextBox.Text = "";
                GameIsEpisodeCheckBox.Checked = false;
                GameEpisodeTitleTextBox.Text = "";
                GameEpisodeNumberTextBox.Text = "";
                GamePlayerCharacterComboBox.SelectedItem = null;
                GameFirstScriptComboBox.SelectedItem = null;
                GameIconPixelBox.Image = Resources.ImageNotFound;
            }
            else if (GameListBox.SelectedItem is GameModel model
                    && model is not null)
            {
                GameIDStatic.Text = model.ID.ToString();
                GameNameTextBox.Text = model.Name;
                GameDescriptionTextBox.Text = model.Description;
                GameCommentTextBox.Text = model.Comment;
                GameIsEpisodeCheckBox.Checked = model.IsEpisode;
                GameEpisodeTitleTextBox.Text = model.EpisodeTitle;
                GameEpisodeNumberTextBox.Text = model.EpisodeNumber.ToString();
                GamePlayerCharacterComboBox.SelectedItem = model.PlayerCharacterID == ModelID.None
                    ? null
                    : All.Characters.GetOrNull<CharacterModel>(model.PlayerCharacterID);
                GameFirstScriptComboBox.SelectedItem = model.FirstScriptID == ModelID.None
                    ? null
                    : All.Scripts.GetOrNull<ScriptModel>(model.FirstScriptID);
                PictureBoxLoadFromStorage(GameIconPixelBox, model.ID);
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
            if (BlockListBox.SelectedItem is null)
            {
                BlockIDStatic.Text = ModelID.None.ToString();
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
                BlockPixelBox.Image = Resources.ImageNotFound;
            }
            else if (BlockListBox.SelectedItem is BlockModel model
                    && model is not null)
            {
                BlockIDStatic.Text = model.ID.ToString();
                BlockNameTextBox.Text = model.Name;
                BlockDescriptionTextBox.Text = model.Description;
                BlockCommentTextBox.Text = model.Comment;
                BlockEquivalentItemComboBox.SelectedItem = model.ItemID == ModelID.None
                    ? null
                    : All.Items.GetOrNull<ItemModel>(model.ItemID);
                RepopulateListBox(BlockAddsToBiomeListBox, model.AddsToBiome);
                RepopulateListBox(BlockAddsToRoomListBox, model.AddsToRoom);
                BlockGatherToolComboBox.SelectedItem = model.GatherTool;
                BlockGatherEffectComboBox.SelectedItem = model.GatherEffect;
                BlockDroppedCollectibleIDComboBox.SelectedItem =
                    All.Collectibles.GetOrNull<CollectibleModel>(model.CollectibleID);
                BlockIsFlammableCheckBox.Checked = model.IsFlammable;
                BlockIsLiquidCheckBox.Checked = model.IsLiquid;
                BlockMaxToughnessTextBox.Text = model.MaxToughness.ToString();
                PictureBoxLoadFromStorage(BlockPixelBox, model.ID);
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
            if (FloorListBox.SelectedItem is null)
            {
                FloorIDStatic.Text = ModelID.None.ToString();
                FloorNameTextBox.Text = "";
                FloorDescriptionTextBox.Text = "";
                FloorCommentTextBox.Text = "";
                FloorEquivalentItemComboBox.SelectedItem = null;
                FloorAddsToBiomeListBox.Items.Clear();
                FloorAddsToRoomListBox.Items.Clear();
                FloorModificationToolComboBox.SelectedItem = ModificationTool.None;
                FloorTrenchNameTextBox.Text = "";
                FloorDugOutPixelBox.Image = Resources.ImageNotFound;
                FloorFilledInPixelBox.Image = Resources.ImageNotFound;
            }
            else if (FloorListBox.SelectedItem is FloorModel model
                    && model is not null)
            {
                FloorIDStatic.Text = model.ID.ToString();
                FloorNameTextBox.Text = model.Name;
                FloorDescriptionTextBox.Text = model.Description;
                FloorCommentTextBox.Text = model.Comment;
                FloorEquivalentItemComboBox.SelectedItem = model.ItemID == ModelID.None
                    ? null
                    : All.Items.GetOrNull<ItemModel>(model.ItemID);
                RepopulateListBox(FloorAddsToBiomeListBox, model.AddsToBiome);
                RepopulateListBox(FloorAddsToRoomListBox, model.AddsToRoom);
                FloorModificationToolComboBox.SelectedItem = model.ModTool;
                FloorTrenchNameTextBox.Text = model.TrenchName;
                // TODO: [FLOORS] Fix PictureBoxLoadFromStorage since there are two images for each floor.
                // TODO: [FLOORS] We might have to also adjust the way new projects populate the graphics folder....
                PictureBoxLoadFromStorage(FloorDugOutPixelBox, model.ID);
                // PictureBoxLoadFromStorage(FloorFilledInPixelBox, model.ID);
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
            if (FurnishingListBox.SelectedItem is null)
            {
                FurnishingIDStatic.Text = ModelID.None.ToString();
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
                FurnishingPixelBox.Image = Resources.ImageNotFound;
            }
            else if (FurnishingListBox.SelectedItem is FurnishingModel model
                    && model is not null)
            {
                FurnishingIDStatic.Text = model.ID.ToString();
                FurnishingNameTextBox.Text = model.Name;
                FurnishingDescriptionTextBox.Text = model.Description;
                FurnishingCommentTextBox.Text = model.Comment;
                FurnishingEquivalentItemComboBox.SelectedItem = model.ItemID == ModelID.None
                    ? null
                    : All.Items.GetOrNull<ItemModel>(model.ItemID);
                RepopulateListBox(FurnishingAddsToBiomeListBox, model.AddsToBiome);
                RepopulateListBox(FurnishingAddsToRoomListBox, model.AddsToRoom);
                FurnishingEntryTypeComboBox.SelectedItem = model.Entry;
                FurnishingIsWalkableCheckBox.Checked = model.IsWalkable;
                FurnishingIsEnclosingCheckBox.Checked = model.IsEnclosing;
                FurnishingIsFlammableCheckBox.Checked = model.IsFlammable;
                FurnishingSwapWithFurnishingComboBox.SelectedItem = model.SwapID == ModelID.None
                    ? null
                    : All.Furnishings.GetOrNull<FurnishingModel>(model.SwapID);
                PictureBoxLoadFromStorage(FurnishingPixelBox, model.ID);
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
            if (CollectibleListBox.SelectedItem is null)
            {
                CollectibleIDStatic.Text = ModelID.None.ToString();
                CollectibleNameTextBox.Text = "";
                CollectibleDescriptionTextBox.Text = "";
                CollectibleCommentTextBox.Text = "";
                CollectibleEquivalentItemComboBox.SelectedItem = null;
                CollectibleAddsToBiomeListBox.Items.Clear();
                CollectibleAddsToRoomListBox.Items.Clear();
                CollectibleCollectionEffectComboBox.SelectedItem = null;
                CollectibleEffectAmountTextBox.Text = "";
                CollectiblePixelBox.Image = Resources.ImageNotFound;
            }
            else if (CollectibleListBox.SelectedItem is CollectibleModel model
                    && model is not null)
            {
                CollectibleIDStatic.Text = model.ID.ToString();
                CollectibleNameTextBox.Text = model.Name;
                CollectibleDescriptionTextBox.Text = model.Description;
                CollectibleCommentTextBox.Text = model.Comment;
                CollectibleEquivalentItemComboBox.SelectedItem = model.ItemID == ModelID.None
                    ? null
                    : All.Items.GetOrNull<ItemModel>(model.ItemID);
                RepopulateListBox(CollectibleAddsToBiomeListBox, model.AddsToBiome);
                RepopulateListBox(CollectibleAddsToRoomListBox, model.AddsToRoom);
                CollectibleCollectionEffectComboBox.SelectedItem = model.CollectionEffect;
                CollectibleEffectAmountTextBox.Text = model.EffectAmount.ToString();
                PictureBoxLoadFromStorage(CollectiblePixelBox, model.ID);
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
            if (CharacterListBox.SelectedItem is null)
            {
                CharacterIDStatic.Text = ModelID.None.ToString();
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
                CharacterStartingInventoryStatic.Text = "0 Items";
                CharacterPixelBox.Image = Resources.ImageNotFound;
            }
            else if (CharacterListBox.SelectedItem is CharacterModel model
                     && model is not null)
            {
                CharacterIDStatic.Text = model.ID.ToString();
                CharacterPersonalNameTextBox.Text = model.PersonalName;
                CharacterFamilyNameTextBox.Text = model.FamilyName;
                CharacterDescriptionTextBox.Text = model.Description;
                CharacterCommentTextBox.Text = model.Comment;
                CharacterNativeBiomeComboBox.SelectedItem = model.NativeBiomeID == ModelID.None
                    ? null
                    : All.BiomeRecipes.GetOrNull<BiomeRecipe>(model.NativeBiomeID);
                CharacterPrimaryBehaviorComboBox.SelectedItem = model.PrimaryBehaviorID == ModelID.None
                    ? null
                    : All.Scripts.GetOrNull<ScriptModel>(model.PrimaryBehaviorID);
                CharacterPronounComboBox.SelectedItem = model.PronounKey;
                CharacterStoryIDTextBox.Text =
                    string.IsNullOrEmpty(model.StoryCharacterID) && Settings.Default.SuggestStoryIDs
                        ? $"{model.PersonalName.ToUpperInvariant()}_{model.FamilyName.ToUpperInvariant()}"
                        : model.StoryCharacterID;
                RepopulateListBox(CharacterStartingQuestsListBox, model.StartingQuestIDs
                                                                       // Note: I am not 100% certain what happens if GetOrNull returns null here.
                                                                       // In any case, that would be an error state.
                                                                       .Select(id => All.Interactions.GetOrNull<InteractionModel>(id)));
                CharacterStartingDialogueComboBox.SelectedItem =
                    ModelID.None == model.StartingDialogueID
                        ? null
                        : All.Interactions.GetOrNull<InteractionModel>(model.StartingDialogueID);
                CharacterStartingInventoryStatic.Text = $"{model.StartingInventory?.ItemCount ?? 0} Items";
                PictureBoxLoadFromStorage(CharacterPixelBox, model.ID);
            }
        }

        /// <summary>
        /// Populates the Pronouns panel when a <see cref="PronounGroup"/> is selected in the CharacterPronounListBox.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void CharacterPronounListBox_SelectedIndexChanged(object sender, EventArgs eventArguments)
        {
            if (CharacterPronounListBox.SelectedItem is null)
            {
                CharacterPronounKeyStatic.Text = PronounGroup.DefaultKey;
                CharacterPronounSubjectiveTextBox.Text = "";
                CharacterPronounObjectiveTextBox.Text = "";
                CharacterPronounDeterminerTextBox.Text = "";
                CharacterPronounPossessiveTextBox.Text = "";
                CharacterPronounReflexiveTextBox.Text = "";
            }
            else if (CharacterPronounListBox.SelectedItem is PronounGroup group
                     && group is not null)
            {
                CharacterPronounKeyStatic.Text = group.Key;
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
            if (CritterListBox.SelectedItem is null)
            {
                CritterIDStatic.Text = ModelID.None.ToString();
                CritterNameTextBox.Text = "";
                CritterDescriptionTextBox.Text = "";
                CritterCommentTextBox.Text = "";
                CritterNativeBiomeComboBox.SelectedItem = null;
                CritterPrimaryBehaviorComboBox.SelectedItem = null;
                CritterPixelBox.Image = Resources.ImageNotFound;
            }
            else if (CritterListBox.SelectedItem is CritterModel model
                     && model is not null)
            {
                CritterIDStatic.Text = model.ID.ToString();
                CritterNameTextBox.Text = model.Name;
                CritterDescriptionTextBox.Text = model.Description;
                CritterCommentTextBox.Text = model.Comment;
                CritterNativeBiomeComboBox.SelectedItem = model.NativeBiomeID == ModelID.None
                    ? null
                    : All.BiomeRecipes.GetOrNull<BiomeRecipe>(model.NativeBiomeID);
                CritterPrimaryBehaviorComboBox.SelectedItem = model.PrimaryBehaviorID == ModelID.None
                    ? null
                    : All.Scripts.GetOrNull<ScriptModel>(model.PrimaryBehaviorID);
                PictureBoxLoadFromStorage(CritterPixelBox, model.ID);
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
            if (ItemListBox.SelectedItem is null)
            {
                ItemIDStatic.Text = ModelID.None.ToString();
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
                ItemPixelBox.Image = Resources.ImageNotFound;
            }
            else if (ItemListBox.SelectedItem is ItemModel model
                    && model is not null)
            {
                ItemIDStatic.Text = model.ID.ToString();
                ItemNameTextBox.Text = model.Name;
                ItemDescriptionTextBox.Text = model.Description;
                ItemCommentTextBox.Text = model.Comment;
                ItemSubtypeComboBox.SelectedItem = model.Subtype;
                ItemPriceTextBox.Text = model.Price.ToString();
                ItemRarityTextBox.Text = model.Rarity.ToString();
                ItemStackMaxTextBox.Text = model.StackMax.ToString();
                ItemEffectWhileHeldComboBox.SelectedItem = model.EffectWhileHeldID == ModelID.None
                    ? null
                    : All.Scripts.GetOrNull<ScriptModel>(model.EffectWhileHeldID);
                ItemEffectWhenUsedComboBox.SelectedItem = model.EffectWhenUsedID == ModelID.None
                    ? null
                    : All.Scripts.GetOrNull<ScriptModel>(model.EffectWhenUsedID);
                ItemEquivalentParquetComboBox.SelectedItem = model.ParquetID == ModelID.None
                    ? null
                    : All.Parquets.GetOrNull<ParquetModel>(model.ParquetID);
                RepopulateListBox(ItemTagListBox, model.Tags);
                PictureBoxLoadFromStorage(ItemPixelBox, model.ID);
            }
        }

        /// <summary>
        /// Populates the Biome Recipes tab when a <see cref="BiomeRecipe"/> is selected in the BiomeListBox.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void BiomeListBox_SelectedValueChanged(object sender, EventArgs eventArguments)
        {
            BiomeEntryRequirementsListBox.SelectedItem = null;
            if (BiomeListBox.SelectedItem is null)
            {
                BiomeIDStatic.Text = ModelID.None.ToString();
                BiomeNameTextBox.Text = "";
                BiomeDescriptionTextBox.Text = "";
                BiomeCommentTextBox.Text = "";
                BiomeTierTextBox.Text = "";
                BiomeIsRoomBasedCheckBox.Checked = false;
                BiomeIsLiquidBasedCheckBox.Checked = false;
                BiomeParquetCriteriaTextBox.Text = "";
                BiomeEntryRequirementsListBox.Items.Clear();
                BiomePixelBox.Image = Resources.ImageNotFound;
            }
            else if (BiomeListBox.SelectedItem is BiomeRecipe recipe
                    && recipe is not null)
            {
                BiomeIDStatic.Text = recipe.ID.ToString();
                BiomeNameTextBox.Text = recipe.Name;
                BiomeDescriptionTextBox.Text = recipe.Description;
                BiomeCommentTextBox.Text = recipe.Comment;
                BiomeTierTextBox.Text = recipe.Tier.ToString();
                BiomeIsRoomBasedCheckBox.Checked = recipe.IsRoomBased;
                BiomeIsLiquidBasedCheckBox.Checked = recipe.IsLiquidBased;
                BiomeParquetCriteriaTextBox.Text = recipe.ParquetCriteria;
                RepopulateListBox(BiomeEntryRequirementsListBox, recipe.EntryRequirements);
                PictureBoxLoadFromStorage(BiomePixelBox, recipe.ID);
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
            if (CraftingListBox.SelectedItem is null)
            {
                CraftingIDStatic.Text = ModelID.None.ToString();
                CraftingNameTextBox.Text = "";
                CraftingDescriptionTextBox.Text = "";
                CraftingCommentTextBox.Text = "";
                CraftingProductsListBox.Items.Clear();
                CraftingIngredientsListBox.Items.Clear();
                CraftingPanelsCountStatic.Text = $"0 Panels";
                CraftingPixelBox.Image = Resources.ImageNotFound;
            }
            else if (CraftingListBox.SelectedItem is CraftingRecipe recipe
                    && recipe is not null)
            {
                CraftingIDStatic.Text = recipe.ID.ToString();
                CraftingNameTextBox.Text = recipe.Name;
                CraftingDescriptionTextBox.Text = recipe.Description;
                CraftingCommentTextBox.Text = recipe.Comment;
                RepopulateListBox(CraftingProductsListBox, recipe.Products);
                RepopulateListBox(CraftingIngredientsListBox, recipe.Ingredients);
                CraftingPanelsCountStatic.Text = $"{recipe.PanelPattern?.Count ?? 0} Panels";
                PictureBoxLoadFromStorage(CraftingPixelBox, recipe.ID);
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
            if (RoomListBox.SelectedItem is null)
            {
                RoomIDStatic.Text = ModelID.None.ToString();
                RoomNameTextBox.Text = "";
                RoomDescriptionTextBox.Text = "";
                RoomCommentTextBox.Text = "";
                RoomMinimumWalkableSpacesTextBox.Text = "";
                RoomRequiredFurnishingsListBox.Items.Clear();
                RoomRequiredFloorsListBox.Items.Clear();
                RoomRequiredBlocksListBox.Items.Clear();
                RoomPixelBox.Image = Resources.ImageNotFound;
            }
            else if (RoomListBox.SelectedItem is RoomRecipe recipe
                    && recipe is not null)
            {
                RoomIDStatic.Text = recipe.ID.ToString();
                RoomNameTextBox.Text = recipe.Name;
                RoomDescriptionTextBox.Text = recipe.Description;
                RoomCommentTextBox.Text = recipe.Comment;
                RoomMinimumWalkableSpacesTextBox.Text = recipe.MinimumWalkableSpaces.ToString();
                RepopulateListBox(RoomRequiredFurnishingsListBox, recipe.OptionallyRequiredFurnishings);
                RepopulateListBox(RoomRequiredFloorsListBox, recipe.OptionallyRequiredWalkableFloors);
                RepopulateListBox(RoomRequiredBlocksListBox, recipe.OptionallyRequiredPerimeterBlocks);
                PictureBoxLoadFromStorage(RoomPixelBox, recipe.ID);
            }
        }

        /// <summary>
        /// Populates the Maps tab when a <see cref="MapModel"/> is selected in the RoomListBox.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void MapListBox_SelectedValueChanged(object sender, EventArgs eventArguments)
        {
            if (MapListBox.SelectedItem is null)
            {
                MapIDStatic.Text = ModelID.None.ToString();
                MapNameTextBox.Text = "";
                MapDescriptionTextBox.Text = "";
                MapCommentTextBox.Text = "";
                // TODO [MAPS] Fix this: MapBackgroundColorStatic.BackColor = ColorTranslator.FromHtml(MapRegionModel.DefaultColor);
                // TODO [MAPS] Fix this: MapBackgroundColorNameStatic.Text = MapRegionModel.DefaultColor;
                MapExitNorthComboBox.SelectedItem = null;
                MapExitSouthComboBox.SelectedItem = null;
                MapExitEastComboBox.SelectedItem = null;
                MapExitWestComboBox.SelectedItem = null;
                MapExitUpComboBox.SelectedItem = null;
                MapExitDownComboBox.SelectedItem = null;
                MapPixelBox.Image = Resources.Map;
            }
            else if (MapListBox.SelectedItem is MapRegionModel model
                    && model is not null)
            {
                RoomIDStatic.Text = model.ID.ToString();
                RoomNameTextBox.Text = model.Name;
                RoomDescriptionTextBox.Text = model.Description;
                RoomCommentTextBox.Text = model.Comment;
                MapIDStatic.Text = model.ID.ToString();
                MapNameTextBox.Text = model.Name;
                MapDescriptionTextBox.Text = model.Description;
                MapCommentTextBox.Text = model.Comment;
                MapBackgroundColorStatic.BackColor = ColorTranslator.FromHtml(model.BackgroundColor);
                MapBackgroundColorNameStatic.Text = model.BackgroundColor;
                MapExitNorthComboBox.SelectedItem = model.RegionToTheNorth == ModelID.None
                    ? null
                    : All.RegionModels.GetOrNull<RegionModel>(model.RegionToTheNorth);
                MapExitSouthComboBox.SelectedItem = model.RegionToTheNorth == ModelID.None
                    ? null
                    : All.RegionModels.GetOrNull<RegionModel>(model.RegionToTheNorth);
                MapExitEastComboBox.SelectedItem = model.RegionToTheNorth == ModelID.None
                    ? null
                    : All.RegionModels.GetOrNull<RegionModel>(model.RegionToTheNorth);
                MapExitWestComboBox.SelectedItem = model.RegionToTheNorth == ModelID.None
                    ? null
                    : All.RegionModels.GetOrNull<RegionModel>(model.RegionToTheNorth);
                MapExitUpComboBox.SelectedItem = model.RegionToTheNorth == ModelID.None
                    ? null
                    : All.RegionModels.GetOrNull<RegionModel>(model.RegionToTheNorth);
                MapExitDownComboBox.SelectedItem = model.RegionToTheNorth == ModelID.None
                    ? null
                    : All.RegionModels.GetOrNull<RegionModel>(model.RegionToTheNorth);
                // TODO: [MAPS] Fix this: PictureGenerateFromMap(MapPixelBox, model.ID);
            }
        }

        // TODO [SCRIPTS] Add a ScriptListBox_SelectedValueChanged or similar callback.
        #endregion

        #region Handle Changes to Data
        /// <summary>
        /// Autosaves and/or marks the form dirty after an update.
        /// </summary>
        /// <param name="sender">The control whose content was changed.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void ContentAlteredEventHandler(object sender, EventArgs eventArguments)
        {
            if (sender is not Control alteredControl)
            {
                // Silently return if nothing was modified or if sender was not a Control.
                return;
            }
            var PropertyAccessor = GetPropertyAccessorForTabAndControl(EditorTabs.SelectedIndex, alteredControl);
            if (PropertyAccessor is null)
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


            // Suggest a StoryCharacterID if needed and requested.
            // For timing reasons, this must happen before updating the model's ListBox.
            if ((alteredControl.Name.Equals(CharacterPersonalNameTextBox.Name)
                || alteredControl.Name.Equals(CharacterFamilyNameTextBox.Name))
                && Settings.Default.SuggestStoryIDs
                && string.IsNullOrEmpty(CharacterStoryIDTextBox.Text))
            {
                var suggestedID =
                    $"{CharacterPersonalNameTextBox.Text.ToUpperInvariant()}_{CharacterFamilyNameTextBox.Text.ToUpperInvariant()}";
                var StoryIDPropertyAccessor = GetPropertyAccessorForTabAndControl(EditorTabs.SelectedIndex, CharacterStoryIDTextBox);
                CharacterStoryIDTextBox.Text = suggestedID;
                StoryIDPropertyAccessor(suggestedID);
            }

            // Update the model name representing the alteredControl in the associated ListBox if needed.
            if (ControlsWhoseContentIsListed.ContainsKey(alteredControl))
            {
                var listToUpdate = ControlsWhoseContentIsListed[alteredControl];
                listToUpdate.Items[listToUpdate.SelectedIndex] = listToUpdate.SelectedItem;

                // In the case of PronounGroups, a second model name needs to be updated.
                if (listToUpdate == CharacterPronounListBox)
                {
                    var oldIndex = CharacterPronounComboBox.SelectedIndex;
                    RepopulateComboBox(CharacterPronounComboBox,
                                       All.PronounGroups.Select(pronounGroup => pronounGroup.Key));
                    CharacterPronounComboBox.SelectedIndex = oldIndex;
                }
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

            var nextID = inDatabaseCollection.Any()
                ? (ModelID)(inDatabaseCollection.Max(model => model?.ID ?? inIDRange.Minimum) + 1)
                : inIDRange.Minimum;
            if (nextID > inIDRange.Maximum)
            {
                SystemSounds.Beep.Play();
                Logger.Log(LogLevel.Warning, Resources.ErrorMaximumIDReached);
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
            if (modelToRemove is null)
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
        /// <param name="inAddsToListBox">The UI element reflecting the collection being changed.</param>
        /// <param name="inGetTagListFromModel">The means, given a model, to find the correct tag collection.</param>
        private void AddTag<TInterface>(ListBox inAddsToListBox, Func<TInterface, ICollection<ModelTag>> inGetTagListFromModel)
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
                    SystemSounds.Beep.Play();
                    Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.WarningNotAddingDuplicate,
                                                               nameof(ModelTag)));
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
        /// <param name="inAddsToListBox">The UI element reflecting the collection being changed.</param>
        /// <param name="inGetTagListFromModel">The means, given a Model, to find the correct tag collection.</param>
        private void RemoveTag<TInterface>(ListBox inAddsToListBox, Func<TInterface, ICollection<ModelTag>> inGetTagListFromModel)
            where TInterface : IMutableModel
        {
            if (!All.CollectionsHaveBeenInitialized || inAddsToListBox.SelectedItem is null)
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

        /// <summary>
        /// Raises a <see cref="FlavorsBox"/> to adjust the tagging on the current <see cref="Model"/>.
        /// </summary>
        /// <param name="inSender">Originator of the event.</param>
        /// <param name="inArguments">Additional event data.</param>
        private void EditFlavorButton_Click(object inSender, EventArgs inArguments)
        {
            if (!All.CollectionsHaveBeenInitialized
                || GetSelectedModelForTab(EditorTabs.SelectedIndex) is not IMutableModel model)
            {
                SystemSounds.Beep.Play();
                return;
            }

            // TODO Currently this is not hooked into the undo system.
            // Tag changes must be treated atomically instead of as a giant glob.

            var flavorStatic = GetFlavorStaticForTab(EditorTabs.SelectedIndex);
            if (flavorStatic is not null
                && FlavorDialogue.ShowDialog() == DialogResult.OK)
            {
                model.Tags.Remove(model.CurrentFlavor);
                model.Tags.Add(FlavorDialogue.ReturnNewFlavor);
                flavorStatic.Text = FlavorsDialogue.ReturnUpdatedFlavor;
                flavorStatic.BackColor = GetColorForFlavorName(FlavorsDialogue.ReturnUpdatedFlavor);
                HasUnsavedChanges = true;
            }

            // Given the index of an editor tab, return the corresponding flavor display.
            Label GetFlavorStaticForTab(int inTabIndex)
                => inTabIndex switch
                {
                    BlocksTabIndex => BlockFlavorStatic,
                    FloorsTabIndex => FloorFlavorStatic,
                    FurnishingsTabIndex => FurnishingFlavorStatic,
                    CollectiblesTabIndex => CollectibleFlavorStatic,
                    CharactersTabIndex => CharacterFlavorStatic,
                    CrittersTabIndex => CritterFlavorStatic,
                    ItemsTabIndex => ItemFlavorStatic,
                    _ => null,
                };

            // Given the name of a flavor, return the color used to represent it.
            Color GetColorForFlavorName(string inFlavorName)
                => inFlavorName switch
                {
                    "bland" => FlavorBlandSelector.BackColor,
                    "sweet" => FlavorSweetSelector.BackColor,
                    "salty" => FlavorSaltySelector.BackColor,
                    "savory" => FlavorSavorySelector.BackColor,
                    "astringent" => FlavorAstringentSelector.BackColor,
                    "numbing" => FlavorNumbingSelector.BackColor,
                    "bitter" => FlavorBitterSelector.BackColor,
                    "sour" => FlavorSourSelector.BackColor,
                    "fresh" => FlavorFreshSelector.BackColor,
                    "pungent" => FlavorPungentSelector.BackColor,
                    "metallic" => FlavorMetallicSelector.BackColor,
                    "chemical" => FlavorChemicalSelector.BackColor,
                    _ => FlavorNoFlavorsSelector.BackColor,
                };
        }

        private void EditFunctionButton_Click(object sender, EventArgs e)
        {
            if (!All.CollectionsHaveBeenInitialized
                || GetSelectedModelForTab(EditorTabs.SelectedIndex) is not IMutableModel model)
            {
                SystemSounds.Beep.Play();
                return;
            }

            // TODO Currently this is not hooked into the undo system.
            // Tag changes must be treated atomically instead of as a giant glob.

            var flavorStatic = GetFunctionStaticForTab(EditorTabs.SelectedIndex);
            if (flavorStatic is not null
                && FunctionDialogue.ShowDialog() == DialogResult.OK)
            {
                model.Tags.Remove(model.CurrentFunction);
                model.Tags.Add(FunctionDialogue.ReturnNewFunction);
                flavorStatic.Text = FunctionDialogue.ReturnNewFunction;
                HasUnsavedChanges = true;
            }

            // Given the index of an editor tab, return the corresponding function display.
            Label GetFunctionStaticForTab(int inTabIndex)
                => inTabIndex switch
                {
                    BlocksTabIndex => BlockFunctionStatic,
                    FloorsTabIndex => FloorFunctionStatic,
                    FurnishingsTabIndex => FurnishingFunctionStatic,
                    CollectiblesTabIndex => CollectibleFunctionStatic,
                    ItemsTabIndex => ItemFunctionStatic,
                    _ => null,
                };
        }
        #endregion

        #region Recipe Element Adjustments
        /// <summary>
        /// Adds a new <see cref="RecipeElement"/> to the selected <see cref="Model"/>, updating the given <see cref="ListBox"/>.
        /// </summary>
        /// <param name="inAddsToListBox">The UI element reflecting the collection being changed.</param>
        /// <param name="inGetElementListFromRecipe">The means, given a model, to find the correct Recipe Element collection.</param>
        private void AddRecipeElement<TInterface>(ListBox inAddsToListBox,
                                                  Func<TInterface, ICollection<RecipeElement>> inGetElementListFromRecipe)
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
                    SystemSounds.Beep.Play();
                    Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.WarningNotAddingDuplicate,
                                                               nameof(ModelTag)));
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
        /// <param name="inAddsToListBox">The UI element reflecting the collection being changed.</param>
        /// <param name="inGetElementListFromRecipe">The means, given a Model, to find the correct Recipe Element collection.</param>
        private void RemoveRecipeElement<TInterface>(ListBox inAddsToListBox,
                                                     Func<TInterface, ICollection<RecipeElement>> inGetElementListFromRecipe)
            where TInterface : IMutableModel
        {
            if (!All.CollectionsHaveBeenInitialized || inAddsToListBox.SelectedItem is null)
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
        /// <param name="inAddsToListBox">The UI element reflecting the collection being changed.</param>
        /// <param name="inGetQuestListFromModel">The means, given a model, to find the correct ID collection.</param>
        private void AddQuest(ListBox inAddsToListBox, Func<IMutableCharacterModel, ICollection<ModelID>> inGetQuestListFromModel)
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
                    SystemSounds.Beep.Play();
                    Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.WarningNotAddingDuplicate,
                                                               nameof(ModelTag)));
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
        /// <param name="inAddsToListBox">The UI element reflecting the collection being changed.</param>
        /// <param name="inGetTagListFromModel">The means, given a Model, to find the correct ID collection.</param>
        private void RemoveQuest(ListBox inAddsToListBox, Func<IMutableCharacterModel, ICollection<ModelID>> inGetTagListFromModel)
        {
            if (!All.CollectionsHaveBeenInitialized || inAddsToListBox.SelectedItem is null)
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
                CharacterStartingInventoryStatic.Text = $"{currentCharacter.StartingInventory?.ItemCount ?? 0} Items";
            }
            else if (result == DialogResult.Abort)
            {
                SystemSounds.Beep.Play();
                Logger.Log(LogLevel.Warning, Resources.WarningNothingSelected);
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
                                            var pronounGroup = (PronounGroup)databaseValue;
                                            ((ICollection<PronounGroup>)All.PronounGroups).Add(pronounGroup);
                                            _ = CharacterPronounListBox.Items.Add(pronounGroup);
                                            _ = CharacterPronounComboBox.Items.Add(pronounGroup.Key);
                                            CharacterPronounListBox.SelectedItem = pronounGroup;
                                            HasUnsavedChanges = true;
                                        },
                                        (object databaseValue) =>
                                        {
                                            var pronounGroup = (PronounGroup)databaseValue;
                                            ((ICollection<PronounGroup>)All.PronounGroups).Remove(pronounGroup);
                                            CharacterPronounListBox.Items.Remove(pronounGroup);
                                            CharacterPronounComboBox.Items.Remove(pronounGroup.Key);
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

            if (CharacterPronounListBox.SelectedItem is not PronounGroup groupToRemove)
            {
                SystemSounds.Beep.Play();
                return;
            }

            ChangeManager.AddAndExecute(new ChangeList(groupToRemove, $"remove Pronoun Group {groupToRemove.Key}",
                                        (object databaseValue) =>
                                        {
                                            var pronounGroup = (PronounGroup)databaseValue;
                                            ((ICollection<PronounGroup>)All.PronounGroups).Remove(pronounGroup);
                                            CharacterPronounListBox.Items.Remove(pronounGroup);
                                            CharacterPronounComboBox.Items.Remove(pronounGroup.Key);
                                            CharacterPronounListBox.SelectedItem = null;
                                            HasUnsavedChanges = true;
                                        },
                                        (object databaseValue) =>
                                        {
                                            var pronounGroup = (PronounGroup)databaseValue;
                                            ((ICollection<PronounGroup>)All.PronounGroups).Add(pronounGroup);
                                            _ = CharacterPronounListBox.Items.Add(pronounGroup);
                                            _ = CharacterPronounComboBox.Items.Add(pronounGroup.Key);
                                            CharacterPronounListBox.SelectedItem = pronounGroup;
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
            => AddTag(ItemTagListBox, (IMutableItemModel model) => model.Tags);

        /// <summary>
        /// Registers the user command to remove the selected tag from the current item.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void ItemRemoveTagButton_Click(object sender, EventArgs eventArguments)
            => RemoveTag(ItemTagListBox, (IMutableItemModel model) => model.Tags);

        /// <summary>
        /// Invokes the <see cref="InventoryEditorForm"/> for the currently selected <see cref="CharacterModel"/>.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void ItemOpenInvetoryEditorButton_Click(object sender, EventArgs eventArguments)
        {
            var currentCharacter = (CharacterModel)ItemInventoryListBox.SelectedItem;
            InventoryEditorWindow.CurrentCharacter = currentCharacter;
            if (currentCharacter is null ||
                InventoryEditorWindow.ShowDialog() == DialogResult.Abort)
            {
                SystemSounds.Beep.Play();
                Logger.Log(LogLevel.Warning, Resources.WarningNothingSelected);
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
            _ = MessageBox.Show(Resources.WarningNotImplemented, Resources.CaptionWorkflow, MessageBoxButtons.OK);
            // TODO: Reenable this once we fully implement StrikePanel-based crafting.
            /*
            StrikePatternEditorWindow.CurrentCraft = (CraftingRecipe)GetSelectedModelForTab(EditorTabs.SelectedIndex);
            if (StrikePatternEditorWindow.ShowDialog() == DialogResult.Abort)
            {
                SystemSounds.Beep.Play();
                Logger.Log(LogLevel.Warning, Resources.WarningNothingSelected);
            }
            */
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
        /// Registers the user command to add a new Floor requirement to the current Room Recipe.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void RoomAddFloorButton_Click(object sender, EventArgs eventArguments)
            => AddRecipeElement(RoomRequiredFurnishingsListBox, (IMutableRoomRecipe recipe) => recipe.OptionallyRequiredWalkableFloors);

        /// <summary>
        /// Registers the user command to add a new Block requirement to the current Room Recipe.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void RoomAddBlockButton_Click(object sender, EventArgs eventArguments)
            => AddRecipeElement(RoomRequiredFurnishingsListBox, (IMutableRoomRecipe recipe) => recipe.OptionallyRequiredPerimeterBlocks);
        #endregion

        #region Maps Tab
        // TODO Wire these map-related methods up!  (There may be other map items needing wiring.)
        /// <summary>
        /// Responds to the user clicking "Add New Map" on the Maps tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void MapAddNewItemButton_Click(object sender, EventArgs eventArguments)
            => AddNewModel(All.RegionModels, (ModelID id) => new RegionModel(id, "New Region", "", ""), All.RegionIDs, MapListBox, "Region");

        /// <summary>
        /// Responds to the user clicking "Remove Map" on the Maps tab.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void MapRemoveItemButton_Click(object sender, EventArgs eventArguments)
            => RemoveModel(All.RegionModels, MapListBox, "Region");

        /// <summary>
        /// Invokes the <see cref="MapEditorForm"/> for the currently selected <see cref="MapModel"/>.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void MapOpenEditorButton_Click(object sender, EventArgs eventArguments)
        {
            // TODO Implement this!
            //MapEditorWindow.CurrentMap = (MapModel)MapListBox.SelectedItem;
            //if (MapEditorWindow.CurrentMap is null ||
            //    MapEditorWindow.ShowDialog() == DialogResult.Abort)
            //{
            //    SystemSounds.Beep.Play();
            //    Logger.Log(LogLevel.Warning, Resources.WarningNothingSelected);
            //}
            SystemSounds.Beep.Play();
        }
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
        /// <param name="eventArguments">Additional event data.</param>
        private void NewToolStripMenuItem_Click(object sender, EventArgs eventArguments)
        {
            if (!EditorCommands.SelectProjectFolder(Resources.InfoMessageNew, Resources.FolderNameNewProject))
            {
                return;
            }

            Logger.Log(LogLevel.Info, Resources.LogNewProject);
            if (TemplatesMessageBox.CreateTemplatesInProjectFolder()
                && EditorCommands.LoadDataFiles())
            {
                HasUnsavedChanges = false;
                UpdateDisplay();
            }
            else
            {
                SystemSounds.Beep.Play();
                Logger.Log(LogLevel.Error, Resources.ErrorNewFailed);
            }
        }

        /// <summary>
        /// Responds to a user selecting the "Load" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void LoadToolStripMenuItem_Click(object sender, EventArgs eventArguments)
        {
            if (!EditorCommands.SelectProjectFolder(Resources.InfoMessageLoad, Resources.FolderNameOldProject))
            {
                return;
            }

            Logger.Log(LogLevel.Info, Resources.LogLoadingProject);
            if (EditorCommands.LoadDataFiles())
            {
                HasUnsavedChanges = false;
                UpdateDisplay();
            }
            else
            {
                SystemSounds.Beep.Play();
                Logger.Log(LogLevel.Error, Resources.ErrorLoadFailed);
            }
        }

        /// <summary>
        /// Responds to a user selecting the "Reload" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void ReloadToolStripMenuItem_Click(object sender, EventArgs eventArguments)
        {
            if (MessageBox.Show(Resources.WarningMessageReload,
                                Resources.CaptionReloadWarning,
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Logger.Log(LogLevel.Info, Resources.LogLoadingProject);
                if (EditorCommands.LoadDataFiles())
                {
                    HasUnsavedChanges = false;
                    UpdateDisplay();
                }
                else
                {
                    SystemSounds.Beep.Play();
                    Logger.Log(LogLevel.Error, Resources.ErrorLoadFailed);
                }
            }
        }

        /// <summary>
        /// Responds to a user selecting the "Save" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs eventArguments)
        {
            Logger.Log(LogLevel.Info, Resources.LogSavingProject);
            Validate();
            if (EditorCommands.SaveDataFiles())
            {
                HasUnsavedChanges = false;
            }
            else
            {
                SystemSounds.Beep.Play();
                Logger.Log(LogLevel.Error, Resources.ErrorSaveFailed);
            }
        }

        /// <summary>
        /// Responds to a user selecting "Open Project Folder" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void OpenProjectFolderToolStripMenuItem_Click(object sender, EventArgs eventArguments)
        {
            if (!string.IsNullOrEmpty(All.ProjectDirectory))
            {
                Logger.Log(LogLevel.Info, Resources.LogOpenProjectFolder);
                _ = Process.Start("explorer", $"\"{All.ProjectDirectory}\"");
            }
            else
            {
                SystemSounds.Beep.Play();
            }
        }

        /// <summary>
        /// Responds to a user selecting "Open Project Command Prompt" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void OpenCommandPromptToolStripMenuItem_Click(object sender, EventArgs eventArguments)
        {
            if (!string.IsNullOrEmpty(All.ProjectDirectory))
            {
                try
                {
                    Logger.Log(LogLevel.Info, Resources.LogOpenCommandPrompt);

                    using var shellProcess = new Process();
                    shellProcess.StartInfo.FileName = "powershell.exe";
                    shellProcess.StartInfo.Arguments = $"-noexit -command \"cd {All.ProjectDirectory}\"";
                    shellProcess.Start();
                    shellProcess.WaitForExit();

                    var exitCode = (ExitCode)shellProcess.ExitCode;
                    if (exitCode != ExitCode.Success)
                    {
                        Logger.Log(LogLevel.Warning, exitCode.ToStatusMessage());
                    }
                }
                catch (Win32Exception winException)
                {
                    Logger.Log(LogLevel.Warning, winException.Message, winException);
                }
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
        /// <param name="eventArguments">Additional event data.</param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs eventArguments)
            => Close();

        /// <summary>
        /// Responds to a user selecting the "Undo" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void UndoToolStripMenuItem_Click(object sender, EventArgs eventArguments)
            => ChangeManager.Undo();

        /// <summary>
        /// Responds to a user selecting the "Redo" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void RedoToolStripMenuItem_Click(object sender, EventArgs eventArguments)
            => ChangeManager.Redo();

        /// <summary>
        /// Responds to a user selecting the "Cut" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void CutToolStripMenuItem_Click(object sender, EventArgs eventArguments)
        {
            Clipboard.SetText(ActiveControl.Text);
            ActiveControl.Text = "";
            ActiveControl.Focus();
        }

        /// <summary>
        /// Responds to a user selecting the "Copy" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void CopyToolStripMenuItem_Click(object sender, EventArgs eventArguments)
            => Clipboard.SetText(ActiveControl.Text);

        /// <summary>
        /// Responds to a user selecting the "Paste" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void PasteToolStripMenuItem_Click(object sender, EventArgs eventArguments)
            => ActiveControl.Text = Clipboard.GetText();

        /// <summary>
        /// Responds to a user selecting the "Select All" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs eventArguments)
        {
            if (ActiveControl is TextBox activeTextBox)
            {
                activeTextBox.SelectAll();
                activeTextBox.Focus();
            }
            else
            {
                SystemSounds.Beep.Play();
            }
        }

        /// <summary>
        /// Responds to a user selecting the "Check Map" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void CheckMapStripMenuItem_Click(object sender, EventArgs eventArguments)
            => RunRoller("check");

        /// <summary>
        /// Responds to a user selecting the "List Naming Collisions" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void ListNameCollisionsStripMenuItem_Click(object sender, EventArgs eventArguments)
            => RunRoller($"list collisions {GetRollerArgumentForTab(EditorTabs.SelectedIndex)}");

        /// <summary>
        /// Responds to a user selecting the "List ID Ranges" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void ListIDRangesToolStripMenuItem_Click(object sender, EventArgs eventArguments)
            => RunRoller($"list ranges {GetRollerArgumentForTab(EditorTabs.SelectedIndex)}");

        /// <summary>
        /// Responds to a user selecting the "List Max IDs" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void ListMaxIDsToolStripMenuItem_Click(object sender, EventArgs eventArguments)
            => RunRoller($"list maxids {GetRollerArgumentForTab(EditorTabs.SelectedIndex)}");

        /// <summary>
        /// Responds to a user selecting the "List Tags" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void ListTagsToolStripMenuItem_Click(object sender, EventArgs eventArguments)
            => RunRoller($"list tags {GetRollerArgumentForTab(EditorTabs.SelectedIndex)}");

        /// <summary>
        /// Responds to a user selecting the "Options" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void OptionsToolStripMenuItem_Click(object sender, EventArgs eventArguments)
        {
            oldTheme = Settings.Default.CurrentEditorTheme;
            OptionsDialogue.ShowDialog();
        }

        /// <summary>
        /// Responds to a user selecting the "Refresh Display" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void RefreshStripMenuItem_Click(object sender, EventArgs eventArguments)
        {
            UpdateDisplay();
            ApplyCurrentTheme();
        }

        /// <summary>
        /// Responds to a user selecting the "Scribe Help" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void ScribeHelpToolStripMenuItem_Click(object sender, EventArgs eventArguments)
            => throw new NotImplementedException();

        /// <summary>
        /// Responds to a user selecting the "Documentation" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void DocumentationToolStripMenuItem_Click(object sender, EventArgs eventArguments)
            => throw new NotImplementedException();

        /// <summary>
        /// Responds to a user selecting the "About" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void AboutMenuItem_Click(object sender, EventArgs eventArguments)
            => AboutDialogue.ShowDialog();

        /// <summary>
        /// Responds to a user selecting "Open Containing Folder" context menu item from a picture box.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void OpenContainingFolderMenuItem_Click(object sender, EventArgs eventArguments)
        {
            var path = ((PictureBox)((ContextMenuStrip)((ToolStripItem)sender)?.Owner)?.SourceControl)?.ImageLocation;
            path = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(path))
            {
                Logger.Log(LogLevel.Info, nameof(Resources.LogOpenImageFolder));
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
        /// <param name="eventArguments">Additional event data.</param>
        private void CopyID_Click(object sender, EventArgs eventArguments)
        {
            var id = GetSelectedModelIDForTab(EditorTabs.SelectedIndex).ToString();
            if (!string.IsNullOrEmpty(id))
            {
                Clipboard.SetText(id);
                MainToolStripStatusLabel.Text = Resources.InfoIDCopied;
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
        /// <param name="eventArguments">Additional event data.</param>
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
        /// <param name="eventArguments">Additional event data.</param>
        private void ToolStripMenuItemContextCut_OnClick(object sender, EventArgs eventArguments)
            => ContentAlteredEventHandler(SourceBox?.Cut(), eventArguments);

        /// <summary>
        /// Copies the selected text from the currently active <see cref="TextBox"/> or <see cref="ComboBox"/>.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void ToolStripMenuItemContextCopy_OnClick(object sender, EventArgs eventArguments)
            => SourceBox?.Copy();

        /// <summary>
        /// Pastes text to the currently active <see cref="TextBox"/> or <see cref="ComboBox"/>.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void ToolStripMenuItemContextPaste_OnClick(object sender, EventArgs eventArguments)
            => ContentAlteredEventHandler(SourceBox?.Paste(), eventArguments);

        /// <summary>
        /// Clears all text from the currently active <see cref="TextBox"/> or <see cref="ComboBox"/>.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void ToolStripMenuItemContextClear_OnClick(object sender, EventArgs eventArguments)
            => ContentAlteredEventHandler(SourceBox?.ClearAll(), eventArguments);

        /// <summary>
        /// Selects all text in the currently active <see cref="TextBox"/> or <see cref="ComboBox"/>.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void ToolStripMenuItemContextSelectAll_OnClick(object sender, EventArgs eventArguments)
            => SourceBox?.SelectAll();
        #endregion

        #region Other Events
        /// <summary>
        /// Spawns an external image editor with the image of the currently selected model.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void EditImageExternally(object sender, EventArgs eventArguments)
        {
            var id = GetSelectedModelIDForTab(EditorTabs.SelectedIndex);
            if (id != ModelID.None)
            {
                Logger.Log(LogLevel.Info, Resources.LogLaunchExternalImageEditor);
                var imagePathAndFilename = Path.Combine(EditorCommands.GetGraphicsPathForModelID(id), $"{id}.png");
                if (!File.Exists(imagePathAndFilename))
                {
                    Resources.ImageNotFound.Save(imagePathAndFilename, ImageFormat.Png);
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
        private void PixelBoxReload_Click(object sender, EventArgs eventArguments)
            => PictureBoxLoadFromStorage(GetPictureBoxForTab(EditorTabs.SelectedIndex),
                                         GetSelectedModelIDForTab(EditorTabs.SelectedIndex));

        /// <summary>
        /// Clears the status text from the bottom of the window.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void ClearStatusTimer_Tick(object sender, EventArgs eventArguments)
            => MainToolStripStatusLabel.Text = "";
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
                    return;
                }
            }

            // This code should only run if the user does not cancel the close event.
            Logger.Log(LogLevel.Info, Resources.LogScribeClosing);
            UILogger.Dispose();
            FormClosing -= FormClosingEventHandler;
        }
        #endregion
    }
}
