using System.Collections.Generic;
using System.Windows.Forms;

namespace Scribe
{
    /// <summary>
    /// Extension methods for <see cref="Dictionary{K,V}"/>.
    /// </summary>
    internal static class DictionaryExtensions
    {
        /// <summary>
        /// Adds a given sequence of controls to the caching dictionary, using their Text property.
        /// </summary>
        /// <param name="inDictionary">The cache dictionary.</param>
        /// <param name="inControls">The control being cached.</param>
        public static void CacheControlsWithText(this Dictionary<Control, object> inDictionary, IEnumerable<Control> inControls)
        {
            foreach (var control in inControls)
            {
                inDictionary[control] = control.Text;
            }
        }

        /// <summary>
        /// Adds a given sequence of controls to the caching dictionary, using their Checked property.
        /// </summary>
        /// <param name="inDictionary">The cache dictionary.</param>
        /// <param name="inControls">The control being cached.</param>
        public static void CacheCheckBoxes(this Dictionary<Control, object> inDictionary, IEnumerable<Control> inControls)
        {
            foreach (var control in inControls)
            {
                inDictionary[control] = ((CheckBox)control).Checked;
            }
        }
    }
}
