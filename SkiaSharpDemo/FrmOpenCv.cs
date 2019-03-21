using Cbs.Aero;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Windows.Forms;
using Vanara.PInvoke;
using static Vanara.PInvoke.DwmApi;
using static Vanara.PInvoke.User32_Gdi;

namespace SkiaSharpDemo
{
    public partial class FrmOpenCv : Form
    {
        public FrmOpenCv()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileFullName = openFileDialog1.FileName;
                VideoCapture capture = new VideoCapture(fileFullName);

                int sleepTime = (int)Math.Round(1000 / capture.Fps);

                //using (Window window = new Window("capture"))
                using (Mat image = new Mat()) // Frame image buffer
                {
                    // When the movie playback reaches end, Mat.data becomes NULL.
                    while (true)
                    {
                        capture.Read(image); // same as cvQueryFrame
                        if (image.Empty())
                        {
                            break;
                        }
                        var bmp = BitmapConverter.ToBitmap(image);
                        BackgroundImage?.Dispose();
                        BackgroundImage = bmp;
                        //window.ShowImage(image);
                        Cv2.WaitKey(sleepTime);
                    }
                }
            }
        }
    }
}
