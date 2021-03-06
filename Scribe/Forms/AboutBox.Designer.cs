namespace Scribe.Forms
{
    partial class AboutBox
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
            this.AboutTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.LabelFrameworkVersions = new System.Windows.Forms.Label();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.LabelProductName = new System.Windows.Forms.Label();
            this.LabelVersion = new System.Windows.Forms.Label();
            this.LabelCopyright = new System.Windows.Forms.Label();
            this.LabelCompanyName = new System.Windows.Forms.Label();
            this.TextBoxDescription = new System.Windows.Forms.TextBox();
            this.OkayButton = new System.Windows.Forms.Button();
            this.AboutToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.AboutTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // AboutTableLayoutPanel
            // 
            this.AboutTableLayoutPanel.ColumnCount = 2;
            this.AboutTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.25F));
            this.AboutTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.75F));
            this.AboutTableLayoutPanel.Controls.Add(this.LabelFrameworkVersions, 0, 5);
            this.AboutTableLayoutPanel.Controls.Add(this.LogoPictureBox, 0, 0);
            this.AboutTableLayoutPanel.Controls.Add(this.LabelProductName, 1, 0);
            this.AboutTableLayoutPanel.Controls.Add(this.LabelVersion, 1, 1);
            this.AboutTableLayoutPanel.Controls.Add(this.LabelCopyright, 1, 2);
            this.AboutTableLayoutPanel.Controls.Add(this.LabelCompanyName, 1, 3);
            this.AboutTableLayoutPanel.Controls.Add(this.TextBoxDescription, 1, 4);
            this.AboutTableLayoutPanel.Controls.Add(this.OkayButton, 1, 6);
            this.AboutTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AboutTableLayoutPanel.Location = new System.Drawing.Point(10, 10);
            this.AboutTableLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AboutTableLayoutPanel.Name = "AboutTableLayoutPanel";
            this.AboutTableLayoutPanel.RowCount = 7;
            this.AboutTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.AboutTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.AboutTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.AboutTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.AboutTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.AboutTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.AboutTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.AboutTableLayoutPanel.Size = new System.Drawing.Size(487, 307);
            this.AboutTableLayoutPanel.TabIndex = 0;
            // 
            // LabelFrameworkVersions
            // 
            this.LabelFrameworkVersions.AutoSize = true;
            this.LabelFrameworkVersions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelFrameworkVersions.Location = new System.Drawing.Point(7, 196);
            this.LabelFrameworkVersions.Margin = new System.Windows.Forms.Padding(7, 0, 4, 0);
            this.LabelFrameworkVersions.Name = "LabelFrameworkVersions";
            this.LabelFrameworkVersions.Size = new System.Drawing.Size(189, 76);
            this.LabelFrameworkVersions.TabIndex = 0;
            this.LabelFrameworkVersions.Text = "Framework Versions";
            this.LabelFrameworkVersions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LogoPictureBox
            // 
            this.LogoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("LogoPictureBox.Image")));
            this.LogoPictureBox.Location = new System.Drawing.Point(4, 3);
            this.LogoPictureBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.AboutTableLayoutPanel.SetRowSpan(this.LogoPictureBox, 5);
            this.LogoPictureBox.Size = new System.Drawing.Size(192, 190);
            this.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoPictureBox.TabIndex = 12;
            this.LogoPictureBox.TabStop = false;
            // 
            // LabelProductName
            // 
            this.LabelProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelProductName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelProductName.Location = new System.Drawing.Point(207, 0);
            this.LabelProductName.Margin = new System.Windows.Forms.Padding(7, 0, 4, 0);
            this.LabelProductName.MaximumSize = new System.Drawing.Size(0, 20);
            this.LabelProductName.Name = "LabelProductName";
            this.LabelProductName.Size = new System.Drawing.Size(276, 20);
            this.LabelProductName.TabIndex = 19;
            this.LabelProductName.Text = "Product Name";
            this.LabelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelVersion
            // 
            this.LabelVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelVersion.Location = new System.Drawing.Point(207, 30);
            this.LabelVersion.Margin = new System.Windows.Forms.Padding(7, 0, 4, 0);
            this.LabelVersion.MaximumSize = new System.Drawing.Size(0, 20);
            this.LabelVersion.Name = "LabelVersion";
            this.LabelVersion.Size = new System.Drawing.Size(276, 20);
            this.LabelVersion.TabIndex = 0;
            this.LabelVersion.Text = "Version";
            this.LabelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelCopyright
            // 
            this.LabelCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelCopyright.Location = new System.Drawing.Point(207, 60);
            this.LabelCopyright.Margin = new System.Windows.Forms.Padding(7, 0, 4, 0);
            this.LabelCopyright.MaximumSize = new System.Drawing.Size(0, 20);
            this.LabelCopyright.Name = "LabelCopyright";
            this.LabelCopyright.Size = new System.Drawing.Size(276, 20);
            this.LabelCopyright.TabIndex = 21;
            this.LabelCopyright.Text = "Copyright";
            this.LabelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelCompanyName
            // 
            this.LabelCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelCompanyName.Location = new System.Drawing.Point(207, 90);
            this.LabelCompanyName.Margin = new System.Windows.Forms.Padding(7, 0, 4, 0);
            this.LabelCompanyName.MaximumSize = new System.Drawing.Size(0, 20);
            this.LabelCompanyName.Name = "LabelCompanyName";
            this.LabelCompanyName.Size = new System.Drawing.Size(276, 20);
            this.LabelCompanyName.TabIndex = 22;
            this.LabelCompanyName.Text = "Company Name";
            this.LabelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AboutToolTip.SetToolTip(this.LabelCompanyName, "It\'s trans femmes all the way down!");
            // 
            // TextBoxDescription
            // 
            this.TextBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxDescription.Location = new System.Drawing.Point(207, 123);
            this.TextBoxDescription.Margin = new System.Windows.Forms.Padding(7, 3, 4, 3);
            this.TextBoxDescription.Multiline = true;
            this.TextBoxDescription.Name = "TextBoxDescription";
            this.TextBoxDescription.ReadOnly = true;
            this.AboutTableLayoutPanel.SetRowSpan(this.TextBoxDescription, 2);
            this.TextBoxDescription.Size = new System.Drawing.Size(276, 146);
            this.TextBoxDescription.TabIndex = 23;
            this.TextBoxDescription.TabStop = false;
            this.TextBoxDescription.Text = "Description";
            // 
            // OkayButton
            // 
            this.OkayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkayButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.OkayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkayButton.Location = new System.Drawing.Point(395, 277);
            this.OkayButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.OkayButton.Name = "OkayButton";
            this.OkayButton.Size = new System.Drawing.Size(88, 27);
            this.OkayButton.TabIndex = 24;
            this.OkayButton.Text = "&OK";
            this.OkayButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // AboutBox
            // 
            this.AcceptButton = this.OkayButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.OkayButton;
            this.ClientSize = new System.Drawing.Size(507, 327);
            this.Controls.Add(this.AboutTableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AboutBox";
            this.Load += new System.EventHandler(this.AboutBox_Load);
            this.AboutTableLayoutPanel.ResumeLayout(false);
            this.AboutTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel AboutTableLayoutPanel;
        private System.Windows.Forms.PictureBox LogoPictureBox;
        private System.Windows.Forms.Label LabelProductName;
        private System.Windows.Forms.Label LabelVersion;
        private System.Windows.Forms.Label LabelCopyright;
        private System.Windows.Forms.Label LabelCompanyName;
        private System.Windows.Forms.TextBox TextBoxDescription;
        private System.Windows.Forms.Button OkayButton;
        private System.Windows.Forms.ToolTip AboutToolTip;
        private System.Windows.Forms.Label LabelFrameworkVersions;
    }
}
