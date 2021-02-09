using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace Scribe.CustomControls
{
    /// <summary>
    /// Displays a grid of multi-layered images corresponding to a map of parquet packs.
    /// </summary>
    public partial class MapPictureGrid : UserControl
    {
        #region Class Defaults
        /// <summary>How many pixels per axis on each parquet source image.</summary>
        public const int SourceParquetDimensionInPixels = 10;

        /// <summary>How many pixels to scale the source image by to reach the target display resolution.</summary>
        public const int TargetResolutionScalingFactor = 4;

        /// <summary>How many pixels per axis on each parquet target render.</summary>
        public const int TargetParquetDimensionInPixels = SourceParquetDimensionInPixels * TargetResolutionScalingFactor;

        /// <summary>How many parquets wide per <see cref="MapPictureGrid"/>.</summary>
        public const int MapWidthInParquets = 32;

        /// <summary>How many parquets high per <see cref="MapPictureGrid"/>.</summary>
        public const int MapHeightInParquets = 18;

        /// <summary>The resolution at which the entire <see cref="MapPictureGrid"/> will be rendered.</summary>
        public static readonly Size TargetResolution =
            new Size(SourceParquetDimensionInPixels * TargetResolutionScalingFactor * MapWidthInParquets,
                     SourceParquetDimensionInPixels * TargetResolutionScalingFactor * MapHeightInParquets);

        /// <summary>How many parquets per each map space.</summary>
        /// <remarks>
        /// There are four parquets in each map space, from furthest to nearest:
        /// Floor, Block, Furnishing, and Collectible.
        /// Floor has index 0; Collectible has index 3, i.e. <see cref="ParquetLayerCount"/> - 1.
        /// </remarks>
        public const int ParquetLayerCount = 4;
        #endregion

        #region Characteristics
        /// <summary>The <see cref="IMapController"/> responsible for handling map-related events.</summary>
        private readonly IMapController Controller;

        /// <summary>All graphics needed to render this <see cref="MapPictureGrid"/>.</summary>
        public Dictionary<int, Bitmap> ImageByID { get; } = new Dictionary<int, Bitmap>();

        /// <summary>Each cell corresponds to a set of IDs representing each pack on the map.</summary>
        public int[,,] IDMap { get; } = new int[MapHeightInParquets, MapWidthInParquets, ParquetLayerCount];

        /// <summary>When <c>true</c>, no repainting is needed.</summary>
        private bool IsRendering = false;

        /// <summary>Indicates if a click event is currently in progress.</summary>
        private bool IsMidClick = false;

        /// <summary>Where the current click event began, or <see cref="Point.Empty"/> if no such event is in progress.</summary>
        private Point ClickStartLocation = Point.Empty;
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new <see cref="MapPictureGrid"/>.
        /// </summary>
        public MapPictureGrid(IMapController inController = null)
        {
            InitializeComponent();

            Controller = inController;

            // Check my math and that Windows Forms Designer hasn't broken anything.
            Debug.Assert(TargetResolution == new Size(1280, 720));
            Debug.Assert(TargetResolution == new Size(Width, Height));
        }

        /// <summary>
        /// Sets up the map editor UI.
        /// </summary>
        /// <param name="EventData">Handled by parent.</param>
        protected override void OnLoad(EventArgs EventData)
        {
            base.OnLoad(EventData);
            SetStyle(ControlStyles.FixedHeight | ControlStyles.FixedWidth, true);

            FPSStopWatch.Start();
        }
        #endregion

        #region Displaying Graphics
        /// <summary>
        /// Paints multiple images without anti-aliasing or other distortion.
        /// </summary>
        /// <param name="inPaintArguments">Configuration used by the painting routine.</param>
        protected override void OnPaint(PaintEventArgs inPaintArguments)
        {
            if (!IsRendering)
            {
                IsRendering = true;

                // Set up pixel art-style rendering.
                inPaintArguments.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                inPaintArguments.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
                inPaintArguments.Graphics.SmoothingMode = SmoothingMode.None;
                inPaintArguments.Graphics.CompositingQuality = CompositingQuality.HighQuality;

                // Paint each set of images.
                for (var y = 0; y < MapHeightInParquets; y++)
                {
                    for (var x = 0; x < MapWidthInParquets; x++)
                    {
                        PaintPack(inPaintArguments, x, y);
                    }
                }

                MeasureFPS();
                IsRendering = false;
            }
        }

        /// <summary>
        /// Paint each image in the pack, scaled and in order.
        /// </summary>
        /// <param name="inPaintArguments">Configuration used by the painting routine.</param>
        /// <param name="inX">Column of the current pack.</param>
        /// <param name="inY">Row of the current pack.</param>
        private void PaintPack(PaintEventArgs inPaintArguments, int inX, int inY)
        {
            var TargetLocation = new Point(inX * TargetParquetDimensionInPixels,
                                           inY * TargetParquetDimensionInPixels);

            for (var layerIndex = 0; layerIndex < ParquetLayerCount; layerIndex++)
            {
                var TargetID = IDMap[inY, inX, layerIndex];

                if (0 != TargetID
                    && ImageByID.ContainsKey(TargetID))
                {
                    inPaintArguments.Graphics.DrawImage(ImageByID[TargetID], TargetLocation.X, TargetLocation.Y,
                                                        TargetParquetDimensionInPixels, TargetParquetDimensionInPixels);
                }
            }
        }
        #endregion

        #region Process Input
        /// <summary>
        /// Computers the location of the specified client <see cref="Point"/> in terms of grid coordinates.
        /// </summary>
        /// <param name="inLocation">
        /// A location on the <see cref="MapPictureGrid"/> relative to the upper left corner of the control.
        /// </param>
        /// <returns>The given <see cref="Point"/> in terms of grid coordinates.</returns>
        private static Point PointToGrid(Point inLocation)
            => new Point(inLocation.X / TargetParquetDimensionInPixels, inLocation.Y / TargetParquetDimensionInPixels);

        /// <summary>
        /// Computers the location of the specified grid <see cref="Point"/> in terms of client coordinates.
        /// </summary>
        /// <param name="inLocation">
        /// A location on the <see cref="MapPictureGrid"/> relative to the upper left corner of the control.
        /// </param>
        /// <returns>The given <see cref="Point"/> in terms of client coordinates.</returns>
        private static Point PointToPixel(Point inLocation)
            => new Point(inLocation.X * TargetParquetDimensionInPixels, inLocation.Y * TargetParquetDimensionInPixels);

        /// <summary>
        /// Occurs when the mouse pointer rests on the control.
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventArguments">Information about the event.</param>
        private void MapPictureGrid_MouseHover(object inSender, EventArgs inEventArguments)
        {
            if (!IsMidClick
                && Controller is not null)
            {
                var gridLocation = PointToGrid(PointToClient(Cursor.Position));
                var screenLocation = PointToScreen(PointToPixel(gridLocation));
                Controller.MapHover(inSender, inEventArguments, gridLocation, screenLocation);
            }
        }

        /// <summary>
        /// Occurs when the mouse pointer is over the control and a mouse button is pressed.
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inMouseArguments">Information about the event.</param>
        private void MapPictureGrid_MouseDown(object inSender, MouseEventArgs inMouseArguments)
        {
            if (!IsMidClick
                && Controller is not null)
            {
                ClickStartLocation = PointToGrid(inMouseArguments.Location);
                IsMidClick = true;
            }
        }

        /// <summary>
        /// Occurs when the mouse pointer is over the control and a mouse button is released.
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inMouseArguments">Information about the event.</param>
        private void MapPictureGrid_MouseUp(object inSender, MouseEventArgs inMouseArguments)
        {
            if (IsMidClick
                && Controller is not null)
            {
                var clickEndLocation = PointToGrid(inMouseArguments.Location);
                IsMidClick = false;
                Controller.MapUp(inSender, inMouseArguments, ClickStartLocation, clickEndLocation);
            }
        }

        #endregion

        #region Performance Verification
        /// <summary>Used to calculate FPS.</summary>
        private readonly Stopwatch FPSStopWatch = new Stopwatch();

        /// <summary>How often to report the FPS measurements, in milliseconds.</summary>
        private const double MillisecondsBetweenReports = 1000.0;

        /// <summary>How long it has been since FPS was measured.</summary>
        private double MillisecondsSinceLastReport = 0.0;

        /// <summary>A point in time noted during the prior frame.</summary>
        private double CheckInPointLastFrame = 0.0;

        /// <summary>How many frames have been painted since the last FPS measurement.</summary>
        private int FrameCount = 0;

        /// <summary>How many times to calculate FPS before reporting.</summary>
        private const int NumberOfSamples = 10;

        /// <summary>The current calculation being performed.</summary>
        private int CalculationIndex = 0;

        /// <summary>Most recent set of FPS calculations.</summary>
        private readonly int[] FPSCalculations = new int[NumberOfSamples];

        /// <summary>
        /// Measures the <see cref="MapPictureGrid"/>'s current FPS, reporting once a several samples have been taken..
        /// </summary>
        public void MeasureFPS()
        {
            TimeSpan elapsed = FPSStopWatch.Elapsed;
            MillisecondsSinceLastReport += elapsed.TotalMilliseconds - CheckInPointLastFrame;
            CheckInPointLastFrame = elapsed.TotalMilliseconds;
            FrameCount++;
            if (MillisecondsSinceLastReport >= MillisecondsBetweenReports)
            {
                FPSCalculations[CalculationIndex] = FrameCount;
                FrameCount = 0;
                MillisecondsSinceLastReport = 0;

                CalculationIndex = (CalculationIndex + 1) % NumberOfSamples;
                if (CalculationIndex == 0)
                {
                    var sum = 0;
                    for (var i = 0; i < NumberOfSamples; i++)
                    {
                        sum += FPSCalculations[i];
                    }
                    Text = $"Map Grid Test ~ Average FPS: {sum / NumberOfSamples}";
                }
            }
        }
        #endregion
    }
}
