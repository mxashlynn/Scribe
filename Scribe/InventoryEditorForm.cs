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
        /// <summary>The <see cref="CharacterModel"/> whose <see cref="Inventory"/> might be edited.</summary>
        public IMutableCharacterModel CurrentCharacter { get; set; }

        /// <summary>
        /// An <see cref="Inventory"/> that the user cancels interacts with in this form.
        /// It is only given to the <see cref="CharacterModel"/> if the user selects the <see cref="OkayButton"/>.
        /// </summary>
        private Inventory WorkingInventory { get; set; }

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
            WorkingInventory = CurrentCharacter.StartingInventory.Clone();
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
        /// Closes the <see cref="InventoryEditorForm"/>, signalling that the edited <see cref="Inventory"/> was accepted.
        /// </summary>
        /// <param name="sender">The originator of the event.</param>
        /// <param name="e">Additional event data.</param>
        private void OkayButton_Click(object sender, EventArgs e)
        {
            CurrentCharacter.StartingInventory.Clear();
            foreach (var inventorySlot in WorkingInventory)
            {
                CurrentCharacter.StartingInventory.Give(inventorySlot);
            }
            WorkingInventory = Inventory.Empty;
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Closes the <see cref="AdInventoryEditorFormdTagBox"/>, signalling to abandon the edited <see cref="Inventory"/>.
        /// </summary>
        /// <param name="sender">The originator of the event.</param>
        /// <param name="e">Additional event data.</param>
        private void CancelButtonControl_Click(object sender, EventArgs e)
        {
            WorkingInventory = Inventory.Empty;
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion
    }
}
