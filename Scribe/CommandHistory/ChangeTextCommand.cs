using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ParquetClassLibrary;

namespace Scribe.CommandHistory
{
    /// <summary>
    /// Encapsulates a request to change a text field, providing both the ability to act on the request and to take it back.
    /// </summary>
    internal class ChangeTextCommand : Command
    {
        /// <summary>Part of a message describing the command.</summary>
        private readonly string Summary;

        /// <summary>A copy of the reference to the <see cref="Form"/>'s <see cref="TextBox"/> displaying the value being changed.</summary>
        private TextBox TextBoxControl;

        /// <summary>A copy of the reference to the <see cref="Form"/>'s value memento for use in change-tracking.</summary>
        private object OldValue;

        /// <summary>A copy of the reference to <see cref="All"/>'s value for use in data-changing.</summary>
        private object DatabaseValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        internal ChangeTextCommand(string inOldState, string inNewState, TextBox inTextBoxControl,
                                   ref object inDatabaseValue, ref object inOldValue)
            : base($"alter value of {inTextBoxControl.Name}")
        {
            Precondition.IsNotNull(inOldValue, nameof(inOldValue));
            Precondition.IsNotNull(inDatabaseValue, nameof(inDatabaseValue));
            Precondition.IsNotNull(inTextBoxControl, nameof(inTextBoxControl));
            OldValue = inOldValue;
            DatabaseValue = inDatabaseValue;
            TextBoxControl = inTextBoxControl;

            OldState = inOldState;
            NewState = inNewState;

            var displayOldValue = string.IsNullOrEmpty(inOldState) ? "null" : inOldState;
            var displayNewValue = string.IsNullOrEmpty(inNewState) ? "null" : inNewState;
            Summary = $"value changed from {displayOldValue} to {displayNewValue}";
        }

        /// <summary>
        /// How to take the action.
        /// </summary>
        internal override void Execute()
        {
            MessageBox.Show($"[EXECUTE {Description}: {Summary}.]\n{DatabaseValue} to {NewState}");

            OldValue = DatabaseValue;
            DatabaseValue = NewState;
            TextBoxControl.Text = NewState.ToString();
        }

        /// <summary>
        /// How to undo the action.
        /// </summary>
        internal override void Reverse()
        {
            MessageBox.Show($"[REVERSE {Description}: {Summary}.]\n{DatabaseValue} to {OldState}");

            OldValue = DatabaseValue;
            DatabaseValue = OldState;
            TextBoxControl.Text = OldState.ToString();
        }
    }
}
