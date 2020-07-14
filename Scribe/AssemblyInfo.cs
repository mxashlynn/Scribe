using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using Scribe;

// Set assembly values.
[assembly: AssemblyTitle("Scribe")]
[assembly: AssemblyDescription("An editor for Parquet-based games.")]
[assembly: AssemblyCompany("Magical Girlfriends")]
[assembly: AssemblyCopyright("2018-2020 Paige Ashlynn")]
[assembly: AssemblyProduct("Scribe")]
[assembly: AssemblyVersion(AssemblyInfo.ScribeVersion)]
[assembly: AssemblyInformationalVersion(AssemblyInfo.ScribeVersion)]
[assembly: AssemblyFileVersion(AssemblyInfo.ScribeVersion)]

// Make no promises to maintain public services.
[assembly: ComVisible(false)]

// Declare American English as the fallback language.
[assembly: NeutralResourcesLanguage("en-US")]

namespace Scribe
{
    /// <summary>
    /// Provides assembly-wide information.
    /// </summary>
    [SuppressMessage("Performance", "CA1815:Override equals and operator equals on value types",
                     Justification = "Comparing two AssemblyInfos is nonsensical.")]
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
        public const string ScribeVersion = "0.2.0.0";
    }
}
