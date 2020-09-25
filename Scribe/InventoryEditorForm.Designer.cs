namespace Scribe
{
    partial class InventoryEditorForm
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
            this.components = new System.ComponentModel.Container();
            this.CapacityLabel = new System.Windows.Forms.Label();
            this.InventorySlotsLabel = new System.Windows.Forms.Label();
            this.RemoveSlotButton = new System.Windows.Forms.Button();
            this.AddSlotButton = new System.Windows.Forms.Button();
            this.SlotsListBox = new System.Windows.Forms.ListBox();
            this.CapacityTextBox = new System.Windows.Forms.TextBox();
            this.TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.EditorToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.CancelButtonControl = new System.Windows.Forms.Button();
            this.OkayButton = new System.Windows.Forms.Button();
            this.TableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CapacityLabel
            // 
            this.CapacityLabel.AutoSize = true;
            this.CapacityLabel.Location = new System.Drawing.Point(3, 0);
            this.CapacityLabel.Name = "CapacityLabel";
            this.CapacityLabel.Size = new System.Drawing.Size(53, 15);
            this.CapacityLabel.TabIndex = 36;
            this.CapacityLabel.Text = "Capacity";
            // 
            // InventorySlotsLabel
            // 
            this.InventorySlotsLabel.AutoSize = true;
            this.InventorySlotsLabel.Location = new System.Drawing.Point(3, 30);
            this.InventorySlotsLabel.Name = "InventorySlotsLabel";
            this.InventorySlotsLabel.Size = new System.Drawing.Size(85, 15);
            this.InventorySlotsLabel.TabIndex = 38;
            this.InventorySlotsLabel.Text = "Inventory Slots";
            // 
            // RemoveSlotButton
            // 
            this.RemoveSlotButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveSlotButton.Location = new System.Drawing.Point(143, 180);
            this.RemoveSlotButton.Name = "RemoveSlotButton";
            this.RemoveSlotButton.Size = new System.Drawing.Size(124, 23);
            this.RemoveSlotButton.TabIndex = 36;
            this.RemoveSlotButton.Text = "&Remove Slot";
            this.RemoveSlotButton.UseVisualStyleBackColor = true;
            // 
            // AddSlotButton
            // 
            this.AddSlotButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddSlotButton.Location = new System.Drawing.Point(273, 180);
            this.AddSlotButton.Name = "AddSlotButton";
            this.AddSlotButton.Size = new System.Drawing.Size(124, 23);
            this.AddSlotButton.TabIndex = 35;
            this.AddSlotButton.Text = "&Add Slot";
            this.AddSlotButton.UseVisualStyleBackColor = true;
            // 
            // SlotsListBox
            // 
            this.SlotsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TableLayoutPanel.SetColumnSpan(this.SlotsListBox, 2);
            this.SlotsListBox.FormattingEnabled = true;
            this.SlotsListBox.ItemHeight = 15;
            this.SlotsListBox.Location = new System.Drawing.Point(133, 33);
            this.SlotsListBox.Name = "SlotsListBox";
            this.SlotsListBox.Size = new System.Drawing.Size(264, 139);
            this.SlotsListBox.TabIndex = 37;
            // 
            // CapacityTextBox
            // 
            this.CapacityTextBox.Location = new System.Drawing.Point(133, 3);
            this.CapacityTextBox.Name = "CapacityTextBox";
            this.CapacityTextBox.Size = new System.Drawing.Size(124, 23);
            this.CapacityTextBox.TabIndex = 50;
            // 
            // TableLayoutPanel
            // 
            this.TableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel.ColumnCount = 4;
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.TableLayoutPanel.Controls.Add(this.OkayButton, 3, 3);
            this.TableLayoutPanel.Controls.Add(this.CancelButtonControl, 2, 3);
            this.TableLayoutPanel.Controls.Add(this.CapacityLabel, 0, 0);
            this.TableLayoutPanel.Controls.Add(this.InventorySlotsLabel, 0, 1);
            this.TableLayoutPanel.Controls.Add(this.CapacityTextBox, 1, 0);
            this.TableLayoutPanel.Controls.Add(this.SlotsListBox, 1, 1);
            this.TableLayoutPanel.Controls.Add(this.AddSlotButton, 2, 2);
            this.TableLayoutPanel.Controls.Add(this.RemoveSlotButton, 1, 2);
            this.TableLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.TableLayoutPanel.Name = "TableLayoutPanel";
            this.TableLayoutPanel.RowCount = 4;
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TableLayoutPanel.Size = new System.Drawing.Size(530, 237);
            this.TableLayoutPanel.TabIndex = 51;
            // 
            // CancelButtonControl
            // 
            this.CancelButtonControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButtonControl.Location = new System.Drawing.Point(273, 210);
            this.CancelButtonControl.Name = "CancelButtonControl";
            this.CancelButtonControl.Size = new System.Drawing.Size(124, 23);
            this.CancelButtonControl.TabIndex = 52;
            this.CancelButtonControl.Text = "Cancel";
            this.CancelButtonControl.UseVisualStyleBackColor = true;
            // 
            // OkayButton
            // 
            this.OkayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OkayButton.Location = new System.Drawing.Point(403, 210);
            this.OkayButton.Name = "OkayButton";
            this.OkayButton.Size = new System.Drawing.Size(124, 23);
            this.OkayButton.TabIndex = 52;
            this.OkayButton.Text = "&OK";
            this.OkayButton.UseVisualStyleBackColor = true;
            // 
            // InventoryEditorForm
            // 
            this.AcceptButton = this.OkayButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButtonControl;
            this.ClientSize = new System.Drawing.Size(554, 261);
            this.Controls.Add(this.TableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(570, 300);
            this.Name = "InventoryEditorForm";
            this.Text = "Inventories Editor";
            this.Load += new System.EventHandler(this.InventoryEditorForm_Load);
            this.TableLayoutPanel.ResumeLayout(false);
            this.TableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label CapacityLabel;
        private System.Windows.Forms.Label InventorySlotsLabel;
        private System.Windows.Forms.Button RemoveSlotButton;
        private System.Windows.Forms.Button AddSlotButton;
        private System.Windows.Forms.TextBox CapacityTextBox;
        private System.Windows.Forms.ListBox SlotsListBox;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanel;
        private System.Windows.Forms.ToolTip EditorToolTip;
        private System.Windows.Forms.Button OkayButton;
        private System.Windows.Forms.Button CancelButtonControl;
    }
}
