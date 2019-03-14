using Cbs.Aero;
using SkiaSharp;
using SkiaSharp.Views.Desktop;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkiaSharpDemo
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            skCtrl.PaintSurface += SkCtrl_PaintSurface;
        }

        private SKPaint DefPaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = Color.Red.ToSKColor(),
            StrokeWidth = 25,
            IsAntialias = true,
        };
        private bool IsAnimation = false;
        private Stopwatch stopwatch = new Stopwatch();
        private float CurrentScale;

        private void SkCtrl_PaintSurface(object sender, SkiaSharp.Views.Desktop.SKPaintSurfaceEventArgs e)
        {
            //var info = e.Info;
            //var sf = e.Surface;
            //var canvas = sf.Canvas;
            //canvas.Clear();
            //canvas.DrawCircle(info.Width / 2, info.Height / 2, 100, DefPaint);
            //DefPaint.Style = SKPaintStyle.Fill;
            //DefPaint.Color = SKColors.Blue;
            //canvas.DrawCircle(info.Width / 2, info.Height / 2, 100, DefPaint);
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            float maxRadius = 0.75f * Math.Min(info.Width, info.Height) / 2;
            float minRadius = 0.25f * maxRadius;

            float xRadius = minRadius * CurrentScale + maxRadius * (1 - CurrentScale);
            float yRadius = maxRadius * CurrentScale + minRadius * (1 - CurrentScale);

            //using (SKPaint paint = new SKPaint())
            //{
            //DefPaint.Style = SKPaintStyle.Stroke;
            //DefPaint.Color = SKColors.Blue;
            //DefPaint.StrokeWidth = 50;
            //DefPaint.IsAntialias = true;
            canvas.DrawOval(info.Width / 2, info.Height / 2, xRadius, yRadius, DefPaint);

            //DefPaint.Style = SKPaintStyle.Fill;
            //DefPaint.Color = SKColors.SkyBlue;
            canvas.DrawOval(info.Width / 2, info.Height / 2, xRadius, yRadius, DefPaint);
            //}
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            if (AeroHelper.DwmIsCompositionEnabled())
            {
                var margins = AeroHelper.NewMargins((Width + Height) * 2);
                AeroHelper.DwmExtendFrameIntoClientArea(Handle, ref margins);
            }
            IsAnimation = true;
            await AnimationLoop();
        }

        private async Task AnimationLoop()
        {
            stopwatch.Start();

            while (IsAnimation)
            {
                var cycleTime = 10;
                double t = stopwatch.Elapsed.TotalSeconds % cycleTime / cycleTime;
                CurrentScale = (1 + (float)Math.Sin(2 * Math.PI * t)) / 2;
                Invoke((Action)(() => skCtrl.Invalidate()));
                await Task.Delay(TimeSpan.FromSeconds(1.0 / 30));
            }
            stopwatch.Stop();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            if (AeroHelper.DwmIsCompositionEnabled())
            {
                e.Graphics.Clear(Color.Black);
            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsAnimation = false;
        }
    }
}
