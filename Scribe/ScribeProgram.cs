using System;
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
        private static readonly ApplicationContext Context = new();

        /// <summary><c>true</c> if Scribe was compiled with the DEBUG symbol defined; <c>false</c> otherwise.</summary>
        internal static bool IsDebugMode
#if DEBUG
            => true;
#else
            => false;
#endif

        /// <summary>Used to track which editor most recently updated <see cref="Parquet.All"/>.</summary>
        // NOTE I feel like there has to be a better, more automatic way to track this, but
        // I have yet found one that fits all constraints.
        internal static Form MostRecentUpdateSource;
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
