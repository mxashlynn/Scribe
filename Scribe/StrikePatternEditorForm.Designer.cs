namespace Scribe
{
    partial class StrikePatternEditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.StrikePatternTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButtonControl = new System.Windows.Forms.Button();
            this.DiagramPictureBox1 = new System.Windows.Forms.PictureBox();
            this.StrikePatternTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DiagramPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // StrikePatternTableLayoutPanel
            // 
            this.StrikePatternTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StrikePatternTableLayoutPanel.ColumnCount = 4;
            this.StrikePatternTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.StrikePatternTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.StrikePatternTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.StrikePatternTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.StrikePatternTableLayoutPanel.Controls.Add(this.SaveButton, 3, 4);
            this.StrikePatternTableLayoutPanel.Controls.Add(this.CancelButtonControl, 2, 4);
            this.StrikePatternTableLayoutPanel.Controls.Add(this.DiagramPictureBox1, 0, 0);
            this.StrikePatternTableLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.StrikePatternTableLayoutPanel.Name = "StrikePatternTableLayoutPanel";
            this.StrikePatternTableLayoutPanel.RowCount = 5;
            this.StrikePatternTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.StrikePatternTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.StrikePatternTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.StrikePatternTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.StrikePatternTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.StrikePatternTableLayoutPanel.Size = new System.Drawing.Size(760, 417);
            this.StrikePatternTableLayoutPanel.TabIndex = 0;
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(667, 391);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(90, 23);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // CancelButtonControl
            // 
            this.CancelButtonControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButtonControl.Location = new System.Drawing.Point(477, 391);
            this.CancelButtonControl.Name = "CancelButtonControl";
            this.CancelButtonControl.Size = new System.Drawing.Size(90, 23);
            this.CancelButtonControl.TabIndex = 1;
            this.CancelButtonControl.Text = "Cancel";
            this.CancelButtonControl.UseVisualStyleBackColor = true;
            // 
            // DiagramPictureBox1
            // 
            this.DiagramPictureBox1.Location = new System.Drawing.Point(3, 3);
            this.DiagramPictureBox1.Name = "DiagramPictureBox1";
            this.DiagramPictureBox1.Size = new System.Drawing.Size(100, 50);
            this.DiagramPictureBox1.TabIndex = 2;
            this.DiagramPictureBox1.TabStop = false;
            // 
            // StrikePatternEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.StrikePatternTableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "StrikePatternEditorForm";
            this.Text = "Strike Pattern Editor";
            this.StrikePatternTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DiagramPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel StrikePatternTableLayoutPanel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButtonControl;
        private System.Windows.Forms.PictureBox DiagramPictureBox1;
    }
}