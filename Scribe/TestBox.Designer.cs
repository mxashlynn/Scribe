
namespace Scribe
{
    partial class TestBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestBox));
            this.TestPixelBox = new Scribe.CustomControls.PixelBox();
            ((System.ComponentModel.ISupportInitialize)(this.TestPixelBox)).BeginInit();
            this.SuspendLayout();
            // 
            // TestPixelBox
            // 
            this.TestPixelBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TestPixelBox.BackColor = System.Drawing.Color.Transparent;
            this.TestPixelBox.Image = ((System.Drawing.Image)(resources.GetObject("TestPixelBox.Image")));
            this.TestPixelBox.Location = new System.Drawing.Point(434, 254);
            this.TestPixelBox.Name = "TestPixelBox";
            this.TestPixelBox.Size = new System.Drawing.Size(60, 60);
            this.TestPixelBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.TestPixelBox.TabIndex = 0;
            this.TestPixelBox.TabStop = false;
            // 
            // TestBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 327);
            this.Controls.Add(this.TestPixelBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TestBox";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TestBox";
            ((System.ComponentModel.ISupportInitialize)(this.TestPixelBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControls.PixelBox TestPixelBox;
    }
}
