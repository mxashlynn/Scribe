using System;
using System.Windows.Forms;
using Parquet;
using Scribe.Properties;

namespace Scribe
{
    /// <summary>
    /// A modal dialogue that enables the user to add a new <see cref="ModelTag"/> to a collection of model tags.
    /// </summary>
    internal partial class AddTagBox : Form
    {
        /// <summary>The <see cref="ModelTag"/> that the user might add.</summary>
        private ModelTag NewTag { get; set; }

        /// <summary>The <see cref="ModelTag"/> that the user added, if any.</summary>
        public ModelTag ReturnNewTag { get; set; }

        #region Initialization
        /// <summary>
        /// Initialize a new <see cref="AddTagBox"/>.
        /// </summary>
        public AddTagBox()
            => InitializeComponent();

        /// <summary>
        /// Resets the UI each time the dialogue box is loaded.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void AddTagBox_Load(object sender, EventArgs eventArguments)
        {
            if (!string.IsNullOrEmpty(ReturnNewTag))
            {
                ReturnNewTag = "";
                NewTagTextBox.Text = "";
            }
            ApplyCurrentTheme();
            NewTagTextBox.Select();
        }
        #endregion

        #region Color Theming
        /// <summary>
        /// Applies the <see cref="CurrentTheme"/> to the <see cref="AddTagBox"/> and its <see cref="Control"/>s.
        /// </summary>
        private void ApplyCurrentTheme()
        {
            BackColor = CurrentTheme.ControlBackgroundColor;
            ForeColor = CurrentTheme.ControlForegroundColor;
            NewTagTextBox.BackColor = CurrentTheme.ControlBackgroundWhite;
            NewTagTextBox.ForeColor = CurrentTheme.ControlForegroundColor;
            NewTagLabel.BackColor = CurrentTheme.ControlBackgroundColor;
            NewTagLabel.ForeColor = CurrentTheme.ControlForegroundColor;
            OkayButton.BackColor = CurrentTheme.ControlBackgroundColor;
            OkayButton.FlatAppearance.BorderColor = CurrentTheme.BorderColor;
            OkayButton.FlatAppearance.MouseDownBackColor = CurrentTheme.MouseDownColor;
            OkayButton.FlatAppearance.MouseOverBackColor = CurrentTheme.MouseOverColor;
            CancelButtonControl.BackColor = CurrentTheme.ControlBackgroundColor;
            CancelButtonControl.FlatAppearance.BorderColor = CurrentTheme.BorderColor;
            CancelButtonControl.FlatAppearance.MouseDownBackColor = CurrentTheme.MouseDownColor;
            CancelButtonControl.FlatAppearance.MouseOverBackColor = CurrentTheme.MouseOverColor;
        }
        #endregion

        #region Validation
        /// <summary>
        /// Validates the <see cref="ModelTag"/> that the user added. 
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Whether or not to discard the input.</param>
        private void NewTagTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs eventArguments)
        {
            var newText = EditorCommands.NormalizeWhitespace(NewTagTextBox.Text);
            NewTagTextBox.Text = newText;
            if (EditorCommands.TextIsReserved(newText))
            {
                newText = "";
                _ = MessageBox.Show(EditorCommands.ReservedWordMessage, Resources.CaptionWorkflow,
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                eventArguments.Cancel = true;
            }
            NewTag = newText;
        }
        #endregion

        #region Closing Form
        /// <summary>
        /// Closes the <see cref="AddTagBox"/>, signaling that the entered tag text was accepted.
        /// </summary>
        /// <param name="sender">The originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void OkayButton_Click(object sender, EventArgs eventArguments)
        {
            (ReturnNewTag, DialogResult) = string.IsNullOrEmpty(NewTag)
                ? ((ModelTag)"", DialogResult.Cancel)
                : (NewTag, DialogResult.OK);
            Close();
        }

        /// <summary>
        /// Closes the <see cref="AddTagBox"/>, signaling to abandon any entered tag text.
        /// </summary>
        /// <param name="sender">The originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void CancelButtonControl_Click(object sender, EventArgs eventArguments)
        {
            ReturnNewTag = "";
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion
    }
}
