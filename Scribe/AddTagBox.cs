using System;
using System.Windows.Forms;
using ParquetClassLibrary;
using Scribe.Properties;

namespace Scribe
{
    /// <summary>
    /// A modal dialogue that enables the user to add a new <see cref="ModelTag"/> to a collection of model tags.
    /// </summary>
    internal partial class AddTagBox : Form
    {
        /// <summary>The <see cref="ModelTag"/> that the user might add.</summary>
        private ModelTag newTag { get; set; }

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
        /// <param name="e">Ignored.</param>
        private void AddTagBox_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ReturnNewTag))
            {
                ReturnNewTag = "";
                NewTagTextBox.Text = "";
            }
            NewTagTextBox.Select();
        }
        #endregion

        /// <summary>
        /// Validates the <see cref="ModelTag"/> that the user added. 
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void NewTagTextBox_TextChanged(object sender, EventArgs e)
        {
            var newText = EditorCommands.NormalizeWhitespace(NewTagTextBox.Text);
            if (EditorCommands.TextIsReserved(newText))
            {
                newText = "";
                _ = MessageBox.Show(EditorCommands.ReservedWordMessage, Resources.CaptionError,
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            newTag = NewTagTextBox.Text = newText;
        }

        /// <summary>
        /// Closes the <see cref="AddTagBox"/>, signalling that the entered tag text was accepted.
        /// </summary>
        /// <param name="sender">The originator of the event.</param>
        /// <param name="e">Additional event data.</param>
        private void OkayButton_Click(object sender, EventArgs e)
        {
            (ReturnNewTag, DialogResult) = string.IsNullOrEmpty(newTag)
                ? ((ModelTag)"", DialogResult.Cancel)
                : (newTag, DialogResult.OK);
            Close();
        }

        /// <summary>
        /// Closes the <see cref="AddTagBox"/>, signalling to abandon any entered tag text.
        /// </summary>
        /// <param name="sender">The originator of the event.</param>
        /// <param name="e">Additional event data.</param>
        private void CancelButtonControl_Click(object sender, EventArgs e)
        {
            ReturnNewTag = "";
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
