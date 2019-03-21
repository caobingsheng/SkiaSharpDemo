using Cbs.Aero;
using System;
using System.Windows.Forms;
using Vanara.PInvoke;
using static Vanara.PInvoke.DwmApi;
using static Vanara.PInvoke.User32_Gdi;

namespace SkiaSharpDemo
{
    public partial class FrmNoneBorderMove : Form
    {
        public FrmNoneBorderMove()
        {
            InitializeComponent();
        }

        private void FrmNoneBorderMove_Load(object sender, EventArgs e)
        {
            if (AeroHelper.DwmIsCompositionEnabled())
            {
                var hind = new DWM_BLURBEHIND
                {
                    dwFlags = DWM_BLURBEHIND_Mask.DWM_BB_ENABLE | DWM_BLURBEHIND_Mask.DWM_BB_BLURREGION | DWM_BLURBEHIND_Mask.DWM_BB_TRANSITIONONMAXIMIZED,
                    fEnable = true,
                    TransitionOnMaximized = true,
                };
                DwmEnableBlurBehindWindow(Handle, hind);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//按下的是鼠标左键  
            {
                Capture = false;//释放鼠标，使能够手动操作  
                var p = new POINTS();
                SendMessage(Handle, WindowMessage.WM_NCLBUTTONDOWN, HitTestValues.HTCAPTION, ref p);
            }
        }
    }
}
