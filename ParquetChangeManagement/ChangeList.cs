using System;
using Parquet;

namespace ParquetChangeManagement
{
    /// <summary>
    /// Encapsulates a request to add an object to a list, providing both the ability to act on the request and to take it back.
    /// </summary>
    internal class ChangeList : Change
    {
        /// <summary>The value being added or removed.</summary>
        protected object Value { get; }

        /// <summary>What to do when making the change.</summary>
        protected Action<object> OnExecute { get; }

        /// <summary>What to do when reversing the change.</summary>
        protected Action<object> OnReverse { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeList"/> class.
        /// </summary>
        /// <param name="inDatabaseList">The list whose state is changing.</param>
        /// <param name="inValue">The value being added or removed.</param>
        /// <param name="inDescription">Used in constructing a summary of the change.</param>
        /// <param name="inOnExecute">The means to add the value to the list in the backing store and update the UI.</param>
        /// <param name="inOnRemove">What to do when reversing the change.</param>
        internal ChangeList(object inValue, string inDescription, Action<object> inOnExecute, Action<object> inOnRemove)
        {
            Precondition.IsNotNull(inValue, nameof(inValue));
            Precondition.IsNotNullOrEmpty(inDescription, nameof(inDescription));
            Precondition.IsNotNull(inOnExecute, nameof(inOnExecute));
            Precondition.IsNotNull(inOnRemove, nameof(inOnRemove));

            Value = inValue;
            Description = inDescription;
            OnExecute = inOnExecute;
            OnReverse = inOnRemove;
        }

        /// <summary>
        /// Make the change.
        /// </summary>
        internal override void Execute()
            => OnExecute(Value);

        /// <summary>
        /// Reverse the change.
        /// </summary>
        internal override void Reverse()
            => OnReverse(Value);
    }
}
