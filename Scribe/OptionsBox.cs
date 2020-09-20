using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Scribe.Properties;

namespace Scribe
{
    /// <summary>
    /// A modal dialogue that enables the user to adjust application behavior.
    /// </summary>
    internal partial class OptionsBox : Form
    {
        /// <summary>The shortest interval allowed for AutoSaveInterval.</summary>
        private const int MinimumInterval = 0;

        /// <summary>The largest interval allowed for AutoSaveInterval.</summary>
        private const int MaximumInterval = 60;

        /// <summary>User-set autosave interval.  Guaranteed to be valid when <see cref="OptionsBox.FormClosingEventHandler"/> runs.</summary>
        private int NewAutoSaveInterval;

        /// <summary>The UI elements used to represent the current <see cref="EditorTheme"/>.</summary>
        private readonly Dictionary<string, RadioButton> ThemeRadioButtons;

        #region Initialization
        /// <summary>
        /// Initialize a new <see cref="OptionsBox"/>.
        /// </summary>
        public OptionsBox()
        {
            InitializeComponent();
            ThemeRadioButtons = new Dictionary<string, RadioButton>
            {
                { EditorTheme.Femme.ToString(), RadioButtonFemmeTheme },
                { EditorTheme.Colorful.ToString(), RadioButtonColorfulTheme },
                { EditorTheme.OSDefault.ToString(), RadioButtonOSDefaultTheme },
            };
        }

        /// <summary>
        /// Sets up the <see cref="OptionsBox"/> UI.
        /// </summary>
        /// <param name="EventData">Handled by parent.</param>
        protected override void OnLoad(EventArgs EventData)
        {
            base.OnLoad(EventData);

            ThemeRadioButtons.Values.Select(radioButton => radioButton.Checked = false);
            ThemeRadioButtons[Settings.Default.CurrentEditorTheme].Checked = true;

            CheckBoxFlavorFilters.Checked = Settings.Default.UseFlavorFilters;
            CheckBoxSuggestStoryIDs.Checked = Settings.Default.SuggestStoryIDs;
            NewAutoSaveInterval = Settings.Default.AutoSaveInterval;
            TextBoxAutoSaveInterval.Text = NewAutoSaveInterval.ToString();
            RadioButtonDefaultToDesktop.Checked = Settings.Default.DesktopIsDefaultDirectory;
            RadioButtonDefaultToDocuments.Checked = !Settings.Default.DesktopIsDefaultDirectory;
            RadioButtonEditInCustomApp.Checked = Settings.Default.EditInApp;
            RadioButtonEditInOSDefault.Checked = !Settings.Default.EditInApp;
            TextBoxImageEditorPath.Text = Settings.Default.ImageEditor;
        }
        #endregion

        #region Input Validation
        /// <summary>
        /// Determines if the value entered is valid.
        /// Stores valid values for later updating the settings, otherwise signals an input error.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Whether or not to discard the text.</param>
        private void TextBoxAutoSaveInterval_Validating(object sender, System.ComponentModel.CancelEventArgs eventArguments)
        {
            if (int.TryParse(TextBoxAutoSaveInterval.Text, out var newInterval))
            {
                NewAutoSaveInterval = Math.Clamp(newInterval, MinimumInterval, MaximumInterval);
                TextBoxAutoSaveInterval.Text = NewAutoSaveInterval.ToString();
                ErrorProvider.SetError(TextBoxAutoSaveInterval, "");
            }
            else
            {
                eventArguments.Cancel = true;
                TextBoxAutoSaveInterval.Select();
                ErrorProvider.SetError(TextBoxAutoSaveInterval, Resources.ErrorIntegersOnly);
            }
        }

        /// <summary>
        /// Determines if the value entered is valid.
        /// Stores valid values for later updating the settings, otherwise signals an input error.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Whether or not to discard the given text.</param>
        private void TextBoxImageEditorPath_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBoxImageEditorPath.Text = Path.GetFullPath(TextBoxImageEditorPath.Text);
            if (File.Exists(TextBoxImageEditorPath.Text))
            {
                ErrorProvider.SetError(TextBoxAutoSaveInterval, "");
            }
            else
            {
                e.Cancel = true;
                TextBoxImageEditorPath.Select();
                ErrorProvider.SetError(LabelImageEditorPath, Resources.ErrorImageEditorNotFound);
            }
        }
        #endregion

        /// <summary>
        /// Responds to the Okay Button to ensure that settings are saved.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void OkayButton_Click(object sender, EventArgs e)
        {
            Settings.Default.CurrentEditorTheme = RadioButtonFemmeTheme.Checked
                ? EditorTheme.Femme.ToString()
                : RadioButtonColorfulTheme.Checked
                    ? EditorTheme.Colorful.ToString()
                    : EditorTheme.OSDefault.ToString();
            Settings.Default.UseFlavorFilters = CheckBoxFlavorFilters.Checked;
            Settings.Default.SuggestStoryIDs = CheckBoxSuggestStoryIDs.Checked;
            Settings.Default.AutoSaveInterval = NewAutoSaveInterval;
            Settings.Default.DesktopIsDefaultDirectory = RadioButtonDefaultToDesktop.Checked;
            Settings.Default.EditInApp = RadioButtonEditInCustomApp.Checked;
            Settings.Default.ImageEditor = TextBoxImageEditorPath.Text;
            Settings.Default.Save();

            DialogResult = DialogResult.OK;
        }

    }
}
