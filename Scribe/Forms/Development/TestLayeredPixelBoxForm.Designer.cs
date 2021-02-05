
namespace Scribe.Forms.Development
{
    partial class TestLayeredPixelBoxForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestLayeredPixelBoxForm));
            this.TestPixelBox = new Scribe.CustomControls.PixelBox();
            this.TestLayeredPixelBox1 = new Scribe.CustomControls.LayeredPixelBox();
            this.TestLayeredPixelBox2 = new Scribe.CustomControls.LayeredPixelBox();
            this.TestLayeredPixelBox3 = new Scribe.CustomControls.LayeredPixelBox();
            this.TestLayeredPixelBox4 = new Scribe.CustomControls.LayeredPixelBox();
            this.TestPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.TestPixelBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestLayeredPixelBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestLayeredPixelBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestLayeredPixelBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestLayeredPixelBox4)).BeginInit();
            this.TestPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TestPixelBox
            // 
            this.TestPixelBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TestPixelBox.BackColor = System.Drawing.Color.Transparent;
            this.TestPixelBox.Image = ((System.Drawing.Image)(resources.GetObject("TestPixelBox.Image")));
            this.TestPixelBox.Location = new System.Drawing.Point(131, 60);
            this.TestPixelBox.Name = "TestPixelBox";
            this.TestPixelBox.Size = new System.Drawing.Size(60, 60);
            this.TestPixelBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.TestPixelBox.TabIndex = 0;
            this.TestPixelBox.TabStop = false;
            // 
            // TestLayeredPixelBox1
            // 
            this.TestLayeredPixelBox1.BackColor = System.Drawing.Color.Transparent;
            this.TestLayeredPixelBox1.Image = ((System.Drawing.Image)(resources.GetObject("TestLayeredPixelBox1.Image")));
            this.TestLayeredPixelBox1.Location = new System.Drawing.Point(13, 13);
            this.TestLayeredPixelBox1.Name = "TestLayeredPixelBox1";
            this.TestLayeredPixelBox1.Size = new System.Drawing.Size(40, 40);
            this.TestLayeredPixelBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.TestLayeredPixelBox1.TabIndex = 1;
            this.TestLayeredPixelBox1.TabStop = false;
            // 
            // TestLayeredPixelBox2
            // 
            this.TestLayeredPixelBox2.BackColor = System.Drawing.Color.Transparent;
            this.TestLayeredPixelBox2.Image = ((System.Drawing.Image)(resources.GetObject("TestLayeredPixelBox2.Image")));
            this.TestLayeredPixelBox2.Location = new System.Drawing.Point(59, -10);
            this.TestLayeredPixelBox2.Name = "TestLayeredPixelBox2";
            this.TestLayeredPixelBox2.Size = new System.Drawing.Size(40, 40);
            this.TestLayeredPixelBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.TestLayeredPixelBox2.TabIndex = 2;
            this.TestLayeredPixelBox2.TabStop = false;
            // 
            // TestLayeredPixelBox3
            // 
            this.TestLayeredPixelBox3.BackColor = System.Drawing.Color.Transparent;
            this.TestLayeredPixelBox3.Image = ((System.Drawing.Image)(resources.GetObject("TestLayeredPixelBox3.Image")));
            this.TestLayeredPixelBox3.Location = new System.Drawing.Point(105, -10);
            this.TestLayeredPixelBox3.Name = "TestLayeredPixelBox3";
            this.TestLayeredPixelBox3.Size = new System.Drawing.Size(40, 40);
            this.TestLayeredPixelBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.TestLayeredPixelBox3.TabIndex = 3;
            this.TestLayeredPixelBox3.TabStop = false;
            // 
            // TestLayeredPixelBox4
            // 
            this.TestLayeredPixelBox4.BackColor = System.Drawing.Color.Transparent;
            this.TestLayeredPixelBox4.Image = ((System.Drawing.Image)(resources.GetObject("TestLayeredPixelBox4.Image")));
            this.TestLayeredPixelBox4.Location = new System.Drawing.Point(151, -9);
            this.TestLayeredPixelBox4.Name = "TestLayeredPixelBox4";
            this.TestLayeredPixelBox4.Size = new System.Drawing.Size(40, 40);
            this.TestLayeredPixelBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.TestLayeredPixelBox4.TabIndex = 4;
            this.TestLayeredPixelBox4.TabStop = false;
            // 
            // TestPanel
            // 
            this.TestPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.TestPanel.Controls.Add(this.TestLayeredPixelBox2);
            this.TestPanel.Controls.Add(this.TestLayeredPixelBox3);
            this.TestPanel.Controls.Add(this.TestLayeredPixelBox4);
            this.TestPanel.Location = new System.Drawing.Point(0, 23);
            this.TestPanel.Name = "TestPanel";
            this.TestPanel.Size = new System.Drawing.Size(205, 57);
            this.TestPanel.TabIndex = 5;
            // 
            // TestLayeredPixelBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(206, 131);
            this.Controls.Add(this.TestLayeredPixelBox1);
            this.Controls.Add(this.TestPixelBox);
            this.Controls.Add(this.TestPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TestLayeredPixelBoxForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TestLayeredPixelBoxForm";
            ((System.ComponentModel.ISupportInitialize)(this.TestPixelBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestLayeredPixelBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestLayeredPixelBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestLayeredPixelBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestLayeredPixelBox4)).EndInit();
            this.TestPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControls.PixelBox TestPixelBox;
        private CustomControls.LayeredPixelBox TestLayeredPixelBox1;
        private CustomControls.LayeredPixelBox TestLayeredPixelBox2;
        private CustomControls.LayeredPixelBox TestLayeredPixelBox3;
        private CustomControls.LayeredPixelBox TestLayeredPixelBox4;
        private System.Windows.Forms.Panel TestPanel;
    }
}
