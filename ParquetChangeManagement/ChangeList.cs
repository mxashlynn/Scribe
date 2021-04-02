using System;
using ParquetChangeManagement.Properties;

namespace ParquetChangeManagement
{
    /// <summary>
    /// Encapsulates a request to add an object to a list, providing both the ability to act on the request and to take it back.
    /// </summary>
    public class ChangeList : Change
    {
        /// <summary>The value being added or removed.</summary>
        protected object Value { get; }

        /// <summary>What to do when making the change.</summary>
        protected Action<object, string> OnExecute { get; }

        /// <summary>What to do when reversing the change.</summary>
        protected Action<object, string> OnReverse { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeList"/> class.
        /// </summary>
        /// <param name="inValue">The value being added or removed.</param>
        /// <param name="inDescription">A summary of the change.</param>
        /// <param name="inOnExecute">The means to add the value to the list in the backing store and update the UI.</param>
        /// <param name="inOnReverse">What to do when reversing the change.</param>
        public ChangeList(object inValue, string inDescription, Action<object, string> inOnExecute, Action<object, string> inOnReverse)
        {
            if (inValue is null) { throw new ArgumentNullException(nameof(inValue)); }
            if (string.IsNullOrEmpty(inDescription)) { throw new ArgumentNullException(nameof(inDescription)); }
            if (inOnExecute is null) { throw new ArgumentNullException(nameof(inOnExecute)); }
            if (inOnReverse is null) { throw new ArgumentNullException(nameof(inOnReverse)); }

            Value = inValue;
            DescriptionOfExecution = inDescription;
            DescriptionOfReversal = $"{Resources.UndoChangeListPrefix}{inDescription}";
            OnExecute = inOnExecute;
            OnReverse = inOnReverse;
        }

        /// <summary>
        /// Make the change.
        /// </summary>
        public override void Execute()
            => OnExecute(Value, DescriptionOfExecution);

        /// <summary>
        /// Reverse the change.
        /// </summary>
        public override void Reverse()
            => OnReverse(Value, DescriptionOfReversal);
    }
}
