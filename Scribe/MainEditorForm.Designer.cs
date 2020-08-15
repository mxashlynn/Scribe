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
            this.MainToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.EditorStatusStrip = new System.Windows.Forms.StatusStrip();
            this.EditorToolTip = new System.Windows.Forms.ToolTip(this.components);
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
            this.ContextMenuStripEditorForm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemOpenContainingFolder = new System.Windows.Forms.ToolStripMenuItem();
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
            this.FlavorsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
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
            this.EditorTabs = new System.Windows.Forms.TabControl();
            this.GamesTabPage = new System.Windows.Forms.TabPage();
            this.GameRemoveGameButton = new System.Windows.Forms.Button();
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
            this.GameAddNewGameButton = new System.Windows.Forms.Button();
            this.GameListBox = new System.Windows.Forms.ListBox();
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
            this.LibraryProjectPathLabel = new System.Windows.Forms.Label();
            this.LibraryProjectPathExample = new System.Windows.Forms.Label();
            this.BlocksTabPage = new System.Windows.Forms.TabPage();
            this.BlockTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.BlockGatherToolComboBox = new System.Windows.Forms.ComboBox();
            this.BlockDroppedCollectibleIDComboBox = new System.Windows.Forms.ComboBox();
            this.BlockGatherEffectComboBox = new System.Windows.Forms.ComboBox();
            this.BlockMaxToughnessTextBox = new System.Windows.Forms.TextBox();
            this.BlockNameLabel = new System.Windows.Forms.Label();
            this.BlockDescriptionLabel = new System.Windows.Forms.Label();
            this.BlockCommentLabel = new System.Windows.Forms.Label();
            this.BlockEquivalentItemLabel = new System.Windows.Forms.Label();
            this.BlockNameTextBox = new System.Windows.Forms.TextBox();
            this.BlockDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.BlockCommentTextBox = new System.Windows.Forms.TextBox();
            this.BlockEquivalentItemComboBox = new System.Windows.Forms.ComboBox();
            this.BlockGatheringToolLabel = new System.Windows.Forms.Label();
            this.BlockGatheringEffectLabel = new System.Windows.Forms.Label();
            this.BlockDroppedCollectibleLabel = new System.Windows.Forms.Label();
            this.BlockIsFlammableLabel = new System.Windows.Forms.Label();
            this.BlockIsLiquidLabel = new System.Windows.Forms.Label();
            this.BlockMaxToughnessLabel = new System.Windows.Forms.Label();
            this.BlockIsFlammableCheckBox = new System.Windows.Forms.CheckBox();
            this.BlockIsLiquidCheckBox = new System.Windows.Forms.CheckBox();
            this.BlockPictureBox = new System.Windows.Forms.PictureBox();
            this.BlockEditImageButton = new System.Windows.Forms.Button();
            this.BlockIDLabel = new System.Windows.Forms.Label();
            this.BlockListBox = new System.Windows.Forms.ListBox();
            this.BlockAddNewBlockButton = new System.Windows.Forms.Button();
            this.BlockIDTextBox = new System.Windows.Forms.TextBox();
            this.BlockConfigGroupBox = new System.Windows.Forms.GroupBox();
            this.BlockRemoveBlockButton = new System.Windows.Forms.Button();
            this.FloorsTabPage = new System.Windows.Forms.TabPage();
            this.FloorRemoveFloorButton = new System.Windows.Forms.Button();
            this.FloorLayoutTabelPanel = new System.Windows.Forms.TableLayoutPanel();
            this.FloorRemoveRoomTagButton = new System.Windows.Forms.Button();
            this.FloorRemoveBiomeTagButton = new System.Windows.Forms.Button();
            this.FloorAddRoomTagButton = new System.Windows.Forms.Button();
            this.FloorNameLabel = new System.Windows.Forms.Label();
            this.FloorDescriptionLabel = new System.Windows.Forms.Label();
            this.FloorCommentLabel = new System.Windows.Forms.Label();
            this.FloorEquivalentItemIDLabel = new System.Windows.Forms.Label();
            this.FloorNameTextBox = new System.Windows.Forms.TextBox();
            this.FloorDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.FloorCommentTextBox = new System.Windows.Forms.TextBox();
            this.FloorlItemIDComboBox = new System.Windows.Forms.ComboBox();
            this.FloorModificationToolLabel = new System.Windows.Forms.Label();
            this.FloorModificationToolComboBox = new System.Windows.Forms.ComboBox();
            this.FloorTrenchName = new System.Windows.Forms.Label();
            this.FloorTrenchNameTextBox = new System.Windows.Forms.TextBox();
            this.FloorAddsToBiomeLabel = new System.Windows.Forms.Label();
            this.FloorAddsToRoomLabel = new System.Windows.Forms.Label();
            this.FloorAddsToBiomeListBox = new System.Windows.Forms.ListBox();
            this.FloorAddsToRoomListBox = new System.Windows.Forms.ListBox();
            this.FloorAddBiomeTagButton = new System.Windows.Forms.Button();
            this.FloorConfigGroupBox = new System.Windows.Forms.GroupBox();
            this.FloorIDTextBox = new System.Windows.Forms.TextBox();
            this.FloorAddNewFloorButton = new System.Windows.Forms.Button();
            this.FloorListBox = new System.Windows.Forms.ListBox();
            this.FloorIDLabel = new System.Windows.Forms.Label();
            this.FloorEditImageButton = new System.Windows.Forms.Button();
            this.FloorPictureBox = new System.Windows.Forms.PictureBox();
            this.FurnishingsTabPage = new System.Windows.Forms.TabPage();
            this.FurnishingTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.FurnishingSwapWithFurnishingComboBox = new System.Windows.Forms.ComboBox();
            this.FurnishingEntryTypeComboBox = new System.Windows.Forms.ComboBox();
            this.FurnishingNameLabel = new System.Windows.Forms.Label();
            this.FurnishingDescriptionLabel = new System.Windows.Forms.Label();
            this.FurnishingCommentLabel = new System.Windows.Forms.Label();
            this.FurnishingEquivalentItemLabel = new System.Windows.Forms.Label();
            this.FurnishingNameTextBox = new System.Windows.Forms.TextBox();
            this.FurnishingDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.FurnishingCommentTextBox = new System.Windows.Forms.TextBox();
            this.FurnishingEquivalentItemComboBox = new System.Windows.Forms.ComboBox();
            this.FurnishingEntryTypeLabel = new System.Windows.Forms.Label();
            this.FurnishingIsWalkableLabel = new System.Windows.Forms.Label();
            this.FurnishingIsEnclosingLabel = new System.Windows.Forms.Label();
            this.FurnishingIsFlammableLabel = new System.Windows.Forms.Label();
            this.FurnishingSwapWithFurnishingLabel = new System.Windows.Forms.Label();
            this.FurnishingIsWalkableCheckBox = new System.Windows.Forms.CheckBox();
            this.FurnishingIsEnclosingCheckBox = new System.Windows.Forms.CheckBox();
            this.FurnishingIsFlammableCheckBox = new System.Windows.Forms.CheckBox();
            this.FurnishingRemoveFurnishingButton = new System.Windows.Forms.Button();
            this.FurnishingConfigGroupBox = new System.Windows.Forms.GroupBox();
            this.FurnishingIDTextBox = new System.Windows.Forms.TextBox();
            this.FurnishingAddNewFurnishingButton = new System.Windows.Forms.Button();
            this.FurnishingListBox = new System.Windows.Forms.ListBox();
            this.FurnishingIDLabel = new System.Windows.Forms.Label();
            this.FurnishingEditImageButton = new System.Windows.Forms.Button();
            this.FurnishingPictureBox = new System.Windows.Forms.PictureBox();
            this.CollectiblesTabPage = new System.Windows.Forms.TabPage();
            this.CollectibleTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CollectibleEffectAmountTextBox = new System.Windows.Forms.TextBox();
            this.CollectibleCollectionEffectComboBox = new System.Windows.Forms.ComboBox();
            this.CollectibleNameLabel = new System.Windows.Forms.Label();
            this.CollectibleDescriptionLabel = new System.Windows.Forms.Label();
            this.CollectibleCommentLabel = new System.Windows.Forms.Label();
            this.CollectibleEquivalentItemLabel = new System.Windows.Forms.Label();
            this.CollectibleNameTextBox = new System.Windows.Forms.TextBox();
            this.CollectibleDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.CollectibleCommentTextBox = new System.Windows.Forms.TextBox();
            this.CollectibleEquivalentItemComboBox = new System.Windows.Forms.ComboBox();
            this.CollectibleCollectionEffectLabel = new System.Windows.Forms.Label();
            this.CollectibleEffectAmountLabel = new System.Windows.Forms.Label();
            this.CollectibleRemoveCollectibleButton = new System.Windows.Forms.Button();
            this.CollectibleConfigGroupBox = new System.Windows.Forms.GroupBox();
            this.CollectibleIDTextBox = new System.Windows.Forms.TextBox();
            this.CollectibleAddNewCollectibleButton = new System.Windows.Forms.Button();
            this.CollectibleListBox = new System.Windows.Forms.ListBox();
            this.CollectibleIDLabel = new System.Windows.Forms.Label();
            this.CollectibleEditImageButton = new System.Windows.Forms.Button();
            this.CollectiblePictureBox = new System.Windows.Forms.PictureBox();
            this.CharactersTabPage = new System.Windows.Forms.TabPage();
            this.CharacterPronounGroupBox = new System.Windows.Forms.GroupBox();
            this.CharacterPronounTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CharacterPronounAddNewPronoungGroupButton = new System.Windows.Forms.Button();
            this.CharacterPronounRemovePronoungGroupButton = new System.Windows.Forms.Button();
            this.CharacterPronounReflexiveTextBox = new System.Windows.Forms.TextBox();
            this.CharacterPronounPossessiveTextBox = new System.Windows.Forms.TextBox();
            this.CharacterPronounDeterminerTextBox = new System.Windows.Forms.TextBox();
            this.CharacterPronounObjectiveTextBox = new System.Windows.Forms.TextBox();
            this.CharacterPronounSubjectiveTextBox = new System.Windows.Forms.TextBox();
            this.CharacterPronounListBox = new System.Windows.Forms.ListBox();
            this.CharacterPronounSubjectiveLabel = new System.Windows.Forms.Label();
            this.CharacterPronounObjectiveLabel = new System.Windows.Forms.Label();
            this.CharacterPronounDeterminerLabel = new System.Windows.Forms.Label();
            this.CharacterPronounPossessiveLabel = new System.Windows.Forms.Label();
            this.CharacterPronounReflexiveLabel = new System.Windows.Forms.Label();
            this.CharacterPronounKeyLabel = new System.Windows.Forms.Label();
            this.CharacterPronounKeyExample = new System.Windows.Forms.Label();
            this.CharacterTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CharacterAddQuestButton = new System.Windows.Forms.Button();
            this.CharacterRemoveQuestButton = new System.Windows.Forms.Button();
            this.CharacterStartingQuestsListBox = new System.Windows.Forms.ListBox();
            this.CharacterStoryIDTextBox = new System.Windows.Forms.TextBox();
            this.CharacterOpenInventoryEditorButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.CharacterNameLabel = new System.Windows.Forms.Label();
            this.CharacterDescriptionLabel = new System.Windows.Forms.Label();
            this.CharacterCommentLabel = new System.Windows.Forms.Label();
            this.CharacterNativeBiomeLabel = new System.Windows.Forms.Label();
            this.CharacterNameTextBox = new System.Windows.Forms.TextBox();
            this.CharacterDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.CharacterCommentTextBox = new System.Windows.Forms.TextBox();
            this.CharacterNativeBiomeComboBox = new System.Windows.Forms.ComboBox();
            this.CharacterPrimaryBehaviorLabel = new System.Windows.Forms.Label();
            this.CharacterParquetsAvoidedLabel = new System.Windows.Forms.Label();
            this.CharacterComingSoonLabel1 = new System.Windows.Forms.Label();
            this.CharacterParquetsSoughtLabel = new System.Windows.Forms.Label();
            this.CharacterComingSoonLabel = new System.Windows.Forms.Label();
            this.CharacterPronounLabel = new System.Windows.Forms.Label();
            this.CharacterStoryIDLabel = new System.Windows.Forms.Label();
            this.CharacterStartingQuestsLabel = new System.Windows.Forms.Label();
            this.CharacterStartingDialogueLabel = new System.Windows.Forms.Label();
            this.CharacterStartingInventoryLabel = new System.Windows.Forms.Label();
            this.CharacterPronounComboBox = new System.Windows.Forms.ComboBox();
            this.CharacterStartingDialogueComboBox = new System.Windows.Forms.ComboBox();
            this.StartingInventoryComboBox = new System.Windows.Forms.ComboBox();
            this.CharacterRemoveCharacterButton = new System.Windows.Forms.Button();
            this.CharacterIDTextBox = new System.Windows.Forms.TextBox();
            this.CharacterAddNewCharacterButton = new System.Windows.Forms.Button();
            this.CharacterListBox = new System.Windows.Forms.ListBox();
            this.CharacterIDLabel = new System.Windows.Forms.Label();
            this.CharacterEditImageButton = new System.Windows.Forms.Button();
            this.CharacterPictureBox = new System.Windows.Forms.PictureBox();
            this.CrittersTabPage = new System.Windows.Forms.TabPage();
            this.CritterTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CritterPrimaryBehaviorComboBox = new System.Windows.Forms.ComboBox();
            this.CritterNameLabel = new System.Windows.Forms.Label();
            this.CritterDescriptionLabel = new System.Windows.Forms.Label();
            this.CritterCommentLabel = new System.Windows.Forms.Label();
            this.CritterNativeBiomeLabel = new System.Windows.Forms.Label();
            this.CritterNameTextBox = new System.Windows.Forms.TextBox();
            this.CritterDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.CritterCommentTextBox = new System.Windows.Forms.TextBox();
            this.CritterNativeBiomeComboBox = new System.Windows.Forms.ComboBox();
            this.CritterPrimaryBehaviorLabel = new System.Windows.Forms.Label();
            this.CritterParquetAvoidsLabel = new System.Windows.Forms.Label();
            this.CritterComingSoonLabel1 = new System.Windows.Forms.Label();
            this.CritterParquetsSoughtLabel = new System.Windows.Forms.Label();
            this.CritterComingSoonLabel2 = new System.Windows.Forms.Label();
            this.CritterPictureBox = new System.Windows.Forms.PictureBox();
            this.CritterEditImageButton = new System.Windows.Forms.Button();
            this.CritterIDLabel = new System.Windows.Forms.Label();
            this.CritterListBox = new System.Windows.Forms.ListBox();
            this.CritterAddNewCritterButton = new System.Windows.Forms.Button();
            this.CritterIDTextBox = new System.Windows.Forms.TextBox();
            this.CritterConfigGroupBox = new System.Windows.Forms.GroupBox();
            this.CritterRemoveCritterButton = new System.Windows.Forms.Button();
            this.ItemsTabPage = new System.Windows.Forms.TabPage();
            this.ItemRemoveItemButton = new System.Windows.Forms.Button();
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
            this.BiomesTabPage = new System.Windows.Forms.TabPage();
            this.BiomeRemoveBiomeButton = new System.Windows.Forms.Button();
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
            this.CraftingRecipesTabPage = new System.Windows.Forms.TabPage();
            this.CraftingRemoveCraftingButton = new System.Windows.Forms.Button();
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
            this.CraftingConfigGroupBox = new System.Windows.Forms.GroupBox();
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
            this.RoomRecipesTabPage = new System.Windows.Forms.TabPage();
            this.RoomRemoveRoomButton = new System.Windows.Forms.Button();
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
            this.MapsTabPage = new System.Windows.Forms.TabPage();
            this.MapComingSoonLabel = new System.Windows.Forms.Label();
            this.ScriptsTabPage = new System.Windows.Forms.TabPage();
            this.ScriptingComingSoonLabel = new System.Windows.Forms.Label();
            this.EditorStatusStrip.SuspendLayout();
            this.MainMenuBar.SuspendLayout();
            this.ContextMenuStripEditorForm.SuspendLayout();
            this.FiltersTableLayoutPanel.SuspendLayout();
            this.FilterGroupBox.SuspendLayout();
            this.FlavorFilterGroupBox.SuspendLayout();
            this.FlavorsTableLayoutPanel.SuspendLayout();
            this.EditorTabs.SuspendLayout();
            this.GamesTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GameIconPictureBox)).BeginInit();
            this.GameTableLayoutPanel.SuspendLayout();
            this.FileFormatGroupBox.SuspendLayout();
            this.FileFormatTableLayoutPanel.SuspendLayout();
            this.LibraryInfoGroupBox.SuspendLayout();
            this.LibraryInfoTableLayoutPanel.SuspendLayout();
            this.BlocksTabPage.SuspendLayout();
            this.BlockTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlockPictureBox)).BeginInit();
            this.FloorsTabPage.SuspendLayout();
            this.FloorLayoutTabelPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FloorPictureBox)).BeginInit();
            this.FurnishingsTabPage.SuspendLayout();
            this.FurnishingTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FurnishingPictureBox)).BeginInit();
            this.CollectiblesTabPage.SuspendLayout();
            this.CollectibleTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CollectiblePictureBox)).BeginInit();
            this.CharactersTabPage.SuspendLayout();
            this.CharacterPronounGroupBox.SuspendLayout();
            this.CharacterPronounTableLayoutPanel.SuspendLayout();
            this.CharacterTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CharacterPictureBox)).BeginInit();
            this.CrittersTabPage.SuspendLayout();
            this.CritterTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CritterPictureBox)).BeginInit();
            this.ItemsTabPage.SuspendLayout();
            this.ItemInventoriesGroupBox.SuspendLayout();
            this.ItemTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemPictureBox)).BeginInit();
            this.BiomesTabPage.SuspendLayout();
            this.BiomeConfigGroupBox.SuspendLayout();
            this.BiomeConfigTableLayoutPanel.SuspendLayout();
            this.BiomeTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BiomePictureBox)).BeginInit();
            this.CraftingRecipesTabPage.SuspendLayout();
            this.CraftingTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CraftingPictureBox)).BeginInit();
            this.CraftingConfigGroupBox.SuspendLayout();
            this.CraftingConfigTableLayoutPanel.SuspendLayout();
            this.RoomRecipesTabPage.SuspendLayout();
            this.RoomConfigGroupBox.SuspendLayout();
            this.RoomConfigTableLayoutPanel.SuspendLayout();
            this.RoomTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoomPictureBox)).BeginInit();
            this.MapsTabPage.SuspendLayout();
            this.ScriptsTabPage.SuspendLayout();
            this.SuspendLayout();
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
            // ContextMenuStripEditorForm
            // 
            this.ContextMenuStripEditorForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemOpenContainingFolder});
            this.ContextMenuStripEditorForm.Name = "ContextMenuStripMainMenu";
            this.ContextMenuStripEditorForm.ShowImageMargin = false;
            this.ContextMenuStripEditorForm.Size = new System.Drawing.Size(177, 26);
            // 
            // ToolStripMenuItemOpenContainingFolder
            // 
            this.ToolStripMenuItemOpenContainingFolder.Name = "ToolStripMenuItemOpenContainingFolder";
            this.ToolStripMenuItemOpenContainingFolder.Size = new System.Drawing.Size(176, 22);
            this.ToolStripMenuItemOpenContainingFolder.Text = "Open Containing Folder";
            this.ToolStripMenuItemOpenContainingFolder.Click += new System.EventHandler(this.OpenContainingFolderMenuItem_Click);
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
            this.FlavorFilterGroupBox.Controls.Add(this.FlavorsTableLayoutPanel);
            this.FlavorFilterGroupBox.Location = new System.Drawing.Point(477, 27);
            this.FlavorFilterGroupBox.Name = "FlavorFilterGroupBox";
            this.FlavorFilterGroupBox.Size = new System.Drawing.Size(491, 78);
            this.FlavorFilterGroupBox.TabIndex = 5;
            this.FlavorFilterGroupBox.TabStop = false;
            this.FlavorFilterGroupBox.Text = "Filter By Flavor";
            // 
            // FlavorsTableLayoutPanel
            // 
            this.FlavorsTableLayoutPanel.ColumnCount = 7;
            this.FlavorsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.25F));
            this.FlavorsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.25F));
            this.FlavorsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.25F));
            this.FlavorsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.25F));
            this.FlavorsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.75F));
            this.FlavorsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.25F));
            this.FlavorsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.FlavorsTableLayoutPanel.Controls.Add(this.FlavorSavourySelector, 0, 1);
            this.FlavorsTableLayoutPanel.Controls.Add(this.FlavorMetallicSelector, 0, 1);
            this.FlavorsTableLayoutPanel.Controls.Add(this.FlavorFreshSelector, 0, 1);
            this.FlavorsTableLayoutPanel.Controls.Add(this.FlavorPungentSelector, 0, 1);
            this.FlavorsTableLayoutPanel.Controls.Add(this.FlavorNoFlavorsSelector, 0, 1);
            this.FlavorsTableLayoutPanel.Controls.Add(this.FlavorChemicalSelector, 0, 1);
            this.FlavorsTableLayoutPanel.Controls.Add(this.FlavorAstringentSelector, 0, 1);
            this.FlavorsTableLayoutPanel.Controls.Add(this.FlavorSweetSelector, 1, 0);
            this.FlavorsTableLayoutPanel.Controls.Add(this.FlavorBlandSelector, 0, 0);
            this.FlavorsTableLayoutPanel.Controls.Add(this.FlavorBitterSelector, 4, 0);
            this.FlavorsTableLayoutPanel.Controls.Add(this.FlavorSourSelector, 3, 0);
            this.FlavorsTableLayoutPanel.Controls.Add(this.FlavorSaltySelector, 2, 0);
            this.FlavorsTableLayoutPanel.Controls.Add(this.FlavorNumbingSelector, 5, 0);
            this.FlavorsTableLayoutPanel.Controls.Add(this.FlavorAllFlavorsSelector, 6, 0);
            this.FlavorsTableLayoutPanel.Location = new System.Drawing.Point(6, 19);
            this.FlavorsTableLayoutPanel.Name = "FlavorsTableLayoutPanel";
            this.FlavorsTableLayoutPanel.RowCount = 2;
            this.FlavorsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.FlavorsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.FlavorsTableLayoutPanel.Size = new System.Drawing.Size(479, 52);
            this.FlavorsTableLayoutPanel.TabIndex = 0;
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
            // EditorTabs
            // 
            this.EditorTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EditorTabs.Controls.Add(this.GamesTabPage);
            this.EditorTabs.Controls.Add(this.BlocksTabPage);
            this.EditorTabs.Controls.Add(this.FloorsTabPage);
            this.EditorTabs.Controls.Add(this.FurnishingsTabPage);
            this.EditorTabs.Controls.Add(this.CollectiblesTabPage);
            this.EditorTabs.Controls.Add(this.CharactersTabPage);
            this.EditorTabs.Controls.Add(this.CrittersTabPage);
            this.EditorTabs.Controls.Add(this.ItemsTabPage);
            this.EditorTabs.Controls.Add(this.BiomesTabPage);
            this.EditorTabs.Controls.Add(this.CraftingRecipesTabPage);
            this.EditorTabs.Controls.Add(this.RoomRecipesTabPage);
            this.EditorTabs.Controls.Add(this.MapsTabPage);
            this.EditorTabs.Controls.Add(this.ScriptsTabPage);
            this.EditorTabs.Location = new System.Drawing.Point(12, 111);
            this.EditorTabs.Name = "EditorTabs";
            this.EditorTabs.SelectedIndex = 0;
            this.EditorTabs.Size = new System.Drawing.Size(961, 625);
            this.EditorTabs.TabIndex = 1;
            // 
            // GamesTabPage
            // 
            this.GamesTabPage.Controls.Add(this.GameRemoveGameButton);
            this.GamesTabPage.Controls.Add(this.GameIconEditButton);
            this.GamesTabPage.Controls.Add(this.GameIconPictureBox);
            this.GamesTabPage.Controls.Add(this.GameTableLayoutPanel);
            this.GamesTabPage.Controls.Add(this.GameIDLabel);
            this.GamesTabPage.Controls.Add(this.GameIDTextBox);
            this.GamesTabPage.Controls.Add(this.GameAddNewGameButton);
            this.GamesTabPage.Controls.Add(this.GameListBox);
            this.GamesTabPage.Controls.Add(this.FileFormatGroupBox);
            this.GamesTabPage.Controls.Add(this.LibraryInfoGroupBox);
            this.GamesTabPage.Location = new System.Drawing.Point(4, 22);
            this.GamesTabPage.Name = "GamesTabPage";
            this.GamesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.GamesTabPage.Size = new System.Drawing.Size(953, 599);
            this.GamesTabPage.TabIndex = 0;
            this.GamesTabPage.Text = "Games & Episodes";
            // 
            // GameRemoveGameButton
            // 
            this.GameRemoveGameButton.Location = new System.Drawing.Point(24, 468);
            this.GameRemoveGameButton.Name = "GameRemoveGameButton";
            this.GameRemoveGameButton.Size = new System.Drawing.Size(129, 23);
            this.GameRemoveGameButton.TabIndex = 2;
            this.GameRemoveGameButton.Text = "Remove Game";
            this.GameRemoveGameButton.UseVisualStyleBackColor = true;
            // 
            // GameIconEditButton
            // 
            this.GameIconEditButton.Location = new System.Drawing.Point(815, 468);
            this.GameIconEditButton.Name = "GameIconEditButton";
            this.GameIconEditButton.Size = new System.Drawing.Size(128, 23);
            this.GameIconEditButton.TabIndex = 7;
            this.GameIconEditButton.Text = "Edit Image";
            this.GameIconEditButton.UseVisualStyleBackColor = true;
            this.GameIconEditButton.Click += new System.EventHandler(this.GameIconEditButton_Click);
            // 
            // GameIconPictureBox
            // 
            this.GameIconPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GameIconPictureBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.GameIconPictureBox.ContextMenuStrip = this.ContextMenuStripEditorForm;
            this.GameIconPictureBox.Location = new System.Drawing.Point(767, 286);
            this.GameIconPictureBox.Name = "GameIconPictureBox";
            this.GameIconPictureBox.Size = new System.Drawing.Size(176, 176);
            this.GameIconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
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
            // GameAddNewGameButton
            // 
            this.GameAddNewGameButton.Location = new System.Drawing.Point(159, 468);
            this.GameAddNewGameButton.Name = "GameAddNewGameButton";
            this.GameAddNewGameButton.Size = new System.Drawing.Size(129, 23);
            this.GameAddNewGameButton.TabIndex = 2;
            this.GameAddNewGameButton.Text = "Add New Game";
            this.GameAddNewGameButton.UseVisualStyleBackColor = true;
            // 
            // GameListBox
            // 
            this.GameListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GameListBox.DisplayMember = "Name";
            this.GameListBox.FormattingEnabled = true;
            this.GameListBox.Location = new System.Drawing.Point(9, 16);
            this.GameListBox.Name = "GameListBox";
            this.GameListBox.Size = new System.Drawing.Size(279, 446);
            this.GameListBox.TabIndex = 1;
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
            this.FileFormatPrimaryDelimiterExample.Text = ";";
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
            this.FileFormatSecondaryDelimiterExample.Size = new System.Drawing.Size(11, 13);
            this.FileFormatSecondaryDelimiterExample.TabIndex = 3;
            this.FileFormatSecondaryDelimiterExample.Text = ";";
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
            this.FileFormatInternalDelimiterExample.Text = ";";
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
            this.FileFormatElementDelimiterExample.Size = new System.Drawing.Size(11, 13);
            this.FileFormatElementDelimiterExample.TabIndex = 7;
            this.FileFormatElementDelimiterExample.Text = ";";
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
            this.FileFormatNameDelimiterExample.Size = new System.Drawing.Size(11, 13);
            this.FileFormatNameDelimiterExample.TabIndex = 9;
            this.FileFormatNameDelimiterExample.Text = ";";
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
            this.FileFormatPronounDelimiterExample.Text = ";";
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
            this.FileFormatDimensionalDelimiterExample.Size = new System.Drawing.Size(11, 13);
            this.FileFormatDimensionalDelimiterExample.TabIndex = 13;
            this.FileFormatDimensionalDelimiterExample.Text = ";";
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
            this.FileFormatDimensionalTerminatorExample.Size = new System.Drawing.Size(11, 13);
            this.FileFormatDimensionalTerminatorExample.TabIndex = 15;
            this.FileFormatDimensionalTerminatorExample.Text = ";";
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
            this.LibraryInfoTableLayoutPanel.Controls.Add(this.LibraryProjectPathLabel, 2, 0);
            this.LibraryInfoTableLayoutPanel.Controls.Add(this.LibraryProjectPathExample, 3, 0);
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
            // LibraryProjectPathLabel
            // 
            this.LibraryProjectPathLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LibraryProjectPathLabel.AutoSize = true;
            this.LibraryProjectPathLabel.Location = new System.Drawing.Point(1, 38);
            this.LibraryProjectPathLabel.Margin = new System.Windows.Forms.Padding(1);
            this.LibraryProjectPathLabel.Name = "LibraryProjectPathLabel";
            this.LibraryProjectPathLabel.Size = new System.Drawing.Size(67, 36);
            this.LibraryProjectPathLabel.TabIndex = 0;
            this.LibraryProjectPathLabel.Text = "Project Path";
            // 
            // LibraryProjectPathExample
            // 
            this.LibraryProjectPathExample.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LibraryProjectPathExample.AutoSize = true;
            this.LibraryProjectPathExample.Location = new System.Drawing.Point(70, 38);
            this.LibraryProjectPathExample.Margin = new System.Windows.Forms.Padding(1);
            this.LibraryProjectPathExample.Name = "LibraryProjectPathExample";
            this.LibraryProjectPathExample.Size = new System.Drawing.Size(207, 36);
            this.LibraryProjectPathExample.TabIndex = 1;
            this.LibraryProjectPathExample.Text = "C:\\";
            // 
            // BlocksTabPage
            // 
            this.BlocksTabPage.Controls.Add(this.BlockTableLayoutPanel);
            this.BlocksTabPage.Controls.Add(this.BlockPictureBox);
            this.BlocksTabPage.Controls.Add(this.BlockEditImageButton);
            this.BlocksTabPage.Controls.Add(this.BlockIDLabel);
            this.BlocksTabPage.Controls.Add(this.BlockListBox);
            this.BlocksTabPage.Controls.Add(this.BlockAddNewBlockButton);
            this.BlocksTabPage.Controls.Add(this.BlockIDTextBox);
            this.BlocksTabPage.Controls.Add(this.BlockConfigGroupBox);
            this.BlocksTabPage.Controls.Add(this.BlockRemoveBlockButton);
            this.BlocksTabPage.Location = new System.Drawing.Point(4, 22);
            this.BlocksTabPage.Name = "BlocksTabPage";
            this.BlocksTabPage.Size = new System.Drawing.Size(953, 599);
            this.BlocksTabPage.TabIndex = 9;
            this.BlocksTabPage.Text = "Blocks";
            // 
            // BlockTableLayoutPanel
            // 
            this.BlockTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BlockTableLayoutPanel.ColumnCount = 3;
            this.BlockTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.BlockTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.BlockTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.BlockTableLayoutPanel.Controls.Add(this.BlockGatherToolComboBox, 1, 4);
            this.BlockTableLayoutPanel.Controls.Add(this.BlockDroppedCollectibleIDComboBox, 1, 6);
            this.BlockTableLayoutPanel.Controls.Add(this.BlockGatherEffectComboBox, 1, 5);
            this.BlockTableLayoutPanel.Controls.Add(this.BlockMaxToughnessTextBox, 1, 9);
            this.BlockTableLayoutPanel.Controls.Add(this.BlockNameLabel, 0, 0);
            this.BlockTableLayoutPanel.Controls.Add(this.BlockDescriptionLabel, 0, 1);
            this.BlockTableLayoutPanel.Controls.Add(this.BlockCommentLabel, 0, 2);
            this.BlockTableLayoutPanel.Controls.Add(this.BlockEquivalentItemLabel, 0, 3);
            this.BlockTableLayoutPanel.Controls.Add(this.BlockNameTextBox, 1, 0);
            this.BlockTableLayoutPanel.Controls.Add(this.BlockDescriptionTextBox, 1, 1);
            this.BlockTableLayoutPanel.Controls.Add(this.BlockCommentTextBox, 1, 2);
            this.BlockTableLayoutPanel.Controls.Add(this.BlockEquivalentItemComboBox, 1, 3);
            this.BlockTableLayoutPanel.Controls.Add(this.BlockGatheringToolLabel, 0, 4);
            this.BlockTableLayoutPanel.Controls.Add(this.BlockGatheringEffectLabel, 0, 5);
            this.BlockTableLayoutPanel.Controls.Add(this.BlockDroppedCollectibleLabel, 0, 6);
            this.BlockTableLayoutPanel.Controls.Add(this.BlockIsFlammableLabel, 0, 7);
            this.BlockTableLayoutPanel.Controls.Add(this.BlockIsLiquidLabel, 0, 8);
            this.BlockTableLayoutPanel.Controls.Add(this.BlockMaxToughnessLabel, 0, 9);
            this.BlockTableLayoutPanel.Controls.Add(this.BlockIsFlammableCheckBox, 1, 7);
            this.BlockTableLayoutPanel.Controls.Add(this.BlockIsLiquidCheckBox, 1, 8);
            this.BlockTableLayoutPanel.Location = new System.Drawing.Point(307, 16);
            this.BlockTableLayoutPanel.Name = "BlockTableLayoutPanel";
            this.BlockTableLayoutPanel.RowCount = 11;
            this.BlockTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.BlockTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.BlockTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.BlockTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.BlockTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.BlockTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.BlockTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.BlockTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.BlockTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.BlockTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.BlockTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BlockTableLayoutPanel.Size = new System.Drawing.Size(429, 446);
            this.BlockTableLayoutPanel.TabIndex = 5;
            // 
            // BlockGatherToolComboBox
            // 
            this.BlockGatherToolComboBox.FormattingEnabled = true;
            this.BlockGatherToolComboBox.Location = new System.Drawing.Point(131, 163);
            this.BlockGatherToolComboBox.Name = "BlockGatherToolComboBox";
            this.BlockGatherToolComboBox.Size = new System.Drawing.Size(144, 21);
            this.BlockGatherToolComboBox.TabIndex = 29;
            // 
            // BlockDroppedCollectibleIDComboBox
            // 
            this.BlockDroppedCollectibleIDComboBox.FormattingEnabled = true;
            this.BlockDroppedCollectibleIDComboBox.Location = new System.Drawing.Point(131, 213);
            this.BlockDroppedCollectibleIDComboBox.Name = "BlockDroppedCollectibleIDComboBox";
            this.BlockDroppedCollectibleIDComboBox.Size = new System.Drawing.Size(144, 21);
            this.BlockDroppedCollectibleIDComboBox.TabIndex = 29;
            // 
            // BlockGatherEffectComboBox
            // 
            this.BlockGatherEffectComboBox.FormattingEnabled = true;
            this.BlockGatherEffectComboBox.Location = new System.Drawing.Point(131, 188);
            this.BlockGatherEffectComboBox.Name = "BlockGatherEffectComboBox";
            this.BlockGatherEffectComboBox.Size = new System.Drawing.Size(144, 21);
            this.BlockGatherEffectComboBox.TabIndex = 29;
            // 
            // BlockMaxToughnessTextBox
            // 
            this.BlockMaxToughnessTextBox.Location = new System.Drawing.Point(131, 288);
            this.BlockMaxToughnessTextBox.Name = "BlockMaxToughnessTextBox";
            this.BlockMaxToughnessTextBox.Size = new System.Drawing.Size(144, 20);
            this.BlockMaxToughnessTextBox.TabIndex = 23;
            // 
            // BlockNameLabel
            // 
            this.BlockNameLabel.AutoSize = true;
            this.BlockNameLabel.Location = new System.Drawing.Point(3, 0);
            this.BlockNameLabel.Name = "BlockNameLabel";
            this.BlockNameLabel.Size = new System.Drawing.Size(34, 13);
            this.BlockNameLabel.TabIndex = 0;
            this.BlockNameLabel.Text = "Name";
            // 
            // BlockDescriptionLabel
            // 
            this.BlockDescriptionLabel.AutoSize = true;
            this.BlockDescriptionLabel.Location = new System.Drawing.Point(3, 25);
            this.BlockDescriptionLabel.Name = "BlockDescriptionLabel";
            this.BlockDescriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.BlockDescriptionLabel.TabIndex = 3;
            this.BlockDescriptionLabel.Text = "Description";
            // 
            // BlockCommentLabel
            // 
            this.BlockCommentLabel.AutoSize = true;
            this.BlockCommentLabel.Location = new System.Drawing.Point(3, 80);
            this.BlockCommentLabel.Name = "BlockCommentLabel";
            this.BlockCommentLabel.Size = new System.Drawing.Size(52, 13);
            this.BlockCommentLabel.TabIndex = 6;
            this.BlockCommentLabel.Text = "Comment";
            // 
            // BlockEquivalentItemLabel
            // 
            this.BlockEquivalentItemLabel.AutoSize = true;
            this.BlockEquivalentItemLabel.Location = new System.Drawing.Point(3, 135);
            this.BlockEquivalentItemLabel.Name = "BlockEquivalentItemLabel";
            this.BlockEquivalentItemLabel.Size = new System.Drawing.Size(82, 13);
            this.BlockEquivalentItemLabel.TabIndex = 9;
            this.BlockEquivalentItemLabel.Text = "Equivalent Item";
            // 
            // BlockNameTextBox
            // 
            this.BlockNameTextBox.Location = new System.Drawing.Point(131, 3);
            this.BlockNameTextBox.Name = "BlockNameTextBox";
            this.BlockNameTextBox.Size = new System.Drawing.Size(144, 20);
            this.BlockNameTextBox.TabIndex = 23;
            // 
            // BlockDescriptionTextBox
            // 
            this.BlockDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BlockTableLayoutPanel.SetColumnSpan(this.BlockDescriptionTextBox, 2);
            this.BlockDescriptionTextBox.Location = new System.Drawing.Point(131, 28);
            this.BlockDescriptionTextBox.Multiline = true;
            this.BlockDescriptionTextBox.Name = "BlockDescriptionTextBox";
            this.BlockDescriptionTextBox.Size = new System.Drawing.Size(295, 49);
            this.BlockDescriptionTextBox.TabIndex = 24;
            // 
            // BlockCommentTextBox
            // 
            this.BlockCommentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BlockTableLayoutPanel.SetColumnSpan(this.BlockCommentTextBox, 2);
            this.BlockCommentTextBox.Location = new System.Drawing.Point(131, 83);
            this.BlockCommentTextBox.Multiline = true;
            this.BlockCommentTextBox.Name = "BlockCommentTextBox";
            this.BlockCommentTextBox.Size = new System.Drawing.Size(295, 49);
            this.BlockCommentTextBox.TabIndex = 25;
            // 
            // BlockEquivalentItemComboBox
            // 
            this.BlockEquivalentItemComboBox.FormattingEnabled = true;
            this.BlockEquivalentItemComboBox.Location = new System.Drawing.Point(131, 138);
            this.BlockEquivalentItemComboBox.Name = "BlockEquivalentItemComboBox";
            this.BlockEquivalentItemComboBox.Size = new System.Drawing.Size(144, 21);
            this.BlockEquivalentItemComboBox.TabIndex = 29;
            // 
            // BlockGatheringToolLabel
            // 
            this.BlockGatheringToolLabel.AutoSize = true;
            this.BlockGatheringToolLabel.Location = new System.Drawing.Point(3, 160);
            this.BlockGatheringToolLabel.Name = "BlockGatheringToolLabel";
            this.BlockGatheringToolLabel.Size = new System.Drawing.Size(77, 13);
            this.BlockGatheringToolLabel.TabIndex = 30;
            this.BlockGatheringToolLabel.Text = "Gathering Tool";
            // 
            // BlockGatheringEffectLabel
            // 
            this.BlockGatheringEffectLabel.AutoSize = true;
            this.BlockGatheringEffectLabel.Location = new System.Drawing.Point(3, 185);
            this.BlockGatheringEffectLabel.Name = "BlockGatheringEffectLabel";
            this.BlockGatheringEffectLabel.Size = new System.Drawing.Size(86, 13);
            this.BlockGatheringEffectLabel.TabIndex = 31;
            this.BlockGatheringEffectLabel.Text = "Gathering Effect";
            // 
            // BlockDroppedCollectibleLabel
            // 
            this.BlockDroppedCollectibleLabel.AutoSize = true;
            this.BlockDroppedCollectibleLabel.Location = new System.Drawing.Point(3, 210);
            this.BlockDroppedCollectibleLabel.Name = "BlockDroppedCollectibleLabel";
            this.BlockDroppedCollectibleLabel.Size = new System.Drawing.Size(99, 13);
            this.BlockDroppedCollectibleLabel.TabIndex = 32;
            this.BlockDroppedCollectibleLabel.Text = "Dropped Collectible";
            // 
            // BlockIsFlammableLabel
            // 
            this.BlockIsFlammableLabel.AutoSize = true;
            this.BlockIsFlammableLabel.Location = new System.Drawing.Point(3, 235);
            this.BlockIsFlammableLabel.Name = "BlockIsFlammableLabel";
            this.BlockIsFlammableLabel.Size = new System.Drawing.Size(69, 13);
            this.BlockIsFlammableLabel.TabIndex = 33;
            this.BlockIsFlammableLabel.Text = "Is Flammable";
            // 
            // BlockIsLiquidLabel
            // 
            this.BlockIsLiquidLabel.AutoSize = true;
            this.BlockIsLiquidLabel.Location = new System.Drawing.Point(3, 260);
            this.BlockIsLiquidLabel.Name = "BlockIsLiquidLabel";
            this.BlockIsLiquidLabel.Size = new System.Drawing.Size(46, 13);
            this.BlockIsLiquidLabel.TabIndex = 34;
            this.BlockIsLiquidLabel.Text = "Is Liquid";
            // 
            // BlockMaxToughnessLabel
            // 
            this.BlockMaxToughnessLabel.AutoSize = true;
            this.BlockMaxToughnessLabel.Location = new System.Drawing.Point(3, 285);
            this.BlockMaxToughnessLabel.Name = "BlockMaxToughnessLabel";
            this.BlockMaxToughnessLabel.Size = new System.Drawing.Size(59, 13);
            this.BlockMaxToughnessLabel.TabIndex = 35;
            this.BlockMaxToughnessLabel.Text = "Toughness";
            // 
            // BlockIsFlammableCheckBox
            // 
            this.BlockIsFlammableCheckBox.AutoSize = true;
            this.BlockIsFlammableCheckBox.Location = new System.Drawing.Point(131, 238);
            this.BlockIsFlammableCheckBox.Name = "BlockIsFlammableCheckBox";
            this.BlockIsFlammableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.BlockIsFlammableCheckBox.TabIndex = 36;
            this.BlockIsFlammableCheckBox.UseVisualStyleBackColor = true;
            // 
            // BlockIsLiquidCheckBox
            // 
            this.BlockIsLiquidCheckBox.AutoSize = true;
            this.BlockIsLiquidCheckBox.Location = new System.Drawing.Point(131, 263);
            this.BlockIsLiquidCheckBox.Name = "BlockIsLiquidCheckBox";
            this.BlockIsLiquidCheckBox.Size = new System.Drawing.Size(15, 14);
            this.BlockIsLiquidCheckBox.TabIndex = 37;
            this.BlockIsLiquidCheckBox.UseVisualStyleBackColor = true;
            // 
            // BlockPictureBox
            // 
            this.BlockPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BlockPictureBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.BlockPictureBox.Location = new System.Drawing.Point(767, 286);
            this.BlockPictureBox.Name = "BlockPictureBox";
            this.BlockPictureBox.Size = new System.Drawing.Size(176, 176);
            this.BlockPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BlockPictureBox.TabIndex = 6;
            this.BlockPictureBox.TabStop = false;
            // 
            // BlockEditImageButton
            // 
            this.BlockEditImageButton.Location = new System.Drawing.Point(815, 468);
            this.BlockEditImageButton.Name = "BlockEditImageButton";
            this.BlockEditImageButton.Size = new System.Drawing.Size(128, 23);
            this.BlockEditImageButton.TabIndex = 7;
            this.BlockEditImageButton.Text = "Edit Image";
            this.BlockEditImageButton.UseVisualStyleBackColor = true;
            this.BlockEditImageButton.Click += new System.EventHandler(this.BlockEditImageButton_Click);
            // 
            // BlockIDLabel
            // 
            this.BlockIDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BlockIDLabel.AutoSize = true;
            this.BlockIDLabel.Location = new System.Drawing.Point(761, 19);
            this.BlockIDLabel.Name = "BlockIDLabel";
            this.BlockIDLabel.Size = new System.Drawing.Size(45, 13);
            this.BlockIDLabel.TabIndex = 4;
            this.BlockIDLabel.Text = "Block ID";
            // 
            // BlockListBox
            // 
            this.BlockListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BlockListBox.DisplayMember = "Name";
            this.BlockListBox.FormattingEnabled = true;
            this.BlockListBox.Location = new System.Drawing.Point(9, 16);
            this.BlockListBox.Name = "BlockListBox";
            this.BlockListBox.Size = new System.Drawing.Size(279, 446);
            this.BlockListBox.TabIndex = 1;
            // 
            // BlockAddNewBlockButton
            // 
            this.BlockAddNewBlockButton.Location = new System.Drawing.Point(159, 468);
            this.BlockAddNewBlockButton.Name = "BlockAddNewBlockButton";
            this.BlockAddNewBlockButton.Size = new System.Drawing.Size(129, 23);
            this.BlockAddNewBlockButton.TabIndex = 2;
            this.BlockAddNewBlockButton.Text = "Add New Block";
            this.BlockAddNewBlockButton.UseVisualStyleBackColor = true;
            // 
            // BlockIDTextBox
            // 
            this.BlockIDTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BlockIDTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.BlockIDTextBox.Location = new System.Drawing.Point(812, 16);
            this.BlockIDTextBox.Name = "BlockIDTextBox";
            this.BlockIDTextBox.Size = new System.Drawing.Size(131, 20);
            this.BlockIDTextBox.TabIndex = 3;
            this.BlockIDTextBox.Text = "-2020202020";
            // 
            // BlockConfigGroupBox
            // 
            this.BlockConfigGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BlockConfigGroupBox.Location = new System.Drawing.Point(9, 497);
            this.BlockConfigGroupBox.Name = "BlockConfigGroupBox";
            this.BlockConfigGroupBox.Size = new System.Drawing.Size(938, 96);
            this.BlockConfigGroupBox.TabIndex = 0;
            this.BlockConfigGroupBox.TabStop = false;
            // 
            // BlockRemoveBlockButton
            // 
            this.BlockRemoveBlockButton.Location = new System.Drawing.Point(24, 468);
            this.BlockRemoveBlockButton.Name = "BlockRemoveBlockButton";
            this.BlockRemoveBlockButton.Size = new System.Drawing.Size(129, 23);
            this.BlockRemoveBlockButton.TabIndex = 2;
            this.BlockRemoveBlockButton.Text = "Remove Block";
            this.BlockRemoveBlockButton.UseVisualStyleBackColor = true;
            // 
            // FloorsTabPage
            // 
            this.FloorsTabPage.BackColor = System.Drawing.Color.Transparent;
            this.FloorsTabPage.Controls.Add(this.FloorRemoveFloorButton);
            this.FloorsTabPage.Controls.Add(this.FloorLayoutTabelPanel);
            this.FloorsTabPage.Controls.Add(this.FloorConfigGroupBox);
            this.FloorsTabPage.Controls.Add(this.FloorIDTextBox);
            this.FloorsTabPage.Controls.Add(this.FloorAddNewFloorButton);
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
            // FloorRemoveFloorButton
            // 
            this.FloorRemoveFloorButton.Location = new System.Drawing.Point(24, 468);
            this.FloorRemoveFloorButton.Name = "FloorRemoveFloorButton";
            this.FloorRemoveFloorButton.Size = new System.Drawing.Size(129, 23);
            this.FloorRemoveFloorButton.TabIndex = 2;
            this.FloorRemoveFloorButton.Text = "Remove Floor";
            this.FloorRemoveFloorButton.UseVisualStyleBackColor = true;
            // 
            // FloorLayoutTabelPanel
            // 
            this.FloorLayoutTabelPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.FloorLayoutTabelPanel.ColumnCount = 3;
            this.FloorLayoutTabelPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.FloorLayoutTabelPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.FloorLayoutTabelPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.FloorLayoutTabelPanel.Controls.Add(this.FloorRemoveRoomTagButton, 1, 7);
            this.FloorLayoutTabelPanel.Controls.Add(this.FloorRemoveBiomeTagButton, 1, 5);
            this.FloorLayoutTabelPanel.Controls.Add(this.FloorAddRoomTagButton, 2, 7);
            this.FloorLayoutTabelPanel.Controls.Add(this.FloorNameLabel, 0, 0);
            this.FloorLayoutTabelPanel.Controls.Add(this.FloorDescriptionLabel, 0, 1);
            this.FloorLayoutTabelPanel.Controls.Add(this.FloorCommentLabel, 0, 2);
            this.FloorLayoutTabelPanel.Controls.Add(this.FloorEquivalentItemIDLabel, 0, 3);
            this.FloorLayoutTabelPanel.Controls.Add(this.FloorNameTextBox, 1, 0);
            this.FloorLayoutTabelPanel.Controls.Add(this.FloorDescriptionTextBox, 1, 1);
            this.FloorLayoutTabelPanel.Controls.Add(this.FloorCommentTextBox, 1, 2);
            this.FloorLayoutTabelPanel.Controls.Add(this.FloorlItemIDComboBox, 1, 3);
            this.FloorLayoutTabelPanel.Controls.Add(this.FloorModificationToolLabel, 0, 8);
            this.FloorLayoutTabelPanel.Controls.Add(this.FloorModificationToolComboBox, 1, 8);
            this.FloorLayoutTabelPanel.Controls.Add(this.FloorTrenchName, 0, 9);
            this.FloorLayoutTabelPanel.Controls.Add(this.FloorTrenchNameTextBox, 1, 9);
            this.FloorLayoutTabelPanel.Controls.Add(this.FloorAddsToBiomeLabel, 0, 4);
            this.FloorLayoutTabelPanel.Controls.Add(this.FloorAddsToRoomLabel, 0, 6);
            this.FloorLayoutTabelPanel.Controls.Add(this.FloorAddsToBiomeListBox, 1, 4);
            this.FloorLayoutTabelPanel.Controls.Add(this.FloorAddsToRoomListBox, 1, 6);
            this.FloorLayoutTabelPanel.Controls.Add(this.FloorAddBiomeTagButton, 2, 5);
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
            // FloorRemoveRoomTagButton
            // 
            this.FloorRemoveRoomTagButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FloorRemoveRoomTagButton.Location = new System.Drawing.Point(146, 343);
            this.FloorRemoveRoomTagButton.Name = "FloorRemoveRoomTagButton";
            this.FloorRemoveRoomTagButton.Size = new System.Drawing.Size(129, 23);
            this.FloorRemoveRoomTagButton.TabIndex = 38;
            this.FloorRemoveRoomTagButton.Text = "Remove Room Tag";
            this.FloorRemoveRoomTagButton.UseVisualStyleBackColor = true;
            // 
            // FloorRemoveBiomeTagButton
            // 
            this.FloorRemoveBiomeTagButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FloorRemoveBiomeTagButton.Location = new System.Drawing.Point(146, 238);
            this.FloorRemoveBiomeTagButton.Name = "FloorRemoveBiomeTagButton";
            this.FloorRemoveBiomeTagButton.Size = new System.Drawing.Size(129, 23);
            this.FloorRemoveBiomeTagButton.TabIndex = 38;
            this.FloorRemoveBiomeTagButton.Text = "Remove Biome Tag";
            this.FloorRemoveBiomeTagButton.UseVisualStyleBackColor = true;
            // 
            // FloorAddRoomTagButton
            // 
            this.FloorAddRoomTagButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FloorAddRoomTagButton.Location = new System.Drawing.Point(297, 343);
            this.FloorAddRoomTagButton.Name = "FloorAddRoomTagButton";
            this.FloorAddRoomTagButton.Size = new System.Drawing.Size(129, 23);
            this.FloorAddRoomTagButton.TabIndex = 38;
            this.FloorAddRoomTagButton.Text = "Add Room Tag";
            this.FloorAddRoomTagButton.UseVisualStyleBackColor = true;
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
            // FloorEquivalentItemIDLabel
            // 
            this.FloorEquivalentItemIDLabel.AutoSize = true;
            this.FloorEquivalentItemIDLabel.Location = new System.Drawing.Point(3, 135);
            this.FloorEquivalentItemIDLabel.Name = "FloorEquivalentItemIDLabel";
            this.FloorEquivalentItemIDLabel.Size = new System.Drawing.Size(82, 13);
            this.FloorEquivalentItemIDLabel.TabIndex = 9;
            this.FloorEquivalentItemIDLabel.Text = "Equivalent Item";
            // 
            // FloorNameTextBox
            // 
            this.FloorNameTextBox.Location = new System.Drawing.Point(131, 3);
            this.FloorNameTextBox.Name = "FloorNameTextBox";
            this.FloorNameTextBox.Size = new System.Drawing.Size(144, 20);
            this.FloorNameTextBox.TabIndex = 23;
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
            // FloorAddsToBiomeLabel
            // 
            this.FloorAddsToBiomeLabel.AutoSize = true;
            this.FloorAddsToBiomeLabel.Location = new System.Drawing.Point(3, 160);
            this.FloorAddsToBiomeLabel.Name = "FloorAddsToBiomeLabel";
            this.FloorAddsToBiomeLabel.Size = new System.Drawing.Size(75, 13);
            this.FloorAddsToBiomeLabel.TabIndex = 35;
            this.FloorAddsToBiomeLabel.Text = "Adds to Biome";
            // 
            // FloorAddsToRoomLabel
            // 
            this.FloorAddsToRoomLabel.AutoSize = true;
            this.FloorAddsToRoomLabel.Location = new System.Drawing.Point(3, 265);
            this.FloorAddsToRoomLabel.Name = "FloorAddsToRoomLabel";
            this.FloorAddsToRoomLabel.Size = new System.Drawing.Size(74, 13);
            this.FloorAddsToRoomLabel.TabIndex = 36;
            this.FloorAddsToRoomLabel.Text = "Adds to Room";
            // 
            // FloorAddsToBiomeListBox
            // 
            this.FloorAddsToBiomeListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FloorLayoutTabelPanel.SetColumnSpan(this.FloorAddsToBiomeListBox, 2);
            this.FloorAddsToBiomeListBox.FormattingEnabled = true;
            this.FloorAddsToBiomeListBox.Location = new System.Drawing.Point(131, 163);
            this.FloorAddsToBiomeListBox.Name = "FloorAddsToBiomeListBox";
            this.FloorAddsToBiomeListBox.Size = new System.Drawing.Size(295, 69);
            this.FloorAddsToBiomeListBox.TabIndex = 37;
            // 
            // FloorAddsToRoomListBox
            // 
            this.FloorAddsToRoomListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FloorLayoutTabelPanel.SetColumnSpan(this.FloorAddsToRoomListBox, 2);
            this.FloorAddsToRoomListBox.FormattingEnabled = true;
            this.FloorAddsToRoomListBox.Location = new System.Drawing.Point(131, 268);
            this.FloorAddsToRoomListBox.Name = "FloorAddsToRoomListBox";
            this.FloorAddsToRoomListBox.Size = new System.Drawing.Size(295, 69);
            this.FloorAddsToRoomListBox.TabIndex = 37;
            // 
            // FloorAddBiomeTagButton
            // 
            this.FloorAddBiomeTagButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FloorAddBiomeTagButton.Location = new System.Drawing.Point(297, 238);
            this.FloorAddBiomeTagButton.Name = "FloorAddBiomeTagButton";
            this.FloorAddBiomeTagButton.Size = new System.Drawing.Size(129, 23);
            this.FloorAddBiomeTagButton.TabIndex = 38;
            this.FloorAddBiomeTagButton.Text = "Add Biome Tag";
            this.FloorAddBiomeTagButton.UseVisualStyleBackColor = true;
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
            // FloorAddNewFloorButton
            // 
            this.FloorAddNewFloorButton.Location = new System.Drawing.Point(159, 468);
            this.FloorAddNewFloorButton.Name = "FloorAddNewFloorButton";
            this.FloorAddNewFloorButton.Size = new System.Drawing.Size(129, 23);
            this.FloorAddNewFloorButton.TabIndex = 2;
            this.FloorAddNewFloorButton.Text = "Add New Floor";
            this.FloorAddNewFloorButton.UseVisualStyleBackColor = true;
            // 
            // FloorListBox
            // 
            this.FloorListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.FloorListBox.DisplayMember = "Name";
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
            this.FloorEditImageButton.Click += new System.EventHandler(this.FloorEditImageButton_Click);
            // 
            // FloorPictureBox
            // 
            this.FloorPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FloorPictureBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.FloorPictureBox.Location = new System.Drawing.Point(767, 286);
            this.FloorPictureBox.Name = "FloorPictureBox";
            this.FloorPictureBox.Size = new System.Drawing.Size(176, 176);
            this.FloorPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.FloorPictureBox.TabIndex = 6;
            this.FloorPictureBox.TabStop = false;
            // 
            // FurnishingsTabPage
            // 
            this.FurnishingsTabPage.Controls.Add(this.FurnishingTableLayoutPanel);
            this.FurnishingsTabPage.Controls.Add(this.FurnishingRemoveFurnishingButton);
            this.FurnishingsTabPage.Controls.Add(this.FurnishingConfigGroupBox);
            this.FurnishingsTabPage.Controls.Add(this.FurnishingIDTextBox);
            this.FurnishingsTabPage.Controls.Add(this.FurnishingAddNewFurnishingButton);
            this.FurnishingsTabPage.Controls.Add(this.FurnishingListBox);
            this.FurnishingsTabPage.Controls.Add(this.FurnishingIDLabel);
            this.FurnishingsTabPage.Controls.Add(this.FurnishingEditImageButton);
            this.FurnishingsTabPage.Controls.Add(this.FurnishingPictureBox);
            this.FurnishingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.FurnishingsTabPage.Name = "FurnishingsTabPage";
            this.FurnishingsTabPage.Size = new System.Drawing.Size(953, 599);
            this.FurnishingsTabPage.TabIndex = 10;
            this.FurnishingsTabPage.Text = "Furnishings";
            // 
            // FurnishingTableLayoutPanel
            // 
            this.FurnishingTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.FurnishingTableLayoutPanel.ColumnCount = 3;
            this.FurnishingTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.FurnishingTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.FurnishingTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.FurnishingTableLayoutPanel.Controls.Add(this.FurnishingSwapWithFurnishingComboBox, 1, 8);
            this.FurnishingTableLayoutPanel.Controls.Add(this.FurnishingEntryTypeComboBox, 1, 4);
            this.FurnishingTableLayoutPanel.Controls.Add(this.FurnishingNameLabel, 0, 0);
            this.FurnishingTableLayoutPanel.Controls.Add(this.FurnishingDescriptionLabel, 0, 1);
            this.FurnishingTableLayoutPanel.Controls.Add(this.FurnishingCommentLabel, 0, 2);
            this.FurnishingTableLayoutPanel.Controls.Add(this.FurnishingEquivalentItemLabel, 0, 3);
            this.FurnishingTableLayoutPanel.Controls.Add(this.FurnishingNameTextBox, 1, 0);
            this.FurnishingTableLayoutPanel.Controls.Add(this.FurnishingDescriptionTextBox, 1, 1);
            this.FurnishingTableLayoutPanel.Controls.Add(this.FurnishingCommentTextBox, 1, 2);
            this.FurnishingTableLayoutPanel.Controls.Add(this.FurnishingEquivalentItemComboBox, 1, 3);
            this.FurnishingTableLayoutPanel.Controls.Add(this.FurnishingEntryTypeLabel, 0, 4);
            this.FurnishingTableLayoutPanel.Controls.Add(this.FurnishingIsWalkableLabel, 0, 5);
            this.FurnishingTableLayoutPanel.Controls.Add(this.FurnishingIsEnclosingLabel, 0, 6);
            this.FurnishingTableLayoutPanel.Controls.Add(this.FurnishingIsFlammableLabel, 0, 7);
            this.FurnishingTableLayoutPanel.Controls.Add(this.FurnishingSwapWithFurnishingLabel, 0, 8);
            this.FurnishingTableLayoutPanel.Controls.Add(this.FurnishingIsWalkableCheckBox, 1, 5);
            this.FurnishingTableLayoutPanel.Controls.Add(this.FurnishingIsEnclosingCheckBox, 1, 6);
            this.FurnishingTableLayoutPanel.Controls.Add(this.FurnishingIsFlammableCheckBox, 1, 7);
            this.FurnishingTableLayoutPanel.Location = new System.Drawing.Point(307, 16);
            this.FurnishingTableLayoutPanel.Name = "FurnishingTableLayoutPanel";
            this.FurnishingTableLayoutPanel.RowCount = 10;
            this.FurnishingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.FurnishingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.FurnishingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.FurnishingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.FurnishingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.FurnishingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.FurnishingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.FurnishingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.FurnishingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.FurnishingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FurnishingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.FurnishingTableLayoutPanel.Size = new System.Drawing.Size(429, 446);
            this.FurnishingTableLayoutPanel.TabIndex = 5;
            // 
            // FurnishingSwapWithFurnishingComboBox
            // 
            this.FurnishingSwapWithFurnishingComboBox.FormattingEnabled = true;
            this.FurnishingSwapWithFurnishingComboBox.Location = new System.Drawing.Point(131, 263);
            this.FurnishingSwapWithFurnishingComboBox.Name = "FurnishingSwapWithFurnishingComboBox";
            this.FurnishingSwapWithFurnishingComboBox.Size = new System.Drawing.Size(144, 21);
            this.FurnishingSwapWithFurnishingComboBox.TabIndex = 29;
            // 
            // FurnishingEntryTypeComboBox
            // 
            this.FurnishingEntryTypeComboBox.FormattingEnabled = true;
            this.FurnishingEntryTypeComboBox.Location = new System.Drawing.Point(131, 163);
            this.FurnishingEntryTypeComboBox.Name = "FurnishingEntryTypeComboBox";
            this.FurnishingEntryTypeComboBox.Size = new System.Drawing.Size(144, 21);
            this.FurnishingEntryTypeComboBox.TabIndex = 29;
            // 
            // FurnishingNameLabel
            // 
            this.FurnishingNameLabel.AutoSize = true;
            this.FurnishingNameLabel.Location = new System.Drawing.Point(3, 0);
            this.FurnishingNameLabel.Name = "FurnishingNameLabel";
            this.FurnishingNameLabel.Size = new System.Drawing.Size(34, 13);
            this.FurnishingNameLabel.TabIndex = 0;
            this.FurnishingNameLabel.Text = "Name";
            // 
            // FurnishingDescriptionLabel
            // 
            this.FurnishingDescriptionLabel.AutoSize = true;
            this.FurnishingDescriptionLabel.Location = new System.Drawing.Point(3, 25);
            this.FurnishingDescriptionLabel.Name = "FurnishingDescriptionLabel";
            this.FurnishingDescriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.FurnishingDescriptionLabel.TabIndex = 3;
            this.FurnishingDescriptionLabel.Text = "Description";
            // 
            // FurnishingCommentLabel
            // 
            this.FurnishingCommentLabel.AutoSize = true;
            this.FurnishingCommentLabel.Location = new System.Drawing.Point(3, 80);
            this.FurnishingCommentLabel.Name = "FurnishingCommentLabel";
            this.FurnishingCommentLabel.Size = new System.Drawing.Size(52, 13);
            this.FurnishingCommentLabel.TabIndex = 6;
            this.FurnishingCommentLabel.Text = "Comment";
            // 
            // FurnishingEquivalentItemLabel
            // 
            this.FurnishingEquivalentItemLabel.AutoSize = true;
            this.FurnishingEquivalentItemLabel.Location = new System.Drawing.Point(3, 135);
            this.FurnishingEquivalentItemLabel.Name = "FurnishingEquivalentItemLabel";
            this.FurnishingEquivalentItemLabel.Size = new System.Drawing.Size(82, 13);
            this.FurnishingEquivalentItemLabel.TabIndex = 9;
            this.FurnishingEquivalentItemLabel.Text = "Equivalent Item";
            // 
            // FurnishingNameTextBox
            // 
            this.FurnishingNameTextBox.Location = new System.Drawing.Point(131, 3);
            this.FurnishingNameTextBox.Name = "FurnishingNameTextBox";
            this.FurnishingNameTextBox.Size = new System.Drawing.Size(144, 20);
            this.FurnishingNameTextBox.TabIndex = 23;
            // 
            // FurnishingDescriptionTextBox
            // 
            this.FurnishingDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FurnishingTableLayoutPanel.SetColumnSpan(this.FurnishingDescriptionTextBox, 2);
            this.FurnishingDescriptionTextBox.Location = new System.Drawing.Point(131, 28);
            this.FurnishingDescriptionTextBox.Multiline = true;
            this.FurnishingDescriptionTextBox.Name = "FurnishingDescriptionTextBox";
            this.FurnishingDescriptionTextBox.Size = new System.Drawing.Size(295, 49);
            this.FurnishingDescriptionTextBox.TabIndex = 24;
            // 
            // FurnishingCommentTextBox
            // 
            this.FurnishingCommentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FurnishingTableLayoutPanel.SetColumnSpan(this.FurnishingCommentTextBox, 2);
            this.FurnishingCommentTextBox.Location = new System.Drawing.Point(131, 83);
            this.FurnishingCommentTextBox.Multiline = true;
            this.FurnishingCommentTextBox.Name = "FurnishingCommentTextBox";
            this.FurnishingCommentTextBox.Size = new System.Drawing.Size(295, 49);
            this.FurnishingCommentTextBox.TabIndex = 25;
            // 
            // FurnishingEquivalentItemComboBox
            // 
            this.FurnishingEquivalentItemComboBox.FormattingEnabled = true;
            this.FurnishingEquivalentItemComboBox.Location = new System.Drawing.Point(131, 138);
            this.FurnishingEquivalentItemComboBox.Name = "FurnishingEquivalentItemComboBox";
            this.FurnishingEquivalentItemComboBox.Size = new System.Drawing.Size(144, 21);
            this.FurnishingEquivalentItemComboBox.TabIndex = 29;
            // 
            // FurnishingEntryTypeLabel
            // 
            this.FurnishingEntryTypeLabel.AutoSize = true;
            this.FurnishingEntryTypeLabel.Location = new System.Drawing.Point(3, 160);
            this.FurnishingEntryTypeLabel.Name = "FurnishingEntryTypeLabel";
            this.FurnishingEntryTypeLabel.Size = new System.Drawing.Size(60, 13);
            this.FurnishingEntryTypeLabel.TabIndex = 30;
            this.FurnishingEntryTypeLabel.Text = "Entry Type";
            // 
            // FurnishingIsWalkableLabel
            // 
            this.FurnishingIsWalkableLabel.AutoSize = true;
            this.FurnishingIsWalkableLabel.Location = new System.Drawing.Point(3, 185);
            this.FurnishingIsWalkableLabel.Name = "FurnishingIsWalkableLabel";
            this.FurnishingIsWalkableLabel.Size = new System.Drawing.Size(62, 13);
            this.FurnishingIsWalkableLabel.TabIndex = 31;
            this.FurnishingIsWalkableLabel.Text = "Is Walkable";
            // 
            // FurnishingIsEnclosingLabel
            // 
            this.FurnishingIsEnclosingLabel.AutoSize = true;
            this.FurnishingIsEnclosingLabel.Location = new System.Drawing.Point(3, 210);
            this.FurnishingIsEnclosingLabel.Name = "FurnishingIsEnclosingLabel";
            this.FurnishingIsEnclosingLabel.Size = new System.Drawing.Size(63, 13);
            this.FurnishingIsEnclosingLabel.TabIndex = 32;
            this.FurnishingIsEnclosingLabel.Text = "Is Enclosing";
            // 
            // FurnishingIsFlammableLabel
            // 
            this.FurnishingIsFlammableLabel.AutoSize = true;
            this.FurnishingIsFlammableLabel.Location = new System.Drawing.Point(3, 235);
            this.FurnishingIsFlammableLabel.Name = "FurnishingIsFlammableLabel";
            this.FurnishingIsFlammableLabel.Size = new System.Drawing.Size(69, 13);
            this.FurnishingIsFlammableLabel.TabIndex = 33;
            this.FurnishingIsFlammableLabel.Text = "Is Flammable";
            // 
            // FurnishingSwapWithFurnishingLabel
            // 
            this.FurnishingSwapWithFurnishingLabel.AutoSize = true;
            this.FurnishingSwapWithFurnishingLabel.Location = new System.Drawing.Point(3, 260);
            this.FurnishingSwapWithFurnishingLabel.Name = "FurnishingSwapWithFurnishingLabel";
            this.FurnishingSwapWithFurnishingLabel.Size = new System.Drawing.Size(110, 13);
            this.FurnishingSwapWithFurnishingLabel.TabIndex = 34;
            this.FurnishingSwapWithFurnishingLabel.Text = "Swap With Furnishing";
            // 
            // FurnishingIsWalkableCheckBox
            // 
            this.FurnishingIsWalkableCheckBox.AutoSize = true;
            this.FurnishingIsWalkableCheckBox.Location = new System.Drawing.Point(131, 188);
            this.FurnishingIsWalkableCheckBox.Name = "FurnishingIsWalkableCheckBox";
            this.FurnishingIsWalkableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.FurnishingIsWalkableCheckBox.TabIndex = 35;
            this.FurnishingIsWalkableCheckBox.UseVisualStyleBackColor = true;
            // 
            // FurnishingIsEnclosingCheckBox
            // 
            this.FurnishingIsEnclosingCheckBox.AutoSize = true;
            this.FurnishingIsEnclosingCheckBox.Location = new System.Drawing.Point(131, 213);
            this.FurnishingIsEnclosingCheckBox.Name = "FurnishingIsEnclosingCheckBox";
            this.FurnishingIsEnclosingCheckBox.Size = new System.Drawing.Size(15, 14);
            this.FurnishingIsEnclosingCheckBox.TabIndex = 36;
            this.FurnishingIsEnclosingCheckBox.UseVisualStyleBackColor = true;
            // 
            // FurnishingIsFlammableCheckBox
            // 
            this.FurnishingIsFlammableCheckBox.AutoSize = true;
            this.FurnishingIsFlammableCheckBox.Location = new System.Drawing.Point(131, 238);
            this.FurnishingIsFlammableCheckBox.Name = "FurnishingIsFlammableCheckBox";
            this.FurnishingIsFlammableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.FurnishingIsFlammableCheckBox.TabIndex = 37;
            this.FurnishingIsFlammableCheckBox.UseVisualStyleBackColor = true;
            // 
            // FurnishingRemoveFurnishingButton
            // 
            this.FurnishingRemoveFurnishingButton.Location = new System.Drawing.Point(24, 468);
            this.FurnishingRemoveFurnishingButton.Name = "FurnishingRemoveFurnishingButton";
            this.FurnishingRemoveFurnishingButton.Size = new System.Drawing.Size(129, 23);
            this.FurnishingRemoveFurnishingButton.TabIndex = 2;
            this.FurnishingRemoveFurnishingButton.Text = "Remove Furnishing";
            this.FurnishingRemoveFurnishingButton.UseVisualStyleBackColor = true;
            // 
            // FurnishingConfigGroupBox
            // 
            this.FurnishingConfigGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FurnishingConfigGroupBox.Location = new System.Drawing.Point(9, 497);
            this.FurnishingConfigGroupBox.Name = "FurnishingConfigGroupBox";
            this.FurnishingConfigGroupBox.Size = new System.Drawing.Size(938, 96);
            this.FurnishingConfigGroupBox.TabIndex = 0;
            this.FurnishingConfigGroupBox.TabStop = false;
            // 
            // FurnishingIDTextBox
            // 
            this.FurnishingIDTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FurnishingIDTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.FurnishingIDTextBox.Location = new System.Drawing.Point(812, 16);
            this.FurnishingIDTextBox.Name = "FurnishingIDTextBox";
            this.FurnishingIDTextBox.Size = new System.Drawing.Size(131, 20);
            this.FurnishingIDTextBox.TabIndex = 3;
            this.FurnishingIDTextBox.Text = "-2020202020";
            // 
            // FurnishingAddNewFurnishingButton
            // 
            this.FurnishingAddNewFurnishingButton.Location = new System.Drawing.Point(159, 468);
            this.FurnishingAddNewFurnishingButton.Name = "FurnishingAddNewFurnishingButton";
            this.FurnishingAddNewFurnishingButton.Size = new System.Drawing.Size(129, 23);
            this.FurnishingAddNewFurnishingButton.TabIndex = 2;
            this.FurnishingAddNewFurnishingButton.Text = "Add New Furnishing";
            this.FurnishingAddNewFurnishingButton.UseVisualStyleBackColor = true;
            // 
            // FurnishingListBox
            // 
            this.FurnishingListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.FurnishingListBox.DisplayMember = "Name";
            this.FurnishingListBox.FormattingEnabled = true;
            this.FurnishingListBox.Location = new System.Drawing.Point(9, 16);
            this.FurnishingListBox.Name = "FurnishingListBox";
            this.FurnishingListBox.Size = new System.Drawing.Size(279, 446);
            this.FurnishingListBox.TabIndex = 1;
            // 
            // FurnishingIDLabel
            // 
            this.FurnishingIDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FurnishingIDLabel.AutoSize = true;
            this.FurnishingIDLabel.Location = new System.Drawing.Point(742, 19);
            this.FurnishingIDLabel.Name = "FurnishingIDLabel";
            this.FurnishingIDLabel.Size = new System.Drawing.Size(70, 13);
            this.FurnishingIDLabel.TabIndex = 4;
            this.FurnishingIDLabel.Text = "Furnishing ID";
            // 
            // FurnishingEditImageButton
            // 
            this.FurnishingEditImageButton.Location = new System.Drawing.Point(815, 468);
            this.FurnishingEditImageButton.Name = "FurnishingEditImageButton";
            this.FurnishingEditImageButton.Size = new System.Drawing.Size(128, 23);
            this.FurnishingEditImageButton.TabIndex = 7;
            this.FurnishingEditImageButton.Text = "Edit Image";
            this.FurnishingEditImageButton.UseVisualStyleBackColor = true;
            this.FurnishingEditImageButton.Click += new System.EventHandler(this.FurnishingEditImageButton_Click);
            // 
            // FurnishingPictureBox
            // 
            this.FurnishingPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FurnishingPictureBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.FurnishingPictureBox.Location = new System.Drawing.Point(767, 286);
            this.FurnishingPictureBox.Name = "FurnishingPictureBox";
            this.FurnishingPictureBox.Size = new System.Drawing.Size(176, 176);
            this.FurnishingPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.FurnishingPictureBox.TabIndex = 6;
            this.FurnishingPictureBox.TabStop = false;
            // 
            // CollectiblesTabPage
            // 
            this.CollectiblesTabPage.Controls.Add(this.CollectibleTableLayoutPanel);
            this.CollectiblesTabPage.Controls.Add(this.CollectibleRemoveCollectibleButton);
            this.CollectiblesTabPage.Controls.Add(this.CollectibleConfigGroupBox);
            this.CollectiblesTabPage.Controls.Add(this.CollectibleIDTextBox);
            this.CollectiblesTabPage.Controls.Add(this.CollectibleAddNewCollectibleButton);
            this.CollectiblesTabPage.Controls.Add(this.CollectibleListBox);
            this.CollectiblesTabPage.Controls.Add(this.CollectibleIDLabel);
            this.CollectiblesTabPage.Controls.Add(this.CollectibleEditImageButton);
            this.CollectiblesTabPage.Controls.Add(this.CollectiblePictureBox);
            this.CollectiblesTabPage.Location = new System.Drawing.Point(4, 22);
            this.CollectiblesTabPage.Name = "CollectiblesTabPage";
            this.CollectiblesTabPage.Size = new System.Drawing.Size(953, 599);
            this.CollectiblesTabPage.TabIndex = 11;
            this.CollectiblesTabPage.Text = "Collectibles";
            // 
            // CollectibleTableLayoutPanel
            // 
            this.CollectibleTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CollectibleTableLayoutPanel.ColumnCount = 3;
            this.CollectibleTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.CollectibleTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.CollectibleTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.CollectibleTableLayoutPanel.Controls.Add(this.CollectibleEffectAmountTextBox, 1, 5);
            this.CollectibleTableLayoutPanel.Controls.Add(this.CollectibleCollectionEffectComboBox, 1, 4);
            this.CollectibleTableLayoutPanel.Controls.Add(this.CollectibleNameLabel, 0, 0);
            this.CollectibleTableLayoutPanel.Controls.Add(this.CollectibleDescriptionLabel, 0, 1);
            this.CollectibleTableLayoutPanel.Controls.Add(this.CollectibleCommentLabel, 0, 2);
            this.CollectibleTableLayoutPanel.Controls.Add(this.CollectibleEquivalentItemLabel, 0, 3);
            this.CollectibleTableLayoutPanel.Controls.Add(this.CollectibleNameTextBox, 1, 0);
            this.CollectibleTableLayoutPanel.Controls.Add(this.CollectibleDescriptionTextBox, 1, 1);
            this.CollectibleTableLayoutPanel.Controls.Add(this.CollectibleCommentTextBox, 1, 2);
            this.CollectibleTableLayoutPanel.Controls.Add(this.CollectibleEquivalentItemComboBox, 1, 3);
            this.CollectibleTableLayoutPanel.Controls.Add(this.CollectibleCollectionEffectLabel, 0, 4);
            this.CollectibleTableLayoutPanel.Controls.Add(this.CollectibleEffectAmountLabel, 0, 5);
            this.CollectibleTableLayoutPanel.Location = new System.Drawing.Point(307, 16);
            this.CollectibleTableLayoutPanel.Name = "CollectibleTableLayoutPanel";
            this.CollectibleTableLayoutPanel.RowCount = 7;
            this.CollectibleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.CollectibleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.CollectibleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.CollectibleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.CollectibleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.CollectibleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.CollectibleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CollectibleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.CollectibleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.CollectibleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.CollectibleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.CollectibleTableLayoutPanel.Size = new System.Drawing.Size(429, 446);
            this.CollectibleTableLayoutPanel.TabIndex = 5;
            // 
            // CollectibleEffectAmountTextBox
            // 
            this.CollectibleEffectAmountTextBox.Location = new System.Drawing.Point(131, 188);
            this.CollectibleEffectAmountTextBox.Name = "CollectibleEffectAmountTextBox";
            this.CollectibleEffectAmountTextBox.Size = new System.Drawing.Size(144, 20);
            this.CollectibleEffectAmountTextBox.TabIndex = 23;
            // 
            // CollectibleCollectionEffectComboBox
            // 
            this.CollectibleCollectionEffectComboBox.FormattingEnabled = true;
            this.CollectibleCollectionEffectComboBox.Location = new System.Drawing.Point(131, 163);
            this.CollectibleCollectionEffectComboBox.Name = "CollectibleCollectionEffectComboBox";
            this.CollectibleCollectionEffectComboBox.Size = new System.Drawing.Size(144, 21);
            this.CollectibleCollectionEffectComboBox.TabIndex = 29;
            // 
            // CollectibleNameLabel
            // 
            this.CollectibleNameLabel.AutoSize = true;
            this.CollectibleNameLabel.Location = new System.Drawing.Point(3, 0);
            this.CollectibleNameLabel.Name = "CollectibleNameLabel";
            this.CollectibleNameLabel.Size = new System.Drawing.Size(34, 13);
            this.CollectibleNameLabel.TabIndex = 0;
            this.CollectibleNameLabel.Text = "Name";
            // 
            // CollectibleDescriptionLabel
            // 
            this.CollectibleDescriptionLabel.AutoSize = true;
            this.CollectibleDescriptionLabel.Location = new System.Drawing.Point(3, 25);
            this.CollectibleDescriptionLabel.Name = "CollectibleDescriptionLabel";
            this.CollectibleDescriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.CollectibleDescriptionLabel.TabIndex = 3;
            this.CollectibleDescriptionLabel.Text = "Description";
            // 
            // CollectibleCommentLabel
            // 
            this.CollectibleCommentLabel.AutoSize = true;
            this.CollectibleCommentLabel.Location = new System.Drawing.Point(3, 80);
            this.CollectibleCommentLabel.Name = "CollectibleCommentLabel";
            this.CollectibleCommentLabel.Size = new System.Drawing.Size(52, 13);
            this.CollectibleCommentLabel.TabIndex = 6;
            this.CollectibleCommentLabel.Text = "Comment";
            // 
            // CollectibleEquivalentItemLabel
            // 
            this.CollectibleEquivalentItemLabel.AutoSize = true;
            this.CollectibleEquivalentItemLabel.Location = new System.Drawing.Point(3, 135);
            this.CollectibleEquivalentItemLabel.Name = "CollectibleEquivalentItemLabel";
            this.CollectibleEquivalentItemLabel.Size = new System.Drawing.Size(82, 13);
            this.CollectibleEquivalentItemLabel.TabIndex = 9;
            this.CollectibleEquivalentItemLabel.Text = "Equivalent Item";
            // 
            // CollectibleNameTextBox
            // 
            this.CollectibleNameTextBox.Location = new System.Drawing.Point(131, 3);
            this.CollectibleNameTextBox.Name = "CollectibleNameTextBox";
            this.CollectibleNameTextBox.Size = new System.Drawing.Size(144, 20);
            this.CollectibleNameTextBox.TabIndex = 23;
            // 
            // CollectibleDescriptionTextBox
            // 
            this.CollectibleDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CollectibleTableLayoutPanel.SetColumnSpan(this.CollectibleDescriptionTextBox, 2);
            this.CollectibleDescriptionTextBox.Location = new System.Drawing.Point(131, 28);
            this.CollectibleDescriptionTextBox.Multiline = true;
            this.CollectibleDescriptionTextBox.Name = "CollectibleDescriptionTextBox";
            this.CollectibleDescriptionTextBox.Size = new System.Drawing.Size(295, 49);
            this.CollectibleDescriptionTextBox.TabIndex = 24;
            // 
            // CollectibleCommentTextBox
            // 
            this.CollectibleCommentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CollectibleTableLayoutPanel.SetColumnSpan(this.CollectibleCommentTextBox, 2);
            this.CollectibleCommentTextBox.Location = new System.Drawing.Point(131, 83);
            this.CollectibleCommentTextBox.Multiline = true;
            this.CollectibleCommentTextBox.Name = "CollectibleCommentTextBox";
            this.CollectibleCommentTextBox.Size = new System.Drawing.Size(295, 49);
            this.CollectibleCommentTextBox.TabIndex = 25;
            // 
            // CollectibleEquivalentItemComboBox
            // 
            this.CollectibleEquivalentItemComboBox.FormattingEnabled = true;
            this.CollectibleEquivalentItemComboBox.Location = new System.Drawing.Point(131, 138);
            this.CollectibleEquivalentItemComboBox.Name = "CollectibleEquivalentItemComboBox";
            this.CollectibleEquivalentItemComboBox.Size = new System.Drawing.Size(144, 21);
            this.CollectibleEquivalentItemComboBox.TabIndex = 29;
            // 
            // CollectibleCollectionEffectLabel
            // 
            this.CollectibleCollectionEffectLabel.AutoSize = true;
            this.CollectibleCollectionEffectLabel.Location = new System.Drawing.Point(3, 160);
            this.CollectibleCollectionEffectLabel.Name = "CollectibleCollectionEffectLabel";
            this.CollectibleCollectionEffectLabel.Size = new System.Drawing.Size(85, 13);
            this.CollectibleCollectionEffectLabel.TabIndex = 30;
            this.CollectibleCollectionEffectLabel.Text = "Collection Effect";
            // 
            // CollectibleEffectAmountLabel
            // 
            this.CollectibleEffectAmountLabel.AutoSize = true;
            this.CollectibleEffectAmountLabel.Location = new System.Drawing.Point(3, 185);
            this.CollectibleEffectAmountLabel.Name = "CollectibleEffectAmountLabel";
            this.CollectibleEffectAmountLabel.Size = new System.Drawing.Size(76, 13);
            this.CollectibleEffectAmountLabel.TabIndex = 31;
            this.CollectibleEffectAmountLabel.Text = "Effect Amount";
            // 
            // CollectibleRemoveCollectibleButton
            // 
            this.CollectibleRemoveCollectibleButton.Location = new System.Drawing.Point(24, 468);
            this.CollectibleRemoveCollectibleButton.Name = "CollectibleRemoveCollectibleButton";
            this.CollectibleRemoveCollectibleButton.Size = new System.Drawing.Size(129, 23);
            this.CollectibleRemoveCollectibleButton.TabIndex = 2;
            this.CollectibleRemoveCollectibleButton.Text = "Remove Collectible";
            this.CollectibleRemoveCollectibleButton.UseVisualStyleBackColor = true;
            // 
            // CollectibleConfigGroupBox
            // 
            this.CollectibleConfigGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CollectibleConfigGroupBox.Location = new System.Drawing.Point(9, 497);
            this.CollectibleConfigGroupBox.Name = "CollectibleConfigGroupBox";
            this.CollectibleConfigGroupBox.Size = new System.Drawing.Size(938, 96);
            this.CollectibleConfigGroupBox.TabIndex = 0;
            this.CollectibleConfigGroupBox.TabStop = false;
            // 
            // CollectibleIDTextBox
            // 
            this.CollectibleIDTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CollectibleIDTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.CollectibleIDTextBox.Location = new System.Drawing.Point(812, 16);
            this.CollectibleIDTextBox.Name = "CollectibleIDTextBox";
            this.CollectibleIDTextBox.Size = new System.Drawing.Size(131, 20);
            this.CollectibleIDTextBox.TabIndex = 3;
            this.CollectibleIDTextBox.Text = "-2020202020";
            // 
            // CollectibleAddNewCollectibleButton
            // 
            this.CollectibleAddNewCollectibleButton.Location = new System.Drawing.Point(159, 468);
            this.CollectibleAddNewCollectibleButton.Name = "CollectibleAddNewCollectibleButton";
            this.CollectibleAddNewCollectibleButton.Size = new System.Drawing.Size(129, 23);
            this.CollectibleAddNewCollectibleButton.TabIndex = 2;
            this.CollectibleAddNewCollectibleButton.Text = "Add New Collectible";
            this.CollectibleAddNewCollectibleButton.UseVisualStyleBackColor = true;
            // 
            // CollectibleListBox
            // 
            this.CollectibleListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CollectibleListBox.DisplayMember = "Name";
            this.CollectibleListBox.FormattingEnabled = true;
            this.CollectibleListBox.Location = new System.Drawing.Point(9, 16);
            this.CollectibleListBox.Name = "CollectibleListBox";
            this.CollectibleListBox.Size = new System.Drawing.Size(279, 446);
            this.CollectibleListBox.TabIndex = 1;
            // 
            // CollectibleIDLabel
            // 
            this.CollectibleIDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CollectibleIDLabel.AutoSize = true;
            this.CollectibleIDLabel.Location = new System.Drawing.Point(742, 19);
            this.CollectibleIDLabel.Name = "CollectibleIDLabel";
            this.CollectibleIDLabel.Size = new System.Drawing.Size(69, 13);
            this.CollectibleIDLabel.TabIndex = 4;
            this.CollectibleIDLabel.Text = "Collectible ID";
            // 
            // CollectibleEditImageButton
            // 
            this.CollectibleEditImageButton.Location = new System.Drawing.Point(815, 468);
            this.CollectibleEditImageButton.Name = "CollectibleEditImageButton";
            this.CollectibleEditImageButton.Size = new System.Drawing.Size(128, 23);
            this.CollectibleEditImageButton.TabIndex = 7;
            this.CollectibleEditImageButton.Text = "Edit Image";
            this.CollectibleEditImageButton.UseVisualStyleBackColor = true;
            this.CollectibleEditImageButton.Click += new System.EventHandler(this.CollectibleEditImageButton_Click);
            // 
            // CollectiblePictureBox
            // 
            this.CollectiblePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CollectiblePictureBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.CollectiblePictureBox.Location = new System.Drawing.Point(767, 286);
            this.CollectiblePictureBox.Name = "CollectiblePictureBox";
            this.CollectiblePictureBox.Size = new System.Drawing.Size(176, 176);
            this.CollectiblePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CollectiblePictureBox.TabIndex = 6;
            this.CollectiblePictureBox.TabStop = false;
            // 
            // CharactersTabPage
            // 
            this.CharactersTabPage.Controls.Add(this.CharacterPronounGroupBox);
            this.CharactersTabPage.Controls.Add(this.CharacterTableLayoutPanel);
            this.CharactersTabPage.Controls.Add(this.CharacterRemoveCharacterButton);
            this.CharactersTabPage.Controls.Add(this.CharacterIDTextBox);
            this.CharactersTabPage.Controls.Add(this.CharacterAddNewCharacterButton);
            this.CharactersTabPage.Controls.Add(this.CharacterListBox);
            this.CharactersTabPage.Controls.Add(this.CharacterIDLabel);
            this.CharactersTabPage.Controls.Add(this.CharacterEditImageButton);
            this.CharactersTabPage.Controls.Add(this.CharacterPictureBox);
            this.CharactersTabPage.Location = new System.Drawing.Point(4, 22);
            this.CharactersTabPage.Name = "CharactersTabPage";
            this.CharactersTabPage.Size = new System.Drawing.Size(953, 599);
            this.CharactersTabPage.TabIndex = 12;
            this.CharactersTabPage.Text = "Characters";
            // 
            // CharacterPronounGroupBox
            // 
            this.CharacterPronounGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CharacterPronounGroupBox.Controls.Add(this.CharacterPronounTableLayoutPanel);
            this.CharacterPronounGroupBox.Location = new System.Drawing.Point(6, 497);
            this.CharacterPronounGroupBox.Name = "CharacterPronounGroupBox";
            this.CharacterPronounGroupBox.Size = new System.Drawing.Size(938, 96);
            this.CharacterPronounGroupBox.TabIndex = 0;
            this.CharacterPronounGroupBox.TabStop = false;
            this.CharacterPronounGroupBox.Text = "Pronouns";
            // 
            // CharacterPronounTableLayoutPanel
            // 
            this.CharacterPronounTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CharacterPronounTableLayoutPanel.ColumnCount = 6;
            this.CharacterPronounTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CharacterPronounTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.CharacterPronounTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.CharacterPronounTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.CharacterPronounTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.CharacterPronounTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.CharacterPronounTableLayoutPanel.Controls.Add(this.CharacterPronounAddNewPronoungGroupButton, 2, 2);
            this.CharacterPronounTableLayoutPanel.Controls.Add(this.CharacterPronounRemovePronoungGroupButton, 1, 2);
            this.CharacterPronounTableLayoutPanel.Controls.Add(this.CharacterPronounReflexiveTextBox, 5, 1);
            this.CharacterPronounTableLayoutPanel.Controls.Add(this.CharacterPronounPossessiveTextBox, 4, 1);
            this.CharacterPronounTableLayoutPanel.Controls.Add(this.CharacterPronounDeterminerTextBox, 3, 1);
            this.CharacterPronounTableLayoutPanel.Controls.Add(this.CharacterPronounObjectiveTextBox, 2, 1);
            this.CharacterPronounTableLayoutPanel.Controls.Add(this.CharacterPronounSubjectiveTextBox, 1, 1);
            this.CharacterPronounTableLayoutPanel.Controls.Add(this.CharacterPronounListBox, 0, 0);
            this.CharacterPronounTableLayoutPanel.Controls.Add(this.CharacterPronounSubjectiveLabel, 1, 0);
            this.CharacterPronounTableLayoutPanel.Controls.Add(this.CharacterPronounObjectiveLabel, 2, 0);
            this.CharacterPronounTableLayoutPanel.Controls.Add(this.CharacterPronounDeterminerLabel, 3, 0);
            this.CharacterPronounTableLayoutPanel.Controls.Add(this.CharacterPronounPossessiveLabel, 4, 0);
            this.CharacterPronounTableLayoutPanel.Controls.Add(this.CharacterPronounReflexiveLabel, 5, 0);
            this.CharacterPronounTableLayoutPanel.Controls.Add(this.CharacterPronounKeyLabel, 4, 2);
            this.CharacterPronounTableLayoutPanel.Controls.Add(this.CharacterPronounKeyExample, 5, 2);
            this.CharacterPronounTableLayoutPanel.Location = new System.Drawing.Point(6, 19);
            this.CharacterPronounTableLayoutPanel.Name = "CharacterPronounTableLayoutPanel";
            this.CharacterPronounTableLayoutPanel.RowCount = 3;
            this.CharacterPronounTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CharacterPronounTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.CharacterPronounTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.CharacterPronounTableLayoutPanel.Size = new System.Drawing.Size(926, 71);
            this.CharacterPronounTableLayoutPanel.TabIndex = 0;
            // 
            // CharacterPronounAddNewPronoungGroupButton
            // 
            this.CharacterPronounAddNewPronoungGroupButton.Location = new System.Drawing.Point(409, 44);
            this.CharacterPronounAddNewPronoungGroupButton.Name = "CharacterPronounAddNewPronoungGroupButton";
            this.CharacterPronounAddNewPronoungGroupButton.Size = new System.Drawing.Size(124, 23);
            this.CharacterPronounAddNewPronoungGroupButton.TabIndex = 2;
            this.CharacterPronounAddNewPronoungGroupButton.Text = "Add New Group";
            this.CharacterPronounAddNewPronoungGroupButton.UseVisualStyleBackColor = true;
            // 
            // CharacterPronounRemovePronoungGroupButton
            // 
            this.CharacterPronounRemovePronoungGroupButton.Location = new System.Drawing.Point(279, 44);
            this.CharacterPronounRemovePronoungGroupButton.Name = "CharacterPronounRemovePronoungGroupButton";
            this.CharacterPronounRemovePronoungGroupButton.Size = new System.Drawing.Size(124, 23);
            this.CharacterPronounRemovePronoungGroupButton.TabIndex = 2;
            this.CharacterPronounRemovePronoungGroupButton.Text = "Remove Group";
            this.CharacterPronounRemovePronoungGroupButton.UseVisualStyleBackColor = true;
            // 
            // CharacterPronounReflexiveTextBox
            // 
            this.CharacterPronounReflexiveTextBox.Location = new System.Drawing.Point(799, 19);
            this.CharacterPronounReflexiveTextBox.Name = "CharacterPronounReflexiveTextBox";
            this.CharacterPronounReflexiveTextBox.Size = new System.Drawing.Size(124, 20);
            this.CharacterPronounReflexiveTextBox.TabIndex = 23;
            // 
            // CharacterPronounPossessiveTextBox
            // 
            this.CharacterPronounPossessiveTextBox.Location = new System.Drawing.Point(669, 19);
            this.CharacterPronounPossessiveTextBox.Name = "CharacterPronounPossessiveTextBox";
            this.CharacterPronounPossessiveTextBox.Size = new System.Drawing.Size(124, 20);
            this.CharacterPronounPossessiveTextBox.TabIndex = 23;
            // 
            // CharacterPronounDeterminerTextBox
            // 
            this.CharacterPronounDeterminerTextBox.Location = new System.Drawing.Point(539, 19);
            this.CharacterPronounDeterminerTextBox.Name = "CharacterPronounDeterminerTextBox";
            this.CharacterPronounDeterminerTextBox.Size = new System.Drawing.Size(124, 20);
            this.CharacterPronounDeterminerTextBox.TabIndex = 23;
            // 
            // CharacterPronounObjectiveTextBox
            // 
            this.CharacterPronounObjectiveTextBox.Location = new System.Drawing.Point(409, 19);
            this.CharacterPronounObjectiveTextBox.Name = "CharacterPronounObjectiveTextBox";
            this.CharacterPronounObjectiveTextBox.Size = new System.Drawing.Size(124, 20);
            this.CharacterPronounObjectiveTextBox.TabIndex = 23;
            // 
            // CharacterPronounSubjectiveTextBox
            // 
            this.CharacterPronounSubjectiveTextBox.Location = new System.Drawing.Point(279, 19);
            this.CharacterPronounSubjectiveTextBox.Name = "CharacterPronounSubjectiveTextBox";
            this.CharacterPronounSubjectiveTextBox.Size = new System.Drawing.Size(124, 20);
            this.CharacterPronounSubjectiveTextBox.TabIndex = 23;
            // 
            // CharacterPronounListBox
            // 
            this.CharacterPronounListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CharacterPronounListBox.FormattingEnabled = true;
            this.CharacterPronounListBox.Location = new System.Drawing.Point(0, 0);
            this.CharacterPronounListBox.Margin = new System.Windows.Forms.Padding(0);
            this.CharacterPronounListBox.Name = "CharacterPronounListBox";
            this.CharacterPronounTableLayoutPanel.SetRowSpan(this.CharacterPronounListBox, 3);
            this.CharacterPronounListBox.Size = new System.Drawing.Size(276, 69);
            this.CharacterPronounListBox.TabIndex = 0;
            // 
            // CharacterPronounSubjectiveLabel
            // 
            this.CharacterPronounSubjectiveLabel.AutoSize = true;
            this.CharacterPronounSubjectiveLabel.Location = new System.Drawing.Point(279, 0);
            this.CharacterPronounSubjectiveLabel.Name = "CharacterPronounSubjectiveLabel";
            this.CharacterPronounSubjectiveLabel.Size = new System.Drawing.Size(57, 13);
            this.CharacterPronounSubjectiveLabel.TabIndex = 1;
            this.CharacterPronounSubjectiveLabel.Text = "Subjective";
            // 
            // CharacterPronounObjectiveLabel
            // 
            this.CharacterPronounObjectiveLabel.AutoSize = true;
            this.CharacterPronounObjectiveLabel.Location = new System.Drawing.Point(409, 0);
            this.CharacterPronounObjectiveLabel.Name = "CharacterPronounObjectiveLabel";
            this.CharacterPronounObjectiveLabel.Size = new System.Drawing.Size(53, 13);
            this.CharacterPronounObjectiveLabel.TabIndex = 2;
            this.CharacterPronounObjectiveLabel.Text = "Objective";
            // 
            // CharacterPronounDeterminerLabel
            // 
            this.CharacterPronounDeterminerLabel.AutoSize = true;
            this.CharacterPronounDeterminerLabel.Location = new System.Drawing.Point(539, 0);
            this.CharacterPronounDeterminerLabel.Name = "CharacterPronounDeterminerLabel";
            this.CharacterPronounDeterminerLabel.Size = new System.Drawing.Size(60, 13);
            this.CharacterPronounDeterminerLabel.TabIndex = 3;
            this.CharacterPronounDeterminerLabel.Text = "Determiner";
            // 
            // CharacterPronounPossessiveLabel
            // 
            this.CharacterPronounPossessiveLabel.AutoSize = true;
            this.CharacterPronounPossessiveLabel.Location = new System.Drawing.Point(669, 0);
            this.CharacterPronounPossessiveLabel.Name = "CharacterPronounPossessiveLabel";
            this.CharacterPronounPossessiveLabel.Size = new System.Drawing.Size(59, 13);
            this.CharacterPronounPossessiveLabel.TabIndex = 4;
            this.CharacterPronounPossessiveLabel.Text = "Possessive";
            // 
            // CharacterPronounReflexiveLabel
            // 
            this.CharacterPronounReflexiveLabel.AutoSize = true;
            this.CharacterPronounReflexiveLabel.Location = new System.Drawing.Point(799, 0);
            this.CharacterPronounReflexiveLabel.Name = "CharacterPronounReflexiveLabel";
            this.CharacterPronounReflexiveLabel.Size = new System.Drawing.Size(52, 13);
            this.CharacterPronounReflexiveLabel.TabIndex = 5;
            this.CharacterPronounReflexiveLabel.Text = "Reflexive";
            // 
            // CharacterPronounKeyLabel
            // 
            this.CharacterPronounKeyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CharacterPronounKeyLabel.AutoSize = true;
            this.CharacterPronounKeyLabel.Location = new System.Drawing.Point(764, 58);
            this.CharacterPronounKeyLabel.Name = "CharacterPronounKeyLabel";
            this.CharacterPronounKeyLabel.Size = new System.Drawing.Size(29, 13);
            this.CharacterPronounKeyLabel.TabIndex = 24;
            this.CharacterPronounKeyLabel.Text = "Key:";
            // 
            // CharacterPronounKeyExample
            // 
            this.CharacterPronounKeyExample.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CharacterPronounKeyExample.AutoSize = true;
            this.CharacterPronounKeyExample.Location = new System.Drawing.Point(799, 58);
            this.CharacterPronounKeyExample.Name = "CharacterPronounKeyExample";
            this.CharacterPronounKeyExample.Size = new System.Drawing.Size(57, 13);
            this.CharacterPronounKeyExample.TabIndex = 25;
            this.CharacterPronounKeyExample.Text = "they/them";
            // 
            // CharacterTableLayoutPanel
            // 
            this.CharacterTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CharacterTableLayoutPanel.ColumnCount = 3;
            this.CharacterTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.CharacterTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.CharacterTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.CharacterTableLayoutPanel.Controls.Add(this.CharacterAddQuestButton, 2, 10);
            this.CharacterTableLayoutPanel.Controls.Add(this.CharacterRemoveQuestButton, 1, 10);
            this.CharacterTableLayoutPanel.Controls.Add(this.CharacterStartingQuestsListBox, 1, 9);
            this.CharacterTableLayoutPanel.Controls.Add(this.CharacterStoryIDTextBox, 1, 8);
            this.CharacterTableLayoutPanel.Controls.Add(this.CharacterOpenInventoryEditorButton, 2, 12);
            this.CharacterTableLayoutPanel.Controls.Add(this.comboBox1, 1, 4);
            this.CharacterTableLayoutPanel.Controls.Add(this.CharacterNameLabel, 0, 0);
            this.CharacterTableLayoutPanel.Controls.Add(this.CharacterDescriptionLabel, 0, 1);
            this.CharacterTableLayoutPanel.Controls.Add(this.CharacterCommentLabel, 0, 2);
            this.CharacterTableLayoutPanel.Controls.Add(this.CharacterNativeBiomeLabel, 0, 3);
            this.CharacterTableLayoutPanel.Controls.Add(this.CharacterNameTextBox, 1, 0);
            this.CharacterTableLayoutPanel.Controls.Add(this.CharacterDescriptionTextBox, 1, 1);
            this.CharacterTableLayoutPanel.Controls.Add(this.CharacterCommentTextBox, 1, 2);
            this.CharacterTableLayoutPanel.Controls.Add(this.CharacterNativeBiomeComboBox, 1, 3);
            this.CharacterTableLayoutPanel.Controls.Add(this.CharacterPrimaryBehaviorLabel, 0, 4);
            this.CharacterTableLayoutPanel.Controls.Add(this.CharacterParquetsAvoidedLabel, 0, 5);
            this.CharacterTableLayoutPanel.Controls.Add(this.CharacterComingSoonLabel1, 1, 5);
            this.CharacterTableLayoutPanel.Controls.Add(this.CharacterParquetsSoughtLabel, 0, 6);
            this.CharacterTableLayoutPanel.Controls.Add(this.CharacterComingSoonLabel, 1, 6);
            this.CharacterTableLayoutPanel.Controls.Add(this.CharacterPronounLabel, 0, 7);
            this.CharacterTableLayoutPanel.Controls.Add(this.CharacterStoryIDLabel, 0, 8);
            this.CharacterTableLayoutPanel.Controls.Add(this.CharacterStartingQuestsLabel, 0, 9);
            this.CharacterTableLayoutPanel.Controls.Add(this.CharacterStartingDialogueLabel, 0, 11);
            this.CharacterTableLayoutPanel.Controls.Add(this.CharacterStartingInventoryLabel, 0, 12);
            this.CharacterTableLayoutPanel.Controls.Add(this.CharacterPronounComboBox, 1, 7);
            this.CharacterTableLayoutPanel.Controls.Add(this.CharacterStartingDialogueComboBox, 1, 11);
            this.CharacterTableLayoutPanel.Controls.Add(this.StartingInventoryComboBox, 1, 12);
            this.CharacterTableLayoutPanel.Location = new System.Drawing.Point(307, 16);
            this.CharacterTableLayoutPanel.Name = "CharacterTableLayoutPanel";
            this.CharacterTableLayoutPanel.RowCount = 13;
            this.CharacterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.CharacterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.CharacterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.CharacterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.CharacterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.CharacterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.CharacterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.CharacterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.CharacterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.CharacterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CharacterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.CharacterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.CharacterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.CharacterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.CharacterTableLayoutPanel.Size = new System.Drawing.Size(429, 446);
            this.CharacterTableLayoutPanel.TabIndex = 5;
            // 
            // CharacterAddQuestButton
            // 
            this.CharacterAddQuestButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CharacterAddQuestButton.Location = new System.Drawing.Point(297, 364);
            this.CharacterAddQuestButton.Name = "CharacterAddQuestButton";
            this.CharacterAddQuestButton.Size = new System.Drawing.Size(129, 23);
            this.CharacterAddQuestButton.TabIndex = 29;
            this.CharacterAddQuestButton.Text = "Add Quest";
            this.CharacterAddQuestButton.UseVisualStyleBackColor = true;
            // 
            // CharacterRemoveQuestButton
            // 
            this.CharacterRemoveQuestButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CharacterRemoveQuestButton.Location = new System.Drawing.Point(146, 364);
            this.CharacterRemoveQuestButton.Name = "CharacterRemoveQuestButton";
            this.CharacterRemoveQuestButton.Size = new System.Drawing.Size(129, 23);
            this.CharacterRemoveQuestButton.TabIndex = 29;
            this.CharacterRemoveQuestButton.Text = "Remove Quest";
            this.CharacterRemoveQuestButton.UseVisualStyleBackColor = true;
            // 
            // CharacterStartingQuestsListBox
            // 
            this.CharacterStartingQuestsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CharacterTableLayoutPanel.SetColumnSpan(this.CharacterStartingQuestsListBox, 2);
            this.CharacterStartingQuestsListBox.FormattingEnabled = true;
            this.CharacterStartingQuestsListBox.Location = new System.Drawing.Point(131, 288);
            this.CharacterStartingQuestsListBox.Name = "CharacterStartingQuestsListBox";
            this.CharacterStartingQuestsListBox.Size = new System.Drawing.Size(295, 69);
            this.CharacterStartingQuestsListBox.TabIndex = 1;
            // 
            // CharacterStoryIDTextBox
            // 
            this.CharacterStoryIDTextBox.Location = new System.Drawing.Point(131, 263);
            this.CharacterStoryIDTextBox.Name = "CharacterStoryIDTextBox";
            this.CharacterStoryIDTextBox.Size = new System.Drawing.Size(144, 20);
            this.CharacterStoryIDTextBox.TabIndex = 23;
            // 
            // CharacterOpenInventoryEditorButton
            // 
            this.CharacterOpenInventoryEditorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CharacterOpenInventoryEditorButton.Location = new System.Drawing.Point(297, 419);
            this.CharacterOpenInventoryEditorButton.Name = "CharacterOpenInventoryEditorButton";
            this.CharacterOpenInventoryEditorButton.Size = new System.Drawing.Size(129, 23);
            this.CharacterOpenInventoryEditorButton.TabIndex = 3;
            this.CharacterOpenInventoryEditorButton.Text = "Open Inventory Editor";
            this.CharacterOpenInventoryEditorButton.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(131, 163);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(144, 21);
            this.comboBox1.TabIndex = 29;
            // 
            // CharacterNameLabel
            // 
            this.CharacterNameLabel.AutoSize = true;
            this.CharacterNameLabel.Location = new System.Drawing.Point(3, 0);
            this.CharacterNameLabel.Name = "CharacterNameLabel";
            this.CharacterNameLabel.Size = new System.Drawing.Size(34, 13);
            this.CharacterNameLabel.TabIndex = 0;
            this.CharacterNameLabel.Text = "Name";
            // 
            // CharacterDescriptionLabel
            // 
            this.CharacterDescriptionLabel.AutoSize = true;
            this.CharacterDescriptionLabel.Location = new System.Drawing.Point(3, 25);
            this.CharacterDescriptionLabel.Name = "CharacterDescriptionLabel";
            this.CharacterDescriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.CharacterDescriptionLabel.TabIndex = 3;
            this.CharacterDescriptionLabel.Text = "Description";
            // 
            // CharacterCommentLabel
            // 
            this.CharacterCommentLabel.AutoSize = true;
            this.CharacterCommentLabel.Location = new System.Drawing.Point(3, 80);
            this.CharacterCommentLabel.Name = "CharacterCommentLabel";
            this.CharacterCommentLabel.Size = new System.Drawing.Size(52, 13);
            this.CharacterCommentLabel.TabIndex = 6;
            this.CharacterCommentLabel.Text = "Comment";
            // 
            // CharacterNativeBiomeLabel
            // 
            this.CharacterNativeBiomeLabel.AutoSize = true;
            this.CharacterNativeBiomeLabel.Location = new System.Drawing.Point(3, 135);
            this.CharacterNativeBiomeLabel.Name = "CharacterNativeBiomeLabel";
            this.CharacterNativeBiomeLabel.Size = new System.Drawing.Size(69, 13);
            this.CharacterNativeBiomeLabel.TabIndex = 9;
            this.CharacterNativeBiomeLabel.Text = "Native Biome";
            // 
            // CharacterNameTextBox
            // 
            this.CharacterNameTextBox.Location = new System.Drawing.Point(131, 3);
            this.CharacterNameTextBox.Name = "CharacterNameTextBox";
            this.CharacterNameTextBox.Size = new System.Drawing.Size(144, 20);
            this.CharacterNameTextBox.TabIndex = 23;
            // 
            // CharacterDescriptionTextBox
            // 
            this.CharacterDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CharacterTableLayoutPanel.SetColumnSpan(this.CharacterDescriptionTextBox, 2);
            this.CharacterDescriptionTextBox.Location = new System.Drawing.Point(131, 28);
            this.CharacterDescriptionTextBox.Multiline = true;
            this.CharacterDescriptionTextBox.Name = "CharacterDescriptionTextBox";
            this.CharacterDescriptionTextBox.Size = new System.Drawing.Size(295, 49);
            this.CharacterDescriptionTextBox.TabIndex = 24;
            // 
            // CharacterCommentTextBox
            // 
            this.CharacterCommentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CharacterTableLayoutPanel.SetColumnSpan(this.CharacterCommentTextBox, 2);
            this.CharacterCommentTextBox.Location = new System.Drawing.Point(131, 83);
            this.CharacterCommentTextBox.Multiline = true;
            this.CharacterCommentTextBox.Name = "CharacterCommentTextBox";
            this.CharacterCommentTextBox.Size = new System.Drawing.Size(295, 49);
            this.CharacterCommentTextBox.TabIndex = 25;
            // 
            // CharacterNativeBiomeComboBox
            // 
            this.CharacterNativeBiomeComboBox.FormattingEnabled = true;
            this.CharacterNativeBiomeComboBox.Location = new System.Drawing.Point(131, 138);
            this.CharacterNativeBiomeComboBox.Name = "CharacterNativeBiomeComboBox";
            this.CharacterNativeBiomeComboBox.Size = new System.Drawing.Size(144, 21);
            this.CharacterNativeBiomeComboBox.TabIndex = 29;
            // 
            // CharacterPrimaryBehaviorLabel
            // 
            this.CharacterPrimaryBehaviorLabel.AutoSize = true;
            this.CharacterPrimaryBehaviorLabel.Location = new System.Drawing.Point(3, 160);
            this.CharacterPrimaryBehaviorLabel.Name = "CharacterPrimaryBehaviorLabel";
            this.CharacterPrimaryBehaviorLabel.Size = new System.Drawing.Size(88, 13);
            this.CharacterPrimaryBehaviorLabel.TabIndex = 30;
            this.CharacterPrimaryBehaviorLabel.Text = "Primary Behavior";
            // 
            // CharacterParquetsAvoidedLabel
            // 
            this.CharacterParquetsAvoidedLabel.AutoSize = true;
            this.CharacterParquetsAvoidedLabel.Location = new System.Drawing.Point(3, 185);
            this.CharacterParquetsAvoidedLabel.Name = "CharacterParquetsAvoidedLabel";
            this.CharacterParquetsAvoidedLabel.Size = new System.Drawing.Size(92, 13);
            this.CharacterParquetsAvoidedLabel.TabIndex = 31;
            this.CharacterParquetsAvoidedLabel.Text = "Parquets Avoided";
            // 
            // CharacterComingSoonLabel1
            // 
            this.CharacterComingSoonLabel1.AutoSize = true;
            this.CharacterComingSoonLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CharacterComingSoonLabel1.Location = new System.Drawing.Point(131, 185);
            this.CharacterComingSoonLabel1.Name = "CharacterComingSoonLabel1";
            this.CharacterComingSoonLabel1.Size = new System.Drawing.Size(89, 16);
            this.CharacterComingSoonLabel1.TabIndex = 32;
            this.CharacterComingSoonLabel1.Text = "Coming Soon";
            // 
            // CharacterParquetsSoughtLabel
            // 
            this.CharacterParquetsSoughtLabel.AutoSize = true;
            this.CharacterParquetsSoughtLabel.Location = new System.Drawing.Point(3, 210);
            this.CharacterParquetsSoughtLabel.Name = "CharacterParquetsSoughtLabel";
            this.CharacterParquetsSoughtLabel.Size = new System.Drawing.Size(87, 13);
            this.CharacterParquetsSoughtLabel.TabIndex = 33;
            this.CharacterParquetsSoughtLabel.Text = "Parquets Sought";
            // 
            // CharacterComingSoonLabel
            // 
            this.CharacterComingSoonLabel.AutoSize = true;
            this.CharacterComingSoonLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CharacterComingSoonLabel.Location = new System.Drawing.Point(131, 210);
            this.CharacterComingSoonLabel.Name = "CharacterComingSoonLabel";
            this.CharacterComingSoonLabel.Size = new System.Drawing.Size(89, 16);
            this.CharacterComingSoonLabel.TabIndex = 34;
            this.CharacterComingSoonLabel.Text = "Coming Soon";
            // 
            // CharacterPronounLabel
            // 
            this.CharacterPronounLabel.AutoSize = true;
            this.CharacterPronounLabel.Location = new System.Drawing.Point(3, 235);
            this.CharacterPronounLabel.Name = "CharacterPronounLabel";
            this.CharacterPronounLabel.Size = new System.Drawing.Size(52, 13);
            this.CharacterPronounLabel.TabIndex = 35;
            this.CharacterPronounLabel.Text = "Pronouns";
            // 
            // CharacterStoryIDLabel
            // 
            this.CharacterStoryIDLabel.AutoSize = true;
            this.CharacterStoryIDLabel.Location = new System.Drawing.Point(3, 260);
            this.CharacterStoryIDLabel.Name = "CharacterStoryIDLabel";
            this.CharacterStoryIDLabel.Size = new System.Drawing.Size(47, 13);
            this.CharacterStoryIDLabel.TabIndex = 36;
            this.CharacterStoryIDLabel.Text = "Story ID";
            // 
            // CharacterStartingQuestsLabel
            // 
            this.CharacterStartingQuestsLabel.AutoSize = true;
            this.CharacterStartingQuestsLabel.Location = new System.Drawing.Point(3, 285);
            this.CharacterStartingQuestsLabel.Name = "CharacterStartingQuestsLabel";
            this.CharacterStartingQuestsLabel.Size = new System.Drawing.Size(82, 13);
            this.CharacterStartingQuestsLabel.TabIndex = 37;
            this.CharacterStartingQuestsLabel.Text = "Starting Quests";
            // 
            // CharacterStartingDialogueLabel
            // 
            this.CharacterStartingDialogueLabel.AutoSize = true;
            this.CharacterStartingDialogueLabel.Location = new System.Drawing.Point(3, 391);
            this.CharacterStartingDialogueLabel.Name = "CharacterStartingDialogueLabel";
            this.CharacterStartingDialogueLabel.Size = new System.Drawing.Size(89, 13);
            this.CharacterStartingDialogueLabel.TabIndex = 38;
            this.CharacterStartingDialogueLabel.Text = "Starting Dialogue";
            // 
            // CharacterStartingInventoryLabel
            // 
            this.CharacterStartingInventoryLabel.AutoSize = true;
            this.CharacterStartingInventoryLabel.Location = new System.Drawing.Point(3, 416);
            this.CharacterStartingInventoryLabel.Name = "CharacterStartingInventoryLabel";
            this.CharacterStartingInventoryLabel.Size = new System.Drawing.Size(96, 13);
            this.CharacterStartingInventoryLabel.TabIndex = 39;
            this.CharacterStartingInventoryLabel.Text = "Starting Inventory";
            // 
            // CharacterPronounComboBox
            // 
            this.CharacterPronounComboBox.FormattingEnabled = true;
            this.CharacterPronounComboBox.Location = new System.Drawing.Point(131, 238);
            this.CharacterPronounComboBox.Name = "CharacterPronounComboBox";
            this.CharacterPronounComboBox.Size = new System.Drawing.Size(144, 21);
            this.CharacterPronounComboBox.TabIndex = 40;
            // 
            // CharacterStartingDialogueComboBox
            // 
            this.CharacterStartingDialogueComboBox.FormattingEnabled = true;
            this.CharacterStartingDialogueComboBox.Location = new System.Drawing.Point(131, 394);
            this.CharacterStartingDialogueComboBox.Name = "CharacterStartingDialogueComboBox";
            this.CharacterStartingDialogueComboBox.Size = new System.Drawing.Size(144, 21);
            this.CharacterStartingDialogueComboBox.TabIndex = 42;
            // 
            // StartingInventoryComboBox
            // 
            this.StartingInventoryComboBox.FormattingEnabled = true;
            this.StartingInventoryComboBox.Location = new System.Drawing.Point(131, 419);
            this.StartingInventoryComboBox.Name = "StartingInventoryComboBox";
            this.StartingInventoryComboBox.Size = new System.Drawing.Size(144, 21);
            this.StartingInventoryComboBox.TabIndex = 43;
            // 
            // CharacterRemoveCharacterButton
            // 
            this.CharacterRemoveCharacterButton.Location = new System.Drawing.Point(24, 468);
            this.CharacterRemoveCharacterButton.Name = "CharacterRemoveCharacterButton";
            this.CharacterRemoveCharacterButton.Size = new System.Drawing.Size(129, 23);
            this.CharacterRemoveCharacterButton.TabIndex = 2;
            this.CharacterRemoveCharacterButton.Text = "Remove Character";
            this.CharacterRemoveCharacterButton.UseVisualStyleBackColor = true;
            // 
            // CharacterIDTextBox
            // 
            this.CharacterIDTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CharacterIDTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.CharacterIDTextBox.Location = new System.Drawing.Point(812, 16);
            this.CharacterIDTextBox.Name = "CharacterIDTextBox";
            this.CharacterIDTextBox.Size = new System.Drawing.Size(131, 20);
            this.CharacterIDTextBox.TabIndex = 3;
            this.CharacterIDTextBox.Text = "-2020202020";
            // 
            // CharacterAddNewCharacterButton
            // 
            this.CharacterAddNewCharacterButton.Location = new System.Drawing.Point(159, 468);
            this.CharacterAddNewCharacterButton.Name = "CharacterAddNewCharacterButton";
            this.CharacterAddNewCharacterButton.Size = new System.Drawing.Size(129, 23);
            this.CharacterAddNewCharacterButton.TabIndex = 2;
            this.CharacterAddNewCharacterButton.Text = "Add New Character";
            this.CharacterAddNewCharacterButton.UseVisualStyleBackColor = true;
            // 
            // CharacterListBox
            // 
            this.CharacterListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CharacterListBox.DisplayMember = "Name";
            this.CharacterListBox.FormattingEnabled = true;
            this.CharacterListBox.Location = new System.Drawing.Point(9, 16);
            this.CharacterListBox.Name = "CharacterListBox";
            this.CharacterListBox.Size = new System.Drawing.Size(279, 446);
            this.CharacterListBox.TabIndex = 1;
            // 
            // CharacterIDLabel
            // 
            this.CharacterIDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CharacterIDLabel.AutoSize = true;
            this.CharacterIDLabel.Location = new System.Drawing.Point(742, 19);
            this.CharacterIDLabel.Name = "CharacterIDLabel";
            this.CharacterIDLabel.Size = new System.Drawing.Size(69, 13);
            this.CharacterIDLabel.TabIndex = 4;
            this.CharacterIDLabel.Text = "Character ID";
            // 
            // CharacterEditImageButton
            // 
            this.CharacterEditImageButton.Location = new System.Drawing.Point(815, 468);
            this.CharacterEditImageButton.Name = "CharacterEditImageButton";
            this.CharacterEditImageButton.Size = new System.Drawing.Size(128, 23);
            this.CharacterEditImageButton.TabIndex = 7;
            this.CharacterEditImageButton.Text = "Edit Image";
            this.CharacterEditImageButton.UseVisualStyleBackColor = true;
            this.CharacterEditImageButton.Click += new System.EventHandler(this.CharacterEditImageButton_Click);
            // 
            // CharacterPictureBox
            // 
            this.CharacterPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CharacterPictureBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.CharacterPictureBox.Location = new System.Drawing.Point(767, 286);
            this.CharacterPictureBox.Name = "CharacterPictureBox";
            this.CharacterPictureBox.Size = new System.Drawing.Size(176, 176);
            this.CharacterPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CharacterPictureBox.TabIndex = 6;
            this.CharacterPictureBox.TabStop = false;
            // 
            // CrittersTabPage
            // 
            this.CrittersTabPage.Controls.Add(this.CritterTableLayoutPanel);
            this.CrittersTabPage.Controls.Add(this.CritterPictureBox);
            this.CrittersTabPage.Controls.Add(this.CritterEditImageButton);
            this.CrittersTabPage.Controls.Add(this.CritterIDLabel);
            this.CrittersTabPage.Controls.Add(this.CritterListBox);
            this.CrittersTabPage.Controls.Add(this.CritterAddNewCritterButton);
            this.CrittersTabPage.Controls.Add(this.CritterIDTextBox);
            this.CrittersTabPage.Controls.Add(this.CritterConfigGroupBox);
            this.CrittersTabPage.Controls.Add(this.CritterRemoveCritterButton);
            this.CrittersTabPage.Location = new System.Drawing.Point(4, 22);
            this.CrittersTabPage.Name = "CrittersTabPage";
            this.CrittersTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.CrittersTabPage.Size = new System.Drawing.Size(953, 599);
            this.CrittersTabPage.TabIndex = 1;
            this.CrittersTabPage.Text = "Critters";
            // 
            // CritterTableLayoutPanel
            // 
            this.CritterTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CritterTableLayoutPanel.ColumnCount = 3;
            this.CritterTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.CritterTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.CritterTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.CritterTableLayoutPanel.Controls.Add(this.CritterPrimaryBehaviorComboBox, 1, 4);
            this.CritterTableLayoutPanel.Controls.Add(this.CritterNameLabel, 0, 0);
            this.CritterTableLayoutPanel.Controls.Add(this.CritterDescriptionLabel, 0, 1);
            this.CritterTableLayoutPanel.Controls.Add(this.CritterCommentLabel, 0, 2);
            this.CritterTableLayoutPanel.Controls.Add(this.CritterNativeBiomeLabel, 0, 3);
            this.CritterTableLayoutPanel.Controls.Add(this.CritterNameTextBox, 1, 0);
            this.CritterTableLayoutPanel.Controls.Add(this.CritterDescriptionTextBox, 1, 1);
            this.CritterTableLayoutPanel.Controls.Add(this.CritterCommentTextBox, 1, 2);
            this.CritterTableLayoutPanel.Controls.Add(this.CritterNativeBiomeComboBox, 1, 3);
            this.CritterTableLayoutPanel.Controls.Add(this.CritterPrimaryBehaviorLabel, 0, 4);
            this.CritterTableLayoutPanel.Controls.Add(this.CritterParquetAvoidsLabel, 0, 5);
            this.CritterTableLayoutPanel.Controls.Add(this.CritterComingSoonLabel1, 1, 5);
            this.CritterTableLayoutPanel.Controls.Add(this.CritterParquetsSoughtLabel, 0, 6);
            this.CritterTableLayoutPanel.Controls.Add(this.CritterComingSoonLabel2, 1, 6);
            this.CritterTableLayoutPanel.Location = new System.Drawing.Point(307, 16);
            this.CritterTableLayoutPanel.Name = "CritterTableLayoutPanel";
            this.CritterTableLayoutPanel.RowCount = 8;
            this.CritterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.CritterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.CritterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.CritterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.CritterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.CritterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.CritterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.CritterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CritterTableLayoutPanel.Size = new System.Drawing.Size(429, 446);
            this.CritterTableLayoutPanel.TabIndex = 5;
            // 
            // CritterPrimaryBehaviorComboBox
            // 
            this.CritterPrimaryBehaviorComboBox.FormattingEnabled = true;
            this.CritterPrimaryBehaviorComboBox.Location = new System.Drawing.Point(131, 163);
            this.CritterPrimaryBehaviorComboBox.Name = "CritterPrimaryBehaviorComboBox";
            this.CritterPrimaryBehaviorComboBox.Size = new System.Drawing.Size(144, 21);
            this.CritterPrimaryBehaviorComboBox.TabIndex = 29;
            // 
            // CritterNameLabel
            // 
            this.CritterNameLabel.AutoSize = true;
            this.CritterNameLabel.Location = new System.Drawing.Point(3, 0);
            this.CritterNameLabel.Name = "CritterNameLabel";
            this.CritterNameLabel.Size = new System.Drawing.Size(34, 13);
            this.CritterNameLabel.TabIndex = 0;
            this.CritterNameLabel.Text = "Name";
            // 
            // CritterDescriptionLabel
            // 
            this.CritterDescriptionLabel.AutoSize = true;
            this.CritterDescriptionLabel.Location = new System.Drawing.Point(3, 25);
            this.CritterDescriptionLabel.Name = "CritterDescriptionLabel";
            this.CritterDescriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.CritterDescriptionLabel.TabIndex = 3;
            this.CritterDescriptionLabel.Text = "Description";
            // 
            // CritterCommentLabel
            // 
            this.CritterCommentLabel.AutoSize = true;
            this.CritterCommentLabel.Location = new System.Drawing.Point(3, 80);
            this.CritterCommentLabel.Name = "CritterCommentLabel";
            this.CritterCommentLabel.Size = new System.Drawing.Size(52, 13);
            this.CritterCommentLabel.TabIndex = 6;
            this.CritterCommentLabel.Text = "Comment";
            // 
            // CritterNativeBiomeLabel
            // 
            this.CritterNativeBiomeLabel.AutoSize = true;
            this.CritterNativeBiomeLabel.Location = new System.Drawing.Point(3, 135);
            this.CritterNativeBiomeLabel.Name = "CritterNativeBiomeLabel";
            this.CritterNativeBiomeLabel.Size = new System.Drawing.Size(69, 13);
            this.CritterNativeBiomeLabel.TabIndex = 9;
            this.CritterNativeBiomeLabel.Text = "Native Biome";
            // 
            // CritterNameTextBox
            // 
            this.CritterNameTextBox.Location = new System.Drawing.Point(131, 3);
            this.CritterNameTextBox.Name = "CritterNameTextBox";
            this.CritterNameTextBox.Size = new System.Drawing.Size(144, 20);
            this.CritterNameTextBox.TabIndex = 23;
            // 
            // CritterDescriptionTextBox
            // 
            this.CritterDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CritterTableLayoutPanel.SetColumnSpan(this.CritterDescriptionTextBox, 2);
            this.CritterDescriptionTextBox.Location = new System.Drawing.Point(131, 28);
            this.CritterDescriptionTextBox.Multiline = true;
            this.CritterDescriptionTextBox.Name = "CritterDescriptionTextBox";
            this.CritterDescriptionTextBox.Size = new System.Drawing.Size(295, 49);
            this.CritterDescriptionTextBox.TabIndex = 24;
            // 
            // CritterCommentTextBox
            // 
            this.CritterCommentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CritterTableLayoutPanel.SetColumnSpan(this.CritterCommentTextBox, 2);
            this.CritterCommentTextBox.Location = new System.Drawing.Point(131, 83);
            this.CritterCommentTextBox.Multiline = true;
            this.CritterCommentTextBox.Name = "CritterCommentTextBox";
            this.CritterCommentTextBox.Size = new System.Drawing.Size(295, 49);
            this.CritterCommentTextBox.TabIndex = 25;
            // 
            // CritterNativeBiomeComboBox
            // 
            this.CritterNativeBiomeComboBox.FormattingEnabled = true;
            this.CritterNativeBiomeComboBox.Location = new System.Drawing.Point(131, 138);
            this.CritterNativeBiomeComboBox.Name = "CritterNativeBiomeComboBox";
            this.CritterNativeBiomeComboBox.Size = new System.Drawing.Size(144, 21);
            this.CritterNativeBiomeComboBox.TabIndex = 29;
            // 
            // CritterPrimaryBehaviorLabel
            // 
            this.CritterPrimaryBehaviorLabel.AutoSize = true;
            this.CritterPrimaryBehaviorLabel.Location = new System.Drawing.Point(3, 160);
            this.CritterPrimaryBehaviorLabel.Name = "CritterPrimaryBehaviorLabel";
            this.CritterPrimaryBehaviorLabel.Size = new System.Drawing.Size(88, 13);
            this.CritterPrimaryBehaviorLabel.TabIndex = 30;
            this.CritterPrimaryBehaviorLabel.Text = "Primary Behavior";
            // 
            // CritterParquetAvoidsLabel
            // 
            this.CritterParquetAvoidsLabel.AutoSize = true;
            this.CritterParquetAvoidsLabel.Location = new System.Drawing.Point(3, 185);
            this.CritterParquetAvoidsLabel.Name = "CritterParquetAvoidsLabel";
            this.CritterParquetAvoidsLabel.Size = new System.Drawing.Size(92, 13);
            this.CritterParquetAvoidsLabel.TabIndex = 31;
            this.CritterParquetAvoidsLabel.Text = "Parquets Avoided";
            // 
            // CritterComingSoonLabel1
            // 
            this.CritterComingSoonLabel1.AutoSize = true;
            this.CritterComingSoonLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CritterComingSoonLabel1.Location = new System.Drawing.Point(131, 185);
            this.CritterComingSoonLabel1.Name = "CritterComingSoonLabel1";
            this.CritterComingSoonLabel1.Size = new System.Drawing.Size(89, 16);
            this.CritterComingSoonLabel1.TabIndex = 32;
            this.CritterComingSoonLabel1.Text = "Coming Soon";
            // 
            // CritterParquetsSoughtLabel
            // 
            this.CritterParquetsSoughtLabel.AutoSize = true;
            this.CritterParquetsSoughtLabel.Location = new System.Drawing.Point(3, 210);
            this.CritterParquetsSoughtLabel.Name = "CritterParquetsSoughtLabel";
            this.CritterParquetsSoughtLabel.Size = new System.Drawing.Size(87, 13);
            this.CritterParquetsSoughtLabel.TabIndex = 33;
            this.CritterParquetsSoughtLabel.Text = "Parquets Sought";
            // 
            // CritterComingSoonLabel2
            // 
            this.CritterComingSoonLabel2.AutoSize = true;
            this.CritterComingSoonLabel2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CritterComingSoonLabel2.Location = new System.Drawing.Point(131, 210);
            this.CritterComingSoonLabel2.Name = "CritterComingSoonLabel2";
            this.CritterComingSoonLabel2.Size = new System.Drawing.Size(89, 16);
            this.CritterComingSoonLabel2.TabIndex = 34;
            this.CritterComingSoonLabel2.Text = "Coming Soon";
            // 
            // CritterPictureBox
            // 
            this.CritterPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CritterPictureBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.CritterPictureBox.Location = new System.Drawing.Point(767, 286);
            this.CritterPictureBox.Name = "CritterPictureBox";
            this.CritterPictureBox.Size = new System.Drawing.Size(176, 176);
            this.CritterPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CritterPictureBox.TabIndex = 6;
            this.CritterPictureBox.TabStop = false;
            // 
            // CritterEditImageButton
            // 
            this.CritterEditImageButton.Location = new System.Drawing.Point(815, 468);
            this.CritterEditImageButton.Name = "CritterEditImageButton";
            this.CritterEditImageButton.Size = new System.Drawing.Size(128, 23);
            this.CritterEditImageButton.TabIndex = 7;
            this.CritterEditImageButton.Text = "Edit Image";
            this.CritterEditImageButton.UseVisualStyleBackColor = true;
            this.CritterEditImageButton.Click += new System.EventHandler(this.CritterEditImageButton_Click);
            // 
            // CritterIDLabel
            // 
            this.CritterIDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CritterIDLabel.AutoSize = true;
            this.CritterIDLabel.Location = new System.Drawing.Point(754, 19);
            this.CritterIDLabel.Name = "CritterIDLabel";
            this.CritterIDLabel.Size = new System.Drawing.Size(52, 13);
            this.CritterIDLabel.TabIndex = 4;
            this.CritterIDLabel.Text = "Critter ID";
            // 
            // CritterListBox
            // 
            this.CritterListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CritterListBox.DisplayMember = "Name";
            this.CritterListBox.FormattingEnabled = true;
            this.CritterListBox.Location = new System.Drawing.Point(9, 16);
            this.CritterListBox.Name = "CritterListBox";
            this.CritterListBox.Size = new System.Drawing.Size(279, 446);
            this.CritterListBox.TabIndex = 1;
            // 
            // CritterAddNewCritterButton
            // 
            this.CritterAddNewCritterButton.Location = new System.Drawing.Point(159, 468);
            this.CritterAddNewCritterButton.Name = "CritterAddNewCritterButton";
            this.CritterAddNewCritterButton.Size = new System.Drawing.Size(129, 23);
            this.CritterAddNewCritterButton.TabIndex = 2;
            this.CritterAddNewCritterButton.Text = "Add New Critter";
            this.CritterAddNewCritterButton.UseVisualStyleBackColor = true;
            // 
            // CritterIDTextBox
            // 
            this.CritterIDTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CritterIDTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.CritterIDTextBox.Location = new System.Drawing.Point(812, 16);
            this.CritterIDTextBox.Name = "CritterIDTextBox";
            this.CritterIDTextBox.Size = new System.Drawing.Size(131, 20);
            this.CritterIDTextBox.TabIndex = 3;
            this.CritterIDTextBox.Text = "-2020202020";
            // 
            // CritterConfigGroupBox
            // 
            this.CritterConfigGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CritterConfigGroupBox.Location = new System.Drawing.Point(9, 497);
            this.CritterConfigGroupBox.Name = "CritterConfigGroupBox";
            this.CritterConfigGroupBox.Size = new System.Drawing.Size(938, 96);
            this.CritterConfigGroupBox.TabIndex = 0;
            this.CritterConfigGroupBox.TabStop = false;
            // 
            // CritterRemoveCritterButton
            // 
            this.CritterRemoveCritterButton.Location = new System.Drawing.Point(24, 468);
            this.CritterRemoveCritterButton.Name = "CritterRemoveCritterButton";
            this.CritterRemoveCritterButton.Size = new System.Drawing.Size(129, 23);
            this.CritterRemoveCritterButton.TabIndex = 2;
            this.CritterRemoveCritterButton.Text = "Remove Critter";
            this.CritterRemoveCritterButton.UseVisualStyleBackColor = true;
            // 
            // ItemsTabPage
            // 
            this.ItemsTabPage.BackColor = System.Drawing.Color.Transparent;
            this.ItemsTabPage.Controls.Add(this.ItemRemoveItemButton);
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
            // ItemRemoveItemButton
            // 
            this.ItemRemoveItemButton.Location = new System.Drawing.Point(24, 468);
            this.ItemRemoveItemButton.Name = "ItemRemoveItemButton";
            this.ItemRemoveItemButton.Size = new System.Drawing.Size(129, 23);
            this.ItemRemoveItemButton.TabIndex = 2;
            this.ItemRemoveItemButton.Text = "Remove Item";
            this.ItemRemoveItemButton.UseVisualStyleBackColor = true;
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
            this.ItemListBox.DisplayMember = "Name";
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
            this.ItemPictureEditButton.Location = new System.Drawing.Point(816, 468);
            this.ItemPictureEditButton.Name = "ItemPictureEditButton";
            this.ItemPictureEditButton.Size = new System.Drawing.Size(128, 23);
            this.ItemPictureEditButton.TabIndex = 7;
            this.ItemPictureEditButton.Text = "Edit Image";
            this.ItemPictureEditButton.UseVisualStyleBackColor = true;
            this.ItemPictureEditButton.Click += new System.EventHandler(this.ItemPictureEditButton_Click);
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
            this.ItemPictureBox.Location = new System.Drawing.Point(768, 286);
            this.ItemPictureBox.Name = "ItemPictureBox";
            this.ItemPictureBox.Size = new System.Drawing.Size(176, 176);
            this.ItemPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
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
            // BiomesTabPage
            // 
            this.BiomesTabPage.BackColor = System.Drawing.Color.Transparent;
            this.BiomesTabPage.Controls.Add(this.BiomeRemoveBiomeButton);
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
            this.BiomesTabPage.Text = "Biome Recipes";
            // 
            // BiomeRemoveBiomeButton
            // 
            this.BiomeRemoveBiomeButton.Location = new System.Drawing.Point(24, 468);
            this.BiomeRemoveBiomeButton.Name = "BiomeRemoveBiomeButton";
            this.BiomeRemoveBiomeButton.Size = new System.Drawing.Size(129, 23);
            this.BiomeRemoveBiomeButton.TabIndex = 2;
            this.BiomeRemoveBiomeButton.Text = "Remove Biome";
            this.BiomeRemoveBiomeButton.UseVisualStyleBackColor = true;
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
            this.BiomeListBox.DisplayMember = "Name";
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
            this.BiomePictureEditButton.Location = new System.Drawing.Point(815, 468);
            this.BiomePictureEditButton.Name = "BiomePictureEditButton";
            this.BiomePictureEditButton.Size = new System.Drawing.Size(128, 23);
            this.BiomePictureEditButton.TabIndex = 7;
            this.BiomePictureEditButton.Text = "Edit Image";
            this.BiomePictureEditButton.UseVisualStyleBackColor = true;
            this.BiomePictureEditButton.Click += new System.EventHandler(this.BiomePictureEditButton_Click);
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
            this.BiomePictureBox.Location = new System.Drawing.Point(767, 281);
            this.BiomePictureBox.Name = "BiomePictureBox";
            this.BiomePictureBox.Size = new System.Drawing.Size(176, 176);
            this.BiomePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
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
            // CraftingRecipesTabPage
            // 
            this.CraftingRecipesTabPage.BackColor = System.Drawing.Color.Transparent;
            this.CraftingRecipesTabPage.Controls.Add(this.CraftingRemoveCraftingButton);
            this.CraftingRecipesTabPage.Controls.Add(this.CraftingListBox);
            this.CraftingRecipesTabPage.Controls.Add(this.CraftingPictureEditButton);
            this.CraftingRecipesTabPage.Controls.Add(this.CraftingTableLayoutPanel);
            this.CraftingRecipesTabPage.Controls.Add(this.CraftingPictureBox);
            this.CraftingRecipesTabPage.Controls.Add(this.CraftingIDLabel);
            this.CraftingRecipesTabPage.Controls.Add(this.CraftingAddNewCraftingButton);
            this.CraftingRecipesTabPage.Controls.Add(this.CraftingIDTextBox);
            this.CraftingRecipesTabPage.Controls.Add(this.CraftingConfigGroupBox);
            this.CraftingRecipesTabPage.Location = new System.Drawing.Point(4, 22);
            this.CraftingRecipesTabPage.Name = "CraftingRecipesTabPage";
            this.CraftingRecipesTabPage.Size = new System.Drawing.Size(953, 599);
            this.CraftingRecipesTabPage.TabIndex = 3;
            this.CraftingRecipesTabPage.Text = "Crafting Recipes";
            // 
            // CraftingRemoveCraftingButton
            // 
            this.CraftingRemoveCraftingButton.Location = new System.Drawing.Point(9, 468);
            this.CraftingRemoveCraftingButton.Name = "CraftingRemoveCraftingButton";
            this.CraftingRemoveCraftingButton.Size = new System.Drawing.Size(127, 23);
            this.CraftingRemoveCraftingButton.TabIndex = 2;
            this.CraftingRemoveCraftingButton.Text = "Remove Crafting Recipe";
            this.CraftingRemoveCraftingButton.UseVisualStyleBackColor = true;
            // 
            // CraftingListBox
            // 
            this.CraftingListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CraftingListBox.DisplayMember = "Name";
            this.CraftingListBox.FormattingEnabled = true;
            this.CraftingListBox.Location = new System.Drawing.Point(9, 16);
            this.CraftingListBox.Name = "CraftingListBox";
            this.CraftingListBox.Size = new System.Drawing.Size(279, 446);
            this.CraftingListBox.TabIndex = 1;
            // 
            // CraftingPictureEditButton
            // 
            this.CraftingPictureEditButton.Location = new System.Drawing.Point(816, 465);
            this.CraftingPictureEditButton.Name = "CraftingPictureEditButton";
            this.CraftingPictureEditButton.Size = new System.Drawing.Size(128, 23);
            this.CraftingPictureEditButton.TabIndex = 7;
            this.CraftingPictureEditButton.Text = "Edit Image";
            this.CraftingPictureEditButton.UseVisualStyleBackColor = true;
            this.CraftingPictureEditButton.Click += new System.EventHandler(this.CraftingPictureEditButton_Click);
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
            this.CraftingPictureBox.Location = new System.Drawing.Point(767, 283);
            this.CraftingPictureBox.Name = "CraftingPictureBox";
            this.CraftingPictureBox.Size = new System.Drawing.Size(176, 176);
            this.CraftingPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
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
            // CraftingConfigGroupBox
            // 
            this.CraftingConfigGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CraftingConfigGroupBox.Controls.Add(this.CraftingConfigTableLayoutPanel);
            this.CraftingConfigGroupBox.Location = new System.Drawing.Point(6, 496);
            this.CraftingConfigGroupBox.Name = "CraftingConfigGroupBox";
            this.CraftingConfigGroupBox.Size = new System.Drawing.Size(940, 100);
            this.CraftingConfigGroupBox.TabIndex = 0;
            this.CraftingConfigGroupBox.TabStop = false;
            this.CraftingConfigGroupBox.Text = "Configuration";
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
            // RoomRecipesTabPage
            // 
            this.RoomRecipesTabPage.BackColor = System.Drawing.Color.Transparent;
            this.RoomRecipesTabPage.Controls.Add(this.RoomRemoveRoomButton);
            this.RoomRecipesTabPage.Controls.Add(this.RoomAddBlockButton);
            this.RoomRecipesTabPage.Controls.Add(this.RoomRemoveBlockButton);
            this.RoomRecipesTabPage.Controls.Add(this.RoomListBox);
            this.RoomRecipesTabPage.Controls.Add(this.RoomConfigGroupBox);
            this.RoomRecipesTabPage.Controls.Add(this.RoomPictureEditButton);
            this.RoomRecipesTabPage.Controls.Add(this.RoomTableLayoutPanel);
            this.RoomRecipesTabPage.Controls.Add(this.RoomPictureBox);
            this.RoomRecipesTabPage.Controls.Add(this.RoomIDLabel);
            this.RoomRecipesTabPage.Controls.Add(this.RoomAddNewRoomButton);
            this.RoomRecipesTabPage.Controls.Add(this.RoomIDTextBox);
            this.RoomRecipesTabPage.Location = new System.Drawing.Point(4, 22);
            this.RoomRecipesTabPage.Name = "RoomRecipesTabPage";
            this.RoomRecipesTabPage.Size = new System.Drawing.Size(953, 599);
            this.RoomRecipesTabPage.TabIndex = 7;
            this.RoomRecipesTabPage.Text = "Room Recipes";
            // 
            // RoomRemoveRoomButton
            // 
            this.RoomRemoveRoomButton.Location = new System.Drawing.Point(24, 468);
            this.RoomRemoveRoomButton.Name = "RoomRemoveRoomButton";
            this.RoomRemoveRoomButton.Size = new System.Drawing.Size(129, 23);
            this.RoomRemoveRoomButton.TabIndex = 2;
            this.RoomRemoveRoomButton.Text = "Remove Room";
            this.RoomRemoveRoomButton.UseVisualStyleBackColor = true;
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
            this.RoomRemoveBlockButton.Location = new System.Drawing.Point(460, 468);
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
            this.RoomListBox.DisplayMember = "Name";
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
            this.RoomPictureEditButton.Location = new System.Drawing.Point(815, 468);
            this.RoomPictureEditButton.Name = "RoomPictureEditButton";
            this.RoomPictureEditButton.Size = new System.Drawing.Size(128, 23);
            this.RoomPictureEditButton.TabIndex = 7;
            this.RoomPictureEditButton.Text = "Edit Image";
            this.RoomPictureEditButton.UseVisualStyleBackColor = true;
            this.RoomPictureEditButton.Click += new System.EventHandler(this.RoomPictureEditButton_Click);
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
            this.RoomPictureBox.Location = new System.Drawing.Point(767, 286);
            this.RoomPictureBox.Name = "RoomPictureBox";
            this.RoomPictureBox.Size = new System.Drawing.Size(176, 176);
            this.RoomPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
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
            // MapsTabPage
            // 
            this.MapsTabPage.BackColor = System.Drawing.Color.Transparent;
            this.MapsTabPage.Controls.Add(this.MapComingSoonLabel);
            this.MapsTabPage.Location = new System.Drawing.Point(4, 22);
            this.MapsTabPage.Name = "MapsTabPage";
            this.MapsTabPage.Size = new System.Drawing.Size(953, 599);
            this.MapsTabPage.TabIndex = 5;
            this.MapsTabPage.Text = "Maps";
            // 
            // MapComingSoonLabel
            // 
            this.MapComingSoonLabel.AutoSize = true;
            this.MapComingSoonLabel.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MapComingSoonLabel.Location = new System.Drawing.Point(420, 278);
            this.MapComingSoonLabel.Name = "MapComingSoonLabel";
            this.MapComingSoonLabel.Size = new System.Drawing.Size(136, 25);
            this.MapComingSoonLabel.TabIndex = 0;
            this.MapComingSoonLabel.Text = "Coming Soon";
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
            this.Activated += new System.EventHandler(this.MainEditorForm_Activated);
            this.EditorStatusStrip.ResumeLayout(false);
            this.EditorStatusStrip.PerformLayout();
            this.MainMenuBar.ResumeLayout(false);
            this.MainMenuBar.PerformLayout();
            this.ContextMenuStripEditorForm.ResumeLayout(false);
            this.FiltersTableLayoutPanel.ResumeLayout(false);
            this.FiltersTableLayoutPanel.PerformLayout();
            this.FilterGroupBox.ResumeLayout(false);
            this.FlavorFilterGroupBox.ResumeLayout(false);
            this.FlavorsTableLayoutPanel.ResumeLayout(false);
            this.FlavorsTableLayoutPanel.PerformLayout();
            this.EditorTabs.ResumeLayout(false);
            this.GamesTabPage.ResumeLayout(false);
            this.GamesTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GameIconPictureBox)).EndInit();
            this.GameTableLayoutPanel.ResumeLayout(false);
            this.GameTableLayoutPanel.PerformLayout();
            this.FileFormatGroupBox.ResumeLayout(false);
            this.FileFormatTableLayoutPanel.ResumeLayout(false);
            this.FileFormatTableLayoutPanel.PerformLayout();
            this.LibraryInfoGroupBox.ResumeLayout(false);
            this.LibraryInfoTableLayoutPanel.ResumeLayout(false);
            this.LibraryInfoTableLayoutPanel.PerformLayout();
            this.BlocksTabPage.ResumeLayout(false);
            this.BlocksTabPage.PerformLayout();
            this.BlockTableLayoutPanel.ResumeLayout(false);
            this.BlockTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlockPictureBox)).EndInit();
            this.FloorsTabPage.ResumeLayout(false);
            this.FloorsTabPage.PerformLayout();
            this.FloorLayoutTabelPanel.ResumeLayout(false);
            this.FloorLayoutTabelPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FloorPictureBox)).EndInit();
            this.FurnishingsTabPage.ResumeLayout(false);
            this.FurnishingsTabPage.PerformLayout();
            this.FurnishingTableLayoutPanel.ResumeLayout(false);
            this.FurnishingTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FurnishingPictureBox)).EndInit();
            this.CollectiblesTabPage.ResumeLayout(false);
            this.CollectiblesTabPage.PerformLayout();
            this.CollectibleTableLayoutPanel.ResumeLayout(false);
            this.CollectibleTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CollectiblePictureBox)).EndInit();
            this.CharactersTabPage.ResumeLayout(false);
            this.CharactersTabPage.PerformLayout();
            this.CharacterPronounGroupBox.ResumeLayout(false);
            this.CharacterPronounTableLayoutPanel.ResumeLayout(false);
            this.CharacterPronounTableLayoutPanel.PerformLayout();
            this.CharacterTableLayoutPanel.ResumeLayout(false);
            this.CharacterTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CharacterPictureBox)).EndInit();
            this.CrittersTabPage.ResumeLayout(false);
            this.CrittersTabPage.PerformLayout();
            this.CritterTableLayoutPanel.ResumeLayout(false);
            this.CritterTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CritterPictureBox)).EndInit();
            this.ItemsTabPage.ResumeLayout(false);
            this.ItemsTabPage.PerformLayout();
            this.ItemInventoriesGroupBox.ResumeLayout(false);
            this.ItemTableLayoutPanel.ResumeLayout(false);
            this.ItemTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemPictureBox)).EndInit();
            this.BiomesTabPage.ResumeLayout(false);
            this.BiomesTabPage.PerformLayout();
            this.BiomeConfigGroupBox.ResumeLayout(false);
            this.BiomeConfigTableLayoutPanel.ResumeLayout(false);
            this.BiomeConfigTableLayoutPanel.PerformLayout();
            this.BiomeTableLayoutPanel.ResumeLayout(false);
            this.BiomeTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BiomePictureBox)).EndInit();
            this.CraftingRecipesTabPage.ResumeLayout(false);
            this.CraftingRecipesTabPage.PerformLayout();
            this.CraftingTableLayoutPanel.ResumeLayout(false);
            this.CraftingTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CraftingPictureBox)).EndInit();
            this.CraftingConfigGroupBox.ResumeLayout(false);
            this.CraftingConfigTableLayoutPanel.ResumeLayout(false);
            this.CraftingConfigTableLayoutPanel.PerformLayout();
            this.RoomRecipesTabPage.ResumeLayout(false);
            this.RoomRecipesTabPage.PerformLayout();
            this.RoomConfigGroupBox.ResumeLayout(false);
            this.RoomConfigTableLayoutPanel.ResumeLayout(false);
            this.RoomConfigTableLayoutPanel.PerformLayout();
            this.RoomTableLayoutPanel.ResumeLayout(false);
            this.RoomTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoomPictureBox)).EndInit();
            this.MapsTabPage.ResumeLayout(false);
            this.MapsTabPage.PerformLayout();
            this.ScriptsTabPage.ResumeLayout(false);
            this.ScriptsTabPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.ToolStripStatusLabel MainToolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar ToolStripProgressBar;
        private System.Windows.Forms.StatusStrip EditorStatusStrip;
        private System.Windows.Forms.ToolTip EditorToolTip;

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
        private System.Windows.Forms.TableLayoutPanel FlavorsTableLayoutPanel;
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

        private System.Windows.Forms.TabControl EditorTabs;

        private System.Windows.Forms.TabPage GamesTabPage;
        private System.Windows.Forms.GroupBox LibraryInfoGroupBox;
        private System.Windows.Forms.GroupBox FileFormatGroupBox;
        private System.Windows.Forms.TableLayoutPanel LibraryInfoTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel FileFormatTableLayoutPanel;
        private System.Windows.Forms.Label LibraryVersionLabel;
        private System.Windows.Forms.Label LibraryVersionExample;
        private System.Windows.Forms.Label LibraryProjectPathLabel;
        private System.Windows.Forms.Label LibraryProjectPathExample;
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
        private System.Windows.Forms.Button GameAddNewGameButton;
        private System.Windows.Forms.Button GameRemoveGameButton;
        private System.Windows.Forms.ListBox GameListBox;
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

        private System.Windows.Forms.TabPage CrittersTabPage;
        private System.Windows.Forms.TableLayoutPanel CritterTableLayoutPanel;
        private System.Windows.Forms.ComboBox CritterPrimaryBehaviorComboBox;
        private System.Windows.Forms.Label CritterNameLabel;
        private System.Windows.Forms.Label CritterDescriptionLabel;
        private System.Windows.Forms.Label CritterCommentLabel;
        private System.Windows.Forms.Label CritterNativeBiomeLabel;
        private System.Windows.Forms.TextBox CritterNameTextBox;
        private System.Windows.Forms.TextBox CritterDescriptionTextBox;
        private System.Windows.Forms.TextBox CritterCommentTextBox;
        private System.Windows.Forms.ComboBox CritterNativeBiomeComboBox;
        private System.Windows.Forms.Label CritterPrimaryBehaviorLabel;
        private System.Windows.Forms.Label CritterParquetAvoidsLabel;
        private System.Windows.Forms.Label CritterComingSoonLabel1;
        private System.Windows.Forms.Label CritterParquetsSoughtLabel;
        private System.Windows.Forms.Label CritterComingSoonLabel2;
        private System.Windows.Forms.PictureBox CritterPictureBox;
        private System.Windows.Forms.Button CritterEditImageButton;
        private System.Windows.Forms.Label CritterIDLabel;
        private System.Windows.Forms.ListBox CritterListBox;
        private System.Windows.Forms.Button CritterAddNewCritterButton;
        private System.Windows.Forms.TextBox CritterIDTextBox;
        private System.Windows.Forms.GroupBox CritterConfigGroupBox;
        private System.Windows.Forms.Button CritterRemoveCritterButton;

        private System.Windows.Forms.TabPage CharactersTabPage;
        private System.Windows.Forms.GroupBox CharacterPronounGroupBox;
        private System.Windows.Forms.TableLayoutPanel CharacterTableLayoutPanel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label CharacterNameLabel;
        private System.Windows.Forms.Label CharacterDescriptionLabel;
        private System.Windows.Forms.Label CharacterCommentLabel;
        private System.Windows.Forms.Label CharacterNativeBiomeLabel;
        private System.Windows.Forms.TextBox CharacterNameTextBox;
        private System.Windows.Forms.TextBox CharacterDescriptionTextBox;
        private System.Windows.Forms.TextBox CharacterCommentTextBox;
        private System.Windows.Forms.ComboBox CharacterNativeBiomeComboBox;
        private System.Windows.Forms.Label CharacterPrimaryBehaviorLabel;
        private System.Windows.Forms.Label CharacterParquetsAvoidedLabel;
        private System.Windows.Forms.Label CharacterComingSoonLabel1;
        private System.Windows.Forms.Label CharacterParquetsSoughtLabel;
        private System.Windows.Forms.Label CharacterComingSoonLabel;
        private System.Windows.Forms.Button CharacterRemoveCharacterButton;
        private System.Windows.Forms.TextBox CharacterIDTextBox;
        private System.Windows.Forms.Button CharacterAddNewCharacterButton;
        private System.Windows.Forms.ListBox CharacterListBox;
        private System.Windows.Forms.Label CharacterIDLabel;
        private System.Windows.Forms.Button CharacterEditImageButton;
        private System.Windows.Forms.PictureBox CharacterPictureBox;
        private System.Windows.Forms.TextBox CharacterStoryIDTextBox;
        private System.Windows.Forms.Button CharacterOpenInventoryEditorButton;
        private System.Windows.Forms.Label CharacterPronounLabel;
        private System.Windows.Forms.Label CharacterStoryIDLabel;
        private System.Windows.Forms.Label CharacterStartingQuestsLabel;
        private System.Windows.Forms.Label CharacterStartingDialogueLabel;
        private System.Windows.Forms.Label CharacterStartingInventoryLabel;
        private System.Windows.Forms.ComboBox CharacterPronounComboBox;
        private System.Windows.Forms.ComboBox CharacterStartingDialogueComboBox;
        private System.Windows.Forms.ComboBox StartingInventoryComboBox;
        private System.Windows.Forms.ListBox CharacterStartingQuestsListBox;
        private System.Windows.Forms.Button CharacterAddQuestButton;
        private System.Windows.Forms.Button CharacterRemoveQuestButton;
        private System.Windows.Forms.TableLayoutPanel CharacterPronounTableLayoutPanel;
        private System.Windows.Forms.ListBox CharacterPronounListBox;
        private System.Windows.Forms.Label CharacterPronounSubjectiveLabel;
        private System.Windows.Forms.Label CharacterPronounObjectiveLabel;
        private System.Windows.Forms.Label CharacterPronounDeterminerLabel;
        private System.Windows.Forms.Label CharacterPronounPossessiveLabel;
        private System.Windows.Forms.Label CharacterPronounReflexiveLabel;
        private System.Windows.Forms.TextBox CharacterPronounReflexiveTextBox;
        private System.Windows.Forms.TextBox CharacterPronounDeterminerTextBox;
        private System.Windows.Forms.TextBox CharacterPronounObjectiveTextBox;
        private System.Windows.Forms.TextBox CharacterPronounSubjectiveTextBox;
        private System.Windows.Forms.Button CharacterPronounAddNewPronoungGroupButton;
        private System.Windows.Forms.Button CharacterPronounRemovePronoungGroupButton;
        private System.Windows.Forms.TextBox CharacterPronounPossessiveTextBox;
        private System.Windows.Forms.Label CharacterPronounKeyLabel;
        private System.Windows.Forms.Label CharacterPronounKeyExample;

        private System.Windows.Forms.TabPage BiomesTabPage;
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
        private System.Windows.Forms.Button BiomeRemoveBiomeButton;
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

        private System.Windows.Forms.TabPage CraftingRecipesTabPage;
        private System.Windows.Forms.ListBox CraftingListBox;
        private System.Windows.Forms.TableLayoutPanel CraftingConfigTableLayoutPanel;
        private System.Windows.Forms.GroupBox CraftingConfigGroupBox;
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
        private System.Windows.Forms.Button CraftingRemoveCraftingButton;
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
        private System.Windows.Forms.ListBox CraftingProductsListBox;
        private System.Windows.Forms.Label CraftingStrikePatternDimensionLabelLabel;
        private System.Windows.Forms.Label CraftingStrikePatternDimensionLabelExample;
        private System.Windows.Forms.Label CraftingStrikePatternLabel;
        private System.Windows.Forms.Label CraftingStrikePatternComingSoonLabel;

        private System.Windows.Forms.TabPage ItemsTabPage;
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
        private System.Windows.Forms.Button ItemRemoveItemButton;
        private System.Windows.Forms.TextBox ItemIDTextBox;
        private System.Windows.Forms.Button ItemAddTagButton;
        private System.Windows.Forms.Button ItemRemoveTagButton;
        private System.Windows.Forms.ListBox ItemTagListBox;
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

        private System.Windows.Forms.TabPage MapsTabPage;
        private System.Windows.Forms.Label MapComingSoonLabel;

        private System.Windows.Forms.TabPage FloorsTabPage;
        private System.Windows.Forms.Button FloorEditImageButton;
        private System.Windows.Forms.TableLayoutPanel FloorLayoutTabelPanel;
        private System.Windows.Forms.Label FloorNameLabel;
        private System.Windows.Forms.Label FloorDescriptionLabel;
        private System.Windows.Forms.Label FloorCommentLabel;
        private System.Windows.Forms.Label FloorEquivalentItemIDLabel;
        private System.Windows.Forms.Label FloorModificationToolLabel;
        private System.Windows.Forms.TextBox FloorNameTextBox;
        private System.Windows.Forms.TextBox FloorDescriptionTextBox;
        private System.Windows.Forms.TextBox FloorCommentTextBox;
        private System.Windows.Forms.PictureBox FloorPictureBox;
        private System.Windows.Forms.Label FloorIDLabel;
        private System.Windows.Forms.Button FloorAddNewFloorButton;
        private System.Windows.Forms.Button FloorRemoveFloorButton;
        private System.Windows.Forms.TextBox FloorIDTextBox;
        private System.Windows.Forms.GroupBox FloorConfigGroupBox;
        private System.Windows.Forms.Label FloorTrenchName;
        private System.Windows.Forms.TextBox FloorTrenchNameTextBox;
        private System.Windows.Forms.ListBox FloorListBox;
        private System.Windows.Forms.ComboBox FloorlItemIDComboBox;
        private System.Windows.Forms.ComboBox FloorModificationToolComboBox;
        private System.Windows.Forms.Label FloorAddsToBiomeLabel;
        private System.Windows.Forms.Label FloorAddsToRoomLabel;
        private System.Windows.Forms.ListBox FloorAddsToBiomeListBox;
        private System.Windows.Forms.ListBox FloorAddsToRoomListBox;
        private System.Windows.Forms.Button FloorAddRoomTagButton;
        private System.Windows.Forms.Button FloorAddBiomeTagButton;
        private System.Windows.Forms.Button FloorRemoveBiomeTagButton;
        private System.Windows.Forms.Button FloorRemoveRoomTagButton;

        private System.Windows.Forms.TabPage BlocksTabPage;
        private System.Windows.Forms.TableLayoutPanel BlockTableLayoutPanel;
        private System.Windows.Forms.Label BlockNameLabel;
        private System.Windows.Forms.Label BlockDescriptionLabel;
        private System.Windows.Forms.Label BlockCommentLabel;
        private System.Windows.Forms.Label BlockEquivalentItemLabel;
        private System.Windows.Forms.ComboBox BlockEquivalentItemComboBox;
        private System.Windows.Forms.TextBox BlockNameTextBox;
        private System.Windows.Forms.TextBox BlockDescriptionTextBox;
        private System.Windows.Forms.TextBox BlockCommentTextBox;
        private System.Windows.Forms.PictureBox BlockPictureBox;
        private System.Windows.Forms.Button BlockEditImageButton;
        private System.Windows.Forms.Label BlockIDLabel;
        private System.Windows.Forms.ListBox BlockListBox;
        private System.Windows.Forms.Button BlockAddNewBlockButton;
        private System.Windows.Forms.TextBox BlockIDTextBox;
        private System.Windows.Forms.Button BlockRemoveBlockButton;
        private System.Windows.Forms.TextBox BlockMaxToughnessTextBox;
        private System.Windows.Forms.Label BlockGatheringToolLabel;
        private System.Windows.Forms.Label BlockGatheringEffectLabel;
        private System.Windows.Forms.Label BlockDroppedCollectibleLabel;
        private System.Windows.Forms.Label BlockIsFlammableLabel;
        private System.Windows.Forms.Label BlockIsLiquidLabel;
        private System.Windows.Forms.Label BlockMaxToughnessLabel;
        private System.Windows.Forms.CheckBox BlockIsFlammableCheckBox;
        private System.Windows.Forms.CheckBox BlockIsLiquidCheckBox;
        private System.Windows.Forms.ComboBox BlockGatherToolComboBox;
        private System.Windows.Forms.ComboBox BlockDroppedCollectibleIDComboBox;
        private System.Windows.Forms.ComboBox BlockGatherEffectComboBox;
        private System.Windows.Forms.GroupBox BlockConfigGroupBox;

        private System.Windows.Forms.TabPage FurnishingsTabPage;
        private System.Windows.Forms.TableLayoutPanel FurnishingTableLayoutPanel;
        private System.Windows.Forms.Label FurnishingNameLabel;
        private System.Windows.Forms.Label FurnishingDescriptionLabel;
        private System.Windows.Forms.Label FurnishingCommentLabel;
        private System.Windows.Forms.Label FurnishingEquivalentItemLabel;
        private System.Windows.Forms.TextBox FurnishingNameTextBox;
        private System.Windows.Forms.TextBox FurnishingDescriptionTextBox;
        private System.Windows.Forms.TextBox FurnishingCommentTextBox;
        private System.Windows.Forms.ComboBox FurnishingEquivalentItemComboBox;
        private System.Windows.Forms.Button FurnishingRemoveFurnishingButton;
        private System.Windows.Forms.GroupBox FurnishingConfigGroupBox;
        private System.Windows.Forms.TextBox FurnishingIDTextBox;
        private System.Windows.Forms.Button FurnishingAddNewFurnishingButton;
        private System.Windows.Forms.ListBox FurnishingListBox;
        private System.Windows.Forms.Label FurnishingIDLabel;
        private System.Windows.Forms.Button FurnishingEditImageButton;
        private System.Windows.Forms.PictureBox FurnishingPictureBox;
        private System.Windows.Forms.ComboBox FurnishingEntryTypeComboBox;
        private System.Windows.Forms.Label FurnishingEntryTypeLabel;
        private System.Windows.Forms.Label FurnishingIsWalkableLabel;
        private System.Windows.Forms.Label FurnishingIsEnclosingLabel;
        private System.Windows.Forms.Label FurnishingIsFlammableLabel;
        private System.Windows.Forms.Label FurnishingSwapWithFurnishingLabel;
        private System.Windows.Forms.ComboBox FurnishingSwapWithFurnishingComboBox;
        private System.Windows.Forms.CheckBox FurnishingIsWalkableCheckBox;
        private System.Windows.Forms.CheckBox FurnishingIsEnclosingCheckBox;
        private System.Windows.Forms.CheckBox FurnishingIsFlammableCheckBox;

        private System.Windows.Forms.TabPage CollectiblesTabPage;
        private System.Windows.Forms.TableLayoutPanel CollectibleTableLayoutPanel;
        private System.Windows.Forms.Label CollectibleNameLabel;
        private System.Windows.Forms.Label CollectibleDescriptionLabel;
        private System.Windows.Forms.Label CollectibleCommentLabel;
        private System.Windows.Forms.Label CollectibleEquivalentItemLabel;
        private System.Windows.Forms.TextBox CollectibleNameTextBox;
        private System.Windows.Forms.TextBox CollectibleDescriptionTextBox;
        private System.Windows.Forms.TextBox CollectibleCommentTextBox;
        private System.Windows.Forms.TextBox CollectibleEffectAmountTextBox;
        private System.Windows.Forms.ComboBox CollectibleCollectionEffectComboBox;
        private System.Windows.Forms.Label CollectibleCollectionEffectLabel;
        private System.Windows.Forms.Label CollectibleEffectAmountLabel;
        private System.Windows.Forms.ComboBox CollectibleEquivalentItemComboBox;
        private System.Windows.Forms.Button CollectibleRemoveCollectibleButton;
        private System.Windows.Forms.GroupBox CollectibleConfigGroupBox;
        private System.Windows.Forms.TextBox CollectibleIDTextBox;
        private System.Windows.Forms.Button CollectibleAddNewCollectibleButton;
        private System.Windows.Forms.ListBox CollectibleListBox;
        private System.Windows.Forms.Label CollectibleIDLabel;
        private System.Windows.Forms.Button CollectibleEditImageButton;
        private System.Windows.Forms.PictureBox CollectiblePictureBox;

        private System.Windows.Forms.TabPage RoomRecipesTabPage;
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
        private System.Windows.Forms.Button RoomRemoveRoomButton;
        private System.Windows.Forms.TextBox RoomIDTextBox;
        private System.Windows.Forms.Button RoomAddBlockButton;
        private System.Windows.Forms.Button RoomRemoveBlockButton;
        private System.Windows.Forms.Button RoomAddFloorButton;
        private System.Windows.Forms.Button RoomRemoveFloorButton;
        private System.Windows.Forms.ListBox RoomRequiredBlocksListBox;
        private System.Windows.Forms.ListBox RoomRequiredFloorsListBox;
        private System.Windows.Forms.Button RoomAddFurnishingsButton;
        private System.Windows.Forms.Button RoomRemoveFurnishingsButton;
        private System.Windows.Forms.Label RoomRequiredFurnishingsLabel;
        private System.Windows.Forms.ListBox RoomRequiredFurnishingsListBox;
        private System.Windows.Forms.TableLayoutPanel RoomConfigTableLayoutPanel;
        private System.Windows.Forms.Label RoomMinWalkableSpacesLabel;
        private System.Windows.Forms.Label RoomMaxWalkableSpacesLabel;
        private System.Windows.Forms.TextBox RoomMinWalkableSpacesTextBox;
        private System.Windows.Forms.TextBox RoomMaxWalkableSpacesTextBox;

        private System.Windows.Forms.TabPage ScriptsTabPage;
        private System.Windows.Forms.Label ScriptingComingSoonLabel;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStripEditorForm;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemOpenContainingFolder;
    }
}
