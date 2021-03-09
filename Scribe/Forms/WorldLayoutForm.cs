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
        #region Class Defaults
        /// <summary>Index to the uppermost layer.</summary>
        private const int UpperLayer = 0;

        /// <summary>Index to the midmost layer.</summary>
        private const int MiddleLayer = 1;

        /// <summary>Index to the bottommost layer.</summary>
        private const int LowerLayer = 2;

        /// <summary>Index to the an unconnected layer.</summary>
        private const int ElsewhereLayer = 3;
        #endregion

        #region Characteristics
        /// <summary>The <see cref="RegionModel"/> currently being worked with.</summary>
        private ModelID CurrentModel = ModelID.None;

        /// <summary>Backing store for the <see cref="CurrentLayer"/>.</summary>
        private int currentLayerBackingInt = MiddleLayer;

        /// <summary>The world layer currently being edited and displayed.</summary>
        private int CurrentLayer
        {
            get => currentLayerBackingInt;
            set
            {
                currentLayerBackingInt = value;
                UpdateLayerDisplay();
            }
        }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="WorldLayoutForm"/> class.
        /// </summary>
        public WorldLayoutForm()
        {
            InitializeComponent();

            #region Add Region Statics to Table
            SuspendLayout();
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
                    regionStatic.MouseClick += new MouseEventHandler(RegionStatic_MouseClick);
                    WorldLayoutTableLayoutPanel.Controls.Add(regionStatic, column, row);
                }
            }

            WorldLayoutTableLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
            #endregion
        }
        #endregion

        #region Layout Table Click Events
        /// <summary>
        /// Responds to a user clicking on a region static.
        /// </summary>
        /// <param name="inSender">Originator of the event.</param>
        /// <param name="inEventArguments">Additional event data.</param>
        private void RegionStatic_MouseClick(object inSender, MouseEventArgs inEventArguments)
        {
            var regionStatic = (Label)inSender;
            if (inEventArguments.Button == MouseButtons.Left)
            {
                UpdateRegionAt((Point2D)regionStatic.Tag, regionStatic);
            }
            else
            {
                MessageBox.Show("Right Click!!");
            }
        }
        #endregion

        #region Update World Data
        // TODO [MAPS] WorldLayourForm.RegionListBox needs to be updated when the regions listbox in MainEditorForm is updated.
        // Maybe this can be done simply by refreshing data when the form is selected/becomes active?
        // If so, that would be an easy addition to the MainEditorForm, too.

        /// <summary>
        /// Responds to a request to assign a <see cref="RegionModel"/> to a given location in the world.
        /// </summary>
        /// <param name="inCoordinates">The location to assign the <see cref="RegionModel"/>.</param>
        /// <param name="inRegionStatic">The UI element reflecting that <see cref="RegionModel"/>.</param>
        private void UpdateRegionAt(Point2D inCoordinates, Label inRegionStatic)
        {
            MessageBox.Show($"Assign RegionModel to ({inCoordinates.X}, {inCoordinates.Y}, {CurrentLayer}).");
            inRegionStatic.BackColor = Color.AliceBlue;
        }
        #endregion

        #region Update Model
        // TODO [MAPS] Update non-Exit properties for current model.
        #endregion

        #region Update Editor
        /// <summary>
        /// Responds to the user selecting a new layer to edit.
        /// </summary>
        private void UpdateLayerDisplay()
        {
            // TODO [MAPS] Update the layer display for the new
        }

        /// <summary>
        /// Responds to the user selecting the Upper layer.
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventArguments">Additional data about the event.</param>
        private void LayerUpperRadioButton_CheckedChanged(object inSender, EventArgs inEventArguments)
            => CurrentLayer = LayerUpperRadioButton.Checked
                ? UpperLayer
                : CurrentLayer;

        /// <summary>
        /// Responds to the user selecting the Middle layer.
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventArguments">Additional data about the event.</param>
        private void LayerMiddleRadioButton_CheckedChanged(object inSender, EventArgs inEventArguments)
            => CurrentLayer = LayerMiddleRadioButton.Checked
                ? MiddleLayer
                : CurrentLayer;

        /// <summary>
        /// Responds to the user selecting the Lower layer.
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventArguments">Additional data about the event.</param>
        private void LayerLowerRadioButton_CheckedChanged(object inSender, EventArgs inEventArguments)
            => CurrentLayer = LayerLowerRadioButton.Checked
                ? LowerLayer
                : CurrentLayer;

        /// <summary>
        /// Responds to the user selecting the Elsewhere layer.
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventArguments">Additional data about the event.</param>
        private void LayerElsewhereRadioButton_CheckedChanged(object inSender, EventArgs inEventArguments)
            => CurrentLayer = LayerElsewhereRadioButton.Checked
                ? ElsewhereLayer
                : CurrentLayer;

        // TODO [MAPS] Update the state of the editor.
        #endregion

        #region Update Exits
        // TODO [MAPS] Update Exit properties for all models
        #endregion
    }
}
