using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Scribe
{
    /// <summary>
    /// Extension methods for <see cref="ToolStripItemCollection"/>.
    /// </summary>
    internal static class ToolStripItemCollectionExtensions
    {
        /// <summary>
        /// Finds all contained <see cref="ToolStripItem"/>s recursively.
        /// </summary>
        /// <param name="inCollection">The collection whose contents are sought.</param>
        /// <returns>A list of controls.</returns>
        public static IEnumerable<ToolStripItem> GetAllChildren(this ToolStripItemCollection inCollection)
        {
            var children = inCollection.OfType<ToolStripItem>();
            return children.OfType<ToolStripDropDownItem>()
                           .SelectMany(dropDownItem => dropDownItem.DropDownItems.GetAllChildren())
                           .Concat(children);
        }
    }
}
