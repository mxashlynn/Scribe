using System.Drawing;

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
            this.ListNameCollisionsStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
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
            this.BeingsTabPage = new System.Windows.Forms.TabPage();
            this.BiomesTabPage = new System.Windows.Forms.TabPage();
            this.CraftingTabPage = new System.Windows.Forms.TabPage();
            this.ItemsTabPage = new System.Windows.Forms.TabPage();
            this.MapsTabPage = new System.Windows.Forms.TabPage();
            this.ParquetsTabPage = new System.Windows.Forms.TabPage();
            this.RoomsTabPage = new System.Windows.Forms.TabPage();
            this.ScriptsTabPage = new System.Windows.Forms.TabPage();
            this.LibraryTabPage = new System.Windows.Forms.TabPage();
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
            this.MainMenuBar.SuspendLayout();
            this.EditorTabs.SuspendLayout();
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
            this.SaveToolStripMenuItem,
            this.ToolStripSeparator1,
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "&File";
            // 
            // NewToolStripMenuItem
            // 
            this.NewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewToolStripMenuItem.Name = "NewToolStripMenuItem";
            this.NewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NewToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.NewToolStripMenuItem.Text = "&New";
            // 
            // LoadToolStripMenuItem
            // 
            this.LoadToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoadToolStripMenuItem.Name = "LoadToolStripMenuItem";
            this.LoadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.LoadToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.LoadToolStripMenuItem.Text = "&Load";
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.SaveToolStripMenuItem.Text = "&Save";
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(140, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.ExitToolStripMenuItem.Text = "E&xit";
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
            this.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem";
            this.UndoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.UndoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.UndoToolStripMenuItem.Text = "&Undo";
            // 
            // RedoToolStripMenuItem
            // 
            this.RedoToolStripMenuItem.Enabled = false;
            this.RedoToolStripMenuItem.Name = "RedoToolStripMenuItem";
            this.RedoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.RedoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.RedoToolStripMenuItem.Text = "&Redo";
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(141, 6);
            // 
            // CutToolStripMenuItem
            // 
            this.CutToolStripMenuItem.Enabled = false;
            this.CutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CutToolStripMenuItem.Name = "CutToolStripMenuItem";
            this.CutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.CutToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.CutToolStripMenuItem.Text = "Cu&t";
            // 
            // CopyToolStripMenuItem
            // 
            this.CopyToolStripMenuItem.Enabled = false;
            this.CopyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            this.CopyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.CopyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.CopyToolStripMenuItem.Text = "&Copy";
            // 
            // PasteToolStripMenuItem
            // 
            this.PasteToolStripMenuItem.Enabled = false;
            this.PasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem";
            this.PasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.PasteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.PasteToolStripMenuItem.Text = "&Paste";
            // 
            // ToolStripSeparator3
            // 
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(141, 6);
            // 
            // SelectAllToolStripMenuItem
            // 
            this.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem";
            this.SelectAllToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.SelectAllToolStripMenuItem.Text = "Select &All";
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
            this.ListNameCollisionsStripMenuItem2,
            this.ToolStripSeparator4,
            this.ListIDRangesToolStripMenuItem,
            this.ListMaxIDsToolStripMenuItem,
            this.ListTagsToolStripMenuItem});
            this.RollerToolStripMenuItem.Name = "RollerToolStripMenuItem";
            this.RollerToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.RollerToolStripMenuItem.Text = "&Roller";
            // 
            // CheckMapStripMenuItem
            // 
            this.CheckMapStripMenuItem.Name = "CheckMapStripMenuItem";
            this.CheckMapStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.CheckMapStripMenuItem.Text = "Check &Map Adjacency";
            // 
            // ListNameCollisionsStripMenuItem2
            // 
            this.ListNameCollisionsStripMenuItem2.Name = "ListNameCollisionsStripMenuItem2";
            this.ListNameCollisionsStripMenuItem2.Size = new System.Drawing.Size(192, 22);
            this.ListNameCollisionsStripMenuItem2.Text = "List &Name Collisions";
            // 
            // ToolStripSeparator4
            // 
            this.ToolStripSeparator4.Name = "ToolStripSeparator4";
            this.ToolStripSeparator4.Size = new System.Drawing.Size(189, 6);
            // 
            // ListIDRangesToolStripMenuItem
            // 
            this.ListIDRangesToolStripMenuItem.Name = "ListIDRangesToolStripMenuItem";
            this.ListIDRangesToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.ListIDRangesToolStripMenuItem.Text = "List ID &Ranges";
            // 
            // ListMaxIDsToolStripMenuItem
            // 
            this.ListMaxIDsToolStripMenuItem.Name = "ListMaxIDsToolStripMenuItem";
            this.ListMaxIDsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.ListMaxIDsToolStripMenuItem.Text = "List Maximum &IDs";
            // 
            // ListTagsToolStripMenuItem
            // 
            this.ListTagsToolStripMenuItem.Name = "ListTagsToolStripMenuItem";
            this.ListTagsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.ListTagsToolStripMenuItem.Text = "List &Tags";
            // 
            // ToolStripSeparator5
            // 
            this.ToolStripSeparator5.Name = "ToolStripSeparator5";
            this.ToolStripSeparator5.Size = new System.Drawing.Size(113, 6);
            // 
            // OptionsToolStripMenuItem
            // 
            this.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem";
            this.OptionsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.OptionsToolStripMenuItem.Text = "&Options";
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
            this.ScribeHelpToolStripMenuItem.Name = "ScribeHelpToolStripMenuItem";
            this.ScribeHelpToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.ScribeHelpToolStripMenuItem.Text = "Scribe &Help";
            // 
            // DocumentationToolStripMenuItem
            // 
            this.DocumentationToolStripMenuItem.Name = "DocumentationToolStripMenuItem";
            this.DocumentationToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.DocumentationToolStripMenuItem.Text = "Parquet &Documentation";
            // 
            // ToolStripSeparator6
            // 
            this.ToolStripSeparator6.Name = "ToolStripSeparator6";
            this.ToolStripSeparator6.Size = new System.Drawing.Size(198, 6);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.AboutToolStripMenuItem.Text = "&About...";
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
            this.EditorTabs.Controls.Add(this.LibraryTabPage);
            this.EditorTabs.Location = new System.Drawing.Point(12, 111);
            this.EditorTabs.Name = "EditorTabs";
            this.EditorTabs.SelectedIndex = 0;
            this.EditorTabs.Size = new System.Drawing.Size(960, 590);
            this.EditorTabs.TabIndex = 2;
            // 
            // GameTabPage
            // 
            this.GameTabPage.Location = new System.Drawing.Point(4, 22);
            this.GameTabPage.Name = "GameTabPage";
            this.GameTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.GameTabPage.Size = new System.Drawing.Size(952, 564);
            this.GameTabPage.TabIndex = 0;
            this.GameTabPage.Text = "Game";
            // 
            // BeingsTabPage
            // 
            this.BeingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.BeingsTabPage.Name = "BeingsTabPage";
            this.BeingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.BeingsTabPage.Size = new System.Drawing.Size(952, 564);
            this.BeingsTabPage.TabIndex = 1;
            this.BeingsTabPage.Text = "Beings";
            // 
            // BiomesTabPage
            // 
            this.BiomesTabPage.BackColor = System.Drawing.Color.Transparent;
            this.BiomesTabPage.Location = new System.Drawing.Point(4, 22);
            this.BiomesTabPage.Name = "BiomesTabPage";
            this.BiomesTabPage.Size = new System.Drawing.Size(952, 564);
            this.BiomesTabPage.TabIndex = 2;
            this.BiomesTabPage.Text = "Biomes";
            // 
            // CraftingTabPage
            // 
            this.CraftingTabPage.BackColor = System.Drawing.Color.Transparent;
            this.CraftingTabPage.Location = new System.Drawing.Point(4, 22);
            this.CraftingTabPage.Name = "CraftingTabPage";
            this.CraftingTabPage.Size = new System.Drawing.Size(952, 564);
            this.CraftingTabPage.TabIndex = 3;
            this.CraftingTabPage.Text = "Crafting";
            // 
            // ItemsTabPage
            // 
            this.ItemsTabPage.BackColor = System.Drawing.Color.Transparent;
            this.ItemsTabPage.Location = new System.Drawing.Point(4, 22);
            this.ItemsTabPage.Name = "ItemsTabPage";
            this.ItemsTabPage.Size = new System.Drawing.Size(952, 564);
            this.ItemsTabPage.TabIndex = 4;
            this.ItemsTabPage.Text = "Items";
            // 
            // MapsTabPage
            // 
            this.MapsTabPage.BackColor = System.Drawing.Color.Transparent;
            this.MapsTabPage.Location = new System.Drawing.Point(4, 22);
            this.MapsTabPage.Name = "MapsTabPage";
            this.MapsTabPage.Size = new System.Drawing.Size(952, 564);
            this.MapsTabPage.TabIndex = 5;
            this.MapsTabPage.Text = "Maps";
            // 
            // ParquetsTabPage
            // 
            this.ParquetsTabPage.BackColor = System.Drawing.Color.Transparent;
            this.ParquetsTabPage.Location = new System.Drawing.Point(4, 22);
            this.ParquetsTabPage.Name = "ParquetsTabPage";
            this.ParquetsTabPage.Size = new System.Drawing.Size(952, 564);
            this.ParquetsTabPage.TabIndex = 6;
            this.ParquetsTabPage.Text = "Parquets";
            // 
            // RoomsTabPage
            // 
            this.RoomsTabPage.BackColor = System.Drawing.Color.Transparent;
            this.RoomsTabPage.Location = new System.Drawing.Point(4, 22);
            this.RoomsTabPage.Name = "RoomsTabPage";
            this.RoomsTabPage.Size = new System.Drawing.Size(952, 564);
            this.RoomsTabPage.TabIndex = 7;
            this.RoomsTabPage.Text = "Rooms";
            // 
            // ScriptsTabPage
            // 
            this.ScriptsTabPage.BackColor = System.Drawing.Color.Transparent;
            this.ScriptsTabPage.Location = new System.Drawing.Point(4, 22);
            this.ScriptsTabPage.Name = "ScriptsTabPage";
            this.ScriptsTabPage.Size = new System.Drawing.Size(952, 564);
            this.ScriptsTabPage.TabIndex = 8;
            this.ScriptsTabPage.Text = "Scripting";
            // 
            // LibraryTabPage
            // 
            this.LibraryTabPage.BackColor = System.Drawing.Color.Transparent;
            this.LibraryTabPage.Location = new System.Drawing.Point(4, 22);
            this.LibraryTabPage.Name = "LibraryTabPage";
            this.LibraryTabPage.Size = new System.Drawing.Size(952, 564);
            this.LibraryTabPage.TabIndex = 9;
            this.LibraryTabPage.Text = "Library";
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
            this.MainMenuBar.ResumeLayout(false);
            this.MainMenuBar.PerformLayout();
            this.EditorTabs.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem ListNameCollisionsStripMenuItem2;
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
        private System.Windows.Forms.TabPage LibraryTabPage;
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
    }
}

