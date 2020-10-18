namespace Scribe
{
    partial class AddQuestBox
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
            this.AddQuestTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.QuestLabel = new System.Windows.Forms.Label();
            this.CancelButtonControl = new System.Windows.Forms.Button();
            this.OkayButton = new System.Windows.Forms.Button();
            this.AddQuestComboBox = new System.Windows.Forms.ComboBox();
            this.AddQuestTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddQuestTableLayoutPanel
            // 
            this.AddQuestTableLayoutPanel.ColumnCount = 2;
            this.AddQuestTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.AddQuestTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AddQuestTableLayoutPanel.Controls.Add(this.QuestLabel, 0, 0);
            this.AddQuestTableLayoutPanel.Controls.Add(this.CancelButtonControl, 0, 1);
            this.AddQuestTableLayoutPanel.Controls.Add(this.OkayButton, 1, 1);
            this.AddQuestTableLayoutPanel.Controls.Add(this.AddQuestComboBox, 1, 0);
            this.AddQuestTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddQuestTableLayoutPanel.Location = new System.Drawing.Point(10, 10);
            this.AddQuestTableLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AddQuestTableLayoutPanel.Name = "AddQuestTableLayoutPanel";
            this.AddQuestTableLayoutPanel.RowCount = 2;
            this.AddQuestTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.AddQuestTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.AddQuestTableLayoutPanel.Size = new System.Drawing.Size(264, 63);
            this.AddQuestTableLayoutPanel.TabIndex = 0;
            // 
            // QuestLabel
            // 
            this.QuestLabel.AutoSize = true;
            this.QuestLabel.Location = new System.Drawing.Point(3, 0);
            this.QuestLabel.Name = "QuestLabel";
            this.QuestLabel.Size = new System.Drawing.Size(38, 15);
            this.QuestLabel.TabIndex = 1;
            this.QuestLabel.Text = "Quest";
            // 
            // CancelButtonControl
            // 
            this.CancelButtonControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButtonControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButtonControl.Location = new System.Drawing.Point(3, 37);
            this.CancelButtonControl.Name = "CancelButtonControl";
            this.CancelButtonControl.Size = new System.Drawing.Size(74, 23);
            this.CancelButtonControl.TabIndex = 9;
            this.CancelButtonControl.Text = "Cancel";
            this.CancelButtonControl.UseVisualStyleBackColor = true;
            // 
            // OkayButton
            // 
            this.OkayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkayButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.OkayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkayButton.Location = new System.Drawing.Point(185, 37);
            this.OkayButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.OkayButton.Name = "OkayButton";
            this.OkayButton.Size = new System.Drawing.Size(75, 23);
            this.OkayButton.TabIndex = 24;
            this.OkayButton.Text = "&OK";
            // 
            // AddQuestComboBox
            // 
            this.AddQuestComboBox.FormattingEnabled = true;
            this.AddQuestComboBox.Location = new System.Drawing.Point(83, 3);
            this.AddQuestComboBox.Name = "AddQuestComboBox";
            this.AddQuestComboBox.Size = new System.Drawing.Size(177, 23);
            this.AddQuestComboBox.TabIndex = 25;
            // 
            // AddQuestBox
            // 
            this.AcceptButton = this.OkayButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButtonControl;
            this.ClientSize = new System.Drawing.Size(284, 83);
            this.ControlBox = false;
            this.Controls.Add(this.AddQuestTableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 122);
            this.Name = "AddQuestBox";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Quest";
            this.Load += new System.EventHandler(this.AddQuestBox_Load);
            this.AddQuestTableLayoutPanel.ResumeLayout(false);
            this.AddQuestTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel AddQuestTableLayoutPanel;
        private System.Windows.Forms.Button OkayButton;
        private System.Windows.Forms.Button CancelButtonControl;
        private System.Windows.Forms.Label QuestLabel;
        private System.Windows.Forms.ComboBox AddQuestComboBox;
    }
}
