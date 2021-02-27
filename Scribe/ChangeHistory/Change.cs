namespace Scribe.ChangeHistory
{
    /// <summary>
    /// Encapsulates a change request, providing both the ability to act on the request and to take it back.
    /// </summary>
    internal abstract class Change
    {
        /// <summary>A summary of the action.</summary>
        internal string Description { get; set; }

        /// <summary>
        /// Make the change.
        /// </summary>
        internal abstract void Execute();

        /// <summary>
        /// Reverse the change.
        /// </summary>
        internal abstract void Reverse();
    }
}
