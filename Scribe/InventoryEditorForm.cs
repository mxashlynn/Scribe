using System;
using System.Windows.Forms;
using ParquetClassLibrary.Beings;
using ParquetClassLibrary.EditorSupport;
using ParquetClassLibrary.Items;

namespace Scribe
{
    /// <summary>
    /// A modal form that enables the user to edit a given <see cref="ParquetClassLibrary.Items.Inventory"/>.
    /// </summary>
    internal partial class InventoryEditorForm : Form
    {
        /// <summary>The <see cref="CharacterModel"/> whose <see cref="Inventory"/> is being edited.</summary>
        public IMutableCharacterModel CurrentCharacter { get; set; }

        /// <summary>A copy of the <see cref="Inventory"/> that has not been altered, for use if the user cancels.</summary>
        private Inventory UnchangedInventoryCopy { get; set; }

        #region Initialization
        /// <summary>
        /// Initialize a new <see cref="InventoryEditorForm"/>.
        /// </summary>
        public InventoryEditorForm()
            => InitializeComponent();

        /// <summary>
        /// Resets the UI each time the <see cref="Form"/> is loaded.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void InventoryEditorForm_Load(object sender, EventArgs e)
        {
            if (null == CurrentCharacter)
            {
                DialogResult = DialogResult.Abort;
                Close();
            }
            ApplyCurrentTheme();
            UnchangedInventoryCopy = CurrentCharacter.StartingInventory.Clone();
        }
        #endregion

        #region Color Theming
        /// <summary>
        /// Applies the <see cref="CurrentTheme"/> to the <see cref="InventoryEditorForm"/> and its <see cref="Control"/>s.
        /// </summary>
        private void ApplyCurrentTheme()
        {
            BackColor = CurrentTheme.ControlBackgroundColor;
            ForeColor = CurrentTheme.ControlForegroundColor;
            CapacityTextBox.BackColor = CurrentTheme.ControlBackgroundWhite;
            CapacityTextBox.ForeColor = CurrentTheme.ControlForegroundColor;
            SlotsListBox.BackColor = CurrentTheme.ControlBackgroundWhite;
            SlotsListBox.ForeColor = CurrentTheme.ControlForegroundColor;
            CapacityLabel.BackColor = CurrentTheme.ControlBackgroundColor;
            CapacityLabel.ForeColor = CurrentTheme.ControlForegroundColor;
            InventorySlotsLabel.BackColor = CurrentTheme.ControlBackgroundColor;
            InventorySlotsLabel.ForeColor = CurrentTheme.ControlForegroundColor;
            RemoveSlotButton.BackColor = CurrentTheme.ControlBackgroundColor;
            RemoveSlotButton.FlatAppearance.BorderColor = CurrentTheme.BorderColor;
            RemoveSlotButton.FlatAppearance.MouseDownBackColor = CurrentTheme.MouseDownColor;
            RemoveSlotButton.FlatAppearance.MouseOverBackColor = CurrentTheme.MouseOverColor;
            AddSlotButton.BackColor = CurrentTheme.ControlBackgroundColor;
            AddSlotButton.FlatAppearance.BorderColor = CurrentTheme.BorderColor;
            AddSlotButton.FlatAppearance.MouseDownBackColor = CurrentTheme.MouseDownColor;
            AddSlotButton.FlatAppearance.MouseOverBackColor = CurrentTheme.MouseOverColor;
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
            // TODO Implement Inventory Editor validation routines.
        #endregion

        #region Closing Form
        /// <summary>
        /// Closes the <see cref="InventoryEditorForm"/>, signalling that the entered tag text was accepted.
        /// </summary>
        /// <param name="sender">The originator of the event.</param>
        /// <param name="e">Additional event data.</param>
        private void OkayButton_Click(object sender, EventArgs e)
        {
            UnchangedInventoryCopy = Inventory.Empty;
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Closes the <see cref="AdInventoryEditorFormdTagBox"/>, signalling to abandon any entered tag text.
        /// </summary>
        /// <param name="sender">The originator of the event.</param>
        /// <param name="e">Additional event data.</param>
        private void CancelButtonControl_Click(object sender, EventArgs e)
        {
            CurrentCharacter.StartingInventory.Clear();
            foreach (var inventorySlot in UnchangedInventoryCopy)
            {
                CurrentCharacter.StartingInventory.Give(inventorySlot);
            }
            UnchangedInventoryCopy = Inventory.Empty;
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion
    }
}
