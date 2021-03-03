using System;

namespace ParquetChangeManagement
{
    /// <summary>
    /// Encapsulates a change-of-value request, providing both the ability to act on the request and to take it back.
    /// </summary>
    public class ChangeValue : Change
    {
        /// <summary>State before change.</summary>
        protected object OldState { get; }

        /// <summary>State after change.</summary>
        protected object NewState { get; }

        /// <summary>The means to set the state in the backing store.</summary>
        protected Action<object> SetDatabaseValue { get; }

        /// <summary>The means to set the state in the UI.</summary>
        protected Action<object> SetDisplayValue { get; }

        /// <summary>The means to set the state in an external request-tracker.</summary>
        /// <remarks>Calling code uses this to evaluate if a change is substantive or not.</remarks>
        protected Action<object> SetOldValue { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeValue"/> class.
        /// </summary>
        /// <param name="inOldState">State before change.</param>
        /// <param name="inNewState">State after change.</param>
        /// <param name="inControlName">Used in constructing a summary of the change.</param>
        /// <param name="inSetDatabaseValue">The means to set the state in the backing store.</param>
        /// <param name="inSetDisplayValue">The means to set the state in the UI.</param>
        /// <param name="inSetOldValue">The means to set the state in the UI request-tracker.</param>
        public ChangeValue(object inOldState, object inNewState, string inControlName,
                           Action<object> inSetDatabaseValue, Action<object> inSetDisplayValue, Action<object> inSetOldValue)
        {
            if (inSetDatabaseValue is null) { throw new ArgumentNullException(nameof(inSetDatabaseValue)); }
            if (inSetDisplayValue is null) { throw new ArgumentNullException(nameof(inSetDisplayValue)); }
            if (inSetOldValue is null) { throw new ArgumentNullException(nameof(inSetOldValue)); }

            OldState = inOldState;
            NewState = inNewState;
            SetDatabaseValue = inSetDatabaseValue;
            SetDisplayValue = inSetDisplayValue;
            SetOldValue = inSetOldValue;

            var displayOldState = string.IsNullOrEmpty(inOldState as string)
                ? "null"
                : inOldState.ToString();
            var displayNewState = string.IsNullOrEmpty(inNewState as string)
                ? "null"
                : inNewState.ToString();
            Description = $"alter value of {inControlName} from {displayOldState} to {displayNewState}";
        }

        /// <summary>
        /// Make the change.
        /// </summary>
        public override void Execute()
        {
            SetOldValue(NewState);
            SetDatabaseValue(NewState);
            SetDisplayValue(NewState);
        }

        /// <summary>
        /// Reverse the change.
        /// </summary>
        public override void Reverse()
        {
            SetOldValue(OldState);
            SetDatabaseValue(OldState);
            SetDisplayValue(OldState);
        }
    }
}
