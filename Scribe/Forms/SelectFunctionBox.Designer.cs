namespace Scribe.Forms
{
    partial class SelectFunctionBox
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
            this.FunctionTagLabel = new System.Windows.Forms.Label();
            this.NewTagComboBox = new System.Windows.Forms.ComboBox();
            this.TableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanel
            // 
            this.TableLayoutPanel.ColumnCount = 2;
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel.Controls.Add(this.CancelButtonControl, 0, 1);
            this.TableLayoutPanel.Controls.Add(this.OkayButton, 1, 1);
            this.TableLayoutPanel.Controls.Add(this.FunctionTagLabel, 0, 0);
            this.TableLayoutPanel.Controls.Add(this.NewTagComboBox, 1, 0);
            this.TableLayoutPanel.Location = new System.Drawing.Point(9, 9);
            this.TableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.TableLayoutPanel.Name = "TableLayoutPanel";
            this.TableLayoutPanel.RowCount = 2;
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TableLayoutPanel.Size = new System.Drawing.Size(258, 62);
            this.TableLayoutPanel.TabIndex = 0;
            // 
            // CancelButtonControl
            // 
            this.CancelButtonControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CancelButtonControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButtonControl.Location = new System.Drawing.Point(3, 36);
            this.CancelButtonControl.Name = "CancelButtonControl";
            this.CancelButtonControl.Size = new System.Drawing.Size(74, 23);
            this.CancelButtonControl.TabIndex = 2;
            this.CancelButtonControl.Text = "Cancel";
            this.CancelButtonControl.UseVisualStyleBackColor = true;
            this.CancelButtonControl.Click += new System.EventHandler(this.CancelButtonControl_Click);
            // 
            // OkayButton
            // 
            this.OkayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkayButton.Location = new System.Drawing.Point(180, 36);
            this.OkayButton.Name = "OkayButton";
            this.OkayButton.Size = new System.Drawing.Size(75, 23);
            this.OkayButton.TabIndex = 1;
            this.OkayButton.Text = "&OK";
            this.OkayButton.UseVisualStyleBackColor = true;
            this.OkayButton.Click += new System.EventHandler(this.OkayButton_Click);
            // 
            // FunctionTagLabel
            // 
            this.FunctionTagLabel.AutoSize = true;
            this.FunctionTagLabel.Location = new System.Drawing.Point(3, 0);
            this.FunctionTagLabel.Name = "FunctionTagLabel";
            this.FunctionTagLabel.Size = new System.Drawing.Size(88, 15);
            this.FunctionTagLabel.TabIndex = 1;
            this.FunctionTagLabel.Text = "Select Function";
            // 
            // NewTagComboBox
            // 
            this.NewTagComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewTagComboBox.Items.AddRange(new object[] {
            "(None)",
            "GroundFertile",
            "GroundSterile",
            "BarrierSolidNatural",
            "BarrierSolidArteficial",
            "BarrierFluid",
            "PlantLarge",
            "PlantMedium",
            "PlantSmall",
            "OverlayResidue",
            "OverlayGroundCovering",
            "OverlayBridge",
            "Seat",
            "Door",
            "Fence",
            "StorageContainer",
            "StorageSurface",
            "Bed",
            "CraftingStation"});
            this.NewTagComboBox.Location = new System.Drawing.Point(97, 3);
            this.NewTagComboBox.Name = "NewTagComboBox";
            this.NewTagComboBox.Size = new System.Drawing.Size(158, 23);
            this.NewTagComboBox.TabIndex = 0;
            // 
            // SelectFunctionBox
            // 
            this.AcceptButton = this.OkayButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButtonControl;
            this.ClientSize = new System.Drawing.Size(276, 80);
            this.ControlBox = false;
            this.Controls.Add(this.TableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(292, 119);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(292, 119);
            this.Name = "SelectFunctionBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Function";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AddTagBox_Load);
            this.TableLayoutPanel.ResumeLayout(false);
            this.TableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.TableLayoutPanel TableLayoutPanel;
        private System.Windows.Forms.Button OkayButton;
        private System.Windows.Forms.Label FunctionTagLabel;
        private System.Windows.Forms.ComboBox NewTagComboBox;
        private System.Windows.Forms.Button CancelButtonControl;
    }
}
