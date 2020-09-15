namespace Scribe
{
    partial class AddTagBox
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
            this.TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CancelButtonControl = new System.Windows.Forms.Button();
            this.OkayButton = new System.Windows.Forms.Button();
            this.NewTagLabel = new System.Windows.Forms.Label();
            this.NewTagTextBox = new System.Windows.Forms.TextBox();
            this.TableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanel
            // 
            this.TableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel.ColumnCount = 2;
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel.Controls.Add(this.CancelButtonControl, 0, 1);
            this.TableLayoutPanel.Controls.Add(this.OkayButton, 1, 1);
            this.TableLayoutPanel.Controls.Add(this.NewTagLabel, 0, 0);
            this.TableLayoutPanel.Controls.Add(this.NewTagTextBox, 1, 0);
            this.TableLayoutPanel.Location = new System.Drawing.Point(13, 13);
            this.TableLayoutPanel.Name = "TableLayoutPanel";
            this.TableLayoutPanel.RowCount = 2;
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TableLayoutPanel.Size = new System.Drawing.Size(258, 85);
            this.TableLayoutPanel.TabIndex = 0;
            // 
            // CancelButtonControl
            // 
            this.CancelButtonControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButtonControl.Location = new System.Drawing.Point(3, 59);
            this.CancelButtonControl.Name = "CancelButtonControl";
            this.CancelButtonControl.Size = new System.Drawing.Size(74, 23);
            this.CancelButtonControl.TabIndex = 2;
            this.CancelButtonControl.Text = "Cancel";
            this.CancelButtonControl.UseVisualStyleBackColor = true;
            this.CancelButtonControl.Click += new System.EventHandler(this.CancelButtonControl_Click);
            // 
            // OkayButton
            // 
            this.OkayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkayButton.Location = new System.Drawing.Point(180, 59);
            this.OkayButton.Name = "OkayButton";
            this.OkayButton.Size = new System.Drawing.Size(75, 23);
            this.OkayButton.TabIndex = 1;
            this.OkayButton.Text = "&OK";
            this.OkayButton.UseVisualStyleBackColor = true;
            this.OkayButton.Click += new System.EventHandler(this.OkayButton_Click);
            // 
            // NewTagLabel
            // 
            this.NewTagLabel.AutoSize = true;
            this.NewTagLabel.Location = new System.Drawing.Point(3, 0);
            this.NewTagLabel.Name = "NewTagLabel";
            this.NewTagLabel.Size = new System.Drawing.Size(52, 15);
            this.NewTagLabel.TabIndex = 1;
            this.NewTagLabel.Text = "New Tag";
            // 
            // NewTagTextBox
            // 
            this.NewTagTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewTagTextBox.Location = new System.Drawing.Point(83, 3);
            this.NewTagTextBox.Multiline = true;
            this.NewTagTextBox.Name = "NewTagTextBox";
            this.NewTagTextBox.Size = new System.Drawing.Size(172, 49);
            this.NewTagTextBox.TabIndex = 0;
            this.NewTagTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.NewTagTextBox_Validating);
            // 
            // AddTagBox
            // 
            this.AcceptButton = this.OkayButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButtonControl;
            this.ClientSize = new System.Drawing.Size(284, 111);
            this.Controls.Add(this.TableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 150);
            this.Name = "AddTagBox";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Tag";
            this.Load += new System.EventHandler(this.AddTagBox_Load);
            this.TableLayoutPanel.ResumeLayout(false);
            this.TableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TableLayoutPanel;
        private System.Windows.Forms.Button OkayButton;
        private System.Windows.Forms.Label NewTagLabel;
        private System.Windows.Forms.TextBox NewTagTextBox;
        private System.Windows.Forms.Button CancelButtonControl;
    }
}
