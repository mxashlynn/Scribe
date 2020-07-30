using System;
using System.Reflection;
using System.Windows.Forms;
using Scribe.Properties;

namespace Scribe
{
    partial class AboutBox : Form
    {
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
            TextBoxDescription.Text = $"{AssemblyDescription}{Environment.NewLine}  {Environment.NewLine}{Resources.AboutDetails}{Environment.NewLine}  {Environment.NewLine}{Resources.AboutLinkPreamble} {Resources.RepositoryURL}";
        }

        #region Assembly Attribute Accessors
        /// <summary>
        /// The name of the assembly.
        /// </summary>
        public string AssemblyTitle
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    var titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        /// <summary>
        /// What the purpose of the assembly.
        /// </summary>
        public string AssemblyDescription
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
        public string AssemblyProduct
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
        public string AssemblyCopyright
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
        public string AssemblyCompany
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

        /// <summary>
        /// Closes the <see cref="AboutBox"/>.
        /// </summary>
        /// <param name="sender">The originator of the event.</param>
        /// <param name="e">Additional event data.</param>
        private void OKButton_Click(object sender, EventArgs e)
            => Close();
    }
}
