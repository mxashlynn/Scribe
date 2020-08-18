using System;
using System.Windows.Forms;

namespace Scribe
{
    /// <summary>
    /// A GUI application used to edit game definitions consumed by the Parquet Class Library.
    /// </summary>
    static class ScribeProgram
    {
        /// <summary>
        /// Entry point to a GUI application used to edit game definitions consumed by the Parquet Class Library.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainEditorForm());
            Application.Run(new CommandHistory.UndoTestForm());
        }
    }
}
