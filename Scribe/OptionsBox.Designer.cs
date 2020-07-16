namespace Scribe
{
    partial class OptionsBox
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
            this.OkayButton = new System.Windows.Forms.Button();
            this.LabelTheme = new System.Windows.Forms.Label();
            this.PanelEditorTheme = new System.Windows.Forms.Panel();
            this.RadioButtonColorfulTheme = new System.Windows.Forms.RadioButton();
            this.RadioButtonLightTheme = new System.Windows.Forms.RadioButton();
            this.TableLayoutPanel.SuspendLayout();
            this.PanelEditorTheme.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanel
            // 
            this.TableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel.ColumnCount = 2;
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel.Controls.Add(this.OkayButton, 1, 5);
            this.TableLayoutPanel.Controls.Add(this.LabelTheme, 0, 0);
            this.TableLayoutPanel.Controls.Add(this.PanelEditorTheme, 1, 0);
            this.TableLayoutPanel.Location = new System.Drawing.Point(10, 10);
            this.TableLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TableLayoutPanel.Name = "TableLayoutPanel";
            this.TableLayoutPanel.RowCount = 6;
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TableLayoutPanel.Size = new System.Drawing.Size(486, 306);
            this.TableLayoutPanel.TabIndex = 0;
            // 
            // OkayButton
            // 
            this.OkayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkayButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.OkayButton.Location = new System.Drawing.Point(394, 276);
            this.OkayButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.OkayButton.Name = "OkayButton";
            this.OkayButton.Size = new System.Drawing.Size(88, 27);
            this.OkayButton.TabIndex = 24;
            this.OkayButton.Text = "&OK";
            // 
            // LabelTheme
            // 
            this.LabelTheme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelTheme.AutoSize = true;
            this.LabelTheme.Location = new System.Drawing.Point(3, 0);
            this.LabelTheme.Name = "LabelTheme";
            this.LabelTheme.Size = new System.Drawing.Size(77, 30);
            this.LabelTheme.TabIndex = 25;
            this.LabelTheme.Text = "Editor Theme";
            this.LabelTheme.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PanelEditorTheme
            // 
            this.PanelEditorTheme.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelEditorTheme.Controls.Add(this.RadioButtonColorfulTheme);
            this.PanelEditorTheme.Controls.Add(this.RadioButtonLightTheme);
            this.PanelEditorTheme.Location = new System.Drawing.Point(163, 3);
            this.PanelEditorTheme.Name = "PanelEditorTheme";
            this.PanelEditorTheme.Size = new System.Drawing.Size(320, 24);
            this.PanelEditorTheme.TabIndex = 28;
            // 
            // RadioButtonColorfulTheme
            // 
            this.RadioButtonColorfulTheme.AutoSize = true;
            this.RadioButtonColorfulTheme.Checked = true;
            this.RadioButtonColorfulTheme.Location = new System.Drawing.Point(0, 5);
            this.RadioButtonColorfulTheme.Name = "RadioButtonColorfulTheme";
            this.RadioButtonColorfulTheme.Size = new System.Drawing.Size(75, 19);
            this.RadioButtonColorfulTheme.TabIndex = 1;
            this.RadioButtonColorfulTheme.TabStop = true;
            this.RadioButtonColorfulTheme.Text = "Colourful";
            this.RadioButtonColorfulTheme.UseVisualStyleBackColor = true;
            // 
            // RadioButtonLightTheme
            // 
            this.RadioButtonLightTheme.AutoSize = true;
            this.RadioButtonLightTheme.Location = new System.Drawing.Point(100, 5);
            this.RadioButtonLightTheme.Name = "RadioButtonLightTheme";
            this.RadioButtonLightTheme.Size = new System.Drawing.Size(52, 19);
            this.RadioButtonLightTheme.TabIndex = 2;
            this.RadioButtonLightTheme.Text = "Light";
            this.RadioButtonLightTheme.UseVisualStyleBackColor = true;
            // 
            // OptionsBox
            // 
            this.AcceptButton = this.OkayButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 327);
            this.Controls.Add(this.TableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsBox";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Scribe Options";
            this.TableLayoutPanel.ResumeLayout(false);
            this.TableLayoutPanel.PerformLayout();
            this.PanelEditorTheme.ResumeLayout(false);
            this.PanelEditorTheme.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TableLayoutPanel;
        private System.Windows.Forms.Button OkayButton;
        private System.Windows.Forms.Label LabelTheme;
        private System.Windows.Forms.Panel PanelEditorTheme;
        private System.Windows.Forms.RadioButton RadioButtonColorfulTheme;
        private System.Windows.Forms.RadioButton RadioButtonLightTheme;
    }
}
