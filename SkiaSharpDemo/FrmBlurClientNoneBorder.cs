using Cbs.Aero;
using System;
using System.Drawing;
using System.Windows.Forms;
using static Vanara.PInvoke.DwmApi;

namespace SkiaSharpDemo
{
    public partial class FrmBlurClientNoneBorder : Form
    {
        public FrmBlurClientNoneBorder()
        {
            InitializeComponent();
        }

        private void FrmBlurClientNoneBorder_Load(object sender, EventArgs e)
        {
            if (AeroHelper.DwmIsCompositionEnabled())
            {
                var hind = new DWM_BLURBEHIND
                {
                    dwFlags = DWM_BLURBEHIND_Mask.DWM_BB_ENABLE | DWM_BLURBEHIND_Mask.DWM_BB_BLURREGION | DWM_BLURBEHIND_Mask.DWM_BB_TRANSITIONONMAXIMIZED,
                    fEnable = true,
                    //hRgnBlur = new HRGN(),
                    TransitionOnMaximized = true,
                };
                DwmEnableBlurBehindWindow(Handle, hind);
            }
        }

        private void FrmBlurClientNoneBorder_Paint(object sender, PaintEventArgs e)
        {
            using (var g = e.Graphics)
            {
                g.DrawRectangle(Pens.White, 0, 0, Width - 1, Height - 1);
            }
        }
    }
}
