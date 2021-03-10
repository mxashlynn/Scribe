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
    internal class RegionModelForLayoutTool : RegionModel
    {
        #region Characteristics
        /// <summary>
        /// Provides a <see cref="ListControl.DisplayMember"/> appropriate for the <see cref="WorldLayoutForm"/>.
        /// </summary>
        internal string LayoutToolName
            => $"({ID}) {Name} {(Tags.Contains(ScribeTags.WorldCenter) ? "🟡" : "")}";
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="RegionModelForLayoutTool"/> class.
        /// </summary>
        /// <inheritdoc/>
        internal RegionModelForLayoutTool(ModelID inID, string inName, string inDescription, string inComment,
                                          IEnumerable<ModelTag> inTags = null, string inBackgroundColor = "#FFFFFFFF",
                                          ModelID? inRegionToTheNorth = null, ModelID? inRegionToTheEast = null,
                                          ModelID? inRegionToTheSouth = null, ModelID? inRegionToTheWest = null,
                                          ModelID? inRegionAbove = null, ModelID? inRegionBelow = null)
            : base(inID, inName, inDescription, inComment, inTags, inBackgroundColor, inRegionToTheNorth,
                   inRegionToTheEast, inRegionToTheSouth, inRegionToTheWest, inRegionAbove, inRegionBelow)
        { }
        #endregion
    }
}
