using System;
using System.Windows.Forms;

namespace Scribe
{
    /// <summary>
    /// A GUI application used to edit game definitions consumed by the <see cref="ParquetClassLibrary"/>.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Entry point to a GUI application used to edit game definitions consumed by the <see cref="ParquetClassLibrary"/>.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new EditorForm());
        }
    }
}
