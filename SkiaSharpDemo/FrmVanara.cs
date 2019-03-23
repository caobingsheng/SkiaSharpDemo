using System.Windows.Forms;
using Vanara.Windows.Forms;

namespace SkiaSharpDemo
{
    public partial class FrmVanara : Form
    {
        //private GlassExtenderProvider glassExtenderProvider = new GlassExtenderProvider();
        public FrmVanara()
        {
            InitializeComponent();
            //glassExtenderProvider.SetGlassEnabled(this, true);
            //glassExtenderProvider.SetGlassMarginMovesForm(this,true);
            this.EnableBlurBehind(true);
        }
    }
}
