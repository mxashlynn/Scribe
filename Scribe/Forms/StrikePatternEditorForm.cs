using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Parquet.Crafts;
using Parquet.EditorSupport;
using Scribe.Properties;

namespace Scribe.Forms
{
    /// <summary>
    /// A form that enables the user to edit a given <see cref="Parquet.Crafts.StrikePanelGrid"/>.
    /// </summary>
    internal partial class StrikePatternEditorForm : Form
    {
        #region Form Details
        /// <summary>How many <see cref="GroupBox"/>es are arranged horizontally across the <see cref="Form"/>.</summary>
        private int FormMaxRows = 0;

        /// <summary>How many <see cref="GroupBox"/>es are arranged vertically down the <see cref="Form"/>.</summary>
        private int FormMaxColumns = 0;

        /// <summary>When <c>true</c> it is not necessary to validate input.</summary>
        private bool IsUpdating = false;
        #endregion

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
            if (CurrentCraft is null)
            {
                DialogResult = DialogResult.Abort;
                Close();
            }
            else
            {
                ApplyCurrentTheme();
                WorkingGrid = (StrikePanelGrid)CurrentCraft.PanelPattern.Clone();
                UpdateControlsBasedOnModel();
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
                if (x > FormMaxColumns) { FormMaxColumns = x; }
                if (y > FormMaxRows) { FormMaxRows = y; }
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
                ((Label)label).BackColor = CurrentTheme.ControlBackgroundColor;
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
            IsUpdating = true;
            for (var x = 0; x <= FormMaxColumns; x++)
            {
                for (var y = 0; y <= FormMaxRows; y++)
                {
                    var panelIsActive = x < WorkingGrid.Columns
                                        && y < WorkingGrid.Rows
                                        && !StrikePanel.Unused.Equals(WorkingGrid[y, x]);
                    EditableGroupBoxes[(y, x)].GetAllChildrenExactlyOfType<CheckBox>()
                                              .First()
                                              .Checked = panelIsActive;
                    EditableGroupBoxes[(y, x)].GetAllChildrenExactlyOfType<TableLayoutPanel>()
                                              .First()
                                              .Enabled = panelIsActive;
                    var textBoxes = EditableGroupBoxes[(y, x)].GetAllChildrenExactlyOfType<TextBox>();
                    textBoxes.Where(control => control.Name.StartsWith("RangeStart"))
                                .First()
                                .Text = panelIsActive
                                ? WorkingGrid[y, x].WorkingRange.Minimum.ToString()
                                : "";
                    textBoxes.Where(control => control.Name.StartsWith("RangeEnd"))
                                .First()
                                .Text = panelIsActive
                                ? WorkingGrid[y, x].WorkingRange.Maximum.ToString()
                                : "";
                    textBoxes.Where(control => control.Name.StartsWith("GoalStart"))
                                .First()
                                .Text = panelIsActive
                                ? WorkingGrid[y, x].IdealRange.Minimum.ToString()
                                : "";
                    textBoxes.Where(control => control.Name.StartsWith("GoalEnd"))
                                .First()
                                .Text = panelIsActive
                                ? WorkingGrid[y, x].IdealRange.Maximum.ToString()
                                : "";
                }
            }
            IsUpdating = false;
        }
        #endregion

        #region Handle Changes to Data
        /// <summary>
        /// Updates an editable <see cref="GroupBox"/> when its Panel Active <see cref="CheckBox"/>'s state changes.
        /// </summary>
        /// <param name="sender">The check box that raised the event.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void PanelActiveCheckBox_CheckedChanged(object sender, EventArgs eventArguments)
        {
            if (!IsUpdating)
            {
                var checkBox = (CheckBox)sender;
                checkBox.Parent
                        .GetAllChildrenExactlyOfType<TableLayoutPanel>()
                        .First()
                        .Enabled = checkBox.Checked;
            }
        }

        /// <summary>
        /// Updates the <see cref="WorkingGrid"/> when a <see cref="TextBox"/>'s contents is changed.
        /// </summary>
        /// <param name="sender">The text box that raised the event.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void RangeStartTextBox_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            if (int.TryParse(textBox.Text?.ToString() ?? "", NumberStyles.Integer, null, out var parsedInt))
            {
                var x = CharUnicodeInfo.GetDecimalDigitValue(textBox.Parent.Parent.Name[^1]);
                var y = CharUnicodeInfo.GetDecimalDigitValue(textBox.Parent.Parent.Name[^2]);

                if(x >= WorkingGrid.Columns)
                {
                    WorkingGrid = new StrikePanelGrid(WorkingGrid, WorkingGrid.Rows, x + 1);
                }
                if (y >= WorkingGrid.Rows)
                {
                    WorkingGrid = new StrikePanelGrid(WorkingGrid, y + 1, WorkingGrid.Columns);
                }

                if (textBox.Name.StartsWith("RangeStart"))
                {
                    var newMax = parsedInt < WorkingGrid[y, x].WorkingRange.Maximum
                        ? WorkingGrid[y, x].WorkingRange.Maximum
                        : parsedInt + 1;
                    WorkingGrid[y, x].WorkingRange =
                        new Parquet.Range<int>(parsedInt, newMax);
                }
                else if (textBox.Name.StartsWith("RangeEnd"))
                {
                    var newMin = WorkingGrid[y, x].WorkingRange.Minimum < parsedInt
                        ? WorkingGrid[y, x].WorkingRange.Minimum
                        : parsedInt - 1;
                    WorkingGrid[y, x].WorkingRange =
                        new Parquet.Range<int>(newMin, parsedInt);
                }
                else if (textBox.Name.StartsWith("GoalStart"))
                {
                    var newMax = parsedInt < WorkingGrid[y, x].IdealRange.Maximum
                        ? WorkingGrid[y, x].IdealRange.Maximum
                        : parsedInt + 1;
                    WorkingGrid[y, x].IdealRange =
                        new Parquet.Range<int>(parsedInt, newMax);
                }
                else if (textBox.Name.StartsWith("GoalEnd"))
                {
                    var newMin = WorkingGrid[y, x].IdealRange.Minimum < parsedInt
                        ? WorkingGrid[y, x].IdealRange.Minimum
                        : parsedInt - 1;
                    WorkingGrid[y, x].IdealRange =
                        new Parquet.Range<int>(newMin, parsedInt);
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
        private void StrikePatternEditorForm_KeyDown(object sender, KeyEventArgs inKeyEvents)
        {
            if (inKeyEvents.KeyCode == Keys.F5)
            {
                UpdateControlsBasedOnModel();
            }
        }

        /// <summary>
        /// Determines if the value entered is valid.
        /// </summary>
        /// <param name="sender">The text box that raised the event.</param>
        /// <param name="eventAruments">Whether or not to discard the given text.</param>
        private void TextBox_Validating(object sender, CancelEventArgs eventAruments)
        {
            var textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text)
                || int.TryParse(textBox.Text, out _))
            {
                RangeErrorProvider.SetError(textBox, "");
            }
            else
            {
                eventAruments.Cancel = true;
                RangeErrorProvider.SetError(textBox, Resources.ErrorIntegersOnly);
            }
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
            CurrentCraft.PanelPatternReplace(WorkingGrid);
            WorkingGrid = StrikePanelGrid.Empty;
            DialogResult = DialogResult.OK;
            Close();
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
