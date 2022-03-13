using System;
using System.Windows.Forms;
using Parquet;

namespace Scribe.Forms
{
    /// <summary>
    /// A modal dialogue that enables the user to select a function-themed <see cref="ModelTag"/> for a <see cref="Model"/>.
    /// </summary>
    internal partial class SelectFunctionBox : Form
    {
        /// <summary>When <c>true</c> a function was selected.</summary>
        public bool SpecificFunctionChosen { get; set; }

        /// <summary>The function that the user selected, if any.</summary>
        public ModelTag ReturnNewFunction { get; set; }

        #region Initialization
        /// <summary>
        /// Initialize a new <see cref="SelectFunctionBox"/>.
        /// </summary>
        public SelectFunctionBox()
            => InitializeComponent();

        /// <summary>
        /// Resets the UI each time the dialogue box is loaded.
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventArguments">Additional event data.</param>
        private void AddTagBox_Load(object inSender, EventArgs inEventArguments)
        {
            ApplyCurrentTheme();
            if (!string.IsNullOrEmpty(ReturnNewFunction))
            {
                NewTagComboBox.SelectedItem = ReturnNewFunction;
            }
            NewTagComboBox.Select();
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
            NewTagComboBox.BackColor = CurrentTheme.ControlBackgroundWhite;
            NewTagComboBox.ForeColor = CurrentTheme.ControlForegroundColor;
            FunctionTagLabel.BackColor = CurrentTheme.ControlBackgroundColor;
            FunctionTagLabel.ForeColor = CurrentTheme.ControlForegroundColor;
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

        #region Closing Form
        /// <summary>
        /// Closes the <see cref="SelectFlavorBox"/>, signaling that a function was accepted.
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventArguments">Additional event data.</param>
        private void OkayButton_Click(object inSender, EventArgs inEventArguments)
        {
            SpecificFunctionChosen = !string.Equals("(None)", NewTagComboBox.SelectedText, StringComparison.OrdinalIgnoreCase);
            ReturnNewFunction = NewTagComboBox.SelectedText;
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Closes the <see cref="SelectFlavorBox"/>, signaling that no function was chosen.
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventArguments">Additional event data.</param>
        private void CancelButtonControl_Click(object inSender, EventArgs inEventArguments)
        {
            ReturnNewFunction = "";
            SpecificFunctionChosen = false;
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion
    }
}
