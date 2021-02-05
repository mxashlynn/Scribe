using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Parquet;
using Parquet.Items;
using Scribe.Properties;

namespace Scribe.Forms
{
    /// <summary>
    /// A modal dialogue enabling users to add new <see cref="Parquet.Items.InventorySlot"/>s.
    /// </summary>
    internal partial class AddSlotBox : Form
    {
        /// <summary>The <see cref="ModelID"/> for the <see cref="ItemModel"/> that the user might add.</summary>
        private ModelID ItemID { get; set; }

        /// <summary>The amount of the <see cref="ItemModel"/> that the user might add.</summary>
        private int ItemAmount { get; set; }

        /// <summary>The <see cref="InventorySlot"/> that the user added, if any.</summary>
        public InventorySlot ReturnNewSlot { get; private set; }

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
        /// <param name="eventArguments">Ignored.</param>
        private void AddSlotBox_Load(object sender, EventArgs eventArguments)
        {
            ReturnNewSlot = InventorySlot.Empty;
            ItemID = ModelID.None;
            ItemAmount = 0;

            AmountTextBox.Text = "";
            ItemListBox.SelectedItem = null;
            ItemListBox.BeginUpdate();
            ItemListBox.Items.Clear();
            ItemListBox.Items.AddRange(All.Items.Where(model => model.ID != ModelID.None).ToArray<object>());
            ItemListBox.EndUpdate();

            ApplyCurrentTheme();
            ItemListBox.Select();
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

        #region Validation
        /// <summary>
        /// Determines if the value entered is valid.
        /// Updates the <see cref="ItemAmount"/> according to valid values, otherwise signals an input error.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventAruments">Whether or not to discard the given text.</param>
        private void AmountTextBox_Validating(object sender, CancelEventArgs eventAruments)
        {
            if (int.TryParse(AmountTextBox.Text, out var parsedAmount)
                && parsedAmount > 0)
            {
                ItemAmount = parsedAmount;
                AmountErrorProvider.SetError(AmountLabel, "");
            }
            else
            {
                eventAruments.Cancel = true;
                AmountErrorProvider.SetError(AmountLabel, Resources.ErrorPositiveIntegersOnly);
            }
        }

        /// <summary>
        /// Updates the <see cref="ItemID"/> according to user input.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void ItemListBox_SelectedIndexChanged(object sender, EventArgs eventArguments)
            => ItemID = ((ItemModel)ItemListBox.SelectedItem)?.ID ?? ModelID.None;
        #endregion

        #region Closing Form
        /// <summary>
        /// Closes the <see cref="AddSlotBox"/>, signaling that the <see cref="InventorySlot"/> was accepted.
        /// </summary>
        /// <param name="sender">The originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void OkayButton_Click(object sender, EventArgs eventArguments)
        {
            (ReturnNewSlot, DialogResult) = ModelID.None != ItemID
                            && ItemID.IsValidForRange(All.ItemIDs)
                            && ItemAmount > 0
                ? (new InventorySlot(ItemID, ItemAmount), DialogResult.OK)
                : (InventorySlot.Empty, DialogResult.Cancel);
            Close();
        }

        /// <summary>
        /// Closes the <see cref="AddSlotBox"/>.
        /// </summary>
        /// <param name="sender">The originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void CancelButtonControl_Click(object sender, EventArgs eventArguments)
        {
            ReturnNewSlot = InventorySlot.Empty;
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion
    }
}
