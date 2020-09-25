using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Scribe
{
    /// <summary>
    /// A form that enables the user to edit a given <see cref="ParquetClassLibrary.Crafts.StrikePanelGrid"/>.
    /// </summary>
    internal partial class StrikePatternEditorForm : Form
    {
        /// <summary>
        /// A collection of all themed <see cref="Component"/>s in the <see cref="StrikePatternEditorForm"/>.
        /// </summary>
        private readonly Dictionary<Type, List<Component>> ThemedComponents;

        #region Initialization
        /// <summary>
        /// Initialize a new <see cref="StrikePatternEditorForm"/>.
        /// </summary>
        public StrikePatternEditorForm()
        {
            InitializeComponent();
            ThemedComponents = GetThemedComponents();
        }

        /// <summary>
        /// Resets the UI each time the <see cref="Form"/> is loaded.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void StrikePatternEditorForm_Load(object sender, EventArgs e)
            => ApplyCurrentTheme();
        #endregion

        #region Cache Controls
        /// <summary>
        /// Finds all themed <see cref="Component"/>s in the <see cref="StrikePatternEditorForm"/>.
        /// </summary>
        /// <returns>A dictionary containing lists of components, organized by type.</returns>
        private Dictionary<Type, List<Component>> GetThemedComponents()
        {
            var themed = new Dictionary<Type, List<Component>>
            {
                [typeof(GroupBox)] = new List<Component>(),
                [typeof(TextBox)] = new List<Component>(),
                [typeof(Label)] = new List<Component>(),
            };
            themed[typeof(GroupBox)].AddRange(this.GetAllChildrenExactlyOfType<GroupBox>());
            themed[typeof(TextBox)].AddRange(this.GetAllChildrenExactlyOfType<TextBox>());
            themed[typeof(Label)].AddRange(this.GetAllChildrenExactlyOfType<Label>());
            return themed;
        }
        #endregion

        #region Color Theming
        /// <summary>
        /// Applies the <see cref="CurrentTheme"/> to the <see cref="StrikePatternEditorForm"/> and its <see cref="Control"/>s.
        /// </summary>
        private void ApplyCurrentTheme()
        {
            #region Apply Theme to Primary Form
            BackColor = CurrentTheme.ControlBackgroundColor;
            ForeColor = CurrentTheme.ControlForegroundColor;
            OkayButton.BackColor = CurrentTheme.ControlBackgroundColor;
            OkayButton.FlatAppearance.BorderColor = CurrentTheme.BorderColor;
            OkayButton.FlatAppearance.MouseDownBackColor = CurrentTheme.MouseDownColor;
            OkayButton.FlatAppearance.MouseOverBackColor = CurrentTheme.MouseOverColor;
            CancelButtonControl.BackColor = CurrentTheme.ControlBackgroundColor;
            CancelButtonControl.FlatAppearance.BorderColor = CurrentTheme.BorderColor;
            CancelButtonControl.FlatAppearance.MouseDownBackColor = CurrentTheme.MouseDownColor;
            CancelButtonControl.FlatAppearance.MouseOverBackColor = CurrentTheme.MouseOverColor;
            #endregion

            #region Apply Theme to Controls
            foreach (var groupBox in ThemedComponents[typeof(GroupBox)])
            {
                ((GroupBox)groupBox).BackColor = CurrentTheme.ControlBackgroundColor;
                ((GroupBox)groupBox).ForeColor = CurrentTheme.ControlForegroundColor;
            }
            foreach (var textBox in ThemedComponents[typeof(TextBox)])
            {
                ((TextBox)textBox).BackColor = CurrentTheme.ControlBackgroundWhite;
                ((TextBox)textBox).ForeColor = CurrentTheme.ControlForegroundColor;
            }
            foreach (var label in ThemedComponents[typeof(Label)])
            {
                ((Label)label).BackColor = CurrentTheme.UneditableBackgroundColor;
                ((Label)label).ForeColor = CurrentTheme.ControlForegroundColor;
            }
            #endregion
        }
        #endregion
    }
}
