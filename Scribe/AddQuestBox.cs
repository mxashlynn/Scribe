using System;
using System.Linq;
using System.Windows.Forms;
using ParquetClassLibrary;
using ParquetClassLibrary.Scripts;

namespace Scribe
{
    /// <summary>
    /// A modal dialogue that enables the user to add a new <see cref="ParquetClassLibrary.Scripts.ScriptModel"/> representing a quest.
    /// </summary>
    internal partial class AddQuestBox : Form
    {
        /// <summary>The <see cref="ModelID"/> that the user added, if any.</summary>
        public ModelID ReturnNewQuestID { get; set; }

        #region Initialization
        /// <summary>
        /// Initialize a new <see cref="AddQuestBox"/>.
        /// </summary>
        public AddQuestBox()
            => InitializeComponent();

        /// <summary>
        /// Resets the UI each time the dialogue box is loaded.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void AddQuestBox_Load(object sender, EventArgs eventArguments)
        {
            if (ModelID.None == ReturnNewQuestID)
            {
                AddQuestComboBox.SelectedItem = null;
                AddQuestComboBox.BeginUpdate();
                AddQuestComboBox.Items.Clear();
                AddQuestComboBox.Items.AddRange(All.Interactions.Where(model => model.ID != ModelID.None).ToArray<object>());
                AddQuestComboBox.EndUpdate();
            }
            ApplyCurrentTheme();
            AddQuestComboBox.Select();
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
            AddQuestComboBox.BackColor = CurrentTheme.ControlBackgroundWhite;
            AddQuestComboBox.ForeColor = CurrentTheme.ControlForegroundColor;
            QuestLabel.BackColor = CurrentTheme.ControlBackgroundColor;
            QuestLabel.ForeColor = CurrentTheme.ControlForegroundColor;
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

        #region Closing Form
        /// <summary>
        /// Closes the <see cref="AddQuestBox"/>, signaling that the entered quest was accepted.
        /// </summary>
        /// <param name="sender">The originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void OkayButton_Click(object sender, EventArgs eventArguments)
        {
            (ReturnNewQuestID, DialogResult) = null == AddQuestComboBox.SelectedItem
                ? (ModelID.None, DialogResult.Cancel)
                : (((InteractionModel)AddQuestComboBox.SelectedItem).ID, DialogResult.OK);
            Close();
        }

        /// <summary>
        /// Closes the <see cref="AddQuestBox"/>, signaling to abandon any entered quest.
        /// </summary>
        /// <param name="sender">The originator of the event.</param>
        /// <param name="eventArguments">Additional event data.</param>
        private void CancelButtonControl_Click(object sender, EventArgs eventArguments)
        {
            ReturnNewQuestID = ModelID.None;
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion
    }
}
