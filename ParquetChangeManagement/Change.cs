namespace ParquetChangeManagement
{
    /// <summary>
    /// Encapsulates a change request, providing both the ability to act on the request and to take it back.
    /// </summary>
    public abstract class Change
    {
        /// <summary>A summary of taking the action.</summary>
        public string DescriptionOfExecution { get; set; }

        /// <summary>A summary of reversing the action.</summary>
        public string DescriptionOfReversal { get; set; }

        /// <summary>
        /// Make the change.
        /// </summary>
        public abstract void Execute();

        /// <summary>
        /// Reverse the change.
        /// </summary>
        public abstract void Reverse();
    }
}
