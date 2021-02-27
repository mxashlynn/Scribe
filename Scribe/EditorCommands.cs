using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Parquet;
using Parquet.Beings;
using Parquet.Biomes;
using Parquet.Crafts;
using Parquet.Games;
using Parquet.Items;
using Parquet.Parquets;
using Parquet.Regions;
using Parquet.Rooms;
using Parquet.Scripts;
using Scribe.Properties;

namespace Scribe
{
    /// <summary>
    /// Controls interaction with the library.
    /// </summary>
    internal static class EditorCommands
    {
        /// <summary>Children of the <see cref="Model"/> class that do not have a graphical representation.</summary>
        private static readonly IList<string> TypeNamesWithoutGraphics;

        /// <summary>Children of the <see cref="Model"/> class that have a graphical representation, and the path to those assets.</summary>
        private static readonly Dictionary<Range<ModelID>, string> GraphicalAssetPaths;

        /// <summary>Name of the folder under which all graphics are stored.</summary>
        private const string GraphicsFolderName = "Graphics";

        /// <summary>Dialogue for selecting the project folder to work in.</summary>
        private static readonly FolderBrowserDialog FolderBrowserDialogue;

        /// <summary>Texts that cannot be used as <see cref="ModelTag"/>s.</summary>
        private static readonly IList<string> ReservedWorldList;

        /// <summary>Indicates to the user that the text entered cannot be used as a <see cref="ModelTag"/>.</summary>
        internal static readonly string ReservedWordMessage;

        #region Initialization
        /// <summary>
        /// Initializes <see cref="EditorCommands"/> asset collections.
        /// </summary>
        [SuppressMessage("Performance", "CA1810:Initialize reference type static fields inline",
            Justification = "Not possible, we need to force load the Parquet assembly.")]
        static EditorCommands()
        {
            FolderBrowserDialogue = new FolderBrowserDialog();
            ReservedWorldList = new List<string>
            {
                "Empty",
                "None",
                "Other",
                "Unstarted",
                "Unused",
                Delimiters.SecondaryDelimiter,
                Delimiters.InternalDelimiter,
                Delimiters.ElementDelimiter,
                Delimiters.NameDelimiter,
                Delimiters.PronounDelimiter,
                Delimiters.DimensionalDelimiter,
                Delimiters.DimensionalTerminator,
            };
            ReservedWordMessage = string.Format(CultureInfo.InvariantCulture, Resources.ErrorReservedWord,
                                                string.Join(", ", ReservedWorldList));

            // This comparison forces the Parquet assembly to load.
            if (string.IsNullOrEmpty(Parquet.AssemblyInfo.LibraryVersion))
            {
                Logger.Log(LogLevel.Fatal, Resources.ErrorAccessingParquet,
                           new InvalidOperationException(Resources.ErrorAccessingParquet));
            }
            else
            {
                TypeNamesWithoutGraphics = new List<string> { "Interaction", "Region", "Script" };
                GraphicalAssetPaths = AppDomain.CurrentDomain.GetAssemblies()
                                               .Where(myassembly => string.Equals(myassembly.GetName().Name,
                                                                                  "Parquet",
                                                                                  StringComparison.OrdinalIgnoreCase))
                                               .SelectMany(myassembly => myassembly.GetExportedTypes())
                                               .Where(type => typeof(Model).IsAssignableFrom(type)
                                                           && !type.IsInterface
                                                           && !type.IsAbstract
                                                           && !TypeNamesWithoutGraphics
                                                                .Any(name => type.Name
                                                                                 .Contains(name,
                                                                                           StringComparison.OrdinalIgnoreCase)))
                                               .ToDictionary(type => All.GetIDRangeForType(type),
                                                             type => Path.Combine(GraphicsFolderName,
                                                                                  type.Name
                                                                                      .Replace("Model", "s",
                                                                                               StringComparison.OrdinalIgnoreCase)
                                                                                      .Replace("Recipe", "Recipes",
                                                                                               StringComparison.OrdinalIgnoreCase)));
            }
        }
        #endregion

        #region Validation Routines
        /// <summary>
        /// Validates that text is not one of the words reserved by Parquet's serialization routines.
        /// </summary>
        /// <param name="newText">The text to validate.</param>
        /// <returns><c>True</c> if the text is a reserved word, <c>false</c> otherwise.</returns>
        internal static bool TextIsReserved(string newText)
            => ReservedWorldList
               .Any(reservedWord => 0 == string.Compare(newText, reservedWord, comparisonType: StringComparison.OrdinalIgnoreCase));

        /// <summary>
        /// Replaces all whitespace in the given text with the ASCII space character.
        /// This will remove unicode whitespace as well as tabs and ends-of-line.
        /// </summary>
        /// <param name="inText">The <see cref="string"/> to normalize.</param>
        /// <returns>The normalized <see cref="string"/>.</returns>
        internal static string NormalizeWhitespace(string inText)
        {
            if (string.IsNullOrEmpty(inText))
            {
                return "";
            }
            else
            {
                var newTextBuilder = new StringBuilder(inText.Length);
                foreach(var c in inText)
                {
                    var normalC = char.IsWhiteSpace(c)
                        ? ' '
                        : c;
                    newTextBuilder.Append(normalC);
                }
                return newTextBuilder.ToString().Trim();
            }
        }
        #endregion

