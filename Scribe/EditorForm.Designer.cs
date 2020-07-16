using System;

namespace Scribe
{
    partial class EditorForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorForm));
            this.EditorStatusStrip = new System.Windows.Forms.StatusStrip();
            this.MainToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.MainMenuBar = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UndoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RedoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.CutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.SelectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RollerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckMapStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListNameCollisionsStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ListIDRangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListMaxIDsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListTagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.OptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ScribeHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DocumentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditorTabs = new System.Windows.Forms.TabControl();
            this.GameTabPage = new System.Windows.Forms.TabPage();
            this.GameIconEditButton = new System.Windows.Forms.Button();
            this.GameIconPictureBox = new System.Windows.Forms.PictureBox();
            this.GameTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.GameNameLabel = new System.Windows.Forms.Label();
            this.GameDescriptionLabel = new System.Windows.Forms.Label();
            this.GameCommentLabel = new System.Windows.Forms.Label();
            this.GameIsEpisodeLabel = new System.Windows.Forms.Label();
            this.GameEpisodeTitleLabel = new System.Windows.Forms.Label();
            this.GameEpisodeNumberLabel = new System.Windows.Forms.Label();
            this.GamePlayerCharacterLabel = new System.Windows.Forms.Label();
            this.GameFirstScriptLabel = new System.Windows.Forms.Label();
            this.GameIsEpisodeCheckBox = new System.Windows.Forms.CheckBox();
            this.GameNameTextBox = new System.Windows.Forms.TextBox();
            this.GameDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.GameCommentTextBox = new System.Windows.Forms.TextBox();
            this.GameEpisodeTitleTextBox = new System.Windows.Forms.TextBox();
            this.GameEpisodeNumberTextBox = new System.Windows.Forms.TextBox();
            this.GamePlayerCharacterTextBox = new System.Windows.Forms.TextBox();
            this.GameFirstScriptTextBox = new System.Windows.Forms.TextBox();
            this.GameIDLabel = new System.Windows.Forms.Label();
            this.GameIDTextBox = new System.Windows.Forms.TextBox();
            this.NewGameButton = new System.Windows.Forms.Button();
            this.GamesListBox = new System.Windows.Forms.ListBox();
            this.FileFormatGroupBox = new System.Windows.Forms.GroupBox();
            this.FileFormatTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.PrimaryDelimiterLabel = new System.Windows.Forms.Label();
            this.PrimaryDelimiterExample = new System.Windows.Forms.Label();
            this.SecondaryDelimiterLabel = new System.Windows.Forms.Label();
            this.SecondaryDelimiterExample = new System.Windows.Forms.Label();
            this.InternalDelimiterLabel = new System.Windows.Forms.Label();
            this.InternalDelimiterExample = new System.Windows.Forms.Label();
            this.ElementDelimiterLabel = new System.Windows.Forms.Label();
            this.ElementDelimiterExample = new System.Windows.Forms.Label();
            this.NameDelimiterLabel = new System.Windows.Forms.Label();
            this.NameDelimiterExample = new System.Windows.Forms.Label();
            this.PronounDelimiterLabel = new System.Windows.Forms.Label();
            this.PronounDelimiterExample = new System.Windows.Forms.Label();
            this.DimensionalDelimiterLabel = new System.Windows.Forms.Label();
            this.DimensionalDelimiterExample = new System.Windows.Forms.Label();
            this.DimensionalTerminatorLabel = new System.Windows.Forms.Label();
            this.DimensionalTerminatorExample = new System.Windows.Forms.Label();
            this.LibraryInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.LibraryInfoTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.VersionExample = new System.Windows.Forms.Label();
            this.WorkingDirectoryLabel = new System.Windows.Forms.Label();
            this.WorkingDirectoryExample = new System.Windows.Forms.Label();
            this.BeingsTabPage = new System.Windows.Forms.TabPage();
            this.BiomesTabPage = new System.Windows.Forms.TabPage();
            this.BiomeAddEntryRequirementButton = new System.Windows.Forms.Button();
            this.BiomeDeleteEntryRequirementButton = new System.Windows.Forms.Button();
            this.BiomeListBox = new System.Windows.Forms.ListBox();
            this.BiomeConfigGroupBox = new System.Windows.Forms.GroupBox();
            this.BiomeConfigTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.BiomeLandThresholdFactorLabel = new System.Windows.Forms.Label();
            this.BiomeLiquidThresholdFactorLabel = new System.Windows.Forms.Label();
            this.BiomeLandThresholdTextBox = new System.Windows.Forms.TextBox();
            this.BiomeLiquidThresholdFactorTextBox = new System.Windows.Forms.TextBox();
            this.BiomeRoomThresholdFactorTextBox = new System.Windows.Forms.TextBox();
            this.BiomeRoomThresholdFactorLabel = new System.Windows.Forms.Label();
            this.BiomePictureEditButton = new System.Windows.Forms.Button();
            this.BiomeTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.BiomeAddParquetCriterionButton = new System.Windows.Forms.Button();
            this.BiomeDeleteParquetCriterionButton = new System.Windows.Forms.Button();
            this.BiomeEntryRequirementsListBox = new System.Windows.Forms.ListBox();
            this.BiomeParquetCriteriaListBox = new System.Windows.Forms.ListBox();
            this.BiomeIsLiquidBasedCheckBox = new System.Windows.Forms.CheckBox();
            this.BiomeIsRoomBasedCheckBox = new System.Windows.Forms.CheckBox();
            this.BiomeNameLabel = new System.Windows.Forms.Label();
            this.BiomeDescriptionLabel = new System.Windows.Forms.Label();
            this.BiomeCommentLabel = new System.Windows.Forms.Label();
            this.BiomeTierLabel = new System.Windows.Forms.Label();
            this.BiomeIsRoomBasedLabel = new System.Windows.Forms.Label();
            this.BiomeIsLiquidBasedLabel = new System.Windows.Forms.Label();
            this.BiomeParquetCriteriaLabel = new System.Windows.Forms.Label();
            this.BiomeEntryRequirementsLabel = new System.Windows.Forms.Label();
            this.BiomeNameTextBox = new System.Windows.Forms.TextBox();
            this.BiomeDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.BiomeCommentTextBox = new System.Windows.Forms.TextBox();
            this.BiomeTierTextBox = new System.Windows.Forms.TextBox();
            this.BiomePictureBox = new System.Windows.Forms.PictureBox();
            this.BiomeIDLabel = new System.Windows.Forms.Label();
            this.BiomeAddNewBiomeButton = new System.Windows.Forms.Button();
            this.BiomeIDTextBox = new System.Windows.Forms.TextBox();
            this.CraftingTabPage = new System.Windows.Forms.TabPage();
            this.ItemsTabPage = new System.Windows.Forms.TabPage();
            this.ItemAddEntryRequirementButton = new System.Windows.Forms.Button();
            this.ItemDeleteEntryRequirementButton = new System.Windows.Forms.Button();
            this.ItemListBox = new System.Windows.Forms.ListBox();
            this.ItemConfigGroupBox = new System.Windows.Forms.GroupBox();
            this.ItemConfigTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ItemMinWalkableSpacesLabel = new System.Windows.Forms.Label();
            this.ItemMaxWalkableSpacesLabel = new System.Windows.Forms.Label();
            this.ItemMinWalkableSpacesTextBox = new System.Windows.Forms.TextBox();
            this.ItemMaxWalkableSpacesTextBox = new System.Windows.Forms.TextBox();
            this.ItemPictureEditButton = new System.Windows.Forms.Button();
            this.ItemTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ItemAddParquetCriterionButton = new System.Windows.Forms.Button();
            this.ItemDeleteParquetCriterionButton = new System.Windows.Forms.Button();
            this.ItemEntryRequirementsListBox = new System.Windows.Forms.ListBox();
            this.ItemParquetCriteriaListBox = new System.Windows.Forms.ListBox();
            this.ItemIsLiquidBasedCheckBox = new System.Windows.Forms.CheckBox();
            this.ItemIsItemBasedCheckBox = new System.Windows.Forms.CheckBox();
            this.ItemNameLabel = new System.Windows.Forms.Label();
            this.ItemDescriptionLabel = new System.Windows.Forms.Label();
            this.ItemCommentLabel = new System.Windows.Forms.Label();
            this.ItemTierLabel = new System.Windows.Forms.Label();
            this.ItemIsItemBasedLabel = new System.Windows.Forms.Label();
            this.ItemIsLiquidBasedLabel = new System.Windows.Forms.Label();
            this.ItemParquetCriteriaLabel = new System.Windows.Forms.Label();
            this.ItemEntryRequirementsLabel = new System.Windows.Forms.Label();
            this.ItemNameTextBox = new System.Windows.Forms.TextBox();
            this.ItemDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.ItemCommentTextBox = new System.Windows.Forms.TextBox();
            this.ItemTierTextBox = new System.Windows.Forms.TextBox();
            this.ItemPictureBox = new System.Windows.Forms.PictureBox();
            this.ItemIDLabel = new System.Windows.Forms.Label();
            this.ItemAddNewItemButton = new System.Windows.Forms.Button();
            this.ItemIDTextBox = new System.Windows.Forms.TextBox();
            this.MapsTabPage = new System.Windows.Forms.TabPage();
            this.ParquetsTabPage = new System.Windows.Forms.TabPage();
            this.RoomsTabPage = new System.Windows.Forms.TabPage();
            this.RoomAddEntryRequirementButton = new System.Windows.Forms.Button();
            this.RoomDeleteEntryRequirementButton = new System.Windows.Forms.Button();
            this.RoomListBox = new System.Windows.Forms.ListBox();
            this.RoomConfigGroupBox = new System.Windows.Forms.GroupBox();
            this.RoomConfigTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.RoomMinWalkableSpacesLabel = new System.Windows.Forms.Label();
            this.RoomMaxWalkableSpacesLabel = new System.Windows.Forms.Label();
            this.RoomMinWalkableSpacesTextBox = new System.Windows.Forms.TextBox();
            this.RoomMaxWalkableSpacesTextBox = new System.Windows.Forms.TextBox();
            this.RoomPictureEditButton = new System.Windows.Forms.Button();
            this.RoomTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.RoomAddParquetCriterionButton = new System.Windows.Forms.Button();
            this.RoomDeleteParquetCriterionButton = new System.Windows.Forms.Button();
            this.RoomEntryRequirementsListBox = new System.Windows.Forms.ListBox();
            this.RoomParquetCriteriaListBox = new System.Windows.Forms.ListBox();
            this.RoomIsLiquidBasedCheckBox = new System.Windows.Forms.CheckBox();
            this.RoomIsRoomBasedCheckBox = new System.Windows.Forms.CheckBox();
            this.RoomNameLabel = new System.Windows.Forms.Label();
            this.RoomDescriptionLabel = new System.Windows.Forms.Label();
            this.RoomCommentLabel = new System.Windows.Forms.Label();
            this.RoomTierLabel = new System.Windows.Forms.Label();
            this.RoomIsRoomBasedLabel = new System.Windows.Forms.Label();
            this.RoomIsLiquidBasedLabel = new System.Windows.Forms.Label();
            this.RoomParquetCriteriaLabel = new System.Windows.Forms.Label();
            this.RoomEntryRequirementsLabel = new System.Windows.Forms.Label();
            this.RoomNameTextBox = new System.Windows.Forms.TextBox();
            this.RoomDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.RoomCommentTextBox = new System.Windows.Forms.TextBox();
            this.RoomTierTextBox = new System.Windows.Forms.TextBox();
            this.RoomPictureBox = new System.Windows.Forms.PictureBox();
            this.RoomIDLabel = new System.Windows.Forms.Label();
            this.RoomAddNewRoomButton = new System.Windows.Forms.Button();
            this.RoomIDTextBox = new System.Windows.Forms.TextBox();
            this.ScriptsTabPage = new System.Windows.Forms.TabPage();
            this.FiltersTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.FilterTextBox = new System.Windows.Forms.TextBox();
            this.NameFilterCheckBox = new System.Windows.Forms.CheckBox();
            this.StoryIDFilterCheckBox = new System.Windows.Forms.CheckBox();
            this.DescriptionCheckBox = new System.Windows.Forms.CheckBox();
            this.TagsCheckBox = new System.Windows.Forms.CheckBox();
            this.CommentCheckBox = new System.Windows.Forms.CheckBox();
            this.MoreCheckBox = new System.Windows.Forms.CheckBox();
            this.FilterGroupBox = new System.Windows.Forms.GroupBox();
            this.FlavorFilterGroupBox = new System.Windows.Forms.GroupBox();
            this.FlavorTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SavourySelector = new System.Windows.Forms.Label();
            this.MetallicSelector = new System.Windows.Forms.Label();
            this.FreshSelector = new System.Windows.Forms.Label();
            this.PungentSelector = new System.Windows.Forms.Label();
            this.NoFlavorsSelector = new System.Windows.Forms.Label();
            this.ChemicalSelector = new System.Windows.Forms.Label();
            this.AstringentSelector = new System.Windows.Forms.Label();
            this.SweetSelector = new System.Windows.Forms.Label();
            this.BlandSelector = new System.Windows.Forms.Label();
            this.BitterSelector = new System.Windows.Forms.Label();
            this.SourSelector = new System.Windows.Forms.Label();
            this.SaltySelector = new System.Windows.Forms.Label();
            this.NumbingSelector = new System.Windows.Forms.Label();
            this.AllFlavorsSelector = new System.Windows.Forms.Label();
            this.EditorStatusStrip.SuspendLayout();
            this.MainMenuBar.SuspendLayout();
            this.EditorTabs.SuspendLayout();
            this.GameTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GameIconPictureBox)).BeginInit();
            this.GameTableLayoutPanel.SuspendLayout();
            this.FileFormatGroupBox.SuspendLayout();
            this.FileFormatTableLayoutPanel.SuspendLayout();
            this.LibraryInfoGroupBox.SuspendLayout();
            this.LibraryInfoTableLayoutPanel.SuspendLayout();
            this.BiomesTabPage.SuspendLayout();
            this.BiomeConfigGroupBox.SuspendLayout();
            this.BiomeConfigTableLayoutPanel.SuspendLayout();
            this.BiomeTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BiomePictureBox)).BeginInit();
            this.ItemsTabPage.SuspendLayout();
            this.ItemConfigGroupBox.SuspendLayout();
            this.ItemConfigTableLayoutPanel.SuspendLayout();
            this.ItemTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemPictureBox)).BeginInit();
            this.RoomsTabPage.SuspendLayout();
            this.RoomConfigGroupBox.SuspendLayout();
            this.RoomConfigTableLayoutPanel.SuspendLayout();
            this.RoomTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoomPictureBox)).BeginInit();
            this.FiltersTableLayoutPanel.SuspendLayout();
            this.FilterGroupBox.SuspendLayout();
            this.FlavorFilterGroupBox.SuspendLayout();
            this.FlavorTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditorStatusStrip
            // 
            this.EditorStatusStrip.AccessibleDescription = "The status of the application.";
            this.EditorStatusStrip.AccessibleName = "Editor Status";
            this.EditorStatusStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.StatusBar;
            this.EditorStatusStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EditorStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainToolStripStatusLabel,
            this.ToolStripProgressBar});
            this.EditorStatusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.EditorStatusStrip.Location = new System.Drawing.Point(0, 739);
            this.EditorStatusStrip.Name = "EditorStatusStrip";
            this.EditorStatusStrip.Size = new System.Drawing.Size(984, 22);
            this.EditorStatusStrip.SizingGrip = false;
            this.EditorStatusStrip.TabIndex = 0;
            // 
            // MainToolStripStatusLabel
            // 
            this.MainToolStripStatusLabel.Name = "MainToolStripStatusLabel";
            this.MainToolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.MainToolStripStatusLabel.Text = "Ready";
            // 
            // ToolStripProgressBar
            // 
            this.ToolStripProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolStripProgressBar.Name = "ToolStripProgressBar";
            this.ToolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // MainMenuBar
            // 
            this.MainMenuBar.AccessibleDescription = "The application\'s menu.";
            this.MainMenuBar.AccessibleName = "Main Menu";
            this.MainMenuBar.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.MainMenuBar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MainMenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.ToolsToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.MainMenuBar.Location = new System.Drawing.Point(0, 0);
            this.MainMenuBar.Name = "MainMenuBar";
            this.MainMenuBar.Size = new System.Drawing.Size(984, 24);
            this.MainMenuBar.TabIndex = 1;
            this.MainMenuBar.Text = "Main Menu";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewToolStripMenuItem,
            this.LoadToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.ToolStripSeparator1,
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "&File";
            // 
            // NewToolStripMenuItem
            // 
            this.NewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("NewToolStripMenuItem.Image")));
            this.NewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewToolStripMenuItem.Name = "NewToolStripMenuItem";
            this.NewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NewToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.NewToolStripMenuItem.Text = "&New";
            this.NewToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // LoadToolStripMenuItem
            // 
            this.LoadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("LoadToolStripMenuItem.Image")));
            this.LoadToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoadToolStripMenuItem.Name = "LoadToolStripMenuItem";
            this.LoadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.LoadToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.LoadToolStripMenuItem.Text = "&Load";
            this.LoadToolStripMenuItem.Click += new System.EventHandler(this.LoadToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SaveToolStripMenuItem.Image")));
            this.SaveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.SaveToolStripMenuItem.Text = "&Save";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(140, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ExitToolStripMenuItem.Image")));
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.ExitToolStripMenuItem.Text = "E&xit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UndoToolStripMenuItem,
            this.RedoToolStripMenuItem,
            this.ToolStripSeparator2,
            this.CutToolStripMenuItem,
            this.CopyToolStripMenuItem,
            this.PasteToolStripMenuItem,
            this.ToolStripSeparator3,
            this.SelectAllToolStripMenuItem});
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.EditToolStripMenuItem.Text = "&Edit";
            // 
            // UndoToolStripMenuItem
            // 
            this.UndoToolStripMenuItem.Enabled = false;
            this.UndoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("UndoToolStripMenuItem.Image")));
            this.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem";
            this.UndoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.UndoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.UndoToolStripMenuItem.Text = "&Undo";
            this.UndoToolStripMenuItem.Click += new System.EventHandler(this.UndoToolStripMenuItem_Click);
            // 
            // RedoToolStripMenuItem
            // 
            this.RedoToolStripMenuItem.Enabled = false;
            this.RedoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("RedoToolStripMenuItem.Image")));
            this.RedoToolStripMenuItem.Name = "RedoToolStripMenuItem";
            this.RedoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.RedoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.RedoToolStripMenuItem.Text = "&Redo";
            this.RedoToolStripMenuItem.Click += new System.EventHandler(this.RedoToolStripMenuItem_Click);
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(141, 6);
            // 
            // CutToolStripMenuItem
            // 
            this.CutToolStripMenuItem.Enabled = false;
            this.CutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CutToolStripMenuItem.Image")));
            this.CutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CutToolStripMenuItem.Name = "CutToolStripMenuItem";
            this.CutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.CutToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.CutToolStripMenuItem.Text = "Cu&t";
            this.CutToolStripMenuItem.Click += new System.EventHandler(this.CutToolStripMenuItem_Click);
            // 
            // CopyToolStripMenuItem
            // 
            this.CopyToolStripMenuItem.Enabled = false;
            this.CopyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CopyToolStripMenuItem.Image")));
            this.CopyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            this.CopyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.CopyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.CopyToolStripMenuItem.Text = "&Copy";
            this.CopyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // PasteToolStripMenuItem
            // 
            this.PasteToolStripMenuItem.Enabled = false;
            this.PasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("PasteToolStripMenuItem.Image")));
            this.PasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem";
            this.PasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.PasteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.PasteToolStripMenuItem.Text = "&Paste";
            this.PasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
            // 
            // ToolStripSeparator3
            // 
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(141, 6);
            // 
            // SelectAllToolStripMenuItem
            // 
            this.SelectAllToolStripMenuItem.Enabled = false;
            this.SelectAllToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SelectAllToolStripMenuItem.Image")));
            this.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem";
            this.SelectAllToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.SelectAllToolStripMenuItem.Text = "Select &All";
            this.SelectAllToolStripMenuItem.Click += new System.EventHandler(this.SelectAllToolStripMenuItem_Click);
            // 
            // ToolsToolStripMenuItem
            // 
            this.ToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RollerToolStripMenuItem,
            this.ToolStripSeparator5,
            this.OptionsToolStripMenuItem});
            this.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem";
            this.ToolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.ToolsToolStripMenuItem.Text = "&Tools";
            // 
            // RollerToolStripMenuItem
            // 
            this.RollerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CheckMapStripMenuItem,
            this.ListNameCollisionsStripMenuItem,
            this.ToolStripSeparator4,
            this.ListIDRangesToolStripMenuItem,
            this.ListMaxIDsToolStripMenuItem,
            this.ListTagsToolStripMenuItem});
            this.RollerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("RollerToolStripMenuItem.Image")));
            this.RollerToolStripMenuItem.Name = "RollerToolStripMenuItem";
            this.RollerToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.RollerToolStripMenuItem.Text = "&Roller";
            // 
            // CheckMapStripMenuItem
            // 
            this.CheckMapStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CheckMapStripMenuItem.Image")));
            this.CheckMapStripMenuItem.Name = "CheckMapStripMenuItem";
            this.CheckMapStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.CheckMapStripMenuItem.Text = "Check &Map Adjacency";
            this.CheckMapStripMenuItem.Click += new System.EventHandler(this.CheckMapStripMenuItem_Click);
            // 
            // ListNameCollisionsStripMenuItem
            // 
            this.ListNameCollisionsStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ListNameCollisionsStripMenuItem.Image")));
            this.ListNameCollisionsStripMenuItem.Name = "ListNameCollisionsStripMenuItem";
            this.ListNameCollisionsStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.ListNameCollisionsStripMenuItem.Text = "List &Name Collisions";
            this.ListNameCollisionsStripMenuItem.Click += new System.EventHandler(this.ListNameCollisionsStripMenuItem_Click);
            // 
            // ToolStripSeparator4
            // 
            this.ToolStripSeparator4.Name = "ToolStripSeparator4";
            this.ToolStripSeparator4.Size = new System.Drawing.Size(189, 6);
            // 
            // ListIDRangesToolStripMenuItem
            // 
            this.ListIDRangesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ListIDRangesToolStripMenuItem.Image")));
            this.ListIDRangesToolStripMenuItem.Name = "ListIDRangesToolStripMenuItem";
            this.ListIDRangesToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.ListIDRangesToolStripMenuItem.Text = "List ID &Ranges";
            this.ListIDRangesToolStripMenuItem.Click += new System.EventHandler(this.ListIDRangesToolStripMenuItem_Click);
            // 
            // ListMaxIDsToolStripMenuItem
            // 
            this.ListMaxIDsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ListMaxIDsToolStripMenuItem.Image")));
            this.ListMaxIDsToolStripMenuItem.Name = "ListMaxIDsToolStripMenuItem";
            this.ListMaxIDsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.ListMaxIDsToolStripMenuItem.Text = "List Maximum &IDs";
            this.ListMaxIDsToolStripMenuItem.Click += new System.EventHandler(this.ListMaxIDsToolStripMenuItem_Click);
            // 
            // ListTagsToolStripMenuItem
            // 
            this.ListTagsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ListTagsToolStripMenuItem.Image")));
            this.ListTagsToolStripMenuItem.Name = "ListTagsToolStripMenuItem";
            this.ListTagsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.ListTagsToolStripMenuItem.Text = "List &Tags";
            this.ListTagsToolStripMenuItem.Click += new System.EventHandler(this.ListTagsToolStripMenuItem_Click);
            // 
            // ToolStripSeparator5
            // 
            this.ToolStripSeparator5.Name = "ToolStripSeparator5";
            this.ToolStripSeparator5.Size = new System.Drawing.Size(113, 6);
            // 
            // OptionsToolStripMenuItem
            // 
            this.OptionsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("OptionsToolStripMenuItem.Image")));
            this.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem";
            this.OptionsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.OptionsToolStripMenuItem.Text = "&Options";
            this.OptionsToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItem_Click);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ScribeHelpToolStripMenuItem,
            this.DocumentationToolStripMenuItem,
            this.ToolStripSeparator6,
            this.AboutToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.HelpToolStripMenuItem.Text = "&Help";
            // 
            // ScribeHelpToolStripMenuItem
            // 
            this.ScribeHelpToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ScribeHelpToolStripMenuItem.Image")));
            this.ScribeHelpToolStripMenuItem.Name = "ScribeHelpToolStripMenuItem";
            this.ScribeHelpToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.ScribeHelpToolStripMenuItem.Text = "Scribe &Help";
            this.ScribeHelpToolStripMenuItem.Click += new System.EventHandler(this.ScribeHelpToolStripMenuItem_Click);
            // 
            // DocumentationToolStripMenuItem
            // 
            this.DocumentationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("DocumentationToolStripMenuItem.Image")));
            this.DocumentationToolStripMenuItem.Name = "DocumentationToolStripMenuItem";
            this.DocumentationToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.DocumentationToolStripMenuItem.Text = "Parquet &Documentation";
            this.DocumentationToolStripMenuItem.Click += new System.EventHandler(this.DocumentationToolStripMenuItem_Click);
            // 
            // ToolStripSeparator6
            // 
            this.ToolStripSeparator6.Name = "ToolStripSeparator6";
            this.ToolStripSeparator6.Size = new System.Drawing.Size(198, 6);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("AboutToolStripMenuItem.Image")));
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.AboutToolStripMenuItem.Text = "&About...";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // EditorTabs
            // 
            this.EditorTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EditorTabs.Controls.Add(this.GameTabPage);
            this.EditorTabs.Controls.Add(this.BeingsTabPage);
            this.EditorTabs.Controls.Add(this.BiomesTabPage);
            this.EditorTabs.Controls.Add(this.CraftingTabPage);
            this.EditorTabs.Controls.Add(this.ItemsTabPage);
            this.EditorTabs.Controls.Add(this.MapsTabPage);
            this.EditorTabs.Controls.Add(this.ParquetsTabPage);
            this.EditorTabs.Controls.Add(this.RoomsTabPage);
            this.EditorTabs.Controls.Add(this.ScriptsTabPage);
            this.EditorTabs.Location = new System.Drawing.Point(12, 111);
            this.EditorTabs.Name = "EditorTabs";
            this.EditorTabs.SelectedIndex = 9;
            this.EditorTabs.Size = new System.Drawing.Size(960, 625);
            this.EditorTabs.TabIndex = 2;
            // 
            // GameTabPage
            // 
            this.GameTabPage.Controls.Add(this.GameIconEditButton);
            this.GameTabPage.Controls.Add(this.GameIconPictureBox);
            this.GameTabPage.Controls.Add(this.GameTableLayoutPanel);
            this.GameTabPage.Controls.Add(this.GameIDLabel);
            this.GameTabPage.Controls.Add(this.GameIDTextBox);
            this.GameTabPage.Controls.Add(this.NewGameButton);
            this.GameTabPage.Controls.Add(this.GamesListBox);
            this.GameTabPage.Controls.Add(this.FileFormatGroupBox);
            this.GameTabPage.Controls.Add(this.LibraryInfoGroupBox);
            this.GameTabPage.Location = new System.Drawing.Point(4, 22);
            this.GameTabPage.Name = "GameTabPage";
            this.GameTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.GameTabPage.Size = new System.Drawing.Size(952, 599);
            this.GameTabPage.TabIndex = 0;
            this.GameTabPage.Text = "Game";
            // 
            // GameIconEditButton
            // 
            this.GameIconEditButton.Location = new System.Drawing.Point(812, 468);
            this.GameIconEditButton.Name = "GameIconEditButton";
            this.GameIconEditButton.Size = new System.Drawing.Size(128, 23);
            this.GameIconEditButton.TabIndex = 7;
            this.GameIconEditButton.Text = "Edit Image";
            this.GameIconEditButton.UseVisualStyleBackColor = true;
            // 
            // GameIconPictureBox
            // 
            this.GameIconPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GameIconPictureBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.GameIconPictureBox.Location = new System.Drawing.Point(758, 280);
            this.GameIconPictureBox.Name = "GameIconPictureBox";
            this.GameIconPictureBox.Size = new System.Drawing.Size(182, 182);
            this.GameIconPictureBox.TabIndex = 6;
            this.GameIconPictureBox.TabStop = false;
            // 
            // GameTableLayoutPanel
            // 
            this.GameTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GameTableLayoutPanel.ColumnCount = 2;
            this.GameTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.GameTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.GameTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.GameTableLayoutPanel.Controls.Add(this.GameNameLabel, 0, 0);
            this.GameTableLayoutPanel.Controls.Add(this.GameDescriptionLabel, 0, 1);
            this.GameTableLayoutPanel.Controls.Add(this.GameCommentLabel, 0, 2);
            this.GameTableLayoutPanel.Controls.Add(this.GameIsEpisodeLabel, 0, 3);
            this.GameTableLayoutPanel.Controls.Add(this.GameEpisodeTitleLabel, 0, 4);
            this.GameTableLayoutPanel.Controls.Add(this.GameEpisodeNumberLabel, 0, 5);
            this.GameTableLayoutPanel.Controls.Add(this.GamePlayerCharacterLabel, 0, 6);
            this.GameTableLayoutPanel.Controls.Add(this.GameFirstScriptLabel, 0, 7);
            this.GameTableLayoutPanel.Controls.Add(this.GameIsEpisodeCheckBox, 1, 3);
            this.GameTableLayoutPanel.Controls.Add(this.GameNameTextBox, 1, 0);
            this.GameTableLayoutPanel.Controls.Add(this.GameDescriptionTextBox, 1, 1);
            this.GameTableLayoutPanel.Controls.Add(this.GameCommentTextBox, 1, 2);
            this.GameTableLayoutPanel.Controls.Add(this.GameEpisodeTitleTextBox, 1, 4);
            this.GameTableLayoutPanel.Controls.Add(this.GameEpisodeNumberTextBox, 1, 5);
            this.GameTableLayoutPanel.Controls.Add(this.GamePlayerCharacterTextBox, 1, 6);
            this.GameTableLayoutPanel.Controls.Add(this.GameFirstScriptTextBox, 1, 7);
            this.GameTableLayoutPanel.Location = new System.Drawing.Point(307, 16);
            this.GameTableLayoutPanel.Name = "GameTableLayoutPanel";
            this.GameTableLayoutPanel.RowCount = 9;
            this.GameTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.GameTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.GameTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.GameTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.GameTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.GameTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.GameTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.GameTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.GameTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.GameTableLayoutPanel.Size = new System.Drawing.Size(429, 446);
            this.GameTableLayoutPanel.TabIndex = 5;
            // 
            // GameNameLabel
            // 
            this.GameNameLabel.AutoSize = true;
            this.GameNameLabel.Location = new System.Drawing.Point(3, 0);
            this.GameNameLabel.Name = "GameNameLabel";
            this.GameNameLabel.Size = new System.Drawing.Size(34, 13);
            this.GameNameLabel.TabIndex = 0;
            this.GameNameLabel.Text = "Name";
            // 
            // GameDescriptionLabel
            // 
            this.GameDescriptionLabel.AutoSize = true;
            this.GameDescriptionLabel.Location = new System.Drawing.Point(3, 25);
            this.GameDescriptionLabel.Name = "GameDescriptionLabel";
            this.GameDescriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.GameDescriptionLabel.TabIndex = 3;
            this.GameDescriptionLabel.Text = "Description";
            // 
            // GameCommentLabel
            // 
            this.GameCommentLabel.AutoSize = true;
            this.GameCommentLabel.Location = new System.Drawing.Point(3, 80);
            this.GameCommentLabel.Name = "GameCommentLabel";
            this.GameCommentLabel.Size = new System.Drawing.Size(52, 13);
            this.GameCommentLabel.TabIndex = 6;
            this.GameCommentLabel.Text = "Comment";
            // 
            // GameIsEpisodeLabel
            // 
            this.GameIsEpisodeLabel.AutoSize = true;
            this.GameIsEpisodeLabel.Location = new System.Drawing.Point(3, 135);
            this.GameIsEpisodeLabel.Name = "GameIsEpisodeLabel";
            this.GameIsEpisodeLabel.Size = new System.Drawing.Size(61, 13);
            this.GameIsEpisodeLabel.TabIndex = 9;
            this.GameIsEpisodeLabel.Text = "Is Episode?";
            // 
            // GameEpisodeTitleLabel
            // 
            this.GameEpisodeTitleLabel.AutoSize = true;
            this.GameEpisodeTitleLabel.Location = new System.Drawing.Point(3, 160);
            this.GameEpisodeTitleLabel.Name = "GameEpisodeTitleLabel";
            this.GameEpisodeTitleLabel.Size = new System.Drawing.Size(67, 13);
            this.GameEpisodeTitleLabel.TabIndex = 12;
            this.GameEpisodeTitleLabel.Text = "Episode Title";
            // 
            // GameEpisodeNumberLabel
            // 
            this.GameEpisodeNumberLabel.AutoSize = true;
            this.GameEpisodeNumberLabel.Location = new System.Drawing.Point(3, 185);
            this.GameEpisodeNumberLabel.Name = "GameEpisodeNumberLabel";
            this.GameEpisodeNumberLabel.Size = new System.Drawing.Size(84, 13);
            this.GameEpisodeNumberLabel.TabIndex = 15;
            this.GameEpisodeNumberLabel.Text = "Episode Number";
            // 
            // GamePlayerCharacterLabel
            // 
            this.GamePlayerCharacterLabel.AutoSize = true;
            this.GamePlayerCharacterLabel.Location = new System.Drawing.Point(3, 210);
            this.GamePlayerCharacterLabel.Name = "GamePlayerCharacterLabel";
            this.GamePlayerCharacterLabel.Size = new System.Drawing.Size(88, 13);
            this.GamePlayerCharacterLabel.TabIndex = 18;
            this.GamePlayerCharacterLabel.Text = "Player Character";
            // 
            // GameFirstScriptLabel
            // 
            this.GameFirstScriptLabel.AutoSize = true;
            this.GameFirstScriptLabel.Location = new System.Drawing.Point(3, 235);
            this.GameFirstScriptLabel.Name = "GameFirstScriptLabel";
            this.GameFirstScriptLabel.Size = new System.Drawing.Size(58, 13);
            this.GameFirstScriptLabel.TabIndex = 21;
            this.GameFirstScriptLabel.Text = "First Script";
            // 
            // GameIsEpisodeCheckBox
            // 
            this.GameIsEpisodeCheckBox.AutoSize = true;
            this.GameIsEpisodeCheckBox.Location = new System.Drawing.Point(131, 138);
            this.GameIsEpisodeCheckBox.Name = "GameIsEpisodeCheckBox";
            this.GameIsEpisodeCheckBox.Size = new System.Drawing.Size(15, 14);
            this.GameIsEpisodeCheckBox.TabIndex = 22;
            this.GameIsEpisodeCheckBox.UseVisualStyleBackColor = true;
            // 
            // GameNameTextBox
            // 
            this.GameNameTextBox.Location = new System.Drawing.Point(131, 3);
            this.GameNameTextBox.Name = "GameNameTextBox";
            this.GameNameTextBox.Size = new System.Drawing.Size(147, 20);
            this.GameNameTextBox.TabIndex = 23;
            // 
            // GameDescriptionTextBox
            // 
            this.GameDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GameDescriptionTextBox.Location = new System.Drawing.Point(131, 28);
            this.GameDescriptionTextBox.Multiline = true;
            this.GameDescriptionTextBox.Name = "GameDescriptionTextBox";
            this.GameDescriptionTextBox.Size = new System.Drawing.Size(295, 49);
            this.GameDescriptionTextBox.TabIndex = 24;
            // 
            // GameCommentTextBox
            // 
            this.GameCommentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GameCommentTextBox.Location = new System.Drawing.Point(131, 83);
            this.GameCommentTextBox.Multiline = true;
            this.GameCommentTextBox.Name = "GameCommentTextBox";
            this.GameCommentTextBox.Size = new System.Drawing.Size(295, 49);
            this.GameCommentTextBox.TabIndex = 25;
            // 
            // GameEpisodeTitleTextBox
            // 
            this.GameEpisodeTitleTextBox.Location = new System.Drawing.Point(131, 163);
            this.GameEpisodeTitleTextBox.Name = "GameEpisodeTitleTextBox";
            this.GameEpisodeTitleTextBox.Size = new System.Drawing.Size(147, 20);
            this.GameEpisodeTitleTextBox.TabIndex = 26;
            // 
            // GameEpisodeNumberTextBox
            // 
            this.GameEpisodeNumberTextBox.Location = new System.Drawing.Point(131, 188);
            this.GameEpisodeNumberTextBox.Name = "GameEpisodeNumberTextBox";
            this.GameEpisodeNumberTextBox.Size = new System.Drawing.Size(147, 20);
            this.GameEpisodeNumberTextBox.TabIndex = 27;
            // 
            // GamePlayerCharacterTextBox
            // 
            this.GamePlayerCharacterTextBox.Location = new System.Drawing.Point(131, 213);
            this.GamePlayerCharacterTextBox.Name = "GamePlayerCharacterTextBox";
            this.GamePlayerCharacterTextBox.Size = new System.Drawing.Size(147, 20);
            this.GamePlayerCharacterTextBox.TabIndex = 28;
            // 
            // GameFirstScriptTextBox
            // 
            this.GameFirstScriptTextBox.Location = new System.Drawing.Point(131, 238);
            this.GameFirstScriptTextBox.Name = "GameFirstScriptTextBox";
            this.GameFirstScriptTextBox.Size = new System.Drawing.Size(147, 20);
            this.GameFirstScriptTextBox.TabIndex = 29;
            // 
            // GameIDLabel
            // 
            this.GameIDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GameIDLabel.AutoSize = true;
            this.GameIDLabel.Location = new System.Drawing.Point(758, 19);
            this.GameIDLabel.Name = "GameIDLabel";
            this.GameIDLabel.Size = new System.Drawing.Size(48, 13);
            this.GameIDLabel.TabIndex = 4;
            this.GameIDLabel.Text = "Game ID";
            // 
            // GameIDTextBox
            // 
            this.GameIDTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GameIDTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.GameIDTextBox.Location = new System.Drawing.Point(812, 16);
            this.GameIDTextBox.Name = "GameIDTextBox";
            this.GameIDTextBox.Size = new System.Drawing.Size(131, 20);
            this.GameIDTextBox.TabIndex = 3;
            this.GameIDTextBox.Text = "-2020202020";
            // 
            // NewGameButton
            // 
            this.NewGameButton.Location = new System.Drawing.Point(159, 468);
            this.NewGameButton.Name = "NewGameButton";
            this.NewGameButton.Size = new System.Drawing.Size(129, 23);
            this.NewGameButton.TabIndex = 2;
            this.NewGameButton.Text = "Add New Game";
            this.NewGameButton.UseVisualStyleBackColor = true;
            // 
            // GamesListBox
            // 
            this.GamesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GamesListBox.FormattingEnabled = true;
            this.GamesListBox.Location = new System.Drawing.Point(9, 16);
            this.GamesListBox.Name = "GamesListBox";
            this.GamesListBox.Size = new System.Drawing.Size(279, 446);
            this.GamesListBox.TabIndex = 1;
            // 
            // FileFormatGroupBox
            // 
            this.FileFormatGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileFormatGroupBox.Controls.Add(this.FileFormatTableLayoutPanel);
            this.FileFormatGroupBox.Location = new System.Drawing.Point(301, 499);
            this.FileFormatGroupBox.Name = "FileFormatGroupBox";
            this.FileFormatGroupBox.Size = new System.Drawing.Size(645, 97);
            this.FileFormatGroupBox.TabIndex = 0;
            this.FileFormatGroupBox.TabStop = false;
            this.FileFormatGroupBox.Text = "File Format";
            // 
            // FileFormatTableLayoutPanel
            // 
            this.FileFormatTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileFormatTableLayoutPanel.ColumnCount = 6;
            this.FileFormatTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.83792F));
            this.FileFormatTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.495411F));
            this.FileFormatTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.83792F));
            this.FileFormatTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.495411F));
            this.FileFormatTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.83792F));
            this.FileFormatTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.495411F));
            this.FileFormatTableLayoutPanel.Controls.Add(this.PrimaryDelimiterLabel, 0, 0);
            this.FileFormatTableLayoutPanel.Controls.Add(this.PrimaryDelimiterExample, 1, 0);
            this.FileFormatTableLayoutPanel.Controls.Add(this.SecondaryDelimiterLabel, 2, 0);
            this.FileFormatTableLayoutPanel.Controls.Add(this.SecondaryDelimiterExample, 3, 0);
            this.FileFormatTableLayoutPanel.Controls.Add(this.InternalDelimiterLabel, 4, 0);
            this.FileFormatTableLayoutPanel.Controls.Add(this.InternalDelimiterExample, 5, 0);
            this.FileFormatTableLayoutPanel.Controls.Add(this.ElementDelimiterLabel, 0, 1);
            this.FileFormatTableLayoutPanel.Controls.Add(this.ElementDelimiterExample, 1, 1);
            this.FileFormatTableLayoutPanel.Controls.Add(this.NameDelimiterLabel, 2, 1);
            this.FileFormatTableLayoutPanel.Controls.Add(this.NameDelimiterExample, 3, 1);
            this.FileFormatTableLayoutPanel.Controls.Add(this.PronounDelimiterLabel, 4, 1);
            this.FileFormatTableLayoutPanel.Controls.Add(this.PronounDelimiterExample, 5, 1);
            this.FileFormatTableLayoutPanel.Controls.Add(this.DimensionalDelimiterLabel, 0, 2);
            this.FileFormatTableLayoutPanel.Controls.Add(this.DimensionalDelimiterExample, 1, 2);
            this.FileFormatTableLayoutPanel.Controls.Add(this.DimensionalTerminatorLabel, 2, 2);
            this.FileFormatTableLayoutPanel.Controls.Add(this.DimensionalTerminatorExample, 3, 2);
            this.FileFormatTableLayoutPanel.Location = new System.Drawing.Point(6, 19);
            this.FileFormatTableLayoutPanel.Name = "FileFormatTableLayoutPanel";
            this.FileFormatTableLayoutPanel.RowCount = 3;
            this.FileFormatTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.FileFormatTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.FileFormatTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.FileFormatTableLayoutPanel.Size = new System.Drawing.Size(633, 72);
            this.FileFormatTableLayoutPanel.TabIndex = 1;
            // 
            // PrimaryDelimiterLabel
            // 
            this.PrimaryDelimiterLabel.AutoSize = true;
            this.PrimaryDelimiterLabel.Location = new System.Drawing.Point(50, 5);
            this.PrimaryDelimiterLabel.Margin = new System.Windows.Forms.Padding(50, 5, 3, 0);
            this.PrimaryDelimiterLabel.Name = "PrimaryDelimiterLabel";
            this.PrimaryDelimiterLabel.Size = new System.Drawing.Size(87, 13);
            this.PrimaryDelimiterLabel.TabIndex = 0;
            this.PrimaryDelimiterLabel.Text = "Primary Delimiter";
            // 
            // PrimaryDelimiterExample
            // 
            this.PrimaryDelimiterExample.AutoSize = true;
            this.PrimaryDelimiterExample.Location = new System.Drawing.Point(179, 5);
            this.PrimaryDelimiterExample.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.PrimaryDelimiterExample.Name = "PrimaryDelimiterExample";
            this.PrimaryDelimiterExample.Size = new System.Drawing.Size(11, 13);
            this.PrimaryDelimiterExample.TabIndex = 1;
            this.PrimaryDelimiterExample.Text = ",";
            // 
            // SecondaryDelimiterLabel
            // 
            this.SecondaryDelimiterLabel.AutoSize = true;
            this.SecondaryDelimiterLabel.Location = new System.Drawing.Point(260, 5);
            this.SecondaryDelimiterLabel.Margin = new System.Windows.Forms.Padding(50, 5, 3, 0);
            this.SecondaryDelimiterLabel.Name = "SecondaryDelimiterLabel";
            this.SecondaryDelimiterLabel.Size = new System.Drawing.Size(102, 13);
            this.SecondaryDelimiterLabel.TabIndex = 2;
            this.SecondaryDelimiterLabel.Text = "Secondary Delimiter";
            // 
            // SecondaryDelimiterExample
            // 
            this.SecondaryDelimiterExample.AutoSize = true;
            this.SecondaryDelimiterExample.Location = new System.Drawing.Point(389, 5);
            this.SecondaryDelimiterExample.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.SecondaryDelimiterExample.Name = "SecondaryDelimiterExample";
            this.SecondaryDelimiterExample.Size = new System.Drawing.Size(18, 13);
            this.SecondaryDelimiterExample.TabIndex = 3;
            this.SecondaryDelimiterExample.Text = "∟";
            // 
            // InternalDelimiterLabel
            // 
            this.InternalDelimiterLabel.AutoSize = true;
            this.InternalDelimiterLabel.Location = new System.Drawing.Point(470, 5);
            this.InternalDelimiterLabel.Margin = new System.Windows.Forms.Padding(50, 5, 3, 0);
            this.InternalDelimiterLabel.Name = "InternalDelimiterLabel";
            this.InternalDelimiterLabel.Size = new System.Drawing.Size(89, 13);
            this.InternalDelimiterLabel.TabIndex = 4;
            this.InternalDelimiterLabel.Text = "Internal Delimiter";
            // 
            // InternalDelimiterExample
            // 
            this.InternalDelimiterExample.AutoSize = true;
            this.InternalDelimiterExample.Location = new System.Drawing.Point(599, 5);
            this.InternalDelimiterExample.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.InternalDelimiterExample.Name = "InternalDelimiterExample";
            this.InternalDelimiterExample.Size = new System.Drawing.Size(11, 13);
            this.InternalDelimiterExample.TabIndex = 5;
            this.InternalDelimiterExample.Text = "·";
            // 
            // ElementDelimiterLabel
            // 
            this.ElementDelimiterLabel.AutoSize = true;
            this.ElementDelimiterLabel.Location = new System.Drawing.Point(50, 28);
            this.ElementDelimiterLabel.Margin = new System.Windows.Forms.Padding(50, 5, 3, 0);
            this.ElementDelimiterLabel.Name = "ElementDelimiterLabel";
            this.ElementDelimiterLabel.Size = new System.Drawing.Size(89, 13);
            this.ElementDelimiterLabel.TabIndex = 6;
            this.ElementDelimiterLabel.Text = "Element Delimiter";
            // 
            // ElementDelimiterExample
            // 
            this.ElementDelimiterExample.AutoSize = true;
            this.ElementDelimiterExample.Location = new System.Drawing.Point(179, 28);
            this.ElementDelimiterExample.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.ElementDelimiterExample.Name = "ElementDelimiterExample";
            this.ElementDelimiterExample.Size = new System.Drawing.Size(13, 13);
            this.ElementDelimiterExample.TabIndex = 7;
            this.ElementDelimiterExample.Text = "–";
            // 
            // NameDelimiterLabel
            // 
            this.NameDelimiterLabel.AutoSize = true;
            this.NameDelimiterLabel.Location = new System.Drawing.Point(260, 28);
            this.NameDelimiterLabel.Margin = new System.Windows.Forms.Padding(50, 5, 3, 0);
            this.NameDelimiterLabel.Name = "NameDelimiterLabel";
            this.NameDelimiterLabel.Size = new System.Drawing.Size(78, 13);
            this.NameDelimiterLabel.TabIndex = 8;
            this.NameDelimiterLabel.Text = "Name Delimiter";
            // 
            // NameDelimiterExample
            // 
            this.NameDelimiterExample.AutoSize = true;
            this.NameDelimiterExample.Location = new System.Drawing.Point(389, 28);
            this.NameDelimiterExample.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.NameDelimiterExample.Name = "NameDelimiterExample";
            this.NameDelimiterExample.Size = new System.Drawing.Size(13, 13);
            this.NameDelimiterExample.TabIndex = 9;
            this.NameDelimiterExample.Text = "§";
            // 
            // PronounDelimiterLabel
            // 
            this.PronounDelimiterLabel.AutoSize = true;
            this.PronounDelimiterLabel.Location = new System.Drawing.Point(470, 28);
            this.PronounDelimiterLabel.Margin = new System.Windows.Forms.Padding(50, 5, 3, 0);
            this.PronounDelimiterLabel.Name = "PronounDelimiterLabel";
            this.PronounDelimiterLabel.Size = new System.Drawing.Size(91, 13);
            this.PronounDelimiterLabel.TabIndex = 10;
            this.PronounDelimiterLabel.Text = "Pronoun Delimiter";
            // 
            // PronounDelimiterExample
            // 
            this.PronounDelimiterExample.AutoSize = true;
            this.PronounDelimiterExample.Location = new System.Drawing.Point(599, 28);
            this.PronounDelimiterExample.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.PronounDelimiterExample.Name = "PronounDelimiterExample";
            this.PronounDelimiterExample.Size = new System.Drawing.Size(11, 13);
            this.PronounDelimiterExample.TabIndex = 11;
            this.PronounDelimiterExample.Text = "|";
            // 
            // DimensionalDelimiterLabel
            // 
            this.DimensionalDelimiterLabel.AutoSize = true;
            this.DimensionalDelimiterLabel.Location = new System.Drawing.Point(50, 51);
            this.DimensionalDelimiterLabel.Margin = new System.Windows.Forms.Padding(50, 5, 3, 0);
            this.DimensionalDelimiterLabel.Name = "DimensionalDelimiterLabel";
            this.DimensionalDelimiterLabel.Size = new System.Drawing.Size(107, 13);
            this.DimensionalDelimiterLabel.TabIndex = 12;
            this.DimensionalDelimiterLabel.Text = "Dimensional Delimiter";
            // 
            // DimensionalDelimiterExample
            // 
            this.DimensionalDelimiterExample.AutoSize = true;
            this.DimensionalDelimiterExample.Location = new System.Drawing.Point(179, 51);
            this.DimensionalDelimiterExample.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.DimensionalDelimiterExample.Name = "DimensionalDelimiterExample";
            this.DimensionalDelimiterExample.Size = new System.Drawing.Size(15, 13);
            this.DimensionalDelimiterExample.TabIndex = 13;
            this.DimensionalDelimiterExample.Text = "×";
            // 
            // DimensionalTerminatorLabel
            // 
            this.DimensionalTerminatorLabel.AutoSize = true;
            this.DimensionalTerminatorLabel.Location = new System.Drawing.Point(260, 51);
            this.DimensionalTerminatorLabel.Margin = new System.Windows.Forms.Padding(50, 5, 3, 0);
            this.DimensionalTerminatorLabel.Name = "DimensionalTerminatorLabel";
            this.DimensionalTerminatorLabel.Size = new System.Drawing.Size(118, 13);
            this.DimensionalTerminatorLabel.TabIndex = 14;
            this.DimensionalTerminatorLabel.Text = "Dimensional Terminator";
            // 
            // DimensionalTerminatorExample
            // 
            this.DimensionalTerminatorExample.AutoSize = true;
            this.DimensionalTerminatorExample.Location = new System.Drawing.Point(389, 51);
            this.DimensionalTerminatorExample.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.DimensionalTerminatorExample.Name = "DimensionalTerminatorExample";
            this.DimensionalTerminatorExample.Size = new System.Drawing.Size(15, 13);
            this.DimensionalTerminatorExample.TabIndex = 15;
            this.DimensionalTerminatorExample.Text = "≡";
            // 
            // LibraryInfoGroupBox
            // 
            this.LibraryInfoGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LibraryInfoGroupBox.Controls.Add(this.LibraryInfoTableLayoutPanel);
            this.LibraryInfoGroupBox.Location = new System.Drawing.Point(6, 496);
            this.LibraryInfoGroupBox.Name = "LibraryInfoGroupBox";
            this.LibraryInfoGroupBox.Size = new System.Drawing.Size(289, 100);
            this.LibraryInfoGroupBox.TabIndex = 0;
            this.LibraryInfoGroupBox.TabStop = false;
            this.LibraryInfoGroupBox.Text = "Library Info";
            // 
            // LibraryInfoTableLayoutPanel
            // 
            this.LibraryInfoTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LibraryInfoTableLayoutPanel.ColumnCount = 2;
            this.LibraryInfoTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.LibraryInfoTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.LibraryInfoTableLayoutPanel.Controls.Add(this.VersionLabel, 0, 0);
            this.LibraryInfoTableLayoutPanel.Controls.Add(this.VersionExample, 1, 0);
            this.LibraryInfoTableLayoutPanel.Controls.Add(this.WorkingDirectoryLabel, 2, 0);
            this.LibraryInfoTableLayoutPanel.Controls.Add(this.WorkingDirectoryExample, 3, 0);
            this.LibraryInfoTableLayoutPanel.Location = new System.Drawing.Point(6, 19);
            this.LibraryInfoTableLayoutPanel.Name = "LibraryInfoTableLayoutPanel";
            this.LibraryInfoTableLayoutPanel.RowCount = 2;
            this.LibraryInfoTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LibraryInfoTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LibraryInfoTableLayoutPanel.Size = new System.Drawing.Size(277, 75);
            this.LibraryInfoTableLayoutPanel.TabIndex = 0;
            // 
            // VersionLabel
            // 
            this.VersionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Location = new System.Drawing.Point(1, 1);
            this.VersionLabel.Margin = new System.Windows.Forms.Padding(1);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(67, 35);
            this.VersionLabel.TabIndex = 0;
            this.VersionLabel.Text = "Version";
            // 
            // VersionExample
            // 
            this.VersionExample.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VersionExample.AutoSize = true;
            this.VersionExample.Location = new System.Drawing.Point(70, 1);
            this.VersionExample.Margin = new System.Windows.Forms.Padding(1);
            this.VersionExample.Name = "VersionExample";
            this.VersionExample.Size = new System.Drawing.Size(206, 35);
            this.VersionExample.TabIndex = 1;
            this.VersionExample.Text = "0.0.0";
            // 
            // WorkingDirectoryLabel
            // 
            this.WorkingDirectoryLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WorkingDirectoryLabel.AutoSize = true;
            this.WorkingDirectoryLabel.Location = new System.Drawing.Point(1, 38);
            this.WorkingDirectoryLabel.Margin = new System.Windows.Forms.Padding(1);
            this.WorkingDirectoryLabel.Name = "WorkingDirectoryLabel";
            this.WorkingDirectoryLabel.Size = new System.Drawing.Size(67, 36);
            this.WorkingDirectoryLabel.TabIndex = 0;
            this.WorkingDirectoryLabel.Text = "Working Directory";
            // 
            // WorkingDirectoryExample
            // 
            this.WorkingDirectoryExample.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WorkingDirectoryExample.AutoSize = true;
            this.WorkingDirectoryExample.Location = new System.Drawing.Point(70, 38);
            this.WorkingDirectoryExample.Margin = new System.Windows.Forms.Padding(1);
            this.WorkingDirectoryExample.Name = "WorkingDirectoryExample";
            this.WorkingDirectoryExample.Size = new System.Drawing.Size(206, 36);
            this.WorkingDirectoryExample.TabIndex = 1;
            this.WorkingDirectoryExample.Text = "C:\\";
            // 
            // BeingsTabPage
            // 
            this.BeingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.BeingsTabPage.Name = "BeingsTabPage";
            this.BeingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.BeingsTabPage.Size = new System.Drawing.Size(952, 599);
            this.BeingsTabPage.TabIndex = 1;
            this.BeingsTabPage.Text = "Beings";
            // 
            // BiomesTabPage
            // 
            this.BiomesTabPage.BackColor = System.Drawing.Color.Transparent;
            this.BiomesTabPage.Controls.Add(this.BiomeAddEntryRequirementButton);
            this.BiomesTabPage.Controls.Add(this.BiomeDeleteEntryRequirementButton);
            this.BiomesTabPage.Controls.Add(this.BiomeListBox);
            this.BiomesTabPage.Controls.Add(this.BiomeConfigGroupBox);
            this.BiomesTabPage.Controls.Add(this.BiomePictureEditButton);
            this.BiomesTabPage.Controls.Add(this.BiomeTableLayoutPanel);
            this.BiomesTabPage.Controls.Add(this.BiomePictureBox);
            this.BiomesTabPage.Controls.Add(this.BiomeIDLabel);
            this.BiomesTabPage.Controls.Add(this.BiomeAddNewBiomeButton);
            this.BiomesTabPage.Controls.Add(this.BiomeIDTextBox);
            this.BiomesTabPage.Location = new System.Drawing.Point(4, 22);
            this.BiomesTabPage.Name = "BiomesTabPage";
            this.BiomesTabPage.Size = new System.Drawing.Size(952, 599);
            this.BiomesTabPage.TabIndex = 2;
            this.BiomesTabPage.Text = "Biomes";
            // 
            // BiomeAddEntryRequirementButton
            // 
            this.BiomeAddEntryRequirementButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BiomeAddEntryRequirementButton.Location = new System.Drawing.Point(604, 468);
            this.BiomeAddEntryRequirementButton.Name = "BiomeAddEntryRequirementButton";
            this.BiomeAddEntryRequirementButton.Size = new System.Drawing.Size(129, 23);
            this.BiomeAddEntryRequirementButton.TabIndex = 2;
            this.BiomeAddEntryRequirementButton.Text = "Add Requirement";
            this.BiomeAddEntryRequirementButton.UseVisualStyleBackColor = true;
            // 
            // BiomeDeleteEntryRequirementButton
            // 
            this.BiomeDeleteEntryRequirementButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BiomeDeleteEntryRequirementButton.Location = new System.Drawing.Point(453, 468);
            this.BiomeDeleteEntryRequirementButton.Name = "BiomeDeleteEntryRequirementButton";
            this.BiomeDeleteEntryRequirementButton.Size = new System.Drawing.Size(129, 23);
            this.BiomeDeleteEntryRequirementButton.TabIndex = 2;
            this.BiomeDeleteEntryRequirementButton.Text = "Remove Requirement";
            this.BiomeDeleteEntryRequirementButton.UseVisualStyleBackColor = true;
            // 
            // BiomeListBox
            // 
            this.BiomeListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BiomeListBox.FormattingEnabled = true;
            this.BiomeListBox.Location = new System.Drawing.Point(9, 16);
            this.BiomeListBox.Name = "BiomeListBox";
            this.BiomeListBox.Size = new System.Drawing.Size(279, 446);
            this.BiomeListBox.TabIndex = 1;
            // 
            // BiomeConfigGroupBox
            // 
            this.BiomeConfigGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BiomeConfigGroupBox.Controls.Add(this.BiomeConfigTableLayoutPanel);
            this.BiomeConfigGroupBox.Location = new System.Drawing.Point(9, 499);
            this.BiomeConfigGroupBox.Name = "BiomeConfigGroupBox";
            this.BiomeConfigGroupBox.Size = new System.Drawing.Size(937, 97);
            this.BiomeConfigGroupBox.TabIndex = 0;
            this.BiomeConfigGroupBox.TabStop = false;
            this.BiomeConfigGroupBox.Text = "Configuration";
            // 
            // BiomeConfigTableLayoutPanel
            // 
            this.BiomeConfigTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BiomeConfigTableLayoutPanel.ColumnCount = 3;
            this.BiomeConfigTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.BiomeConfigTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.BiomeConfigTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.BiomeConfigTableLayoutPanel.Controls.Add(this.BiomeLandThresholdFactorLabel, 0, 0);
            this.BiomeConfigTableLayoutPanel.Controls.Add(this.BiomeLiquidThresholdFactorLabel, 0, 1);
            this.BiomeConfigTableLayoutPanel.Controls.Add(this.BiomeLandThresholdTextBox, 1, 0);
            this.BiomeConfigTableLayoutPanel.Controls.Add(this.BiomeLiquidThresholdFactorTextBox, 1, 1);
            this.BiomeConfigTableLayoutPanel.Controls.Add(this.BiomeRoomThresholdFactorTextBox, 1, 2);
            this.BiomeConfigTableLayoutPanel.Controls.Add(this.BiomeRoomThresholdFactorLabel, 0, 2);
            this.BiomeConfigTableLayoutPanel.Location = new System.Drawing.Point(6, 19);
            this.BiomeConfigTableLayoutPanel.Name = "BiomeConfigTableLayoutPanel";
            this.BiomeConfigTableLayoutPanel.RowCount = 3;
            this.BiomeConfigTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.BiomeConfigTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.BiomeConfigTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.BiomeConfigTableLayoutPanel.Size = new System.Drawing.Size(925, 72);
            this.BiomeConfigTableLayoutPanel.TabIndex = 1;
            // 
            // BiomeLandThresholdFactorLabel
            // 
            this.BiomeLandThresholdFactorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BiomeLandThresholdFactorLabel.AutoSize = true;
            this.BiomeLandThresholdFactorLabel.Location = new System.Drawing.Point(21, 0);
            this.BiomeLandThresholdFactorLabel.Name = "BiomeLandThresholdFactorLabel";
            this.BiomeLandThresholdFactorLabel.Size = new System.Drawing.Size(114, 23);
            this.BiomeLandThresholdFactorLabel.TabIndex = 0;
            this.BiomeLandThresholdFactorLabel.Text = "Land Threshold Factor";
            // 
            // BiomeLiquidThresholdFactorLabel
            // 
            this.BiomeLiquidThresholdFactorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BiomeLiquidThresholdFactorLabel.AutoSize = true;
            this.BiomeLiquidThresholdFactorLabel.Location = new System.Drawing.Point(17, 23);
            this.BiomeLiquidThresholdFactorLabel.Name = "BiomeLiquidThresholdFactorLabel";
            this.BiomeLiquidThresholdFactorLabel.Size = new System.Drawing.Size(118, 23);
            this.BiomeLiquidThresholdFactorLabel.TabIndex = 1;
            this.BiomeLiquidThresholdFactorLabel.Text = "Liquid Threshold Factor";
            // 
            // BiomeLandThresholdTextBox
            // 
            this.BiomeLandThresholdTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BiomeLandThresholdTextBox.Location = new System.Drawing.Point(141, 3);
            this.BiomeLandThresholdTextBox.Name = "BiomeLandThresholdTextBox";
            this.BiomeLandThresholdTextBox.Size = new System.Drawing.Size(132, 20);
            this.BiomeLandThresholdTextBox.TabIndex = 2;
            // 
            // BiomeLiquidThresholdFactorTextBox
            // 
            this.BiomeLiquidThresholdFactorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BiomeLiquidThresholdFactorTextBox.Location = new System.Drawing.Point(141, 26);
            this.BiomeLiquidThresholdFactorTextBox.Name = "BiomeLiquidThresholdFactorTextBox";
            this.BiomeLiquidThresholdFactorTextBox.Size = new System.Drawing.Size(132, 20);
            this.BiomeLiquidThresholdFactorTextBox.TabIndex = 3;
            // 
            // BiomeRoomThresholdFactorTextBox
            // 
            this.BiomeRoomThresholdFactorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BiomeRoomThresholdFactorTextBox.Location = new System.Drawing.Point(141, 49);
            this.BiomeRoomThresholdFactorTextBox.Name = "BiomeRoomThresholdFactorTextBox";
            this.BiomeRoomThresholdFactorTextBox.Size = new System.Drawing.Size(132, 20);
            this.BiomeRoomThresholdFactorTextBox.TabIndex = 4;
            // 
            // BiomeRoomThresholdFactorLabel
            // 
            this.BiomeRoomThresholdFactorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BiomeRoomThresholdFactorLabel.AutoSize = true;
            this.BiomeRoomThresholdFactorLabel.Location = new System.Drawing.Point(17, 46);
            this.BiomeRoomThresholdFactorLabel.Name = "BiomeRoomThresholdFactorLabel";
            this.BiomeRoomThresholdFactorLabel.Size = new System.Drawing.Size(118, 26);
            this.BiomeRoomThresholdFactorLabel.TabIndex = 5;
            this.BiomeRoomThresholdFactorLabel.Text = "Room Threshold Factor";
            // 
            // BiomePictureEditButton
            // 
            this.BiomePictureEditButton.Location = new System.Drawing.Point(812, 468);
            this.BiomePictureEditButton.Name = "BiomePictureEditButton";
            this.BiomePictureEditButton.Size = new System.Drawing.Size(128, 23);
            this.BiomePictureEditButton.TabIndex = 7;
            this.BiomePictureEditButton.Text = "Edit Image";
            this.BiomePictureEditButton.UseVisualStyleBackColor = true;
            // 
            // BiomeTableLayoutPanel
            // 
            this.BiomeTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BiomeTableLayoutPanel.ColumnCount = 3;
            this.BiomeTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.BiomeTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.BiomeTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.BiomeTableLayoutPanel.Controls.Add(this.BiomeAddParquetCriterionButton, 2, 7);
            this.BiomeTableLayoutPanel.Controls.Add(this.BiomeDeleteParquetCriterionButton, 1, 7);
            this.BiomeTableLayoutPanel.Controls.Add(this.BiomeEntryRequirementsListBox, 1, 8);
            this.BiomeTableLayoutPanel.Controls.Add(this.BiomeParquetCriteriaListBox, 1, 6);
            this.BiomeTableLayoutPanel.Controls.Add(this.BiomeIsLiquidBasedCheckBox, 1, 5);
            this.BiomeTableLayoutPanel.Controls.Add(this.BiomeIsRoomBasedCheckBox, 1, 4);
            this.BiomeTableLayoutPanel.Controls.Add(this.BiomeNameLabel, 0, 0);
            this.BiomeTableLayoutPanel.Controls.Add(this.BiomeDescriptionLabel, 0, 1);
            this.BiomeTableLayoutPanel.Controls.Add(this.BiomeCommentLabel, 0, 2);
            this.BiomeTableLayoutPanel.Controls.Add(this.BiomeTierLabel, 0, 3);
            this.BiomeTableLayoutPanel.Controls.Add(this.BiomeIsRoomBasedLabel, 0, 4);
            this.BiomeTableLayoutPanel.Controls.Add(this.BiomeIsLiquidBasedLabel, 0, 5);
            this.BiomeTableLayoutPanel.Controls.Add(this.BiomeParquetCriteriaLabel, 0, 6);
            this.BiomeTableLayoutPanel.Controls.Add(this.BiomeEntryRequirementsLabel, 0, 8);
            this.BiomeTableLayoutPanel.Controls.Add(this.BiomeNameTextBox, 1, 0);
            this.BiomeTableLayoutPanel.Controls.Add(this.BiomeDescriptionTextBox, 1, 1);
            this.BiomeTableLayoutPanel.Controls.Add(this.BiomeCommentTextBox, 1, 2);
            this.BiomeTableLayoutPanel.Controls.Add(this.BiomeTierTextBox, 1, 3);
            this.BiomeTableLayoutPanel.Location = new System.Drawing.Point(307, 16);
            this.BiomeTableLayoutPanel.Name = "BiomeTableLayoutPanel";
            this.BiomeTableLayoutPanel.RowCount = 9;
            this.BiomeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.BiomeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.BiomeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.BiomeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.BiomeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.BiomeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.BiomeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.BiomeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.BiomeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.BiomeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.BiomeTableLayoutPanel.Size = new System.Drawing.Size(429, 446);
            this.BiomeTableLayoutPanel.TabIndex = 5;
            // 
            // BiomeAddParquetCriterionButton
            // 
            this.BiomeAddParquetCriterionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BiomeAddParquetCriterionButton.Location = new System.Drawing.Point(297, 316);
            this.BiomeAddParquetCriterionButton.Name = "BiomeAddParquetCriterionButton";
            this.BiomeAddParquetCriterionButton.Size = new System.Drawing.Size(129, 23);
            this.BiomeAddParquetCriterionButton.TabIndex = 2;
            this.BiomeAddParquetCriterionButton.Text = "Add Criterion";
            this.BiomeAddParquetCriterionButton.UseVisualStyleBackColor = true;
            // 
            // BiomeDeleteParquetCriterionButton
            // 
            this.BiomeDeleteParquetCriterionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BiomeDeleteParquetCriterionButton.Location = new System.Drawing.Point(146, 316);
            this.BiomeDeleteParquetCriterionButton.Name = "BiomeDeleteParquetCriterionButton";
            this.BiomeDeleteParquetCriterionButton.Size = new System.Drawing.Size(129, 23);
            this.BiomeDeleteParquetCriterionButton.TabIndex = 2;
            this.BiomeDeleteParquetCriterionButton.Text = "Remove Criterion";
            this.BiomeDeleteParquetCriterionButton.UseVisualStyleBackColor = true;
            // 
            // BiomeEntryRequirementsListBox
            // 
            this.BiomeEntryRequirementsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BiomeTableLayoutPanel.SetColumnSpan(this.BiomeEntryRequirementsListBox, 2);
            this.BiomeEntryRequirementsListBox.FormattingEnabled = true;
            this.BiomeEntryRequirementsListBox.Location = new System.Drawing.Point(131, 346);
            this.BiomeEntryRequirementsListBox.Name = "BiomeEntryRequirementsListBox";
            this.BiomeEntryRequirementsListBox.Size = new System.Drawing.Size(279, 95);
            this.BiomeEntryRequirementsListBox.TabIndex = 1;
            // 
            // BiomeParquetCriteriaListBox
            // 
            this.BiomeParquetCriteriaListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BiomeTableLayoutPanel.SetColumnSpan(this.BiomeParquetCriteriaListBox, 2);
            this.BiomeParquetCriteriaListBox.FormattingEnabled = true;
            this.BiomeParquetCriteriaListBox.Location = new System.Drawing.Point(131, 213);
            this.BiomeParquetCriteriaListBox.Name = "BiomeParquetCriteriaListBox";
            this.BiomeParquetCriteriaListBox.Size = new System.Drawing.Size(279, 95);
            this.BiomeParquetCriteriaListBox.TabIndex = 1;
            // 
            // BiomeIsLiquidBasedCheckBox
            // 
            this.BiomeIsLiquidBasedCheckBox.AutoSize = true;
            this.BiomeIsLiquidBasedCheckBox.Location = new System.Drawing.Point(131, 188);
            this.BiomeIsLiquidBasedCheckBox.Name = "BiomeIsLiquidBasedCheckBox";
            this.BiomeIsLiquidBasedCheckBox.Size = new System.Drawing.Size(15, 14);
            this.BiomeIsLiquidBasedCheckBox.TabIndex = 22;
            this.BiomeIsLiquidBasedCheckBox.UseVisualStyleBackColor = true;
            // 
            // BiomeIsRoomBasedCheckBox
            // 
            this.BiomeIsRoomBasedCheckBox.AutoSize = true;
            this.BiomeIsRoomBasedCheckBox.Location = new System.Drawing.Point(131, 163);
            this.BiomeIsRoomBasedCheckBox.Name = "BiomeIsRoomBasedCheckBox";
            this.BiomeIsRoomBasedCheckBox.Size = new System.Drawing.Size(15, 14);
            this.BiomeIsRoomBasedCheckBox.TabIndex = 22;
            this.BiomeIsRoomBasedCheckBox.UseVisualStyleBackColor = true;
            // 
            // BiomeNameLabel
            // 
            this.BiomeNameLabel.AutoSize = true;
            this.BiomeNameLabel.Location = new System.Drawing.Point(3, 0);
            this.BiomeNameLabel.Name = "BiomeNameLabel";
            this.BiomeNameLabel.Size = new System.Drawing.Size(34, 13);
            this.BiomeNameLabel.TabIndex = 0;
            this.BiomeNameLabel.Text = "Name";
            // 
            // BiomeDescriptionLabel
            // 
            this.BiomeDescriptionLabel.AutoSize = true;
            this.BiomeDescriptionLabel.Location = new System.Drawing.Point(3, 25);
            this.BiomeDescriptionLabel.Name = "BiomeDescriptionLabel";
            this.BiomeDescriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.BiomeDescriptionLabel.TabIndex = 3;
            this.BiomeDescriptionLabel.Text = "Description";
            // 
            // BiomeCommentLabel
            // 
            this.BiomeCommentLabel.AutoSize = true;
            this.BiomeCommentLabel.Location = new System.Drawing.Point(3, 80);
            this.BiomeCommentLabel.Name = "BiomeCommentLabel";
            this.BiomeCommentLabel.Size = new System.Drawing.Size(52, 13);
            this.BiomeCommentLabel.TabIndex = 6;
            this.BiomeCommentLabel.Text = "Comment";
            // 
            // BiomeTierLabel
            // 
            this.BiomeTierLabel.AutoSize = true;
            this.BiomeTierLabel.Location = new System.Drawing.Point(3, 135);
            this.BiomeTierLabel.Name = "BiomeTierLabel";
            this.BiomeTierLabel.Size = new System.Drawing.Size(25, 13);
            this.BiomeTierLabel.TabIndex = 9;
            this.BiomeTierLabel.Text = "Tier";
            // 
            // BiomeIsRoomBasedLabel
            // 
            this.BiomeIsRoomBasedLabel.AutoSize = true;
            this.BiomeIsRoomBasedLabel.Location = new System.Drawing.Point(3, 160);
            this.BiomeIsRoomBasedLabel.Name = "BiomeIsRoomBasedLabel";
            this.BiomeIsRoomBasedLabel.Size = new System.Drawing.Size(84, 13);
            this.BiomeIsRoomBasedLabel.TabIndex = 12;
            this.BiomeIsRoomBasedLabel.Text = "Is Room-Based?";
            // 
            // BiomeIsLiquidBasedLabel
            // 
            this.BiomeIsLiquidBasedLabel.AutoSize = true;
            this.BiomeIsLiquidBasedLabel.Location = new System.Drawing.Point(3, 185);
            this.BiomeIsLiquidBasedLabel.Name = "BiomeIsLiquidBasedLabel";
            this.BiomeIsLiquidBasedLabel.Size = new System.Drawing.Size(84, 13);
            this.BiomeIsLiquidBasedLabel.TabIndex = 15;
            this.BiomeIsLiquidBasedLabel.Text = "Is Liquid-Based?";
            // 
            // BiomeParquetCriteriaLabel
            // 
            this.BiomeParquetCriteriaLabel.AutoSize = true;
            this.BiomeParquetCriteriaLabel.Location = new System.Drawing.Point(3, 210);
            this.BiomeParquetCriteriaLabel.Name = "BiomeParquetCriteriaLabel";
            this.BiomeParquetCriteriaLabel.Size = new System.Drawing.Size(83, 13);
            this.BiomeParquetCriteriaLabel.TabIndex = 18;
            this.BiomeParquetCriteriaLabel.Text = "Parquet Criteria";
            // 
            // BiomeEntryRequirementsLabel
            // 
            this.BiomeEntryRequirementsLabel.AutoSize = true;
            this.BiomeEntryRequirementsLabel.Location = new System.Drawing.Point(3, 343);
            this.BiomeEntryRequirementsLabel.Name = "BiomeEntryRequirementsLabel";
            this.BiomeEntryRequirementsLabel.Size = new System.Drawing.Size(102, 13);
            this.BiomeEntryRequirementsLabel.TabIndex = 21;
            this.BiomeEntryRequirementsLabel.Text = "Entry Requirements";
            // 
            // BiomeNameTextBox
            // 
            this.BiomeNameTextBox.Location = new System.Drawing.Point(131, 3);
            this.BiomeNameTextBox.Name = "BiomeNameTextBox";
            this.BiomeNameTextBox.Size = new System.Drawing.Size(144, 20);
            this.BiomeNameTextBox.TabIndex = 23;
            // 
            // BiomeDescriptionTextBox
            // 
            this.BiomeDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BiomeTableLayoutPanel.SetColumnSpan(this.BiomeDescriptionTextBox, 2);
            this.BiomeDescriptionTextBox.Location = new System.Drawing.Point(131, 28);
            this.BiomeDescriptionTextBox.Multiline = true;
            this.BiomeDescriptionTextBox.Name = "BiomeDescriptionTextBox";
            this.BiomeDescriptionTextBox.Size = new System.Drawing.Size(295, 49);
            this.BiomeDescriptionTextBox.TabIndex = 24;
            // 
            // BiomeCommentTextBox
            // 
            this.BiomeCommentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BiomeTableLayoutPanel.SetColumnSpan(this.BiomeCommentTextBox, 2);
            this.BiomeCommentTextBox.Location = new System.Drawing.Point(131, 83);
            this.BiomeCommentTextBox.Multiline = true;
            this.BiomeCommentTextBox.Name = "BiomeCommentTextBox";
            this.BiomeCommentTextBox.Size = new System.Drawing.Size(295, 49);
            this.BiomeCommentTextBox.TabIndex = 25;
            // 
            // BiomeTierTextBox
            // 
            this.BiomeTierTextBox.Location = new System.Drawing.Point(131, 138);
            this.BiomeTierTextBox.Name = "BiomeTierTextBox";
            this.BiomeTierTextBox.Size = new System.Drawing.Size(144, 20);
            this.BiomeTierTextBox.TabIndex = 26;
            // 
            // BiomePictureBox
            // 
            this.BiomePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BiomePictureBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.BiomePictureBox.Location = new System.Drawing.Point(758, 280);
            this.BiomePictureBox.Name = "BiomePictureBox";
            this.BiomePictureBox.Size = new System.Drawing.Size(182, 182);
            this.BiomePictureBox.TabIndex = 6;
            this.BiomePictureBox.TabStop = false;
            // 
            // BiomeIDLabel
            // 
            this.BiomeIDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BiomeIDLabel.AutoSize = true;
            this.BiomeIDLabel.Location = new System.Drawing.Point(758, 19);
            this.BiomeIDLabel.Name = "BiomeIDLabel";
            this.BiomeIDLabel.Size = new System.Drawing.Size(49, 13);
            this.BiomeIDLabel.TabIndex = 4;
            this.BiomeIDLabel.Text = "Biome ID";
            // 
            // BiomeAddNewBiomeButton
            // 
            this.BiomeAddNewBiomeButton.Location = new System.Drawing.Point(159, 468);
            this.BiomeAddNewBiomeButton.Name = "BiomeAddNewBiomeButton";
            this.BiomeAddNewBiomeButton.Size = new System.Drawing.Size(129, 23);
            this.BiomeAddNewBiomeButton.TabIndex = 2;
            this.BiomeAddNewBiomeButton.Text = "Add New Biome";
            this.BiomeAddNewBiomeButton.UseVisualStyleBackColor = true;
            // 
            // BiomeIDTextBox
            // 
            this.BiomeIDTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BiomeIDTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.BiomeIDTextBox.Location = new System.Drawing.Point(812, 16);
            this.BiomeIDTextBox.Name = "BiomeIDTextBox";
            this.BiomeIDTextBox.Size = new System.Drawing.Size(131, 20);
            this.BiomeIDTextBox.TabIndex = 3;
            this.BiomeIDTextBox.Text = "-2020202020";
            //
            // CraftingTabPage
            //
            this.CraftingTabPage.BackColor = System.Drawing.Color.Transparent;
            this.CraftingTabPage.Location = new System.Drawing.Point(4, 22);
            this.CraftingTabPage.Name = "CraftingTabPage";
            this.CraftingTabPage.Size = new System.Drawing.Size(952, 599);
            this.CraftingTabPage.TabIndex = 3;
            this.CraftingTabPage.Text = "Crafting";
            //
            // ItemsTabPage
            //
            this.ItemsTabPage.BackColor = System.Drawing.Color.Transparent;
            this.ItemsTabPage.Controls.Add(this.ItemAddEntryRequirementButton);
            this.ItemsTabPage.Controls.Add(this.ItemDeleteEntryRequirementButton);
            this.ItemsTabPage.Controls.Add(this.ItemListBox);
            this.ItemsTabPage.Controls.Add(this.ItemConfigGroupBox);
            this.ItemsTabPage.Controls.Add(this.ItemPictureEditButton);
            this.ItemsTabPage.Controls.Add(this.ItemTableLayoutPanel);
            this.ItemsTabPage.Controls.Add(this.ItemPictureBox);
            this.ItemsTabPage.Controls.Add(this.ItemIDLabel);
            this.ItemsTabPage.Controls.Add(this.ItemAddNewItemButton);
            this.ItemsTabPage.Controls.Add(this.ItemIDTextBox);
            this.ItemsTabPage.Location = new System.Drawing.Point(4, 22);
            this.ItemsTabPage.Name = "ItemsTabPage";
            this.ItemsTabPage.Size = new System.Drawing.Size(952, 599);
            this.ItemsTabPage.TabIndex = 4;
            this.ItemsTabPage.Text = "Items";
            //
            // ItemAddEntryRequirementButton
            //
            this.ItemAddEntryRequirementButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemAddEntryRequirementButton.Location = new System.Drawing.Point(604, 468);
            this.ItemAddEntryRequirementButton.Name = "ItemAddEntryRequirementButton";
            this.ItemAddEntryRequirementButton.Size = new System.Drawing.Size(129, 23);
            this.ItemAddEntryRequirementButton.TabIndex = 2;
            this.ItemAddEntryRequirementButton.Text = "Add Requirement";
            this.ItemAddEntryRequirementButton.UseVisualStyleBackColor = true;
            //
            // ItemDeleteEntryRequirementButton
            //
            this.ItemDeleteEntryRequirementButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemDeleteEntryRequirementButton.Location = new System.Drawing.Point(453, 468);
            this.ItemDeleteEntryRequirementButton.Name = "ItemDeleteEntryRequirementButton";
            this.ItemDeleteEntryRequirementButton.Size = new System.Drawing.Size(129, 23);
            this.ItemDeleteEntryRequirementButton.TabIndex = 2;
            this.ItemDeleteEntryRequirementButton.Text = "Remove Requirement";
            this.ItemDeleteEntryRequirementButton.UseVisualStyleBackColor = true;
            //
            // ItemListBox
            //
            this.ItemListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ItemListBox.FormattingEnabled = true;
            this.ItemListBox.Location = new System.Drawing.Point(9, 16);
            this.ItemListBox.Name = "ItemListBox";
            this.ItemListBox.Size = new System.Drawing.Size(279, 446);
            this.ItemListBox.TabIndex = 1;
            //
            // ItemConfigGroupBox
            //
            this.ItemConfigGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemConfigGroupBox.Controls.Add(this.ItemConfigTableLayoutPanel);
            this.ItemConfigGroupBox.Location = new System.Drawing.Point(9, 499);
            this.ItemConfigGroupBox.Name = "ItemConfigGroupBox";
            this.ItemConfigGroupBox.Size = new System.Drawing.Size(937, 97);
            this.ItemConfigGroupBox.TabIndex = 0;
            this.ItemConfigGroupBox.TabStop = false;
            this.ItemConfigGroupBox.Text = "Configuration";
            //
            // ItemConfigTableLayoutPanel
            //
            this.ItemConfigTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemConfigTableLayoutPanel.ColumnCount = 3;
            this.ItemConfigTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.ItemConfigTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.ItemConfigTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.ItemConfigTableLayoutPanel.Controls.Add(this.ItemMinWalkableSpacesLabel, 0, 0);
            this.ItemConfigTableLayoutPanel.Controls.Add(this.ItemMaxWalkableSpacesLabel, 0, 1);
            this.ItemConfigTableLayoutPanel.Controls.Add(this.ItemMinWalkableSpacesTextBox, 1, 0);
            this.ItemConfigTableLayoutPanel.Controls.Add(this.ItemMaxWalkableSpacesTextBox, 1, 1);
            this.ItemConfigTableLayoutPanel.Location = new System.Drawing.Point(6, 19);
            this.ItemConfigTableLayoutPanel.Name = "ItemConfigTableLayoutPanel";
            this.ItemConfigTableLayoutPanel.RowCount = 3;
            this.ItemConfigTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ItemConfigTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ItemConfigTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ItemConfigTableLayoutPanel.Size = new System.Drawing.Size(925, 72);
            this.ItemConfigTableLayoutPanel.TabIndex = 1;
            //
            // ItemMinWalkableSpacesLabel
            //
            this.ItemMinWalkableSpacesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemMinWalkableSpacesLabel.AutoSize = true;
            this.ItemMinWalkableSpacesLabel.Location = new System.Drawing.Point(24, 0);
            this.ItemMinWalkableSpacesLabel.Name = "ItemMinWalkableSpacesLabel";
            this.ItemMinWalkableSpacesLabel.Size = new System.Drawing.Size(130, 24);
            this.ItemMinWalkableSpacesLabel.TabIndex = 0;
            this.ItemMinWalkableSpacesLabel.Text = "Minimum Walkable Spaces";
            //
            // ItemMaxWalkableSpacesLabel
            //
            this.ItemMaxWalkableSpacesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemMaxWalkableSpacesLabel.AutoSize = true;
            this.ItemMaxWalkableSpacesLabel.Location = new System.Drawing.Point(20, 24);
            this.ItemMaxWalkableSpacesLabel.Name = "ItemMaxWalkableSpacesLabel";
            this.ItemMaxWalkableSpacesLabel.Size = new System.Drawing.Size(134, 24);
            this.ItemMaxWalkableSpacesLabel.TabIndex = 1;
            this.ItemMaxWalkableSpacesLabel.Text = "Maximum Walkable Spaces";
            //
            // ItemMinWalkableSpacesTextBox
            //
            this.ItemMinWalkableSpacesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ItemMinWalkableSpacesTextBox.Location = new System.Drawing.Point(160, 3);
            this.ItemMinWalkableSpacesTextBox.Name = "ItemMinWalkableSpacesTextBox";
            this.ItemMinWalkableSpacesTextBox.Size = new System.Drawing.Size(114, 20);
            this.ItemMinWalkableSpacesTextBox.TabIndex = 2;
            //
            // ItemMaxWalkableSpacesTextBox
            //
            this.ItemMaxWalkableSpacesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ItemMaxWalkableSpacesTextBox.Location = new System.Drawing.Point(160, 27);
            this.ItemMaxWalkableSpacesTextBox.Name = "ItemMaxWalkableSpacesTextBox";
            this.ItemMaxWalkableSpacesTextBox.Size = new System.Drawing.Size(114, 20);
            this.ItemMaxWalkableSpacesTextBox.TabIndex = 3;
            //
            // ItemPictureEditButton
            //
            this.ItemPictureEditButton.Location = new System.Drawing.Point(812, 468);
            this.ItemPictureEditButton.Name = "ItemPictureEditButton";
            this.ItemPictureEditButton.Size = new System.Drawing.Size(128, 23);
            this.ItemPictureEditButton.TabIndex = 7;
            this.ItemPictureEditButton.Text = "Edit Image";
            this.ItemPictureEditButton.UseVisualStyleBackColor = true;
            //
            // ItemTableLayoutPanel
            //
            this.ItemTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ItemTableLayoutPanel.ColumnCount = 3;
            this.ItemTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.ItemTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.ItemTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.ItemTableLayoutPanel.Controls.Add(this.ItemAddParquetCriterionButton, 2, 7);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemDeleteParquetCriterionButton, 1, 7);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemEntryRequirementsListBox, 1, 8);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemParquetCriteriaListBox, 1, 6);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemIsLiquidBasedCheckBox, 1, 5);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemIsItemBasedCheckBox, 1, 4);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemNameLabel, 0, 0);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemDescriptionLabel, 0, 1);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemCommentLabel, 0, 2);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemTierLabel, 0, 3);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemIsItemBasedLabel, 0, 4);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemIsLiquidBasedLabel, 0, 5);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemParquetCriteriaLabel, 0, 6);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemEntryRequirementsLabel, 0, 8);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemNameTextBox, 1, 0);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemDescriptionTextBox, 1, 1);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemCommentTextBox, 1, 2);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemTierTextBox, 1, 3);
            this.ItemTableLayoutPanel.Location = new System.Drawing.Point(307, 16);
            this.ItemTableLayoutPanel.Name = "ItemTableLayoutPanel";
            this.ItemTableLayoutPanel.RowCount = 9;
            this.ItemTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.ItemTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.ItemTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.ItemTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.ItemTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.ItemTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.ItemTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ItemTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ItemTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ItemTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ItemTableLayoutPanel.Size = new System.Drawing.Size(429, 446);
            this.ItemTableLayoutPanel.TabIndex = 5;
            //
            // ItemAddParquetCriterionButton
            //
            this.ItemAddParquetCriterionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemAddParquetCriterionButton.Location = new System.Drawing.Point(297, 316);
            this.ItemAddParquetCriterionButton.Name = "ItemAddParquetCriterionButton";
            this.ItemAddParquetCriterionButton.Size = new System.Drawing.Size(129, 23);
            this.ItemAddParquetCriterionButton.TabIndex = 2;
            this.ItemAddParquetCriterionButton.Text = "Add Criterion";
            this.ItemAddParquetCriterionButton.UseVisualStyleBackColor = true;
            //
            // ItemDeleteParquetCriterionButton
            //
            this.ItemDeleteParquetCriterionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemDeleteParquetCriterionButton.Location = new System.Drawing.Point(146, 316);
            this.ItemDeleteParquetCriterionButton.Name = "ItemDeleteParquetCriterionButton";
            this.ItemDeleteParquetCriterionButton.Size = new System.Drawing.Size(129, 23);
            this.ItemDeleteParquetCriterionButton.TabIndex = 2;
            this.ItemDeleteParquetCriterionButton.Text = "Remove Criterion";
            this.ItemDeleteParquetCriterionButton.UseVisualStyleBackColor = true;
            //
            // ItemEntryRequirementsListBox
            //
            this.ItemEntryRequirementsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ItemTableLayoutPanel.SetColumnSpan(this.ItemEntryRequirementsListBox, 2);
            this.ItemEntryRequirementsListBox.FormattingEnabled = true;
            this.ItemEntryRequirementsListBox.Location = new System.Drawing.Point(131, 346);
            this.ItemEntryRequirementsListBox.Name = "ItemEntryRequirementsListBox";
            this.ItemEntryRequirementsListBox.Size = new System.Drawing.Size(279, 95);
            this.ItemEntryRequirementsListBox.TabIndex = 1;
            //
            // ItemParquetCriteriaListBox
            //
            this.ItemParquetCriteriaListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ItemTableLayoutPanel.SetColumnSpan(this.ItemParquetCriteriaListBox, 2);
            this.ItemParquetCriteriaListBox.FormattingEnabled = true;
            this.ItemParquetCriteriaListBox.Location = new System.Drawing.Point(131, 213);
            this.ItemParquetCriteriaListBox.Name = "ItemParquetCriteriaListBox";
            this.ItemParquetCriteriaListBox.Size = new System.Drawing.Size(279, 95);
            this.ItemParquetCriteriaListBox.TabIndex = 1;
            //
            // ItemIsLiquidBasedCheckBox
            //
            this.ItemIsLiquidBasedCheckBox.AutoSize = true;
            this.ItemIsLiquidBasedCheckBox.Location = new System.Drawing.Point(131, 188);
            this.ItemIsLiquidBasedCheckBox.Name = "ItemIsLiquidBasedCheckBox";
            this.ItemIsLiquidBasedCheckBox.Size = new System.Drawing.Size(15, 14);
            this.ItemIsLiquidBasedCheckBox.TabIndex = 22;
            this.ItemIsLiquidBasedCheckBox.UseVisualStyleBackColor = true;
            //
            // ItemIsItemBasedCheckBox
            //
            this.ItemIsItemBasedCheckBox.AutoSize = true;
            this.ItemIsItemBasedCheckBox.Location = new System.Drawing.Point(131, 163);
            this.ItemIsItemBasedCheckBox.Name = "ItemIsItemBasedCheckBox";
            this.ItemIsItemBasedCheckBox.Size = new System.Drawing.Size(15, 14);
            this.ItemIsItemBasedCheckBox.TabIndex = 22;
            this.ItemIsItemBasedCheckBox.UseVisualStyleBackColor = true;
            //
            // ItemNameLabel
            //
            this.ItemNameLabel.AutoSize = true;
            this.ItemNameLabel.Location = new System.Drawing.Point(3, 0);
            this.ItemNameLabel.Name = "ItemNameLabel";
            this.ItemNameLabel.Size = new System.Drawing.Size(34, 13);
            this.ItemNameLabel.TabIndex = 0;
            this.ItemNameLabel.Text = "Name";
            //
            // ItemDescriptionLabel
            //
            this.ItemDescriptionLabel.AutoSize = true;
            this.ItemDescriptionLabel.Location = new System.Drawing.Point(3, 25);
            this.ItemDescriptionLabel.Name = "ItemDescriptionLabel";
            this.ItemDescriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.ItemDescriptionLabel.TabIndex = 3;
            this.ItemDescriptionLabel.Text = "Description";
            //
            // ItemCommentLabel
            //
            this.ItemCommentLabel.AutoSize = true;
            this.ItemCommentLabel.Location = new System.Drawing.Point(3, 80);
            this.ItemCommentLabel.Name = "ItemCommentLabel";
            this.ItemCommentLabel.Size = new System.Drawing.Size(52, 13);
            this.ItemCommentLabel.TabIndex = 6;
            this.ItemCommentLabel.Text = "Comment";
            //
            // ItemTierLabel
            //
            this.ItemTierLabel.AutoSize = true;
            this.ItemTierLabel.Location = new System.Drawing.Point(3, 135);
            this.ItemTierLabel.Name = "ItemTierLabel";
            this.ItemTierLabel.Size = new System.Drawing.Size(25, 13);
            this.ItemTierLabel.TabIndex = 9;
            this.ItemTierLabel.Text = "Tier";
            //
            // ItemIsItemBasedLabel
            //
            this.ItemIsItemBasedLabel.AutoSize = true;
            this.ItemIsItemBasedLabel.Location = new System.Drawing.Point(3, 160);
            this.ItemIsItemBasedLabel.Name = "ItemIsItemBasedLabel";
            this.ItemIsItemBasedLabel.Size = new System.Drawing.Size(84, 13);
            this.ItemIsItemBasedLabel.TabIndex = 12;
            this.ItemIsItemBasedLabel.Text = "Is Item-Based?";
            //
            // ItemIsLiquidBasedLabel
            //
            this.ItemIsLiquidBasedLabel.AutoSize = true;
            this.ItemIsLiquidBasedLabel.Location = new System.Drawing.Point(3, 185);
            this.ItemIsLiquidBasedLabel.Name = "ItemIsLiquidBasedLabel";
            this.ItemIsLiquidBasedLabel.Size = new System.Drawing.Size(84, 13);
            this.ItemIsLiquidBasedLabel.TabIndex = 15;
            this.ItemIsLiquidBasedLabel.Text = "Is Liquid-Based?";
            //
            // ItemParquetCriteriaLabel
            //
            this.ItemParquetCriteriaLabel.AutoSize = true;
            this.ItemParquetCriteriaLabel.Location = new System.Drawing.Point(3, 210);
            this.ItemParquetCriteriaLabel.Name = "ItemParquetCriteriaLabel";
            this.ItemParquetCriteriaLabel.Size = new System.Drawing.Size(83, 13);
            this.ItemParquetCriteriaLabel.TabIndex = 18;
            this.ItemParquetCriteriaLabel.Text = "Parquet Criteria";
            //
            // ItemEntryRequirementsLabel
            //
            this.ItemEntryRequirementsLabel.AutoSize = true;
            this.ItemEntryRequirementsLabel.Location = new System.Drawing.Point(3, 343);
            this.ItemEntryRequirementsLabel.Name = "ItemEntryRequirementsLabel";
            this.ItemEntryRequirementsLabel.Size = new System.Drawing.Size(102, 13);
            this.ItemEntryRequirementsLabel.TabIndex = 21;
            this.ItemEntryRequirementsLabel.Text = "Entry Requirements";
            //
            // ItemNameTextBox
            //
            this.ItemNameTextBox.Location = new System.Drawing.Point(131, 3);
            this.ItemNameTextBox.Name = "ItemNameTextBox";
            this.ItemNameTextBox.Size = new System.Drawing.Size(144, 20);
            this.ItemNameTextBox.TabIndex = 23;
            //
            // ItemDescriptionTextBox
            //
            this.ItemDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemTableLayoutPanel.SetColumnSpan(this.ItemDescriptionTextBox, 2);
            this.ItemDescriptionTextBox.Location = new System.Drawing.Point(131, 28);
            this.ItemDescriptionTextBox.Multiline = true;
            this.ItemDescriptionTextBox.Name = "ItemDescriptionTextBox";
            this.ItemDescriptionTextBox.Size = new System.Drawing.Size(295, 49);
            this.ItemDescriptionTextBox.TabIndex = 24;
            //
            // ItemCommentTextBox
            //
            this.ItemCommentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemTableLayoutPanel.SetColumnSpan(this.ItemCommentTextBox, 2);
            this.ItemCommentTextBox.Location = new System.Drawing.Point(131, 83);
            this.ItemCommentTextBox.Multiline = true;
            this.ItemCommentTextBox.Name = "ItemCommentTextBox";
            this.ItemCommentTextBox.Size = new System.Drawing.Size(295, 49);
            this.ItemCommentTextBox.TabIndex = 25;
            //
            // ItemTierTextBox
            //
            this.ItemTierTextBox.Location = new System.Drawing.Point(131, 138);
            this.ItemTierTextBox.Name = "ItemTierTextBox";
            this.ItemTierTextBox.Size = new System.Drawing.Size(144, 20);
            this.ItemTierTextBox.TabIndex = 26;
            //
            // ItemPictureBox
            //
            this.ItemPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemPictureBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ItemPictureBox.Location = new System.Drawing.Point(758, 280);
            this.ItemPictureBox.Name = "ItemPictureBox";
            this.ItemPictureBox.Size = new System.Drawing.Size(182, 182);
            this.ItemPictureBox.TabIndex = 6;
            this.ItemPictureBox.TabStop = false;
            //
            // ItemIDLabel
            //
            this.ItemIDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemIDLabel.AutoSize = true;
            this.ItemIDLabel.Location = new System.Drawing.Point(758, 19);
            this.ItemIDLabel.Name = "ItemIDLabel";
            this.ItemIDLabel.Size = new System.Drawing.Size(48, 13);
            this.ItemIDLabel.TabIndex = 4;
            this.ItemIDLabel.Text = "Item ID";
            //
            // ItemAddNewItemButton
            //
            this.ItemAddNewItemButton.Location = new System.Drawing.Point(159, 468);
            this.ItemAddNewItemButton.Name = "ItemAddNewItemButton";
            this.ItemAddNewItemButton.Size = new System.Drawing.Size(129, 23);
            this.ItemAddNewItemButton.TabIndex = 2;
            this.ItemAddNewItemButton.Text = "Add New Item";
            this.ItemAddNewItemButton.UseVisualStyleBackColor = true;
            //
            // ItemIDTextBox
            //
            this.ItemIDTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemIDTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ItemIDTextBox.Location = new System.Drawing.Point(812, 16);
            this.ItemIDTextBox.Name = "ItemIDTextBox";
            this.ItemIDTextBox.Size = new System.Drawing.Size(131, 20);
            this.ItemIDTextBox.TabIndex = 3;
            this.ItemIDTextBox.Text = "-2020202020";
            //
            // MapsTabPage
            //
            this.MapsTabPage.BackColor = System.Drawing.Color.Transparent;
            this.MapsTabPage.Location = new System.Drawing.Point(4, 22);
            this.MapsTabPage.Name = "MapsTabPage";
            this.MapsTabPage.Size = new System.Drawing.Size(952, 599);
            this.MapsTabPage.TabIndex = 5;
            this.MapsTabPage.Text = "Maps";
            //
            // ParquetsTabPage
            //
            this.ParquetsTabPage.BackColor = System.Drawing.Color.Transparent;
            this.ParquetsTabPage.Location = new System.Drawing.Point(4, 22);
            this.ParquetsTabPage.Name = "ParquetsTabPage";
            this.ParquetsTabPage.Size = new System.Drawing.Size(952, 599);
            this.ParquetsTabPage.TabIndex = 6;
            this.ParquetsTabPage.Text = "Parquets";
            //
            // RoomsTabPage
            //
            this.RoomsTabPage.BackColor = System.Drawing.Color.Transparent;
            this.RoomsTabPage.Controls.Add(this.RoomAddEntryRequirementButton);
            this.RoomsTabPage.Controls.Add(this.RoomDeleteEntryRequirementButton);
            this.RoomsTabPage.Controls.Add(this.RoomListBox);
            this.RoomsTabPage.Controls.Add(this.RoomConfigGroupBox);
            this.RoomsTabPage.Controls.Add(this.RoomPictureEditButton);
            this.RoomsTabPage.Controls.Add(this.RoomTableLayoutPanel);
            this.RoomsTabPage.Controls.Add(this.RoomPictureBox);
            this.RoomsTabPage.Controls.Add(this.RoomIDLabel);
            this.RoomsTabPage.Controls.Add(this.RoomAddNewRoomButton);
            this.RoomsTabPage.Controls.Add(this.RoomIDTextBox);
            this.RoomsTabPage.Location = new System.Drawing.Point(4, 22);
            this.RoomsTabPage.Name = "RoomsTabPage";
            this.RoomsTabPage.Size = new System.Drawing.Size(952, 599);
            this.RoomsTabPage.TabIndex = 7;
            this.RoomsTabPage.Text = "Rooms";
            // 
            // RoomAddEntryRequirementButton
            // 
            this.RoomAddEntryRequirementButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RoomAddEntryRequirementButton.Location = new System.Drawing.Point(604, 468);
            this.RoomAddEntryRequirementButton.Name = "RoomAddEntryRequirementButton";
            this.RoomAddEntryRequirementButton.Size = new System.Drawing.Size(129, 23);
            this.RoomAddEntryRequirementButton.TabIndex = 2;
            this.RoomAddEntryRequirementButton.Text = "Add Requirement";
            this.RoomAddEntryRequirementButton.UseVisualStyleBackColor = true;
            // 
            // RoomDeleteEntryRequirementButton
            // 
            this.RoomDeleteEntryRequirementButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RoomDeleteEntryRequirementButton.Location = new System.Drawing.Point(453, 468);
            this.RoomDeleteEntryRequirementButton.Name = "RoomDeleteEntryRequirementButton";
            this.RoomDeleteEntryRequirementButton.Size = new System.Drawing.Size(129, 23);
            this.RoomDeleteEntryRequirementButton.TabIndex = 2;
            this.RoomDeleteEntryRequirementButton.Text = "Remove Requirement";
            this.RoomDeleteEntryRequirementButton.UseVisualStyleBackColor = true;
            // 
            // RoomListBox
            // 
            this.RoomListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.RoomListBox.FormattingEnabled = true;
            this.RoomListBox.Location = new System.Drawing.Point(9, 16);
            this.RoomListBox.Name = "RoomListBox";
            this.RoomListBox.Size = new System.Drawing.Size(279, 446);
            this.RoomListBox.TabIndex = 1;
            // 
            // RoomConfigGroupBox
            // 
            this.RoomConfigGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RoomConfigGroupBox.Controls.Add(this.RoomConfigTableLayoutPanel);
            this.RoomConfigGroupBox.Location = new System.Drawing.Point(9, 499);
            this.RoomConfigGroupBox.Name = "RoomConfigGroupBox";
            this.RoomConfigGroupBox.Size = new System.Drawing.Size(937, 97);
            this.RoomConfigGroupBox.TabIndex = 0;
            this.RoomConfigGroupBox.TabStop = false;
            this.RoomConfigGroupBox.Text = "Configuration";
            // 
            // RoomConfigTableLayoutPanel
            // 
            this.RoomConfigTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RoomConfigTableLayoutPanel.ColumnCount = 3;
            this.RoomConfigTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.RoomConfigTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.RoomConfigTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.RoomConfigTableLayoutPanel.Controls.Add(this.RoomMinWalkableSpacesLabel, 0, 0);
            this.RoomConfigTableLayoutPanel.Controls.Add(this.RoomMaxWalkableSpacesLabel, 0, 1);
            this.RoomConfigTableLayoutPanel.Controls.Add(this.RoomMinWalkableSpacesTextBox, 1, 0);
            this.RoomConfigTableLayoutPanel.Controls.Add(this.RoomMaxWalkableSpacesTextBox, 1, 1);
            this.RoomConfigTableLayoutPanel.Location = new System.Drawing.Point(6, 19);
            this.RoomConfigTableLayoutPanel.Name = "RoomConfigTableLayoutPanel";
            this.RoomConfigTableLayoutPanel.RowCount = 3;
            this.RoomConfigTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.RoomConfigTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.RoomConfigTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.RoomConfigTableLayoutPanel.Size = new System.Drawing.Size(925, 72);
            this.RoomConfigTableLayoutPanel.TabIndex = 1;
            // 
            // RoomMinWalkableSpacesLabel
            // 
            this.RoomMinWalkableSpacesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RoomMinWalkableSpacesLabel.AutoSize = true;
            this.RoomMinWalkableSpacesLabel.Location = new System.Drawing.Point(24, 0);
            this.RoomMinWalkableSpacesLabel.Name = "RoomMinWalkableSpacesLabel";
            this.RoomMinWalkableSpacesLabel.Size = new System.Drawing.Size(130, 24);
            this.RoomMinWalkableSpacesLabel.TabIndex = 0;
            this.RoomMinWalkableSpacesLabel.Text = "Minimum Walkable Spaces";
            // 
            // RoomMaxWalkableSpacesLabel
            // 
            this.RoomMaxWalkableSpacesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RoomMaxWalkableSpacesLabel.AutoSize = true;
            this.RoomMaxWalkableSpacesLabel.Location = new System.Drawing.Point(20, 24);
            this.RoomMaxWalkableSpacesLabel.Name = "RoomMaxWalkableSpacesLabel";
            this.RoomMaxWalkableSpacesLabel.Size = new System.Drawing.Size(134, 24);
            this.RoomMaxWalkableSpacesLabel.TabIndex = 1;
            this.RoomMaxWalkableSpacesLabel.Text = "Maximum Walkable Spaces";
            // 
            // RoomMinWalkableSpacesTextBox
            // 
            this.RoomMinWalkableSpacesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.RoomMinWalkableSpacesTextBox.Location = new System.Drawing.Point(160, 3);
            this.RoomMinWalkableSpacesTextBox.Name = "RoomMinWalkableSpacesTextBox";
            this.RoomMinWalkableSpacesTextBox.Size = new System.Drawing.Size(114, 20);
            this.RoomMinWalkableSpacesTextBox.TabIndex = 2;
            // 
            // RoomMaxWalkableSpacesTextBox
            // 
            this.RoomMaxWalkableSpacesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.RoomMaxWalkableSpacesTextBox.Location = new System.Drawing.Point(160, 27);
            this.RoomMaxWalkableSpacesTextBox.Name = "RoomMaxWalkableSpacesTextBox";
            this.RoomMaxWalkableSpacesTextBox.Size = new System.Drawing.Size(114, 20);
            this.RoomMaxWalkableSpacesTextBox.TabIndex = 3;
            // 
            // RoomPictureEditButton
            // 
            this.RoomPictureEditButton.Location = new System.Drawing.Point(812, 468);
            this.RoomPictureEditButton.Name = "RoomPictureEditButton";
            this.RoomPictureEditButton.Size = new System.Drawing.Size(128, 23);
            this.RoomPictureEditButton.TabIndex = 7;
            this.RoomPictureEditButton.Text = "Edit Image";
            this.RoomPictureEditButton.UseVisualStyleBackColor = true;
            // 
            // RoomTableLayoutPanel
            // 
            this.RoomTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.RoomTableLayoutPanel.ColumnCount = 3;
            this.RoomTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.RoomTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.RoomTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.RoomTableLayoutPanel.Controls.Add(this.RoomAddParquetCriterionButton, 2, 7);
            this.RoomTableLayoutPanel.Controls.Add(this.RoomDeleteParquetCriterionButton, 1, 7);
            this.RoomTableLayoutPanel.Controls.Add(this.RoomEntryRequirementsListBox, 1, 8);
            this.RoomTableLayoutPanel.Controls.Add(this.RoomParquetCriteriaListBox, 1, 6);
            this.RoomTableLayoutPanel.Controls.Add(this.RoomIsLiquidBasedCheckBox, 1, 5);
            this.RoomTableLayoutPanel.Controls.Add(this.RoomIsRoomBasedCheckBox, 1, 4);
            this.RoomTableLayoutPanel.Controls.Add(this.RoomNameLabel, 0, 0);
            this.RoomTableLayoutPanel.Controls.Add(this.RoomDescriptionLabel, 0, 1);
            this.RoomTableLayoutPanel.Controls.Add(this.RoomCommentLabel, 0, 2);
            this.RoomTableLayoutPanel.Controls.Add(this.RoomTierLabel, 0, 3);
            this.RoomTableLayoutPanel.Controls.Add(this.RoomIsRoomBasedLabel, 0, 4);
            this.RoomTableLayoutPanel.Controls.Add(this.RoomIsLiquidBasedLabel, 0, 5);
            this.RoomTableLayoutPanel.Controls.Add(this.RoomParquetCriteriaLabel, 0, 6);
            this.RoomTableLayoutPanel.Controls.Add(this.RoomEntryRequirementsLabel, 0, 8);
            this.RoomTableLayoutPanel.Controls.Add(this.RoomNameTextBox, 1, 0);
            this.RoomTableLayoutPanel.Controls.Add(this.RoomDescriptionTextBox, 1, 1);
            this.RoomTableLayoutPanel.Controls.Add(this.RoomCommentTextBox, 1, 2);
            this.RoomTableLayoutPanel.Controls.Add(this.RoomTierTextBox, 1, 3);
            this.RoomTableLayoutPanel.Location = new System.Drawing.Point(307, 16);
            this.RoomTableLayoutPanel.Name = "RoomTableLayoutPanel";
            this.RoomTableLayoutPanel.RowCount = 9;
            this.RoomTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.RoomTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.RoomTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.RoomTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.RoomTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.RoomTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.RoomTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.RoomTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.RoomTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.RoomTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RoomTableLayoutPanel.Size = new System.Drawing.Size(429, 446);
            this.RoomTableLayoutPanel.TabIndex = 5;
            // 
            // RoomAddParquetCriterionButton
            // 
            this.RoomAddParquetCriterionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RoomAddParquetCriterionButton.Location = new System.Drawing.Point(297, 316);
            this.RoomAddParquetCriterionButton.Name = "RoomAddParquetCriterionButton";
            this.RoomAddParquetCriterionButton.Size = new System.Drawing.Size(129, 23);
            this.RoomAddParquetCriterionButton.TabIndex = 2;
            this.RoomAddParquetCriterionButton.Text = "Add Criterion";
            this.RoomAddParquetCriterionButton.UseVisualStyleBackColor = true;
            // 
            // RoomDeleteParquetCriterionButton
            // 
            this.RoomDeleteParquetCriterionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RoomDeleteParquetCriterionButton.Location = new System.Drawing.Point(146, 316);
            this.RoomDeleteParquetCriterionButton.Name = "RoomDeleteParquetCriterionButton";
            this.RoomDeleteParquetCriterionButton.Size = new System.Drawing.Size(129, 23);
            this.RoomDeleteParquetCriterionButton.TabIndex = 2;
            this.RoomDeleteParquetCriterionButton.Text = "Remove Criterion";
            this.RoomDeleteParquetCriterionButton.UseVisualStyleBackColor = true;
            // 
            // RoomEntryRequirementsListBox
            // 
            this.RoomEntryRequirementsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.RoomTableLayoutPanel.SetColumnSpan(this.RoomEntryRequirementsListBox, 2);
            this.RoomEntryRequirementsListBox.FormattingEnabled = true;
            this.RoomEntryRequirementsListBox.Location = new System.Drawing.Point(131, 346);
            this.RoomEntryRequirementsListBox.Name = "RoomEntryRequirementsListBox";
            this.RoomEntryRequirementsListBox.Size = new System.Drawing.Size(279, 95);
            this.RoomEntryRequirementsListBox.TabIndex = 1;
            // 
            // RoomParquetCriteriaListBox
            // 
            this.RoomParquetCriteriaListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.RoomTableLayoutPanel.SetColumnSpan(this.RoomParquetCriteriaListBox, 2);
            this.RoomParquetCriteriaListBox.FormattingEnabled = true;
            this.RoomParquetCriteriaListBox.Location = new System.Drawing.Point(131, 213);
            this.RoomParquetCriteriaListBox.Name = "RoomParquetCriteriaListBox";
            this.RoomParquetCriteriaListBox.Size = new System.Drawing.Size(279, 95);
            this.RoomParquetCriteriaListBox.TabIndex = 1;
            // 
            // RoomIsLiquidBasedCheckBox
            // 
            this.RoomIsLiquidBasedCheckBox.AutoSize = true;
            this.RoomIsLiquidBasedCheckBox.Location = new System.Drawing.Point(131, 188);
            this.RoomIsLiquidBasedCheckBox.Name = "RoomIsLiquidBasedCheckBox";
            this.RoomIsLiquidBasedCheckBox.Size = new System.Drawing.Size(15, 14);
            this.RoomIsLiquidBasedCheckBox.TabIndex = 22;
            this.RoomIsLiquidBasedCheckBox.UseVisualStyleBackColor = true;
            // 
            // RoomIsRoomBasedCheckBox
            // 
            this.RoomIsRoomBasedCheckBox.AutoSize = true;
            this.RoomIsRoomBasedCheckBox.Location = new System.Drawing.Point(131, 163);
            this.RoomIsRoomBasedCheckBox.Name = "RoomIsRoomBasedCheckBox";
            this.RoomIsRoomBasedCheckBox.Size = new System.Drawing.Size(15, 14);
            this.RoomIsRoomBasedCheckBox.TabIndex = 22;
            this.RoomIsRoomBasedCheckBox.UseVisualStyleBackColor = true;
            // 
            // RoomNameLabel
            // 
            this.RoomNameLabel.AutoSize = true;
            this.RoomNameLabel.Location = new System.Drawing.Point(3, 0);
            this.RoomNameLabel.Name = "RoomNameLabel";
            this.RoomNameLabel.Size = new System.Drawing.Size(34, 13);
            this.RoomNameLabel.TabIndex = 0;
            this.RoomNameLabel.Text = "Name";
            // 
            // RoomDescriptionLabel
            // 
            this.RoomDescriptionLabel.AutoSize = true;
            this.RoomDescriptionLabel.Location = new System.Drawing.Point(3, 25);
            this.RoomDescriptionLabel.Name = "RoomDescriptionLabel";
            this.RoomDescriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.RoomDescriptionLabel.TabIndex = 3;
            this.RoomDescriptionLabel.Text = "Description";
            // 
            // RoomCommentLabel
            // 
            this.RoomCommentLabel.AutoSize = true;
            this.RoomCommentLabel.Location = new System.Drawing.Point(3, 80);
            this.RoomCommentLabel.Name = "RoomCommentLabel";
            this.RoomCommentLabel.Size = new System.Drawing.Size(52, 13);
            this.RoomCommentLabel.TabIndex = 6;
            this.RoomCommentLabel.Text = "Comment";
            // 
            // RoomTierLabel
            // 
            this.RoomTierLabel.AutoSize = true;
            this.RoomTierLabel.Location = new System.Drawing.Point(3, 135);
            this.RoomTierLabel.Name = "RoomTierLabel";
            this.RoomTierLabel.Size = new System.Drawing.Size(25, 13);
            this.RoomTierLabel.TabIndex = 9;
            this.RoomTierLabel.Text = "Tier";
            // 
            // RoomIsRoomBasedLabel
            // 
            this.RoomIsRoomBasedLabel.AutoSize = true;
            this.RoomIsRoomBasedLabel.Location = new System.Drawing.Point(3, 160);
            this.RoomIsRoomBasedLabel.Name = "RoomIsRoomBasedLabel";
            this.RoomIsRoomBasedLabel.Size = new System.Drawing.Size(84, 13);
            this.RoomIsRoomBasedLabel.TabIndex = 12;
            this.RoomIsRoomBasedLabel.Text = "Is Room-Based?";
            // 
            // RoomIsLiquidBasedLabel
            // 
            this.RoomIsLiquidBasedLabel.AutoSize = true;
            this.RoomIsLiquidBasedLabel.Location = new System.Drawing.Point(3, 185);
            this.RoomIsLiquidBasedLabel.Name = "RoomIsLiquidBasedLabel";
            this.RoomIsLiquidBasedLabel.Size = new System.Drawing.Size(84, 13);
            this.RoomIsLiquidBasedLabel.TabIndex = 15;
            this.RoomIsLiquidBasedLabel.Text = "Is Liquid-Based?";
            // 
            // RoomParquetCriteriaLabel
            // 
            this.RoomParquetCriteriaLabel.AutoSize = true;
            this.RoomParquetCriteriaLabel.Location = new System.Drawing.Point(3, 210);
            this.RoomParquetCriteriaLabel.Name = "RoomParquetCriteriaLabel";
            this.RoomParquetCriteriaLabel.Size = new System.Drawing.Size(83, 13);
            this.RoomParquetCriteriaLabel.TabIndex = 18;
            this.RoomParquetCriteriaLabel.Text = "Parquet Criteria";
            // 
            // RoomEntryRequirementsLabel
            // 
            this.RoomEntryRequirementsLabel.AutoSize = true;
            this.RoomEntryRequirementsLabel.Location = new System.Drawing.Point(3, 343);
            this.RoomEntryRequirementsLabel.Name = "RoomEntryRequirementsLabel";
            this.RoomEntryRequirementsLabel.Size = new System.Drawing.Size(102, 13);
            this.RoomEntryRequirementsLabel.TabIndex = 21;
            this.RoomEntryRequirementsLabel.Text = "Entry Requirements";
            // 
            // RoomNameTextBox
            // 
            this.RoomNameTextBox.Location = new System.Drawing.Point(131, 3);
            this.RoomNameTextBox.Name = "RoomNameTextBox";
            this.RoomNameTextBox.Size = new System.Drawing.Size(144, 20);
            this.RoomNameTextBox.TabIndex = 23;
            // 
            // RoomDescriptionTextBox
            // 
            this.RoomDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RoomTableLayoutPanel.SetColumnSpan(this.RoomDescriptionTextBox, 2);
            this.RoomDescriptionTextBox.Location = new System.Drawing.Point(131, 28);
            this.RoomDescriptionTextBox.Multiline = true;
            this.RoomDescriptionTextBox.Name = "RoomDescriptionTextBox";
            this.RoomDescriptionTextBox.Size = new System.Drawing.Size(295, 49);
            this.RoomDescriptionTextBox.TabIndex = 24;
            // 
            // RoomCommentTextBox
            // 
            this.RoomCommentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RoomTableLayoutPanel.SetColumnSpan(this.RoomCommentTextBox, 2);
            this.RoomCommentTextBox.Location = new System.Drawing.Point(131, 83);
            this.RoomCommentTextBox.Multiline = true;
            this.RoomCommentTextBox.Name = "RoomCommentTextBox";
            this.RoomCommentTextBox.Size = new System.Drawing.Size(295, 49);
            this.RoomCommentTextBox.TabIndex = 25;
            // 
            // RoomTierTextBox
            // 
            this.RoomTierTextBox.Location = new System.Drawing.Point(131, 138);
            this.RoomTierTextBox.Name = "RoomTierTextBox";
            this.RoomTierTextBox.Size = new System.Drawing.Size(144, 20);
            this.RoomTierTextBox.TabIndex = 26;
            // 
            // RoomPictureBox
            // 
            this.RoomPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RoomPictureBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.RoomPictureBox.Location = new System.Drawing.Point(758, 280);
            this.RoomPictureBox.Name = "RoomPictureBox";
            this.RoomPictureBox.Size = new System.Drawing.Size(182, 182);
            this.RoomPictureBox.TabIndex = 6;
            this.RoomPictureBox.TabStop = false;
            // 
            // RoomIDLabel
            // 
            this.RoomIDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RoomIDLabel.AutoSize = true;
            this.RoomIDLabel.Location = new System.Drawing.Point(758, 19);
            this.RoomIDLabel.Name = "RoomIDLabel";
            this.RoomIDLabel.Size = new System.Drawing.Size(48, 13);
            this.RoomIDLabel.TabIndex = 4;
            this.RoomIDLabel.Text = "Room ID";
            // 
            // RoomAddNewRoomButton
            // 
            this.RoomAddNewRoomButton.Location = new System.Drawing.Point(159, 468);
            this.RoomAddNewRoomButton.Name = "RoomAddNewRoomButton";
            this.RoomAddNewRoomButton.Size = new System.Drawing.Size(129, 23);
            this.RoomAddNewRoomButton.TabIndex = 2;
            this.RoomAddNewRoomButton.Text = "Add New Room";
            this.RoomAddNewRoomButton.UseVisualStyleBackColor = true;
            // 
            // RoomIDTextBox
            // 
            this.RoomIDTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RoomIDTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.RoomIDTextBox.Location = new System.Drawing.Point(812, 16);
            this.RoomIDTextBox.Name = "RoomIDTextBox";
            this.RoomIDTextBox.Size = new System.Drawing.Size(131, 20);
            this.RoomIDTextBox.TabIndex = 3;
            this.RoomIDTextBox.Text = "-2020202020";
            // 
            // ScriptsTabPage
            // 
            this.ScriptsTabPage.BackColor = System.Drawing.Color.Transparent;
            this.ScriptsTabPage.Location = new System.Drawing.Point(4, 22);
            this.ScriptsTabPage.Name = "ScriptsTabPage";
            this.ScriptsTabPage.Size = new System.Drawing.Size(952, 599);
            this.ScriptsTabPage.TabIndex = 8;
            this.ScriptsTabPage.Text = "Scripting";
            // 
            // FiltersTableLayoutPanel
            // 
            this.FiltersTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FiltersTableLayoutPanel.ColumnCount = 4;
            this.FiltersTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.FiltersTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.FiltersTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.FiltersTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.FiltersTableLayoutPanel.Controls.Add(this.FilterTextBox, 0, 0);
            this.FiltersTableLayoutPanel.Controls.Add(this.NameFilterCheckBox, 1, 0);
            this.FiltersTableLayoutPanel.Controls.Add(this.StoryIDFilterCheckBox, 1, 1);
            this.FiltersTableLayoutPanel.Controls.Add(this.DescriptionCheckBox, 2, 0);
            this.FiltersTableLayoutPanel.Controls.Add(this.TagsCheckBox, 2, 1);
            this.FiltersTableLayoutPanel.Controls.Add(this.CommentCheckBox, 3, 0);
            this.FiltersTableLayoutPanel.Controls.Add(this.MoreCheckBox, 3, 1);
            this.FiltersTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.FiltersTableLayoutPanel.Location = new System.Drawing.Point(6, 21);
            this.FiltersTableLayoutPanel.Name = "FiltersTableLayoutPanel";
            this.FiltersTableLayoutPanel.RowCount = 2;
            this.FiltersTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.FiltersTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.FiltersTableLayoutPanel.Size = new System.Drawing.Size(443, 50);
            this.FiltersTableLayoutPanel.TabIndex = 3;
            // 
            // FilterTextBox
            // 
            this.FilterTextBox.Location = new System.Drawing.Point(3, 3);
            this.FilterTextBox.Name = "FilterTextBox";
            this.FilterTextBox.Size = new System.Drawing.Size(144, 20);
            this.FilterTextBox.TabIndex = 2;
            // 
            // NameFilterCheckBox
            // 
            this.NameFilterCheckBox.AutoSize = true;
            this.NameFilterCheckBox.Location = new System.Drawing.Point(153, 3);
            this.NameFilterCheckBox.Name = "NameFilterCheckBox";
            this.NameFilterCheckBox.Size = new System.Drawing.Size(53, 17);
            this.NameFilterCheckBox.TabIndex = 3;
            this.NameFilterCheckBox.Text = "Name";
            this.NameFilterCheckBox.UseVisualStyleBackColor = true;
            // 
            // StoryIDFilterCheckBox
            // 
            this.StoryIDFilterCheckBox.AutoSize = true;
            this.StoryIDFilterCheckBox.Location = new System.Drawing.Point(153, 28);
            this.StoryIDFilterCheckBox.Name = "StoryIDFilterCheckBox";
            this.StoryIDFilterCheckBox.Size = new System.Drawing.Size(66, 17);
            this.StoryIDFilterCheckBox.TabIndex = 6;
            this.StoryIDFilterCheckBox.Text = "Story ID";
            this.StoryIDFilterCheckBox.UseVisualStyleBackColor = true;
            // 
            // DescriptionCheckBox
            // 
            this.DescriptionCheckBox.AutoSize = true;
            this.DescriptionCheckBox.Location = new System.Drawing.Point(253, 3);
            this.DescriptionCheckBox.Name = "DescriptionCheckBox";
            this.DescriptionCheckBox.Size = new System.Drawing.Size(79, 17);
            this.DescriptionCheckBox.TabIndex = 4;
            this.DescriptionCheckBox.Text = "Description";
            this.DescriptionCheckBox.UseVisualStyleBackColor = true;
            // 
            // TagsCheckBox
            // 
            this.TagsCheckBox.AutoSize = true;
            this.TagsCheckBox.Location = new System.Drawing.Point(253, 28);
            this.TagsCheckBox.Name = "TagsCheckBox";
            this.TagsCheckBox.Size = new System.Drawing.Size(49, 17);
            this.TagsCheckBox.TabIndex = 7;
            this.TagsCheckBox.Text = "Tags";
            this.TagsCheckBox.UseVisualStyleBackColor = true;
            // 
            // CommentCheckBox
            // 
            this.CommentCheckBox.AutoSize = true;
            this.CommentCheckBox.Location = new System.Drawing.Point(353, 3);
            this.CommentCheckBox.Name = "CommentCheckBox";
            this.CommentCheckBox.Size = new System.Drawing.Size(71, 17);
            this.CommentCheckBox.TabIndex = 5;
            this.CommentCheckBox.Text = "Comment";
            this.CommentCheckBox.UseVisualStyleBackColor = true;
            // 
            // MoreCheckBox
            // 
            this.MoreCheckBox.AutoSize = true;
            this.MoreCheckBox.Location = new System.Drawing.Point(353, 28);
            this.MoreCheckBox.Name = "MoreCheckBox";
            this.MoreCheckBox.Size = new System.Drawing.Size(50, 17);
            this.MoreCheckBox.TabIndex = 8;
            this.MoreCheckBox.Text = "More";
            this.MoreCheckBox.UseVisualStyleBackColor = true;
            // 
            // FilterGroupBox
            // 
            this.FilterGroupBox.Controls.Add(this.FiltersTableLayoutPanel);
            this.FilterGroupBox.Location = new System.Drawing.Point(16, 27);
            this.FilterGroupBox.Name = "FilterGroupBox";
            this.FilterGroupBox.Size = new System.Drawing.Size(455, 78);
            this.FilterGroupBox.TabIndex = 4;
            this.FilterGroupBox.TabStop = false;
            this.FilterGroupBox.Text = "Filter By Text";
            // 
            // FlavorFilterGroupBox
            // 
            this.FlavorFilterGroupBox.Controls.Add(this.FlavorTableLayoutPanel);
            this.FlavorFilterGroupBox.Location = new System.Drawing.Point(477, 27);
            this.FlavorFilterGroupBox.Name = "FlavorFilterGroupBox";
            this.FlavorFilterGroupBox.Size = new System.Drawing.Size(491, 78);
            this.FlavorFilterGroupBox.TabIndex = 5;
            this.FlavorFilterGroupBox.TabStop = false;
            this.FlavorFilterGroupBox.Text = "Filter By Flavor";
            // 
            // FlavorTableLayoutPanel
            // 
            this.FlavorTableLayoutPanel.ColumnCount = 7;
            this.FlavorTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.25F));
            this.FlavorTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.25F));
            this.FlavorTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.25F));
            this.FlavorTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.25F));
            this.FlavorTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.75F));
            this.FlavorTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.25F));
            this.FlavorTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.FlavorTableLayoutPanel.Controls.Add(this.SavourySelector, 0, 1);
            this.FlavorTableLayoutPanel.Controls.Add(this.MetallicSelector, 0, 1);
            this.FlavorTableLayoutPanel.Controls.Add(this.FreshSelector, 0, 1);
            this.FlavorTableLayoutPanel.Controls.Add(this.PungentSelector, 0, 1);
            this.FlavorTableLayoutPanel.Controls.Add(this.NoFlavorsSelector, 0, 1);
            this.FlavorTableLayoutPanel.Controls.Add(this.ChemicalSelector, 0, 1);
            this.FlavorTableLayoutPanel.Controls.Add(this.AstringentSelector, 0, 1);
            this.FlavorTableLayoutPanel.Controls.Add(this.SweetSelector, 1, 0);
            this.FlavorTableLayoutPanel.Controls.Add(this.BlandSelector, 0, 0);
            this.FlavorTableLayoutPanel.Controls.Add(this.BitterSelector, 4, 0);
            this.FlavorTableLayoutPanel.Controls.Add(this.SourSelector, 3, 0);
            this.FlavorTableLayoutPanel.Controls.Add(this.SaltySelector, 2, 0);
            this.FlavorTableLayoutPanel.Controls.Add(this.NumbingSelector, 5, 0);
            this.FlavorTableLayoutPanel.Controls.Add(this.AllFlavorsSelector, 6, 0);
            this.FlavorTableLayoutPanel.Location = new System.Drawing.Point(6, 19);
            this.FlavorTableLayoutPanel.Name = "FlavorTableLayoutPanel";
            this.FlavorTableLayoutPanel.RowCount = 2;
            this.FlavorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.FlavorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.FlavorTableLayoutPanel.Size = new System.Drawing.Size(479, 52);
            this.FlavorTableLayoutPanel.TabIndex = 0;
            // 
            // SavourySelector
            // 
            this.SavourySelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SavourySelector.AutoSize = true;
            this.SavourySelector.BackColor = System.Drawing.Color.PapayaWhip;
            this.SavourySelector.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SavourySelector.Location = new System.Drawing.Point(3, 26);
            this.SavourySelector.Name = "SavourySelector";
            this.SavourySelector.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.SavourySelector.Size = new System.Drawing.Size(62, 26);
            this.SavourySelector.TabIndex = 0;
            this.SavourySelector.Text = "Savoury";
            // 
            // MetallicSelector
            // 
            this.MetallicSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MetallicSelector.AutoSize = true;
            this.MetallicSelector.BackColor = System.Drawing.Color.Gainsboro;
            this.MetallicSelector.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MetallicSelector.Location = new System.Drawing.Point(207, 26);
            this.MetallicSelector.Name = "MetallicSelector";
            this.MetallicSelector.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.MetallicSelector.Size = new System.Drawing.Size(62, 26);
            this.MetallicSelector.TabIndex = 0;
            this.MetallicSelector.Text = "Metallic";
            // 
            // FreshSelector
            // 
            this.FreshSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FreshSelector.AutoSize = true;
            this.FreshSelector.BackColor = System.Drawing.Color.LightCyan;
            this.FreshSelector.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FreshSelector.Location = new System.Drawing.Point(139, 26);
            this.FreshSelector.Name = "FreshSelector";
            this.FreshSelector.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.FreshSelector.Size = new System.Drawing.Size(62, 26);
            this.FreshSelector.TabIndex = 0;
            this.FreshSelector.Text = "Fresh";
            // 
            // PungentSelector
            // 
            this.PungentSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PungentSelector.AutoSize = true;
            this.PungentSelector.BackColor = System.Drawing.Color.Pink;
            this.PungentSelector.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PungentSelector.Location = new System.Drawing.Point(71, 26);
            this.PungentSelector.Name = "PungentSelector";
            this.PungentSelector.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.PungentSelector.Size = new System.Drawing.Size(62, 26);
            this.PungentSelector.TabIndex = 0;
            this.PungentSelector.Text = "Pungent";
            // 
            // NoFlavorsSelector
            // 
            this.NoFlavorsSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NoFlavorsSelector.AutoSize = true;
            this.NoFlavorsSelector.BackColor = System.Drawing.SystemColors.ControlDark;
            this.NoFlavorsSelector.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NoFlavorsSelector.Location = new System.Drawing.Point(413, 26);
            this.NoFlavorsSelector.Name = "NoFlavorsSelector";
            this.NoFlavorsSelector.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.NoFlavorsSelector.Size = new System.Drawing.Size(63, 26);
            this.NoFlavorsSelector.TabIndex = 0;
            this.NoFlavorsSelector.Text = "(None)";
            // 
            // ChemicalSelector
            // 
            this.ChemicalSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChemicalSelector.AutoSize = true;
            this.ChemicalSelector.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ChemicalSelector.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ChemicalSelector.Location = new System.Drawing.Point(345, 26);
            this.ChemicalSelector.Name = "ChemicalSelector";
            this.ChemicalSelector.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.ChemicalSelector.Size = new System.Drawing.Size(62, 26);
            this.ChemicalSelector.TabIndex = 0;
            this.ChemicalSelector.Text = "Chemical";
            // 
            // AstringentSelector
            // 
            this.AstringentSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AstringentSelector.AutoSize = true;
            this.AstringentSelector.BackColor = System.Drawing.Color.Moccasin;
            this.AstringentSelector.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AstringentSelector.Location = new System.Drawing.Point(275, 26);
            this.AstringentSelector.Name = "AstringentSelector";
            this.AstringentSelector.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.AstringentSelector.Size = new System.Drawing.Size(64, 26);
            this.AstringentSelector.TabIndex = 0;
            this.AstringentSelector.Text = "Astringent";
            // 
            // SweetSelector
            // 
            this.SweetSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SweetSelector.AutoSize = true;
            this.SweetSelector.BackColor = System.Drawing.Color.MistyRose;
            this.SweetSelector.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SweetSelector.Location = new System.Drawing.Point(71, 0);
            this.SweetSelector.Name = "SweetSelector";
            this.SweetSelector.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.SweetSelector.Size = new System.Drawing.Size(62, 26);
            this.SweetSelector.TabIndex = 0;
            this.SweetSelector.Text = "Sweet";
            // 
            // BlandSelector
            // 
            this.BlandSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BlandSelector.AutoSize = true;
            this.BlandSelector.BackColor = System.Drawing.Color.NavajoWhite;
            this.BlandSelector.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BlandSelector.Location = new System.Drawing.Point(3, 0);
            this.BlandSelector.Name = "BlandSelector";
            this.BlandSelector.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.BlandSelector.Size = new System.Drawing.Size(62, 26);
            this.BlandSelector.TabIndex = 0;
            this.BlandSelector.Text = "Bland";
            // 
            // BitterSelector
            // 
            this.BitterSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BitterSelector.AutoSize = true;
            this.BitterSelector.BackColor = System.Drawing.Color.LightGreen;
            this.BitterSelector.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BitterSelector.Location = new System.Drawing.Point(275, 0);
            this.BitterSelector.Name = "BitterSelector";
            this.BitterSelector.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.BitterSelector.Size = new System.Drawing.Size(64, 26);
            this.BitterSelector.TabIndex = 0;
            this.BitterSelector.Text = "Bitter";
            // 
            // SourSelector
            // 
            this.SourSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SourSelector.AutoSize = true;
            this.SourSelector.BackColor = System.Drawing.Color.LemonChiffon;
            this.SourSelector.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SourSelector.Location = new System.Drawing.Point(207, 0);
            this.SourSelector.Name = "SourSelector";
            this.SourSelector.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.SourSelector.Size = new System.Drawing.Size(62, 26);
            this.SourSelector.TabIndex = 0;
            this.SourSelector.Text = "Sour";
            // 
            // SaltySelector
            // 
            this.SaltySelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaltySelector.AutoSize = true;
            this.SaltySelector.BackColor = System.Drawing.Color.PowderBlue;
            this.SaltySelector.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SaltySelector.Location = new System.Drawing.Point(139, 0);
            this.SaltySelector.Name = "SaltySelector";
            this.SaltySelector.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.SaltySelector.Size = new System.Drawing.Size(62, 26);
            this.SaltySelector.TabIndex = 0;
            this.SaltySelector.Text = "Salty";
            // 
            // NumbingSelector
            // 
            this.NumbingSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NumbingSelector.AutoSize = true;
            this.NumbingSelector.BackColor = System.Drawing.Color.Plum;
            this.NumbingSelector.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NumbingSelector.Location = new System.Drawing.Point(345, 0);
            this.NumbingSelector.Name = "NumbingSelector";
            this.NumbingSelector.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.NumbingSelector.Size = new System.Drawing.Size(62, 26);
            this.NumbingSelector.TabIndex = 0;
            this.NumbingSelector.Text = "Numbing";
            // 
            // AllFlavorsSelector
            // 
            this.AllFlavorsSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AllFlavorsSelector.AutoSize = true;
            this.AllFlavorsSelector.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AllFlavorsSelector.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AllFlavorsSelector.Location = new System.Drawing.Point(413, 0);
            this.AllFlavorsSelector.Name = "AllFlavorsSelector";
            this.AllFlavorsSelector.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.AllFlavorsSelector.Size = new System.Drawing.Size(63, 26);
            this.AllFlavorsSelector.TabIndex = 0;
            this.AllFlavorsSelector.Text = "(All)";
            // 
            // EditorForm
            // 
            this.AccessibleDescription = "The primary interactive editor window.";
            this.AccessibleName = "Editor Window";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 761);
            this.Controls.Add(this.FlavorFilterGroupBox);
            this.Controls.Add(this.FilterGroupBox);
            this.Controls.Add(this.EditorTabs);
            this.Controls.Add(this.EditorStatusStrip);
            this.Controls.Add(this.MainMenuBar);
            this.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "EditorForm";
            this.Text = "Scribe";
            this.EditorStatusStrip.ResumeLayout(false);
            this.EditorStatusStrip.PerformLayout();
            this.MainMenuBar.ResumeLayout(false);
            this.MainMenuBar.PerformLayout();
            this.EditorTabs.ResumeLayout(false);
            this.GameTabPage.ResumeLayout(false);
            this.GameTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GameIconPictureBox)).EndInit();
            this.GameTableLayoutPanel.ResumeLayout(false);
            this.GameTableLayoutPanel.PerformLayout();
            this.FileFormatGroupBox.ResumeLayout(false);
            this.FileFormatTableLayoutPanel.ResumeLayout(false);
            this.FileFormatTableLayoutPanel.PerformLayout();
            this.LibraryInfoGroupBox.ResumeLayout(false);
            this.LibraryInfoTableLayoutPanel.ResumeLayout(false);
            this.LibraryInfoTableLayoutPanel.PerformLayout();
            this.BiomesTabPage.ResumeLayout(false);
            this.BiomesTabPage.PerformLayout();
            this.BiomeConfigGroupBox.ResumeLayout(false);
            this.BiomeConfigTableLayoutPanel.ResumeLayout(false);
            this.BiomeConfigTableLayoutPanel.PerformLayout();
            this.BiomeTableLayoutPanel.ResumeLayout(false);
            this.BiomeTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BiomePictureBox)).EndInit();
            this.ItemsTabPage.ResumeLayout(false);
            this.ItemsTabPage.PerformLayout();
            this.ItemConfigGroupBox.ResumeLayout(false);
            this.ItemConfigTableLayoutPanel.ResumeLayout(false);
            this.ItemConfigTableLayoutPanel.PerformLayout();
            this.ItemTableLayoutPanel.ResumeLayout(false);
            this.ItemTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemPictureBox)).EndInit();
            this.RoomsTabPage.ResumeLayout(false);
            this.RoomsTabPage.PerformLayout();
            this.RoomConfigGroupBox.ResumeLayout(false);
            this.RoomConfigTableLayoutPanel.ResumeLayout(false);
            this.RoomConfigTableLayoutPanel.PerformLayout();
            this.RoomTableLayoutPanel.ResumeLayout(false);
            this.RoomTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoomPictureBox)).EndInit();
            this.FiltersTableLayoutPanel.ResumeLayout(false);
            this.FiltersTableLayoutPanel.PerformLayout();
            this.FilterGroupBox.ResumeLayout(false);
            this.FlavorFilterGroupBox.ResumeLayout(false);
            this.FlavorTableLayoutPanel.ResumeLayout(false);
            this.FlavorTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.StatusStrip EditorStatusStrip;
        private System.Windows.Forms.MenuStrip MainMenuBar;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UndoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RedoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem CutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem SelectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RollerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ScribeHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DocumentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CheckMapStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ListNameCollisionsStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem ListIDRangesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ListMaxIDsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ListTagsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator5;
        private System.Windows.Forms.TabControl EditorTabs;
        private System.Windows.Forms.TabPage GameTabPage;
        private System.Windows.Forms.TabPage BeingsTabPage;
        private System.Windows.Forms.TabPage BiomesTabPage;
        private System.Windows.Forms.TabPage CraftingTabPage;
        private System.Windows.Forms.TabPage ItemsTabPage;
        private System.Windows.Forms.TabPage MapsTabPage;
        private System.Windows.Forms.TabPage ParquetsTabPage;
        private System.Windows.Forms.TabPage RoomsTabPage;
        private System.Windows.Forms.TabPage ScriptsTabPage;
        private System.Windows.Forms.TableLayoutPanel FiltersTableLayoutPanel;
        private System.Windows.Forms.TextBox FilterTextBox;
        private System.Windows.Forms.CheckBox NameFilterCheckBox;
        private System.Windows.Forms.CheckBox DescriptionCheckBox;
        private System.Windows.Forms.CheckBox CommentCheckBox;
        private System.Windows.Forms.CheckBox StoryIDFilterCheckBox;
        private System.Windows.Forms.CheckBox TagsCheckBox;
        private System.Windows.Forms.CheckBox MoreCheckBox;
        private System.Windows.Forms.GroupBox FilterGroupBox;
        private System.Windows.Forms.GroupBox FlavorFilterGroupBox;
        private System.Windows.Forms.TableLayoutPanel FlavorTableLayoutPanel;
        private System.Windows.Forms.Label SweetSelector;
        private System.Windows.Forms.Label BlandSelector;
        private System.Windows.Forms.Label SavourySelector;
        private System.Windows.Forms.Label MetallicSelector;
        private System.Windows.Forms.Label FreshSelector;
        private System.Windows.Forms.Label PungentSelector;
        private System.Windows.Forms.Label NoFlavorsSelector;
        private System.Windows.Forms.Label ChemicalSelector;
        private System.Windows.Forms.Label AstringentSelector;
        private System.Windows.Forms.Label BitterSelector;
        private System.Windows.Forms.Label SourSelector;
        private System.Windows.Forms.Label SaltySelector;
        private System.Windows.Forms.Label NumbingSelector;
        private System.Windows.Forms.Label AllFlavorsSelector;
        private System.Windows.Forms.ToolStripStatusLabel MainToolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar ToolStripProgressBar;
        private System.Windows.Forms.GroupBox LibraryInfoGroupBox;
        private System.Windows.Forms.GroupBox FileFormatGroupBox;
        private System.Windows.Forms.TableLayoutPanel LibraryInfoTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel FileFormatTableLayoutPanel;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Label VersionExample;
        private System.Windows.Forms.Label WorkingDirectoryLabel;
        private System.Windows.Forms.Label WorkingDirectoryExample;
        private System.Windows.Forms.Label PrimaryDelimiterLabel;
        private System.Windows.Forms.Label PrimaryDelimiterExample;
        private System.Windows.Forms.Label SecondaryDelimiterLabel;
        private System.Windows.Forms.Label SecondaryDelimiterExample;
        private System.Windows.Forms.Label InternalDelimiterLabel;
        private System.Windows.Forms.Label InternalDelimiterExample;
        private System.Windows.Forms.Label ElementDelimiterLabel;
        private System.Windows.Forms.Label ElementDelimiterExample;
        private System.Windows.Forms.Label NameDelimiterLabel;
        private System.Windows.Forms.Label NameDelimiterExample;
        private System.Windows.Forms.Label PronounDelimiterLabel;
        private System.Windows.Forms.Label PronounDelimiterExample;
        private System.Windows.Forms.Label DimensionalDelimiterLabel;
        private System.Windows.Forms.Label DimensionalDelimiterExample;
        private System.Windows.Forms.Label DimensionalTerminatorLabel;
        private System.Windows.Forms.Label DimensionalTerminatorExample;
        private System.Windows.Forms.Button NewGameButton;
        private System.Windows.Forms.ListBox GamesListBox;
        private System.Windows.Forms.TableLayoutPanel GameTableLayoutPanel;
        private System.Windows.Forms.Label GameIDLabel;
        private System.Windows.Forms.TextBox GameIDTextBox;
        private System.Windows.Forms.Label GameNameLabel;
        private System.Windows.Forms.Label GameDescriptionLabel;
        private System.Windows.Forms.Label GameCommentLabel;
        private System.Windows.Forms.Label GameIsEpisodeLabel;
        private System.Windows.Forms.Label GameEpisodeTitleLabel;
        private System.Windows.Forms.Label GameEpisodeNumberLabel;
        private System.Windows.Forms.Label GamePlayerCharacterLabel;
        private System.Windows.Forms.Label GameFirstScriptLabel;
        private System.Windows.Forms.CheckBox GameIsEpisodeCheckBox;
        private System.Windows.Forms.TextBox GameNameTextBox;
        private System.Windows.Forms.TextBox GameDescriptionTextBox;
        private System.Windows.Forms.TextBox GameCommentTextBox;
        private System.Windows.Forms.TextBox GameEpisodeTitleTextBox;
        private System.Windows.Forms.TextBox GameEpisodeNumberTextBox;
        private System.Windows.Forms.TextBox GamePlayerCharacterTextBox;
        private System.Windows.Forms.TextBox GameFirstScriptTextBox;
        private System.Windows.Forms.Button GameIconEditButton;
        private System.Windows.Forms.PictureBox GameIconPictureBox;
        private System.Windows.Forms.ListBox BiomeListBox;
        private System.Windows.Forms.GroupBox BiomeConfigGroupBox;
        private System.Windows.Forms.Button BiomePictureEditButton;
        private System.Windows.Forms.TableLayoutPanel BiomeTableLayoutPanel;
        private System.Windows.Forms.Label BiomeNameLabel;
        private System.Windows.Forms.Label BiomeDescriptionLabel;
        private System.Windows.Forms.Label BiomeCommentLabel;
        private System.Windows.Forms.Label BiomeTierLabel;
        private System.Windows.Forms.Label BiomeIsRoomBasedLabel;
        private System.Windows.Forms.Label BiomeIsLiquidBasedLabel;
        private System.Windows.Forms.Label BiomeParquetCriteriaLabel;
        private System.Windows.Forms.Label BiomeEntryRequirementsLabel;
        private System.Windows.Forms.TextBox BiomeNameTextBox;
        private System.Windows.Forms.TextBox BiomeDescriptionTextBox;
        private System.Windows.Forms.TextBox BiomeCommentTextBox;
        private System.Windows.Forms.TextBox BiomeTierTextBox;
        private System.Windows.Forms.PictureBox BiomePictureBox;
        private System.Windows.Forms.Label BiomeIDLabel;
        private System.Windows.Forms.Button BiomeAddNewBiomeButton;
        private System.Windows.Forms.TextBox BiomeIDTextBox;
        private System.Windows.Forms.CheckBox BiomeIsLiquidBasedCheckBox;
        private System.Windows.Forms.CheckBox BiomeIsRoomBasedCheckBox;
        private System.Windows.Forms.Button BiomeAddEntryRequirementButton;
        private System.Windows.Forms.Button BiomeDeleteEntryRequirementButton;
        private System.Windows.Forms.Button BiomeAddParquetCriterionButton;
        private System.Windows.Forms.Button BiomeDeleteParquetCriterionButton;
        private System.Windows.Forms.ListBox BiomeEntryRequirementsListBox;
        private System.Windows.Forms.ListBox BiomeParquetCriteriaListBox;
        private System.Windows.Forms.TableLayoutPanel BiomeConfigTableLayoutPanel;
        private System.Windows.Forms.Label BiomeLandThresholdFactorLabel;
        private System.Windows.Forms.Label BiomeLiquidThresholdFactorLabel;
        private System.Windows.Forms.TextBox BiomeLandThresholdTextBox;
        private System.Windows.Forms.TextBox BiomeLiquidThresholdFactorTextBox;
        private System.Windows.Forms.TextBox BiomeRoomThresholdFactorTextBox;
        private System.Windows.Forms.Label BiomeRoomThresholdFactorLabel;
        private System.Windows.Forms.ListBox RoomListBox;
        private System.Windows.Forms.GroupBox RoomConfigGroupBox;
        private System.Windows.Forms.Button RoomPictureEditButton;
        private System.Windows.Forms.TableLayoutPanel RoomTableLayoutPanel;
        private System.Windows.Forms.Label RoomNameLabel;
        private System.Windows.Forms.Label RoomDescriptionLabel;
        private System.Windows.Forms.Label RoomCommentLabel;
        private System.Windows.Forms.Label RoomTierLabel;
        private System.Windows.Forms.Label RoomIsRoomBasedLabel;
        private System.Windows.Forms.Label RoomIsLiquidBasedLabel;
        private System.Windows.Forms.Label RoomParquetCriteriaLabel;
        private System.Windows.Forms.Label RoomEntryRequirementsLabel;
        private System.Windows.Forms.TextBox RoomNameTextBox;
        private System.Windows.Forms.TextBox RoomDescriptionTextBox;
        private System.Windows.Forms.TextBox RoomCommentTextBox;
        private System.Windows.Forms.TextBox RoomTierTextBox;
        private System.Windows.Forms.PictureBox RoomPictureBox;
        private System.Windows.Forms.Label RoomIDLabel;
        private System.Windows.Forms.Button RoomAddNewRoomButton;
        private System.Windows.Forms.TextBox RoomIDTextBox;
        private System.Windows.Forms.CheckBox RoomIsLiquidBasedCheckBox;
        private System.Windows.Forms.CheckBox RoomIsRoomBasedCheckBox;
        private System.Windows.Forms.Button RoomAddEntryRequirementButton;
        private System.Windows.Forms.Button RoomDeleteEntryRequirementButton;
        private System.Windows.Forms.Button RoomAddParquetCriterionButton;
        private System.Windows.Forms.Button RoomDeleteParquetCriterionButton;
        private System.Windows.Forms.ListBox RoomEntryRequirementsListBox;
        private System.Windows.Forms.ListBox RoomParquetCriteriaListBox;
        private System.Windows.Forms.TableLayoutPanel RoomConfigTableLayoutPanel;
        private System.Windows.Forms.Label RoomMinWalkableSpacesLabel;
        private System.Windows.Forms.Label RoomMaxWalkableSpacesLabel;
        private System.Windows.Forms.TextBox RoomMinWalkableSpacesTextBox;
        private System.Windows.Forms.TextBox RoomMaxWalkableSpacesTextBox;
        private System.Windows.Forms.ListBox ItemListBox;
        private System.Windows.Forms.GroupBox ItemConfigGroupBox;
        private System.Windows.Forms.Button ItemPictureEditButton;
        private System.Windows.Forms.TableLayoutPanel ItemTableLayoutPanel;
        private System.Windows.Forms.Label ItemNameLabel;
        private System.Windows.Forms.Label ItemDescriptionLabel;
        private System.Windows.Forms.Label ItemCommentLabel;
        private System.Windows.Forms.Label ItemTierLabel;
        private System.Windows.Forms.Label ItemIsItemBasedLabel;
        private System.Windows.Forms.Label ItemIsLiquidBasedLabel;
        private System.Windows.Forms.Label ItemParquetCriteriaLabel;
        private System.Windows.Forms.Label ItemEntryRequirementsLabel;
        private System.Windows.Forms.TextBox ItemNameTextBox;
        private System.Windows.Forms.TextBox ItemDescriptionTextBox;
        private System.Windows.Forms.TextBox ItemCommentTextBox;
        private System.Windows.Forms.TextBox ItemTierTextBox;
        private System.Windows.Forms.PictureBox ItemPictureBox;
        private System.Windows.Forms.Label ItemIDLabel;
        private System.Windows.Forms.Button ItemAddNewItemButton;
        private System.Windows.Forms.TextBox ItemIDTextBox;
        private System.Windows.Forms.CheckBox ItemIsLiquidBasedCheckBox;
        private System.Windows.Forms.CheckBox ItemIsItemBasedCheckBox;
        private System.Windows.Forms.Button ItemAddEntryRequirementButton;
        private System.Windows.Forms.Button ItemDeleteEntryRequirementButton;
        private System.Windows.Forms.Button ItemAddParquetCriterionButton;
        private System.Windows.Forms.Button ItemDeleteParquetCriterionButton;
        private System.Windows.Forms.ListBox ItemEntryRequirementsListBox;
        private System.Windows.Forms.ListBox ItemParquetCriteriaListBox;
        private System.Windows.Forms.TableLayoutPanel ItemConfigTableLayoutPanel;
        private System.Windows.Forms.Label ItemMinWalkableSpacesLabel;
        private System.Windows.Forms.Label ItemMaxWalkableSpacesLabel;
        private System.Windows.Forms.TextBox ItemMinWalkableSpacesTextBox;
        private System.Windows.Forms.TextBox ItemMaxWalkableSpacesTextBox;
    }
}

