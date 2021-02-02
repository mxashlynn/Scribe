using System.Collections.Generic;
using Parquet;

namespace Scribe.ChangeHistory
{
    /// <summary>
    /// Tracks requests to make changes and stores them as <see cref="Change"/> objects to enable Undo and Redo functionality.
    /// </summary>
    internal static class ChangeManager
    {
        /// <summary>A history of actions taken.</summary>
        private static List<Change> Changes = new List<Change>();

        /// <summary>The index of the <see cref="Change"/> that will be Undone next.</summary>
        private static int CurrentChangeIndex = -1;

        /// <summary>The backing field for <see cref="MaximumChanges"/>.</summary>
        private static int _maximumChanges = 100;

        /// <summary>
        /// How many levels of undo to maintain.
        /// No more than this number of <see cref="Change"/>s will ever be stored.  Cannot be less than 1.
        /// </summary>
        internal static int MaximumChanges
        {
            get => _maximumChanges;
            set
            {
                if (value > 0)
                {
                    _maximumChanges = value;
                }
                if (Changes.Count > MaximumChanges)
                {
                    Changes = Changes.GetRange(Changes.Count - MaximumChanges, MaximumChanges);
                    CurrentChangeIndex = Changes.Count - 1;
                }
            }
        }

        /// <summary>How many levels of undo are currently stored.</summary>
        internal static int Count => Changes.Count;

        /// <summary>
        /// Empties the <see cref="Change"/> history and resets the manager.
        /// </summary>
        internal static void Clear()
        {
            // TODO: Ideally this log dependency would be injected.
            Logger.Log(LogLevel.Info, $"{nameof(Clear)} {nameof(ChangeHistory)}");
            Changes.Clear();
            CurrentChangeIndex = -1;
        }

        /// <summary>
        /// Add a new <see cref="Change"/> to the history and immediately take action on it.
        /// </summary>
        /// <param name="inChange">The change to add and act on.</param>
        internal static void AddAndExecute(Change inChange)
        {
            // TODO: Ideally this log dependency would be injected.
            Logger.Log(LogLevel.Info, $"{nameof(Change.Execute)} {inChange.Description}");

            CurrentChangeIndex++;
            if (0 < Count && CurrentChangeIndex < Count)
            {
                // If the new change supersedes any stored changes, dispose of them.
                Changes = Changes.GetRange(0, CurrentChangeIndex);
            }
            Changes.Add(inChange);
            Changes[CurrentChangeIndex].Execute();
            if (Count > MaximumChanges)
            {
                // Trim excess old changes.
                Changes = Changes.GetRange(Count - MaximumChanges, MaximumChanges);
                CurrentChangeIndex = Count - 1;
            }
        }

        /// <summary>
        /// Undo the last action done, if any.
        /// </summary>
        internal static void Undo()
        {
            if (CurrentChangeIndex > -1)
            {
                // TODO: Ideally this log dependency would be injected.
                Logger.Log(LogLevel.Info, $"{nameof(Undo)} {Changes[CurrentChangeIndex].Description}");
                Changes[CurrentChangeIndex].Reverse();
                CurrentChangeIndex--;
            }
        }

        /// <summary>
        /// Redo the action most recently undone, if any.
        /// </summary>
        internal static void Redo()
        {
            if (CurrentChangeIndex < Count - 1)
            {
                CurrentChangeIndex++;
                // TODO: Ideally this log dependency would be injected.
                Logger.Log(LogLevel.Info, $"{nameof(Redo)} {Changes[CurrentChangeIndex].Description}");
                Changes[CurrentChangeIndex].Execute();
            }
        }
    }
}
