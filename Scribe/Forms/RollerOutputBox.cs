using System;
using System.Windows.Forms;

namespace Scribe.Forms
{
    partial class RollerOutputBox : Form
    {
        /// <summary>The results text to be shown.</summary>
        public string TextOnDisplay
        {
            get => OutputDisplayTextBox.Text;
            set => OutputDisplayTextBox.Text = value;
        }

        #region Initialization
        /// <summary>
        /// Initialize a new <see cref="AddTagBox"/>.
        /// </summary>
        public RollerOutputBox()
            => InitializeComponent();

        /// <summary>
        /// Resets the UI each time the dialogue box is loaded.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void RollerOutputBox_Load(object sender, EventArgs eventArguments)
        {
            ApplyCurrentTheme();
            OutputDisplayTextBox.Select();
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
            OutputDisplayTextBox.BackColor = CurrentTheme.ControlBackgroundWhite;
            OutputDisplayTextBox.ForeColor = CurrentTheme.ControlForegroundColor;
            OkayButton.BackColor = CurrentTheme.ControlBackgroundColor;
            OkayButton.FlatAppearance.BorderColor = CurrentTheme.BorderColor;
            OkayButton.FlatAppearance.MouseDownBackColor = CurrentTheme.MouseDownColor;
            OkayButton.FlatAppearance.MouseOverBackColor = CurrentTheme.MouseOverColor;
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
            OutputDisplayTextBox.Clear();
            Close();
        }
        #endregion
    }
}
