using System.Drawing;
using System.Windows.Forms;

namespace Scribe.Forms.Development
{
    partial class TestMapGridForm : Form
    {
        /// <summary>The resolution at which the final map will be rendered.</summary>
        public static readonly Size TargetResolution = new Size(1280, 720);

        public TestMapGridForm()
        {
            InitializeComponent();

            //ClientSize = TargetResolution;
        }
    }
}
