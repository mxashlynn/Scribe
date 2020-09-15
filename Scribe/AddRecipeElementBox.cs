using System;
using System.Windows.Forms;
using ParquetClassLibrary;
using Scribe.Properties;

namespace Scribe
{
    /// <summary>
    /// A modal dialogue that enables the user to add a new <see cref="ParquetClassLibrary.RecipeElement"/>
    /// to a collection of recipe elements.
    /// </summary>
    internal partial class AddRecipeElementBox : Form
    {
        /// <summary>The <see cref="ModelTag"/> that will help make up the new <see cref="RecipeElement"/>.</summary>
        private ModelTag newTag;

        /// <summary>The <see cref="int"/> that will help make up the new <see cref="RecipeElement"/>.</summary>
        private int newAmount;

        /// <summary>The <see cref="RecipeElement"/> that the user added, if any.</summary>
        public RecipeElement ReturnNewRecipeElement { get; set; }

        #region Initialization
        /// <summary>
        /// Initialize a new <see cref="AddRecipeElementBox"/>.
        /// </summary>
        public AddRecipeElementBox()
            => InitializeComponent();

        /// <summary>
        /// Resets the UI each time the dialogue box is loaded.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void AddRecipeElementBox_Load(object sender, EventArgs e)
        {
            if (null != ReturnNewRecipeElement)
            {
                ReturnNewRecipeElement = null;
                newTag = "";
                newAmount = 0;
                ElementAmountTextBox.Text = "";
                ElementTagTextBox.Text = "";
            }
            ElementTagTextBox.Select();
        }
        #endregion

        /// <summary>
        /// Validates the <see cref="ParquetClassLibrary.ModelTag"/> that the user added to the <see cref="RecipeElement"/>. 
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Whether or not to discard the input.</param>
        private void ElementTagTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs eventArguments)
        {
            var newText = EditorCommands.NormalizeWhitespace(ElementTagTextBox.Text);
            ElementTagTextBox.Text = newText;
            if (EditorCommands.TextIsReserved(newText))
            {
                newText = "";
                _ = MessageBox.Show(EditorCommands.ReservedWordMessage, Resources.CaptionError,
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                eventArguments.Cancel = true;
            }
            newTag = newText;
        }

        /// <summary>
        /// Validates the integer that the user added to the <see cref="RecipeElement"/>. 
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Whether or not to discard the input.</param>
        private void ElementAmountTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs eventArguments)
        {
            var newText = EditorCommands.NormalizeWhitespace(ElementAmountTextBox.Text);
            ElementAmountTextBox.Text = newText;
            if (!int.TryParse(newText, out var parsedAmount)
                || parsedAmount < 1)
            {
                parsedAmount = 0;
                ElementAmountTextBox.Text = "";
                _ = MessageBox.Show(Resources.ErrorPositiveIntegersOnly, Resources.CaptionError,
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                eventArguments.Cancel = true;
            }
            newAmount = parsedAmount;
        }

        /// <summary>
        /// Closes the <see cref="AddTagBox"/>, signalling that the entered tag text was accepted.
        /// </summary>
        /// <param name="sender">The originator of the event.</param>
        /// <param name="e">Additional event data.</param>
        private void OkayButton_Click(object sender, EventArgs e)
        {
            (ReturnNewRecipeElement, DialogResult) = newAmount < 1 || string.IsNullOrEmpty(newTag)
                ? (null, DialogResult.Cancel)
                : (new RecipeElement(newAmount, newTag), DialogResult.OK);
            Close();
        }

        /// <summary>
        /// Closes the <see cref="AddTagBox"/>, signalling to abandon any entered tag text.
        /// </summary>
        /// <param name="sender">The originator of the event.</param>
        /// <param name="e">Additional event data.</param>
        private void CancelButtonControl_Click(object sender, EventArgs e)
        {
            ReturnNewRecipeElement = null;
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
