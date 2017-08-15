using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private FilterInfoCollection Devices;
        private VideoCaptureDevice ImageDevice;

        private void Form1_Load(object sender, EventArgs e)
        {
            Devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach(FilterInfo dev in Devices)
            {
                WebcamsBox.Items.Add(dev.Name);
            }
            WebcamsBox.SelectedIndex = 0;
            ImageDevice = new VideoCaptureDevice();

        }

        private void OnOffButton_Click(object sender, EventArgs e)
        {
            if(ImageDevice.IsRunning)
            {
                ImageDevice.Stop();
                VideoBox.Image = null;
                VideoBox.Invalidate();
            }
            else
            {
                ImageDevice = new VideoCaptureDevice(Devices[WebcamsBox.SelectedIndex].MonikerString);

                ImageDevice.NewFrame += new NewFrameEventHandler(ImageDevice_NewFrame);
                ImageDevice.Start();
            }
        }

        private void ImageDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap picture = (Bitmap)eventArgs.Frame.Clone();
            VideoBox.Image = picture;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(ImageDevice.IsRunning)
            {
                ImageDevice.Stop();
            }
        }

        private void CaptureButton_Click(object sender, EventArgs e)
        {
            VideoBox.Image.Save(PicName.Text, ImageFormat.Bmp);
        }
    }
}
