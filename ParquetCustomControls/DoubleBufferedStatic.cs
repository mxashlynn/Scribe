using System.Windows.Forms;

namespace ParquetCustomControls
{
    /// <summary>
    /// A control that can display text and color rapidly and without flickering.
    /// </summary>
    public partial class DoubleBufferedStatic : Label
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleBufferedStatic"/> class.
        /// </summary>
        public DoubleBufferedStatic()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }
    }
}
