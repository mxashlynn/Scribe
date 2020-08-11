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
                Settings.Default.AutoSaveInterval = int.Parse(TextBoxAutoSaveInterval.Text);
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
            TextBoxAutoSaveInterval.Text = Settings.Default.AutoSaveInterval.ToString();
            RadioButtonDefaultToDesktop.Checked = Settings.Default.DesktopIsDefaultDirectory;
            // TODO Is the line below needed?
            //RadioButtonDefaultToDocuments.Checked = !Settings.Default.DesktopIsDefaultDirectory;
        }
        #endregion
    }
}
