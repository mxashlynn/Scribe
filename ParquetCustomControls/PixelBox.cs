using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ParquetCustomControls
{
    /// <summary>
    /// Represents a Windows picture box for displaying pixel art images.
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
        /// <param name="inPaintArguments">Configuration used by the painting routine.</param>
        protected override void OnPaint(PaintEventArgs inPaintArguments)
        {
            if (inPaintArguments is null)
            {
                throw new ArgumentException("PaintEventArguments cannot be null");
            }

            inPaintArguments.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            inPaintArguments.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            inPaintArguments.Graphics.SmoothingMode = SmoothingMode.None;
            inPaintArguments.Graphics.CompositingQuality = CompositingQuality.HighQuality;

            base.OnPaint(inPaintArguments);
        }
    }
}
