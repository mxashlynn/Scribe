using System;
using System.Drawing;
using System.Windows.Forms;
using Scribe.CustomControls;

namespace Scribe.Forms.Development
{
    partial class TestMapGridForm : Form
    {
        #region Class Defaults
        /// <summary>Pseudo-Random Number Generator, used in creating the test pattern.</summary>
        private readonly Random PRNG = new Random();

        /// <summary>Periodically calculate the map's FPS.</summary>
        private readonly Timer CalculateFPSTimer = new Timer();

        /// <summary>How many times to calculate FPS before reporting.</summary>
        private const int NumberOfSamples = 100;

        /// <summary>How often, in milliseconds, to calculate FPS.</summary>
        private const int CalculationInterval = 30;
        #endregion

        #region Characteristics
        /// <summary>The current calculation being performed.</summary>
        private int CalculationIndex = 0;

        /// <summary>Most recent set of FPS calculations.</summary>
        private readonly double[] FPSCalculations = new double[NumberOfSamples];
        #endregion

        #region Optimizations
        /// <summary>Encapsulates the information needed when creating a control.</summary>
        /// <remarks>In this instance, composited mode is turned on to improve framerate.</remarks>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of <see cref="TestMapGridForm"/>.
        /// </summary>
        public TestMapGridForm()
        {
            InitializeComponent();

            CalculateFPSTimer.Tick += CalculateAndReportFPS;
            CalculateFPSTimer.Interval = CalculationInterval;
        }

        /// <summary>
        /// Sets up the map.
        /// </summary>
        /// <param name="EventData">Handled by parent.</param>
        protected override void OnLoad(EventArgs EventData)
        {
            base.OnLoad(EventData);

            // Load Test Patterns
            MapGrid.ImageByID[1] = (Bitmap)Image.FromFile("../../../Resources/ParquetTest1.png");
            MapGrid.ImageByID[2] = (Bitmap)Image.FromFile("../../../Resources/ParquetTest2.png");
            MapGrid.ImageByID[3] = (Bitmap)Image.FromFile("../../../Resources/ParquetTest3.png");
            MapGrid.ImageByID[4] = (Bitmap)Image.FromFile("../../../Resources/ParquetTest4.png");

            // Create Test Map
            // Paint each set of images.
            for (var x = 0; x < MapPictureGrid.MapWidthInParquets; x++)
            {
                for (var y = 0; y < MapPictureGrid.MapHeightInParquets; y++)
                {
                    MapGrid.IDMap[y, x, 0] = RandomBool() ? 0 : 1;
                    MapGrid.IDMap[y, x, 1] = RandomBool() ? 0 : 2;
                    MapGrid.IDMap[y, x, 2] = RandomBool() ? 0 : 3;
                    MapGrid.IDMap[y, x, 3] = RandomBool() ? 0 : 4;
                }
            }
            MapGrid.IDMap[0, 0, 0] = 1;
            MapGrid.IDMap[0, 0, 1] = 2;
            MapGrid.IDMap[0, 0, 2] = 3;
            MapGrid.IDMap[0, 0, 3] = 4;
            MapGrid.IDMap[0, 1, 0] = 0;
            MapGrid.IDMap[0, 1, 1] = 0;
            MapGrid.IDMap[0, 1, 2] = 0;
            MapGrid.IDMap[0, 1, 3] = 0;

            CalculateFPSTimer.Start();
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Calculates the average FPS according and reports once enough samples have been made.
        /// </summary>
        /// <param name="inSender">Ignored.</param>
        /// <param name="inArguments">Ignored.</param>
        private void CalculateAndReportFPS(object inSender, EventArgs inArguments)
        {
            FPSCalculations[CalculationIndex] = MapGrid.GetFramesPerSecond();
            CalculationIndex = (CalculationIndex + 1) % NumberOfSamples;

            if (CalculationIndex == 0)
            {
                var sum = 0d;
                for (var i = 0; i < NumberOfSamples; i++)
                {
                    sum += FPSCalculations[i];
                }
                Text = $"Map Grid Test ~ Average FPS: {sum / NumberOfSamples}";
            }
        }

        /// <summary>
        /// Returns a boolean value according to .Net's default pseudo-random number generator.
        /// </summary>
        /// <returns><c>true</c> or <c>false</c></returns>
        private bool RandomBool()
            => PRNG.Next(2) > 0;
        #endregion
    }
}
