namespace Scribe
{
    partial class OptionsBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.PanelDefaultFolder = new System.Windows.Forms.Panel();
            this.RadioButtonDefaultToDesktop = new System.Windows.Forms.RadioButton();
            this.RadioButtonDefaultToDocuments = new System.Windows.Forms.RadioButton();
            this.LabelTheme = new System.Windows.Forms.Label();
            this.PanelEditorTheme = new System.Windows.Forms.Panel();
            this.RadioButtonColorfulTheme = new System.Windows.Forms.RadioButton();
            this.RadioButtonOSTheme = new System.Windows.Forms.RadioButton();
            this.LabelSuggestStoryIDs = new System.Windows.Forms.Label();
            this.CheckBoxSuggestStoryIDs = new System.Windows.Forms.CheckBox();
            this.LabelAutoSaveInterval = new System.Windows.Forms.Label();
            this.TextBoxAutoSaveInterval = new System.Windows.Forms.TextBox();
            this.LabelAutoSaveExplanation = new System.Windows.Forms.Label();
            this.LabelDefaultFolder = new System.Windows.Forms.Label();
            this.OkayButton = new System.Windows.Forms.Button();
            this.LabelFlavorFilter = new System.Windows.Forms.Label();
            this.CheckBoxFlavorFilters = new System.Windows.Forms.CheckBox();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.TableLayoutPanel.SuspendLayout();
            this.PanelDefaultFolder.SuspendLayout();
            this.PanelEditorTheme.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // TableLayoutPanel
            // 
            this.TableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel.ColumnCount = 2;
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.TableLayoutPanel.Controls.Add(this.PanelDefaultFolder, 1, 5);
            this.TableLayoutPanel.Controls.Add(this.LabelTheme, 0, 0);
            this.TableLayoutPanel.Controls.Add(this.PanelEditorTheme, 1, 0);
            this.TableLayoutPanel.Controls.Add(this.LabelSuggestStoryIDs, 0, 2);
            this.TableLayoutPanel.Controls.Add(this.CheckBoxSuggestStoryIDs, 1, 2);
            this.TableLayoutPanel.Controls.Add(this.LabelAutoSaveInterval, 0, 3);
            this.TableLayoutPanel.Controls.Add(this.TextBoxAutoSaveInterval, 1, 3);
            this.TableLayoutPanel.Controls.Add(this.LabelAutoSaveExplanation, 1, 4);
            this.TableLayoutPanel.Controls.Add(this.LabelDefaultFolder, 0, 5);
            this.TableLayoutPanel.Controls.Add(this.OkayButton, 1, 7);
            this.TableLayoutPanel.Controls.Add(this.LabelFlavorFilter, 0, 1);
            this.TableLayoutPanel.Controls.Add(this.CheckBoxFlavorFilters, 1, 1);
            this.TableLayoutPanel.Location = new System.Drawing.Point(10, 10);
            this.TableLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TableLayoutPanel.Name = "TableLayoutPanel";
            this.TableLayoutPanel.RowCount = 8;
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TableLayoutPanel.Size = new System.Drawing.Size(486, 306);
            this.TableLayoutPanel.TabIndex = 0;
            // 
            // PanelDefaultFolder
            // 
            this.PanelDefaultFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelDefaultFolder.Controls.Add(this.RadioButtonDefaultToDesktop);
            this.PanelDefaultFolder.Controls.Add(this.RadioButtonDefaultToDocuments);
            this.PanelDefaultFolder.Location = new System.Drawing.Point(163, 153);
            this.PanelDefaultFolder.Name = "PanelDefaultFolder";
            this.PanelDefaultFolder.Size = new System.Drawing.Size(320, 24);
            this.PanelDefaultFolder.TabIndex = 28;
            // 
            // RadioButtonDefaultToDesktop
            // 
            this.RadioButtonDefaultToDesktop.AutoSize = true;
            this.RadioButtonDefaultToDesktop.Checked = true;
            this.RadioButtonDefaultToDesktop.Location = new System.Drawing.Point(0, 5);
            this.RadioButtonDefaultToDesktop.Name = "RadioButtonDefaultToDesktop";
            this.RadioButtonDefaultToDesktop.Size = new System.Drawing.Size(68, 19);
            this.RadioButtonDefaultToDesktop.TabIndex = 1;
            this.RadioButtonDefaultToDesktop.TabStop = true;
            this.RadioButtonDefaultToDesktop.Text = "Desktop";
            this.RadioButtonDefaultToDesktop.UseVisualStyleBackColor = true;
            // 
            // RadioButtonDefaultToDocuments
            // 
            this.RadioButtonDefaultToDocuments.AutoSize = true;
            this.RadioButtonDefaultToDocuments.Location = new System.Drawing.Point(100, 5);
            this.RadioButtonDefaultToDocuments.Name = "RadioButtonDefaultToDocuments";
            this.RadioButtonDefaultToDocuments.Size = new System.Drawing.Size(86, 19);
            this.RadioButtonDefaultToDocuments.TabIndex = 2;
            this.RadioButtonDefaultToDocuments.Text = "Documents";
            this.RadioButtonDefaultToDocuments.UseVisualStyleBackColor = true;
            // 
            // LabelTheme
            // 
            this.LabelTheme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelTheme.AutoSize = true;
            this.LabelTheme.Location = new System.Drawing.Point(3, 0);
            this.LabelTheme.Name = "LabelTheme";
            this.LabelTheme.Size = new System.Drawing.Size(77, 30);
            this.LabelTheme.TabIndex = 25;
            this.LabelTheme.Text = "Editor Theme";
            this.LabelTheme.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PanelEditorTheme
            // 
            this.PanelEditorTheme.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelEditorTheme.Controls.Add(this.RadioButtonColorfulTheme);
            this.PanelEditorTheme.Controls.Add(this.RadioButtonOSTheme);
            this.PanelEditorTheme.Location = new System.Drawing.Point(163, 3);
            this.PanelEditorTheme.Name = "PanelEditorTheme";
            this.PanelEditorTheme.Size = new System.Drawing.Size(320, 24);
            this.PanelEditorTheme.TabIndex = 28;
            // 
            // RadioButtonColorfulTheme
            // 
            this.RadioButtonColorfulTheme.AutoSize = true;
            this.RadioButtonColorfulTheme.Checked = true;
            this.RadioButtonColorfulTheme.Location = new System.Drawing.Point(0, 5);
            this.RadioButtonColorfulTheme.Name = "RadioButtonColorfulTheme";
            this.RadioButtonColorfulTheme.Size = new System.Drawing.Size(68, 19);
            this.RadioButtonColorfulTheme.TabIndex = 1;
            this.RadioButtonColorfulTheme.TabStop = true;
            this.RadioButtonColorfulTheme.Text = "Colorful";
            this.RadioButtonColorfulTheme.UseVisualStyleBackColor = true;
            // 
            // RadioButtonOSTheme
            // 
            this.RadioButtonOSTheme.AutoSize = true;
            this.RadioButtonOSTheme.Location = new System.Drawing.Point(100, 5);
            this.RadioButtonOSTheme.Name = "RadioButtonOSTheme";
            this.RadioButtonOSTheme.Size = new System.Drawing.Size(81, 19);
            this.RadioButtonOSTheme.TabIndex = 2;
            this.RadioButtonOSTheme.Text = "OS Default";
            this.RadioButtonOSTheme.UseVisualStyleBackColor = true;
            // 
            // LabelSuggestStoryIDs
            // 
            this.LabelSuggestStoryIDs.AutoSize = true;
            this.LabelSuggestStoryIDs.Location = new System.Drawing.Point(3, 60);
            this.LabelSuggestStoryIDs.Name = "LabelSuggestStoryIDs";
            this.LabelSuggestStoryIDs.Size = new System.Drawing.Size(98, 15);
            this.LabelSuggestStoryIDs.TabIndex = 29;
            this.LabelSuggestStoryIDs.Text = "Suggest Story IDs";
            // 
            // CheckBoxSuggestStoryIDs
            // 
            this.CheckBoxSuggestStoryIDs.AutoSize = true;
            this.CheckBoxSuggestStoryIDs.Checked = true;
            this.CheckBoxSuggestStoryIDs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxSuggestStoryIDs.Location = new System.Drawing.Point(163, 63);
            this.CheckBoxSuggestStoryIDs.Name = "CheckBoxSuggestStoryIDs";
            this.CheckBoxSuggestStoryIDs.Size = new System.Drawing.Size(15, 14);
            this.CheckBoxSuggestStoryIDs.TabIndex = 30;
            this.CheckBoxSuggestStoryIDs.UseVisualStyleBackColor = true;
            // 
            // LabelAutoSaveInterval
            // 
            this.LabelAutoSaveInterval.AutoSize = true;
            this.LabelAutoSaveInterval.Location = new System.Drawing.Point(3, 90);
            this.LabelAutoSaveInterval.Name = "LabelAutoSaveInterval";
            this.LabelAutoSaveInterval.Size = new System.Drawing.Size(151, 15);
            this.LabelAutoSaveInterval.TabIndex = 31;
            this.LabelAutoSaveInterval.Text = "Interval Between Autosaves";
            // 
            // TextBoxAutoSaveInterval
            // 
            this.TextBoxAutoSaveInterval.Location = new System.Drawing.Point(163, 93);
            this.TextBoxAutoSaveInterval.Name = "TextBoxAutoSaveInterval";
            this.TextBoxAutoSaveInterval.Size = new System.Drawing.Size(68, 23);
            this.TextBoxAutoSaveInterval.TabIndex = 32;
            this.TextBoxAutoSaveInterval.Text = "5";
            this.TextBoxAutoSaveInterval.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxAutoSaveInterval_Validating);
            // 
            // LabelAutoSaveExplanation
            // 
            this.LabelAutoSaveExplanation.AutoSize = true;
            this.LabelAutoSaveExplanation.Location = new System.Drawing.Point(163, 120);
            this.LabelAutoSaveExplanation.Name = "LabelAutoSaveExplanation";
            this.LabelAutoSaveExplanation.Size = new System.Drawing.Size(255, 15);
            this.LabelAutoSaveExplanation.TabIndex = 33;
            this.LabelAutoSaveExplanation.Text = "Interval is in minutes, 0 to 60.  0 = No autosave.";
            // 
            // LabelDefaultFolder
            // 
            this.LabelDefaultFolder.AutoSize = true;
            this.LabelDefaultFolder.Location = new System.Drawing.Point(3, 150);
            this.LabelDefaultFolder.Name = "LabelDefaultFolder";
            this.LabelDefaultFolder.Size = new System.Drawing.Size(81, 15);
            this.LabelDefaultFolder.TabIndex = 34;
            this.LabelDefaultFolder.Text = "Default Folder";
            // 
            // OkayButton
            // 
            this.OkayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkayButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.OkayButton.Location = new System.Drawing.Point(394, 281);
            this.OkayButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.OkayButton.Name = "OkayButton";
            this.OkayButton.Size = new System.Drawing.Size(88, 22);
            this.OkayButton.TabIndex = 24;
            this.OkayButton.Text = "&OK";
            // 
            // LabelFlavorFilter
            // 
            this.LabelFlavorFilter.AutoSize = true;
            this.LabelFlavorFilter.Location = new System.Drawing.Point(3, 30);
            this.LabelFlavorFilter.Name = "LabelFlavorFilter";
            this.LabelFlavorFilter.Size = new System.Drawing.Size(95, 15);
            this.LabelFlavorFilter.TabIndex = 35;
            this.LabelFlavorFilter.Text = "Use Flavor Filters";
            // 
            // CheckBoxFlavorFilters
            // 
            this.CheckBoxFlavorFilters.AutoSize = true;
            this.CheckBoxFlavorFilters.Checked = true;
            this.CheckBoxFlavorFilters.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxFlavorFilters.Location = new System.Drawing.Point(163, 33);
            this.CheckBoxFlavorFilters.Name = "CheckBoxFlavorFilters";
            this.CheckBoxFlavorFilters.Size = new System.Drawing.Size(15, 14);
            this.CheckBoxFlavorFilters.TabIndex = 36;
            this.CheckBoxFlavorFilters.UseVisualStyleBackColor = true;
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // OptionsBox
            // 
            this.AcceptButton = this.OkayButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 327);
            this.Controls.Add(this.TableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsBox";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Scribe Options";
            this.TableLayoutPanel.ResumeLayout(false);
            this.TableLayoutPanel.PerformLayout();
            this.PanelDefaultFolder.ResumeLayout(false);
            this.PanelDefaultFolder.PerformLayout();
            this.PanelEditorTheme.ResumeLayout(false);
            this.PanelEditorTheme.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TableLayoutPanel;
        private System.Windows.Forms.Button OkayButton;
        private System.Windows.Forms.Label LabelTheme;
        private System.Windows.Forms.Panel PanelEditorTheme;
        private System.Windows.Forms.RadioButton RadioButtonColorfulTheme;
        private System.Windows.Forms.RadioButton RadioButtonOSTheme;
        private System.Windows.Forms.Panel PanelDefaultFolder;
        private System.Windows.Forms.RadioButton RadioButtonDefaultToDesktop;
        private System.Windows.Forms.RadioButton RadioButtonDefaultToDocuments;
        private System.Windows.Forms.Label LabelSuggestStoryIDs;
        private System.Windows.Forms.CheckBox CheckBoxSuggestStoryIDs;
        private System.Windows.Forms.Label LabelAutoSaveInterval;
        private System.Windows.Forms.TextBox TextBoxAutoSaveInterval;
        private System.Windows.Forms.Label LabelAutoSaveExplanation;
        private System.Windows.Forms.Label LabelDefaultFolder;
        private System.Windows.Forms.Label LabelFlavorFilter;
        private System.Windows.Forms.CheckBox CheckBoxFlavorFilters;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
    }
}
