using System.Drawing;
using System.Globalization;
using Parquet;
using Scribe.Properties;

namespace Scribe
{
    /// <summary>
    /// Extensions to the <see cref="Logger"/> class.
    /// </summary>
    internal static class LoggerExtension
    {
        /// <summary>
        /// Convenience method that logs a <see cref="Color"/> error and returns the given default value.
        /// </summary>
        /// <param name="inText">The value that cannot be parsed as a <see cref="Color"/>.</param>
        /// <param name="inDefaultValue">The default value to return.</param>
        /// <returns>The default value given.</returns>
        internal static string DefaultWithUnknownColorLog(string inText, string inDefaultValue)
        {
            Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.WarningUnkownColor,
                                                       inText), null);
            return inDefaultValue;
        }
    }
}
