using System;
using System.Windows.Forms;
using Parquet;

namespace Scribe.Forms
{
    /// <summary>
    /// A modal dialogue that enables the user to select a flavor-themed <see cref="ModelTag"/> for a <see cref="Model"/>.
    /// </summary>
    partial class SelectFlavorBox : Form
    {
        /// <summary>When <c>true</c> a flavor was selected.</summary>
        public bool SpecificFlavorChosen { get; set; }

        /// <summary>The flavor that the user selected, if any.</summary>
        public ModelTag ReturnNewFlavor { get; set; }

        #region Initialization
        /// <summary>
        /// Instantiates a new instance of the <see cref="SelectFlavorBox"/> class.
        /// </summary>
        public SelectFlavorBox()
            => InitializeComponent();

        /// <summary>
        /// Resets the UI each time the dialogue box is loaded.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void SelectFlavorBox_Load(object sender, EventArgs eventArguments)
            => ApplyCurrentTheme();
        #endregion

        #region Color Theming
        /// <summary>
        /// Applies the <see cref="CurrentTheme"/> to the <see cref="SelectFlavorBox"/> and its <see cref="Control"/>s.
        /// </summary>
        private void ApplyCurrentTheme()
        {
            BackColor = CurrentTheme.ControlBackgroundColor;
            ForeColor = CurrentTheme.ControlForegroundColor;
            FlavorsTableLayoutPanel.BackColor = CurrentTheme.ControlBackgroundWhite;
            FlavorsTableLayoutPanel.ForeColor = CurrentTheme.ControlForegroundColor;
            FlavorCancelButton.BackColor = CurrentTheme.ControlBackgroundColor;
            FlavorCancelButton.FlatAppearance.BorderColor = CurrentTheme.BorderColor;
            FlavorCancelButton.FlatAppearance.MouseDownBackColor = CurrentTheme.MouseDownColor;
            FlavorCancelButton.FlatAppearance.MouseOverBackColor = CurrentTheme.MouseOverColor;
        }
        #endregion

        #region Closing Form
        /// <summary>
        /// Closes the <see cref="SelectFlavorBox"/>, signaling that the chosen flavor was accepted.
        /// </summary>
        /// <param name="sender">The originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void FlavorSelector_Click(object sender, EventArgs eventArguments)
        {
            var chosenControl = sender as Label;
            SpecificFlavorChosen = chosenControl != FlavorNoFlavorsSelector;
            ReturnNewFlavor = chosenControl.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Closes the <see cref="SelectFlavorBox"/>, signaling that no flavor was chosen.
        /// </summary>
        /// <param name="sender">The originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void FlavorCancelButton_Click(object sender, EventArgs eventArguments)
        {
            ReturnNewFlavor = "";
            SpecificFlavorChosen = false;
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion
    }
}
