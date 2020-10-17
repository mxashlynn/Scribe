using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using ParquetClassLibrary.Crafts;
using ParquetClassLibrary.EditorSupport;

namespace Scribe
{
    /// <summary>
    /// A form that enables the user to edit a given <see cref="ParquetClassLibrary.Crafts.StrikePanelGrid"/>.
    /// </summary>
    internal partial class StrikePatternEditorForm : Form
    {
        #region Cached Controls
        /// <summary>
        /// A collection of all themed <see cref="Component"/>s in the <see cref="StrikePatternEditorForm"/>.
        /// </summary>
        private readonly Dictionary<Type, List<Component>> ThemedComponents;

        /// <summary>
        /// A collection of all editable <see cref="GroupBox"/>es in the <see cref="StrikePatternEditorForm"/>.
        /// </summary>
        private readonly Dictionary<(int, int), GroupBox> EditableGroupBoxes;
        #endregion

        #region Content Being Edited
        /// <summary>The <see cref="CraftingRecipe"/> whose <see cref="StrikePanelGrid"/> might be edited.</summary>
        public IMutableCraftingRecipe CurrentCraft { get; set; }

        /// <summary>
        /// A <see cref="StrikePanelGrid"/> that the user interacts with in this form.
        /// It is only attached to the <see cref="CraftingRecipe"/> if the user selects the <see cref="OkayButton"/>.
        /// </summary>
        private StrikePanelGrid WorkingGrid { get; set; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initialize a new <see cref="StrikePatternEditorForm"/>.
        /// </summary>
        public StrikePatternEditorForm()
        {
            InitializeComponent();
            ThemedComponents = GetThemedComponents();
            EditableGroupBoxes = GetGroupBoxes();
        }

        /// <summary>
        /// Resets the UI each time the <see cref="Form"/> is loaded.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void StrikePatternEditorForm_Load(object sender, EventArgs eventArguments)
        {
            if (null == CurrentCraft)
            {
                DialogResult = DialogResult.Abort;
                Close();
            }
            else
            {
                ApplyCurrentTheme();
                WorkingGrid = (StrikePanelGrid)CurrentCraft.PanelPattern.Clone();
                //UpdateControlsBasedOnModel();

                var names = EditableGroupBoxes[(0, 0)].GetAllChildren()
                                                      .Select(control => control.Name)
                                                      .ToArray();
                var namesCombined = string.Join(Environment.NewLine, names);
                MessageBox.Show($"The children of EditableGroupBoxes[(0,0)] are: {namesCombined}");
            }
        }
        #endregion

        #region Cache Controls
        /// <summary>
        /// Finds all themed <see cref="Component"/>s in the <see cref="StrikePatternEditorForm"/>.
        /// </summary>
        /// <returns>A dictionary containing lists of components, organized by type.</returns>
        private Dictionary<Type, List<Component>> GetThemedComponents()
        {
            var themed = new Dictionary<Type, List<Component>>
            {
                [typeof(GroupBox)] = new List<Component>(),
                [typeof(TextBox)] = new List<Component>(),
                [typeof(Label)] = new List<Component>(),
            };
            themed[typeof(GroupBox)].AddRange(this.GetAllChildrenExactlyOfType<GroupBox>());
            themed[typeof(TextBox)].AddRange(this.GetAllChildrenExactlyOfType<TextBox>());
            themed[typeof(Label)].AddRange(this.GetAllChildrenExactlyOfType<Label>());
            return themed;
        }

        /// <summary>
        /// Finds all editable <see cref="GroupBox"/>es in the <see cref="StrikePatternEditorForm"/>
        /// organized according to their coordinates.
        /// </summary>
        /// <returns>A dictionary containing lists of boxes.</returns>
        private Dictionary<(int, int), GroupBox> GetGroupBoxes()
        {
            var editable = new Dictionary<(int, int), GroupBox>();
            var allGroupBoxes = this.GetAllChildrenExactlyOfType<GroupBox>();
            foreach(var groupBox in allGroupBoxes)
            {
                var x = CharUnicodeInfo.GetDecimalDigitValue(groupBox.Name[^1]);
                var y = CharUnicodeInfo.GetDecimalDigitValue(groupBox.Name[^2]);
                editable[(y, x)] = groupBox;
            }
            return editable;
        }
        #endregion

        #region Color Theming
        /// <summary>
        /// Applies the <see cref="CurrentTheme"/> to the <see cref="StrikePatternEditorForm"/> and its <see cref="Control"/>s.
        /// </summary>
        private void ApplyCurrentTheme()
        {
            #region Apply Theme to Primary Form
            BackColor = CurrentTheme.ControlBackgroundColor;
            ForeColor = CurrentTheme.ControlForegroundColor;
            OkayButton.BackColor = CurrentTheme.ControlBackgroundColor;
            OkayButton.FlatAppearance.BorderColor = CurrentTheme.BorderColor;
            OkayButton.FlatAppearance.MouseDownBackColor = CurrentTheme.MouseDownColor;
            OkayButton.FlatAppearance.MouseOverBackColor = CurrentTheme.MouseOverColor;
            CancelButtonControl.BackColor = CurrentTheme.ControlBackgroundColor;
            CancelButtonControl.FlatAppearance.BorderColor = CurrentTheme.BorderColor;
            CancelButtonControl.FlatAppearance.MouseDownBackColor = CurrentTheme.MouseDownColor;
            CancelButtonControl.FlatAppearance.MouseOverBackColor = CurrentTheme.MouseOverColor;
            #endregion

            #region Apply Theme to Controls
            foreach (var groupBox in ThemedComponents[typeof(GroupBox)])
            {
                ((GroupBox)groupBox).BackColor = CurrentTheme.ControlBackgroundColor;
                ((GroupBox)groupBox).ForeColor = CurrentTheme.ControlForegroundColor;
            }
            foreach (var textBox in ThemedComponents[typeof(TextBox)])
            {
                ((TextBox)textBox).BackColor = CurrentTheme.ControlBackgroundWhite;
                ((TextBox)textBox).ForeColor = CurrentTheme.ControlForegroundColor;
            }
            foreach (var label in ThemedComponents[typeof(Label)])
            {
                ((Label)label).BackColor = CurrentTheme.UneditableBackgroundColor;
                ((Label)label).ForeColor = CurrentTheme.ControlForegroundColor;
            }
            #endregion
        }
        #endregion

        #region Update Display
        /// <summary>
        /// Repopulates all <see cref="Control"/>s with the <see cref="WorkingGrid"/>.
        /// </summary>
        private void UpdateControlsBasedOnModel()
        {
            for (var x = 0; x < WorkingGrid.Columns; x++)
            {
                for (var y = 0; y < WorkingGrid.Rows; y++)
                {
                    EditableGroupBoxes[(y, x)].GetAllChildrenExactlyOfType<CheckBox>().First().Checked =
                        EditableGroupBoxes[(y, x)].Enabled =
                        StrikePanel.Unused != WorkingGrid[y, x];
                    // TODO Update other elements.
                }
            }
        }
        #endregion

        #region Validation
        /// <summary>
        /// Intercepts keydown events to register user requests to refresh the display.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="inKeyEvents">The key that was held down.</param>
        private void InventoryEditorForm_KeyDown(object sender, KeyEventArgs inKeyEvents)
        {
            if (inKeyEvents.KeyCode == Keys.F5)
            {
                UpdateControlsBasedOnModel();
            }
        }

        /// <summary>
        /// Determines if the value entered is valid.
        /// Adjusts the capacity of the <see cref="WorkingGrid"/> according to valid values, otherwise signals an input error.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventAruments">Whether or not to discard the given text.</param>
        private void CapacityTextBox_Validating(object sender, CancelEventArgs eventAruments)
        {
            /* TODO implement this
            if (int.TryParse(CapacityTextBox.Text, out var parsedCapacity)
                && parsedCapacity > 0)
            {
                WorkingGrid.Capacity = parsedCapacity;
                CapacityErrorProvider.SetError(CapacityTextBox, "");
            }
            else
            {
                eventAruments.Cancel = true;
                CapacityErrorProvider.SetError(CapacityTextBox, Resources.ErrorPositiveIntegersOnly);
            }
            */
        }
        #endregion

        #region Closing Form
        /// <summary>
        /// Closes the <see cref="StrikePatternEditorForm"/>, accepting the edited <see cref="StrikePanelGrid"/>.
        /// </summary>
        /// <param name="sender">The originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void OkayButton_Click(object sender, EventArgs eventArguments)
        {
            /* TODO implement this
            CurrentCharacter.StartingInventory.Clear();
            CurrentCharacter.StartingInventory.Capacity = WorkingGrid.Capacity;
            foreach (var inventorySlot in WorkingGrid)
            {
                CurrentCharacter.StartingInventory.Give(inventorySlot);
            }
            WorkingGrid = Inventory.Empty;
            DialogResult = DialogResult.OK;
            Close();
            */
        }

        /// <summary>
        /// Closes the <see cref="StrikePatternEditorForm"/>, abandoning the edited <see cref="StrikePatternGrid"/>.
        /// </summary>
        /// <param name="sender">The originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void CancelButtonControl_Click(object sender, EventArgs eventArguments)
        {
            WorkingGrid = StrikePanelGrid.Empty;
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion
    }
}
