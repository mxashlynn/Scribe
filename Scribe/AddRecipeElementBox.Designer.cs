namespace Scribe
{
    partial class AddRecipeElementBox
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
            this.ElementTagLabel = new System.Windows.Forms.Label();
            this.ElementTagTextBox = new System.Windows.Forms.TextBox();
            this.ElementAmountLabel = new System.Windows.Forms.Label();
            this.ElementAmountTextBox = new System.Windows.Forms.TextBox();
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
            this.TableLayoutPanel.Controls.Add(this.CancelButtonControl, 0, 2);
            this.TableLayoutPanel.Controls.Add(this.OkayButton, 1, 2);
            this.TableLayoutPanel.Controls.Add(this.ElementTagLabel, 0, 0);
            this.TableLayoutPanel.Controls.Add(this.ElementTagTextBox, 1, 0);
            this.TableLayoutPanel.Controls.Add(this.ElementAmountLabel, 0, 1);
            this.TableLayoutPanel.Controls.Add(this.ElementAmountTextBox, 1, 1);
            this.TableLayoutPanel.Location = new System.Drawing.Point(13, 13);
            this.TableLayoutPanel.Name = "TableLayoutPanel";
            this.TableLayoutPanel.RowCount = 3;
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TableLayoutPanel.Size = new System.Drawing.Size(258, 115);
            this.TableLayoutPanel.TabIndex = 1;
            // 
            // CancelButtonControl
            // 
            this.CancelButtonControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButtonControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButtonControl.Location = new System.Drawing.Point(3, 89);
            this.CancelButtonControl.Name = "CancelButtonControl";
            this.CancelButtonControl.Size = new System.Drawing.Size(74, 23);
            this.CancelButtonControl.TabIndex = 8;
            this.CancelButtonControl.Text = "Cancel";
            this.CancelButtonControl.UseVisualStyleBackColor = true;
            this.CancelButtonControl.Click += new System.EventHandler(this.CancelButtonControl_Click);
            // 
            // OkayButton
            // 
            this.OkayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkayButton.Location = new System.Drawing.Point(180, 89);
            this.OkayButton.Name = "OkayButton";
            this.OkayButton.Size = new System.Drawing.Size(75, 23);
            this.OkayButton.TabIndex = 3;
            this.OkayButton.Text = "&OK";
            this.OkayButton.UseVisualStyleBackColor = true;
            this.OkayButton.Click += new System.EventHandler(this.OkayButton_Click);
            // 
            // ElementTagLabel
            // 
            this.ElementTagLabel.AutoSize = true;
            this.ElementTagLabel.Location = new System.Drawing.Point(3, 0);
            this.ElementTagLabel.Name = "ElementTagLabel";
            this.ElementTagLabel.Size = new System.Drawing.Size(52, 15);
            this.ElementTagLabel.TabIndex = 4;
            this.ElementTagLabel.Text = "New Tag";
            // 
            // ElementTagTextBox
            // 
            this.ElementTagTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ElementTagTextBox.Location = new System.Drawing.Point(83, 3);
            this.ElementTagTextBox.Multiline = true;
            this.ElementTagTextBox.Name = "ElementTagTextBox";
            this.ElementTagTextBox.Size = new System.Drawing.Size(172, 49);
            this.ElementTagTextBox.TabIndex = 5;
            this.ElementTagTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.ElementTagTextBox_Validating);
            // 
            // ElementAmountLabel
            // 
            this.ElementAmountLabel.AutoSize = true;
            this.ElementAmountLabel.Location = new System.Drawing.Point(3, 55);
            this.ElementAmountLabel.Name = "ElementAmountLabel";
            this.ElementAmountLabel.Size = new System.Drawing.Size(51, 15);
            this.ElementAmountLabel.TabIndex = 6;
            this.ElementAmountLabel.Text = "Amount";
            // 
            // ElementAmountTextBox
            // 
            this.ElementAmountTextBox.Location = new System.Drawing.Point(83, 58);
            this.ElementAmountTextBox.Name = "ElementAmountTextBox";
            this.ElementAmountTextBox.Size = new System.Drawing.Size(100, 23);
            this.ElementAmountTextBox.TabIndex = 7;
            this.ElementAmountTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.ElementAmountTextBox_Validating);
            // 
            // AddRecipeElementBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButtonControl;
            this.ClientSize = new System.Drawing.Size(284, 141);
            this.Controls.Add(this.TableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 180);
            this.Name = "AddRecipeElementBox";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Recipe Element";
            this.Load += new System.EventHandler(this.AddRecipeElementBox_Load);
            this.TableLayoutPanel.ResumeLayout(false);
            this.TableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TableLayoutPanel;
        private System.Windows.Forms.Button OkayButton;
        private System.Windows.Forms.Button CancelButtonControl;
        private System.Windows.Forms.Label ElementTagLabel;
        private System.Windows.Forms.TextBox ElementTagTextBox;
        private System.Windows.Forms.Label ElementAmountLabel;
        private System.Windows.Forms.TextBox ElementAmountTextBox;
    }
}
