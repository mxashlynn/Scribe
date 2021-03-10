using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Parquet;
using Parquet.Regions;
using Scribe.Forms;

namespace Scribe
{
    /// <summary>
    /// Wrapper class for <see cref="RegionModel"/> that provides a custom <see cref="ListControl.DisplayMember"/>.
    /// </summary>
    internal class RegionModelForLayoutTool
    {
        #region Characteristics
        /// <summary>The <see cref="RegionModel"/> being worked with.</summary>
        internal IMutableRegionModel Region { get; }

        /// <summary>
        /// Provides a <see cref="ListControl.DisplayMember"/> appropriate for the <see cref="WorldLayoutForm"/>.
        /// </summary>
        internal string LayoutToolName
            => $"({Region.ID}) {Region.Name} {(Region.Tags.Contains(ScribeTags.WorldCenter) ? "🟡" : "")}";
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="RegionModelForLayoutTool"/> class.
        /// </summary>
        /// <inheritdoc/>
        internal RegionModelForLayoutTool(IMutableRegionModel inRegion)
            => Region = inRegion;
        #endregion
    }
}
