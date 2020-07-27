using System;

namespace Scribe
{
    partial class MainEditorForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainEditorForm));
            this.EditorStatusStrip = new System.Windows.Forms.StatusStrip();
            this.MainToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.MainMenuBar = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.FileFormatPrimaryDelimiterLabel = new System.Windows.Forms.Label();
            this.FileFormatPrimaryDelimiterExample = new System.Windows.Forms.Label();
            this.FileFormatSecondaryDelimiterLabel = new System.Windows.Forms.Label();
            this.FileFormatSecondaryDelimiterExample = new System.Windows.Forms.Label();
            this.FileFormatInternalDelimiterLabel = new System.Windows.Forms.Label();
            this.FileFormatInternalDelimiterExample = new System.Windows.Forms.Label();
            this.FileFormatElementDelimiterLabel = new System.Windows.Forms.Label();
            this.FileFormatElementDelimiterExample = new System.Windows.Forms.Label();
            this.FileFormatNameDelimiterLabel = new System.Windows.Forms.Label();
            this.FileFormatNameDelimiterExample = new System.Windows.Forms.Label();
            this.FileFormatPronounDelimiterLabel = new System.Windows.Forms.Label();
            this.FileFormatPronounDelimiterExample = new System.Windows.Forms.Label();
            this.FileFormatDimensionalDelimiterLabel = new System.Windows.Forms.Label();
            this.FileFormatDimensionalDelimiterExample = new System.Windows.Forms.Label();
            this.FileFormatDimensionalTerminatorLabel = new System.Windows.Forms.Label();
            this.FileFormatDimensionalTerminatorExample = new System.Windows.Forms.Label();
            this.LibraryInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.LibraryInfoTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.LibraryVersionLabel = new System.Windows.Forms.Label();
            this.LibraryVersionExample = new System.Windows.Forms.Label();
            this.LibraryWorkingDirectoryLabel = new System.Windows.Forms.Label();
            this.LibraryWorkingDirectoryExample = new System.Windows.Forms.Label();
            this.BeingsTabPage = new System.Windows.Forms.TabPage();
            this.BiomesTabPage = new System.Windows.Forms.TabPage();
            this.BiomeAddEntryRequirementButton = new System.Windows.Forms.Button();
            this.BiomeRemoveEntryRequirementButton = new System.Windows.Forms.Button();
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
            this.BiomeRemoveParquetCriterionButton = new System.Windows.Forms.Button();
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
            this.CraftingListBox = new System.Windows.Forms.ListBox();
            this.CraftingPictureEditButton = new System.Windows.Forms.Button();
            this.CraftingTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CraftingOpenPatternEditorButton = new System.Windows.Forms.Button();
            this.CraftingAddProductButton = new System.Windows.Forms.Button();
            this.CraftingRemoveProductButton = new System.Windows.Forms.Button();
            this.CraftingAddIngredientButton = new System.Windows.Forms.Button();
            this.CraftingRemoveIngredientButton = new System.Windows.Forms.Button();
            this.CraftingIngredientsBox = new System.Windows.Forms.ListBox();
            this.CraftingNameLabel = new System.Windows.Forms.Label();
            this.CraftingDescriptionLabel = new System.Windows.Forms.Label();
            this.CraftingCommentLabel = new System.Windows.Forms.Label();
            this.CraftingIngredientsLabel = new System.Windows.Forms.Label();
            this.CraftingNameTextBox = new System.Windows.Forms.TextBox();
            this.CraftingDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.CraftingCommentTextBox = new System.Windows.Forms.TextBox();
            this.CraftingProductsLabel = new System.Windows.Forms.Label();
            this.CraftingProductsListBox = new System.Windows.Forms.ListBox();
            this.CraftingStrikePatternLabel = new System.Windows.Forms.Label();
            this.CraftingStrikePatternComingSoonLabel = new System.Windows.Forms.Label();
            this.CraftingPictureBox = new System.Windows.Forms.PictureBox();
            this.CraftingIDLabel = new System.Windows.Forms.Label();
            this.CraftingAddNewCraftingButton = new System.Windows.Forms.Button();
            this.CraftingIDTextBox = new System.Windows.Forms.TextBox();
            this.CraftsConfigGroupBox = new System.Windows.Forms.GroupBox();
            this.CraftingConfigTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CraftingMinIngredientCountLabel = new System.Windows.Forms.Label();
            this.CraftingMinProductCountLabel = new System.Windows.Forms.Label();
            this.CraftingMaxIngredientCountLabel = new System.Windows.Forms.Label();
            this.CraftingMaxProductCountLabel = new System.Windows.Forms.Label();
            this.CraftingMinIngredientCountTextBox = new System.Windows.Forms.TextBox();
            this.CraftingMinProductCountTextBox = new System.Windows.Forms.TextBox();
            this.CraftingMaxIngredientCountTextBox = new System.Windows.Forms.TextBox();
            this.CraftingMaxProductCountTextBox = new System.Windows.Forms.TextBox();
            this.CraftingStrikePatternDimensionLabelLabel = new System.Windows.Forms.Label();
            this.CraftingStrikePatternDimensionLabelExample = new System.Windows.Forms.Label();
            this.ItemsTabPage = new System.Windows.Forms.TabPage();
            this.ItemAddTagButton = new System.Windows.Forms.Button();
            this.ItemRemoveTagButton = new System.Windows.Forms.Button();
            this.ItemListBox = new System.Windows.Forms.ListBox();
            this.ItemInventoriesGroupBox = new System.Windows.Forms.GroupBox();
            this.ItemOpenInvetoryEditorButton = new System.Windows.Forms.Button();
            this.ItemInventoryListBox = new System.Windows.Forms.ListBox();
            this.ItemPictureEditButton = new System.Windows.Forms.Button();
            this.ItemTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ItemEffectWhenUsedComboBox = new System.Windows.Forms.ComboBox();
            this.ItemStackMaxTextBox = new System.Windows.Forms.TextBox();
            this.ItemRarityTextBox = new System.Windows.Forms.TextBox();
            this.ItemTagListBox = new System.Windows.Forms.ListBox();
            this.ItemNameLabel = new System.Windows.Forms.Label();
            this.ItemDescriptionLabel = new System.Windows.Forms.Label();
            this.ItemCommentLabel = new System.Windows.Forms.Label();
            this.ItemSubtypeLabel = new System.Windows.Forms.Label();
            this.ItemPriceLabel = new System.Windows.Forms.Label();
            this.ItemRarityLabel = new System.Windows.Forms.Label();
            this.ItemStackMaxLabel = new System.Windows.Forms.Label();
            this.ItemTagsLabel = new System.Windows.Forms.Label();
            this.ItemNameTextBox = new System.Windows.Forms.TextBox();
            this.ItemDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.ItemCommentTextBox = new System.Windows.Forms.TextBox();
            this.ItemPriceTextBox = new System.Windows.Forms.TextBox();
            this.ItemSubtypeComboBox = new System.Windows.Forms.ComboBox();
            this.ItemEffectWhileHeldLabel = new System.Windows.Forms.Label();
            this.ItemEffectWhenUsedLabel = new System.Windows.Forms.Label();
            this.ItemParquetLabel = new System.Windows.Forms.Label();
            this.ItemEffectWhileHeldComboBox = new System.Windows.Forms.ComboBox();
            this.ItemEquivalentParquetComboBox = new System.Windows.Forms.ComboBox();
            this.ItemPictureBox = new System.Windows.Forms.PictureBox();
            this.ItemIDLabel = new System.Windows.Forms.Label();
            this.ItemAddNewItemButton = new System.Windows.Forms.Button();
            this.ItemIDTextBox = new System.Windows.Forms.TextBox();
            this.MapsTabPage = new System.Windows.Forms.TabPage();
            this.MapsComingSoonLabel = new System.Windows.Forms.Label();
            this.FloorsTabPage = new System.Windows.Forms.TabPage();
            this.FloorLayoutTabelPanel = new System.Windows.Forms.TableLayoutPanel();
            this.FloorDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.FloorCommentTextBox = new System.Windows.Forms.TextBox();
            this.FloorNameLabel = new System.Windows.Forms.Label();
            this.FloorDescriptionLabel = new System.Windows.Forms.Label();
            this.FloorCommentLabel = new System.Windows.Forms.Label();
            this.ParquetEquivalentItemIDLabel = new System.Windows.Forms.Label();
            this.ParquetNameTextBox = new System.Windows.Forms.TextBox();
            this.FloorlItemIDComboBox = new System.Windows.Forms.ComboBox();
            this.FloorModificationToolLabel = new System.Windows.Forms.Label();
            this.FloorModificationToolComboBox = new System.Windows.Forms.ComboBox();
            this.FloorTrenchName = new System.Windows.Forms.Label();
            this.FloorTrenchNameTextBox = new System.Windows.Forms.TextBox();
            this.FloorConfigGroupBox = new System.Windows.Forms.GroupBox();
            this.FloorIDTextBox = new System.Windows.Forms.TextBox();
            this.ParquetsAddNewButton = new System.Windows.Forms.Button();
            this.FloorListBox = new System.Windows.Forms.ListBox();
            this.FloorIDLabel = new System.Windows.Forms.Label();
            this.FloorEditImageButton = new System.Windows.Forms.Button();
            this.FloorPictureBox = new System.Windows.Forms.PictureBox();
            this.RoomsTabPage = new System.Windows.Forms.TabPage();
            this.RoomAddBlockButton = new System.Windows.Forms.Button();
            this.RoomRemoveBlockButton = new System.Windows.Forms.Button();
            this.RoomListBox = new System.Windows.Forms.ListBox();
            this.RoomConfigGroupBox = new System.Windows.Forms.GroupBox();
            this.RoomConfigTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.RoomMinWalkableSpacesLabel = new System.Windows.Forms.Label();
            this.RoomMaxWalkableSpacesLabel = new System.Windows.Forms.Label();
            this.RoomMinWalkableSpacesTextBox = new System.Windows.Forms.TextBox();
            this.RoomMaxWalkableSpacesTextBox = new System.Windows.Forms.TextBox();
            this.RoomPictureEditButton = new System.Windows.Forms.Button();
            this.RoomTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.RoomAddFurnishingsButton = new System.Windows.Forms.Button();
            this.RoomRemoveFurnishingsButton = new System.Windows.Forms.Button();
            this.RoomAddFloorButton = new System.Windows.Forms.Button();
            this.RoomRemoveFloorButton = new System.Windows.Forms.Button();
            this.RoomRequiredBlocksListBox = new System.Windows.Forms.ListBox();
            this.RoomRequiredFloorsListBox = new System.Windows.Forms.ListBox();
            this.RoomNameLabel = new System.Windows.Forms.Label();
            this.RoomDescriptionLabel = new System.Windows.Forms.Label();
            this.RoomCommentLabel = new System.Windows.Forms.Label();
            this.RoomTierLabel = new System.Windows.Forms.Label();
            this.RoomRequiredFloorsLabel = new System.Windows.Forms.Label();
            this.RoomRequiredBlocksLabel = new System.Windows.Forms.Label();
            this.RoomNameTextBox = new System.Windows.Forms.TextBox();
            this.RoomDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.RoomCommentTextBox = new System.Windows.Forms.TextBox();
            this.RoomTierTextBox = new System.Windows.Forms.TextBox();
            this.RoomRequiredFurnishingsLabel = new System.Windows.Forms.Label();
            this.RoomRequiredFurnishingsListBox = new System.Windows.Forms.ListBox();
            this.RoomPictureBox = new System.Windows.Forms.PictureBox();
            this.RoomIDLabel = new System.Windows.Forms.Label();
            this.RoomAddNewRoomButton = new System.Windows.Forms.Button();
            this.RoomIDTextBox = new System.Windows.Forms.TextBox();
            this.ScriptsTabPage = new System.Windows.Forms.TabPage();
            this.ScriptingComingSoonLabel = new System.Windows.Forms.Label();
            this.FiltersTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.FilterTextBox = new System.Windows.Forms.TextBox();
            this.FilterByNameCheckBox = new System.Windows.Forms.CheckBox();
            this.FilterByStoryIDCheckBox = new System.Windows.Forms.CheckBox();
            this.FilterByDescriptionCheckBox = new System.Windows.Forms.CheckBox();
            this.FilterByTagsCheckBox = new System.Windows.Forms.CheckBox();
            this.FilterByCommentCheckBox = new System.Windows.Forms.CheckBox();
            this.FilterByMoreCheckBox = new System.Windows.Forms.CheckBox();
            this.FilterGroupBox = new System.Windows.Forms.GroupBox();
            this.FlavorFilterGroupBox = new System.Windows.Forms.GroupBox();
            this.FlavorTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.FlavorSavourySelector = new System.Windows.Forms.Label();
            this.FlavorMetallicSelector = new System.Windows.Forms.Label();
            this.FlavorFreshSelector = new System.Windows.Forms.Label();
            this.FlavorPungentSelector = new System.Windows.Forms.Label();
            this.FlavorNoFlavorsSelector = new System.Windows.Forms.Label();
            this.FlavorChemicalSelector = new System.Windows.Forms.Label();
            this.FlavorAstringentSelector = new System.Windows.Forms.Label();
            this.FlavorSweetSelector = new System.Windows.Forms.Label();
            this.FlavorBlandSelector = new System.Windows.Forms.Label();
            this.FlavorBitterSelector = new System.Windows.Forms.Label();
            this.FlavorSourSelector = new System.Windows.Forms.Label();
            this.FlavorSaltySelector = new System.Windows.Forms.Label();
            this.FlavorNumbingSelector = new System.Windows.Forms.Label();
            this.FlavorAllFlavorsSelector = new System.Windows.Forms.Label();
            this.EditorToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
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
            this.CraftingTabPage.SuspendLayout();
            this.CraftingTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CraftingPictureBox)).BeginInit();
            this.CraftsConfigGroupBox.SuspendLayout();
            this.CraftingConfigTableLayoutPanel.SuspendLayout();
            this.ItemsTabPage.SuspendLayout();
            this.ItemInventoriesGroupBox.SuspendLayout();
            this.ItemTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemPictureBox)).BeginInit();
            this.MapsTabPage.SuspendLayout();
            this.FloorsTabPage.SuspendLayout();
            this.FloorLayoutTabelPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FloorPictureBox)).BeginInit();
            this.RoomsTabPage.SuspendLayout();
            this.RoomConfigGroupBox.SuspendLayout();
            this.RoomConfigTableLayoutPanel.SuspendLayout();
            this.RoomTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoomPictureBox)).BeginInit();
            this.ScriptsTabPage.SuspendLayout();
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
            this.ReloadToolStripMenuItem,
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
            // ReloadToolStripMenuItem
            // 
            this.ReloadToolStripMenuItem.Name = "ReloadToolStripMenuItem";
            this.ReloadToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.ReloadToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.ReloadToolStripMenuItem.Text = "&Reload";
            this.ReloadToolStripMenuItem.Click += new System.EventHandler(this.ReloadToolStripMenuItem_Click);
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
            this.EditorTabs.Controls.Add(this.FloorsTabPage);
            this.EditorTabs.Controls.Add(this.RoomsTabPage);
            this.EditorTabs.Controls.Add(this.ScriptsTabPage);
            this.EditorTabs.Location = new System.Drawing.Point(12, 111);
            this.EditorTabs.Name = "EditorTabs";
            this.EditorTabs.SelectedIndex = 9;
            this.EditorTabs.Size = new System.Drawing.Size(961, 625);
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
            this.GameTabPage.Size = new System.Drawing.Size(953, 599);
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
            this.GameIconPictureBox.Location = new System.Drawing.Point(759, 280);
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
            this.GameIDLabel.Location = new System.Drawing.Point(759, 19);
            this.GameIDLabel.Name = "GameIDLabel";
            this.GameIDLabel.Size = new System.Drawing.Size(48, 13);
            this.GameIDLabel.TabIndex = 4;
            this.GameIDLabel.Text = "Game ID";
            // 
            // GameIDTextBox
            // 
            this.GameIDTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GameIDTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.GameIDTextBox.Location = new System.Drawing.Point(813, 16);
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
            this.FileFormatGroupBox.Size = new System.Drawing.Size(646, 97);
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
            this.FileFormatTableLayoutPanel.Controls.Add(this.FileFormatPrimaryDelimiterLabel, 0, 0);
            this.FileFormatTableLayoutPanel.Controls.Add(this.FileFormatPrimaryDelimiterExample, 1, 0);
            this.FileFormatTableLayoutPanel.Controls.Add(this.FileFormatSecondaryDelimiterLabel, 2, 0);
            this.FileFormatTableLayoutPanel.Controls.Add(this.FileFormatSecondaryDelimiterExample, 3, 0);
            this.FileFormatTableLayoutPanel.Controls.Add(this.FileFormatInternalDelimiterLabel, 4, 0);
            this.FileFormatTableLayoutPanel.Controls.Add(this.FileFormatInternalDelimiterExample, 5, 0);
            this.FileFormatTableLayoutPanel.Controls.Add(this.FileFormatElementDelimiterLabel, 0, 1);
            this.FileFormatTableLayoutPanel.Controls.Add(this.FileFormatElementDelimiterExample, 1, 1);
            this.FileFormatTableLayoutPanel.Controls.Add(this.FileFormatNameDelimiterLabel, 2, 1);
            this.FileFormatTableLayoutPanel.Controls.Add(this.FileFormatNameDelimiterExample, 3, 1);
            this.FileFormatTableLayoutPanel.Controls.Add(this.FileFormatPronounDelimiterLabel, 4, 1);
            this.FileFormatTableLayoutPanel.Controls.Add(this.FileFormatPronounDelimiterExample, 5, 1);
            this.FileFormatTableLayoutPanel.Controls.Add(this.FileFormatDimensionalDelimiterLabel, 0, 2);
            this.FileFormatTableLayoutPanel.Controls.Add(this.FileFormatDimensionalDelimiterExample, 1, 2);
            this.FileFormatTableLayoutPanel.Controls.Add(this.FileFormatDimensionalTerminatorLabel, 2, 2);
            this.FileFormatTableLayoutPanel.Controls.Add(this.FileFormatDimensionalTerminatorExample, 3, 2);
            this.FileFormatTableLayoutPanel.Location = new System.Drawing.Point(6, 19);
            this.FileFormatTableLayoutPanel.Name = "FileFormatTableLayoutPanel";
            this.FileFormatTableLayoutPanel.RowCount = 3;
            this.FileFormatTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.FileFormatTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.FileFormatTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.FileFormatTableLayoutPanel.Size = new System.Drawing.Size(634, 72);
            this.FileFormatTableLayoutPanel.TabIndex = 1;
            // 
            // FileFormatPrimaryDelimiterLabel
            // 
            this.FileFormatPrimaryDelimiterLabel.AutoSize = true;
            this.FileFormatPrimaryDelimiterLabel.Location = new System.Drawing.Point(50, 5);
            this.FileFormatPrimaryDelimiterLabel.Margin = new System.Windows.Forms.Padding(50, 5, 3, 0);
            this.FileFormatPrimaryDelimiterLabel.Name = "FileFormatPrimaryDelimiterLabel";
            this.FileFormatPrimaryDelimiterLabel.Size = new System.Drawing.Size(87, 13);
            this.FileFormatPrimaryDelimiterLabel.TabIndex = 0;
            this.FileFormatPrimaryDelimiterLabel.Text = "Primary Delimiter";
            // 
            // FileFormatPrimaryDelimiterExample
            // 
            this.FileFormatPrimaryDelimiterExample.AutoSize = true;
            this.FileFormatPrimaryDelimiterExample.Location = new System.Drawing.Point(179, 5);
            this.FileFormatPrimaryDelimiterExample.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.FileFormatPrimaryDelimiterExample.Name = "FileFormatPrimaryDelimiterExample";
            this.FileFormatPrimaryDelimiterExample.Size = new System.Drawing.Size(11, 13);
            this.FileFormatPrimaryDelimiterExample.TabIndex = 1;
            this.FileFormatPrimaryDelimiterExample.Text = ",";
            // 
            // FileFormatSecondaryDelimiterLabel
            // 
            this.FileFormatSecondaryDelimiterLabel.AutoSize = true;
            this.FileFormatSecondaryDelimiterLabel.Location = new System.Drawing.Point(260, 5);
            this.FileFormatSecondaryDelimiterLabel.Margin = new System.Windows.Forms.Padding(50, 5, 3, 0);
            this.FileFormatSecondaryDelimiterLabel.Name = "FileFormatSecondaryDelimiterLabel";
            this.FileFormatSecondaryDelimiterLabel.Size = new System.Drawing.Size(102, 13);
            this.FileFormatSecondaryDelimiterLabel.TabIndex = 2;
            this.FileFormatSecondaryDelimiterLabel.Text = "Secondary Delimiter";
            // 
            // FileFormatSecondaryDelimiterExample
            // 
            this.FileFormatSecondaryDelimiterExample.AutoSize = true;
            this.FileFormatSecondaryDelimiterExample.Location = new System.Drawing.Point(389, 5);
            this.FileFormatSecondaryDelimiterExample.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.FileFormatSecondaryDelimiterExample.Name = "FileFormatSecondaryDelimiterExample";
            this.FileFormatSecondaryDelimiterExample.Size = new System.Drawing.Size(18, 13);
            this.FileFormatSecondaryDelimiterExample.TabIndex = 3;
            this.FileFormatSecondaryDelimiterExample.Text = "∟";
            // 
            // FileFormatInternalDelimiterLabel
            // 
            this.FileFormatInternalDelimiterLabel.AutoSize = true;
            this.FileFormatInternalDelimiterLabel.Location = new System.Drawing.Point(470, 5);
            this.FileFormatInternalDelimiterLabel.Margin = new System.Windows.Forms.Padding(50, 5, 3, 0);
            this.FileFormatInternalDelimiterLabel.Name = "FileFormatInternalDelimiterLabel";
            this.FileFormatInternalDelimiterLabel.Size = new System.Drawing.Size(89, 13);
            this.FileFormatInternalDelimiterLabel.TabIndex = 4;
            this.FileFormatInternalDelimiterLabel.Text = "Internal Delimiter";
            // 
            // FileFormatInternalDelimiterExample
            // 
            this.FileFormatInternalDelimiterExample.AutoSize = true;
            this.FileFormatInternalDelimiterExample.Location = new System.Drawing.Point(599, 5);
            this.FileFormatInternalDelimiterExample.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.FileFormatInternalDelimiterExample.Name = "FileFormatInternalDelimiterExample";
            this.FileFormatInternalDelimiterExample.Size = new System.Drawing.Size(11, 13);
            this.FileFormatInternalDelimiterExample.TabIndex = 5;
            this.FileFormatInternalDelimiterExample.Text = "·";
            // 
            // FileFormatElementDelimiterLabel
            // 
            this.FileFormatElementDelimiterLabel.AutoSize = true;
            this.FileFormatElementDelimiterLabel.Location = new System.Drawing.Point(50, 28);
            this.FileFormatElementDelimiterLabel.Margin = new System.Windows.Forms.Padding(50, 5, 3, 0);
            this.FileFormatElementDelimiterLabel.Name = "FileFormatElementDelimiterLabel";
            this.FileFormatElementDelimiterLabel.Size = new System.Drawing.Size(89, 13);
            this.FileFormatElementDelimiterLabel.TabIndex = 6;
            this.FileFormatElementDelimiterLabel.Text = "Element Delimiter";
            // 
            // FileFormatElementDelimiterExample
            // 
            this.FileFormatElementDelimiterExample.AutoSize = true;
            this.FileFormatElementDelimiterExample.Location = new System.Drawing.Point(179, 28);
            this.FileFormatElementDelimiterExample.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.FileFormatElementDelimiterExample.Name = "FileFormatElementDelimiterExample";
            this.FileFormatElementDelimiterExample.Size = new System.Drawing.Size(13, 13);
            this.FileFormatElementDelimiterExample.TabIndex = 7;
            this.FileFormatElementDelimiterExample.Text = "–";
            // 
            // FileFormatNameDelimiterLabel
            // 
            this.FileFormatNameDelimiterLabel.AutoSize = true;
            this.FileFormatNameDelimiterLabel.Location = new System.Drawing.Point(260, 28);
            this.FileFormatNameDelimiterLabel.Margin = new System.Windows.Forms.Padding(50, 5, 3, 0);
            this.FileFormatNameDelimiterLabel.Name = "FileFormatNameDelimiterLabel";
            this.FileFormatNameDelimiterLabel.Size = new System.Drawing.Size(78, 13);
            this.FileFormatNameDelimiterLabel.TabIndex = 8;
            this.FileFormatNameDelimiterLabel.Text = "Name Delimiter";
            // 
            // FileFormatNameDelimiterExample
            // 
            this.FileFormatNameDelimiterExample.AutoSize = true;
            this.FileFormatNameDelimiterExample.Location = new System.Drawing.Point(389, 28);
            this.FileFormatNameDelimiterExample.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.FileFormatNameDelimiterExample.Name = "FileFormatNameDelimiterExample";
            this.FileFormatNameDelimiterExample.Size = new System.Drawing.Size(13, 13);
            this.FileFormatNameDelimiterExample.TabIndex = 9;
            this.FileFormatNameDelimiterExample.Text = "§";
            // 
            // FileFormatPronounDelimiterLabel
            // 
            this.FileFormatPronounDelimiterLabel.AutoSize = true;
            this.FileFormatPronounDelimiterLabel.Location = new System.Drawing.Point(470, 28);
            this.FileFormatPronounDelimiterLabel.Margin = new System.Windows.Forms.Padding(50, 5, 3, 0);
            this.FileFormatPronounDelimiterLabel.Name = "FileFormatPronounDelimiterLabel";
            this.FileFormatPronounDelimiterLabel.Size = new System.Drawing.Size(91, 13);
            this.FileFormatPronounDelimiterLabel.TabIndex = 10;
            this.FileFormatPronounDelimiterLabel.Text = "Pronoun Delimiter";
            // 
            // FileFormatPronounDelimiterExample
            // 
            this.FileFormatPronounDelimiterExample.AutoSize = true;
            this.FileFormatPronounDelimiterExample.Location = new System.Drawing.Point(599, 28);
            this.FileFormatPronounDelimiterExample.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.FileFormatPronounDelimiterExample.Name = "FileFormatPronounDelimiterExample";
            this.FileFormatPronounDelimiterExample.Size = new System.Drawing.Size(11, 13);
            this.FileFormatPronounDelimiterExample.TabIndex = 11;
            this.FileFormatPronounDelimiterExample.Text = "|";
            // 
            // FileFormatDimensionalDelimiterLabel
            // 
            this.FileFormatDimensionalDelimiterLabel.AutoSize = true;
            this.FileFormatDimensionalDelimiterLabel.Location = new System.Drawing.Point(50, 51);
            this.FileFormatDimensionalDelimiterLabel.Margin = new System.Windows.Forms.Padding(50, 5, 3, 0);
            this.FileFormatDimensionalDelimiterLabel.Name = "FileFormatDimensionalDelimiterLabel";
            this.FileFormatDimensionalDelimiterLabel.Size = new System.Drawing.Size(107, 13);
            this.FileFormatDimensionalDelimiterLabel.TabIndex = 12;
            this.FileFormatDimensionalDelimiterLabel.Text = "Dimensional Delimiter";
            // 
            // FileFormatDimensionalDelimiterExample
            // 
            this.FileFormatDimensionalDelimiterExample.AutoSize = true;
            this.FileFormatDimensionalDelimiterExample.Location = new System.Drawing.Point(179, 51);
            this.FileFormatDimensionalDelimiterExample.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.FileFormatDimensionalDelimiterExample.Name = "FileFormatDimensionalDelimiterExample";
            this.FileFormatDimensionalDelimiterExample.Size = new System.Drawing.Size(15, 13);
            this.FileFormatDimensionalDelimiterExample.TabIndex = 13;
            this.FileFormatDimensionalDelimiterExample.Text = "×";
            // 
            // FileFormatDimensionalTerminatorLabel
            // 
            this.FileFormatDimensionalTerminatorLabel.AutoSize = true;
            this.FileFormatDimensionalTerminatorLabel.Location = new System.Drawing.Point(260, 51);
            this.FileFormatDimensionalTerminatorLabel.Margin = new System.Windows.Forms.Padding(50, 5, 3, 0);
            this.FileFormatDimensionalTerminatorLabel.Name = "FileFormatDimensionalTerminatorLabel";
            this.FileFormatDimensionalTerminatorLabel.Size = new System.Drawing.Size(118, 13);
            this.FileFormatDimensionalTerminatorLabel.TabIndex = 14;
            this.FileFormatDimensionalTerminatorLabel.Text = "Dimensional Terminator";
            // 
            // FileFormatDimensionalTerminatorExample
            // 
            this.FileFormatDimensionalTerminatorExample.AutoSize = true;
            this.FileFormatDimensionalTerminatorExample.Location = new System.Drawing.Point(389, 51);
            this.FileFormatDimensionalTerminatorExample.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.FileFormatDimensionalTerminatorExample.Name = "FileFormatDimensionalTerminatorExample";
            this.FileFormatDimensionalTerminatorExample.Size = new System.Drawing.Size(15, 13);
            this.FileFormatDimensionalTerminatorExample.TabIndex = 15;
            this.FileFormatDimensionalTerminatorExample.Text = "≡";
            // 
            // LibraryInfoGroupBox
            // 
            this.LibraryInfoGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LibraryInfoGroupBox.Controls.Add(this.LibraryInfoTableLayoutPanel);
            this.LibraryInfoGroupBox.Location = new System.Drawing.Point(6, 496);
            this.LibraryInfoGroupBox.Name = "LibraryInfoGroupBox";
            this.LibraryInfoGroupBox.Size = new System.Drawing.Size(290, 100);
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
            this.LibraryInfoTableLayoutPanel.Controls.Add(this.LibraryVersionLabel, 0, 0);
            this.LibraryInfoTableLayoutPanel.Controls.Add(this.LibraryVersionExample, 1, 0);
            this.LibraryInfoTableLayoutPanel.Controls.Add(this.LibraryWorkingDirectoryLabel, 2, 0);
            this.LibraryInfoTableLayoutPanel.Controls.Add(this.LibraryWorkingDirectoryExample, 3, 0);
            this.LibraryInfoTableLayoutPanel.Location = new System.Drawing.Point(6, 19);
            this.LibraryInfoTableLayoutPanel.Name = "LibraryInfoTableLayoutPanel";
            this.LibraryInfoTableLayoutPanel.RowCount = 2;
            this.LibraryInfoTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LibraryInfoTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LibraryInfoTableLayoutPanel.Size = new System.Drawing.Size(278, 75);
            this.LibraryInfoTableLayoutPanel.TabIndex = 0;
            // 
            // LibraryVersionLabel
            // 
            this.LibraryVersionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LibraryVersionLabel.AutoSize = true;
            this.LibraryVersionLabel.Location = new System.Drawing.Point(1, 1);
            this.LibraryVersionLabel.Margin = new System.Windows.Forms.Padding(1);
            this.LibraryVersionLabel.Name = "LibraryVersionLabel";
            this.LibraryVersionLabel.Size = new System.Drawing.Size(67, 35);
            this.LibraryVersionLabel.TabIndex = 0;
            this.LibraryVersionLabel.Text = "Version";
            // 
            // LibraryVersionExample
            // 
            this.LibraryVersionExample.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LibraryVersionExample.AutoSize = true;
            this.LibraryVersionExample.Location = new System.Drawing.Point(70, 1);
            this.LibraryVersionExample.Margin = new System.Windows.Forms.Padding(1);
            this.LibraryVersionExample.Name = "LibraryVersionExample";
            this.LibraryVersionExample.Size = new System.Drawing.Size(207, 35);
            this.LibraryVersionExample.TabIndex = 1;
            this.LibraryVersionExample.Text = "0.0.0";
            // 
            // LibraryWorkingDirectoryLabel
            // 
            this.LibraryWorkingDirectoryLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LibraryWorkingDirectoryLabel.AutoSize = true;
            this.LibraryWorkingDirectoryLabel.Location = new System.Drawing.Point(1, 38);
            this.LibraryWorkingDirectoryLabel.Margin = new System.Windows.Forms.Padding(1);
            this.LibraryWorkingDirectoryLabel.Name = "LibraryWorkingDirectoryLabel";
            this.LibraryWorkingDirectoryLabel.Size = new System.Drawing.Size(67, 36);
            this.LibraryWorkingDirectoryLabel.TabIndex = 0;
            this.LibraryWorkingDirectoryLabel.Text = "Working Directory";
            // 
            // LibraryWorkingDirectoryExample
            // 
            this.LibraryWorkingDirectoryExample.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LibraryWorkingDirectoryExample.AutoSize = true;
            this.LibraryWorkingDirectoryExample.Location = new System.Drawing.Point(70, 38);
            this.LibraryWorkingDirectoryExample.Margin = new System.Windows.Forms.Padding(1);
            this.LibraryWorkingDirectoryExample.Name = "LibraryWorkingDirectoryExample";
            this.LibraryWorkingDirectoryExample.Size = new System.Drawing.Size(207, 36);
            this.LibraryWorkingDirectoryExample.TabIndex = 1;
            this.LibraryWorkingDirectoryExample.Text = "C:\\";
            // 
            // BeingsTabPage
            // 
            this.BeingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.BeingsTabPage.Name = "BeingsTabPage";
            this.BeingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.BeingsTabPage.Size = new System.Drawing.Size(953, 599);
            this.BeingsTabPage.TabIndex = 1;
            this.BeingsTabPage.Text = "Beings";
            // 
            // BiomesTabPage
            // 
            this.BiomesTabPage.BackColor = System.Drawing.Color.Transparent;
            this.BiomesTabPage.Controls.Add(this.BiomeAddEntryRequirementButton);
            this.BiomesTabPage.Controls.Add(this.BiomeRemoveEntryRequirementButton);
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
            this.BiomesTabPage.Size = new System.Drawing.Size(953, 599);
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
            // BiomeRemoveEntryRequirementButton
            // 
            this.BiomeRemoveEntryRequirementButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BiomeRemoveEntryRequirementButton.Location = new System.Drawing.Point(453, 468);
            this.BiomeRemoveEntryRequirementButton.Name = "BiomeRemoveEntryRequirementButton";
            this.BiomeRemoveEntryRequirementButton.Size = new System.Drawing.Size(129, 23);
            this.BiomeRemoveEntryRequirementButton.TabIndex = 2;
            this.BiomeRemoveEntryRequirementButton.Text = "Remove Requirement";
            this.BiomeRemoveEntryRequirementButton.UseVisualStyleBackColor = true;
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
            this.BiomeTableLayoutPanel.Controls.Add(this.BiomeRemoveParquetCriterionButton, 1, 7);
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
            // BiomeRemoveParquetCriterionButton
            // 
            this.BiomeRemoveParquetCriterionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BiomeRemoveParquetCriterionButton.Location = new System.Drawing.Point(146, 316);
            this.BiomeRemoveParquetCriterionButton.Name = "BiomeRemoveParquetCriterionButton";
            this.BiomeRemoveParquetCriterionButton.Size = new System.Drawing.Size(129, 23);
            this.BiomeRemoveParquetCriterionButton.TabIndex = 2;
            this.BiomeRemoveParquetCriterionButton.Text = "Remove Criterion";
            this.BiomeRemoveParquetCriterionButton.UseVisualStyleBackColor = true;
            // 
            // BiomeEntryRequirementsListBox
            // 
            this.BiomeEntryRequirementsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BiomeTableLayoutPanel.SetColumnSpan(this.BiomeEntryRequirementsListBox, 2);
            this.BiomeEntryRequirementsListBox.FormattingEnabled = true;
            this.BiomeEntryRequirementsListBox.Location = new System.Drawing.Point(131, 346);
            this.BiomeEntryRequirementsListBox.Name = "BiomeEntryRequirementsListBox";
            this.BiomeEntryRequirementsListBox.Size = new System.Drawing.Size(295, 95);
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
            this.BiomeParquetCriteriaListBox.Size = new System.Drawing.Size(295, 95);
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
            this.CraftingTabPage.Controls.Add(this.CraftingListBox);
            this.CraftingTabPage.Controls.Add(this.CraftingPictureEditButton);
            this.CraftingTabPage.Controls.Add(this.CraftingTableLayoutPanel);
            this.CraftingTabPage.Controls.Add(this.CraftingPictureBox);
            this.CraftingTabPage.Controls.Add(this.CraftingIDLabel);
            this.CraftingTabPage.Controls.Add(this.CraftingAddNewCraftingButton);
            this.CraftingTabPage.Controls.Add(this.CraftingIDTextBox);
            this.CraftingTabPage.Controls.Add(this.CraftsConfigGroupBox);
            this.CraftingTabPage.Location = new System.Drawing.Point(4, 22);
            this.CraftingTabPage.Name = "CraftingTabPage";
            this.CraftingTabPage.Size = new System.Drawing.Size(953, 599);
            this.CraftingTabPage.TabIndex = 3;
            this.CraftingTabPage.Text = "Crafting";
            // 
            // CraftingListBox
            // 
            this.CraftingListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CraftingListBox.FormattingEnabled = true;
            this.CraftingListBox.Location = new System.Drawing.Point(9, 16);
            this.CraftingListBox.Name = "CraftingListBox";
            this.CraftingListBox.Size = new System.Drawing.Size(279, 446);
            this.CraftingListBox.TabIndex = 1;
            // 
            // CraftingPictureEditButton
            // 
            this.CraftingPictureEditButton.Location = new System.Drawing.Point(812, 468);
            this.CraftingPictureEditButton.Name = "CraftingPictureEditButton";
            this.CraftingPictureEditButton.Size = new System.Drawing.Size(128, 23);
            this.CraftingPictureEditButton.TabIndex = 7;
            this.CraftingPictureEditButton.Text = "Edit Image";
            this.CraftingPictureEditButton.UseVisualStyleBackColor = true;
            // 
            // CraftingTableLayoutPanel
            // 
            this.CraftingTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CraftingTableLayoutPanel.ColumnCount = 3;
            this.CraftingTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.CraftingTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.CraftingTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.CraftingTableLayoutPanel.Controls.Add(this.CraftingOpenPatternEditorButton, 2, 7);
            this.CraftingTableLayoutPanel.Controls.Add(this.CraftingAddProductButton, 2, 4);
            this.CraftingTableLayoutPanel.Controls.Add(this.CraftingRemoveProductButton, 1, 4);
            this.CraftingTableLayoutPanel.Controls.Add(this.CraftingAddIngredientButton, 2, 6);
            this.CraftingTableLayoutPanel.Controls.Add(this.CraftingRemoveIngredientButton, 1, 6);
            this.CraftingTableLayoutPanel.Controls.Add(this.CraftingIngredientsBox, 1, 5);
            this.CraftingTableLayoutPanel.Controls.Add(this.CraftingNameLabel, 0, 0);
            this.CraftingTableLayoutPanel.Controls.Add(this.CraftingDescriptionLabel, 0, 1);
            this.CraftingTableLayoutPanel.Controls.Add(this.CraftingCommentLabel, 0, 2);
            this.CraftingTableLayoutPanel.Controls.Add(this.CraftingIngredientsLabel, 0, 5);
            this.CraftingTableLayoutPanel.Controls.Add(this.CraftingNameTextBox, 1, 0);
            this.CraftingTableLayoutPanel.Controls.Add(this.CraftingDescriptionTextBox, 1, 1);
            this.CraftingTableLayoutPanel.Controls.Add(this.CraftingCommentTextBox, 1, 2);
            this.CraftingTableLayoutPanel.Controls.Add(this.CraftingProductsLabel, 0, 3);
            this.CraftingTableLayoutPanel.Controls.Add(this.CraftingProductsListBox, 1, 3);
            this.CraftingTableLayoutPanel.Controls.Add(this.CraftingStrikePatternLabel, 0, 7);
            this.CraftingTableLayoutPanel.Controls.Add(this.CraftingStrikePatternComingSoonLabel, 1, 7);
            this.CraftingTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.CraftingTableLayoutPanel.Location = new System.Drawing.Point(307, 16);
            this.CraftingTableLayoutPanel.Name = "CraftingTableLayoutPanel";
            this.CraftingTableLayoutPanel.RowCount = 8;
            this.CraftingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.CraftingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.CraftingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.CraftingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.CraftingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.CraftingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.CraftingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.CraftingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CraftingTableLayoutPanel.Size = new System.Drawing.Size(429, 446);
            this.CraftingTableLayoutPanel.TabIndex = 5;
            // 
            // CraftingOpenPatternEditorButton
            // 
            this.CraftingOpenPatternEditorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CraftingOpenPatternEditorButton.Location = new System.Drawing.Point(297, 420);
            this.CraftingOpenPatternEditorButton.Name = "CraftingOpenPatternEditorButton";
            this.CraftingOpenPatternEditorButton.Size = new System.Drawing.Size(129, 23);
            this.CraftingOpenPatternEditorButton.TabIndex = 2;
            this.CraftingOpenPatternEditorButton.Text = "Open Pattern Editor";
            this.CraftingOpenPatternEditorButton.UseVisualStyleBackColor = true;
            // 
            // CraftingAddProductButton
            // 
            this.CraftingAddProductButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CraftingAddProductButton.Location = new System.Drawing.Point(297, 193);
            this.CraftingAddProductButton.Name = "CraftingAddProductButton";
            this.CraftingAddProductButton.Size = new System.Drawing.Size(129, 23);
            this.CraftingAddProductButton.TabIndex = 30;
            this.CraftingAddProductButton.Text = "Add Product";
            this.CraftingAddProductButton.UseVisualStyleBackColor = true;
            // 
            // CraftingRemoveProductButton
            // 
            this.CraftingRemoveProductButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CraftingRemoveProductButton.Location = new System.Drawing.Point(154, 193);
            this.CraftingRemoveProductButton.Name = "CraftingRemoveProductButton";
            this.CraftingRemoveProductButton.Size = new System.Drawing.Size(129, 23);
            this.CraftingRemoveProductButton.TabIndex = 29;
            this.CraftingRemoveProductButton.Text = "Remove Product";
            this.CraftingRemoveProductButton.UseVisualStyleBackColor = true;
            // 
            // CraftingAddIngredientButton
            // 
            this.CraftingAddIngredientButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CraftingAddIngredientButton.Location = new System.Drawing.Point(297, 278);
            this.CraftingAddIngredientButton.Name = "CraftingAddIngredientButton";
            this.CraftingAddIngredientButton.Size = new System.Drawing.Size(129, 23);
            this.CraftingAddIngredientButton.TabIndex = 2;
            this.CraftingAddIngredientButton.Text = "Add Ingredient";
            this.CraftingAddIngredientButton.UseVisualStyleBackColor = true;
            // 
            // CraftingRemoveIngredientButton
            // 
            this.CraftingRemoveIngredientButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CraftingRemoveIngredientButton.Location = new System.Drawing.Point(154, 278);
            this.CraftingRemoveIngredientButton.Name = "CraftingRemoveIngredientButton";
            this.CraftingRemoveIngredientButton.Size = new System.Drawing.Size(129, 23);
            this.CraftingRemoveIngredientButton.TabIndex = 2;
            this.CraftingRemoveIngredientButton.Text = "Remove Ingredient";
            this.CraftingRemoveIngredientButton.UseVisualStyleBackColor = true;
            // 
            // CraftingIngredientsBox
            // 
            this.CraftingIngredientsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CraftingTableLayoutPanel.SetColumnSpan(this.CraftingIngredientsBox, 2);
            this.CraftingIngredientsBox.FormattingEnabled = true;
            this.CraftingIngredientsBox.Location = new System.Drawing.Point(146, 223);
            this.CraftingIngredientsBox.Name = "CraftingIngredientsBox";
            this.CraftingIngredientsBox.Size = new System.Drawing.Size(279, 43);
            this.CraftingIngredientsBox.TabIndex = 1;
            // 
            // CraftingNameLabel
            // 
            this.CraftingNameLabel.AutoSize = true;
            this.CraftingNameLabel.Location = new System.Drawing.Point(3, 0);
            this.CraftingNameLabel.Name = "CraftingNameLabel";
            this.CraftingNameLabel.Size = new System.Drawing.Size(34, 13);
            this.CraftingNameLabel.TabIndex = 0;
            this.CraftingNameLabel.Text = "Name";
            // 
            // CraftingDescriptionLabel
            // 
            this.CraftingDescriptionLabel.AutoSize = true;
            this.CraftingDescriptionLabel.Location = new System.Drawing.Point(3, 25);
            this.CraftingDescriptionLabel.Name = "CraftingDescriptionLabel";
            this.CraftingDescriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.CraftingDescriptionLabel.TabIndex = 3;
            this.CraftingDescriptionLabel.Text = "Description";
            // 
            // CraftingCommentLabel
            // 
            this.CraftingCommentLabel.AutoSize = true;
            this.CraftingCommentLabel.Location = new System.Drawing.Point(3, 80);
            this.CraftingCommentLabel.Name = "CraftingCommentLabel";
            this.CraftingCommentLabel.Size = new System.Drawing.Size(52, 13);
            this.CraftingCommentLabel.TabIndex = 6;
            this.CraftingCommentLabel.Text = "Comment";
            // 
            // CraftingIngredientsLabel
            // 
            this.CraftingIngredientsLabel.AutoSize = true;
            this.CraftingIngredientsLabel.Location = new System.Drawing.Point(3, 220);
            this.CraftingIngredientsLabel.Name = "CraftingIngredientsLabel";
            this.CraftingIngredientsLabel.Size = new System.Drawing.Size(62, 13);
            this.CraftingIngredientsLabel.TabIndex = 18;
            this.CraftingIngredientsLabel.Text = "Ingredients";
            // 
            // CraftingNameTextBox
            // 
            this.CraftingNameTextBox.Location = new System.Drawing.Point(146, 3);
            this.CraftingNameTextBox.Name = "CraftingNameTextBox";
            this.CraftingNameTextBox.Size = new System.Drawing.Size(136, 20);
            this.CraftingNameTextBox.TabIndex = 23;
            // 
            // CraftingDescriptionTextBox
            // 
            this.CraftingDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CraftingTableLayoutPanel.SetColumnSpan(this.CraftingDescriptionTextBox, 2);
            this.CraftingDescriptionTextBox.Location = new System.Drawing.Point(146, 28);
            this.CraftingDescriptionTextBox.Multiline = true;
            this.CraftingDescriptionTextBox.Name = "CraftingDescriptionTextBox";
            this.CraftingDescriptionTextBox.Size = new System.Drawing.Size(280, 49);
            this.CraftingDescriptionTextBox.TabIndex = 24;
            // 
            // CraftingCommentTextBox
            // 
            this.CraftingCommentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CraftingTableLayoutPanel.SetColumnSpan(this.CraftingCommentTextBox, 2);
            this.CraftingCommentTextBox.Location = new System.Drawing.Point(146, 83);
            this.CraftingCommentTextBox.Multiline = true;
            this.CraftingCommentTextBox.Name = "CraftingCommentTextBox";
            this.CraftingCommentTextBox.Size = new System.Drawing.Size(280, 49);
            this.CraftingCommentTextBox.TabIndex = 25;
            // 
            // CraftingProductsLabel
            // 
            this.CraftingProductsLabel.AutoSize = true;
            this.CraftingProductsLabel.Location = new System.Drawing.Point(3, 135);
            this.CraftingProductsLabel.Name = "CraftingProductsLabel";
            this.CraftingProductsLabel.Size = new System.Drawing.Size(49, 13);
            this.CraftingProductsLabel.TabIndex = 27;
            this.CraftingProductsLabel.Text = "Products";
            // 
            // CraftingProductsListBox
            // 
            this.CraftingProductsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CraftingTableLayoutPanel.SetColumnSpan(this.CraftingProductsListBox, 2);
            this.CraftingProductsListBox.Location = new System.Drawing.Point(146, 138);
            this.CraftingProductsListBox.Name = "CraftingProductsListBox";
            this.CraftingProductsListBox.Size = new System.Drawing.Size(279, 43);
            this.CraftingProductsListBox.TabIndex = 28;
            // 
            // CraftingStrikePatternLabel
            // 
            this.CraftingStrikePatternLabel.AutoSize = true;
            this.CraftingStrikePatternLabel.Location = new System.Drawing.Point(3, 305);
            this.CraftingStrikePatternLabel.Name = "CraftingStrikePatternLabel";
            this.CraftingStrikePatternLabel.Size = new System.Drawing.Size(115, 13);
            this.CraftingStrikePatternLabel.TabIndex = 31;
            this.CraftingStrikePatternLabel.Text = "Crafting Strike Pattern";
            // 
            // CraftingStrikePatternComingSoonLabel
            // 
            this.CraftingStrikePatternComingSoonLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CraftingStrikePatternComingSoonLabel.AutoSize = true;
            this.CraftingStrikePatternComingSoonLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CraftingStrikePatternComingSoonLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.CraftingStrikePatternComingSoonLabel.Location = new System.Drawing.Point(146, 305);
            this.CraftingStrikePatternComingSoonLabel.Name = "CraftingStrikePatternComingSoonLabel";
            this.CraftingStrikePatternComingSoonLabel.Size = new System.Drawing.Size(137, 141);
            this.CraftingStrikePatternComingSoonLabel.TabIndex = 32;
            this.CraftingStrikePatternComingSoonLabel.Text = "Maybe one day we will have a preview image here.";
            this.CraftingStrikePatternComingSoonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CraftingPictureBox
            // 
            this.CraftingPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CraftingPictureBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.CraftingPictureBox.Location = new System.Drawing.Point(759, 280);
            this.CraftingPictureBox.Name = "CraftingPictureBox";
            this.CraftingPictureBox.Size = new System.Drawing.Size(182, 182);
            this.CraftingPictureBox.TabIndex = 6;
            this.CraftingPictureBox.TabStop = false;
            // 
            // CraftingIDLabel
            // 
            this.CraftingIDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CraftingIDLabel.AutoSize = true;
            this.CraftingIDLabel.Location = new System.Drawing.Point(759, 19);
            this.CraftingIDLabel.Name = "CraftingIDLabel";
            this.CraftingIDLabel.Size = new System.Drawing.Size(46, 13);
            this.CraftingIDLabel.TabIndex = 4;
            this.CraftingIDLabel.Text = "Craft ID";
            // 
            // CraftingAddNewCraftingButton
            // 
            this.CraftingAddNewCraftingButton.Location = new System.Drawing.Point(142, 468);
            this.CraftingAddNewCraftingButton.Name = "CraftingAddNewCraftingButton";
            this.CraftingAddNewCraftingButton.Size = new System.Drawing.Size(146, 23);
            this.CraftingAddNewCraftingButton.TabIndex = 2;
            this.CraftingAddNewCraftingButton.Text = "Add New Crafting Recipe";
            this.CraftingAddNewCraftingButton.UseVisualStyleBackColor = true;
            // 
            // CraftingIDTextBox
            // 
            this.CraftingIDTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CraftingIDTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.CraftingIDTextBox.Location = new System.Drawing.Point(813, 16);
            this.CraftingIDTextBox.Name = "CraftingIDTextBox";
            this.CraftingIDTextBox.Size = new System.Drawing.Size(131, 20);
            this.CraftingIDTextBox.TabIndex = 3;
            this.CraftingIDTextBox.Text = "-2020202020";
            // 
            // CraftsConfigGroupBox
            // 
            this.CraftsConfigGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CraftsConfigGroupBox.Controls.Add(this.CraftingConfigTableLayoutPanel);
            this.CraftsConfigGroupBox.Location = new System.Drawing.Point(6, 496);
            this.CraftsConfigGroupBox.Name = "CraftsConfigGroupBox";
            this.CraftsConfigGroupBox.Size = new System.Drawing.Size(940, 100);
            this.CraftsConfigGroupBox.TabIndex = 0;
            this.CraftsConfigGroupBox.TabStop = false;
            this.CraftsConfigGroupBox.Text = "Configuration";
            // 
            // CraftingConfigTableLayoutPanel
            // 
            this.CraftingConfigTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CraftingConfigTableLayoutPanel.ColumnCount = 5;
            this.CraftingConfigTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.CraftingConfigTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.CraftingConfigTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.CraftingConfigTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.CraftingConfigTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.CraftingConfigTableLayoutPanel.Controls.Add(this.CraftingMinIngredientCountLabel, 0, 0);
            this.CraftingConfigTableLayoutPanel.Controls.Add(this.CraftingMinProductCountLabel, 0, 1);
            this.CraftingConfigTableLayoutPanel.Controls.Add(this.CraftingMaxIngredientCountLabel, 2, 0);
            this.CraftingConfigTableLayoutPanel.Controls.Add(this.CraftingMaxProductCountLabel, 2, 1);
            this.CraftingConfigTableLayoutPanel.Controls.Add(this.CraftingMinIngredientCountTextBox, 1, 0);
            this.CraftingConfigTableLayoutPanel.Controls.Add(this.CraftingMinProductCountTextBox, 1, 1);
            this.CraftingConfigTableLayoutPanel.Controls.Add(this.CraftingMaxIngredientCountTextBox, 3, 0);
            this.CraftingConfigTableLayoutPanel.Controls.Add(this.CraftingMaxProductCountTextBox, 3, 1);
            this.CraftingConfigTableLayoutPanel.Controls.Add(this.CraftingStrikePatternDimensionLabelLabel, 0, 2);
            this.CraftingConfigTableLayoutPanel.Controls.Add(this.CraftingStrikePatternDimensionLabelExample, 1, 2);
            this.CraftingConfigTableLayoutPanel.Location = new System.Drawing.Point(6, 19);
            this.CraftingConfigTableLayoutPanel.Name = "CraftingConfigTableLayoutPanel";
            this.CraftingConfigTableLayoutPanel.RowCount = 3;
            this.CraftingConfigTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.CraftingConfigTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.CraftingConfigTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.CraftingConfigTableLayoutPanel.Size = new System.Drawing.Size(928, 75);
            this.CraftingConfigTableLayoutPanel.TabIndex = 0;
            // 
            // CraftingMinIngredientCountLabel
            // 
            this.CraftingMinIngredientCountLabel.AutoSize = true;
            this.CraftingMinIngredientCountLabel.Location = new System.Drawing.Point(3, 0);
            this.CraftingMinIngredientCountLabel.Name = "CraftingMinIngredientCountLabel";
            this.CraftingMinIngredientCountLabel.Size = new System.Drawing.Size(135, 13);
            this.CraftingMinIngredientCountLabel.TabIndex = 0;
            this.CraftingMinIngredientCountLabel.Text = "Minimum Ingredient Count ";
            // 
            // CraftingMinProductCountLabel
            // 
            this.CraftingMinProductCountLabel.AutoSize = true;
            this.CraftingMinProductCountLabel.Location = new System.Drawing.Point(3, 24);
            this.CraftingMinProductCountLabel.Name = "CraftingMinProductCountLabel";
            this.CraftingMinProductCountLabel.Size = new System.Drawing.Size(119, 13);
            this.CraftingMinProductCountLabel.TabIndex = 1;
            this.CraftingMinProductCountLabel.Text = "Minimum Product Count";
            // 
            // CraftingMaxIngredientCountLabel
            // 
            this.CraftingMaxIngredientCountLabel.AutoSize = true;
            this.CraftingMaxIngredientCountLabel.Location = new System.Drawing.Point(280, 0);
            this.CraftingMaxIngredientCountLabel.Name = "CraftingMaxIngredientCountLabel";
            this.CraftingMaxIngredientCountLabel.Size = new System.Drawing.Size(139, 13);
            this.CraftingMaxIngredientCountLabel.TabIndex = 2;
            this.CraftingMaxIngredientCountLabel.Text = "Maximum Ingredient Count ";
            // 
            // CraftingMaxProductCountLabel
            // 
            this.CraftingMaxProductCountLabel.AutoSize = true;
            this.CraftingMaxProductCountLabel.Location = new System.Drawing.Point(280, 24);
            this.CraftingMaxProductCountLabel.Name = "CraftingMaxProductCountLabel";
            this.CraftingMaxProductCountLabel.Size = new System.Drawing.Size(123, 13);
            this.CraftingMaxProductCountLabel.TabIndex = 3;
            this.CraftingMaxProductCountLabel.Text = "Maximum Product Count";
            // 
            // CraftingMinIngredientCountTextBox
            // 
            this.CraftingMinIngredientCountTextBox.Location = new System.Drawing.Point(160, 3);
            this.CraftingMinIngredientCountTextBox.Name = "CraftingMinIngredientCountTextBox";
            this.CraftingMinIngredientCountTextBox.Size = new System.Drawing.Size(114, 20);
            this.CraftingMinIngredientCountTextBox.TabIndex = 4;
            // 
            // CraftingMinProductCountTextBox
            // 
            this.CraftingMinProductCountTextBox.Location = new System.Drawing.Point(160, 27);
            this.CraftingMinProductCountTextBox.Name = "CraftingMinProductCountTextBox";
            this.CraftingMinProductCountTextBox.Size = new System.Drawing.Size(114, 20);
            this.CraftingMinProductCountTextBox.TabIndex = 5;
            // 
            // CraftingMaxIngredientCountTextBox
            // 
            this.CraftingMaxIngredientCountTextBox.Location = new System.Drawing.Point(437, 3);
            this.CraftingMaxIngredientCountTextBox.Name = "CraftingMaxIngredientCountTextBox";
            this.CraftingMaxIngredientCountTextBox.Size = new System.Drawing.Size(114, 20);
            this.CraftingMaxIngredientCountTextBox.TabIndex = 6;
            // 
            // CraftingMaxProductCountTextBox
            // 
            this.CraftingMaxProductCountTextBox.Location = new System.Drawing.Point(437, 27);
            this.CraftingMaxProductCountTextBox.Name = "CraftingMaxProductCountTextBox";
            this.CraftingMaxProductCountTextBox.Size = new System.Drawing.Size(114, 20);
            this.CraftingMaxProductCountTextBox.TabIndex = 7;
            // 
            // CraftingStrikePatternDimensionLabelLabel
            // 
            this.CraftingStrikePatternDimensionLabelLabel.AutoSize = true;
            this.CraftingStrikePatternDimensionLabelLabel.Location = new System.Drawing.Point(3, 48);
            this.CraftingStrikePatternDimensionLabelLabel.Name = "CraftingStrikePatternDimensionLabelLabel";
            this.CraftingStrikePatternDimensionLabelLabel.Size = new System.Drawing.Size(129, 13);
            this.CraftingStrikePatternDimensionLabelLabel.TabIndex = 8;
            this.CraftingStrikePatternDimensionLabelLabel.Text = "Strike Pattern Dimensions";
            // 
            // CraftingStrikePatternDimensionLabelExample
            // 
            this.CraftingStrikePatternDimensionLabelExample.AutoSize = true;
            this.CraftingStrikePatternDimensionLabelExample.Location = new System.Drawing.Point(160, 48);
            this.CraftingStrikePatternDimensionLabelExample.Name = "CraftingStrikePatternDimensionLabelExample";
            this.CraftingStrikePatternDimensionLabelExample.Size = new System.Drawing.Size(31, 13);
            this.CraftingStrikePatternDimensionLabelExample.TabIndex = 9;
            this.CraftingStrikePatternDimensionLabelExample.Text = "2 x 2";
            // 
            // ItemsTabPage
            // 
            this.ItemsTabPage.BackColor = System.Drawing.Color.Transparent;
            this.ItemsTabPage.Controls.Add(this.ItemAddTagButton);
            this.ItemsTabPage.Controls.Add(this.ItemRemoveTagButton);
            this.ItemsTabPage.Controls.Add(this.ItemListBox);
            this.ItemsTabPage.Controls.Add(this.ItemInventoriesGroupBox);
            this.ItemsTabPage.Controls.Add(this.ItemPictureEditButton);
            this.ItemsTabPage.Controls.Add(this.ItemTableLayoutPanel);
            this.ItemsTabPage.Controls.Add(this.ItemPictureBox);
            this.ItemsTabPage.Controls.Add(this.ItemIDLabel);
            this.ItemsTabPage.Controls.Add(this.ItemAddNewItemButton);
            this.ItemsTabPage.Controls.Add(this.ItemIDTextBox);
            this.ItemsTabPage.Location = new System.Drawing.Point(4, 22);
            this.ItemsTabPage.Name = "ItemsTabPage";
            this.ItemsTabPage.Size = new System.Drawing.Size(953, 599);
            this.ItemsTabPage.TabIndex = 4;
            this.ItemsTabPage.Text = "Items";
            // 
            // ItemAddTagButton
            // 
            this.ItemAddTagButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemAddTagButton.Location = new System.Drawing.Point(605, 468);
            this.ItemAddTagButton.Name = "ItemAddTagButton";
            this.ItemAddTagButton.Size = new System.Drawing.Size(129, 23);
            this.ItemAddTagButton.TabIndex = 2;
            this.ItemAddTagButton.Text = "Add Tag";
            this.ItemAddTagButton.UseVisualStyleBackColor = true;
            // 
            // ItemRemoveTagButton
            // 
            this.ItemRemoveTagButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemRemoveTagButton.Location = new System.Drawing.Point(454, 468);
            this.ItemRemoveTagButton.Name = "ItemRemoveTagButton";
            this.ItemRemoveTagButton.Size = new System.Drawing.Size(129, 23);
            this.ItemRemoveTagButton.TabIndex = 2;
            this.ItemRemoveTagButton.Text = "Remove Tag";
            this.ItemRemoveTagButton.UseVisualStyleBackColor = true;
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
            // ItemInventoriesGroupBox
            // 
            this.ItemInventoriesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemInventoriesGroupBox.Controls.Add(this.ItemOpenInvetoryEditorButton);
            this.ItemInventoriesGroupBox.Controls.Add(this.ItemInventoryListBox);
            this.ItemInventoriesGroupBox.Location = new System.Drawing.Point(9, 497);
            this.ItemInventoriesGroupBox.Name = "ItemInventoriesGroupBox";
            this.ItemInventoriesGroupBox.Size = new System.Drawing.Size(938, 99);
            this.ItemInventoriesGroupBox.TabIndex = 0;
            this.ItemInventoriesGroupBox.TabStop = false;
            this.ItemInventoriesGroupBox.Text = "Inventories";
            // 
            // ItemOpenInvetoryEditorButton
            // 
            this.ItemOpenInvetoryEditorButton.Location = new System.Drawing.Point(285, 74);
            this.ItemOpenInvetoryEditorButton.Name = "ItemOpenInvetoryEditorButton";
            this.ItemOpenInvetoryEditorButton.Size = new System.Drawing.Size(129, 23);
            this.ItemOpenInvetoryEditorButton.TabIndex = 3;
            this.ItemOpenInvetoryEditorButton.Text = "Open Inventory Editor";
            this.ItemOpenInvetoryEditorButton.UseVisualStyleBackColor = true;
            // 
            // ItemInventoryListBox
            // 
            this.ItemInventoryListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ItemInventoryListBox.FormattingEnabled = true;
            this.ItemInventoryListBox.Location = new System.Drawing.Point(6, 15);
            this.ItemInventoryListBox.Name = "ItemInventoryListBox";
            this.ItemInventoryListBox.Size = new System.Drawing.Size(273, 82);
            this.ItemInventoryListBox.TabIndex = 2;
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
            this.ItemTableLayoutPanel.Controls.Add(this.ItemEffectWhenUsedComboBox, 1, 8);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemStackMaxTextBox, 1, 6);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemRarityTextBox, 1, 5);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemTagListBox, 1, 10);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemNameLabel, 0, 0);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemDescriptionLabel, 0, 1);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemCommentLabel, 0, 2);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemSubtypeLabel, 0, 3);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemPriceLabel, 0, 4);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemRarityLabel, 0, 5);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemStackMaxLabel, 0, 6);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemTagsLabel, 0, 10);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemNameTextBox, 1, 0);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemDescriptionTextBox, 1, 1);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemCommentTextBox, 1, 2);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemPriceTextBox, 1, 4);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemSubtypeComboBox, 1, 3);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemEffectWhileHeldLabel, 0, 7);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemEffectWhenUsedLabel, 0, 8);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemParquetLabel, 0, 9);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemEffectWhileHeldComboBox, 1, 7);
            this.ItemTableLayoutPanel.Controls.Add(this.ItemEquivalentParquetComboBox, 1, 9);
            this.ItemTableLayoutPanel.Location = new System.Drawing.Point(307, 16);
            this.ItemTableLayoutPanel.Name = "ItemTableLayoutPanel";
            this.ItemTableLayoutPanel.RowCount = 11;
            this.ItemTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.ItemTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.ItemTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.ItemTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.ItemTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.ItemTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.ItemTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.ItemTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.ItemTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.ItemTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.ItemTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ItemTableLayoutPanel.Size = new System.Drawing.Size(429, 446);
            this.ItemTableLayoutPanel.TabIndex = 5;
            // 
            // ItemEffectWhenUsedComboBox
            // 
            this.ItemEffectWhenUsedComboBox.FormattingEnabled = true;
            this.ItemEffectWhenUsedComboBox.Location = new System.Drawing.Point(131, 263);
            this.ItemEffectWhenUsedComboBox.Name = "ItemEffectWhenUsedComboBox";
            this.ItemEffectWhenUsedComboBox.Size = new System.Drawing.Size(144, 21);
            this.ItemEffectWhenUsedComboBox.TabIndex = 30;
            // 
            // ItemStackMaxTextBox
            // 
            this.ItemStackMaxTextBox.Location = new System.Drawing.Point(131, 213);
            this.ItemStackMaxTextBox.Name = "ItemStackMaxTextBox";
            this.ItemStackMaxTextBox.Size = new System.Drawing.Size(144, 20);
            this.ItemStackMaxTextBox.TabIndex = 28;
            // 
            // ItemRarityTextBox
            // 
            this.ItemRarityTextBox.Location = new System.Drawing.Point(131, 188);
            this.ItemRarityTextBox.Name = "ItemRarityTextBox";
            this.ItemRarityTextBox.Size = new System.Drawing.Size(144, 20);
            this.ItemRarityTextBox.TabIndex = 27;
            // 
            // ItemTagListBox
            // 
            this.ItemTagListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ItemTableLayoutPanel.SetColumnSpan(this.ItemTagListBox, 2);
            this.ItemTagListBox.FormattingEnabled = true;
            this.ItemTagListBox.Location = new System.Drawing.Point(131, 313);
            this.ItemTagListBox.Name = "ItemTagListBox";
            this.ItemTagListBox.Size = new System.Drawing.Size(295, 121);
            this.ItemTagListBox.TabIndex = 1;
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
            // ItemSubtypeLabel
            // 
            this.ItemSubtypeLabel.AutoSize = true;
            this.ItemSubtypeLabel.Location = new System.Drawing.Point(3, 135);
            this.ItemSubtypeLabel.Name = "ItemSubtypeLabel";
            this.ItemSubtypeLabel.Size = new System.Drawing.Size(47, 13);
            this.ItemSubtypeLabel.TabIndex = 9;
            this.ItemSubtypeLabel.Text = "Subtype";
            // 
            // ItemPriceLabel
            // 
            this.ItemPriceLabel.AutoSize = true;
            this.ItemPriceLabel.Location = new System.Drawing.Point(3, 160);
            this.ItemPriceLabel.Name = "ItemPriceLabel";
            this.ItemPriceLabel.Size = new System.Drawing.Size(30, 13);
            this.ItemPriceLabel.TabIndex = 12;
            this.ItemPriceLabel.Text = "Price";
            // 
            // ItemRarityLabel
            // 
            this.ItemRarityLabel.AutoSize = true;
            this.ItemRarityLabel.Location = new System.Drawing.Point(3, 185);
            this.ItemRarityLabel.Name = "ItemRarityLabel";
            this.ItemRarityLabel.Size = new System.Drawing.Size(36, 13);
            this.ItemRarityLabel.TabIndex = 15;
            this.ItemRarityLabel.Text = "Rarity";
            // 
            // ItemStackMaxLabel
            // 
            this.ItemStackMaxLabel.AutoSize = true;
            this.ItemStackMaxLabel.Location = new System.Drawing.Point(3, 210);
            this.ItemStackMaxLabel.Name = "ItemStackMaxLabel";
            this.ItemStackMaxLabel.Size = new System.Drawing.Size(56, 13);
            this.ItemStackMaxLabel.TabIndex = 18;
            this.ItemStackMaxLabel.Text = "Stack Max";
            // 
            // ItemTagsLabel
            // 
            this.ItemTagsLabel.AutoSize = true;
            this.ItemTagsLabel.Location = new System.Drawing.Point(3, 310);
            this.ItemTagsLabel.Name = "ItemTagsLabel";
            this.ItemTagsLabel.Size = new System.Drawing.Size(30, 13);
            this.ItemTagsLabel.TabIndex = 21;
            this.ItemTagsLabel.Text = "Tags";
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
            // ItemPriceTextBox
            // 
            this.ItemPriceTextBox.Location = new System.Drawing.Point(131, 163);
            this.ItemPriceTextBox.Name = "ItemPriceTextBox";
            this.ItemPriceTextBox.Size = new System.Drawing.Size(144, 20);
            this.ItemPriceTextBox.TabIndex = 26;
            // 
            // ItemSubtypeComboBox
            // 
            this.ItemSubtypeComboBox.FormattingEnabled = true;
            this.ItemSubtypeComboBox.Location = new System.Drawing.Point(131, 138);
            this.ItemSubtypeComboBox.Name = "ItemSubtypeComboBox";
            this.ItemSubtypeComboBox.Size = new System.Drawing.Size(144, 21);
            this.ItemSubtypeComboBox.TabIndex = 29;
            // 
            // ItemEffectWhileHeldLabel
            // 
            this.ItemEffectWhileHeldLabel.AutoSize = true;
            this.ItemEffectWhileHeldLabel.Location = new System.Drawing.Point(3, 235);
            this.ItemEffectWhileHeldLabel.Name = "ItemEffectWhileHeldLabel";
            this.ItemEffectWhileHeldLabel.Size = new System.Drawing.Size(89, 13);
            this.ItemEffectWhileHeldLabel.TabIndex = 31;
            this.ItemEffectWhileHeldLabel.Text = "Effect While Held";
            // 
            // ItemEffectWhenUsedLabel
            // 
            this.ItemEffectWhenUsedLabel.AutoSize = true;
            this.ItemEffectWhenUsedLabel.Location = new System.Drawing.Point(3, 260);
            this.ItemEffectWhenUsedLabel.Name = "ItemEffectWhenUsedLabel";
            this.ItemEffectWhenUsedLabel.Size = new System.Drawing.Size(94, 13);
            this.ItemEffectWhenUsedLabel.TabIndex = 32;
            this.ItemEffectWhenUsedLabel.Text = "Effect When Used";
            // 
            // ItemParquetLabel
            // 
            this.ItemParquetLabel.AutoSize = true;
            this.ItemParquetLabel.Location = new System.Drawing.Point(3, 285);
            this.ItemParquetLabel.Name = "ItemParquetLabel";
            this.ItemParquetLabel.Size = new System.Drawing.Size(98, 13);
            this.ItemParquetLabel.TabIndex = 33;
            this.ItemParquetLabel.Text = "Equivalent Parquet";
            // 
            // ItemEffectWhileHeldComboBox
            // 
            this.ItemEffectWhileHeldComboBox.FormattingEnabled = true;
            this.ItemEffectWhileHeldComboBox.Location = new System.Drawing.Point(131, 238);
            this.ItemEffectWhileHeldComboBox.Name = "ItemEffectWhileHeldComboBox";
            this.ItemEffectWhileHeldComboBox.Size = new System.Drawing.Size(144, 21);
            this.ItemEffectWhileHeldComboBox.TabIndex = 34;
            // 
            // ItemEquivalentParquetComboBox
            // 
            this.ItemEquivalentParquetComboBox.FormattingEnabled = true;
            this.ItemEquivalentParquetComboBox.Location = new System.Drawing.Point(131, 288);
            this.ItemEquivalentParquetComboBox.Name = "ItemEquivalentParquetComboBox";
            this.ItemEquivalentParquetComboBox.Size = new System.Drawing.Size(144, 21);
            this.ItemEquivalentParquetComboBox.TabIndex = 35;
            // 
            // ItemPictureBox
            // 
            this.ItemPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemPictureBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ItemPictureBox.Location = new System.Drawing.Point(759, 280);
            this.ItemPictureBox.Name = "ItemPictureBox";
            this.ItemPictureBox.Size = new System.Drawing.Size(182, 182);
            this.ItemPictureBox.TabIndex = 6;
            this.ItemPictureBox.TabStop = false;
            // 
            // ItemIDLabel
            // 
            this.ItemIDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemIDLabel.AutoSize = true;
            this.ItemIDLabel.Location = new System.Drawing.Point(759, 19);
            this.ItemIDLabel.Name = "ItemIDLabel";
            this.ItemIDLabel.Size = new System.Drawing.Size(43, 13);
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
            this.ItemIDTextBox.Location = new System.Drawing.Point(813, 16);
            this.ItemIDTextBox.Name = "ItemIDTextBox";
            this.ItemIDTextBox.Size = new System.Drawing.Size(131, 20);
            this.ItemIDTextBox.TabIndex = 3;
            this.ItemIDTextBox.Text = "-2020202020";
            // 
            // MapsTabPage
            // 
            this.MapsTabPage.BackColor = System.Drawing.Color.Transparent;
            this.MapsTabPage.Controls.Add(this.MapsComingSoonLabel);
            this.MapsTabPage.Location = new System.Drawing.Point(4, 22);
            this.MapsTabPage.Name = "MapsTabPage";
            this.MapsTabPage.Size = new System.Drawing.Size(953, 599);
            this.MapsTabPage.TabIndex = 5;
            this.MapsTabPage.Text = "Maps";
            // 
            // MapsComingSoonLabel
            // 
            this.MapsComingSoonLabel.AutoSize = true;
            this.MapsComingSoonLabel.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MapsComingSoonLabel.Location = new System.Drawing.Point(420, 278);
            this.MapsComingSoonLabel.Name = "MapsComingSoonLabel";
            this.MapsComingSoonLabel.Size = new System.Drawing.Size(136, 25);
            this.MapsComingSoonLabel.TabIndex = 0;
            this.MapsComingSoonLabel.Text = "Coming Soon";
            // 
            // FloorsTabPage
            // 
            this.FloorsTabPage.BackColor = System.Drawing.Color.Transparent;
            this.FloorsTabPage.Controls.Add(this.FloorLayoutTabelPanel);
            this.FloorsTabPage.Controls.Add(this.FloorConfigGroupBox);
            this.FloorsTabPage.Controls.Add(this.FloorIDTextBox);
            this.FloorsTabPage.Controls.Add(this.ParquetsAddNewButton);
            this.FloorsTabPage.Controls.Add(this.FloorListBox);
            this.FloorsTabPage.Controls.Add(this.FloorIDLabel);
            this.FloorsTabPage.Controls.Add(this.FloorEditImageButton);
            this.FloorsTabPage.Controls.Add(this.FloorPictureBox);
            this.FloorsTabPage.Location = new System.Drawing.Point(4, 22);
            this.FloorsTabPage.Name = "FloorsTabPage";
            this.FloorsTabPage.Size = new System.Drawing.Size(953, 599);
            this.FloorsTabPage.TabIndex = 6;
            this.FloorsTabPage.Text = "Floors";
            // 
            // FloorLayoutTabelPanel
            // 
            this.FloorLayoutTabelPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.FloorLayoutTabelPanel.ColumnCount = 3;
            this.FloorLayoutTabelPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.FloorLayoutTabelPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.FloorLayoutTabelPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.FloorLayoutTabelPanel.Controls.Add(this.FloorNameLabel, 0, 0);
            this.FloorLayoutTabelPanel.Controls.Add(this.FloorDescriptionLabel, 0, 1);
            this.FloorLayoutTabelPanel.Controls.Add(this.FloorCommentLabel, 0, 2);
            this.FloorLayoutTabelPanel.Controls.Add(this.ParquetEquivalentItemIDLabel, 0, 3);
            this.FloorLayoutTabelPanel.Controls.Add(this.ParquetNameTextBox, 1, 0);
            this.FloorLayoutTabelPanel.Controls.Add(this.FloorDescriptionTextBox, 1, 1);
            this.FloorLayoutTabelPanel.Controls.Add(this.FloorCommentTextBox, 1, 2);
            this.FloorLayoutTabelPanel.Controls.Add(this.FloorlItemIDComboBox, 1, 3);
            this.FloorLayoutTabelPanel.Controls.Add(this.FloorModificationToolLabel, 0, 8);
            this.FloorLayoutTabelPanel.Controls.Add(this.FloorModificationToolComboBox, 1, 8);
            this.FloorLayoutTabelPanel.Controls.Add(this.FloorTrenchName, 0, 9);
            this.FloorLayoutTabelPanel.Controls.Add(this.FloorTrenchNameTextBox, 1, 9);
            this.FloorLayoutTabelPanel.Controls.Add(this.label1, 0, 4);
            this.FloorLayoutTabelPanel.Controls.Add(this.label2, 0, 6);
            this.FloorLayoutTabelPanel.Controls.Add(this.listBox1, 1, 4);
            this.FloorLayoutTabelPanel.Location = new System.Drawing.Point(307, 16);
            this.FloorLayoutTabelPanel.Name = "FloorLayoutTabelPanel";
            this.FloorLayoutTabelPanel.RowCount = 11;
            this.FloorLayoutTabelPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.FloorLayoutTabelPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.FloorLayoutTabelPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.FloorLayoutTabelPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.FloorLayoutTabelPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.FloorLayoutTabelPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.FloorLayoutTabelPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.FloorLayoutTabelPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.FloorLayoutTabelPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.FloorLayoutTabelPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.FloorLayoutTabelPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FloorLayoutTabelPanel.Size = new System.Drawing.Size(429, 446);
            this.FloorLayoutTabelPanel.TabIndex = 5;
            // 
            // FloorDescriptionTextBox
            // 
            this.FloorDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FloorLayoutTabelPanel.SetColumnSpan(this.FloorDescriptionTextBox, 2);
            this.FloorDescriptionTextBox.Location = new System.Drawing.Point(131, 28);
            this.FloorDescriptionTextBox.Multiline = true;
            this.FloorDescriptionTextBox.Name = "FloorDescriptionTextBox";
            this.FloorDescriptionTextBox.Size = new System.Drawing.Size(295, 49);
            this.FloorDescriptionTextBox.TabIndex = 24;
            // 
            // FloorCommentTextBox
            // 
            this.FloorCommentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FloorLayoutTabelPanel.SetColumnSpan(this.FloorCommentTextBox, 2);
            this.FloorCommentTextBox.Location = new System.Drawing.Point(131, 83);
            this.FloorCommentTextBox.Multiline = true;
            this.FloorCommentTextBox.Name = "FloorCommentTextBox";
            this.FloorCommentTextBox.Size = new System.Drawing.Size(295, 49);
            this.FloorCommentTextBox.TabIndex = 25;
            // 
            // FloorNameLabel
            // 
            this.FloorNameLabel.AutoSize = true;
            this.FloorNameLabel.Location = new System.Drawing.Point(3, 0);
            this.FloorNameLabel.Name = "FloorNameLabel";
            this.FloorNameLabel.Size = new System.Drawing.Size(34, 13);
            this.FloorNameLabel.TabIndex = 0;
            this.FloorNameLabel.Text = "Name";
            // 
            // FloorDescriptionLabel
            // 
            this.FloorDescriptionLabel.AutoSize = true;
            this.FloorDescriptionLabel.Location = new System.Drawing.Point(3, 25);
            this.FloorDescriptionLabel.Name = "FloorDescriptionLabel";
            this.FloorDescriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.FloorDescriptionLabel.TabIndex = 3;
            this.FloorDescriptionLabel.Text = "Description";
            // 
            // FloorCommentLabel
            // 
            this.FloorCommentLabel.AutoSize = true;
            this.FloorCommentLabel.Location = new System.Drawing.Point(3, 80);
            this.FloorCommentLabel.Name = "FloorCommentLabel";
            this.FloorCommentLabel.Size = new System.Drawing.Size(52, 13);
            this.FloorCommentLabel.TabIndex = 6;
            this.FloorCommentLabel.Text = "Comment";
            // 
            // ParquetEquivalentItemIDLabel
            // 
            this.ParquetEquivalentItemIDLabel.AutoSize = true;
            this.ParquetEquivalentItemIDLabel.Location = new System.Drawing.Point(3, 135);
            this.ParquetEquivalentItemIDLabel.Name = "ParquetEquivalentItemIDLabel";
            this.ParquetEquivalentItemIDLabel.Size = new System.Drawing.Size(82, 13);
            this.ParquetEquivalentItemIDLabel.TabIndex = 9;
            this.ParquetEquivalentItemIDLabel.Text = "Equivalent Item";
            // 
            // ParquetNameTextBox
            // 
            this.ParquetNameTextBox.Location = new System.Drawing.Point(131, 3);
            this.ParquetNameTextBox.Name = "ParquetNameTextBox";
            this.ParquetNameTextBox.Size = new System.Drawing.Size(144, 20);
            this.ParquetNameTextBox.TabIndex = 23;
            // 
            // FloorlItemIDComboBox
            // 
            this.FloorlItemIDComboBox.FormattingEnabled = true;
            this.FloorlItemIDComboBox.Location = new System.Drawing.Point(131, 138);
            this.FloorlItemIDComboBox.Name = "FloorlItemIDComboBox";
            this.FloorlItemIDComboBox.Size = new System.Drawing.Size(144, 21);
            this.FloorlItemIDComboBox.TabIndex = 29;
            // 
            // FloorModificationToolLabel
            // 
            this.FloorModificationToolLabel.AutoSize = true;
            this.FloorModificationToolLabel.Location = new System.Drawing.Point(3, 370);
            this.FloorModificationToolLabel.Name = "FloorModificationToolLabel";
            this.FloorModificationToolLabel.Size = new System.Drawing.Size(87, 13);
            this.FloorModificationToolLabel.TabIndex = 12;
            this.FloorModificationToolLabel.Text = "Modification Tool";
            // 
            // FloorModificationToolComboBox
            // 
            this.FloorModificationToolComboBox.FormattingEnabled = true;
            this.FloorModificationToolComboBox.Location = new System.Drawing.Point(131, 373);
            this.FloorModificationToolComboBox.Name = "FloorModificationToolComboBox";
            this.FloorModificationToolComboBox.Size = new System.Drawing.Size(144, 21);
            this.FloorModificationToolComboBox.TabIndex = 34;
            // 
            // FloorTrenchName
            // 
            this.FloorTrenchName.AutoSize = true;
            this.FloorTrenchName.Location = new System.Drawing.Point(3, 395);
            this.FloorTrenchName.Name = "FloorTrenchName";
            this.FloorTrenchName.Size = new System.Drawing.Size(70, 13);
            this.FloorTrenchName.TabIndex = 0;
            this.FloorTrenchName.Text = "Trench Name";
            // 
            // FloorTrenchNameTextBox
            // 
            this.FloorTrenchNameTextBox.Location = new System.Drawing.Point(131, 398);
            this.FloorTrenchNameTextBox.Name = "FloorTrenchNameTextBox";
            this.FloorTrenchNameTextBox.Size = new System.Drawing.Size(144, 20);
            this.FloorTrenchNameTextBox.TabIndex = 23;
            // 
            // FloorConfigGroupBox
            // 
            this.FloorConfigGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FloorConfigGroupBox.Location = new System.Drawing.Point(9, 497);
            this.FloorConfigGroupBox.Name = "FloorConfigGroupBox";
            this.FloorConfigGroupBox.Size = new System.Drawing.Size(938, 96);
            this.FloorConfigGroupBox.TabIndex = 0;
            this.FloorConfigGroupBox.TabStop = false;
            // 
            // FloorIDTextBox
            // 
            this.FloorIDTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FloorIDTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.FloorIDTextBox.Location = new System.Drawing.Point(812, 16);
            this.FloorIDTextBox.Name = "FloorIDTextBox";
            this.FloorIDTextBox.Size = new System.Drawing.Size(131, 20);
            this.FloorIDTextBox.TabIndex = 3;
            this.FloorIDTextBox.Text = "-2020202020";
            // 
            // ParquetsAddNewButton
            // 
            this.ParquetsAddNewButton.Location = new System.Drawing.Point(159, 468);
            this.ParquetsAddNewButton.Name = "ParquetsAddNewButton";
            this.ParquetsAddNewButton.Size = new System.Drawing.Size(129, 23);
            this.ParquetsAddNewButton.TabIndex = 2;
            this.ParquetsAddNewButton.Text = "Add New Item";
            this.ParquetsAddNewButton.UseVisualStyleBackColor = true;
            // 
            // FloorListBox
            // 
            this.FloorListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.FloorListBox.FormattingEnabled = true;
            this.FloorListBox.Location = new System.Drawing.Point(9, 16);
            this.FloorListBox.Name = "FloorListBox";
            this.FloorListBox.Size = new System.Drawing.Size(279, 446);
            this.FloorListBox.TabIndex = 1;
            // 
            // FloorIDLabel
            // 
            this.FloorIDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FloorIDLabel.AutoSize = true;
            this.FloorIDLabel.Location = new System.Drawing.Point(761, 19);
            this.FloorIDLabel.Name = "FloorIDLabel";
            this.FloorIDLabel.Size = new System.Drawing.Size(45, 13);
            this.FloorIDLabel.TabIndex = 4;
            this.FloorIDLabel.Text = "Floor ID";
            // 
            // FloorEditImageButton
            // 
            this.FloorEditImageButton.Location = new System.Drawing.Point(815, 468);
            this.FloorEditImageButton.Name = "FloorEditImageButton";
            this.FloorEditImageButton.Size = new System.Drawing.Size(128, 23);
            this.FloorEditImageButton.TabIndex = 7;
            this.FloorEditImageButton.Text = "Edit Image";
            this.FloorEditImageButton.UseVisualStyleBackColor = true;
            // 
            // FloorPictureBox
            // 
            this.FloorPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FloorPictureBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.FloorPictureBox.Location = new System.Drawing.Point(761, 280);
            this.FloorPictureBox.Name = "FloorPictureBox";
            this.FloorPictureBox.Size = new System.Drawing.Size(182, 182);
            this.FloorPictureBox.TabIndex = 6;
            this.FloorPictureBox.TabStop = false;
            // 
            // RoomsTabPage
            // 
            this.RoomsTabPage.BackColor = System.Drawing.Color.Transparent;
            this.RoomsTabPage.Controls.Add(this.RoomAddBlockButton);
            this.RoomsTabPage.Controls.Add(this.RoomRemoveBlockButton);
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
            this.RoomsTabPage.Size = new System.Drawing.Size(953, 599);
            this.RoomsTabPage.TabIndex = 7;
            this.RoomsTabPage.Text = "Rooms";
            // 
            // RoomAddBlockButton
            // 
            this.RoomAddBlockButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RoomAddBlockButton.Location = new System.Drawing.Point(605, 468);
            this.RoomAddBlockButton.Name = "RoomAddBlockButton";
            this.RoomAddBlockButton.Size = new System.Drawing.Size(129, 23);
            this.RoomAddBlockButton.TabIndex = 2;
            this.RoomAddBlockButton.Text = "Add Block Tag";
            this.RoomAddBlockButton.UseVisualStyleBackColor = true;
            // 
            // RoomRemoveBlockButton
            // 
            this.RoomRemoveBlockButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RoomRemoveBlockButton.Location = new System.Drawing.Point(454, 468);
            this.RoomRemoveBlockButton.Name = "RoomRemoveBlockButton";
            this.RoomRemoveBlockButton.Size = new System.Drawing.Size(129, 23);
            this.RoomRemoveBlockButton.TabIndex = 2;
            this.RoomRemoveBlockButton.Text = "Remove Block Tag";
            this.RoomRemoveBlockButton.UseVisualStyleBackColor = true;
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
            this.RoomConfigGroupBox.Size = new System.Drawing.Size(938, 97);
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
            this.RoomConfigTableLayoutPanel.Size = new System.Drawing.Size(926, 72);
            this.RoomConfigTableLayoutPanel.TabIndex = 1;
            // 
            // RoomMinWalkableSpacesLabel
            // 
            this.RoomMinWalkableSpacesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RoomMinWalkableSpacesLabel.AutoSize = true;
            this.RoomMinWalkableSpacesLabel.Location = new System.Drawing.Point(24, 0);
            this.RoomMinWalkableSpacesLabel.Name = "RoomMinWalkableSpacesLabel";
            this.RoomMinWalkableSpacesLabel.Size = new System.Drawing.Size(130, 23);
            this.RoomMinWalkableSpacesLabel.TabIndex = 0;
            this.RoomMinWalkableSpacesLabel.Text = "Minimum Walkable Spaces";
            // 
            // RoomMaxWalkableSpacesLabel
            // 
            this.RoomMaxWalkableSpacesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RoomMaxWalkableSpacesLabel.AutoSize = true;
            this.RoomMaxWalkableSpacesLabel.Location = new System.Drawing.Point(20, 23);
            this.RoomMaxWalkableSpacesLabel.Name = "RoomMaxWalkableSpacesLabel";
            this.RoomMaxWalkableSpacesLabel.Size = new System.Drawing.Size(134, 23);
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
            this.RoomMaxWalkableSpacesTextBox.Location = new System.Drawing.Point(160, 26);
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
            this.RoomTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.RoomTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.RoomTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.RoomTableLayoutPanel.Controls.Add(this.RoomAddFurnishingsButton, 2, 5);
            this.RoomTableLayoutPanel.Controls.Add(this.RoomRemoveFurnishingsButton, 1, 5);
            this.RoomTableLayoutPanel.Controls.Add(this.RoomAddFloorButton, 2, 7);
            this.RoomTableLayoutPanel.Controls.Add(this.RoomRemoveFloorButton, 1, 7);
            this.RoomTableLayoutPanel.Controls.Add(this.RoomRequiredBlocksListBox, 1, 8);
            this.RoomTableLayoutPanel.Controls.Add(this.RoomRequiredFloorsListBox, 1, 6);
            this.RoomTableLayoutPanel.Controls.Add(this.RoomNameLabel, 0, 0);
            this.RoomTableLayoutPanel.Controls.Add(this.RoomDescriptionLabel, 0, 1);
            this.RoomTableLayoutPanel.Controls.Add(this.RoomCommentLabel, 0, 2);
            this.RoomTableLayoutPanel.Controls.Add(this.RoomTierLabel, 0, 3);
            this.RoomTableLayoutPanel.Controls.Add(this.RoomRequiredFloorsLabel, 0, 6);
            this.RoomTableLayoutPanel.Controls.Add(this.RoomRequiredBlocksLabel, 0, 8);
            this.RoomTableLayoutPanel.Controls.Add(this.RoomNameTextBox, 1, 0);
            this.RoomTableLayoutPanel.Controls.Add(this.RoomDescriptionTextBox, 1, 1);
            this.RoomTableLayoutPanel.Controls.Add(this.RoomCommentTextBox, 1, 2);
            this.RoomTableLayoutPanel.Controls.Add(this.RoomTierTextBox, 1, 3);
            this.RoomTableLayoutPanel.Controls.Add(this.RoomRequiredFurnishingsLabel, 0, 4);
            this.RoomTableLayoutPanel.Controls.Add(this.RoomRequiredFurnishingsListBox, 1, 4);
            this.RoomTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.RoomTableLayoutPanel.Location = new System.Drawing.Point(307, 16);
            this.RoomTableLayoutPanel.Name = "RoomTableLayoutPanel";
            this.RoomTableLayoutPanel.RowCount = 9;
            this.RoomTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.RoomTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.RoomTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.RoomTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.RoomTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.RoomTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.RoomTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.RoomTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.RoomTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.RoomTableLayoutPanel.Size = new System.Drawing.Size(429, 446);
            this.RoomTableLayoutPanel.TabIndex = 5;
            // 
            // RoomAddFurnishingsButton
            // 
            this.RoomAddFurnishingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RoomAddFurnishingsButton.Location = new System.Drawing.Point(297, 238);
            this.RoomAddFurnishingsButton.Name = "RoomAddFurnishingsButton";
            this.RoomAddFurnishingsButton.Size = new System.Drawing.Size(129, 23);
            this.RoomAddFurnishingsButton.TabIndex = 30;
            this.RoomAddFurnishingsButton.Text = "Add Furnishing Tag";
            this.RoomAddFurnishingsButton.UseVisualStyleBackColor = true;
            // 
            // RoomRemoveFurnishingsButton
            // 
            this.RoomRemoveFurnishingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RoomRemoveFurnishingsButton.Location = new System.Drawing.Point(154, 238);
            this.RoomRemoveFurnishingsButton.Name = "RoomRemoveFurnishingsButton";
            this.RoomRemoveFurnishingsButton.Size = new System.Drawing.Size(129, 23);
            this.RoomRemoveFurnishingsButton.TabIndex = 29;
            this.RoomRemoveFurnishingsButton.Text = "Remove Furnishing Tag";
            this.RoomRemoveFurnishingsButton.UseVisualStyleBackColor = true;
            // 
            // RoomAddFloorButton
            // 
            this.RoomAddFloorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RoomAddFloorButton.Location = new System.Drawing.Point(297, 343);
            this.RoomAddFloorButton.Name = "RoomAddFloorButton";
            this.RoomAddFloorButton.Size = new System.Drawing.Size(129, 23);
            this.RoomAddFloorButton.TabIndex = 2;
            this.RoomAddFloorButton.Text = "Add Floor Tag";
            this.RoomAddFloorButton.UseVisualStyleBackColor = true;
            // 
            // RoomRemoveFloorButton
            // 
            this.RoomRemoveFloorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RoomRemoveFloorButton.Location = new System.Drawing.Point(154, 343);
            this.RoomRemoveFloorButton.Name = "RoomRemoveFloorButton";
            this.RoomRemoveFloorButton.Size = new System.Drawing.Size(129, 23);
            this.RoomRemoveFloorButton.TabIndex = 2;
            this.RoomRemoveFloorButton.Text = "Remove Floor Tag";
            this.RoomRemoveFloorButton.UseVisualStyleBackColor = true;
            // 
            // RoomRequiredBlocksListBox
            // 
            this.RoomRequiredBlocksListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.RoomTableLayoutPanel.SetColumnSpan(this.RoomRequiredBlocksListBox, 2);
            this.RoomRequiredBlocksListBox.FormattingEnabled = true;
            this.RoomRequiredBlocksListBox.Location = new System.Drawing.Point(146, 373);
            this.RoomRequiredBlocksListBox.Name = "RoomRequiredBlocksListBox";
            this.RoomRequiredBlocksListBox.Size = new System.Drawing.Size(279, 69);
            this.RoomRequiredBlocksListBox.TabIndex = 1;
            // 
            // RoomRequiredFloorsListBox
            // 
            this.RoomRequiredFloorsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.RoomTableLayoutPanel.SetColumnSpan(this.RoomRequiredFloorsListBox, 2);
            this.RoomRequiredFloorsListBox.FormattingEnabled = true;
            this.RoomRequiredFloorsListBox.Location = new System.Drawing.Point(146, 268);
            this.RoomRequiredFloorsListBox.Name = "RoomRequiredFloorsListBox";
            this.RoomRequiredFloorsListBox.Size = new System.Drawing.Size(279, 69);
            this.RoomRequiredFloorsListBox.TabIndex = 1;
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
            this.RoomTierLabel.Size = new System.Drawing.Size(125, 13);
            this.RoomTierLabel.TabIndex = 9;
            this.RoomTierLabel.Text = "Minimum Walkable Floors";
            // 
            // RoomRequiredFloorsLabel
            // 
            this.RoomRequiredFloorsLabel.AutoSize = true;
            this.RoomRequiredFloorsLabel.Location = new System.Drawing.Point(3, 265);
            this.RoomRequiredFloorsLabel.Name = "RoomRequiredFloorsLabel";
            this.RoomRequiredFloorsLabel.Size = new System.Drawing.Size(103, 13);
            this.RoomRequiredFloorsLabel.TabIndex = 18;
            this.RoomRequiredFloorsLabel.Text = "Required Floor Tags";
            // 
            // RoomRequiredBlocksLabel
            // 
            this.RoomRequiredBlocksLabel.AutoSize = true;
            this.RoomRequiredBlocksLabel.Location = new System.Drawing.Point(3, 370);
            this.RoomRequiredBlocksLabel.Name = "RoomRequiredBlocksLabel";
            this.RoomRequiredBlocksLabel.Size = new System.Drawing.Size(103, 13);
            this.RoomRequiredBlocksLabel.TabIndex = 21;
            this.RoomRequiredBlocksLabel.Text = "Required Block Tags";
            // 
            // RoomNameTextBox
            // 
            this.RoomNameTextBox.Location = new System.Drawing.Point(146, 3);
            this.RoomNameTextBox.Name = "RoomNameTextBox";
            this.RoomNameTextBox.Size = new System.Drawing.Size(136, 20);
            this.RoomNameTextBox.TabIndex = 23;
            // 
            // RoomDescriptionTextBox
            // 
            this.RoomDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RoomTableLayoutPanel.SetColumnSpan(this.RoomDescriptionTextBox, 2);
            this.RoomDescriptionTextBox.Location = new System.Drawing.Point(146, 28);
            this.RoomDescriptionTextBox.Multiline = true;
            this.RoomDescriptionTextBox.Name = "RoomDescriptionTextBox";
            this.RoomDescriptionTextBox.Size = new System.Drawing.Size(280, 49);
            this.RoomDescriptionTextBox.TabIndex = 24;
            // 
            // RoomCommentTextBox
            // 
            this.RoomCommentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RoomTableLayoutPanel.SetColumnSpan(this.RoomCommentTextBox, 2);
            this.RoomCommentTextBox.Location = new System.Drawing.Point(146, 83);
            this.RoomCommentTextBox.Multiline = true;
            this.RoomCommentTextBox.Name = "RoomCommentTextBox";
            this.RoomCommentTextBox.Size = new System.Drawing.Size(280, 49);
            this.RoomCommentTextBox.TabIndex = 25;
            // 
            // RoomTierTextBox
            // 
            this.RoomTierTextBox.Location = new System.Drawing.Point(146, 138);
            this.RoomTierTextBox.Name = "RoomTierTextBox";
            this.RoomTierTextBox.Size = new System.Drawing.Size(136, 20);
            this.RoomTierTextBox.TabIndex = 26;
            // 
            // RoomRequiredFurnishingsLabel
            // 
            this.RoomRequiredFurnishingsLabel.AutoSize = true;
            this.RoomRequiredFurnishingsLabel.Location = new System.Drawing.Point(3, 160);
            this.RoomRequiredFurnishingsLabel.Name = "RoomRequiredFurnishingsLabel";
            this.RoomRequiredFurnishingsLabel.Size = new System.Drawing.Size(128, 13);
            this.RoomRequiredFurnishingsLabel.TabIndex = 27;
            this.RoomRequiredFurnishingsLabel.Text = "Required Furnishing Tags";
            // 
            // RoomRequiredFurnishingsListBox
            // 
            this.RoomRequiredFurnishingsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.RoomTableLayoutPanel.SetColumnSpan(this.RoomRequiredFurnishingsListBox, 2);
            this.RoomRequiredFurnishingsListBox.Location = new System.Drawing.Point(146, 163);
            this.RoomRequiredFurnishingsListBox.Name = "RoomRequiredFurnishingsListBox";
            this.RoomRequiredFurnishingsListBox.Size = new System.Drawing.Size(279, 69);
            this.RoomRequiredFurnishingsListBox.TabIndex = 28;
            // 
            // RoomPictureBox
            // 
            this.RoomPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RoomPictureBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.RoomPictureBox.Location = new System.Drawing.Point(759, 280);
            this.RoomPictureBox.Name = "RoomPictureBox";
            this.RoomPictureBox.Size = new System.Drawing.Size(182, 182);
            this.RoomPictureBox.TabIndex = 6;
            this.RoomPictureBox.TabStop = false;
            // 
            // RoomIDLabel
            // 
            this.RoomIDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RoomIDLabel.AutoSize = true;
            this.RoomIDLabel.Location = new System.Drawing.Point(759, 19);
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
            this.RoomIDTextBox.Location = new System.Drawing.Point(813, 16);
            this.RoomIDTextBox.Name = "RoomIDTextBox";
            this.RoomIDTextBox.Size = new System.Drawing.Size(131, 20);
            this.RoomIDTextBox.TabIndex = 3;
            this.RoomIDTextBox.Text = "-2020202020";
            // 
            // ScriptsTabPage
            // 
            this.ScriptsTabPage.BackColor = System.Drawing.Color.Transparent;
            this.ScriptsTabPage.Controls.Add(this.ScriptingComingSoonLabel);
            this.ScriptsTabPage.Location = new System.Drawing.Point(4, 22);
            this.ScriptsTabPage.Name = "ScriptsTabPage";
            this.ScriptsTabPage.Size = new System.Drawing.Size(953, 599);
            this.ScriptsTabPage.TabIndex = 8;
            this.ScriptsTabPage.Text = "Scripting";
            // 
            // ScriptingComingSoonLabel
            // 
            this.ScriptingComingSoonLabel.AutoSize = true;
            this.ScriptingComingSoonLabel.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ScriptingComingSoonLabel.Location = new System.Drawing.Point(420, 278);
            this.ScriptingComingSoonLabel.Name = "ScriptingComingSoonLabel";
            this.ScriptingComingSoonLabel.Size = new System.Drawing.Size(136, 25);
            this.ScriptingComingSoonLabel.TabIndex = 0;
            this.ScriptingComingSoonLabel.Text = "Coming Soon";
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
            this.FiltersTableLayoutPanel.Controls.Add(this.FilterByNameCheckBox, 1, 0);
            this.FiltersTableLayoutPanel.Controls.Add(this.FilterByStoryIDCheckBox, 1, 1);
            this.FiltersTableLayoutPanel.Controls.Add(this.FilterByDescriptionCheckBox, 2, 0);
            this.FiltersTableLayoutPanel.Controls.Add(this.FilterByTagsCheckBox, 2, 1);
            this.FiltersTableLayoutPanel.Controls.Add(this.FilterByCommentCheckBox, 3, 0);
            this.FiltersTableLayoutPanel.Controls.Add(this.FilterByMoreCheckBox, 3, 1);
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
            // FilterByNameCheckBox
            // 
            this.FilterByNameCheckBox.AutoSize = true;
            this.FilterByNameCheckBox.Location = new System.Drawing.Point(153, 3);
            this.FilterByNameCheckBox.Name = "FilterByNameCheckBox";
            this.FilterByNameCheckBox.Size = new System.Drawing.Size(53, 17);
            this.FilterByNameCheckBox.TabIndex = 3;
            this.FilterByNameCheckBox.Text = "Name";
            this.FilterByNameCheckBox.UseVisualStyleBackColor = true;
            // 
            // FilterByStoryIDCheckBox
            // 
            this.FilterByStoryIDCheckBox.AutoSize = true;
            this.FilterByStoryIDCheckBox.Location = new System.Drawing.Point(153, 28);
            this.FilterByStoryIDCheckBox.Name = "FilterByStoryIDCheckBox";
            this.FilterByStoryIDCheckBox.Size = new System.Drawing.Size(66, 17);
            this.FilterByStoryIDCheckBox.TabIndex = 6;
            this.FilterByStoryIDCheckBox.Text = "Story ID";
            this.FilterByStoryIDCheckBox.UseVisualStyleBackColor = true;
            // 
            // FilterByDescriptionCheckBox
            // 
            this.FilterByDescriptionCheckBox.AutoSize = true;
            this.FilterByDescriptionCheckBox.Location = new System.Drawing.Point(253, 3);
            this.FilterByDescriptionCheckBox.Name = "FilterByDescriptionCheckBox";
            this.FilterByDescriptionCheckBox.Size = new System.Drawing.Size(79, 17);
            this.FilterByDescriptionCheckBox.TabIndex = 4;
            this.FilterByDescriptionCheckBox.Text = "Description";
            this.FilterByDescriptionCheckBox.UseVisualStyleBackColor = true;
            // 
            // FilterByTagsCheckBox
            // 
            this.FilterByTagsCheckBox.AutoSize = true;
            this.FilterByTagsCheckBox.Location = new System.Drawing.Point(253, 28);
            this.FilterByTagsCheckBox.Name = "FilterByTagsCheckBox";
            this.FilterByTagsCheckBox.Size = new System.Drawing.Size(49, 17);
            this.FilterByTagsCheckBox.TabIndex = 7;
            this.FilterByTagsCheckBox.Text = "Tags";
            this.FilterByTagsCheckBox.UseVisualStyleBackColor = true;
            // 
            // FilterByCommentCheckBox
            // 
            this.FilterByCommentCheckBox.AutoSize = true;
            this.FilterByCommentCheckBox.Location = new System.Drawing.Point(353, 3);
            this.FilterByCommentCheckBox.Name = "FilterByCommentCheckBox";
            this.FilterByCommentCheckBox.Size = new System.Drawing.Size(71, 17);
            this.FilterByCommentCheckBox.TabIndex = 5;
            this.FilterByCommentCheckBox.Text = "Comment";
            this.FilterByCommentCheckBox.UseVisualStyleBackColor = true;
            // 
            // FilterByMoreCheckBox
            // 
            this.FilterByMoreCheckBox.AutoSize = true;
            this.FilterByMoreCheckBox.Location = new System.Drawing.Point(353, 28);
            this.FilterByMoreCheckBox.Name = "FilterByMoreCheckBox";
            this.FilterByMoreCheckBox.Size = new System.Drawing.Size(50, 17);
            this.FilterByMoreCheckBox.TabIndex = 8;
            this.FilterByMoreCheckBox.Text = "More";
            this.FilterByMoreCheckBox.UseVisualStyleBackColor = true;
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
            this.FlavorTableLayoutPanel.Controls.Add(this.FlavorSavourySelector, 0, 1);
            this.FlavorTableLayoutPanel.Controls.Add(this.FlavorMetallicSelector, 0, 1);
            this.FlavorTableLayoutPanel.Controls.Add(this.FlavorFreshSelector, 0, 1);
            this.FlavorTableLayoutPanel.Controls.Add(this.FlavorPungentSelector, 0, 1);
            this.FlavorTableLayoutPanel.Controls.Add(this.FlavorNoFlavorsSelector, 0, 1);
            this.FlavorTableLayoutPanel.Controls.Add(this.FlavorChemicalSelector, 0, 1);
            this.FlavorTableLayoutPanel.Controls.Add(this.FlavorAstringentSelector, 0, 1);
            this.FlavorTableLayoutPanel.Controls.Add(this.FlavorSweetSelector, 1, 0);
            this.FlavorTableLayoutPanel.Controls.Add(this.FlavorBlandSelector, 0, 0);
            this.FlavorTableLayoutPanel.Controls.Add(this.FlavorBitterSelector, 4, 0);
            this.FlavorTableLayoutPanel.Controls.Add(this.FlavorSourSelector, 3, 0);
            this.FlavorTableLayoutPanel.Controls.Add(this.FlavorSaltySelector, 2, 0);
            this.FlavorTableLayoutPanel.Controls.Add(this.FlavorNumbingSelector, 5, 0);
            this.FlavorTableLayoutPanel.Controls.Add(this.FlavorAllFlavorsSelector, 6, 0);
            this.FlavorTableLayoutPanel.Location = new System.Drawing.Point(6, 19);
            this.FlavorTableLayoutPanel.Name = "FlavorTableLayoutPanel";
            this.FlavorTableLayoutPanel.RowCount = 2;
            this.FlavorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.FlavorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.FlavorTableLayoutPanel.Size = new System.Drawing.Size(479, 52);
            this.FlavorTableLayoutPanel.TabIndex = 0;
            // 
            // FlavorSavourySelector
            // 
            this.FlavorSavourySelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FlavorSavourySelector.AutoSize = true;
            this.FlavorSavourySelector.BackColor = System.Drawing.Color.PapayaWhip;
            this.FlavorSavourySelector.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FlavorSavourySelector.Location = new System.Drawing.Point(3, 26);
            this.FlavorSavourySelector.Name = "FlavorSavourySelector";
            this.FlavorSavourySelector.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.FlavorSavourySelector.Size = new System.Drawing.Size(62, 26);
            this.FlavorSavourySelector.TabIndex = 0;
            this.FlavorSavourySelector.Text = "Savoury";
            // 
            // FlavorMetallicSelector
            // 
            this.FlavorMetallicSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FlavorMetallicSelector.AutoSize = true;
            this.FlavorMetallicSelector.BackColor = System.Drawing.Color.Gainsboro;
            this.FlavorMetallicSelector.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FlavorMetallicSelector.Location = new System.Drawing.Point(207, 26);
            this.FlavorMetallicSelector.Name = "FlavorMetallicSelector";
            this.FlavorMetallicSelector.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.FlavorMetallicSelector.Size = new System.Drawing.Size(62, 26);
            this.FlavorMetallicSelector.TabIndex = 0;
            this.FlavorMetallicSelector.Text = "Metallic";
            // 
            // FlavorFreshSelector
            // 
            this.FlavorFreshSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FlavorFreshSelector.AutoSize = true;
            this.FlavorFreshSelector.BackColor = System.Drawing.Color.LightCyan;
            this.FlavorFreshSelector.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FlavorFreshSelector.Location = new System.Drawing.Point(139, 26);
            this.FlavorFreshSelector.Name = "FlavorFreshSelector";
            this.FlavorFreshSelector.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.FlavorFreshSelector.Size = new System.Drawing.Size(62, 26);
            this.FlavorFreshSelector.TabIndex = 0;
            this.FlavorFreshSelector.Text = "Fresh";
            // 
            // FlavorPungentSelector
            // 
            this.FlavorPungentSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FlavorPungentSelector.AutoSize = true;
            this.FlavorPungentSelector.BackColor = System.Drawing.Color.Pink;
            this.FlavorPungentSelector.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FlavorPungentSelector.Location = new System.Drawing.Point(71, 26);
            this.FlavorPungentSelector.Name = "FlavorPungentSelector";
            this.FlavorPungentSelector.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.FlavorPungentSelector.Size = new System.Drawing.Size(62, 26);
            this.FlavorPungentSelector.TabIndex = 0;
            this.FlavorPungentSelector.Text = "Pungent";
            // 
            // FlavorNoFlavorsSelector
            // 
            this.FlavorNoFlavorsSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FlavorNoFlavorsSelector.AutoSize = true;
            this.FlavorNoFlavorsSelector.BackColor = System.Drawing.SystemColors.ControlDark;
            this.FlavorNoFlavorsSelector.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FlavorNoFlavorsSelector.Location = new System.Drawing.Point(413, 26);
            this.FlavorNoFlavorsSelector.Name = "FlavorNoFlavorsSelector";
            this.FlavorNoFlavorsSelector.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.FlavorNoFlavorsSelector.Size = new System.Drawing.Size(63, 26);
            this.FlavorNoFlavorsSelector.TabIndex = 0;
            this.FlavorNoFlavorsSelector.Text = "(None)";
            // 
            // FlavorChemicalSelector
            // 
            this.FlavorChemicalSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FlavorChemicalSelector.AutoSize = true;
            this.FlavorChemicalSelector.BackColor = System.Drawing.Color.LightSteelBlue;
            this.FlavorChemicalSelector.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FlavorChemicalSelector.Location = new System.Drawing.Point(345, 26);
            this.FlavorChemicalSelector.Name = "FlavorChemicalSelector";
            this.FlavorChemicalSelector.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.FlavorChemicalSelector.Size = new System.Drawing.Size(62, 26);
            this.FlavorChemicalSelector.TabIndex = 0;
            this.FlavorChemicalSelector.Text = "Chemical";
            // 
            // FlavorAstringentSelector
            // 
            this.FlavorAstringentSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FlavorAstringentSelector.AutoSize = true;
            this.FlavorAstringentSelector.BackColor = System.Drawing.Color.Moccasin;
            this.FlavorAstringentSelector.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FlavorAstringentSelector.Location = new System.Drawing.Point(275, 26);
            this.FlavorAstringentSelector.Name = "FlavorAstringentSelector";
            this.FlavorAstringentSelector.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.FlavorAstringentSelector.Size = new System.Drawing.Size(64, 26);
            this.FlavorAstringentSelector.TabIndex = 0;
            this.FlavorAstringentSelector.Text = "Astringent";
            // 
            // FlavorSweetSelector
            // 
            this.FlavorSweetSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FlavorSweetSelector.AutoSize = true;
            this.FlavorSweetSelector.BackColor = System.Drawing.Color.MistyRose;
            this.FlavorSweetSelector.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FlavorSweetSelector.Location = new System.Drawing.Point(71, 0);
            this.FlavorSweetSelector.Name = "FlavorSweetSelector";
            this.FlavorSweetSelector.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.FlavorSweetSelector.Size = new System.Drawing.Size(62, 26);
            this.FlavorSweetSelector.TabIndex = 0;
            this.FlavorSweetSelector.Text = "Sweet";
            // 
            // FlavorBlandSelector
            // 
            this.FlavorBlandSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FlavorBlandSelector.AutoSize = true;
            this.FlavorBlandSelector.BackColor = System.Drawing.Color.NavajoWhite;
            this.FlavorBlandSelector.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FlavorBlandSelector.Location = new System.Drawing.Point(3, 0);
            this.FlavorBlandSelector.Name = "FlavorBlandSelector";
            this.FlavorBlandSelector.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.FlavorBlandSelector.Size = new System.Drawing.Size(62, 26);
            this.FlavorBlandSelector.TabIndex = 0;
            this.FlavorBlandSelector.Text = "Bland";
            // 
            // FlavorBitterSelector
            // 
            this.FlavorBitterSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FlavorBitterSelector.AutoSize = true;
            this.FlavorBitterSelector.BackColor = System.Drawing.Color.LightGreen;
            this.FlavorBitterSelector.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FlavorBitterSelector.Location = new System.Drawing.Point(275, 0);
            this.FlavorBitterSelector.Name = "FlavorBitterSelector";
            this.FlavorBitterSelector.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.FlavorBitterSelector.Size = new System.Drawing.Size(64, 26);
            this.FlavorBitterSelector.TabIndex = 0;
            this.FlavorBitterSelector.Text = "Bitter";
            // 
            // FlavorSourSelector
            // 
            this.FlavorSourSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FlavorSourSelector.AutoSize = true;
            this.FlavorSourSelector.BackColor = System.Drawing.Color.LemonChiffon;
            this.FlavorSourSelector.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FlavorSourSelector.Location = new System.Drawing.Point(207, 0);
            this.FlavorSourSelector.Name = "FlavorSourSelector";
            this.FlavorSourSelector.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.FlavorSourSelector.Size = new System.Drawing.Size(62, 26);
            this.FlavorSourSelector.TabIndex = 0;
            this.FlavorSourSelector.Text = "Sour";
            // 
            // FlavorSaltySelector
            // 
            this.FlavorSaltySelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FlavorSaltySelector.AutoSize = true;
            this.FlavorSaltySelector.BackColor = System.Drawing.Color.PowderBlue;
            this.FlavorSaltySelector.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FlavorSaltySelector.Location = new System.Drawing.Point(139, 0);
            this.FlavorSaltySelector.Name = "FlavorSaltySelector";
            this.FlavorSaltySelector.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.FlavorSaltySelector.Size = new System.Drawing.Size(62, 26);
            this.FlavorSaltySelector.TabIndex = 0;
            this.FlavorSaltySelector.Text = "Salty";
            // 
            // FlavorNumbingSelector
            // 
            this.FlavorNumbingSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FlavorNumbingSelector.AutoSize = true;
            this.FlavorNumbingSelector.BackColor = System.Drawing.Color.Plum;
            this.FlavorNumbingSelector.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FlavorNumbingSelector.Location = new System.Drawing.Point(345, 0);
            this.FlavorNumbingSelector.Name = "FlavorNumbingSelector";
            this.FlavorNumbingSelector.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.FlavorNumbingSelector.Size = new System.Drawing.Size(62, 26);
            this.FlavorNumbingSelector.TabIndex = 0;
            this.FlavorNumbingSelector.Text = "Numbing";
            // 
            // FlavorAllFlavorsSelector
            // 
            this.FlavorAllFlavorsSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FlavorAllFlavorsSelector.AutoSize = true;
            this.FlavorAllFlavorsSelector.BackColor = System.Drawing.SystemColors.ControlLight;
            this.FlavorAllFlavorsSelector.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FlavorAllFlavorsSelector.Location = new System.Drawing.Point(413, 0);
            this.FlavorAllFlavorsSelector.Name = "FlavorAllFlavorsSelector";
            this.FlavorAllFlavorsSelector.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.FlavorAllFlavorsSelector.Size = new System.Drawing.Size(63, 26);
            this.FlavorAllFlavorsSelector.TabIndex = 0;
            this.FlavorAllFlavorsSelector.Text = "(All)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "label2";
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FloorLayoutTabelPanel.SetColumnSpan(this.listBox1, 2);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(131, 163);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(295, 69);
            this.listBox1.TabIndex = 37;
            // 
            // MainEditorForm
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
            this.Name = "MainEditorForm";
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
            this.CraftingTabPage.ResumeLayout(false);
            this.CraftingTabPage.PerformLayout();
            this.CraftingTableLayoutPanel.ResumeLayout(false);
            this.CraftingTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CraftingPictureBox)).EndInit();
            this.CraftsConfigGroupBox.ResumeLayout(false);
            this.CraftingConfigTableLayoutPanel.ResumeLayout(false);
            this.CraftingConfigTableLayoutPanel.PerformLayout();
            this.ItemsTabPage.ResumeLayout(false);
            this.ItemsTabPage.PerformLayout();
            this.ItemInventoriesGroupBox.ResumeLayout(false);
            this.ItemTableLayoutPanel.ResumeLayout(false);
            this.ItemTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemPictureBox)).EndInit();
            this.MapsTabPage.ResumeLayout(false);
            this.MapsTabPage.PerformLayout();
            this.FloorsTabPage.ResumeLayout(false);
            this.FloorsTabPage.PerformLayout();
            this.FloorLayoutTabelPanel.ResumeLayout(false);
            this.FloorLayoutTabelPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FloorPictureBox)).EndInit();
            this.RoomsTabPage.ResumeLayout(false);
            this.RoomsTabPage.PerformLayout();
            this.RoomConfigGroupBox.ResumeLayout(false);
            this.RoomConfigTableLayoutPanel.ResumeLayout(false);
            this.RoomConfigTableLayoutPanel.PerformLayout();
            this.RoomTableLayoutPanel.ResumeLayout(false);
            this.RoomTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoomPictureBox)).EndInit();
            this.ScriptsTabPage.ResumeLayout(false);
            this.ScriptsTabPage.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem ReloadToolStripMenuItem;
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
        private System.Windows.Forms.ListBox CraftingListBox;
        private System.Windows.Forms.TableLayoutPanel CraftingConfigTableLayoutPanel;
        private System.Windows.Forms.GroupBox CraftsConfigGroupBox;
        private System.Windows.Forms.Button CraftingPictureEditButton;
        private System.Windows.Forms.TableLayoutPanel CraftingTableLayoutPanel;
        private System.Windows.Forms.Label CraftingNameLabel;
        private System.Windows.Forms.Label CraftingDescriptionLabel;
        private System.Windows.Forms.Label CraftingCommentLabel;
        private System.Windows.Forms.Label CraftingIngredientsLabel;
        private System.Windows.Forms.TextBox CraftingNameTextBox;
        private System.Windows.Forms.TextBox CraftingDescriptionTextBox;
        private System.Windows.Forms.TextBox CraftingCommentTextBox;
        private System.Windows.Forms.PictureBox CraftingPictureBox;
        private System.Windows.Forms.Label CraftingIDLabel;
        private System.Windows.Forms.Button CraftingAddNewCraftingButton;
        private System.Windows.Forms.TextBox CraftingIDTextBox;
        private System.Windows.Forms.Button CraftingOpenPatternEditorButton;
        private System.Windows.Forms.Button CraftingAddIngredientButton;
        private System.Windows.Forms.Button CraftingRemoveIngredientButton;
        private System.Windows.Forms.ListBox CraftingIngredientsBox;
        private System.Windows.Forms.Button CraftingAddProductButton;
        private System.Windows.Forms.Button CraftingRemoveProductButton;
        private System.Windows.Forms.Label CraftingProductsLabel;
        private System.Windows.Forms.Label CraftingMinIngredientCountLabel;
        private System.Windows.Forms.Label CraftingMinProductCountLabel;
        private System.Windows.Forms.Label CraftingMaxIngredientCountLabel;
        private System.Windows.Forms.Label CraftingMaxProductCountLabel;
        private System.Windows.Forms.TextBox CraftingMinIngredientCountTextBox;
        private System.Windows.Forms.TextBox CraftingMinProductCountTextBox;
        private System.Windows.Forms.TextBox CraftingMaxIngredientCountTextBox;
        private System.Windows.Forms.TextBox CraftingMaxProductCountTextBox;
        private System.Windows.Forms.TabPage ItemsTabPage;
        private System.Windows.Forms.TabPage MapsTabPage;
        private System.Windows.Forms.TabPage FloorsTabPage;
        private System.Windows.Forms.TabPage RoomsTabPage;
        private System.Windows.Forms.TabPage ScriptsTabPage;
        private System.Windows.Forms.TableLayoutPanel FiltersTableLayoutPanel;
        private System.Windows.Forms.TextBox FilterTextBox;
        private System.Windows.Forms.CheckBox FilterByNameCheckBox;
        private System.Windows.Forms.CheckBox FilterByDescriptionCheckBox;
        private System.Windows.Forms.CheckBox FilterByCommentCheckBox;
        private System.Windows.Forms.CheckBox FilterByStoryIDCheckBox;
        private System.Windows.Forms.CheckBox FilterByTagsCheckBox;
        private System.Windows.Forms.CheckBox FilterByMoreCheckBox;
        private System.Windows.Forms.GroupBox FilterGroupBox;
        private System.Windows.Forms.GroupBox FlavorFilterGroupBox;
        private System.Windows.Forms.TableLayoutPanel FlavorTableLayoutPanel;
        private System.Windows.Forms.Label FlavorSweetSelector;
        private System.Windows.Forms.Label FlavorBlandSelector;
        private System.Windows.Forms.Label FlavorSavourySelector;
        private System.Windows.Forms.Label FlavorMetallicSelector;
        private System.Windows.Forms.Label FlavorFreshSelector;
        private System.Windows.Forms.Label FlavorPungentSelector;
        private System.Windows.Forms.Label FlavorNoFlavorsSelector;
        private System.Windows.Forms.Label FlavorChemicalSelector;
        private System.Windows.Forms.Label FlavorAstringentSelector;
        private System.Windows.Forms.Label FlavorBitterSelector;
        private System.Windows.Forms.Label FlavorSourSelector;
        private System.Windows.Forms.Label FlavorSaltySelector;
        private System.Windows.Forms.Label FlavorNumbingSelector;
        private System.Windows.Forms.Label FlavorAllFlavorsSelector;
        private System.Windows.Forms.ToolStripStatusLabel MainToolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar ToolStripProgressBar;
        private System.Windows.Forms.GroupBox LibraryInfoGroupBox;
        private System.Windows.Forms.GroupBox FileFormatGroupBox;
        private System.Windows.Forms.TableLayoutPanel LibraryInfoTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel FileFormatTableLayoutPanel;
        private System.Windows.Forms.Label LibraryVersionLabel;
        private System.Windows.Forms.Label LibraryVersionExample;
        private System.Windows.Forms.Label LibraryWorkingDirectoryLabel;
        private System.Windows.Forms.Label LibraryWorkingDirectoryExample;
        private System.Windows.Forms.Label FileFormatPrimaryDelimiterLabel;
        private System.Windows.Forms.Label FileFormatPrimaryDelimiterExample;
        private System.Windows.Forms.Label FileFormatSecondaryDelimiterLabel;
        private System.Windows.Forms.Label FileFormatSecondaryDelimiterExample;
        private System.Windows.Forms.Label FileFormatInternalDelimiterLabel;
        private System.Windows.Forms.Label FileFormatInternalDelimiterExample;
        private System.Windows.Forms.Label FileFormatElementDelimiterLabel;
        private System.Windows.Forms.Label FileFormatElementDelimiterExample;
        private System.Windows.Forms.Label FileFormatNameDelimiterLabel;
        private System.Windows.Forms.Label FileFormatNameDelimiterExample;
        private System.Windows.Forms.Label FileFormatPronounDelimiterLabel;
        private System.Windows.Forms.Label FileFormatPronounDelimiterExample;
        private System.Windows.Forms.Label FileFormatDimensionalDelimiterLabel;
        private System.Windows.Forms.Label FileFormatDimensionalDelimiterExample;
        private System.Windows.Forms.Label FileFormatDimensionalTerminatorLabel;
        private System.Windows.Forms.Label FileFormatDimensionalTerminatorExample;
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
        private System.Windows.Forms.Button BiomeRemoveEntryRequirementButton;
        private System.Windows.Forms.Button BiomeAddParquetCriterionButton;
        private System.Windows.Forms.Button BiomeRemoveParquetCriterionButton;
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
        private System.Windows.Forms.Label RoomRequiredFloorsLabel;
        private System.Windows.Forms.Label RoomRequiredBlocksLabel;
        private System.Windows.Forms.TextBox RoomNameTextBox;
        private System.Windows.Forms.TextBox RoomDescriptionTextBox;
        private System.Windows.Forms.TextBox RoomCommentTextBox;
        private System.Windows.Forms.TextBox RoomTierTextBox;
        private System.Windows.Forms.PictureBox RoomPictureBox;
        private System.Windows.Forms.Label RoomIDLabel;
        private System.Windows.Forms.Button RoomAddNewRoomButton;
        private System.Windows.Forms.TextBox RoomIDTextBox;
        private System.Windows.Forms.Button RoomAddBlockButton;
        private System.Windows.Forms.Button RoomRemoveBlockButton;
        private System.Windows.Forms.Button RoomAddFloorButton;
        private System.Windows.Forms.Button RoomRemoveFloorButton;
        private System.Windows.Forms.ListBox RoomRequiredBlocksListBox;
        private System.Windows.Forms.ListBox RoomRequiredFloorsListBox;
        private System.Windows.Forms.TableLayoutPanel RoomConfigTableLayoutPanel;
        private System.Windows.Forms.Label RoomMinWalkableSpacesLabel;
        private System.Windows.Forms.Label RoomMaxWalkableSpacesLabel;
        private System.Windows.Forms.TextBox RoomMinWalkableSpacesTextBox;
        private System.Windows.Forms.TextBox RoomMaxWalkableSpacesTextBox;
        private System.Windows.Forms.ListBox ItemListBox;
        private System.Windows.Forms.GroupBox ItemInventoriesGroupBox;
        private System.Windows.Forms.Button ItemPictureEditButton;
        private System.Windows.Forms.TableLayoutPanel ItemTableLayoutPanel;
        private System.Windows.Forms.Label ItemNameLabel;
        private System.Windows.Forms.Label ItemDescriptionLabel;
        private System.Windows.Forms.Label ItemCommentLabel;
        private System.Windows.Forms.Label ItemSubtypeLabel;
        private System.Windows.Forms.Label ItemPriceLabel;
        private System.Windows.Forms.Label ItemRarityLabel;
        private System.Windows.Forms.Label ItemStackMaxLabel;
        private System.Windows.Forms.Label ItemTagsLabel;
        private System.Windows.Forms.TextBox ItemNameTextBox;
        private System.Windows.Forms.TextBox ItemDescriptionTextBox;
        private System.Windows.Forms.TextBox ItemCommentTextBox;
        private System.Windows.Forms.TextBox ItemPriceTextBox;
        private System.Windows.Forms.PictureBox ItemPictureBox;
        private System.Windows.Forms.Label ItemIDLabel;
        private System.Windows.Forms.Button ItemAddNewItemButton;
        private System.Windows.Forms.TextBox ItemIDTextBox;
        private System.Windows.Forms.Button ItemAddTagButton;
        private System.Windows.Forms.Button ItemRemoveTagButton;
        private System.Windows.Forms.ListBox ItemTagListBox;
        private System.Windows.Forms.Button RoomAddFurnishingsButton;
        private System.Windows.Forms.Button RoomRemoveFurnishingsButton;
        private System.Windows.Forms.Label RoomRequiredFurnishingsLabel;
        private System.Windows.Forms.ListBox RoomRequiredFurnishingsListBox;
        private System.Windows.Forms.Button ItemOpenInvetoryEditorButton;
        private System.Windows.Forms.ListBox ItemInventoryListBox;
        private System.Windows.Forms.TextBox ItemStackMaxTextBox;
        private System.Windows.Forms.TextBox ItemRarityTextBox;
        private System.Windows.Forms.ComboBox ItemEffectWhenUsedComboBox;
        private System.Windows.Forms.ComboBox ItemSubtypeComboBox;
        private System.Windows.Forms.Label ItemEffectWhileHeldLabel;
        private System.Windows.Forms.Label ItemEffectWhenUsedLabel;
        private System.Windows.Forms.Label ItemParquetLabel;
        private System.Windows.Forms.ComboBox ItemEffectWhileHeldComboBox;
        private System.Windows.Forms.ComboBox ItemEquivalentParquetComboBox;
        private System.Windows.Forms.ToolTip EditorToolTip;
        private System.Windows.Forms.ListBox CraftingProductsListBox;
        private System.Windows.Forms.Label ScriptingComingSoonLabel;
        private System.Windows.Forms.Label MapsComingSoonLabel;
        private System.Windows.Forms.Label CraftingStrikePatternDimensionLabelLabel;
        private System.Windows.Forms.Label CraftingStrikePatternDimensionLabelExample;
        private System.Windows.Forms.Label CraftingStrikePatternLabel;
        private System.Windows.Forms.Label CraftingStrikePatternComingSoonLabel;
        private System.Windows.Forms.ListBox ParquetListBox;
        private System.Windows.Forms.Button FloorEditImageButton;
        private System.Windows.Forms.TableLayoutPanel FloorLayoutTabelPanel;
        private System.Windows.Forms.Label FloorNameLabel;
        private System.Windows.Forms.Label FloorDescriptionLabel;
        private System.Windows.Forms.Label FloorCommentLabel;
        private System.Windows.Forms.Label ParquetEquivalentItemIDLabel;
        private System.Windows.Forms.Label FloorModificationToolLabel;
        private System.Windows.Forms.TextBox ParquetNameTextBox;
        private System.Windows.Forms.TextBox FloorDescriptionTextBox;
        private System.Windows.Forms.TextBox FloorCommentTextBox;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.PictureBox FloorPictureBox;
        private System.Windows.Forms.Label FloorIDLabel;
        private System.Windows.Forms.Button ParquetsAddNewButton;
        private System.Windows.Forms.TextBox FloorIDTextBox;
        private System.Windows.Forms.GroupBox Config;
        private System.Windows.Forms.GroupBox FloorConfigGroupBox;
        private System.Windows.Forms.Label FloorTrenchName;
        private System.Windows.Forms.TextBox FloorTrenchNameTextBox;
        private System.Windows.Forms.ListBox FloorListBox;
        private System.Windows.Forms.ComboBox FloorlItemIDComboBox;
        private System.Windows.Forms.ComboBox FloorModificationToolComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
    }
}

