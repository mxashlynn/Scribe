
namespace Scribe.CustomControls
{
    partial class MapPictureGrid
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MapPictureGrid
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Lavender;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "MapPictureGrid";
            this.Size = new System.Drawing.Size(1280, 720);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MapPictureGrid_MouseDown);
            this.MouseHover += new System.EventHandler(this.MapPictureGrid_MouseHover);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MapPictureGrid_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
