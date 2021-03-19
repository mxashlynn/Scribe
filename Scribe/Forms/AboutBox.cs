using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Scribe.Properties;

namespace Scribe.Forms
{
    /// <summary>
    /// A modal dialogue that presents descriptive information about the application and library.
    /// </summary>
    internal partial class AboutBox : Form
    {
        #region Initialization
        /// <summary>
        /// A modal dialogue that present descriptive information about the application and library.
        /// </summary>
        public AboutBox()
        {
            InitializeComponent();

            Text = $"{Resources.CaptionAbout} {AssemblyTitle}";
            LabelProductName.Text = AssemblyProduct;
            LabelVersion.Text = $"{Resources.CaptionVersion} {AssemblyInfo.ScribeVersion}";
            LabelCopyright.Text = AssemblyCopyright;
            LabelCompanyName.Text = AssemblyCompany;
            LabelFrameworkVersions.Text = $"{nameof(Parquet)}: {Parquet.AssemblyInfo.LibraryVersion}  {Environment.NewLine}{nameof(CsvHelper)}: {Assembly.GetAssembly(typeof(CsvHelper.CsvParser)).GetName().Version}  {Environment.NewLine}{RuntimeInformation.FrameworkDescription}";
            TextBoxDescription.Text = $"{AssemblyDescription}{Environment.NewLine}  {Environment.NewLine}{Resources.AboutDetails}{Environment.NewLine}  {Environment.NewLine}{Resources.AboutLinkPreamble} {Resources.RepositoryURL}";
        }

        /// <summary>
        /// Resets the UI each time the dialogue box is loaded.
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventArguments">Additional event data.</param>
        private void AboutBox_Load(object inSender, EventArgs inEventArguments)
            => ApplyCurrentTheme();
        #endregion

        #region Color Theming
        /// <summary>
        /// Applies the <see cref="CurrentTheme"/> to the <see cref="AboutBox"/> and its <see cref="Control"/>s.
        /// </summary>
        private void ApplyCurrentTheme()
        {
            BackColor = CurrentTheme.ControlBackgroundColor;
            ForeColor = CurrentTheme.ControlForegroundColor;
            TextBoxDescription.BackColor = CurrentTheme.ControlBackgroundWhite;
            TextBoxDescription.ForeColor = CurrentTheme.ControlForegroundColor;
            LabelProductName.BackColor = CurrentTheme.ControlBackgroundColor;
            LabelProductName.ForeColor = CurrentTheme.ControlForegroundColor;
            LabelVersion.BackColor = CurrentTheme.ControlBackgroundColor;
            LabelVersion.ForeColor = CurrentTheme.ControlForegroundColor;
            LabelCopyright.BackColor = CurrentTheme.ControlBackgroundColor;
            LabelCopyright.ForeColor = CurrentTheme.ControlForegroundColor;
            LabelCompanyName.BackColor = CurrentTheme.ControlBackgroundColor;
            LabelCompanyName.ForeColor = CurrentTheme.ControlForegroundColor;
            LabelFrameworkVersions.BackColor = CurrentTheme.ControlBackgroundColor;
            LabelFrameworkVersions.ForeColor = CurrentTheme.ControlForegroundColor;
            OkayButton.BackColor = CurrentTheme.ControlBackgroundColor;
            OkayButton.FlatAppearance.BorderColor = CurrentTheme.BorderColor;
            OkayButton.FlatAppearance.MouseDownBackColor = CurrentTheme.MouseDownColor;
            OkayButton.FlatAppearance.MouseOverBackColor = CurrentTheme.MouseOverColor;
        }
        #endregion

        #region Assembly Attribute Accessors
        /// <summary>
        /// The name of the assembly.
        /// </summary>
        public static string AssemblyTitle
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    var titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (!string.IsNullOrEmpty(titleAttribute.Title))
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location);
            }
        }

        /// <summary>
        /// What the purpose of the assembly.
        /// </summary>
        public static string AssemblyDescription
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                return attributes.Length == 0
                    ? ""
                    : ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        /// <summary>
        /// The name of the product.
        /// </summary>
        public static string AssemblyProduct
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                return attributes.Length == 0
                    ? ""
                    : ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        /// <summary>
        /// Copyright information.
        /// </summary>
        public static string AssemblyCopyright
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                return attributes.Length == 0
                    ? ""
                    : ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        /// <summary>
        /// The name of the group that created the product.
        /// </summary>
        public static string AssemblyCompany
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                return attributes.Length == 0
                    ? ""
                    : ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        #region Closing the Form
        /// <summary>
        /// Closes the <see cref="AboutBox"/>.
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventArguments">Additional event data.</param>
        private void OKButton_Click(object inSender, EventArgs inEventArguments)
            => Close();
        #endregion
    }
}
