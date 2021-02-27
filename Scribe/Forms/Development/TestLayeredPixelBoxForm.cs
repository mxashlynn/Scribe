using System.Globalization;
using System.Windows.Forms;

namespace Scribe.Forms.Development
{
    public partial class TestLayeredPixelBoxForm : Form
    {
        public TestLayeredPixelBoxForm()
        {
            InitializeComponent();

            // Dynamically load the test patterns.
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(TestLayeredPixelBoxForm));
            TestLayeredPixelBox1.ImageLayers[0] = (System.Drawing.Image)resources.GetObject("TestLayeredPixelBox1.Image", CultureInfo.InvariantCulture);
            TestLayeredPixelBox1.ImageLayers[1] = (System.Drawing.Image)resources.GetObject("TestLayeredPixelBox2.Image", CultureInfo.InvariantCulture);
            TestLayeredPixelBox1.ImageLayers[2] = (System.Drawing.Image)resources.GetObject("TestLayeredPixelBox3.Image", CultureInfo.InvariantCulture);
            TestLayeredPixelBox1.ImageLayers[3] = (System.Drawing.Image)resources.GetObject("TestLayeredPixelBox4.Image", CultureInfo.InvariantCulture);
        }
    }
}
