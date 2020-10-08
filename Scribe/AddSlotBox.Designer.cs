namespace Scribe
{
    partial class AddSlotBox
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
            this.SlotTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CancelButtonControl = new System.Windows.Forms.Button();
            this.OkayButton = new System.Windows.Forms.Button();
            this.ItemLabel = new System.Windows.Forms.Label();
            this.AmountTextBox = new System.Windows.Forms.TextBox();
            this.AmountLabel = new System.Windows.Forms.Label();
            this.ItemListBox = new System.Windows.Forms.ListBox();
            this.AmountErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.SlotTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AmountErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // SlotTableLayoutPanel
            // 
            this.SlotTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SlotTableLayoutPanel.ColumnCount = 2;
            this.SlotTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.SlotTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SlotTableLayoutPanel.Controls.Add(this.CancelButtonControl, 0, 2);
            this.SlotTableLayoutPanel.Controls.Add(this.OkayButton, 0, 2);
            this.SlotTableLayoutPanel.Controls.Add(this.ItemLabel, 0, 0);
            this.SlotTableLayoutPanel.Controls.Add(this.AmountTextBox, 1, 1);
            this.SlotTableLayoutPanel.Controls.Add(this.AmountLabel, 0, 1);
            this.SlotTableLayoutPanel.Controls.Add(this.ItemListBox, 1, 0);
            this.SlotTableLayoutPanel.Location = new System.Drawing.Point(13, 13);
            this.SlotTableLayoutPanel.Name = "SlotTableLayoutPanel";
            this.SlotTableLayoutPanel.RowCount = 3;
            this.SlotTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SlotTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.SlotTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.SlotTableLayoutPanel.Size = new System.Drawing.Size(258, 115);
            this.SlotTableLayoutPanel.TabIndex = 2;
            // 
            // CancelButtonControl
            // 
            this.CancelButtonControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButtonControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButtonControl.Location = new System.Drawing.Point(3, 89);
            this.CancelButtonControl.Name = "CancelButtonControl";
            this.CancelButtonControl.Size = new System.Drawing.Size(74, 23);
            this.CancelButtonControl.TabIndex = 14;
            this.CancelButtonControl.Text = "Cancel";
            this.CancelButtonControl.UseVisualStyleBackColor = true;
            this.CancelButtonControl.Click += new System.EventHandler(this.CancelButtonControl_Click);
            // 
            // OkayButton
            // 
            this.OkayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkayButton.Location = new System.Drawing.Point(180, 89);
            this.OkayButton.Name = "OkayButton";
            this.OkayButton.Size = new System.Drawing.Size(75, 23);
            this.OkayButton.TabIndex = 9;
            this.OkayButton.Text = "&OK";
            this.OkayButton.UseVisualStyleBackColor = true;
            this.OkayButton.Click += new System.EventHandler(this.OkayButton_Click);
            // 
            // ItemLabel
            // 
            this.ItemLabel.AutoSize = true;
            this.ItemLabel.Location = new System.Drawing.Point(3, 0);
            this.ItemLabel.Name = "ItemLabel";
            this.ItemLabel.Size = new System.Drawing.Size(31, 15);
            this.ItemLabel.TabIndex = 10;
            this.ItemLabel.Text = "Item";
            // 
            // AmountTextBox
            // 
            this.AmountTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AmountTextBox.Location = new System.Drawing.Point(83, 58);
            this.AmountTextBox.Name = "AmountTextBox";
            this.AmountTextBox.Size = new System.Drawing.Size(172, 23);
            this.AmountTextBox.TabIndex = 11;
            this.AmountTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.AmountTextBox_Validating);
            // 
            // AmountLabel
            // 
            this.AmountLabel.AutoSize = true;
            this.AmountLabel.Location = new System.Drawing.Point(3, 55);
            this.AmountLabel.Name = "AmountLabel";
            this.AmountLabel.Size = new System.Drawing.Size(51, 15);
            this.AmountLabel.TabIndex = 12;
            this.AmountLabel.Text = "Amount";
            // 
            // ItemListBox
            // 
            this.ItemListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemListBox.FormattingEnabled = true;
            this.ItemListBox.ItemHeight = 15;
            this.ItemListBox.Location = new System.Drawing.Point(83, 3);
            this.ItemListBox.Name = "ItemListBox";
            this.ItemListBox.Size = new System.Drawing.Size(172, 49);
            this.ItemListBox.TabIndex = 15;
            this.ItemListBox.SelectedIndexChanged += new System.EventHandler(this.ItemListBox_SelectedIndexChanged);
            // 
            // AmountErrorProvider
            // 
            this.AmountErrorProvider.ContainerControl = this;
            // 
            // AddSlotBox
            // 
            this.AcceptButton = this.OkayButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButtonControl;
            this.ClientSize = new System.Drawing.Size(284, 141);
            this.Controls.Add(this.SlotTableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 180);
            this.Name = "AddSlotBox";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddSlotBox";
            this.Load += new System.EventHandler(this.AddSlotBox_Load);
            this.SlotTableLayoutPanel.ResumeLayout(false);
            this.SlotTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AmountErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel SlotTableLayoutPanel;
        private System.Windows.Forms.Button CancelButtonControl;
        private System.Windows.Forms.Button OkayButton;
        private System.Windows.Forms.Label ItemLabel;
        private System.Windows.Forms.TextBox AmountTextBox;
        private System.Windows.Forms.Label AmountLabel;
        private System.Windows.Forms.ListBox ItemListBox;
        private System.Windows.Forms.ErrorProvider AmountErrorProvider;
    }
}
