using System.Drawing;

namespace Scribe
{
    partial class EditorForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorForm));
            this.EditorStatusStrip = new System.Windows.Forms.StatusStrip();
            this.MainMenuBar = new System.Windows.Forms.MenuStrip();
            this.SuspendLayout();
            // 
            // EditorStatusStrip
            // 
            this.EditorStatusStrip.AccessibleDescription = "The status of the application.";
            this.EditorStatusStrip.AccessibleName = "Editor Status";
            this.EditorStatusStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.StatusBar;
            this.EditorStatusStrip.Font = SystemFonts.StatusFont;
            this.EditorStatusStrip.Location = new System.Drawing.Point(0, 739);
            this.EditorStatusStrip.Name = "EditorStatusStrip";
            this.EditorStatusStrip.Size = new System.Drawing.Size(984, 22);
            this.EditorStatusStrip.SizingGrip = false;
            this.EditorStatusStrip.TabIndex = 0;
            // 
            // MainMenuBar
            // 
            this.MainMenuBar.AccessibleDescription = "The application\'s menu.";
            this.MainMenuBar.AccessibleName = "Main Menu";
            this.MainMenuBar.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.MainMenuBar.Font = SystemFonts.MenuFont;
            this.MainMenuBar.Location = new System.Drawing.Point(0, 0);
            this.MainMenuBar.Name = "MainMenuBar";
            this.MainMenuBar.Size = new System.Drawing.Size(984, 24);
            this.MainMenuBar.TabIndex = 1;
            this.MainMenuBar.Text = "Main Menu";
            // 
            // EditorForm
            // 
            this.AccessibleDescription = "The primary interactive editor window.";
            this.AccessibleName = "Editor Window";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 761);
            this.Controls.Add(this.EditorStatusStrip);
            this.Controls.Add(this.MainMenuBar);
            this.Font = SystemFonts.DialogFont;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "EditorForm";
            this.Text = "Scribe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip EditorStatusStrip;
        private System.Windows.Forms.MenuStrip MainMenuBar;
    }
}

