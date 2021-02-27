// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores",
    Justification = "Windows Forms uses underscores for callbacks.")]
[assembly: SuppressMessage("Performance", "CA1814:Prefer jagged arrays over multidimensional",
    Justification = "Parquet requires square arrays.")]
[assembly: SuppressMessage("Naming", "CA1725:Parameter names should match base declaration",
    Justification = "This rule forces poor naming choices, such as 'e' instead of 'eventData'.")]
