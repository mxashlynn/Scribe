namespace Scribe.Forms
{
    partial class MapEditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapEditorForm));
            this.components = new System.ComponentModel.Container();
            this.MapGrid = new ParquetCustomControls.MapPictureGrid();
            this.SuspendLayout();

            // 
            // MapGrid
            // 
            this.MapGrid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MapGrid.BackColor = System.Drawing.Color.Lavender;
            this.MapGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MapGrid.Controller = this;
            this.MapGrid.Location = new System.Drawing.Point(10, 10);
            this.MapGrid.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MapGrid.MinimumSize = new System.Drawing.Size(1280, 720);
            this.MapGrid.Name = "MapGrid";
            this.MapGrid.Size = new System.Drawing.Size(1280, 720);
            this.MapGrid.TabIndex = 0;
            // 
            // MapEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 740);
            this.Controls.Add(this.MapGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MapEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Map Editor Form";
            this.ResumeLayout(false);
        }
        #endregion

        private ParquetCustomControls.MapPictureGrid MapGrid;
    }
}
