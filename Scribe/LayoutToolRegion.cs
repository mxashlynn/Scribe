using System.Linq;
using Parquet;
using Parquet.Regions;
using Scribe.Forms;

namespace Scribe
{
    /// <summary>
    /// Wrapper class for <see cref="RegionModel"/> that provides a custom <see cref="object.ToString"/>.
    /// </summary>
    internal class LayoutToolRegion
    {
        #region Class Defaults
        /// <summary>Used to signal that no region is present.</summary>
        internal static readonly LayoutToolRegion None = new(
            new RegionModel(ModelID.None, nameof(None), "No region exists here.", ""));
        #endregion

        #region Characteristics
        /// <summary>The <see cref="RegionModel"/> being tracked.</summary>
        internal RegionModel Model { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="LayoutToolRegion"/> class.
        /// </summary>
        /// <param name="inRegion">A <see cref="RegionModel"/> being used by the <see cref="WorldLayoutForm"/>.</param>
        internal LayoutToolRegion(RegionModel inRegion)
            => Model = inRegion;
        #endregion

        #region Utilities
        /// <summary>
        /// Provides a <c>string</c> representation of the current instance appropriate for the <see cref="WorldLayoutForm"/>.
        /// </summary>
        public override string ToString()
            => Model.ID == ModelID.None
                ? nameof(None)
                : $"({Model.ID.ToString()[^3..]}) {Model.Name} {(Model.Tags.ContainsOrdinalIgnoreCase(WorldLayoutForm.WorldCenterTag) ? "🟡" : "")}";
        #endregion
    }
}
