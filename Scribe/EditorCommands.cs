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
    }
}
