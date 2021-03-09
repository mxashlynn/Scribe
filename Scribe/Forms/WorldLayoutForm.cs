using System.Windows.Forms;
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
    }
}
