using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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

        #region Project Data
        private string ProjectDirectory = "";
        #endregion

        #region Initialization
        /// <summary>
        /// Constructs a new instance of the main editor UI.
        /// </summary>
        public MainEditorForm()
        {
            InitializeComponent();

            /*  TODO These might not be needed.  Add these if the fonts are wonky.
            EditorStatusStrip.Font = SystemFonts.StatusFont;
            MainMenuBar.Font = SystemFonts.MenuFont;
            Font = SystemFonts.DialogFont;
             */

            #region Default Event Handlers
            FormClosing += new FormClosingEventHandler((object sender, FormClosingEventArgs e) =>
            {
                if (MessageBox.Show(Resources.WarningMessageExit,
                                    Resources.CaptionExitWarning,
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            });
            #endregion
        }

        /// <summary>
        /// Sets up the main editor UI.
        /// </summary>
        /// <param name="EventData">Handled by parent.</param>
        protected override void OnLoad(EventArgs EventData)
        {
            base.OnLoad(EventData);
            if (string.IsNullOrEmpty(ProjectDirectory))
            {
                ProjectDirectory = All.WorkingDirectory;
            }
            UpdateLibraryDataDisplay();
            UpdateFileFormatDisplay();
        }
        #endregion

        #region Display Update Methods
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
            LibraryWorkingDirectoryExample.Text = ProjectDirectory;
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
            var response = MessageBox.Show(string.Format(CultureInfo.CurrentCulture, Resources.WarningMessageNew, ProjectDirectory),
                                           Resources.CaptionNewWarning,
                                           MessageBoxButtons.YesNoCancel,
                                           MessageBoxIcon.Warning);
            switch (response)
            {
                case DialogResult.Yes:
                    CreateTemplatesInProjectFolder();
                    break;
                case DialogResult.No:
                    SelectProjectFolder();
                    CreateTemplatesInProjectFolder();
                    // TODO If creating templates automatically loads their content, remove this call.
                    LoadDataFiles();
                    break;
                case DialogResult.Cancel:
                    break;
            }
        }

        /// <summary>
        /// Responds to a user selecting the "Load" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="e">Addional event data.</param>
        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectProjectFolder();
            LoadDataFiles();
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
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Responds to a user selecting the "Save" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="e">Addional event data.</param>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
            => throw new NotImplementedException();

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
            => OptionsDialogue.ShowDialog();

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
        #endregion

        #region Tab Refresh Methods
        /// <summary>
        /// Repopulates the given list with the <see cref="Model"/>s in the given collection.
        /// </summary>
        /// <typeparam name="T">A model type.</typeparam>
        /// <param name="in_listbox">The UI to repopulate.</param>
        /// <param name="in_source">The objects to populate the UI with.</param>
        private void RepopulateListBox<T>(ListBox in_listbox, IEnumerable<T> in_source)
            where T : Model
        {
            if (null != in_source)
            {
                // TODO This should only happen if the database has actually changed and/or if the list box is empty.
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
        /// Repopulates the selection list box when the tab becomes active.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void GamesTabPage_Enter(object sender, EventArgs e)
            => RepopulateListBox(GameListBox, All.Games);

        /// <summary>
        /// Repopulates the selection list box when the tab becomes active.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void CritterListBox_Enter(object sender, EventArgs e)
            => RepopulateListBox(CritterListBox, (IEnumerable<CritterModel>)All.Beings.Where(being => being is CritterModel));

        /// <summary>
        /// Repopulates the selection list box when the tab becomes active.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void CharacterListBox_Enter(object sender, EventArgs e)
            => RepopulateListBox(CharacterListBox, (IEnumerable<CharacterModel>)All.Beings.Where(being => being is CharacterModel));

        /// <summary>
        /// Repopulates the selection list box when the tab becomes active.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void BiomeListBox_Enter(object sender, EventArgs e)
            => RepopulateListBox(BiomeListBox, All.Biomes);

        /// <summary>
        /// Repopulates the selection list box when the tab becomes active.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void CraftingListBox_Enter(object sender, EventArgs e)
            => RepopulateListBox(CraftingListBox, All.CraftingRecipes);

        /// <summary>
        /// Repopulates the selection list box when the tab becomes active.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void ItemListBox_Enter(object sender, EventArgs e)
            => RepopulateListBox(ItemListBox, All.Items);

        /// <summary>
        /// Repopulates the selection list box when the tab becomes active.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void FloorListBox_Enter(object sender, EventArgs e)
            => RepopulateListBox(FloorListBox, (IEnumerable<FloorModel>)All.Parquets.Where(parquet => parquet is FloorModel));

        /// <summary>
        /// Repopulates the selection list box when the tab becomes active.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void BlockListBox_Enter(object sender, EventArgs e)
            => RepopulateListBox(BlockListBox, (IEnumerable<BlockModel>)All.Parquets.Where(parquet => parquet is BlockModel));

        /// <summary>
        /// Repopulates the selection list box when the tab becomes active.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void FurnishingListBox_Enter(object sender, EventArgs e)
            => RepopulateListBox(FurnishingListBox, (IEnumerable<FurnishingModel>)All.Parquets.Where(parquet => parquet is FurnishingModel));

        /// <summary>
        /// Repopulates the selection list box when the tab becomes active.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void CollectibleListBox_Enter(object sender, EventArgs e)
            => RepopulateListBox(CollectibleListBox, (IEnumerable<CollectibleModel>)All.Parquets.Where(parquet => parquet is CollectibleModel));

        /// <summary>
        /// Repopulates the selection list box when the tab becomes active.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void RoomListBox_Enter(object sender, EventArgs e)
            => RepopulateListBox(RoomListBox, All.RoomRecipes);
        #endregion

        #region Editor Commands
        // TODO These would be good candidates for moving into a dedicated non-UI class.

        private void SelectProjectFolder()
            => throw new NotImplementedException();

        private void CreateTemplatesInProjectFolder()
            => throw new NotImplementedException();

        private void LoadDataFiles()
            => throw new NotImplementedException();
        #endregion
    }
}
