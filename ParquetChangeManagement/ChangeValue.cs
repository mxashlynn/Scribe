using System;
using System.Globalization;
using ParquetChangeManagement.Properties;

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

        /// <summary>The means to set the state in the backing store, the UI, and the cache used to determine if a change is substantive.</param>
        protected Action<object, string> SetState { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeValue"/> class.
        /// </summary>
        /// <param name="inOldState">State before change.</param>
        /// <param name="inNewState">State after change.</param>
        /// <param name="inPropertyName">Name of variable being changed, used in constructing a summary of the change.</param>
        /// <param name="inSetState">The means to set the state in the backing store, the UI, and the cache used to determine if a change is substantive.</param>
        public ChangeValue(object inOldState, object inNewState, string inPropertyName, Action<object, string> inSetState)
        {
            if (inSetState is null) { throw new ArgumentNullException(nameof(inSetState)); }

            OldState = inOldState;
            NewState = inNewState;
            SetState = inSetState;

            var displayOldState = string.IsNullOrEmpty(inOldState as string)
                ? "null"
                : inOldState.ToString();
            var displayNewState = string.IsNullOrEmpty(inNewState as string)
                ? "null"
                : inNewState.ToString();
            DescriptionOfExecution = string.Format(CultureInfo.CurrentCulture, Resources.DoChangeValueDescription,
                                                   inPropertyName, displayOldState, displayNewState);
            DescriptionOfReversal = string.Format(CultureInfo.CurrentCulture, Resources.UndoChangeValueDescription,
                                                  inPropertyName, displayOldState, displayNewState);
        }

        /// <summary>
        /// Make the change.
        /// </summary>
        public override void Execute()
            => SetState(NewState, DescriptionOfExecution);

        /// <summary>
        /// Reverse the change.
        /// </summary>
        public override void Reverse()
            => SetState(OldState, DescriptionOfReversal);
    }
}
