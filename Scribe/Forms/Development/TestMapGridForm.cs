using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;
using Scribe.CustomControls;

namespace Scribe.Forms.Development
{
    partial class TestMapGridForm : Form, IMapController
    {
        #region Class Defaults
        /// <summary>Pseudo-Random Number Generator, used in creating the test pattern.</summary>
        private readonly Random PRNG = new Random();

        /// <summary>Periodically causes the map to redraw, similar to Draw events in a game loop.</summary>
        private readonly Timer RefreshMapTimer = new Timer();

        /// <summary>How often, in milliseconds, to redraw the map.</summary>
        private const int RefreshInterval = 30;
        #endregion

        #region Optimizations
        /// <summary>Encapsulates the information needed when creating a control.</summary>
        /// <remarks>In this instance, composited mode is turned on to improve frame rate.</remarks>
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
            MapGrid.Controller = this;

            RefreshMapTimer.Tick += (object sender, EventArgs arguments) =>
            {
                MapGrid.Refresh();
                Text = MapGrid.Text;
            };
            RefreshMapTimer.Interval = RefreshInterval;
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

            RefreshMapTimer.Start();
        }
        #endregion

        #region Disposal
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            RefreshMapTimer.Dispose();
            base.Dispose(disposing);
        }
        #endregion

        #region IMapController Implementation
        /// <summary>
        /// Occurs when the mouse hovers over a particular cell on the <see cref="MapPictureGrid"/>.
        /// </summary>
        /// <param name="inSender">The <see cref="MapPictureGrid"/> being hovered over.</param>
        /// <param name="inEventArguments">Arguments from the original event.</param>
        /// <param name="gridRestingLocation">The grid coordinates of the cell being hovered over.</param>
        /// <param name="screenRestingLocation">The screen coordinates of the cell being hovered over.</param>
        public void MapHover(object inSender, EventArgs inEventArguments, Point gridRestingLocation, Point screenRestingLocation)
        {
            var pixelRestingLocation = PointToClient(screenRestingLocation);
            _ = MessageBox.Show($"Hovering over ({gridRestingLocation.X}, {gridRestingLocation.Y}) at {pixelRestingLocation}.");
        }

        /// <summary>
        /// Occurs when the is released over the <see cref="MapPictureGrid"/>.
        /// </summary>
        /// <param name="inSender">The <see cref="MapPictureGrid"/> being hovered over.</param>
        /// <param name="inMouseArguments">Arguments from the original event.</param>
        /// <param name="clickStartLocation">The grid coordinates of the cell over which the click began.</param>
        /// <param name="clickEndLocation">The grid coordinates of the cell over which the click ended.</param>
        public void MapUp(object inSender, MouseEventArgs inMouseArguments, Point clickStartLocation, Point clickEndLocation)
            => _ = MessageBox.Show($"Clicked starting at ({clickStartLocation.X}, {clickStartLocation.Y}) at ending at ({clickEndLocation.X}, {clickEndLocation.Y}).");
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a boolean value according to .Net's default pseudo-random number generator.
        /// </summary>
        /// <returns><c>true</c> or <c>false</c></returns>
        [SuppressMessage("Security", "CA5394:Do not use insecure randomness",
            Justification = "This usage has nothing to do with security.")]
        private bool RandomBool()
            => PRNG.Next(2) > 0;
        #endregion
    }
}
