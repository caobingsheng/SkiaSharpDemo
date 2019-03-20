using Cbs.Aero;
using SkiaSharp.Views.Desktop;
using System.Drawing;
using System.Windows.Forms;

namespace SkiaSharpDemo
{
    public partial class FrmSkGl : Form
    {
        private SKGLControl glCtrl;
        public FrmSkGl()
        {
            InitializeComponent();
            glCtrl = new SKGLControl();
            glCtrl.Dock = DockStyle.Fill;
            glCtrl.BackColor = Color.Black;
            glCtrl.PaintSurface += GlCtrl_PaintSurface;
            Controls.Add(glCtrl);
        }

        private void GlCtrl_PaintSurface(object sender, SKPaintGLSurfaceEventArgs e)
        {
            var surface = e.Surface;
            var canvas = surface.Canvas;
            var surfaceWidth = e.BackendRenderTarget.Width;
            var surfaceHeight = e.BackendRenderTarget.Height;

            canvas.Clear(Color.White.ToSKColor());

            canvas.Flush();
        }

        private void FrmSkGl_Load(object sender, System.EventArgs e)
        {
            if (AeroHelper.DwmIsCompositionEnabled())
            {
                var margins = AeroHelper.NewMargins((Width + Height) * 2);
                AeroHelper.DwmExtendFrameIntoClientArea(Handle, ref margins);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            if (AeroHelper.DwmIsCompositionEnabled())
            {
                e.Graphics.Clear(Color.Black);
            }
        }
    }
}
