using System.Windows.Forms;

namespace ParquetCustomControls
{
    /// <summary>
    /// A control that can display other controls in a grid rapidly and without flickering.
    /// </summary>
    public partial class DoubleBufferedPanel : TableLayoutPanel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleBufferedPanel"/> class.
        /// </summary>
        public DoubleBufferedPanel()
            => InitializeComponent();
    }
}
