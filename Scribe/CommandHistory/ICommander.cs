namespace Scribe.CommandHistory
{
    /// <summary>
    /// Allows classes to issue <see cref="Command"/>s that the <see cref="UndoManager"/> can track and report on.
    /// </summary>
    internal interface ICommander
    {
        /// <summary>
        /// Tracks whether or not state has changed.
        /// </summary>
        public string OldValue { get; set; }

        /// <summary>
        /// Stands in for ParquetClassLibrary.All.
        /// </summary>
        public object DatabaseValue { get; set; }
    }
}
