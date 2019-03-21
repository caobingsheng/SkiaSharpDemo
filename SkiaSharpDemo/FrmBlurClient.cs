using System;
using System.Drawing;
using System.Windows.Forms;
using Vanara.PInvoke;
using static Vanara.PInvoke.DwmApi;

namespace SkiaSharpDemo
{
    public partial class FrmBlurClient : Form
    {
        public FrmBlurClient()
        {
            InitializeComponent();
        }

        private void FrmBlurClient_Load(object sender, EventArgs e)
        {
            var hind = new DWM_BLURBEHIND
            {
                dwFlags = DWM_BLURBEHIND_Mask.DWM_BB_ENABLE | DWM_BLURBEHIND_Mask.DWM_BB_BLURREGION | DWM_BLURBEHIND_Mask.DWM_BB_TRANSITIONONMAXIMIZED,
                fEnable = true,
                //hRgnBlur = new HRGN(),
                TransitionOnMaximized = true,
            };
            DwmEnableBlurBehindWindow(this.Handle, hind);
        }
    }
}
