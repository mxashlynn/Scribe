# Scribe
A graphical editor for 2D building, crafting, and narrative sandbox games using the [Parquet](https://github.com/mxashlynn/Parquet) system.

A game built with this system offers many of the features of contemporary quest-driven building games but in a simple, top-down world and without combat.

## Roller
A command line tool for preparing, inspecting, and verifying Parquet data files.

This small tool is integrated into Scribe, and may also be used on its own.

## Version 0.4 Warning
This editor is incomplete, non-functional, and not yet ready for use.

Development milestone deadlines are tentative right now, but I'm hoping to have this usable by mid 2021.

# Parquet Game Data

Parquet stores all game data in CSV files.  These are standard and should be easy to open in most spreadsheet software.  They also ought to be fairly human-readable.

In addition to standard CSV rules, some [additional delimiters](https://github.com/mxashlynn/Parquet/blob/master/ParquetClassLibrary/Delimiters.cs) are used for particular types of data.

# Goals

While most Parquet data is easily edited in any spreadsheet program, data with nested elements can be cumbersome to work with.  The purpose of this project is to improve **map and inventory editing** workflow.

# Repository Structure

The solution contains two related projects.
Every C# namespace is located in its own folder.

- **Roller**
    - A command line tool for working with Parquet CSV files.
- **Scribe**
    - A GUI Editor for working with Parquet game definitions.
    - **ChangeHistory**, an undo/redo implementation.
    - **CustomControls**, user controls for displaying pixel art.
- **TestProject**
    - A minimal example of a Parquet dataset.  This is not a full game, just some samples used in developing Scribe and Roller.

# Requirements

To work with this repository you will need:

- [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0)
- [CSVHelper 19](https://joshclose.github.io/CsvHelper/)
- the latest version of [Parquet](https://github.com/mxashlynn/Parquet/)

# Contributors
- Design and code by [Paige Ashlynn](https://github.com/mxashlynn/).
- Some of the Roller code by [Mint Gould](https://github.com/WispyMouse).
- Special thanks to [Caidence Stone](https://github.com/caidencestone), [Ashley Hauck](https://github.com/khyperia), [Emma Maassen](https://github.com/Enichan), and Lillian Harris for help with code reviews, mathematics, algorithms, game design, and technical decisions.
