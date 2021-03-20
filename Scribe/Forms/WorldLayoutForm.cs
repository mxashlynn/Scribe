using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using Parquet;
using Parquet.Beings;
using Parquet.Games;
using Parquet.Regions;
using ParquetChangeManagement;
using Scribe.Properties;

namespace Scribe.Forms
{
    /// <summary>
    /// A form that enables the user to organize ever <see cref="RegionModel"/> in the game.
    /// </summary>
    public partial class WorldLayoutForm : Form
    {
        #region Class Defaults
        /// <summary>Index to the bottommost layer.</summary>
        private const int LowerLayer = 0;

        /// <summary>Index to the midmost layer.</summary>
        private const int MiddleLayer = 1;

        /// <summary>Index to the uppermost layer.</summary>
        private const int UpperLayer = 2;

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
        /// <summary>The <see cref="MainEditorForm"/> that launches this <see cref="WorldLayoutForm"/>.</summary>
        private readonly MainEditorForm MainForm;

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
        /// <param name="inMainForm">The <see cref="MainEditorForm"/> that launches this <see cref="WorldLayoutForm"/>.</param>
        public WorldLayoutForm(MainEditorForm inMainForm)
        {
            if (inMainForm is null)
            {
                Logger.Log(LogLevel.Fatal, Resources.ErrorNullEditor);
            }
            else
            {
                MainForm = inMainForm;
            }

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
                        Font = new Font("Arial Narrow", 9f, GraphicsUnit.Point),
                        Location = new Point(0, 0),
                        Margin = new Padding(0),
                        Name = $"RegionStatic{column:00}_{row:00}",
                        Padding = new Padding(0),
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
        }

        /// <summary>
        /// Sets up the layout tool UI.
        /// </summary>
        /// <param name="EventData">Handled by parent.</param>
        protected override void OnLoad(EventArgs EventData)
        {
            base.OnLoad(EventData);
            // TODO [MAPS] [UI] Show a UI element informing the user that the world is being loaded here.
            LoadWorldData();
            UpdateLayerDisplay();
            RepopulateListBox();
            // TODO [MAPS] [UI] Hide the UI element informing the user that the world is loading here.
        }

