using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using Parquet;
using Parquet.Beings;
using Parquet.Items;
using Scribe.Properties;

namespace Scribe.Forms
{
    /// <summary>
    /// A modal form that enables the user to edit a given <see cref="InventoryCollection"/>.
    /// </summary>
    internal partial class InventoryEditorForm : Form
    {
        #region Child Forms
        /// <summary>Dialogue for adding an <see cref="InventorySlot"/> to an <see cref="InventoryCollection"/>.</summary>
        private readonly AddSlotBox AddSlotDialogue = new();
        #endregion

        #region Content Being Edited
        /// <summary>The <see cref="CharacterModel"/> whose <see cref="InventoryCollection"/> might be edited.</summary>
        public IMutableCharacterModel CurrentCharacter { get; set; }

        /// <summary>
        /// An <see cref="InventoryCollection"/> that the user interacts with in this form.
        /// It is only attached to the <see cref="CharacterModel"/> if the user selects the <see cref="OkayButton"/>.
        /// </summary>
        private InventoryCollection WorkingInventory { get; set; }
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
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventArguments">Additional event data.</param>
        private void InventoryEditorForm_Load(object inSender, EventArgs inEventArguments)
        {
            if (CurrentCharacter is null)
            {
                DialogResult = DialogResult.Abort;
                Close();
            }
            else
            {
                ApplyCurrentTheme();
                WorkingInventory = CurrentCharacter.StartingInventory.DeepClone();
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
            CapacityLabel.BackColor = CurrentTheme.ControlBackgroundColor;
            CapacityLabel.ForeColor = CurrentTheme.ControlForegroundColor;
            DefaultCapacityTextBox.BackColor = CurrentTheme.ControlBackgroundWhite;
            DefaultCapacityTextBox.ForeColor = CurrentTheme.ControlForegroundColor;
            DefaultCapacityLabel.BackColor = CurrentTheme.ControlBackgroundColor;
            DefaultCapacityLabel.ForeColor = CurrentTheme.ControlForegroundColor;
            SlotsListBox.BackColor = CurrentTheme.ControlBackgroundWhite;
            SlotsListBox.ForeColor = CurrentTheme.ControlForegroundColor;
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
        /// Repopulates the <see cref="DefaultCapacityTextBox"/> with the <see cref="InventoryConfiguration"/>.
        /// </summary>
        /// <remarks>This should only be called if the WorkingInventory has actually changed.</remarks>
        private void UpdateControls()
        {
            DefaultCapacityTextBox.Text = InventoryConfiguration.DefaultCapacity.ToString(CultureInfo.InvariantCulture);
            CapacityTextBox.Text = WorkingInventory?.Capacity.ToString(CultureInfo.InvariantCulture) ?? "";
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
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventArguments">Used to render the selected item.</param>
        private void SlotsListBox_DrawItem(object inSender, DrawItemEventArgs inEventArguments)
        {
            // Determine text to represent this InventorySlot.
            var thisSlot = (InventorySlot)SlotsListBox.Items[inEventArguments.Index];
            var thisSlotName = All.Items.GetOrNull<ItemModel>(thisSlot.ItemID).Name ?? nameof(InventorySlot);
            var thisSlotText = $"{thisSlot.Count} {thisSlotName}";
            // Render that text.
            inEventArguments.DrawBackground();
            TextRenderer.DrawText(inEventArguments.Graphics, thisSlotText, inEventArguments.Font, inEventArguments.Bounds,
                                  SlotsListBox.ForeColor);
            inEventArguments.DrawFocusRectangle();
        }
        #endregion

        #region Validation
        /// <summary>
        /// Intercepts key-down events to register user requests to refresh the display.
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inKeyEvents">The key that was held down.</param>
        private void InventoryEditorForm_KeyDown(object inSender, KeyEventArgs inKeyEvents)
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
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="eventAruments">Whether or not to discard the given text.</param>
        private void CapacityTextBox_Validating(object inSender, CancelEventArgs eventAruments)
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
        /// Determines if the value entered is valid.
        /// Adjusts the <see cref="InventoryConfiguration"/> according to valid values, otherwise signals an input error.
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventAruments">Whether or not to discard the given text.</param>
        private void DefaultCapacityTextBox_Validating(object inSender, CancelEventArgs inEventAruments)
        {
            if (int.TryParse(DefaultCapacityTextBox.Text, out var parsedCapacity)
                && parsedCapacity > 0)
            {
                InventoryConfiguration.DefaultCapacity = parsedCapacity;
                CapacityErrorProvider.SetError(DefaultCapacityTextBox, "");
            }
            else
            {
                inEventAruments.Cancel = true;
                CapacityErrorProvider.SetError(DefaultCapacityTextBox, Resources.ErrorPositiveIntegersOnly);
            }
        }

        /// <summary>
        /// Registers the user command to add a new <see cref="InventorySlot"/> to the <see cref="WorkingInventory"/>.
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventArguments">Additional event data.</param>
        private void AddSlotButton_Click(object inSender, EventArgs inEventArguments)
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
                    CapacityTextBox.Text = WorkingInventory.Capacity.ToString(CultureInfo.InvariantCulture);
                }

                if (0 == WorkingInventory.Give(AddSlotDialogue.ReturnNewSlot))
                {
                    SlotsListBox.Items.Add(AddSlotDialogue.ReturnNewSlot);
                }
                else
                {
                    SystemSounds.Beep.Play();
                    Logger.Log(LogLevel.Error, Resources.ErrorAddingSlot);
                }
            }
        }

        /// <summary>
        /// Registers the user command to remove the selected <see cref="InventorySlot"/> tag from the <see cref="WorkingInventory"/>.
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventArguments">Additional event data.</param>
        private void RemoveSlotButton_Click(object inSender, EventArgs inEventArguments)
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
        /// Closes the <see cref="InventoryEditorForm"/>, signaling that the edited <see cref="InventoryCollection"/> was accepted.
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventArguments">Additional event data.</param>
        private void OkayButton_Click(object inSender, EventArgs inEventArguments)
        {
            ((ICollection<InventorySlot>)CurrentCharacter.StartingInventory).Clear();
            CurrentCharacter.StartingInventory.Capacity = WorkingInventory.Capacity;
            foreach (var inventorySlot in WorkingInventory)
            {
                CurrentCharacter.StartingInventory.Give(inventorySlot);
            }
            WorkingInventory = InventoryCollection.Empty.DeepClone();
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Closes the <see cref="InventoryEditorForm"/>, signaling to abandon the edited <see cref="InventoryCollection"/>.
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventArguments">Additional event data.</param>
        private void CancelButtonControl_Click(object inSender, EventArgs inEventArguments)
        {
            WorkingInventory = InventoryCollection.Empty.DeepClone();
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            AddSlotDialogue.Dispose();
            base.Dispose(disposing);
        }
        #endregion
    }
}
