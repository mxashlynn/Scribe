namespace Scribe.Forms
{
    partial class ChangeTestForm
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
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.ButtonUndo = new System.Windows.Forms.Button();
            this.ButtonRedo = new System.Windows.Forms.Button();
            this.LabelOldValue = new System.Windows.Forms.Label();
            this.LabelDBValue = new System.Windows.Forms.Label();
            this.LabelStoredChanges = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(12, 12);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(100, 23);
            this.TextBox1.TabIndex = 0;
            this.TextBox1.Validated += new System.EventHandler(this.TextBox1_Validated);
            // 
            // ButtonUndo
            // 
            this.ButtonUndo.Location = new System.Drawing.Point(152, 12);
            this.ButtonUndo.Name = "ButtonUndo";
            this.ButtonUndo.Size = new System.Drawing.Size(75, 23);
            this.ButtonUndo.TabIndex = 2;
            this.ButtonUndo.Text = "Undo";
            this.ButtonUndo.UseVisualStyleBackColor = true;
            this.ButtonUndo.Click += new System.EventHandler(this.ButtonUndo_Click);
            // 
            // ButtonRedo
            // 
            this.ButtonRedo.Location = new System.Drawing.Point(152, 41);
            this.ButtonRedo.Name = "ButtonRedo";
            this.ButtonRedo.Size = new System.Drawing.Size(75, 23);
            this.ButtonRedo.TabIndex = 3;
            this.ButtonRedo.Text = "Redo";
            this.ButtonRedo.UseVisualStyleBackColor = true;
            this.ButtonRedo.Click += new System.EventHandler(this.ButtonRedo_Click);
            // 
            // LabelOldValue
            // 
            this.LabelOldValue.AutoSize = true;
            this.LabelOldValue.Location = new System.Drawing.Point(12, 45);
            this.LabelOldValue.Name = "LabelOldValue";
            this.LabelOldValue.Size = new System.Drawing.Size(127, 15);
            this.LabelOldValue.TabIndex = 4;
            this.LabelOldValue.Text = "Old Value: uninitialized";
            // 
            // LabelDBValue
            // 
            this.LabelDBValue.AutoSize = true;
            this.LabelDBValue.Location = new System.Drawing.Point(12, 70);
            this.LabelDBValue.Name = "LabelDBValue";
            this.LabelDBValue.Size = new System.Drawing.Size(89, 15);
            this.LabelDBValue.TabIndex = 4;
            this.LabelDBValue.Text = "Database Value:";
            // 
            // LabelStoredChanges
            // 
            this.LabelStoredChanges.AutoSize = true;
            this.LabelStoredChanges.Location = new System.Drawing.Point(12, 102);
            this.LabelStoredChanges.Name = "LabelStoredChanges";
            this.LabelStoredChanges.Size = new System.Drawing.Size(118, 15);
            this.LabelStoredChanges.TabIndex = 4;
            this.LabelStoredChanges.Text = "Stored Changes: 0";
            // 
            // UndoTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 126);
            this.Controls.Add(this.LabelStoredChanges);
            this.Controls.Add(this.LabelDBValue);
            this.Controls.Add(this.LabelOldValue);
            this.Controls.Add(this.ButtonRedo);
            this.Controls.Add(this.ButtonUndo);
            this.Controls.Add(this.TextBox1);
            this.Name = "UndoTestForm";
            this.Text = "Undo Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBox1;
        private System.Windows.Forms.Button ButtonUndo;
        private System.Windows.Forms.Button ButtonRedo;
        private System.Windows.Forms.Label LabelOldValue;
        private System.Windows.Forms.Label LabelDBValue;
        private System.Windows.Forms.Label LabelStoredChanges;
    }
}
