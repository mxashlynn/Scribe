using System.Drawing;
using Scribe.Properties;

namespace Scribe
{
    /// <summary>
    /// Stores <see cref="Color"/> information about the current <see cref="EditorTheme"/>.
    /// </summary>
    internal static class CurrentTheme
    {
        #region Theme Colors
        public static Color ControlBackgroundWhite = SystemColors.Window;
        public static Color ControlBackgroundColor = SystemColors.Control;
        public static Color UneditableBackgroundColor = SystemColors.ControlLight;
        public static Color HighlightColor = SystemColors.Highlight;
        public static Color ControlForegroundColor = SystemColors.ControlText;
        public static Color BorderColor = Color.Empty;
        public static Color MouseDownColor = Color.Empty;
        public static Color MouseOverColor = Color.Empty;
        public static Color GamesTabColor = SystemColors.Control;
        public static Color ParquetsTabColor = SystemColors.Control;
        public static Color BeingsTabColor = SystemColors.Control;
        public static Color ItemsTabColor = SystemColors.Control;
        public static Color RecipesTabColor = SystemColors.Control;
        public static Color MapsTabColor = SystemColors.Control;
        public static Color ScriptsTabColor = SystemColors.Control;
        #endregion

        /// <summary>
        /// Assigns the colors corresponding to the current <see cref="EditorTheme"/>.
        /// </summary>
        /// <param name="inThemeToSet">Identifier for the newly-selected theme.</param>
        public static void SetUpTheme(EditorTheme inThemeToSet)
        {
            switch (inThemeToSet)
            {
                case EditorTheme.Femme:
                    ControlBackgroundWhite = Color.Snow;
                    ControlBackgroundColor = Color.MistyRose;
                    UneditableBackgroundColor = Color.Pink;
                    HighlightColor = Color.HotPink;
                    ControlForegroundColor = Color.Indigo;
                    BorderColor = Color.PaleVioletRed;
                    MouseDownColor = Color.PaleVioletRed;
                    MouseOverColor = Color.LightPink;
                    GamesTabColor = Color.MistyRose;
                    ParquetsTabColor = Color.MistyRose;
                    BeingsTabColor = Color.MistyRose;
                    ItemsTabColor = Color.MistyRose;
                    RecipesTabColor = Color.MistyRose;
                    MapsTabColor = Color.MistyRose;
                    ScriptsTabColor = Color.MistyRose;
                    break;
                case EditorTheme.Colorful:
                    ControlBackgroundWhite = Color.FloralWhite;
                    ControlBackgroundColor = Color.AntiqueWhite;
                    UneditableBackgroundColor = Color.Linen;
                    HighlightColor = Color.MediumOrchid;
                    ControlForegroundColor = Color.FromArgb(51, 0, 0);
                    BorderColor = Color.RosyBrown;
                    MouseDownColor = Color.RosyBrown;
                    MouseOverColor = Color.Wheat;
                    GamesTabColor = Color.NavajoWhite;
                    ParquetsTabColor = Color.BurlyWood;
                    BeingsTabColor = Color.LightPink;
                    ItemsTabColor = Color.PaleGoldenrod;
                    RecipesTabColor = Color.Plum;
                    MapsTabColor = Color.DarkSalmon;
                    ScriptsTabColor = Color.LightSteelBlue;
                    break;
                // EditorTheme.OSDefault:
                default:
                    ControlBackgroundWhite = SystemColors.Window;
                    ControlBackgroundColor = SystemColors.Control;
                    UneditableBackgroundColor = SystemColors.ControlLight;
                    HighlightColor = SystemColors.Highlight;
                    ControlForegroundColor = SystemColors.ControlText;
                    BorderColor = Color.Empty;
                    MouseDownColor = Color.Empty;
                    MouseOverColor = Color.Empty;
                    GamesTabColor = SystemColors.Control;
                    ParquetsTabColor = SystemColors.Control;
                    BeingsTabColor = SystemColors.Control;
                    ItemsTabColor = SystemColors.Control;
                    RecipesTabColor = SystemColors.Control;
                    MapsTabColor = SystemColors.Control;
                    ScriptsTabColor = SystemColors.Control;
                    break;
            }
        }
    }
}
