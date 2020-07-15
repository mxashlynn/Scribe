using System;
using System.Windows.Forms;

namespace Scribe
{
    /// <summary>
    /// The primary editing interface.
    /// </summary>
    public partial class EditorForm : Form
    {
        /// <summary>Reference to the dialogue displaying information about the application.</summary>
        private AboutBox AboutWindow;

        /// <summary>
        /// Constructs a new instance of the main editor UI.
        /// </summary>
        public EditorForm()
        {
            InitializeComponent();

            /*  TODO These might not be needed.  Add these if the fonts are wonky.
            EditorStatusStrip.Font = SystemFonts.StatusFont;
            MainMenuBar.Font = SystemFonts.MenuFont;
            Font = SystemFonts.DialogFont;
             */
        }

        /// <summary>
        /// Responds to a user selecting the "About" menu item.
        /// </summary>
        /// <param name="sender">Originator of the event.</param>
        /// <param name="e">Addional event data.</param>
        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            AboutWindow ??= new AboutBox();
            AboutWindow.ShowDialog();
        }
    }
}
