using System;
using System.Windows.Forms;

namespace Scribe.CommandHistory
{
    /// <summary>
    /// Encapsulates a request to change a text field, providing both the ability to act on the request and to take it back.
    /// </summary>
    internal class ChangeTextCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        internal ChangeTextCommand(object inOldState, object inNewState, Control inEditableControl,
                                   Action<object> inSetDatabaseValue, Action<string> inSetOldValue, Func<object> inGetOldValue)
            : base(inOldState, inNewState, inEditableControl, inSetDatabaseValue, inSetOldValue, inGetOldValue)
        { }

        /// <summary>
        /// How to take the action.
        /// </summary>
        internal override void Execute()
        {
            SetOldValue(NewState.ToString());
            SetDatabaseValue(NewState.ToString());
            ((TextBox)EditableControl).Text = NewState.ToString();
        }

        /// <summary>
        /// How to undo the action.
        /// </summary>
        internal override void Reverse()
        {
            SetOldValue(OldState.ToString());
            SetDatabaseValue(OldState.ToString());
            ((TextBox)EditableControl).Text = OldState.ToString();
        }
    }
}
