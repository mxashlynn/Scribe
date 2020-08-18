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

        /// <summary>A copy of the reference to the <see cref="Form"/> displaying the value being changed.</summary>
        private readonly UndoTestForm Owner;

        /// <summary>A copy of the reference to the <see cref="Form"/>'s <see cref="TextBox"/> displaying the value being changed.</summary>
        private readonly TextBox TextBoxControl;

        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        internal ChangeTextCommand(string inOldState, string inNewState, TextBox inTextBoxControl, UndoTestForm inOwner)
            : base($"alter value of {inTextBoxControl.Name}")
        {
            Precondition.IsNotNull(inTextBoxControl, nameof(inTextBoxControl));
            Precondition.IsNotNull(inOwner, nameof(inOwner));
            TextBoxControl = inTextBoxControl;
            Owner = inOwner;

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
            //MessageBox.Show($"[EXECUTE {Description}: {Summary}.]\n{Owner.DatabaseValue} to {NewState}");

            Owner.OldValue = NewState.ToString();
            Owner.DatabaseValue = NewState.ToString();
            TextBoxControl.Text = NewState.ToString();
        }

        /// <summary>
        /// How to undo the action.
        /// </summary>
        internal override void Reverse()
        {
            //MessageBox.Show($"[REVERSE {Description}: {Summary}.]\n{Owner.DatabaseValue} to {OldState}");

            Owner.OldValue = OldState.ToString();
            Owner.DatabaseValue = OldState.ToString();
            TextBoxControl.Text = OldState.ToString();
        }
    }
}
