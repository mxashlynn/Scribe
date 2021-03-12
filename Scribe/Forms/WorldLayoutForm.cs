using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Parquet;
using Parquet.Beings;
using Parquet.Games;
using Parquet.Regions;
using Scribe.Properties;

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

        /// <summary>How many layers of <see cref="RegionModel"/>s the <see cref="WorldLayoutForm"/> tracks.</summary>
        private const int LayerCount = 4;

        /// <summary>
        /// How many <see cref="RegionModel"/>s in the <see cref="WorldLayoutForm"/>'s North-South/East-West dimensions.
        /// </summary>
        private const int WorldDimension = 24;

        /// <summary>Where to begin constructing the world graph.</summary>
        private static readonly Point3D WorldCenterCoordinates = new(WorldDimension / 2, WorldDimension / 2, MiddleLayer);

        /// <summary>Labels where to begin constructing the world graph.</summary>
        internal static readonly ModelTag WorldCenterTag = $"{Resources.TagPrefixLayoutTool}{WorldCenterCoordinates}";
        #endregion

        #region Characteristics
        /// <summary>The <see cref="RegionModel"/> currently being worked with.</summary>
        private ModelID CurrentModelID = ModelID.None;

        /// <summary>
        /// The <see cref="ModelID"/>s of the <see cref="RegionModel"/>s that the <see cref="WorldLayoutForm"/> works with.
        /// </summary>
        private readonly ModelID[,,] World = new ModelID[WorldDimension, WorldDimension, LayerCount];

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
            // TODO [MAPS] [UI] Show a UI element informing the user that the world is being loaded here.
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
                        TextAlign = ContentAlignment.MiddleCenter,
                    };
                    regionStatic.MouseClick += new MouseEventHandler(RegionStatic_MouseClick);
                    WorldLayoutTableLayoutPanel.Controls.Add(regionStatic, column, row);
                }
            }
            WorldLayoutTableLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
            // TODO [MAPS] [UI] Hide the UI element informing the user that the world is loading here.
            #endregion

            // TODO [MAPS] These four lines should probably be moved to Form.OnFocus or something similar.
            // TODO [MAPS] [UI] Show a UI element informing the user that the world is being loaded here.
            RepopulateListBox();
            LoadWorldData();
            UpdateLayerDisplay();
            // TODO [MAPS] [UI] Hide the UI element informing the user that the world is loading here.
        }


        /// <summary>
        /// Computes a view of the game world and loads it into <see cref="World"/>.
        /// </summary>
        [SuppressMessage("Design", "CA1031:Do not catch general exception types",
            Justification = "Exception is being reported to the user and logged.")]
        private void LoadWorldData()
        {
            #region Pre-Process ModelTags
            try
            {
                // Ensure only one RegionModel is marked as the center of the world.
                while (All.Regions.Where(region => region.Tags.Contains(WorldCenterTag)).Count() > 1)
                {
                    All.Regions.Last<IMutableRegionModel>(region => region.Tags.Contains(WorldCenterTag))
                               .Tags
                               .Remove(WorldCenterTag);
                }
            }
            catch (Exception exception)
            {
                Logger.Log(LogLevel.Error, Resources.ErrorProcessingTags, exception);
            }
            #endregion

            var startingRegion = GetStartingRegion();
            if (!startingRegion.Tags.Contains(WorldCenterTag))
            {
                ((IMutableRegionModel)startingRegion).Tags.Add(WorldCenterTag);
            }
            var currentElevation = MiddleLayer;
            var currentCoordinates = new Point2D(WorldDimension / 2, WorldDimension / 2);


            // TODO [MAPS] Rework this algorithm so that it uses stored coordinates.
            //  *****  HERE!!  ***********************************************************************************


            // TODO [MAPS] Implement algorithm to fit the world data into the assumptions of this tool.
            /*
            for (var layer = 0; layer < LayerCount; layer++)
            {
                for (var column = 0; column < WorldDimension; column++)
                {
                    for (var row = 0; row < WorldDimension; row++)
                    {
                        World[row, column, layer] == ????
                    }
                }
            }
            */

            #region Find Starting Region
            // Returns the world's central region, or the default region, or a region provided by the user.
            RegionModel GetStartingRegion()
                => All.Regions.Any(region => region.Tags.Contains(WorldCenterTag))
                    ? All.Regions.First(region => region.Tags.Contains(WorldCenterTag))
                    : GetDefaultRegionOrUserRegion();

            // Returns the default region according to the default GameModel, or a region provided by the user.
            RegionModel GetDefaultRegionOrUserRegion()
            {
                var gameID = All.Games.Select(game => game.ID).Min();
                return All.Games.FirstOrDefault(game => game.ID == gameID) is GameModel game
                    && game is not null
                        ? GetRegionFromGame(game)
                        : GetRegionFromUser();
            }

            // Returns the default region according to the given GameModel, or a region provided by the user.
            RegionModel GetRegionFromGame(GameModel game)
                => All.Characters.GetOrNull<CharacterModel>(game.PlayerCharacterID) is CharacterModel player
                && player is not null
                    ? GetRegionFromPlayer(player)
                    : GetRegionFromUser();

            // Returns the default region according to the given CharacterModel, or a region provided by the user.
            RegionModel GetRegionFromPlayer(CharacterModel player)
                => All.Regions.GetOrNull<RegionModel>(player.StartingLocation.RegionID) is RegionModel region
                && region is not null
                    ? region
                    : GetRegionFromUser();

            // Returns a region provided by the user.
            RegionModel GetRegionFromUser()
                // TODO [MAPS] [UI] Implement dialogue to get starting region.
                => null;
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
            #region Update Old Location
            if (TryGetCoordinatesForID(CurrentModelID, out var oldCoordinates))
            {
                var idBeingReplaced = World[inCoordinates.Y, inCoordinates.X, CurrentLayer];
                var staticBeingReplaced =
                    (Label)WorldLayoutTableLayoutPanel.GetControlFromPosition(oldCoordinates.row, oldCoordinates.column);

                World[oldCoordinates.row, oldCoordinates.column, oldCoordinates.layer] = idBeingReplaced;
                staticBeingReplaced.Text = idBeingReplaced == ModelID.None
                    ? ""
                    : idBeingReplaced.ToString();
                staticBeingReplaced.BackColor =
                    ColorTranslator.FromHtml(All.Regions.GetOrNull<RegionModel>(idBeingReplaced)?.BackgroundColor
                                             ?? RegionModel.DefaultColor);
            }
            #endregion

            #region Update New Location
            World[inCoordinates.Y, inCoordinates.X, CurrentLayer] = CurrentModelID;
            inRegionStatic.Text = CurrentModelID == ModelID.None
                ? ""
                : CurrentModelID.ToString();
            inRegionStatic.BackColor = RegionBackgroundColorStatic.BackColor;
            #endregion

            #region Local Helper Routines
            // Finds the coordinates of the first occurance of the given ModelID in the World array.
            // If the ModelID is found, returns true; otherwise returns false.
            bool TryGetCoordinatesForID(ModelID inID, out (int row, int column, int layer) outCoordinates)
            {
                for (var layer = 0; layer < LayerCount; layer++)
                {
                    for (var column = 0; column < WorldDimension; column++)
                    {
                        for (var row = 0; row < WorldDimension; row++)
                        {
                            if (World[row, column, layer] == inID)
                            {
                                outCoordinates = (row, column, layer);
                                return true;
                            }
                        }
                    }
                }

                outCoordinates = (-1, -1, -1);
                return false;
            }
            #endregion
        }
        #endregion

        #region Update RegionModel
        // TODO [MAPS] Update non-Exit properties for current model.
        #endregion

        #region Update Editor
        /// <summary>
        /// Responds to the user selecting a new layer to edit.
        /// </summary>
        private void UpdateLayerDisplay()
        {
            WorldLayoutTableLayoutPanel.SuspendLayout();
            for (var column = 0; column < WorldLayoutTableLayoutPanel.ColumnCount; column++)
            {
                for (var row = 0; row < WorldLayoutTableLayoutPanel.RowCount; row++)
                {
                    var staticBeingUpdated = (Label)WorldLayoutTableLayoutPanel.GetControlFromPosition(row, column);
                    staticBeingUpdated.Text = World[row, column, CurrentLayer] == ModelID.None
                        ? ""
                        : World[row, column, CurrentLayer].ToString();
                    staticBeingUpdated.BackColor =
                        ColorTranslator.FromHtml(All.Regions
                                                    .GetOrNull<RegionModel>(World[row, column, CurrentLayer])?.BackgroundColor
                                                    ?? RegionModel.DefaultColor);

                }
            }
            WorldLayoutTableLayoutPanel.ResumeLayout(false);
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

        /// <summary>
        /// Repopulates the <see cref="RegionModel"/> <see cref="ListBox"/>.
        /// </summary>
        /// <remarks>This should only be called if <see cref="All"/> has actually changed.</remarks>
        // TODO [MAPS] Wire this up.
        private void RepopulateListBox()
        {
            LayoutRegionListBox.SelectedItem = null;
            LayoutRegionListBox.BeginUpdate();
            LayoutRegionListBox.Items.Clear();
            LayoutRegionListBox.Items.Add(LayoutToolRegion.None);
            LayoutRegionListBox.Items.AddRange(All.Regions.Select(region => new LayoutToolRegion(region)).ToArray<object>());
            LayoutRegionListBox.EndUpdate();
        }

        // TODO [MAPS] Update the state of the editor.

        // TODO [MAPS] Update the region field displays when regions are selected.
        #endregion

        #region Update Exits
        // TODO [MAPS] Update Exit properties for all models
        #endregion
    }
}
