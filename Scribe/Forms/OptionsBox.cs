using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Media;
using System.Windows.Forms;
using Parquet;
using Scribe.Properties;

namespace Scribe.Forms
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

        /// <summary>The <see cref="EditorTheme"/> that was set when the form was shown.</summary>
        private EditorTheme OldTheme;

        /// <summary>User-set autosave interval.</summary>
        private int NewAutoSaveInterval;

        /// <summary>The UI elements used to represent the current <see cref="EditorTheme"/>.</summary>
        private readonly Dictionary<string, RadioButton> ThemeRadioButtons;

        /// <summary>The UI elements used to represent the current <see cref="DefaultDirectory"/>.</summary>
        private readonly Dictionary<string, RadioButton> DirectoryRadioButtons;
                
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
            DirectoryRadioButtons = new Dictionary<string, RadioButton>
            {
                { DefaultDirectory.Desktop.ToString(), RadioButtonDefaultToDesktop },
                { DefaultDirectory.Documents.ToString(), RadioButtonDefaultToDocuments },
                { DefaultDirectory.Working.ToString(), RadioButtonDefaultToWorking },
            };
        }

        /// <summary>
        /// Sets up the <see cref="OptionsBox"/> UI.
        /// </summary>
        /// <param name="EventData">Handled by parent.</param>
        protected override void OnLoad(EventArgs EventData)
        {
            base.OnLoad(EventData);

            if (!Enum.TryParse(Settings.Default.CurrentEditorTheme, out OldTheme))
            {
                OldTheme = EditorTheme.OSDefault;
                SystemSounds.Beep.Play();
                Logger.Log(LogLevel.Error, string.Format(CultureInfo.InvariantCulture, Resources.ErrorParseFailed,
                                                         nameof(Settings.Default.CurrentEditorTheme)));
            }
            foreach (var radioButton in ThemeRadioButtons.Values)
            {
                radioButton.Checked = false;
            }
            ThemeRadioButtons[Settings.Default.CurrentEditorTheme].Checked = true;

            foreach (var radioButton in DirectoryRadioButtons.Values)
            {
                radioButton.Checked = false;
            }
            DirectoryRadioButtons[Settings.Default.DefaultDirectory].Checked = true;

            CheckBoxFlavorFilters.Checked = Settings.Default.UseFlavorFilters;
            CheckBoxSuggestStoryIDs.Checked = Settings.Default.SuggestStoryIDs;
            NewAutoSaveInterval = Settings.Default.AutoSaveInterval;
            TextBoxAutoSaveInterval.Text = NewAutoSaveInterval.ToString(CultureInfo.InvariantCulture);
            RadioButtonEditInCustomApp.Checked = Settings.Default.EditInApp;
            RadioButtonEditInOSDefault.Checked = !Settings.Default.EditInApp;
            TextBoxImageEditorPath.Text = Settings.Default.ImageEditor;

            ApplyCurrentTheme();
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
                TextBoxAutoSaveInterval.Text = NewAutoSaveInterval.ToString(CultureInfo.InvariantCulture);
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
        /// <param name="eventAruments">Whether or not to discard the given text.</param>
        private void TextBoxImageEditorPath_Validating(object sender, System.ComponentModel.CancelEventArgs eventAruments)
        {
            TextBoxImageEditorPath.Text = Path.GetFullPath(TextBoxImageEditorPath.Text);
            if (File.Exists(TextBoxImageEditorPath.Text))
            {
                ErrorProvider.SetError(TextBoxAutoSaveInterval, "");
            }
            else
            {
                eventAruments.Cancel = true;
                TextBoxImageEditorPath.Select();
                ErrorProvider.SetError(LabelImageEditorPath, Resources.ErrorImageEditorNotFound);
            }
        }
        #endregion

        #region Color Theming
        /// <summary>
        /// Updates <see cref="CurrentTheme"/> setting to <see cref="EditorTheme.Femme"/>.
        /// </summary>
        /// <param name="sender">Determines if the theme is being set or unset.</param>
        /// <param name="eventAruments">Ignored.</param>
        private void RadioButtonFemmeTheme_CheckedChanged(object sender, EventArgs eventAruments)
        {
            if (sender is RadioButton radioButton
                && radioButton.Checked)
            {
                CurrentTheme.SetUpTheme(EditorTheme.Femme);
                ApplyCurrentTheme();
            }
        }

        /// <summary>
        /// Updates <see cref="CurrentTheme"/> setting to <see cref="EditorTheme.Colorful"/>.
        /// </summary>
        /// <param name="sender">Determines if the theme is being set or unset.</param>
        /// <param name="eventAruments">Ignored.</param>
        private void RadioButtonColorfulTheme_CheckedChanged(object sender, EventArgs eventAruments)
        {
            if (sender is RadioButton radioButton
                && radioButton.Checked)
            {
                CurrentTheme.SetUpTheme(EditorTheme.Colorful);
                ApplyCurrentTheme();
            }
        }

        /// <summary>
        /// Updates <see cref="CurrentTheme"/> setting to <see cref="EditorTheme.OSDefault"/>.
        /// </summary>
        /// <param name="sender">Determines if the theme is being set or unset.</param>
        /// <param name="eventAruments">Ignored.</param>
        private void RadioButtonOSDefaultTheme_CheckedChanged(object sender, EventArgs eventAruments)
        {
            if (sender is RadioButton radioButton
                && radioButton.Checked)
            {
                CurrentTheme.SetUpTheme(EditorTheme.OSDefault);
                ApplyCurrentTheme();
            }
        }

        /// <summary>
        /// Applies the <see cref="CurrentTheme"/> to the <see cref="OptionsBox"/> and its <see cref="Control"/>s.
        /// </summary>
        private void ApplyCurrentTheme()
        {
            BackColor = CurrentTheme.ControlBackgroundColor;
            ForeColor = CurrentTheme.ControlForegroundColor;

            PanelEditorTheme.BackColor = CurrentTheme.ControlBackgroundColor;
            PanelEditorTheme.ForeColor = CurrentTheme.ControlForegroundColor;
            PanelDefaultFolder.BackColor = CurrentTheme.ControlBackgroundColor;
            PanelDefaultFolder.ForeColor = CurrentTheme.ControlForegroundColor;
            PanelEditImagesIn.BackColor = CurrentTheme.ControlBackgroundColor;
            PanelEditImagesIn.ForeColor = CurrentTheme.ControlForegroundColor;

            TextBoxAutoSaveInterval.BackColor = CurrentTheme.ControlBackgroundWhite;
            TextBoxAutoSaveInterval.ForeColor = CurrentTheme.ControlForegroundColor;
            TextBoxImageEditorPath.BackColor = CurrentTheme.ControlBackgroundWhite;
            TextBoxImageEditorPath.ForeColor = CurrentTheme.ControlForegroundColor;

            LabelTheme.BackColor = CurrentTheme.ControlBackgroundColor;
            LabelTheme.ForeColor = CurrentTheme.ControlForegroundColor;
            LabelSuggestStoryIDs.BackColor = CurrentTheme.ControlBackgroundColor;
            LabelSuggestStoryIDs.ForeColor = CurrentTheme.ControlForegroundColor;
            LabelAutoSaveInterval.BackColor = CurrentTheme.ControlBackgroundColor;
            LabelAutoSaveInterval.ForeColor = CurrentTheme.ControlForegroundColor;
            LabelAutoSaveExplanation.BackColor = CurrentTheme.ControlBackgroundColor;
            LabelAutoSaveExplanation.ForeColor = CurrentTheme.ControlForegroundColor;
            LabelDefaultFolder.BackColor = CurrentTheme.ControlBackgroundColor;
            LabelDefaultFolder.ForeColor = CurrentTheme.ControlForegroundColor;
            LabelFlavorFilter.BackColor = CurrentTheme.ControlBackgroundColor;
            LabelFlavorFilter.ForeColor = CurrentTheme.ControlForegroundColor;
            LabelEditImagesIn.BackColor = CurrentTheme.ControlBackgroundColor;
            LabelEditImagesIn.ForeColor = CurrentTheme.ControlForegroundColor;
            LabelImageEditorPath.BackColor = CurrentTheme.ControlBackgroundColor;
            LabelImageEditorPath.ForeColor = CurrentTheme.ControlForegroundColor;

            OkayButton.BackColor = CurrentTheme.ControlBackgroundColor;
            OkayButton.FlatAppearance.BorderColor = CurrentTheme.BorderColor;
            OkayButton.FlatAppearance.MouseDownBackColor = CurrentTheme.MouseDownColor;
            OkayButton.FlatAppearance.MouseOverBackColor = CurrentTheme.MouseOverColor;
            CancelButtonControl.BackColor = CurrentTheme.ControlBackgroundColor;
            CancelButtonControl.FlatAppearance.BorderColor = CurrentTheme.BorderColor;
            CancelButtonControl.FlatAppearance.MouseDownBackColor = CurrentTheme.MouseDownColor;
            CancelButtonControl.FlatAppearance.MouseOverBackColor = CurrentTheme.MouseOverColor;
        }
        #endregion

        #region Closing the Form
        /// <summary>
        /// Responds to the Okay Button to ensure that settings are saved.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void OkayButton_Click(object sender, EventArgs eventArguments)
        {
            Settings.Default.CurrentEditorTheme = RadioButtonFemmeTheme.Checked
                ? EditorTheme.Femme.ToString()
                : RadioButtonColorfulTheme.Checked
                    ? EditorTheme.Colorful.ToString()
                    : EditorTheme.OSDefault.ToString();
            Settings.Default.DefaultDirectory = RadioButtonDefaultToDesktop.Checked
                ? DefaultDirectory.Desktop.ToString()
                : RadioButtonDefaultToDocuments.Checked
                    ? DefaultDirectory.Documents.ToString()
                    : DefaultDirectory.Working.ToString();
            Settings.Default.UseFlavorFilters = CheckBoxFlavorFilters.Checked;
            Settings.Default.SuggestStoryIDs = CheckBoxSuggestStoryIDs.Checked;
            Settings.Default.AutoSaveInterval = NewAutoSaveInterval;
            Settings.Default.EditInApp = RadioButtonEditInCustomApp.Checked;
            Settings.Default.ImageEditor = TextBoxImageEditorPath.Text;
            Settings.Default.Save();

            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Restores old settings on cancel.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="eventArguments">Ignored.</param>
        private void CancelButtonControl_Click(object sender, EventArgs eventArguments)
        {
            CurrentTheme.SetUpTheme(OldTheme);
            Settings.Default.Reload();
            DialogResult = DialogResult.Cancel;
        }
        #endregion
    }
}
