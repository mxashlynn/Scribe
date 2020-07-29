using System.Windows.Forms;

namespace Scribe
{
    /// <summary>
    /// A modal form that enables the user to edit a given <see cref="ParquetClassLibrary.Items.Inventory"/>.
    /// </summary>
    public partial class InventoryEditorForm : Form
    {
        /// <summary>
        /// Initialize a new <see cref="InventoryEditorForm"/>.
        /// </summary>
        public InventoryEditorForm()
            => InitializeComponent();
    }
}
