using System.IO;
using System.Media;
using System.Windows.Forms;
using Parquet;
using Scribe.Properties;

namespace Scribe
{
    /// <summary>
    /// Presents <see cref="MessageBox"/>es to the user when needed while creating new project files.
    /// </summary>
    internal static class TemplatesMessageBox
    {
        /// <summary>
        /// Attempts to create new, blank game data files and folders in the current folder.
        /// </summary>
        /// <returns><c>true</c> if the files were successfully created; otherwise, <c>false</c>.</returns>
        internal static bool CreateTemplatesInProjectFolder()
        {
            while (Directory.GetFiles(All.ProjectDirectory).Length > 0)
            {
                // Loop here to allow the user to empty the given directory if desired.
                SystemSounds.Beep.Play();
                if (MessageBox.Show(Resources.ErrorFolderNotEmpty,
                                    Resources.CaptionFolderNotEmptyError,
                                    MessageBoxButtons.RetryCancel,
                                    MessageBoxIcon.Error) == DialogResult.Cancel)
                {
                    // If they cancel, simply abort.
                    return false;
                }
            }
            EditorCommands.CreateGraphicalAssetFolders();
            EditorCommands.CreateTemplateFiles();
            return true;
        }
    }
}
