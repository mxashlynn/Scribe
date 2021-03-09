using System;
using System.Drawing;
using System.Windows.Forms;
using Parquet;
using Parquet.Regions;

namespace Scribe.Forms
{
    /// <summary>
    /// A form that enables the user to organize ever <see cref="RegionModel"/> in the game.
    /// </summary>
    public partial class WorldLayoutForm : Form
    {
        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="WorldLayoutForm"/> class.
        /// </summary>
        public WorldLayoutForm()
        {
            InitializeComponent();

            #region Add Region Statics to Table
            WorldLayoutTableLayoutPanel.SuspendLayout();

            for (var column = 0; column < WorldLayoutTableLayoutPanel.ColumnCount; column++)
            {
                for (var row = 0; row < WorldLayoutTableLayoutPanel.RowCount; row++)
                {
                    var regionStatic = new Label
                    {
                        BackColor = SystemColors.AppWorkspace,
                        BorderStyle = BorderStyle.FixedSingle,
                        Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point),
                        Location = new Point(0, 0),
                        Margin = new Padding(0),
                        Name = $"RegionStatic{column:00}_{row:00}",
                        Size = new Size(25, 25),
                        Tag = new Point2D(column, row),
                        Text = $"{row:00}",
                        TextAlign = ContentAlignment.MiddleCenter,
                    };
                    regionStatic.Click += new EventHandler(RegionStatic_Click);
                    WorldLayoutTableLayoutPanel.Controls.Add(regionStatic, column, row);
                }
            }

            WorldLayoutTableLayoutPanel.ResumeLayout(false);
            #endregion
        }
        #endregion

        #region Layout Table Click Events
        /// <summary>
        /// Responds to a user clicking on a region static.
        /// </summary>
        /// <param name="inSender">Originator of the event.</param>
        /// <param name="inEventArguments">Additional event data.</param>
        private void RegionStatic_Click(object inSender, EventArgs inEventArguments)
        {
            var regionStatic = (Label)inSender;
            UpdateRegionAt((Point2D)regionStatic.Tag, regionStatic);
        }
        #endregion

        #region Update Data
        /// <summary>
        /// Responds to a request to assign a <see cref="RegionModel"/> to a given location in the world.
        /// </summary>
        /// <param name="inCoordinates">The location to assign the <see cref="RegionModel"/>.</param>
        /// <param name="inRegionStatic">The UI element reflecting that <see cref="RegionModel"/>.</param>
        private void UpdateRegionAt(Point2D inCoordinates, Label inRegionStatic)
        {
            MessageBox.Show($"Assign RegionModel to ({inCoordinates.X}, {inCoordinates.Y}, UNKNOWN).");
            inRegionStatic.BackColor = Color.AliceBlue;
        }
        #endregion
    }
}
