using System.Drawing;

namespace Scribe
{
    /// <summary>
    /// Provides the standard <see cref="Parquet"/> color palette.
    /// </summary>
    public static class ParquetPalette
    {
        #region Tints
        /// <summary>A tint of <see cref="Numbing"/> suitable for use in UI backgrounds.</summary>
        public static Color NumbingPastel { get; } = ColorTranslator.FromHtml("#A9ECFC");

        /// <summary>A tint of <see cref="Fresh"/> suitable for use in UI backgrounds.</summary>
        public static Color FreshPastel { get; } = ColorTranslator.FromHtml("#B8FDEC");

        /// <summary>A tint of <see cref="Astringent"/> suitable for use in UI backgrounds.</summary>
        public static Color AstringentPastel { get; } = ColorTranslator.FromHtml("#E0FCCD");

        /// <summary>A tint of <see cref="Sour"/> suitable for use in UI backgrounds.</summary>
        public static Color SourPastel { get; } = ColorTranslator.FromHtml("#FCFAD1");

        /// <summary>A tint of <see cref="Savoury"/> suitable for use in UI backgrounds.</summary>
        public static Color SavouryPastel { get; } = ColorTranslator.FromHtml("#FAE2B7");

        /// <summary>A tint of <see cref="Sweet"/> suitable for use in UI backgrounds.</summary>
        public static Color SweetPastel { get; } = ColorTranslator.FromHtml("#FDD8E2");

        /// <summary>A tint of <see cref="Pungent"/> suitable for use in UI backgrounds.</summary>
        public static Color PungentPastel { get; } = ColorTranslator.FromHtml("#FDCAEB");

        /// <summary>A tint of <see cref="Chemical"/> suitable for use in UI backgrounds.</summary>
        public static Color ChemicalPastel { get; } = ColorTranslator.FromHtml("#E1CBF8");

        /// <summary>A tint of <see cref="Bitter"/> suitable for use in UI backgrounds.</summary>
        public static Color BitterPastel { get; } = ColorTranslator.FromHtml("#FCD6B4");

        /// <summary>A tint of <see cref="Bland"/> suitable for use in UI backgrounds.</summary>
        public static Color BlandPastel { get; } = ColorTranslator.FromHtml("#FFEACE");

        /// <summary>A tint of <see cref="Metallic"/> suitable for use in UI backgrounds.</summary>
        public static Color MetallicPastel { get; } = ColorTranslator.FromHtml("#C6D5DB");

        /// <summary>A tint of <see cref="Salty"/> suitable for use in UI backgrounds.</summary>
        public static Color SaltyPastel { get; } = ColorTranslator.FromHtml("#E8E8E8");
        #endregion

        #region Tones
        /// <summary>A primary <see cref="Parquet"/> color associated with a flavor.  Its tint is <see cref="NumbingPastel"/> and its shade is <see cref="Moist"/>.</summary>
        public static Color Numbing { get; } = ColorTranslator.FromHtml("#01CDFC");

        /// <summary>A primary <see cref="Parquet"/> color associated with a flavor.  Its tint is <see cref="FreshPastel"/> and its shade is <see cref="Fizzy"/>.</summary>
        public static Color Fresh { get; } = ColorTranslator.FromHtml("#00EDB3");

        /// <summary>A primary <see cref="Parquet"/> color associated with a flavor.  Its tint is <see cref="AstringentPastel"/> and its shade is <see cref="Musty"/>.</summary>
        public static Color Astringent { get; } = ColorTranslator.FromHtml("#B6F98A");

        /// <summary>A primary <see cref="Parquet"/> color associated with a flavor.  Its tint is <see cref="SourPastel"/> and its shade is <see cref="Sharp"/>.</summary>
        public static Color Sour { get; } = ColorTranslator.FromHtml("#FFFB96");

        /// <summary>A primary <see cref="Parquet"/> color associated with a flavor.  Its tint is <see cref="SavouryPastel"/> and its shade is <see cref="Zingy"/>.</summary>
        public static Color Savoury { get; } = ColorTranslator.FromHtml("#FBAE61");

        /// <summary>A primary <see cref="Parquet"/> color associated with a flavor.  Its tint is <see cref="SweetPastel"/> and its shade is <see cref="Cloying"/>.</summary>
        public static Color Sweet { get; } = ColorTranslator.FromHtml("#FCA6BE");

        /// <summary>A primary <see cref="Parquet"/> color associated with a flavor.  Its tint is <see cref="PungentPastel"/> and its shade is <see cref="ExtraBold"/>.</summary>
        public static Color Pungent { get; } = ColorTranslator.FromHtml("#FF71CC");

        /// <summary>A primary <see cref="Parquet"/> color associated with a flavor.  Its tint is <see cref="ChemicalPastel"/> and its shade is <see cref="Floral"/>.</summary>
        public static Color Chemical { get; } = ColorTranslator.FromHtml("#C48AFF");

        /// <summary>A primary <see cref="Parquet"/> color associated with a flavor.  Its tint is <see cref="BitterPastel"/> and its shade is <see cref="Nutty"/>.</summary>
        public static Color Bitter { get; } = ColorTranslator.FromHtml("#DCAD83");

        /// <summary>A primary <see cref="Parquet"/> color associated with a flavor.  Its tint is <see cref="BlandPastel"/> and its shade is <see cref="Dry"/>.</summary>
        public static Color Bland { get; } = ColorTranslator.FromHtml("#DBBF9A");

        /// <summary>A primary <see cref="Parquet"/> color associated with a flavor.  Its tint is <see cref="MetallicPastel"/> and its shade is <see cref="Waxy"/>.</summary>
        public static Color Metallic { get; } = ColorTranslator.FromHtml("#97AFB9");

