using System;
using System.Windows.Forms;
using ParquetClassLibrary.Items;

namespace Scribe
{
    /// <summary>
    /// A modal dialogue enabling users to add new <see cref="ParquetClassLibrary.Items.InventorySlot"/>s.
    /// </summary>
    internal partial class AddSlotBox : Form
    {
        /// <summary>The <see cref="InventorySlot"/> that the user might add.</summary>
        private InventorySlot NewSlot { get; set; }

        /// <summary>The <see cref="InventorySlot"/> that the user added, if any.</summary>
        public InventorySlot ReturnNewSlot { get; set; }


        #region Initialization
        /// <summary>
        /// Initializes a new <see cref="AddSlotBox"/>.
        /// </summary>
        public AddSlotBox()
            => InitializeComponent();

        /// <summary>
        /// Resets the UI each time the dialogue box is loaded.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void AddSlotBox_Load1(object sender, EventArgs e)
        {
            if (ReturnNewSlot == InventorySlot.Empty)
            {
                AmountTextBox.Text = "";
                ItemListBox.SelectedItem = null;
                ItemListBox.Items.Clear();
            }
            ApplyCurrentTheme();
            AmountTextBox.Select();
        }
        #endregion

        #region Color Theming
        /// <summary>
        /// Applies the <see cref="CurrentTheme"/> to the <see cref="OptionsBox"/> and its <see cref="Control"/>s.
        /// </summary>
        private void ApplyCurrentTheme()
        {
            BackColor = CurrentTheme.ControlBackgroundColor;
            ForeColor = CurrentTheme.ControlForegroundColor;
            AmountTextBox.BackColor = CurrentTheme.ControlBackgroundWhite;
            AmountTextBox.ForeColor = CurrentTheme.ControlForegroundColor;
            ItemListBox.BackColor = CurrentTheme.ControlBackgroundWhite;
            ItemListBox.ForeColor = CurrentTheme.ControlForegroundColor;
            ItemLabel.BackColor = CurrentTheme.ControlBackgroundColor;
            ItemLabel.ForeColor = CurrentTheme.ControlForegroundColor;
            AmountLabel.BackColor = CurrentTheme.ControlBackgroundColor;
            AmountLabel.ForeColor = CurrentTheme.ControlForegroundColor;
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
    }
}
