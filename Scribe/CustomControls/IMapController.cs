using System;
using System.Drawing;
using System.Windows.Forms;

namespace Scribe.CustomControls
{
    /// <summary>
    /// A <see cref="Control"/> responsible for handling events generated by a <see cref="MapPictureGrid"/>.
    /// </summary>
    public interface IMapController
    {
        /// <summary>
        /// Occurs when the mouse hovers over a particular cell on the <see cref="MapPictureGrid"/>.
        /// </summary>
        /// <param name="inSender">The <see cref="MapPictureGrid"/> being hovered over.</param>
        /// <param name="inEventArguments">Arguments from the original event.</param>
        /// <param name="gridRestingLocation">The grid coordinates of the cell being hovered over.</param>
        /// <param name="screenRestingLocation">The screen coordinates of the cell being hovered over.</param>
        void MapHover(object inSender, EventArgs inEventArguments, Point gridRestingLocation, Point screenRestingLocation);

        /// <summary>
        /// Occurs when the is released over the <see cref="MapPictureGrid"/>.
        /// </summary>
        /// <param name="inSender">The <see cref="MapPictureGrid"/> being hovered over.</param>
        /// <param name="inMouseArguments">Arguments from the original event.</param>
        /// <param name="clickStartLocation">The grid coordinates of the cell over which the click began.</param>
        /// <param name="clickEndLocation">The grid coordinates of the cell over which the click ended.</param>
        void MapUp(object inSender, MouseEventArgs inMouseArguments, Point clickStartLocation, Point clickEndLocation);
    }
}
