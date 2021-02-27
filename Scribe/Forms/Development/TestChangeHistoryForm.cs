using System;
using System.Windows.Forms;
using Scribe.ChangeHistory;

namespace Scribe.Forms.Development
{
    /// <summary>
    /// A simple form used to test the undo feature before data-binding is finished.
    /// </summary>
    public partial class TestChangeHistoryForm : Form
    {
        /// <summary>The backing field for <see cref="OldValue"/>.</summary>
        private string _oldValue = "";

        /// <summary>
        /// Tracks whether or not a <see cref="Control"/>'s state has changed.
        /// </summary>
        /// <remarks>
        /// Whenever a <see cref="Form"/> reports a control's value as having been changed, the new value may
        /// be compared against this stored value to see if the change was substantive.  In other worse, WinForms
        /// regards TextBox.Text='2' -> TextBox.Text='4' -> TextBox.Text='2' as a change; however, the initial and
        /// end states are indistinguishable and the <see cref="ChangeManager"/> should not consider this a <see cref="Change"/>.
        /// </remarks>
        public string OldValue
        {
            get => _oldValue;
            set
            {
                _oldValue = value;
                LabelOldValue.Text = $"Old Value: {value}";
            }
        }

        /// <summary>The backing field for <see cref="DatabaseValue"/>.</summary>
        private string _databaseValue = "";

        /// <summary>
        /// Stands in for Parquet.All.
        /// </summary>
        public object DatabaseValue
        {
            get => _databaseValue;
            set
            {
                _databaseValue = value?.ToString() ?? "";
                LabelDBValue.Text = $"Database Value: {value}";
                LabelStoredChanges.Text = $"Stored Changes: {ChangeManager.Count}";
            }
        }

        /// <summary>
        /// Initializes a new instance of UndoTestForm.
        /// </summary>        
        public TestChangeHistoryForm()
            => InitializeComponent();

        /// <summary>
        /// Responds to a form value being updated.  The update may or may not correspond to a substantive change.
        /// </summary>
        /// <param name="sender">The control that was updated.</param>
        /// <param name="e">Ignored.</param>
        private void TextBox1_Validated(object sender, EventArgs e)
        {
            if (sender is TextBox textbox
                && string.Compare(textbox.Text, OldValue, comparisonType: StringComparison.OrdinalIgnoreCase) != 0)
            {
                ChangeManager.AddAndExecute(new ChangeValue(OldValue, textbox.Text, textbox.Name,
                                            (object databaseValue) => DatabaseValue = databaseValue.ToString(),
                                            (object displayValue) => textbox.Text = displayValue.ToString(),
                                            (object oldValue) => OldValue = oldValue.ToString()));
            }
        }

        /// <summary>
        /// Responds to the user requesting the Undo feature.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void ButtonUndo_Click(object sender, EventArgs e)
            => ChangeManager.Undo();

        /// <summary>
        /// Responds to the user requesting the Redo feature.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void ButtonRedo_Click(object sender, EventArgs e)
            => ChangeManager.Redo();
    }
}
