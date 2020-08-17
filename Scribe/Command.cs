using System;
using ParquetClassLibrary;

namespace Scribe
{
    /// <summary>
    /// Encapsulates a request, providing both the ability to act on the request and to take it back.
    /// </summary>
    internal class Command
    {
        /// <summary>Summary of the action.</summary>
        internal string Description;

        /// <summary>How to take the action.</summary>
        internal Action Execute;

        /// <summary>How to undo the action.</summary>
        internal Action Reverse;

        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        /// <param name="inDescription">A summary of the action.</param>
        /// <param name="inExecture">How to take the action.</param>
        /// <param name="inReverse">How to undo the action.</param>
        internal Command(string inDescription, Action inExecture, Action inReverse)
        {
            Precondition.IsNotNullOrEmpty(inDescription, nameof(inDescription));
            Precondition.IsNotNull(inExecture, nameof(inExecture));
            Precondition.IsNotNull(inReverse, nameof(inReverse));

            Description = inDescription;
            Execute = inExecture;
            Reverse = inReverse;
        }
    }
}
