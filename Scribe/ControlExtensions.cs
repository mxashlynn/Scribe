using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Scribe
{
    /// <summary>
    /// Extension methods for <see cref="Windows.Forms.Control"/>.
    /// </summary>
    internal static class ControlExtensions
    {
        /// <summary>
        /// Finds all child controls of the given control of the given type.
        /// </summary>
        /// <typeparam name="T">The type of child control sought.</typeparam>
        /// <param name="inControl">The control whose children should be examined.</param>
        /// <returns>A list of matching controls, if any.</returns>
        public static IEnumerable<T> GetAllChildrenOfType<T>(this Control inControl)
            where T : Control
        {
            var controls = inControl.Controls.Cast<Control>();

            return controls.SelectMany(control => control.GetAllChildrenOfType<T>())
                           .Concat(controls)
                           .OfType<T>();
        }
    }
}
