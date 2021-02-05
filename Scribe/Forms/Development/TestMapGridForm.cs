using System;
using System.Drawing;
using System.Windows.Forms;

namespace Scribe.Forms.Development
{
    partial class TestMapGridForm : Form
    {
        /// <summary>The resolution at which the final map will be rendered.</summary>
        public static readonly Size TargetResolution = new Size(1280, 720);

        /// <summary>
        /// Initializes a new instance of <see cref="TestMapGridForm"/>.
        /// </summary>
        public TestMapGridForm()
            => InitializeComponent();

        /// <summary>
        /// Sets up the map.
        /// </summary>
        /// <param name="EventData">Handled by parent.</param>
        protected override void OnLoad(EventArgs EventData)
        {
            base.OnLoad(EventData);

            // TODO Map stuff goes here!
        }
    }
}
