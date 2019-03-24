using System.Windows.Forms;
using Vanara.PInvoke;

namespace SkiaSharpDemo
{
    public partial class FrmLayeredWindow : Form
    {
        public FrmLayeredWindow()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= (int)User32_Gdi.WindowStylesEx.WS_EX_LAYERED;
                return cp;
            }
        }

    }
}
