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

        /// <summary>If <c>true</c> no more than <see cref="MaximumCommands"/> will ever be stored.</summary>
        internal static bool CapCommandsCount = true;

        /// <summary>The backing field for <see cref="MaximumCommands"/>.</summary>
        private static int _maximumCommands = 3;

        /// <summary>
        /// If <see cref="CapCommandsCount"/> is <c>true</c>, no more than this number of <see cref="Command"/>s will ever be stored.
        /// Cannot be less than 1.
        /// </summary>
        internal static int MaximumCommands
        {
            get => _maximumCommands;
            set
            {
                if (value > 0)
                {
                    _maximumCommands = value;
                }
                if (CapCommandsCount && Commands.Count > MaximumCommands)
                {
                    Commands = Commands.GetRange(CurrentCommandIndex - _maximumCommands, _maximumCommands);
                }
            }
        }

        /// <summary>How many levels of undo are currently stored.</summary>
        internal static int Count => Commands.Count;

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
            CurrentCommandIndex++;
            if (CurrentCommandIndex < Commands.Count && CurrentCommandIndex > 0)
            {
                // If the new comman supercedes any stored commands, dispose of them.
                Commands = Commands.GetRange(0, CurrentCommandIndex);
            }
            Commands.Add(inCommand);
            Commands[CurrentCommandIndex].Execute();
            if (CapCommandsCount && Commands.Count > MaximumCommands)
            {
                // Trim Excess Old Commands
                Commands = Commands.GetRange(Commands.Count - MaximumCommands, MaximumCommands);
                CurrentCommandIndex = Commands.Count - 1;
            }
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
        }
    }
}
