using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using ParquetClassLibrary;
using ParquetClassLibrary.Beings;
using ParquetClassLibrary.EditorSupport;
using ParquetClassLibrary.Items;
using Scribe.Properties;

namespace Scribe
{
    /// <summary>
    /// A modal form that enables the user to edit a given <see cref="Inventory"/>.
    /// </summary>
    internal partial class InventoryEditorForm : Form
    {
        #region Child Forms
        /// <summary>Dialogue for adding an <see cref="InventorySlot"/> to an <see cref="Inventory"/>.</summary>
        private readonly AddSlotBox AddSlotDialogue = new AddSlotBox();
        #endregion

        #region Content Being Edited
        /// <summary>The <see cref="CharacterModel"/> whose <see cref="Inventory"/> might be edited.</summary>
        public IMutableCharacterModel CurrentCharacter { get; set; }

        /// <summary>
        /// An <see cref="Inventory"/> that the user interacts with in this form.
        /// It is only attached to the <see cref="CharacterModel"/> if the user selects the <see cref="OkayButton"/>.
        /// </summary>
        private Inventory WorkingInventory { get; set; }
        #endregion

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
        /// <param name="eventArguments">Ignored.</param>
        private void InventoryEditorForm_Load(object sender, EventArgs eventArguments)
        {
            if (null == CurrentCharacter)
            {
                DialogResult = DialogResult.Abort;
                Close();
            }
            else
            {
                ApplyCurrentTheme();
                WorkingInventory = ((Inventory)CurrentCharacter.StartingInventory).Clone();
                UpdateControls();
            }
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

        #region Update Display
        /// <summary>
        /// Repopulates the <see cref="SlotsListBox"/> and <see cref="CapacityTextBox"/> with the <see cref="WorkingInventory"/>.
        /// </summary>
        /// <remarks>This should only be called if the WorkingInventory has actually changed.</remarks>
        private void UpdateControls()
        {
            CapacityTextBox.Text = WorkingInventory?.Capacity.ToString() ?? "";
            if (WorkingInventory?.Count > 0)
            {
                SlotsListBox.SelectedItem = null;
                SlotsListBox.BeginUpdate();
                SlotsListBox.Items.Clear();
                SlotsListBox.Items.AddRange(WorkingInventory.ToArray());
                SlotsListBox.EndUpdate();
            }
        }

        /// <summary>
        /// Updates the SlotsListBox needs to render its content, to display <see cref="InventorySlot"/>s in a custom fashion.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Used to render the selected item.</param>
        private void SlotsListBox_DrawItem(object sender, DrawItemEventArgs eventArguments)
        {
            // Determine text to represent this InventorySlot.
            var thisSlot = (InventorySlot)SlotsListBox.Items[eventArguments.Index];
            var thisSlotName = All.Items.Get<ItemModel>(thisSlot.ItemID).Name;
            var thisSlotText = $"{thisSlot.Count} {thisSlotName}";
            // Render that text.
            eventArguments.DrawBackground();
            TextRenderer.DrawText(eventArguments.Graphics, thisSlotText, eventArguments.Font, eventArguments.Bounds,
                                  SlotsListBox.ForeColor);
            eventArguments.DrawFocusRectangle();
        }
        #endregion

        #region Validation
        /// <summary>
        /// Intercepts key-down events to register user requests to refresh the display.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="inKeyEvents">The key that was held down.</param>
        private void InventoryEditorForm_KeyDown(object sender, KeyEventArgs inKeyEvents)
        {
            if (inKeyEvents.KeyCode == Keys.F5)
            {
                UpdateControls();
            }
        }

        /// <summary>
        /// Determines if the value entered is valid.
        /// Adjusts the capacity of the <see cref="WorkingInventory"/> according to valid values, otherwise signals an input error.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventAruments">Whether or not to discard the given text.</param>
        private void CapacityTextBox_Validating(object sender, CancelEventArgs eventAruments)
        {
            if (int.TryParse(CapacityTextBox.Text, out var parsedCapacity)
                && parsedCapacity > 0)
            {
                WorkingInventory.Capacity = parsedCapacity;
                CapacityErrorProvider.SetError(CapacityTextBox, "");
            }
            else
            {
                eventAruments.Cancel = true;
                CapacityErrorProvider.SetError(CapacityTextBox, Resources.ErrorPositiveIntegersOnly);
            }
        }

        /// <summary>
        /// Registers the user command to add a new <see cref="InventorySlot"/> to the <see cref="WorkingInventory"/>.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void AddSlotButton_Click(object sender, EventArgs eventArguments)
        {
            if (!All.Items.Any(itemModel => ModelID.None != itemModel.ID))
            {
                SystemSounds.Beep.Play();
                _ = MessageBox.Show(Resources.WarngingNoItemsExist, Resources.CaptionWorkflow,
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (AddSlotDialogue.ShowDialog() == DialogResult.OK)
            {
                // Increment the capacity as needed to support additional slots.
                if (WorkingInventory.Count + 1 > WorkingInventory.Capacity)
                {
                    WorkingInventory.Capacity++;
                    CapacityTextBox.Text = WorkingInventory.Capacity.ToString();
                }

                if (0 == WorkingInventory.Give(AddSlotDialogue.ReturnNewSlot))
                {
                    SlotsListBox.Items.Add(AddSlotDialogue.ReturnNewSlot);
                }
                else
                {
                    SystemSounds.Beep.Play();
                    _ = MessageBox.Show(Resources.ErrorAddingSlot, Resources.CaptionError,
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Registers the user command to remove the selected <see cref="InventorySlot"/> tag from the <see cref="WorkingInventory"/>.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArguments">Ignored</param>
        private void RemoveSlotButton_Click(object sender, EventArgs eventArguments)
        {
            if (SlotsListBox.SelectedItem is InventorySlot slot)
            {
                WorkingInventory.Take(slot);
                SlotsListBox.Items.RemoveAt(SlotsListBox.SelectedIndex);
            }
        }
        #endregion

        #region Closing Form
        /// <summary>
        /// Closes the <see cref="InventoryEditorForm"/>, signaling that the edited <see cref="Inventory"/> was accepted.
        /// </summary>
        /// <param name="sender">The originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void OkayButton_Click(object sender, EventArgs eventArguments)
        {
            ((ICollection<InventorySlot>)CurrentCharacter.StartingInventory).Clear();
            CurrentCharacter.StartingInventory.Capacity = WorkingInventory.Capacity;
            foreach (var inventorySlot in WorkingInventory)
            {
                CurrentCharacter.StartingInventory.Give(inventorySlot);
            }
            WorkingInventory = Inventory.Empty;
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Closes the <see cref="InventoryEditorForm"/>, signaling to abandon the edited <see cref="Inventory"/>.
        /// </summary>
        /// <param name="sender">The originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void CancelButtonControl_Click(object sender, EventArgs eventArguments)
        {
            WorkingInventory = Inventory.Empty;
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion
    }
}
