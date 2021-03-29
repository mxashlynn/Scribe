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
using ParquetCustomControls;
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

        /// <summary>The coordinates of every possible location in the world.</summary>
        private readonly IReadOnlyList<Point3D> AllCoordinates;
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
            SuspendLayout();
            WorldTableLayoutPanel.SuspendLayout();
            for (var column = 0; column < WorldTableLayoutPanel.ColumnCount; column++)
            {
                for (var row = 0; row < WorldTableLayoutPanel.RowCount; row++)
                {
                    var regionStatic = new DoubleBufferedStatic
                    {
                        Name = $"RegionStatic{column:00}_{row:00}",
                        Tag = new Point2D(column, row),
                    };
                    regionStatic.MouseClick += new MouseEventHandler(RegionStatic_MouseClick);
                    WorldTableLayoutPanel.Controls.Add(regionStatic, column, row);
                }
            }
            WorldTableLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
            #endregion

            #region Cache Coordinates
            var allCoordinates = new List<Point3D>();
            for (var layer = 0; layer < LayerCount; layer++)
            {
                for (var column = 0; column < WorldTableLayoutPanel.ColumnCount; column++)
                {
                    for (var row = 0; row < WorldTableLayoutPanel.RowCount; row++)
                    {
                        allCoordinates.Add(new Point3D(row, column, layer));
                    }
                }
            }
            AllCoordinates = allCoordinates;
            #endregion

            #region Subscribe to Events
            All.Regions.VisibleDataChanged += Regions_VisibleDataChanged;
            #endregion
        }

        /// <summary>
        /// Sets up the layout tool UI.
        /// </summary>
        /// <param name="EventData">Handled by parent.</param>
        protected override void OnLoad(EventArgs EventData)
        {
            base.OnLoad(EventData);
            LoadWorldData();
            UpdateAllExits();
            UpdateLayerDisplay();
            RepopulateListBox();
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
                            var currentRegion = unvisitedRegions.FirstOrDefault(region => region.ID > 0
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

        #region Click Events
        #region Layout Table
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
                var oldCoordinates = UpdateRegionAt(clickedCoordinates, regionStatic);
                var newCoordinates = new Point3D(clickedCoordinates.Y, clickedCoordinates.X, CurrentLayer);
                UpdateExitsAt(new List<Point3D> { newCoordinates, oldCoordinates });
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

        #region Region Properties
        /// <summary>
        /// Responds to the text being changed in the <see cref="RegionNameTextBox"/>.
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventArguments">Additional event data.</param>
        private void RegionNameTextBox_Validated(object inSender, EventArgs inEventArguments)
            => UpdateName();

        /// <summary>
        /// Responds to the text being changed in the <see cref="RegionDescriptionTextBox"/>.
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventArguments">Additional event data.</param>
        private void RegionDescriptionTextBox_Validated(object inSender, EventArgs inEventArguments)
            => UpdateDescription();

        /// <summary>
        /// Responds to the text being changed in the <see cref="RegionCommentTextBox"/>.
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventArguments">Additional event data.</param>
        private void RegionCommentTextBox_Validated(object inSender, EventArgs inEventArguments)
            => UpdateComment();
        #endregion

        #region Layer Visibility
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

        #region Region List
        /// <summary>
        /// Responds to a RegionModel being selected in the <see cref="LayoutRegionListBox"/>.
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventArguments">Additional event data.</param>
        private void LayoutRegionListBox_SelectedValueChanged(object inSender, EventArgs inEventArguments)
        {
            CurrentModelID = ((LayoutToolRegion)LayoutRegionListBox.SelectedItem)?.Model.ID ?? ModelID.None;
            var propertiesCanBeEdited = CurrentModelID != ModelID.None;

            RegionNameTextBox.Enabled = propertiesCanBeEdited;
            RegionDescriptionTextBox.Enabled = propertiesCanBeEdited;
            RegionCommentTextBox.Enabled = propertiesCanBeEdited;
            RegionBackgroundColorStatic.Enabled = propertiesCanBeEdited;
            UpdateRegionPropertiesUI();
        }

        /// <summary>
        /// Responds to the user clicking "Add New Region".
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventArguments">Additional event data.</param>
        private void LayoutRegionAddNewButton_Click(object inSender, EventArgs inEventArguments)
            => AddNewRegion();

        /// <summary>
        /// Responds to the user clicking "Duplicate Region".
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventArguments">Additional event data.</param>
        private void LayoutRegionDuplicateButton_Click(object inSender, EventArgs inEventArguments)
            => DuplicateRegion();

        /// <summary>
        /// Responds to the user clicking "Remove Region".
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventArguments">Additional event data.</param>
        private void LayoutRegionRemoveButton_Click(object inSender, EventArgs inEventArguments)
            => RemoveRegion();

        /// <summary>
        /// Responds to the player clicking on the <see cref="RegionModel.BackgroundColor"/> selector.
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventArguments">Additional event data.</param>
        private void RegionBackgroundColorStatic_Click(object inSender, EventArgs inEventArguments)
            => SelectBackgroundColor();

        /// <summary>
        /// Invokes the <see cref="MapEditorForm"/> for the currently selected <see cref="LayoutToolRegion"/>.
        /// </summary>
        /// <param name="inSender">The originator of the event.</param>
        /// <param name="inEventArguments">Additional event data.</param>
        private void RegionMapEditButton_Click(object inSender, EventArgs inEventArguments)
        {
            // TODO [MAPS] Wire up launching map editor.
            //MapEditorWindow.CurrentRegion = (RegionModel)RegionListBox.SelectedItem;
            //if (RegionEditorWindow.CurrentRegion is null ||
            //    RegionEditorWindow.ShowDialog() == DialogResult.Abort)
            //{
            //    SystemSounds.Beep.Play();
            //    Logger.Log(LogLevel.Warning, Resources.WarningNothingSelected);
            //}
            SystemSounds.Beep.Play();
        }
        #endregion
        #endregion

        #region Other Events
        /// <summary>
        /// Responds to external changes to the <see cref="ModelCollection{RegionModel}"/>.
        /// </summary>
        /// <param name="inSender">
        /// The instance that raised the event.  If a <see cref="ModelCollection{TModel}"/>, then the collection itself changed;
        /// if a <see cref="RegionModel"/>, then one of the visible properties of the RegionModel changed.</param>
        /// <param name="inEventData">Additional information about the event.</param>
        /// <returns><c>true</c> if an update was performed; otherwise, <c>false</c>.</returns>
        private bool Regions_VisibleDataChanged(object inSender, EventArgs inEventData)
        {
            if (ScribeProgram.MostRecentUpdateSource == this)
            {
                return false;
            }

            UpdateLayerDisplay();
            RepopulateListBox();
            ScribeProgram.MostRecentUpdateSource = null;
            return true;
        }

        #endregion

        #region Update Region Properties
        /// <summary>
        /// Changes the <see cref="Model.Name"/> of the current <see cref="LayoutToolRegion"/>.
        /// </summary>
        private void UpdateName()
        {
            var model = ((LayoutToolRegion)LayoutRegionListBox.SelectedItem)?.Model ?? LayoutToolRegion.None.Model;
            if (model.ID == ModelID.None)
            {
                // Silently abort if no model is selected.
                return;
            }

            if (string.Compare(RegionNameTextBox.Text, model.Name, StringComparison.OrdinalIgnoreCase) != 0)
            {
                ScribeProgram.MostRecentUpdateSource = this;

                var mutableModel = (IMutableRegionModel)model;
                var oldValue = model.Name;
                var changeToExecute = new ChangeValue(oldValue, RegionNameTextBox.Text, nameof(RegionModel.Name),
                                                      (object databaseValue) =>
                                                      {
                                                          mutableModel.Name = databaseValue.ToString();
                                                          MainForm.HasUnsavedChanges = true;
                                                      },
                                                      (object displayValue) => RegionNameTextBox.Text = displayValue.ToString(),
                                                      (object oldValue) => RegionNameTextBox.Text = oldValue.ToString());
                Logger.Log(LogLevel.Info, $"{nameof(Change.Execute)} {changeToExecute.Description}");
                ChangeManager.AddAndExecute(changeToExecute);

                // For the name value, the display in the list must also be updated.
                LayoutRegionListBox.Items[LayoutRegionListBox.SelectedIndex] = LayoutRegionListBox.SelectedItem;
            }
        }

        /// <summary>
        /// Changes the <see cref="Model.Description"/> of the current <see cref="LayoutToolRegion"/>.
        /// </summary>
        private void UpdateDescription()
        {
            var model = ((LayoutToolRegion)LayoutRegionListBox.SelectedItem)?.Model ?? LayoutToolRegion.None.Model;
            if (model.ID == ModelID.None)
            {
                // Silently abort if no model is selected.
                return;
            }

            if (string.Compare(RegionDescriptionTextBox.Text, model.Description, StringComparison.OrdinalIgnoreCase) != 0)
            {
                var mutableModel = (IMutableRegionModel)model;
                var oldValue = model.Description;
                var changeToExecute = new ChangeValue(oldValue, RegionDescriptionTextBox.Text, nameof(RegionModel.Description),
                                                      (object databaseValue) =>
                                                      {
                                                          mutableModel.Description = databaseValue.ToString();
                                                          MainForm.HasUnsavedChanges = true;
                                                      },
                                                      (object displayValue) => RegionDescriptionTextBox.Text = displayValue.ToString(),
                                                      (object oldValue) => RegionDescriptionTextBox.Text = oldValue.ToString());
                Logger.Log(LogLevel.Info, $"{nameof(Change.Execute)} {changeToExecute.Description}");
                ChangeManager.AddAndExecute(changeToExecute);
            }
        }

        /// <summary>
        /// Changes the <see cref="Model.Comment"/> of the current <see cref="LayoutToolRegion"/>.
        /// </summary>
        private void UpdateComment()
        {
            var model = ((LayoutToolRegion)LayoutRegionListBox.SelectedItem)?.Model ?? LayoutToolRegion.None.Model;
            if (model.ID == ModelID.None)
            {
                // Silently abort if no model is selected.
                return;
            }

            if (string.Compare(RegionCommentTextBox.Text, model.Comment, StringComparison.OrdinalIgnoreCase) != 0)
            {
                var mutableModel = (IMutableRegionModel)model;
                var oldValue = model.Comment;
                var changeToExecute = new ChangeValue(oldValue, RegionCommentTextBox.Text, nameof(RegionModel.Comment),
                                                      (object databaseValue) =>
                                                      {
                                                          mutableModel.Comment = databaseValue.ToString();
                                                          MainForm.HasUnsavedChanges = true;
                                                      },
                                                      (object displayValue) => RegionCommentTextBox.Text = displayValue.ToString(),
                                                      (object oldValue) => RegionCommentTextBox.Text = oldValue.ToString());
                Logger.Log(LogLevel.Info, $"{nameof(Change.Execute)} {changeToExecute.Description}");
                ChangeManager.AddAndExecute(changeToExecute);
            }
        }
        #endregion

        #region Update Region Exits
        /// <summary>
        /// Updates the exits for every possible location in the world.
        /// </summary>
        private void UpdateAllExits()
            => UpdateExitsAt(AllCoordinates);

        /// <summary>
        /// Recomputes the exits for all <see cref="RegionModel"/>s at the given locations in the world.
        /// </summary>
        /// <param name="inCoordinateList">The locations whose exits need to be updated.</param>
        private void UpdateExitsAt(IEnumerable<Point3D> inCoordinateList)
        {
            foreach (var coordinates in inCoordinateList ?? Enumerable.Empty<Point3D>())
            {
                #region Acquire Region Models
                if (coordinates.Row < 0 || coordinates.Row > WorldDimension
                    || coordinates.Column < 0 || coordinates.Column > WorldDimension
                    || coordinates.Layer < 0 || coordinates.Layer > LayerCount)
                {
                    // Skip any regions whose coordinates are out of bounds.
                    // This might happen, for example, if the ModelID being replaced was not found in the layout panel.
                    continue;
                }

                var modelCenter = (IMutableRegionModel)All.Regions.GetOrNull<RegionModel>(World[coordinates.Row,
                                                                                                coordinates.Column,
                                                                                                coordinates.Layer]);
                if (modelCenter is null
                    || modelCenter.ID == ModelID.None)
                {
                    // If there is no region at the current coordinates, there is no work to be done.
                    continue;
                }

                var modelNorth = coordinates.Row > 0
                    ? (IMutableRegionModel)All.Regions.GetOrNull<RegionModel>(World[coordinates.Row - 1,
                                                                                    coordinates.Column,
                                                                                    coordinates.Layer])
                    : null;
                var modelSouth = coordinates.Row < WorldDimension
                    ? (IMutableRegionModel)All.Regions.GetOrNull<RegionModel>(World[coordinates.Row + 1,
                                                                                    coordinates.Column,
                                                                                    coordinates.Layer])
                    : null;
                var modelWest = coordinates.Column > 0
                    ? (IMutableRegionModel)All.Regions.GetOrNull<RegionModel>(World[coordinates.Row,
                                                                                    coordinates.Column - 1,
                                                                                    coordinates.Layer])
                    : null;
                var modelEast = coordinates.Column < WorldDimension
                    ? (IMutableRegionModel)All.Regions.GetOrNull<RegionModel>(World[coordinates.Row,
                                                                                    coordinates.Column + 1,
                                                                                    coordinates.Layer])
                    : null;
                var modelBelow = coordinates.Layer != ElsewhereLayer
                                 && coordinates.Layer > 0
                    ? (IMutableRegionModel)All.Regions.GetOrNull<RegionModel>(World[coordinates.Row,
                                                                                    coordinates.Column,
                                                                                    coordinates.Layer - 1])
                    : null;
                var modelAbove = coordinates.Layer < ElsewhereLayer
                    ? (IMutableRegionModel)All.Regions.GetOrNull<RegionModel>(World[coordinates.Row,
                                                                                    coordinates.Column,
                                                                                    coordinates.Layer + 1])
                    : null;
                #endregion

                #region Assign Exits
                modelCenter.RegionToTheNorthID = modelNorth?.ID ?? ModelID.None;
                modelCenter.RegionToTheSouthID = modelSouth?.ID ?? ModelID.None;
                modelCenter.RegionToTheEastID = modelEast?.ID ?? ModelID.None;
                modelCenter.RegionToTheWestID = modelWest?.ID ?? ModelID.None;
                modelCenter.RegionAboveID = modelAbove?.ID ?? ModelID.None;
                modelCenter.RegionBelowID = modelBelow?.ID ?? ModelID.None;

                if (modelNorth is not null) { modelNorth.RegionToTheSouthID = modelCenter.ID; }
                if (modelSouth is not null) { modelSouth.RegionToTheNorthID = modelCenter.ID; }
                if (modelEast is not null) { modelEast.RegionToTheWestID = modelCenter.ID; }
                if (modelWest is not null) { modelWest.RegionToTheEastID = modelCenter.ID; }
                if (modelAbove is not null) { modelAbove.RegionBelowID = modelCenter.ID; }
                if (modelBelow is not null) { modelBelow.RegionAboveID = modelCenter.ID; }
                #endregion
            }
        }
        #endregion

        #region Update Region List
        /// <summary>
        /// Adds a new <see cref="LayoutToolRegion"/> to <see cref="All.Regions"/> and the <see cref="LayoutRegionListBox"/>.
        /// </summary>
        private void AddNewRegion()
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

            ScribeProgram.MostRecentUpdateSource = this;

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
        /// Adds a new <see cref="LayoutToolRegion"/> with properties and status identicle to those of the currently selected region.
        /// </summary>
        private void DuplicateRegion()
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

            var regionToDuplicate = ((LayoutToolRegion)LayoutRegionListBox.SelectedItem).Model;
            if (regionToDuplicate is null
                || regionToDuplicate.ID == ModelID.None)
            {
                SystemSounds.Beep.Play();
                return;
            }

            ScribeProgram.MostRecentUpdateSource = this;

            var regionToAdd = new LayoutToolRegion(new RegionModel(nextID,
                                                                   $"{regionToDuplicate.Name} (Duplicate)",
                                                                   regionToDuplicate.Description,
                                                                   regionToDuplicate.Comment,
                                                                   new List<ModelTag>(regionToDuplicate.Tags),
                                                                   regionToDuplicate.BackgroundColor,
                                                                   regionToDuplicate.RegionToTheNorth,
                                                                   regionToDuplicate.RegionToTheEast,
                                                                   regionToDuplicate.RegionToTheSouth,
                                                                   regionToDuplicate.RegionToTheWest,
                                                                   regionToDuplicate.RegionAbove,
                                                                   regionToDuplicate.RegionBelow));

            // TODO [MAPS] Also duplicate RegionStatus once Map Editor is implemented.

            var changeToExecute = new ChangeList(regionToAdd, $"add duplicate Region definition",
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
        /// Removes a <see cref="LayoutToolRegion"/> from <see cref="All.Regions"/> and the <see cref="LayoutRegionListBox"/>.
        /// </summary>
        private void RemoveRegion()
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

            ScribeProgram.MostRecentUpdateSource = this;

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

        /// <summary>
        /// Raises a dialogue from which the user can select a <see cref="Color"/> for the current <see cref="RegionModel.BackgroundColor"/>.
        /// </summary>
        private void SelectBackgroundColor()
        {
            if (!All.CollectionsHaveBeenInitialized)
            {
                SystemSounds.Beep.Play();
                return;
            }

            ScribeProgram.MostRecentUpdateSource = this;

            if ((((LayoutToolRegion)LayoutRegionListBox.SelectedItem)?.Model) is IMutableRegionModel region)
            {
                // Sets the initial color select to the current text color.
                var oldColor = ColorTranslator.FromHtml(region.BackgroundColor);
                MainForm.SelectColorDialogue.Color = oldColor;

                if (MainForm.SelectColorDialogue.ShowDialog() == DialogResult.OK)
                {
                    var newColor = MainForm.SelectColorDialogue.Color;
                    var changeToExecute = new ChangeValue(oldColor, newColor, RegionBackgroundColorStatic.Name,
                                                          (object databaseValue) =>
                                                          {
                                                              region.BackgroundColor = MainEditorForm.ValueToColorHexString(databaseValue);
                                                              MainForm.HasUnsavedChanges = true;
                                                          },
                                                          (object displayValue) =>
                                                          {
                                                              var displayColor = (Color)displayValue;
                                                              RegionBackgroundColorStatic.BackColor = displayColor;
                                                              RegionBackgroundColorNameStatic.Text = EditorCommands.FormatColorNameForDisplay(displayColor);
                                                          },
                                                          (object oldValue) => RegionBackgroundColorStatic.BackColor = (Color)oldValue);
                    Logger.Log(LogLevel.Info, $"{nameof(Change.Execute)} {changeToExecute.Description}");
                    ChangeManager.AddAndExecute(changeToExecute);
                }
            }
        }
        #endregion

        #region Update World Array
        /// <summary>
        /// Assigns a <see cref="RegionModel"/> to a given location in the world.
        /// </summary>
        /// <param name="inCoordinates">The location to assign the <see cref="RegionModel"/>.</param>
        /// <param name="inRegionStatic">The UI element reflecting that <see cref="RegionModel"/>.</param>
        /// <returns>Another <see cref="World"/> location updated as a result of updating this one.</returns>
        private Point3D UpdateRegionAt(Point2D inCoordinates, Label inRegionStatic)
        {
            #region Update Old Location
            if (TryGetCoordinatesForID(CurrentModelID, out var oldCoordinates))
            {
                var idBeingReplaced = World[inCoordinates.Y, inCoordinates.X, CurrentLayer];
                var staticBeingReplaced =
                    (Label)WorldTableLayoutPanel.GetControlFromPosition(oldCoordinates.row, oldCoordinates.column);

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

            return new Point3D(oldCoordinates);

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
        /// Updates the content of the <see cref="WorldTableLayoutPanel"/> according to the <see cref="CurrentLayer"/>.
        /// </summary>
        private void UpdateLayerDisplay()
        {
            WorldTableLayoutPanel.SuspendLayout();
            for (var column = 0; column < WorldTableLayoutPanel.ColumnCount; column++)
            {
                for (var row = 0; row < WorldTableLayoutPanel.RowCount; row++)
                {
                    var staticBeingUpdated = (Label)WorldTableLayoutPanel.GetControlFromPosition(column, row);
                    staticBeingUpdated.Text = World[row, column, CurrentLayer] == ModelID.None
                        ? ""
                        : World[row, column, CurrentLayer].ToString()[^3..];
                    staticBeingUpdated.BackColor =
                        ColorTranslator.FromHtml(All.Regions
                                                    .GetOrNull<RegionModel>(World[row, column, CurrentLayer])?
                                                    .BackgroundColor ?? RegionModel.DefaultColor);
                    var regionName = All.Regions.GetOrNull<RegionModel>(World[row, column, CurrentLayer])?.Name;
                    LayoutToolTip.SetToolTip(staticBeingUpdated, regionName);
                }
            }
            WorldTableLayoutPanel.ResumeLayout(false);
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

        #region Close Tool
        /// <summary>
        /// Closes or hides the form as appropriate.
        /// </summary>
        /// <param name="inEventData">Data about the event.</param>
        protected override void OnFormClosing(FormClosingEventArgs inEventData)
        {
            base.OnFormClosing(inEventData);
            if (inEventData is not null
                && inEventData.CloseReason == CloseReason.UserClosing)
            {
                inEventData.Cancel = true;
                Hide();
            }
        }
        #endregion
    }
}
