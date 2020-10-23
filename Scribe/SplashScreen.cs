using System;
using System.IO;
using System.Media;
using System.Windows.Forms;
using ParquetClassLibrary;
using Scribe.Properties;

namespace Scribe
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
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void LinkLabelMostRecent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs eventArguments)
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
                    _ = MessageBox.Show(Resources.ErrorLoadFailed, Resources.CaptionError,
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Attempts to load the most recently-edited project.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void ButtonNewProject_Click(object sender, EventArgs eventArguments)
        {
            if (!EditorCommands.SelectProjectFolder(Resources.InfoMessageNew))
            {
                return;
            }

            if (EditorCommands.CreateTemplatesInProjectFolder()
                && EditorCommands.LoadDataFiles())
            {
                ScribeProgram.ShowEditor();
                Close();
            }
            else
            {
                SystemSounds.Beep.Play();
                _ = MessageBox.Show(Resources.ErrorNewFailed, Resources.CaptionError,
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Attempts to load the most recently-edited project.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void ButtonLoadProject_Click(object sender, EventArgs eventArguments)
        {
            if (!EditorCommands.SelectProjectFolder(Resources.InfoMessageLoad))
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
                _ = MessageBox.Show(Resources.ErrorLoadFailed, Resources.CaptionError,
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Attempts to load the most recently-edited project.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void ButtonExitScribe_Click(object sender, EventArgs eventArguments)
            => Close();
    }
}
