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

        /// <summary>State before performing the action.</summary>
        internal object OldState;

        /// <summary>State after performing the action.</summary>
        internal object NewState;

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
        internal Command(string inDescription)
        {
            Precondition.IsNotNullOrEmpty(inDescription, nameof(inDescription));
            Description = inDescription;
        }
    }
}
