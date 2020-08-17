using System;
using System.Collections.Generic;

namespace Scribe
{
    /// <summary>
    /// Tracks requests to make changes and stores them as <see cref="Command"/> objects to enable Undo and Redo functionality.
    /// </summary>
    internal static class UndoManager
    {
        /// <summary>A history of actions taken.</summary>
        private static readonly List<Command> Commands = new List<Command>();

        /// <summary>The index of the <see cref="Command"/> that will be Undone next.</summary>
        private static int CurrentCommandIndex = 0;

        /// <summary>
        /// Empties the <see cref="Command"/> history and resets the manager.
        /// </summary>
        internal static void Clear()
        {
            Commands.Clear();
            CurrentCommandIndex = 0;
        }

        /// <summary>
        /// Add a new command to the history and immediately take action on it.
        /// </summary>
        /// <param name="inDescription">A summary of the action.</param>
        /// <param name="inExecture">How to take the action.</param>
        /// <param name="inReverse">How to undo the action.</param>
        internal static void AddAndExecute(string inDescription, Action inExecture, Action inReverse)
        {
            Commands.Add(new Command(inDescription, inExecture, inReverse));
            CurrentCommandIndex++;
            Commands[CurrentCommandIndex].Execute();
        }

        /// <summary>
        /// Undo the last action done, if any.
        /// </summary>
        internal static void Undo()
        {
            if (CurrentCommandIndex > 0)
            {
                Commands[CurrentCommandIndex].Reverse();
                CurrentCommandIndex--;
            }
        }

        /// <summary>
        /// Redo the action most recently undone, if any.
        /// </summary>
        internal static void Redo()
        {
            if (CurrentCommandIndex < Commands.Count)
            {
                CurrentCommandIndex++;
                Commands[CurrentCommandIndex].Execute();
            }
        }
    }
}
