using System;
using System.IO;
using System.Media;
using System.Windows.Forms;
using Parquet;
using Scribe.Properties;

namespace Scribe.Forms
{
    /// <summary>
    /// The first form to load.
    /// </summary>
    public partial class SplashScreen : Form
    {
        /// <summary>
        /// Initializes the first form to load.
        /// </summary>
        public SplashScreen()
        {
            InitializeComponent();

            LinkLabelMostRecent.Text = string.IsNullOrEmpty(Settings.Default.MostRecentProject)
                ? Resources.WarngingNoRecentProject
                : new DirectoryInfo(Settings.Default.MostRecentProject).Name;
        }

        /// <summary>
        /// Attempts to load the most recently-edited project.
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventArguments">Additional event data.</param>
        private void LinkLabelMostRecent_LinkClicked(object inSender, LinkLabelLinkClickedEventArgs inEventArguments)
        {
            if (!string.IsNullOrEmpty(Settings.Default.MostRecentProject))
            {
                All.ProjectDirectory = Settings.Default.MostRecentProject;
                if (EditorCommands.LoadDataFiles())
                {
                    ScribeProgram.ShowEditor();
                    Close();
                }
                else
                {
                    SystemSounds.Beep.Play();
                    Logger.Log(LogLevel.Error, Resources.ErrorLoadFailed);
                }
            }
        }

        /// <summary>
        /// Attempts to create a new project.
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventArguments">Additional event data.</param>
        private void ButtonNewProject_Click(object inSender, EventArgs inEventArguments)
        {
            if (!EditorCommands.SelectProjectFolder(Resources.InfoMessageNew, Resources.FolderNameNewProject))
            {
                return;
            }

            if (TemplatesMessageBox.CreateTemplatesInProjectFolder()
                && EditorCommands.LoadDataFiles())
            {
                ScribeProgram.ShowEditor();
                Close();
            }
            else
            {
                SystemSounds.Beep.Play();
                Logger.Log(LogLevel.Error, Resources.ErrorNewFailed);
            }
        }

        /// <summary>
        /// Attempts to load a saved project.
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventArguments">Additional event data.</param>
        private void ButtonLoadProject_Click(object inSender, EventArgs inEventArguments)
        {
            if (!EditorCommands.SelectProjectFolder(Resources.InfoMessageLoad, Resources.FolderNameOldProject))
            {
                return;
            }

            if (EditorCommands.LoadDataFiles())
            {
                ScribeProgram.ShowEditor();
                Close();
            }
            else
            {
                SystemSounds.Beep.Play();
                Logger.Log(LogLevel.Error, Resources.ErrorLoadFailed);
            }
        }

        /// <summary>
        /// Attempts to load the most recently-edited project.
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventArguments">Additional event data.</param>
        private void ButtonExitScribe_Click(object inSender, EventArgs inEventArguments)
            => Close();
    }
}
