using System;
using System.Linq;
using System.Windows.Forms;
using Parquet;
using Parquet.Scripts;

namespace Scribe.Forms
{
    /// <summary>
    /// A modal dialogue that enables the user to add a new <see cref="ScriptModel"/> representing a quest.
    /// </summary>
    internal partial class AddQuestBox : Form
    {
        /// <summary>The <see cref="ModelID"/> that the user added, if any.</summary>
        public ModelID ReturnNewQuestID { get; set; }

        /// <summary>The player-facing name corresponding to the ID that the user added, if any.</summary>
        public string ReturnNewQuestName { get; set; }

        #region Initialization
        /// <summary>
        /// Initialize a new <see cref="AddQuestBox"/>.
        /// </summary>
        public AddQuestBox()
            => InitializeComponent();

        /// <summary>
        /// Resets the UI each time the dialogue box is loaded.
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventArguments">Additional event data.</param>
        private void AddQuestBox_Load(object inSender, EventArgs inEventArguments)
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
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventArguments">Additional event data.</param>
        private void OkayButton_Click(object inSender, EventArgs inEventArguments)
        {
            (ReturnNewQuestID, ReturnNewQuestName, DialogResult) = AddQuestComboBox.SelectedItem is null
                ? (ModelID.None, "", DialogResult.Cancel)
                : (((InteractionModel)AddQuestComboBox.SelectedItem).ID,
                   ((InteractionModel)AddQuestComboBox.SelectedItem).Name,
                    DialogResult.OK);
            Close();
        }

        /// <summary>
        /// Closes the <see cref="AddQuestBox"/>, signaling to abandon any entered quest.
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventArguments">Additional event data.</param>
        private void CancelButtonControl_Click(object inSender, EventArgs inEventArguments)
        {
            ReturnNewQuestID = ModelID.None;
            ReturnNewQuestName = "";
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion
    }
}
