using System;
using System.IO;
using System.Windows.Forms;

namespace Scribe
{
    /// <summary>
    /// A GUI application used to edit game definitions consumed by the Parquet Class Library.
    /// </summary>
    static class ScribeProgram
    {
        /// <summary>Used to handle switching between <see cref="SplashScreen"/> and <see cref="MainEditorForm"/>.</summary>
        private static readonly ApplicationContext Context = new ApplicationContext();

        /// <summary>The location of Roller.  Defaults to the application's working directory.</summary>
        public static string RollerFolder { get; set; } =
#if DEBUG
                Path.GetFullPath($"{Directory.GetCurrentDirectory()}/../../../../Roller/bin/Debug/net5.0");
#else
                Path.GetFullPath(Directory.GetCurrentDirectory());
#endif

        /// <summary>
        /// Entry point to a GUI application used to edit game definitions consumed by the Parquet Class Library.
        /// </summary>
        [STAThread]
        static void Main()
        {
            _ = Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Context.MainForm = new SplashScreen();
            Application.Run(Context);
        }

        /// <summary>
        /// Load the <see cref="MainEditorForm"/>.
        /// </summary>
        public static void ShowEditor()
        {
            Context.MainForm = new MainEditorForm();
            Context.MainForm.Show();
        }
    }
}
