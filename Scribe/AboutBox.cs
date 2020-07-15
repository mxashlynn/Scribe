using System;
using System.Reflection;
using System.Windows.Forms;

namespace Scribe
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();

            Text = $"About {AssemblyTitle}";
            LabelProductName.Text = AssemblyProduct;
            LabelVersion.Text = $"Version {AssemblyInfo.ScribeVersion}";
            LabelCopyright.Text = AssemblyCopyright;
            LabelCompanyName.Text = $"Created by {AssemblyCompany}";
            TextBoxDescription.Text = $"{AssemblyDescription}{Environment.NewLine}  {Environment.NewLine}A game built with this system offers many of the features of contemporary quest-driven building games but in a simple, top-down world and without combat.{Environment.NewLine}  {Environment.NewLine}For more information visit: {AssemblyInfo.ScribeRepository}";
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
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
