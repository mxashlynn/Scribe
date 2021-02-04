namespace Scribe
{
    partial class SplashScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.TableLayoutPanelSplashScreen = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonLoadProject = new System.Windows.Forms.Button();
            this.ButtonNewProject = new System.Windows.Forms.Button();
            this.PictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.LabelTitle = new System.Windows.Forms.Label();
            this.LabelTagLine = new System.Windows.Forms.Label();
            this.ButtonExitScribe = new System.Windows.Forms.Button();
            this.LinkLabelMostRecent = new System.Windows.Forms.LinkLabel();
            this.LabelRecent = new System.Windows.Forms.Label();
            this.TableLayoutPanelSplashScreen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // TableLayoutPanelSplashScreen
            // 
            this.TableLayoutPanelSplashScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanelSplashScreen.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.TableLayoutPanelSplashScreen.ColumnCount = 4;
            this.TableLayoutPanelSplashScreen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33221F));
            this.TableLayoutPanelSplashScreen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66945F));
            this.TableLayoutPanelSplashScreen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66945F));
            this.TableLayoutPanelSplashScreen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3289F));
            this.TableLayoutPanelSplashScreen.Controls.Add(this.ButtonLoadProject, 1, 2);
            this.TableLayoutPanelSplashScreen.Controls.Add(this.ButtonNewProject, 0, 2);
            this.TableLayoutPanelSplashScreen.Controls.Add(this.PictureBoxLogo, 0, 0);
            this.TableLayoutPanelSplashScreen.Controls.Add(this.LabelTitle, 2, 0);
            this.TableLayoutPanelSplashScreen.Controls.Add(this.LabelTagLine, 0, 3);
            this.TableLayoutPanelSplashScreen.Controls.Add(this.ButtonExitScribe, 3, 2);
            this.TableLayoutPanelSplashScreen.Controls.Add(this.LinkLabelMostRecent, 3, 1);
            this.TableLayoutPanelSplashScreen.Controls.Add(this.LabelRecent, 2, 1);
            this.TableLayoutPanelSplashScreen.Location = new System.Drawing.Point(12, 12);
            this.TableLayoutPanelSplashScreen.Name = "TableLayoutPanelSplashScreen";
            this.TableLayoutPanelSplashScreen.RowCount = 4;
            this.TableLayoutPanelSplashScreen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.TableLayoutPanelSplashScreen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanelSplashScreen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TableLayoutPanelSplashScreen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.TableLayoutPanelSplashScreen.Size = new System.Drawing.Size(499, 342);
            this.TableLayoutPanelSplashScreen.TabIndex = 0;
            // 
            // ButtonLoadProject
            // 
            this.ButtonLoadProject.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TableLayoutPanelSplashScreen.SetColumnSpan(this.ButtonLoadProject, 2);
            this.ButtonLoadProject.Location = new System.Drawing.Point(185, 290);
            this.ButtonLoadProject.Name = "ButtonLoadProject";
            this.ButtonLoadProject.Size = new System.Drawing.Size(128, 23);
            this.ButtonLoadProject.TabIndex = 7;
            this.ButtonLoadProject.Text = "Load Project";
            this.ButtonLoadProject.UseVisualStyleBackColor = true;
            this.ButtonLoadProject.Click += new System.EventHandler(this.ButtonLoadProject_Click);
            // 
            // ButtonNewProject
            // 
            this.ButtonNewProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonNewProject.Location = new System.Drawing.Point(35, 290);
            this.ButtonNewProject.Name = "ButtonNewProject";
            this.ButtonNewProject.Size = new System.Drawing.Size(128, 23);
            this.ButtonNewProject.TabIndex = 7;
            this.ButtonNewProject.Text = "New Project";
            this.ButtonNewProject.UseVisualStyleBackColor = true;
            this.ButtonNewProject.Click += new System.EventHandler(this.ButtonNewProject_Click);
            // 
            // PictureBoxLogo
            // 
            this.PictureBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.TableLayoutPanelSplashScreen.SetColumnSpan(this.PictureBoxLogo, 2);
            this.PictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("PictureBoxLogo.Image")));
            this.PictureBoxLogo.Location = new System.Drawing.Point(3, 3);
            this.PictureBoxLogo.Name = "PictureBoxLogo";
            this.TableLayoutPanelSplashScreen.SetRowSpan(this.PictureBoxLogo, 2);
            this.PictureBoxLogo.Size = new System.Drawing.Size(242, 231);
            this.PictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxLogo.TabIndex = 0;
            this.PictureBoxLogo.TabStop = false;
            // 
            // LabelTitle
            // 
            this.LabelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelTitle.AutoSize = true;
            this.TableLayoutPanelSplashScreen.SetColumnSpan(this.LabelTitle, 2);
            this.LabelTitle.Font = new System.Drawing.Font("Arial Narrow", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LabelTitle.Location = new System.Drawing.Point(252, 0);
            this.LabelTitle.Name = "LabelTitle";
            this.LabelTitle.Size = new System.Drawing.Size(244, 43);
            this.LabelTitle.TabIndex = 1;
            this.LabelTitle.Text = "Parquet Scribe";
            // 
            // LabelTagLine
            // 
            this.LabelTagLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelTagLine.AutoSize = true;
            this.TableLayoutPanelSplashScreen.SetColumnSpan(this.LabelTagLine, 4);
            this.LabelTagLine.Location = new System.Drawing.Point(3, 327);
            this.LabelTagLine.Name = "LabelTagLine";
            this.LabelTagLine.Size = new System.Drawing.Size(493, 15);
            this.LabelTagLine.TabIndex = 3;
            this.LabelTagLine.Text = "An editor for 2D building, crafting, and narrative sandbox games.";
            this.LabelTagLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ButtonExitScribe
            // 
            this.ButtonExitScribe.Location = new System.Drawing.Point(335, 290);
            this.ButtonExitScribe.Name = "ButtonExitScribe";
            this.ButtonExitScribe.Size = new System.Drawing.Size(128, 23);
            this.ButtonExitScribe.TabIndex = 7;
            this.ButtonExitScribe.Text = "Exit Scribe";
            this.ButtonExitScribe.UseVisualStyleBackColor = true;
            this.ButtonExitScribe.Click += new System.EventHandler(this.ButtonExitScribe_Click);
            // 
            // LinkLabelMostRecent
            // 
            this.LinkLabelMostRecent.AutoSize = true;
            this.LinkLabelMostRecent.Location = new System.Drawing.Point(335, 55);
            this.LinkLabelMostRecent.Name = "LinkLabelMostRecent";
            this.LinkLabelMostRecent.Size = new System.Drawing.Size(107, 15);
            this.LinkLabelMostRecent.TabIndex = 8;
            this.LinkLabelMostRecent.TabStop = true;
            this.LinkLabelMostRecent.Text = "No Recent Projects";
            this.LinkLabelMostRecent.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelMostRecent_LinkClicked);
            // 
            // LabelRecent
            // 
            this.LabelRecent.AutoSize = true;
            this.LabelRecent.Location = new System.Drawing.Point(252, 55);
            this.LabelRecent.Name = "LabelRecent";
            this.LabelRecent.Size = new System.Drawing.Size(46, 15);
            this.LabelRecent.TabIndex = 9;
            this.LabelRecent.Text = "Recent:";
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(523, 366);
            this.ControlBox = false;
            this.Controls.Add(this.TableLayoutPanelSplashScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(523, 366);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(523, 366);
            this.Name = "SplashScreen";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scribe";
            this.TableLayoutPanelSplashScreen.ResumeLayout(false);
            this.TableLayoutPanelSplashScreen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TableLayoutPanelSplashScreen;
        private System.Windows.Forms.PictureBox PictureBoxLogo;
        private System.Windows.Forms.Label LabelTitle;
        private System.Windows.Forms.Label LabelTagLine;
        private System.Windows.Forms.Button ButtonNewProject;
        private System.Windows.Forms.Button ButtonExitScribe;
        private System.Windows.Forms.Button ButtonLoadProject;
        private System.Windows.Forms.LinkLabel LinkLabelMostRecent;
        private System.Windows.Forms.Label LabelRecent;
    }
}
