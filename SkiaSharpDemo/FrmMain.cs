using Cbs.Aero;
using SkiaSharp;
using SkiaSharp.Views.Desktop;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Http;
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
            skCtrl.Parent = this;
            //skCtrl.BackColor = Color.FromArgb(0, Color.Red);
            //var bmp = (Bitmap)picBox.Image;
            //bmp.pix
            //new SKCanvas(new SKBitmap());
        }

        private SKBitmap bgBmp;

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
        private SKBitmap webBitmap;
        private SKBitmap resourceBitmap;
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
            //canvas.Clear(SKColors.Black.WithAlpha(150));
            //canvas.Clear(SystemColors.ControlText.ToSKColor());
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
            //var ii = new SKImageInfo(640, 480,SKColorType.Bgra8888);
            //using (var sf = SKSurface.Create(ii))
            //{
            //    SKCanvas c = sf.Canvas;
            //    c.Clear(SKColors.White);
            //    c.DrawSurface(surface, new SKPoint(0, 0));
            //}
            var txt = "Hello World";
            var txtWidth = DefPaint.MeasureText(txt);
            DefPaint.TextSize = 0.9f * info.Width * DefPaint.TextSize / txtWidth;
            var textBounds = new SKRect();
            DefPaint.MeasureText(txt, ref textBounds);
            float xText = info.Width / 2 - textBounds.MidX;
            float yText = info.Height / 2 - textBounds.MidY;

            // And draw the text
            canvas.DrawText(txt, xText, yText, DefPaint);
            if (webBitmap != null)
            {
                canvas.DrawBitmap(webBitmap, new SKRect
                {
                    Left = 50,
                    Top = 50,
                    Right = 250,
                    Bottom = 160
                });
                //canvas.DrawBitmap(webBitmap, 0, 0);
            }
            if (resourceBitmap != null)
            {
                DefPaint.Color = DefPaint.Color.WithAlpha(150);
                canvas.DrawBitmap(resourceBitmap, new SKRect
                {
                    Left = 50,
                    Top = 180,
                    Right = 250,
                    Bottom = 360
                }, DefPaint);
                DefPaint.Color = DefPaint.Color.WithAlpha(240);
            }
            //canvas.Clear(SKColors.Transparent);
            //canvas.DrawColor(SKColors.Transparent);
            //DefPaint.Color = DefPaint.Color.WithAlpha(0);
            //DefPaint.Style = SKPaintStyle.Fill;
            //canvas.DrawRect(info.Rect, DefPaint);
            //DefPaint.Color = DefPaint.Color.WithAlpha(240);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            if (AeroHelper.DwmIsCompositionEnabled())
            {
                var margins = AeroHelper.NewMargins((Width + Height) * 2);
                AeroHelper.DwmExtendFrameIntoClientArea(Handle, ref margins);
            }
            IsAnimation = true;
            await LoadWebImage();
            LoadResourceImage();
            await AnimationLoop();
        }

        private void LoadResourceImage()
        {
            var asm = GetType().Assembly;
            using (var stream = asm.GetManifestResourceStream("SkiaSharpDemo.Imgs.Koala.jpg"))
            {
                resourceBitmap = SKBitmap.Decode(stream);
            }
        }

        private async Task LoadWebImage()
        {
            try
            {
                var client = new HttpClient();
                var url = @"http://images2.qianyan.biz/qy/3/2/6/201141114385982377357.jpg";
                using (var stream = await client.GetStreamAsync(url))
                using (var mem = new MemoryStream())
                {
                    await stream.CopyToAsync(mem);
                    mem.Seek(0, SeekOrigin.Begin);
                    webBitmap = SKBitmap.Decode(mem);
                    skCtrl.Invalidate();
                }
            }
            catch (Exception)
            {
            }
        }

        private async Task AnimationLoop()
        {
            stopwatch.Start();

            while (IsAnimation)
            {
                var cycleTime = 10;
                double t = stopwatch.Elapsed.TotalSeconds % cycleTime / cycleTime;
                CurrentScale = (1 + (float)Math.Sin(2 * Math.PI * t)) / 2;
                //Invoke((Action)(() => skCtrl.Invalidate()));
                Invoke((Action)(() => Invalidate(true)));
                //Invalidate(true);
                //skCtrl.Invalidate();
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
