using System.Windows.Forms;

namespace Scribe
{
    /// <summary>
    /// Wrapper class for <see cref="TextBox"/>es and <see cref="ComboBox"/>es.
    /// </summary>
    internal class EditableBox
    {
        /// <summary>The <see cref="TextBox"/> contained, if any.</summary>
        private readonly TextBox EditableTextBox;

        /// <summary>The <see cref="ComboBox"/> contained, if any.</summary>
        private readonly ComboBox EditableComboBox;

        /// <summary>
        /// <c>true</c> if this <see cref="EditableBox"/> contains a <see cref="TextBox"/> or <see cref="ComboBox"/>;
        /// false otherwise.
        /// </summary>
        internal bool IsEditable
            => null != EditableTextBox
            || null != EditableComboBox;

        /// <summary>
        /// The text contained in the <see cref="EditableBox"/>.
        /// </summary>
        internal string Text
            => EditableTextBox?.Text
            ?? EditableComboBox?.Text;

        /// <summary>
        /// The text contained in the <see cref="EditableBox"/> that is currently selected.
        /// </summary>
        internal string SelectedText
            => EditableTextBox?.SelectedText
            ?? EditableComboBox?.SelectedText;

        /// <summary>
        /// Convenience constructor, instantiates a new <see cref="EditableBox"/> from the source <see cref="Control"/>
        /// for a given <see cref="ContextMenuStrip"/>.
        /// </summary>
        /// <param name="inBoxMenuContainer">The menu that contains the <see cref="EditableBox"/>.</param>
        internal EditableBox(ContextMenuStrip inBoxMenuContainer)
            : this(inBoxMenuContainer?.SourceControl)
        { }

        /// <summary>
        /// Instantiates a new <see cref="EditableBox"/>.
        /// </summary>
        /// <param name="inBox">A <see cref="TextBox"/> or <see cref="ComboBox"/>.</param>
        internal EditableBox(Control inBox)
        {
            EditableTextBox = inBox as TextBox;
            EditableComboBox = inBox as ComboBox;
        }

        /// <summary>
        /// Cuts selected text.
        /// </summary>
        internal void Cut()
        {
            if (null != EditableTextBox
                && !string.IsNullOrEmpty(EditableTextBox.SelectedText))
            {
                Clipboard.SetText(EditableTextBox.SelectedText);
                EditableTextBox.Text = EditableTextBox.Text.Replace(EditableTextBox.SelectedText, "");
            }
            else if (null != EditableComboBox
                    && !string.IsNullOrEmpty(EditableComboBox.SelectedText))
            {
                Clipboard.SetText(EditableComboBox.SelectedText);
                EditableComboBox.Text = EditableComboBox.Text.Replace(EditableComboBox.SelectedText, "");
            }
        }

        /// <summary>
        /// Copies the currently selected text.
        /// </summary>
        internal void Copy()
            => Clipboard.SetText(SelectedText);

        /// <summary>
        /// Pastes text at the insertion point.
        /// </summary>
        internal void Paste()
        {
            if (null != EditableTextBox)
            {
                EditableTextBox.Text = string.IsNullOrEmpty(SelectedText)
                    ? EditableTextBox.Text.Insert(EditableTextBox.SelectionStart, Clipboard.GetText())
                    : EditableTextBox.Text.Replace(EditableTextBox.SelectedText, Clipboard.GetText());
            }
            else if (null != EditableComboBox)
            {
                EditableComboBox.Text = string.IsNullOrEmpty(SelectedText)
                    ? EditableComboBox.Text.Insert(EditableComboBox.SelectionStart, Clipboard.GetText())
                    : EditableComboBox.Text.Replace(EditableComboBox.SelectedText, Clipboard.GetText());
            }
        }

        /// <summary>
        /// Clears all text.
        /// </summary>
        internal void ClearAll()
        {
            if (null != EditableTextBox)
            {
                EditableTextBox.Clear();
            }
            else if (null != EditableComboBox)
            {
                EditableComboBox.SelectedItem = null;
                EditableComboBox.Text = "";
            }
        }

        /// <summary>
        /// Selects all text.
        /// </summary>
        internal void SelectAll()
        {
            if (null != EditableTextBox)
            {
                EditableTextBox.SelectAll();
                EditableTextBox.Focus();
            }
            else if (null != EditableComboBox)
            {
                EditableComboBox.SelectAll();
                EditableComboBox.Focus();
            }
        }
    }
}
