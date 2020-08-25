using System;
using ParquetClassLibrary;

namespace Scribe.ChangeHistory
{
    /// <summary>
    /// Encapsulates a change-of-value request, providing both the ability to act on the request and to take it back.
    /// </summary>
    internal class ChangeValue : Change
    {
        /// <summary>State before change.</summary>
        protected object OldState;

        /// <summary>State after change.</summary>
        protected object NewState;

        /// <summary>The means to set the state in the backing store.</summary>
        protected readonly Action<object> SetDatabaseValue;

        /// <summary>The means to set the state in the backing store.</summary>
        protected readonly Action<object> SetDisplayValue;

        /// <summary>The means to set the state in the UI request-tracker.</summary>
        protected readonly Action<object> SetOldValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeValue"/> class.
        /// </summary>
        /// <param name="inOldState">State before change.</param>
        /// <param name="inNewState">State after change.</param>
        /// <param name="inControlName">Used in constructing a summary of the change.</param>
        /// <param name="inSetDatabaseValue">The means to set the state in the backing store.</param>
        /// <param name="inSetDisplayValue">The means to set the state in the backing store.</param>
        /// <param name="inSetOldValue">The means to set the state in the UI request-tracker.</param>
        internal ChangeValue(object inOldState, object inNewState, string inControlName,
                             Action<object> inSetDatabaseValue, Action<object> inSetDisplayValue, Action<object> inSetOldValue)
        {
            Precondition.IsNotNull(inSetDatabaseValue, nameof(inSetDatabaseValue));
            Precondition.IsNotNull(inSetDisplayValue, nameof(inSetDisplayValue));
            Precondition.IsNotNull(inSetOldValue, nameof(inSetOldValue));

            OldState = inOldState;
            NewState = inNewState;
            SetDatabaseValue = inSetDatabaseValue;
            SetDisplayValue = inSetDisplayValue;
            SetOldValue = inSetOldValue;

            var displayOldState = (string.IsNullOrEmpty(inOldState as string) ? "null" : inOldState.ToString());
            var displayNewState = (string.IsNullOrEmpty(inNewState as string) ? "null" : inNewState.ToString());
            Description = $"alter value of {inControlName} from {displayOldState} to {displayNewState}";
        }

        /// <summary>
        /// Make the change.
        /// </summary>
        internal override void Execute()
        {
            SetOldValue(NewState);
            SetDatabaseValue(NewState);
            SetDisplayValue(NewState);
        }

        /// <summary>
        /// Reverse the change.
        /// </summary>
        internal override void Reverse()
        {
            SetOldValue(OldState);
            SetDatabaseValue(OldState);
            SetDisplayValue(OldState);
        }
    }
}