        #region Setting Up FolderBrowserDialogue
        /// <summary>
        /// Opens a dialogue allowing the user to select the folder in which to data files are stored.
        /// </summary>
        /// <remarks>
        /// Ideally this should have been handled via sub-classing, but since <see cref="FolderBrowserDialogue"/>
        /// is <c>sealed</c> we take care of it here.
        /// </remarks>
        /// <param name="inMessage">A prompt to the user, differentiating between loading existing files and creating new blank ones.</param>
        /// <returns>True if the user selected a folder.</returns>
        public static bool SelectProjectFolder(string inMessage, string inDefaultFolderName)
        {
            FolderBrowserDialogue.ShowNewFolderButton = true;
            FolderBrowserDialogue.Description = inMessage;
            FolderBrowserDialogue.RootFolder = Environment.SpecialFolder.MyComputer;
            var parentFolder = Settings.Default.DefaultDirectory switch
            {
                nameof(DefaultDirectory.Desktop) => Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                nameof(DefaultDirectory.Documents) => Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                _ => All.ProjectDirectory,
            };
            FolderBrowserDialogue.SelectedPath = Path.Combine(parentFolder, inDefaultFolderName);

            if (FolderBrowserDialogue.ShowDialog() == DialogResult.OK)
            {
                All.ProjectDirectory = FolderBrowserDialogue.SelectedPath;
                Settings.Default.MostRecentProject = FolderBrowserDialogue.SelectedPath;
                Settings.Default.Save();
                return true;
            }
            return false;
        }
        #endregion

        #region Commands
        /// <summary>
        /// Given a <see cref="ModelID"/>, determines if it has a graphical representation.
        /// </summary>
        /// <param name="inModelID">The <see cref="ModelID"/> for the <see cref="Model"/> whose graphics status sought.</param>
        /// <returns><c>true</c> if the model supports graphics, otherwise <c>false</c>.</returns>
        internal static bool IDHasGraphics(ModelID inModelID)
            => GraphicalAssetPaths.ContainsKey(All.GetIDRangeForType(inModelID));

        /// <summary>
        /// Given a <see cref="ModelID"/> for a model that has a graphical representation, returns the path to that representation's assets.
        /// </summary>
        /// <param name="inModelID">The <see cref="ModelID"/> for the <see cref="Model"/> whose graphical asset is sought.</param>
        /// <returns>The path to that asset, if any.</returns>
        internal static string GetGraphicsPathForModelID(ModelID inModelID)
            => GraphicalAssetPaths.ContainsKey(All.GetIDRangeForType(inModelID))
                ? Path.Combine(All.ProjectDirectory, GraphicalAssetPaths[All.GetIDRangeForType(inModelID)])
                : Path.Combine(All.ProjectDirectory, GraphicsFolderName);

        /// <summary>
        /// Requests that the system create the folder structure for a new project.
        /// </summary>
        internal static void CreateGraphicalAssetFolders()
        {
            foreach (var folderPath in GraphicalAssetPaths.Values)
            {
                var pathWithRoot = Path.Combine(All.ProjectDirectory, folderPath);
                if (!Directory.Exists(pathWithRoot))
                {
                    _ = Directory.CreateDirectory(pathWithRoot);
                }
            }
        }

        /// <summary>
        /// Requests that the system create blank files for a new project.
        /// </summary>
        internal static void CreateTemplateFiles()
        {
            #region Write Configuration
            PronounGroup.PutRecords(Enumerable.Empty<PronounGroup>());
            BiomeConfiguration.PutRecord();
            CraftConfiguration.PutRecord();
            InventoryConfiguration.PutRecord();
            RoomConfiguration.PutRecord();
            #endregion

            #region Write Models
            ModelCollection<GameModel>.Default.PutRecordsForType<GameModel>();
            ModelCollection<ParquetModel>.Default.PutRecordsForType<FloorModel>();
            ModelCollection<ParquetModel>.Default.PutRecordsForType<BlockModel>();
            ModelCollection<ParquetModel>.Default.PutRecordsForType<FurnishingModel>();
            ModelCollection<ParquetModel>.Default.PutRecordsForType<CollectibleModel>();
            ModelCollection<BeingModel>.Default.PutRecordsForType<CritterModel>();
            ModelCollection<BeingModel>.Default.PutRecordsForType<CharacterModel>();
            ModelCollection<BiomeRecipe>.Default.PutRecordsForType<BiomeRecipe>();
            ModelCollection<CraftingRecipe>.Default.PutRecordsForType<CraftingRecipe>();
            ModelCollection<RoomRecipe>.Default.PutRecordsForType<RoomRecipe>();
            ModelCollection<RegionModel>.Default.PutRecordsForType<RegionModel>();
            ModelCollection<ScriptModel>.Default.PutRecordsForType<ScriptModel>();
            ModelCollection<InteractionModel>.Default.PutRecordsForType<InteractionModel>();
            ModelCollection<ItemModel>.Default.PutRecordsForType<ItemModel>();
            #endregion
        }

        /// <summary>
        /// Saves game data to files in the current directory.
        /// </summary>
        /// <returns>
        /// <c>true</c> if no exceptions were caught; <c>false</c> otherwise.
        /// Note that a return value of <c>true</c> does not indicate the files were successfully saved!
        /// </returns>
        internal static bool SaveDataFiles()
            // NOTE That currently this is called from the GUI thread and could block on a slow disk or network.
            // I don't foresee this becoming an issue but it's something to keep in mind for possible optimizations.
            => All.CollectionsHaveBeenInitialized
            && All.SaveToCSVs();

        /// <summary>
        /// Loads game data from files in the current directory.
        /// </summary>
        /// <returns>
        /// <c>true</c> if no exceptions were caught; <c>false</c> otherwise.
        /// </returns>
        internal static bool LoadDataFiles()
        {
            All.Clear();
            return All.LoadFromCSVs();
        }
        #endregion
    }
}
