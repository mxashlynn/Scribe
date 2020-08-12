using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ParquetClassLibrary;
using ParquetClassLibrary.Beings;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Crafts;
using ParquetClassLibrary.Games;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Rooms;
using ParquetClassLibrary.Scripts;
using Scribe.Properties;

namespace Scribe
{
    /// <summary>
    /// Controls interaction with the library.
    /// </summary>
    internal static class EditorCommands
    {
        /// <summary>Children of the <see cref="Model"/> class that do not have a graphical representation.</summary>
        private static readonly List<string> TypeNamesWithoutGraphics;

        /// <summary>Children of the <see cref="Model"/> class that have a graphical representation, and the path to those assets.</summary>
        private static readonly Dictionary<Type, string> GraphicalAssetPaths;

        /// <summary>Name of the folder under which all graphics are stored.</summary>
        private const string GraphicsFolderName = "Graphics";

        #region Initialization
        /// <summary>
        /// Initializes <see cref="EditorCommands"/> asset collections.
        /// </summary>
        static EditorCommands()
        {
            // This comparison forces the Parquet assembly to load.
            if (string.IsNullOrEmpty(ParquetClassLibrary.AssemblyInfo.LibraryVersion))
            {
                MessageBox.Show(Resources.ErrorAccessingParquet, Resources.CaptionAccessingParquetError);
            }
            else
            {
                TypeNamesWithoutGraphics = new List<string> { "Interaction", "Map", "Script" };
                GraphicalAssetPaths = AppDomain.CurrentDomain.GetAssemblies()
                                                 .Where(myassembly => string.Equals(myassembly.GetName().Name, "Parquet"))
                                                 .SelectMany(myassembly => myassembly.GetExportedTypes())
                                                 .Where(type => typeof(Model).IsAssignableFrom(type)
                                                             && !type.IsInterface
                                                             && !type.IsAbstract
                                                             && !TypeNamesWithoutGraphics.Any(name => type.Name.Contains(name)))
                                                 .ToDictionary(type => type,
                                                               type => Path.Combine(GraphicsFolderName, type.Name.Replace("Model", "s")
                                                                                                         .Replace("Recipe", "Recipes")));
            }
        }
        #endregion

        #region Commands
        /// <summary>
        /// Given a child of the <see cref="Model"/> class that has a graphical representation, returns the path to that assets.
        /// </summary>
        /// <param name="in_model">The model whose graphical asset is sought.</param>
        /// <returns>The path to that asset, if any.</returns>
        internal static string GetGraphicsPathForModel(Model in_model)
            => GraphicalAssetPaths.ContainsKey(in_model.GetType())
                ? Path.Combine(All.ProjectDirectory, GraphicalAssetPaths[in_model.GetType()])
                : Path.Combine(All.ProjectDirectory, GraphicsFolderName);

        /// <summary>
        /// Attempts to create new, blank game data files in the current folder.
        /// </summary>
        /// <returns><c>true</c> if the files were successfully created; otherwise, <c>false</c>.</returns>
        internal static bool CreateTemplatesInProjectFolder()
        {
            while (Directory.GetFiles(All.ProjectDirectory).Length > 0)
            {
                // Loop here to allow the user to empty the given directory if desired.
                if (MessageBox.Show(Resources.ErrorFolderNotEmpty,
                                    Resources.CaptionFolderNotEmptyError,
                                    MessageBoxButtons.RetryCancel,
                                    MessageBoxIcon.Error) == DialogResult.Cancel)
                {
                    // If they cancel, simply abort.
                    return false;
                }
            }

            #region Create the Asset Folders
            foreach(var folderPath in GraphicalAssetPaths.Values)
            {
                var pathWithRoot = Path.Combine(All.ProjectDirectory, folderPath);
                if (!Directory.Exists(pathWithRoot))
                {
                    Directory.CreateDirectory(pathWithRoot);
                }
            }
            #endregion

            #region Create the Templates
            PronounGroup.PutRecords(Enumerable.Empty<PronounGroup>());
            BiomeConfiguration.PutRecord();
            CraftConfiguration.PutRecord();
            RoomConfiguration.PutRecord();

            ModelCollection<GameModel>.Default.PutRecordsForType<GameModel>();
            ModelCollection<BeingModel>.Default.PutRecordsForType<CritterModel>();
            ModelCollection<BeingModel>.Default.PutRecordsForType<CharacterModel>();
            ModelCollection<BiomeModel>.Default.PutRecordsForType<BiomeModel>();
            ModelCollection<CraftingRecipe>.Default.PutRecordsForType<CraftingRecipe>();
            ModelCollection<InteractionModel>.Default.PutRecordsForType<InteractionModel>();
            ModelCollection<MapModel>.Default.PutRecordsForType<MapChunk>();
            ModelCollection<MapModel>.Default.PutRecordsForType<MapRegionSketch>();
            ModelCollection<MapModel>.Default.PutRecordsForType<MapRegion>();
            ModelCollection<ParquetModel>.Default.PutRecordsForType<FloorModel>();
            ModelCollection<ParquetModel>.Default.PutRecordsForType<BlockModel>();
            ModelCollection<ParquetModel>.Default.PutRecordsForType<FurnishingModel>();
            ModelCollection<ParquetModel>.Default.PutRecordsForType<CollectibleModel>();
            ModelCollection<RoomRecipe>.Default.PutRecordsForType<RoomRecipe>();
            ModelCollection<ScriptModel>.Default.PutRecordsForType<ScriptModel>();
            ModelCollection<ItemModel>.Default.PutRecordsForType<ItemModel>();
            #endregion

            return true;
        }

        /// <summary>
        /// Loads game data from files in the current directory.
        /// </summary>
        // TODO This should probably let the user know if a file was missing or corrupt.
        internal static void LoadDataFiles()
            => All.LoadFromCSVs();
        #endregion
    }
}
