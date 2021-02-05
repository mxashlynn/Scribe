using System.Runtime.InteropServices;
using Scribe.Forms;

// Make no promises to maintain public services.
[assembly: ComVisible(false)]

namespace Scribe
{
    /// <summary>
    /// Provides assembly-wide information.
    /// </summary>
    public readonly struct AssemblyInfo
    {
        /// <summary>Describes the version of the editor.</summary>
        /// <remarks>
        /// The version has the format "{Major}.{Minor}.{Patch}.{Build}".
        /// - Major: Enhancements or fixes that break the API or its serialized data.
        /// - Minor: Enhancements that do not break the API or its serialized data.
        /// - Patch: Fixes that do not break the API or its serialized data.
        /// - Build: Procedural updates that do not imply any changes, such as when rebuilding for APK/IPA submission.
        /// </remarks>
        public static readonly string ScribeVersion = typeof(MainEditorForm).Assembly.GetName().Version.ToString();
    }
}
