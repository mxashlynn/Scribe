using System;
using System.Windows.Forms;
using ParquetClassLibrary;

namespace Scribe
{
    /// <summary>
    /// A modal dialogue that enables the user to add a new <see cref="ModelTag"/> to a collection of model tags.
    /// </summary>
    internal partial class AddTagBox : Form
    {
        /// <summary>The <see cref="ModelTag"/> that the user added, if any.</summary>
        public ModelTag ReturnNewTag { get; set; }

        /// <summary>
        /// Initialize a new <see cref="AddTagBox"/>.
        /// </summary>
        public AddTagBox()
            => InitializeComponent();

        /// <summary>
        /// Returns the <see cref="ParquetClassLibrary.ModelTag"/> that the user added to the <see cref="MainEditorForm"/>. 
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void NewTagTextBox_TextChanged(object sender, EventArgs e)
            => ReturnNewTag = NewTagTextBox.Text;

        private void AddTagBox_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Hi!!");
            ReturnNewTag = "";
            NewTagTextBox.Text = "";
        }

        /// <summary>
        /// Closes the <see cref="AddTagBox"/>, signalling that the entered tag text was accepted.
        /// </summary>
        /// <param name="sender">The originator of the event.</param>
        /// <param name="e">Additional event data.</param>
        private void OkayButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Closes the <see cref="AddTagBox"/>, signalling to abandon any entered tag text.
        /// </summary>
        /// <param name="sender">The originator of the event.</param>
        /// <param name="e">Additional event data.</param>
        private void CancelButtonControl_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
