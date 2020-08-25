namespace Scribe.ChangeHistory
{
    /// <summary>
    /// Encapsulates a change request, providing both the ability to act on the request and to take it back.
    /// </summary>
    internal abstract class Change
    {
        /// <summary>A summary of the action.</summary>
        internal string Description;

        /// <summary>
        /// How to make the change.
        /// </summary>
        internal abstract void Execute();

        /// <summary>
        /// How to undo the change.
        /// </summary>
        internal abstract void Reverse();
    }
}