        /// <summary>A primary <see cref="Parquet"/> color associated with a flavor.  Its tint is <see cref="SaltyPastel"/> and its shade is <see cref="Smokey"/>.</summary>
        public static Color Salty { get; } = ColorTranslator.FromHtml("#BCBCBC");
        #endregion

        #region Shades
        /// <summary>A shade of <see cref="Numbing"/> suitable for tile drawing.</summary>
        public static Color Moist { get; } = ColorTranslator.FromHtml("#1256A9");

        /// <summary>A shade of <see cref="Fresh"/> suitable for tile drawing.</summary>
        public static Color Fizzy { get; } = ColorTranslator.FromHtml("#00809B");

        /// <summary>A shade of <see cref="Astringent"/> suitable for tile drawing.</summary>
        public static Color Musty { get; } = ColorTranslator.FromHtml("#00715C");

        /// <summary>A shade of <see cref="Sour"/> suitable for tile drawing.</summary>
        public static Color Sharp { get; } = ColorTranslator.FromHtml("#EED44B");

        /// <summary>A shade of <see cref="Savoury"/> suitable for tile drawing.</summary>
        public static Color Zingy { get; } = ColorTranslator.FromHtml("#DF7126");

        /// <summary>A shade of <see cref="Sweet"/> suitable for tile drawing.</summary>
        public static Color Cloying { get; } = ColorTranslator.FromHtml("#E13B3B");

        /// <summary>A shade of <see cref="Pungent"/> suitable for tile drawing.</summary>
        /// <remarks>Bold enough to bulldog your tastebuds and hogtie your tongue!</remarks>
        public static Color ExtraBold { get; } = ColorTranslator.FromHtml("#AC276C");

        /// <summary>A shade of <see cref="Chemical"/> suitable for tile drawing.</summary>
        public static Color Floral { get; } = ColorTranslator.FromHtml("#6637A4");

        /// <summary>A shade of <see cref="Bitter"/> suitable for tile drawing.</summary>
        public static Color Nutty { get; } = ColorTranslator.FromHtml("#753D19");

        /// <summary>A shade of <see cref="Bland"/> suitable for tile drawing.</summary>
        public static Color Dry { get; } = ColorTranslator.FromHtml("#8F7159");

        /// <summary>A shade of <see cref="Metallic"/> suitable for tile drawing.</summary>
        public static Color Waxy { get; } = ColorTranslator.FromHtml("#344A53");

        /// <summary>A shade of <see cref="Salty"/> suitable for use tile drawing.</summary>
        public static Color Smokey { get; } = ColorTranslator.FromHtml("#747474");
        #endregion

        #region Special Purpose
        /// <summary>Almost <see cref="Color.White"/>, suitable for use as a UI background color.</summary>
        public static Color Chalky { get; } = ColorTranslator.FromHtml("#FCFCFC");

        /// <summary>A <see cref="Parquet"/> color whose history is as complex as its flavor.</summary>
        public static Color Myrcene { get; } = ColorTranslator.FromHtml("#4632A8");

        /// <summary>Almost <see cref="Color.Black"/>, suitable for use as a UI text color.</summary>
        public static Color Burnt { get; } = ColorTranslator.FromHtml("#0C0C0C");

        #endregion

        #region Utilities
        /// <summary>
        /// Given the name of a <see cref="Color"/> from the <see cref="ParquetPalette"/>, returns that color.
        /// </summary>
        /// <param name="inName">The name of the color sought.</param>
        /// <returns>If the name is a color from the <see cref="ParquetPalette"/>, the color whose name it is; otherwise, <see cref="Color.Magenta"/>.</returns>
        public static Color ColorFromName(string inName)
            => inName switch
            {
                nameof(NumbingPastel) => NumbingPastel,
                nameof(FreshPastel) => FreshPastel,
                nameof(AstringentPastel) => AstringentPastel,
                nameof(SourPastel) => SourPastel,
                nameof(SavouryPastel) => SavouryPastel,
                nameof(SweetPastel) => SweetPastel,
                nameof(PungentPastel) => PungentPastel,
                nameof(ChemicalPastel) => ChemicalPastel,
                nameof(BitterPastel) => BitterPastel,
                nameof(BlandPastel) => BlandPastel,
                nameof(MetallicPastel) => MetallicPastel,
                nameof(SaltyPastel) => SaltyPastel,
                nameof(Numbing) => Numbing,
                nameof(Fresh) => Fresh,
                nameof(Astringent) => Astringent,
                nameof(Sour) => Sour,
                nameof(Savoury) => Savoury,
                nameof(Sweet) => Sweet,
                nameof(Pungent) => Pungent,
                nameof(Chemical) => Chemical,
                nameof(Bitter) => Bitter,
                nameof(Bland) => Metallic,
                nameof(Metallic) => Metallic,
                nameof(Salty) => Salty,
                nameof(Moist) => Moist,
                nameof(Fizzy) => Fizzy,
                nameof(Musty) => Musty,
                nameof(Sharp) => Sharp,
                nameof(Zingy) => Zingy,
                nameof(Cloying) => Cloying,
                nameof(ExtraBold) => ExtraBold,
                nameof(Floral) => Floral,
                nameof(Nutty) => Nutty,
                nameof(Dry) => Dry,
                nameof(Waxy) => Waxy,
                nameof(Smokey) => Smokey,
                nameof(Chalky) => Chalky,
                nameof(Myrcene) => Myrcene,
                nameof(Burnt) => Burnt,
                _ => LoggerExtension.DefaultWithUnknownColorLog(inName, Color.Magenta),
            };
        #endregion
    }
}
