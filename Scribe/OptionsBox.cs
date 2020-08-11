using System;
using System.Windows.Forms;
using Scribe.Properties;

namespace Scribe
{
    /// <summary>
    /// A modal dialogue that enables the user to adjust application behavior.
    /// </summary>
    partial class OptionsBox : Form
    {
        /// <summary>The shortest interval allowed for AutoSaveInterval.</summary>
        private const int MinimumInterval = 0;

        /// <summary>The largest interval allowed for AutoSaveInterval.</summary>
        private const int MaximumInterval = 60;

        /// <summary>User-set autosave interval.  Guaranteed to be valid when <see cref="OptionsBox.FormClosingEventHandler"/> runs.</summary>
        private int NewAutoSaveInterval;

        #region Initialization
        /// <summary>
        /// Initialize a new <see cref="OptionsBox"/>.
        /// </summary>
        public OptionsBox()
        {
            InitializeComponent();

            #region Default Event Handlers
            FormClosing += new FormClosingEventHandler((object sender, FormClosingEventArgs e) =>
            {
                Settings.Default.UseColorfulEditorTheme = RadioButtonColorfulTheme.Checked;
                Settings.Default.UseFlavorFilters = CheckBoxFlavorFilters.Checked;
                Settings.Default.SuggestStoryIDs = CheckBoxSuggestStoryIDs.Checked;
                Settings.Default.AutoSaveInterval = NewAutoSaveInterval;
                Settings.Default.DesktopIsDefaultDirectory = RadioButtonDefaultToDesktop.Checked;
                Settings.Default.Save();
            });
            #endregion
        }

        /// <summary>
        /// Sets up the <see cref="OptionsBox"/> UI.
        /// </summary>
        /// <param name="EventData">Handled by parent.</param>
        protected override void OnLoad(EventArgs EventData)
        {
            base.OnLoad(EventData);

            RadioButtonColorfulTheme.Checked = Settings.Default.UseColorfulEditorTheme;
            // TODO Is the line below needed?
            //RadioButtonOSTheme.Checked = !Settings.Default.UseColorfulEditorTheme;
            CheckBoxFlavorFilters.Checked = Settings.Default.UseFlavorFilters;
            CheckBoxSuggestStoryIDs.Checked = Settings.Default.SuggestStoryIDs;
            NewAutoSaveInterval = Settings.Default.AutoSaveInterval;
            TextBoxAutoSaveInterval.Text = NewAutoSaveInterval.ToString();
            RadioButtonDefaultToDesktop.Checked = Settings.Default.DesktopIsDefaultDirectory;
            // TODO Is the line below needed?
            //RadioButtonDefaultToDocuments.Checked = !Settings.Default.DesktopIsDefaultDirectory;
        }
        #endregion

        /// <summary>
        /// Determines if the value entered is valid.
        /// Stores valid values for later updating the settings, otherwise signals an input error.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Whether or not to discard the given text.</param>
        private void TextBoxAutoSaveInterval_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (int.TryParse(TextBoxAutoSaveInterval.Text, out var newInterval))
            {
                NewAutoSaveInterval = Math.Clamp(newInterval, MinimumInterval, MaximumInterval);
            }
            else
            {
                e.Cancel = true;
                TextBoxAutoSaveInterval.Select();
                ErrorProvider.SetError(TextBoxAutoSaveInterval, Properties.Resources.ErrorFolderNotEmpty);
            }
        }
    }
}
