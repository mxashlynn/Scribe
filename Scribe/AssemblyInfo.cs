using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Scribe.Forms;

// Make no promises to maintain public services.
[assembly: ComVisible(false)]

// Scribe is an API consumer, not an API provider, so CLS Compliance is not needed.
[assembly: CLSCompliant(true)]

// Windows Forms is supported only on Windows, but not all analyzers realize this.
[assembly: SupportedOSPlatform("windows")]

namespace Scribe
{
    /// <summary>
    /// Provides assembly-wide information.
    /// </summary>
    [SuppressMessage("Performance", "CA1815:Override equals and operator equals on value types",
        Justification = "Comparing two AssemblyInfos makes no sense.")]
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
