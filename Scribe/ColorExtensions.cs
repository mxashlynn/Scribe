using System.Drawing;

namespace Scribe
{
    /// <summary>
    /// Extensions to the <see cref="Color"/> class.
    /// </summary>
    public static class ColorExtensions
    {
        /// <summary>
        /// Produces a <c>string</c> that represents the <see cref="Color"/> as a series of hexadecimal digits.
        /// </summary>
        /// <param name="inColor">The given color.</param>
        /// <returns>The color as a hex <c>string</c>.</returns>
        public static string ToHexString(this Color inColor)
            => $"#{inColor.A:X2}{inColor.R:X2}{inColor.G:X2}{inColor.B:X2}";

        /// <summary>
        /// Determines if the current color will be percieved as light or dark,
        /// and returns an appropriately visible foreground color based on this.
        /// </summary>
        /// <param name="inColor">The background color.</param>
        /// <returns><see cref="Color.White"/> if the current color is dark; otherwise <see cref="Color.Black"/>.</returns>
        public static Color ForegroundFromBackground(this Color inColor)
        {
            // Perceived lightness using the sRGB Luma method:
            float lightness = ((inColor.R * 0.2126f) +
                               (inColor.G * 0.7152f) +
                               (inColor.B * 0.0722f)) / 255;

            // Perception threshhold.
            const float threshold = 0.5f;

            return lightness > threshold
                ? Color.Black
                : Color.White;
        }
    }
}
