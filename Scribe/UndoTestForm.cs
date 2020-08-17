using System;
using System.Windows.Forms;

namespace Scribe
{
    /// <summary>
    /// A simple form used to test the undo feature before databinding is finished.
    /// </summary>
    public partial class UndoTestForm : Form
    {
        private string _oldValue = "";

        /// <summary>
        /// Tracks whether or not the form's state has changed.
        /// </summary>
        internal string OldValue
        {
            get => _oldValue;
            set
            {
                MessageBox.Show($"Changing OldValue from {(string.IsNullOrEmpty(_oldValue) ? "null" : _oldValue)} to {(string.IsNullOrEmpty(value) ? "null" : value)}.");
                _oldValue = value;
                LabelOldValue.Text = $"Old Value: {value}";
            }
        }

        private string _databaseValue = "";

        /// <summary>
        /// Stands in for ParquetClassLibrary.All.
        /// </summary>
        internal string DatabaseValue
        {
            get => _databaseValue;
            set
            {
                MessageBox.Show($"Changing DatabaseValue from {(string.IsNullOrEmpty(_databaseValue) ? "null" : _databaseValue)} to {(string.IsNullOrEmpty(value) ? "null" : value)}.");
                _databaseValue = value;
                LabelDBValue.Text = $"Database Value: {value}";
            }
        }


        /// <summary>
        /// Initializes a new instance of UndoTestForm.
        /// </summary>        
        public UndoTestForm()
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
                // TODO Make this into a proper class, nevermind using Actions.
                var localNewValue = textbox.Text;
                var localOldValue = OldValue;
                var message = $"value changed from {(string.IsNullOrEmpty(localOldValue) ? "null" : localOldValue)} to {(string.IsNullOrEmpty(localNewValue) ? "null" : localNewValue)}.]";

                UndoManager.AddAndExecute($"value changed from {localOldValue} to {localNewValue}.",
                                          () =>
                                          {
                                              MessageBox.Show($"[EXECUTE {message}.]\n{(string.IsNullOrEmpty(DatabaseValue) ? "null" : DatabaseValue)} to {(string.IsNullOrEmpty(localNewValue) ? "null" : localNewValue)}");
                                              
                                              OldValue = DatabaseValue;
                                              DatabaseValue = localNewValue;
                                              textbox.Text = DatabaseValue;
                                          },
                                          () =>
                                          {
                                              MessageBox.Show($"[REVERSE {message}.]\n{(string.IsNullOrEmpty(DatabaseValue) ? "null" : DatabaseValue)} to {(string.IsNullOrEmpty(localOldValue) ? "null" : localOldValue)}");

                                              OldValue = DatabaseValue;
                                              DatabaseValue = localOldValue;
                                              textbox.Text = DatabaseValue;
                                          });
            }
        }

        /// <summary>
        /// Responds to the user requesting the Undo feature.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void ButtonUndo_Click(object sender, EventArgs e)
            => UndoManager.Undo();

        /// <summary>
        /// Responds to the user requesting the Redo feature.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void ButtonRedo_Click(object sender, EventArgs e)
            => UndoManager.Redo();
    }
}
