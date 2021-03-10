using Parquet;
using Scribe.Forms;

namespace Scribe
{
    /// <summary>
    /// All <see cref="ModelTag"/>s defined by Scribe.
    /// </summary>
    internal static class ScribeTags
    {
        /// <summary>Used by <see cref="WorldLayoutForm"/> to determine where to begin constructing the world graph.</summary>
        internal static readonly ModelTag WorldCenter = "Scribe:WorldCenter";
    }
}
