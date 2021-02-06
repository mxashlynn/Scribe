namespace Scribe.Forms.Development
{
    partial class TestMapGridForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestMapGridForm));
            this.MapGrid = new Scribe.CustomControls.MapPictureGrid();
            this.SuspendLayout();
            // 
            // MapGrid
            // 
            this.MapGrid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MapGrid.BackColor = System.Drawing.Color.Lavender;
            this.MapGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MapGrid.Location = new System.Drawing.Point(10, 10);
            this.MapGrid.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MapGrid.MinimumSize = new System.Drawing.Size(1280, 720);
            this.MapGrid.Name = "MapGrid";
            this.MapGrid.Size = new System.Drawing.Size(1280, 720);
            this.MapGrid.TabIndex = 0;
            // 
            // TestMapGridForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(206, 200, 239);
            this.ClientSize = new System.Drawing.Size(1300, 740);
            this.Controls.Add(this.MapGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TestMapGridForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Map Grid Test";
            this.ResumeLayout(false);

        }

        #endregion

        private Scribe.CustomControls.MapPictureGrid MapGrid;
    }
}
