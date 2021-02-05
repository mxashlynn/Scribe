using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Scribe.CustomControls
{
    /// <summary>
    /// Represents a Windows picture box for displaying multiple layered pixel art images.
    /// </summary>
    public partial class LayeredPixelBox : PixelBox
    {
        #region Class Defaults
        /// <summary>How many pixels wide the source image is.</summary>
        public const int SourceDimensionInPixels = 10;

        /// <summary>How many pixels to scale the source image by to reach the target display resolution.</summary>
        public const int TargetResolutionScalingFactor = 4;

        /// <summary>How many pixels wide the target image is.</summary>
        private const int TargetDimensionInPixels = SourceDimensionInPixels * TargetResolutionScalingFactor;
        #endregion

        #region Characteristics
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new <see cref="LayeredPixelBox"/>.
        /// </summary>
        public LayeredPixelBox()
        {
            InitializeComponent();

            // Enforce target size.
            if (Width != TargetDimensionInPixels
               || Height != TargetDimensionInPixels)
            {
                Size = new Size(TargetDimensionInPixels, TargetDimensionInPixels);
            }
        }
        #endregion

        #region Displaying Graphics
        /// <summary>
        /// Paints multiple images without anti-aliasing or other distortion.
        /// </summary>
        /// <param name="paintArguments">Configuration used by the painting routine.</param>
        protected override void OnPaint(PaintEventArgs paintArguments)
        {
            paintArguments.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            paintArguments.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            paintArguments.Graphics.SmoothingMode = SmoothingMode.None;
            paintArguments.Graphics.CompositingQuality = CompositingQuality.HighQuality;

            // Paint the images, scaled, using the painter's algorithm.
            paintArguments.Graphics.DrawImage(Image, 0, 0, TargetDimensionInPixels, TargetDimensionInPixels);
        }
        #endregion
    }
}
