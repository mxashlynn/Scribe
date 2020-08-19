using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices.ComTypes;
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
        private readonly Dictionary<Type, Dictionary<Control, string>> EditableControls;

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
                        // TODO It might be a good idea to move this out of the setter? 
                        EditorCommands.SaveDataFiles();
                        // TODO Only do this if the save succeeds.
                        HasUnsavedChanges = false;
                    }
                    else
                    {
                        // All now contains unsaved changes.
                        Text = Resources.CaptionMainEditorFormDirty;
                        _hasUnsavedChanges = true;
                    }
                }
                else
                {
                    // All is now in sync with storage.
                    Text = Resources.CaptionMainEditorFormClean;
                    TimeOfLastSync = DateTime.Now;
                    _hasUnsavedChanges = false;
                }
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
        private Dictionary<Type, Dictionary<Control, string>> GetEditableControls()
        {
            var editables = new Dictionary<Type, Dictionary<Control, string>>();

            editables[typeof(TextBox)] = new Dictionary<Control, string>();
            foreach (var textbox in EditorTabs.GetAllChildrenOfType<TextBox>())
            {
                editables[typeof(TextBox)][textbox] = textbox.Text;
            }
            editables[typeof(CheckBox)] = new Dictionary<Control, string>();
            foreach (var checkbox in EditorTabs.GetAllChildrenOfType<CheckBox>())
            {
                editables[typeof(CheckBox)][checkbox] = checkbox.Checked.ToString();
            }
            editables[typeof(ComboBox)] = new Dictionary<Control, string>();
            foreach (var combobox in EditorTabs.GetAllChildrenOfType<ComboBox>())
            {
                editables[typeof(ComboBox)][combobox] = combobox.SelectedIndex.ToString();
            }
            editables[typeof(ListBox)] = new Dictionary<Control, string>();
            foreach (var listbox in EditorTabs.GetAllChildrenOfType<ListBox>())
            {
                editables[typeof(ListBox)][listbox] = listbox.SelectedIndex.ToString();
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
        /// <summary>
        /// Given the index of an editor tab, return the default <see cref="ModelID"/> for the content it edits.
        /// </summary>
        /// <param name="in_tabIndex">The index of the tab sought.</param>
        /// <returns>The corresponding ID.</returns>
        private ModelID GetDefaultIDForTab(int in_tabIndex)
            => in_tabIndex switch
            {
                0 => All.GameIDs.Minimum,
                1 => All.BlockIDs.Minimum,
                2 => All.FloorIDs.Minimum,
                3 => All.FurnishingIDs.Minimum,
                4 => All.CollectibleIDs.Minimum,
                5 => All.CharacterIDs.Minimum,
                6 => All.CritterIDs.Minimum,
                7 => All.ItemIDs.Minimum,
                8 => All.BiomeIDs.Minimum,
                9 => All.CraftingRecipeIDs.Minimum,
                10 => All.RoomRecipeIDs.Minimum,
                _ => ModelID.None,
            };
        #endregion

        #region Display Update Methods
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
                    in_listbox.Items.Add(game);
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

        #region Handle Changes to Data
        /// <summary>
        /// Autosaves and/or marks the form dirty after an update.
        /// </summary>
        /// <param name="sender">The control whose content was changed.</param>
        /// <param name="e">Ignored.</param>
        private void ContentAlteredEventHandler(object sender, EventArgs e)
        {
            if (sender is TextBox textbox
                && string.Compare(textbox.Text,
                                  EditableControls[typeof(TextBox)][textbox],
                                  comparisonType: StringComparison.OrdinalIgnoreCase) != 0)
            {
                EditableControls[typeof(TextBox)][textbox] = textbox.Text;
                HasUnsavedChanges = true;
            }
            else if (sender is CheckBox checkbox
                     && string.Compare(checkbox.Checked.ToString(),
                                       EditableControls[typeof(CheckBox)][checkbox],
                                       comparisonType: StringComparison.OrdinalIgnoreCase) != 0)
            {
                EditableControls[typeof(CheckBox)][checkbox] = checkbox.Checked.ToString();
                HasUnsavedChanges = true;
            }
            else if (sender is ComboBox combobox
                     && string.Compare(combobox.SelectedIndex.ToString(),
                                       EditableControls[typeof(ComboBox)][combobox],
                                       comparisonType: StringComparison.OrdinalIgnoreCase) != 0)
            {
                EditableControls[typeof(ComboBox)][combobox] = combobox.SelectedIndex.ToString();
                HasUnsavedChanges = true;
            }
            else if (sender is ListBox listbox
                     && string.Compare(listbox.SelectedIndex.ToString(),
                                       EditableControls[typeof(ListBox)][listbox],
                                       comparisonType: StringComparison.OrdinalIgnoreCase) != 0)
            {
                EditableControls[typeof(ListBox)][listbox] = listbox.SelectedIndex.ToString();
                HasUnsavedChanges = true;
            }
        }
        #endregion

        #region Menu Item Events
        /// <summary>
        /// Responds to a user selecting the "New" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="e">Addional event data.</param>
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectProjectFolder(Resources.InfoMessageNew)
                && EditorCommands.CreateTemplatesInProjectFolder())
            {
                EditorCommands.LoadDataFiles();
                // TODO Only do this if the load succeeds.
                HasUnsavedChanges = false;
                UpdateDisplay();
            }
        }

        /// <summary>
        /// Responds to a user selecting the "Load" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="e">Addional event data.</param>
        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectProjectFolder(Resources.InfoMessageLoad))
            {
                EditorCommands.LoadDataFiles();
                // TODO Only do this if the load succeeds.
                HasUnsavedChanges = false;
                UpdateDisplay();
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
                EditorCommands.LoadDataFiles();
                // TODO Only do this if the load succeeds.
                HasUnsavedChanges = false;
                UpdateDisplay();
            }
        }

        /// <summary>
        /// Responds to a user selecting the "Save" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="e">Addional event data.</param>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorCommands.SaveDataFiles();
            // TODO Only do this if the save succeeds.
            HasUnsavedChanges = false;
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
                Process.Start("explorer", $"\"{All.ProjectDirectory}\"");
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
            => throw new NotImplementedException();

        /// <summary>
        /// Responds to a user selecting the "Redo" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="e">Addional event data.</param>
        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
            => throw new NotImplementedException();

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
                Process.Start("explorer", $"\"{path}\"");
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
                Process.Start("explorer", $"\"{picturebox.ImageLocation}\"");
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
            if (inPictureBox.Image != Resources.ImageNotFoundGraphic &&
                !string.IsNullOrEmpty(inPictureBox.ImageLocation))
            {
                // Make this application specifiable via options, maybe?
                Process.Start("explorer", $"\"{inPictureBox.ImageLocation}\"");
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
