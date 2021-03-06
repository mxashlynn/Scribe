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
    }
}
