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
        /// Finds all child controls of the given type and not of a subclass of that type.
        /// </summary>
        /// <typeparam name="T">The type of child control sought.</typeparam>
        /// <param name="inControl">The control whose children should be examined.</param>
        /// <returns>A list of matching controls, if any.</returns>
        public static IEnumerable<T> GetAllChildrenExactlyOfType<T>(this Control inControl)
            where T : Control
            => inControl.GetAllChildren()
                        .OfType<T>()
                        .Where(control => !control.GetType()
                                                  .IsSubclassOf(typeof(T)));

        /// <summary>
        /// Finds all child controls.
        /// </summary>
        /// <param name="inControl">The control whose children should be examined.</param>
        /// <returns>A list of controls.</returns>
        public static IEnumerable<Control> GetAllChildren(this Control inControl)
        {
            var children = inControl.Controls.Cast<Control>();
            return children.SelectMany(child => child.GetAllChildren())
                           .Concat(children);
        }
    }
}