        /// <summary>
        /// Computes a view of the game world and loads it into <see cref="World"/>.
        /// </summary>
        private void LoadWorldData()
        {
            if (All.Regions.Any(region => region.ID > 0
                                       && region.Tags.Any(tag => tag.StartsWithOrdinalIgnoreCase(Resources.TagPrefixLayoutTool))))
            {
                #region Load Regions With Coordinates
                var unvisitedRegions = All.Regions.Where(region => region.ID > 0).ToList();
                for (var layer = 0; layer < LayerCount; layer++)
                {
                    for (var column = 0; column < WorldDimension; column++)
                    {
                        for (var row = 0; row < WorldDimension; row++)
                        {
                            var coordinates = new Point3D(row, column, layer);
                            var tag = $"{Resources.TagPrefixLayoutTool}{coordinates}";
                            var currentRegion = unvisitedRegions.First(region => region.ID > 0
                                                                              && region.Tags.ContainsOrdinalIgnoreCase(tag));
                            World[row, column, layer] = currentRegion?.ID ?? ModelID.None;
                            unvisitedRegions.Remove(currentRegion);
                        }
                    }
                }
                if (unvisitedRegions.Count > 0)
                {
                    var message = string.Format(CultureInfo.InvariantCulture,
                                                Resources.InfoUnprocessedRegions,
                                                unvisitedRegions.Count);
                    Logger.Log(LogLevel.Info, message);
                    MessageBox.Show(message, Resources.CaptionWorkflow, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                #endregion
            }
            else
            {
                var startRegion = GetDefaultRegion();
                if (startRegion is null)
                {
                    // If no regions have been defined, we start with a blank slate.
                    return;
                }

                #region Load Regions Without Coordinates
                var visitedRegions = new List<IMutableRegionModel>();
                var unvisitedRegions = new Queue<IMutableRegionModel>();
                var positiveRegionCount = All.Regions.Where(region => region.ID > 0).Count();

                startRegion.Tags.Add($"{WorldCenterTag}");
                unvisitedRegions.Enqueue(startRegion);

                #region Find Elevation-Based Regions
                while (unvisitedRegions.Count > 0)
                {
                    var currentRegion = unvisitedRegions.Dequeue();
                    visitedRegions.Add(currentRegion);
                    var currentCoordinates = GetCoordinatesFromTag((RegionModel)currentRegion);

                    World[currentCoordinates.Row, currentCoordinates.Column, currentCoordinates.Layer] = currentRegion.ID;

                    // North
                    if (currentCoordinates.Row > 0
                        && currentRegion.RegionToTheNorthID > 0 // Implicitly not ModelID.None
                        && !visitedRegions.Any(region => region.ID == currentRegion.RegionToTheNorthID))
                    {
                        var newCoordinates = new Point3D(currentCoordinates.Row - 1,
                                                         currentCoordinates.Column,
                                                         currentCoordinates.Layer);
                        var newRegion = (IMutableRegionModel)All.Regions
                                                                .GetOrNull<RegionModel>(currentRegion.RegionToTheNorthID);
                        newRegion.Tags.Add($"{Resources.TagPrefixLayoutTool}{newCoordinates}");
                        unvisitedRegions.Enqueue(newRegion);
                    }
                    // South
                    if (currentCoordinates.Row < WorldDimension
                        && currentRegion.RegionToTheSouthID > 0 // Implicitly not ModelID.None
                        && !visitedRegions.Any(region => region.ID == currentRegion.RegionToTheSouthID))
                    {
                        var newCoordinates = new Point3D(currentCoordinates.Row + 1,
                                                         currentCoordinates.Column,
                                                         currentCoordinates.Layer);
                        var newRegion = (IMutableRegionModel)All.Regions
                                                                .GetOrNull<RegionModel>(currentRegion.RegionToTheSouthID);
                        newRegion.Tags.Add($"{Resources.TagPrefixLayoutTool}{newCoordinates}");
                        unvisitedRegions.Enqueue(newRegion);
                    }
                    // West
                    if (currentCoordinates.Column > 0
                        && currentRegion.RegionToTheWestID > 0 // Implicitly not ModelID.None
                        && !visitedRegions.Any(region => region.ID == currentRegion.RegionToTheWestID))
                    {
                        var newCoordinates = new Point3D(currentCoordinates.Row,
                                                         currentCoordinates.Column - 1,
                                                         currentCoordinates.Layer);
                        var newRegion = (IMutableRegionModel)All.Regions
                                                                .GetOrNull<RegionModel>(currentRegion.RegionToTheWestID);
                        newRegion.Tags.Add($"{Resources.TagPrefixLayoutTool}{newCoordinates}");
                        unvisitedRegions.Enqueue(newRegion);
                    }
                    // East
                    if (currentCoordinates.Column < WorldDimension
                        && currentRegion.RegionToTheEastID > 0 // Implicitly not ModelID.None
                        && !visitedRegions.Any(region => region.ID == currentRegion.RegionToTheEastID))
                    {
                        var newCoordinates = new Point3D(currentCoordinates.Row,
                                                         currentCoordinates.Column + 1,
                                                         currentCoordinates.Layer);
                        var newRegion = (IMutableRegionModel)All.Regions
                                                                .GetOrNull<RegionModel>(currentRegion.RegionToTheEastID);
                        newRegion.Tags.Add($"{Resources.TagPrefixLayoutTool}{newCoordinates}");
                        unvisitedRegions.Enqueue(newRegion);
                    }
                    // Above
                    if (currentCoordinates.Layer < UpperLayer
                        && currentRegion.RegionAboveID > 0 // Implicitly not ModelID.None
                        && !visitedRegions.Any(region => region.ID == currentRegion.RegionAboveID))
                    {
                        var newCoordinates = new Point3D(currentCoordinates.Row,
                                                         currentCoordinates.Column,
                                                         currentCoordinates.Layer + 1);
                        var newRegion = (IMutableRegionModel)All.Regions
                                                                .GetOrNull<RegionModel>(currentRegion.RegionAboveID);
                        newRegion.Tags.Add($"{Resources.TagPrefixLayoutTool}{newCoordinates}");
                        unvisitedRegions.Enqueue(newRegion);
                    }
                    // Below
                    if (currentCoordinates.Layer > LowerLayer
                        && currentRegion.RegionBelowID > 0 // Implicitly not ModelID.None
                        && !visitedRegions.Any(region => region.ID == currentRegion.RegionBelowID))
                    {
                        var newCoordinates = new Point3D(currentCoordinates.Row,
                                                         currentCoordinates.Column,
                                                         currentCoordinates.Layer - 1);
                        var newRegion = (IMutableRegionModel)All.Regions
                                                                .GetOrNull<RegionModel>(currentRegion.RegionBelowID);
                        newRegion.Tags.Add($"{Resources.TagPrefixLayoutTool}{newCoordinates}");
                        unvisitedRegions.Enqueue(newRegion);
                    }
                }
                #endregion

                #region Find Elsewhere Regions
                if (positiveRegionCount > visitedRegions.Count)
                {
                    startRegion = All.Regions.First(region => !visitedRegions.Contains(region));
                    var startCoordinates = new Point3D(WorldCenterCoordinates.Row,
                                                       WorldCenterCoordinates.Column,
                                                       ElsewhereLayer);
                    startRegion.Tags.Add($"{Resources.TagPrefixLayoutTool}{startCoordinates}");
                    unvisitedRegions.Enqueue(startRegion);

                    while (unvisitedRegions.Count > 0)
                    {
                        var currentRegion = unvisitedRegions.Dequeue();
                        visitedRegions.Add(currentRegion);
                        var currentCoordinates = GetCoordinatesFromTag((RegionModel)currentRegion);

                        World[currentCoordinates.Row, currentCoordinates.Column, currentCoordinates.Layer] = currentRegion.ID;

                        // North
                        if (currentCoordinates.Row > 0
                            && currentRegion.RegionToTheNorthID > 0 // Implicitly not ModelID.None
                            && !visitedRegions.Any(region => region.ID == currentRegion.RegionToTheNorthID))
                        {
                            var newCoordinates = new Point3D(currentCoordinates.Row - 1,
                                                             currentCoordinates.Column,
                                                             ElsewhereLayer);
                            var newRegion = (IMutableRegionModel)All.Regions
                                                                    .GetOrNull<RegionModel>(currentRegion.RegionToTheNorthID);
                            newRegion.Tags.Add($"{Resources.TagPrefixLayoutTool}{newCoordinates}");
                            unvisitedRegions.Enqueue(newRegion);
                        }
                        // South
                        if (currentCoordinates.Row < WorldDimension
                            && currentRegion.RegionToTheSouthID > 0 // Implicitly not ModelID.None
                            && !visitedRegions.Any(region => region.ID == currentRegion.RegionToTheSouthID))
                        {
                            var newCoordinates = new Point3D(currentCoordinates.Row + 1,
                                                             currentCoordinates.Column,
                                                             ElsewhereLayer);
                            var newRegion = (IMutableRegionModel)All.Regions
                                                                    .GetOrNull<RegionModel>(currentRegion.RegionToTheSouthID);
                            newRegion.Tags.Add($"{Resources.TagPrefixLayoutTool}{newCoordinates}");
                            unvisitedRegions.Enqueue(newRegion);
                        }
                        // West
                        if (currentCoordinates.Column > 0
                            && currentRegion.RegionToTheWestID > 0 // Implicitly not ModelID.None
                            && !visitedRegions.Any(region => region.ID == currentRegion.RegionToTheWestID))
                        {
                            var newCoordinates = new Point3D(currentCoordinates.Row,
                                                             currentCoordinates.Column - 1,
                                                             ElsewhereLayer);
                            var newRegion = (IMutableRegionModel)All.Regions
                                                                    .GetOrNull<RegionModel>(currentRegion.RegionToTheWestID);
                            newRegion.Tags.Add($"{Resources.TagPrefixLayoutTool}{newCoordinates}");
                            unvisitedRegions.Enqueue(newRegion);
                        }
                        // East
                        if (currentCoordinates.Column < WorldDimension
                            && currentRegion.RegionToTheEastID > 0 // Implicitly not ModelID.None
                            && !visitedRegions.Any(region => region.ID == currentRegion.RegionToTheEastID))
                        {
                            var newCoordinates = new Point3D(currentCoordinates.Row,
                                                             currentCoordinates.Column + 1,
                                                             ElsewhereLayer);
                            var newRegion = (IMutableRegionModel)All.Regions
                                                                    .GetOrNull<RegionModel>(currentRegion.RegionToTheEastID);
                            newRegion.Tags.Add($"{Resources.TagPrefixLayoutTool}{newCoordinates}");
                            unvisitedRegions.Enqueue(newRegion);
                        }
                    }
                }
                #endregion

                #region Report Unvisited Regions
                if (positiveRegionCount > visitedRegions.Count)
                {
                    var message = string.Format(CultureInfo.InvariantCulture,
                                                Resources.InfoUnprocessedRegions,
                                                positiveRegionCount - visitedRegions.Count);
                    Logger.Log(LogLevel.Info, message);
                    MessageBox.Show(message, Resources.CaptionWorkflow, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                #endregion
                #endregion
            }

            #region Find Starting Region
            // Returns the default region.
            IMutableRegionModel GetDefaultRegion()
            {
                var gameID = All.Games.Where(game => game.ID > 0).Select(game => game.ID).Min();
                return All.Games.FirstOrDefault(game => game.ID == gameID) is GameModel game
                    && game is not null
                        ? GetRegionFromGame(game)
                        : GetFirstRegion();
            }

            // Returns the default region according to the given GameModel, or the first region defined.
            IMutableRegionModel GetRegionFromGame(GameModel game)
                => All.Characters.GetOrNull<CharacterModel>(game.PlayerCharacterID) is CharacterModel player
                && player is not null
                    ? GetRegionFromPlayer(player)
                    : GetFirstRegion();

            // Returns the default region according to the given CharacterModel, or the first region defined.
            IMutableRegionModel GetRegionFromPlayer(CharacterModel player)
                => All.Regions.GetOrNull<RegionModel>(player.StartingLocation.RegionID) is RegionModel region
                && region is not null
                    ? region
                    : GetFirstRegion();

            // Returns the first region defined.
            IMutableRegionModel GetFirstRegion()
                => All.Regions.Where(region => region.ID > 0).FirstOrDefault();
            #endregion

            #region Parse Coordinates
            // Returns the layout tool coordinates stored as a ModelTag on the given Region.
            Point3D GetCoordinatesFromTag(RegionModel inRegion)
            {
                var serializedCoordinate = (string)inRegion.Tags.First(tag => tag.StartsWithOrdinalIgnoreCase(Resources.TagPrefixLayoutTool));
                return new Point3D(serializedCoordinate[Resources.TagPrefixLayoutTool.Length..]);
            }
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
            var clickedCoordinates = (Point2D)regionStatic.Tag;
            if (inEventArguments.Button == MouseButtons.Left)
            {
                UpdateRegionAt(clickedCoordinates, regionStatic);
            }
            else
            {
                CurrentModelID = World[clickedCoordinates.Y, clickedCoordinates.X, CurrentLayer];
                SelectCurrentModel();
                UpdateRegionPropertiesUI();
            }
        }

        /// <summary>
        /// Finds and selects the <see cref="LayoutToolRegion"/> whose <see cref="Model.ID"/> equals <see cref="CurrentModelID"/>.
        /// </summary>
        private void SelectCurrentModel()
        {
            for (int index = 0; index < LayoutRegionListBox.Items.Count; index++)
            {
                var region = (LayoutToolRegion)LayoutRegionListBox.Items[index];
                if (region.Model.ID == CurrentModelID)
                {
                    LayoutRegionListBox.SetSelected(index, true);
                    break;
                }
            }
        }
        #endregion

        #region Sidebar Click Events
        /// <summary>
        /// Responds to a RegionModel being selected in the <see cref="LayoutRegionListBox"/>.
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventArguments">Additional event data.</param>
        private void LayoutRegionListBox_SelectedValueChanged(object inSender, EventArgs inEventArguments)
        {
            CurrentModelID = ((LayoutToolRegion)LayoutRegionListBox.SelectedItem).Model.ID;
            UpdateRegionPropertiesUI();
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
        #endregion


        /// <summary>
        /// Responds to the user clicking "Add New Region".
        /// Adds a new <see cref="LayoutToolRegion"/> to <see cref="All.Regions"/> and the <see cref="LayoutRegionListBox"/>.
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventArguments">Additional event data.</param>
        private void RegionAddNewRegionButton_Click(object inSender, EventArgs inEventArguments)
        {
            if (!All.CollectionsHaveBeenInitialized)
            {
                SystemSounds.Beep.Play();
                return;
            }

            var nextID = All.Regions.Any()
                ? (ModelID)(All.Regions.Max(model => model?.ID ?? All.RegionIDs.Minimum) + 1)
                : All.RegionIDs.Minimum;
            if (nextID > All.RegionIDs.Maximum)
            {
                SystemSounds.Beep.Play();
                Logger.Log(LogLevel.Warning, Resources.ErrorMaximumIDReached);
                return;
            }

            var regionToAdd = new LayoutToolRegion(new RegionModel(nextID, "New Region", "", ""));
            var changeToExecute = new ChangeList(regionToAdd, $"add new Region definition",
                                        (object databaseValue) =>
                                        {
                                            ((IMutableModelCollection<RegionModel>)All.Regions).Add(((LayoutToolRegion)databaseValue).Model);
                                            _ = LayoutRegionListBox.Items.Add(databaseValue);
                                            LayoutRegionListBox.SelectedItem = databaseValue;
                                            MainForm.HasUnsavedChanges = true;
                                        },
                                        (object databaseValue) =>
                                        {
                                            ((IMutableModelCollection<RegionModel>)All.Regions).Remove(((LayoutToolRegion)databaseValue).Model);
                                            LayoutRegionListBox.Items.Remove(databaseValue);
                                            LayoutRegionListBox.SelectedItem = null;
                                            MainForm.HasUnsavedChanges = true;
                                        });
            Logger.Log(LogLevel.Info, $"{nameof(Change.Execute)} {changeToExecute.Description}");
            ChangeManager.AddAndExecute(changeToExecute);
        }

        /// <summary>
        /// Responds to the user clicking "Remove Region".
        /// Removes a <see cref="LayoutToolRegion"/> from <see cref="All.Regions"/> and the <see cref="LayoutRegionListBox"/>.
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventArguments">Additional event data.</param>
        private void RegionRemoveRegionButton_Click(object inSender, EventArgs inEventArguments)
        {
            if (!All.CollectionsHaveBeenInitialized || LayoutRegionListBox.SelectedIndex == -1)
            {
                SystemSounds.Beep.Play();
                return;
            }

            var regionToRemove = ((LayoutToolRegion)LayoutRegionListBox.SelectedItem).Model;
            if (regionToRemove is null
                || regionToRemove.ID == ModelID.None)
            {
                SystemSounds.Beep.Play();
                return;
            }

            var changeToExecute = new ChangeList(regionToRemove, $"remove Region {regionToRemove.Name}",
                                        (object databaseValue) =>
                                        {
                                            ((IMutableModelCollection<RegionModel>)All.Regions).Remove(((LayoutToolRegion)databaseValue).Model);
                                            LayoutRegionListBox.Items.Remove(databaseValue);
                                            LayoutRegionListBox.SelectedItem = null;
                                            MainForm.HasUnsavedChanges = true;
                                        },
                                        (object databaseValue) =>
                                        {
                                            ((IMutableModelCollection<RegionModel>)All.Regions).Add(((LayoutToolRegion)databaseValue).Model);
                                            _ = LayoutRegionListBox.Items.Add(databaseValue);
                                            LayoutRegionListBox.SelectedItem = databaseValue;
                                            MainForm.HasUnsavedChanges = true;
                                        });
            Logger.Log(LogLevel.Info, $"{nameof(Change.Execute)} {changeToExecute.Description}");
            ChangeManager.AddAndExecute(changeToExecute);
        }
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
                var regionBeingReplaced = All.Regions.GetOrNull<RegionModel>(idBeingReplaced);
                staticBeingReplaced.BackColor =
                    ColorTranslator.FromHtml(regionBeingReplaced?.BackgroundColor ?? RegionModel.DefaultColor);
                LayoutToolTip.SetToolTip(staticBeingReplaced, regionBeingReplaced?.Name);
            }
            #endregion

            #region Update New Location
            World[inCoordinates.Y, inCoordinates.X, CurrentLayer] = CurrentModelID;
            inRegionStatic.Text = CurrentModelID == ModelID.None
                ? ""
                : CurrentModelID.ToString()[^3..];
            inRegionStatic.BackColor = RegionBackgroundColorStatic.BackColor;
            LayoutToolTip.SetToolTip(inRegionStatic, RegionNameTextBox.Text);
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

        #region Update Display
        /// <summary>
        /// Populates the UI for current <see cref="RegionModel"/>.
        /// </summary>
        private void UpdateRegionPropertiesUI()
        {
            if (LayoutRegionListBox.SelectedItem is null)
            {
                RegionIDStatic.Text = ModelID.None.ToString();
                RegionNameTextBox.Text = "";
                RegionDescriptionTextBox.Text = "";
                RegionCommentTextBox.Text = "";
                RegionBackgroundColorStatic.BackColor = EditorCommands.DefaultRegionColor;
                RegionBackgroundColorNameStatic.Text = EditorCommands.DefaultRegionColorName;
            }
            else if (LayoutRegionListBox.SelectedItem is LayoutToolRegion region)
            {
                RegionIDStatic.Text = region.Model.ID.ToString();
                RegionNameTextBox.Text = region.Model.Name;
                RegionDescriptionTextBox.Text = region.Model.Description;
                RegionCommentTextBox.Text = region.Model.Comment;
                var newBackColor = ColorTranslator.FromHtml(region.Model.BackgroundColor);
                RegionBackgroundColorStatic.BackColor = newBackColor;
                RegionBackgroundColorNameStatic.Text = EditorCommands.FormatColorNameForDisplay(newBackColor);
            }
        }

        /// <summary>
        /// Updates the content of the <see cref="WorldLayoutTableLayoutPanel"/> according to the <see cref="CurrentLayer"/>.
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
                        : World[row, column, CurrentLayer].ToString()[^3..];
                    staticBeingUpdated.BackColor =
                        ColorTranslator.FromHtml(All.Regions
                                                    .GetOrNull<RegionModel>(World[row, column, CurrentLayer])?.BackgroundColor
                                                    ?? RegionModel.DefaultColor);
                    var regionName = All.Regions.GetOrNull<RegionModel>(World[row, column, CurrentLayer])?.Name;
                    LayoutToolTip.SetToolTip(staticBeingUpdated, regionName);
                }
            }
            WorldLayoutTableLayoutPanel.ResumeLayout(false);
        }

        /// <summary>
        /// Repopulates the <see cref="RegionModel"/> <see cref="ListBox"/>.
        /// </summary>
        /// <remarks>This should only be called if <see cref="All"/> has actually changed.</remarks>
        private void RepopulateListBox()
        {
            LayoutRegionListBox.SelectedItem = null;
            LayoutRegionListBox.BeginUpdate();
            LayoutRegionListBox.Items.Clear();
            LayoutRegionListBox.Items.Add(LayoutToolRegion.None);
            LayoutRegionListBox.Items.AddRange(All.Regions.Where(region => region.ID > 0)
                                                          .Select(region => new LayoutToolRegion(region))
                                                          .ToArray<object>());
            LayoutRegionListBox.EndUpdate();
        }
        #endregion

        #region Update Exits
        // TODO [MAPS] Update Exit properties for all models
        #endregion
    }
}
