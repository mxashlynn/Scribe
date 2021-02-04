using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Scribe.CustomControls
{
    /// <summary>
    /// Represents a Windows picture box for displaying pixel art.
    /// </summary>
    public partial class PixelBox : PictureBox
    {
        /// <summary>
        /// Initializes a new <see cref="PixelBox"/>.
        /// </summary>
        public PixelBox()
            => InitializeComponent();

        /// <summary>
        /// Paints image without anti-aliasing or other distortion.
        /// </summary>
        /// <param name="paintArguments">Configuration used by the painting routine.</param>
        protected override void OnPaint(PaintEventArgs paintArguments)
        {
            paintArguments.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            paintArguments.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            paintArguments.Graphics.SmoothingMode = SmoothingMode.None;
            paintArguments.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            base.OnPaint(paintArguments);
        }
    }
}
