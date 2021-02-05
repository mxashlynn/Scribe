using System;
using System.Diagnostics;
using System.Windows.Forms;
using Scribe.Forms;

namespace Scribe
{
    /// <summary>
    /// A GUI application used to edit game definitions consumed by the Parquet Class Library.
    /// </summary>
    static class ScribeProgram
    {
        #region Characteristics
        /// <summary>Used to handle switching between <see cref="SplashScreen"/> and <see cref="MainEditorForm"/>.</summary>
        private static readonly ApplicationContext Context;

        /// <summary><c>true</c> if Scribe was compiled with the DEBUG symbol defined; <c>false</c> otherwise.</summary>
        public static readonly bool IsDebugMode;
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes the program.
        /// </summary>
        static ScribeProgram()
        {
            Context = new ApplicationContext();
            GetDebugMode(ref IsDebugMode);
        }

        /// <summary>
        /// This routine only runs if the program was compiled in debug mode.
        /// </summary>
        /// <param name="refIsDebugMode">Set to <c>true</c>.</param>
        [Conditional("DEBUG")]
        private static void GetDebugMode(ref bool refIsDebugMode)
            => refIsDebugMode = true;
        #endregion

        /// <summary>
        /// Entry point to a GUI application used to edit game definitions consumed by the Parquet Class Library.
        /// </summary>
        [STAThread]
        static void Main()
        {
            _ = Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // TODO Context.MainForm = new SplashScreen();
            Context.MainForm = new Forms.Development.TestMapGridForm();
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
