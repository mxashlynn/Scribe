using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Scribe.CommandHistory
{
    /// <summary>
    /// Tracks requests to make changes and stores them as <see cref="Command"/> objects to enable Undo and Redo functionality.
    /// </summary>
    internal static class UndoManager
    {
        /// <summary>A history of actions taken.</summary>
        private static List<Command> Commands = new List<Command>();

        /// <summary>The index of the <see cref="Command"/> that will be Undone next.</summary>
        private static int CurrentCommandIndex = -1;

        /// <summary>
        /// Empties the <see cref="Command"/> history and resets the manager.
        /// </summary>
        internal static void Clear()
        {
            Commands.Clear();
            CurrentCommandIndex = -1;
        }

        /// <summary>
        /// Add a new command to the history and immediately take action on it.
        /// </summary>
        /// <param name="inDescription">A summary of the action.</param>
        /// <param name="inExecture">How to take the action.</param>
        /// <param name="inReverse">How to undo the action.</param>
        internal static void AddAndExecute(Command inCommand)
        {
            MessageBox.Show($"There are {Commands.Count} stored and we are pointing at index {CurrentCommandIndex}.");
            CurrentCommandIndex++;
            if (CurrentCommandIndex > 0)
            {
                Commands = Commands.GetRange(0, CurrentCommandIndex);
            }
            Commands.Add(inCommand);
            Commands[CurrentCommandIndex].Execute();
        }

        /// <summary>
        /// Undo the last action done, if any.
        /// </summary>
        internal static void Undo()
        {
            if (CurrentCommandIndex > -1)
            {
                Commands[CurrentCommandIndex].Reverse();
                CurrentCommandIndex--;
            }
            else
            {
                MessageBox.Show("Did not Undo!");
            }
        }

        /// <summary>
        /// Redo the action most recently undone, if any.
        /// </summary>
        internal static void Redo()
        {
            if (CurrentCommandIndex < Commands.Count - 1)
            {
                CurrentCommandIndex++;
                Commands[CurrentCommandIndex].Execute();
            }
            else
            {
                MessageBox.Show("Did not Redo!");
            }
        }
    }
}
