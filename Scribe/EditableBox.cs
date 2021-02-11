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
            => EditableTextBox is not null
            || EditableComboBox is not null;

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
        /// <returns>The <see cref="TextBox"/> or <see cref="ComboBox"/> that was edited, or <c>null</c> if no edits occurred.</returns>
        internal Control Cut()
        {
            if (EditableTextBox is not null
                && !string.IsNullOrEmpty(EditableTextBox.SelectedText))
            {
                Clipboard.SetText(EditableTextBox.SelectedText);
                EditableTextBox.Text = EditableTextBox.Text.Replace(EditableTextBox.SelectedText, "");
                return EditableTextBox;
            }
            else if (EditableComboBox is not null
                    && !string.IsNullOrEmpty(EditableComboBox.SelectedText))
            {
                Clipboard.SetText(EditableComboBox.SelectedText);
                EditableComboBox.Text = EditableComboBox.Text.Replace(EditableComboBox.SelectedText, "");
                return EditableComboBox;
            }
            return null;
        }

        /// <summary>
        /// Copies the currently selected text.
        /// </summary>
        internal void Copy()
            => Clipboard.SetText(SelectedText);

        /// <summary>
        /// Pastes text at the insertion point.
        /// </summary>
        /// <returns>The <see cref="TextBox"/> or <see cref="ComboBox"/> that was edited, or <c>null</c> if no edits occurred.</returns>
        internal Control Paste()
        {
            if (EditableTextBox is not null)
            {
                EditableTextBox.Text = string.IsNullOrEmpty(SelectedText)
                    ? EditableTextBox.Text.Insert(EditableTextBox.SelectionStart, Clipboard.GetText())
                    : EditableTextBox.Text.Replace(EditableTextBox.SelectedText, Clipboard.GetText());
                return EditableTextBox;
            }
            else if (EditableComboBox is not null)
            {
                EditableComboBox.Text = string.IsNullOrEmpty(SelectedText)
                    ? EditableComboBox.Text.Insert(EditableComboBox.SelectionStart, Clipboard.GetText())
                    : EditableComboBox.Text.Replace(EditableComboBox.SelectedText, Clipboard.GetText());
                return EditableComboBox;
            }
            return null;
        }

        /// <summary>
        /// Clears all text.
        /// </summary>
        /// <returns>The <see cref="TextBox"/> or <see cref="ComboBox"/> that was edited, or <c>null</c> if no edits occurred.</returns>
        internal Control ClearAll()
        {
            if (EditableTextBox is not null)
            {
                EditableTextBox.Clear();
                return EditableTextBox;
            }
            else if (EditableComboBox is not null)
            {
                EditableComboBox.SelectedItem = null;
                EditableComboBox.Text = "";
                return EditableComboBox;
            }
            return null;
        }

        /// <summary>
        /// Selects all text.
        /// </summary>
        internal void SelectAll()
        {
            if (EditableTextBox is not null)
            {
                EditableTextBox.SelectAll();
                EditableTextBox.Focus();
            }
            else if (EditableComboBox is not null)
            {
                EditableComboBox.SelectAll();
                EditableComboBox.Focus();
            }
        }
    }
}
