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

        /// <summary>A copy of the reference to the <see cref="Form"/>'s <see cref="Control"/> displaying the value being changed.</summary>
        protected readonly Control EditableControl;

        /// <summary>The means to set the state in the backing store.</summary>
        protected readonly Action<object> SetDatabaseValue;

        /// <summary>The means to set the state in the change-tracker.</summary>
        protected readonly Action<string> SetOldValue;

        /// <summary>The means to get the state from the change-tracker.</summary>
        protected readonly Func<object> GetOldValue;

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
        /// <param name="inOldState"></param>
        /// <param name="inNewState"></param>
        /// <param name="inEditableControl"></param>
        /// <param name="inSetDatabaseValue"></param>
        /// <param name="inSetOldValue"></param>
        /// <param name="inGetOldValue"></param>
        internal Command(object inOldState, object inNewState, Control inEditableControl,
                         Action<object> inSetDatabaseValue, Action<string> inSetOldValue, Func<object> inGetOldValue)
        {
            Precondition.IsNotNull(inEditableControl, nameof(inEditableControl));
            Precondition.IsNotNull(inSetDatabaseValue, nameof(inSetDatabaseValue));
            Precondition.IsNotNull(inSetOldValue, nameof(inSetOldValue));
            Precondition.IsNotNull(inGetOldValue, nameof(inGetOldValue));

            OldState = inOldState;
            NewState = inNewState;
            EditableControl = inEditableControl;
            SetDatabaseValue = inSetDatabaseValue;
            SetOldValue = inSetOldValue;
            GetOldValue = inGetOldValue;

            var displayOldState = (string.IsNullOrEmpty(inOldState as string) ? "null" : inOldState.ToString());
            var displayNewState = (string.IsNullOrEmpty(inNewState as string) ? "null" : inNewState.ToString());
            Description = $"alter value of {inEditableControl.Name} from {displayOldState} to {displayNewState}";
        }
    }
}
