using System;
using System.Windows.Forms;
using ParquetClassLibrary;

namespace Scribe.CommandHistory
{
    /// <summary>
    /// Encapsulates a request, providing both the ability to act on the request and to take it back.
    /// </summary>
    internal abstract class Command
    {
        /// <summary>A summary of the action.</summary>
        internal string Description;

        /// <summary>A copy of the reference to the <see cref="Form"/> displaying the value being changed.</summary>
        protected readonly UndoTestForm Owner;

        /// <summary>A copy of the reference to the <see cref="Form"/>'s <see cref="Control"/> displaying the value being changed.</summary>
        protected readonly Control EditableControl;

        /// <summary>State before performing the action.</summary>
        protected object OldState;

        /// <summary>State after performing the action.</summary>
        protected object NewState;

        /// <summary>
        /// How to take the action.
        /// </summary>
        internal abstract void Execute();

        /// <summary>
        /// How to undo the action.
        /// </summary>
        internal abstract void Reverse();

        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        /// <param name="inDescription">A summary of the action.</param>
        internal Command(object inOldState, object inNewState, Control inEditableControl, UndoTestForm inOwner)
        {
            OldState = inOldState;
            NewState = inNewState;

            Precondition.IsNotNull(inEditableControl, nameof(inEditableControl));
            EditableControl = inEditableControl;

            Precondition.IsNotNull(inOwner, nameof(inOwner));
            Owner = inOwner;

            var displayOldState = (string.IsNullOrEmpty(inOldState as string) ? "null" : inOldState.ToString());
            var displayNewState = (string.IsNullOrEmpty(inNewState as string) ? "null" : inNewState.ToString());
            Description = $"alter value of {inEditableControl.Name} from {displayOldState} to {displayNewState}";
        }
    }
}
