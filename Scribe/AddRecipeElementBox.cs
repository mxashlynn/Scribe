using System;
using System.Windows.Forms;
using Parquet;
using Scribe.Properties;

namespace Scribe
{
    /// <summary>
    /// A modal dialogue that enables the user to add a new <see cref="Parquet.RecipeElement"/>
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
        /// <param name="eventArguments">Ignored.</param>
        private void AddRecipeElementBox_Load(object sender, EventArgs eventArguments)
        {
            if (null != ReturnNewRecipeElement)
            {
                ReturnNewRecipeElement = null;
                newTag = "";
                newAmount = 0;
                ElementAmountTextBox.Text = "";
                ElementTagTextBox.Text = "";
            }
            ApplyCurrentTheme();
            ElementTagTextBox.Select();
        }
        #endregion

        #region Color Theming
        /// <summary>
        /// Applies the <see cref="CurrentTheme"/> to the <see cref="AddRecipeElementBox"/> and its <see cref="Control"/>s.
        /// </summary>
        private void ApplyCurrentTheme()
        {
            BackColor = CurrentTheme.ControlBackgroundColor;
            ForeColor = CurrentTheme.ControlForegroundColor;
            ElementTagTextBox.BackColor = CurrentTheme.ControlBackgroundWhite;
            ElementTagTextBox.ForeColor = CurrentTheme.ControlForegroundColor;
            ElementAmountTextBox.BackColor = CurrentTheme.ControlBackgroundWhite;
            ElementAmountTextBox.ForeColor = CurrentTheme.ControlForegroundColor;
            ElementTagLabel.BackColor = CurrentTheme.ControlBackgroundColor;
            ElementTagLabel.ForeColor = CurrentTheme.ControlForegroundColor;
            ElementAmountLabel.BackColor = CurrentTheme.ControlBackgroundColor;
            ElementAmountLabel.ForeColor = CurrentTheme.ControlForegroundColor;
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
        /// Validates the <see cref="Parquet.ModelTag"/> that the user added to the <see cref="RecipeElement"/>. 
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
        #endregion

        #region Closing Form
        /// <summary>
        /// Closes the <see cref="AddTagBox"/>, signaling that the entered tag text was accepted.
        /// </summary>
        /// <param name="sender">The originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void OkayButton_Click(object sender, EventArgs eventArguments)
        {
            (ReturnNewRecipeElement, DialogResult) = newAmount < 1 || string.IsNullOrEmpty(newTag)
                ? (null, DialogResult.Cancel)
                : (new RecipeElement(newAmount, newTag), DialogResult.OK);
            Close();
        }

        /// <summary>
        /// Closes the <see cref="AddTagBox"/>, signaling to abandon any entered tag text.
        /// </summary>
        /// <param name="sender">The originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void CancelButtonControl_Click(object sender, EventArgs eventArguments)
        {
            ReturnNewRecipeElement = null;
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion
    }
}
