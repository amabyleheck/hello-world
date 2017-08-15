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
using AForge.Imaging.Filters;
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

        // Crieando o filtro grayscale (BT709)
        Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);

        bool gray = false;

        private void Form1_Load(object sender, EventArgs e)
        {

            //Encontra as câmeras disponíveis e as adiciona a comboBox 'WebcamBox'
            Devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach(FilterInfo dev in Devices)
            {
                WebcamsBox.Items.Add(dev.Name);
            }

            //Por padrão, o primeiro dispositivo da lista é selecionado
            WebcamsBox.SelectedIndex = 0;
            ImageDevice = new VideoCaptureDevice();

        }

        private void OnOffButton_Click(object sender, EventArgs e)
        {
            //Se o botão On/Off é clicado:

            //Caso o vídeo já esteja funcionando, ele é desligado
            if(ImageDevice.IsRunning)
            {
                ImageDevice.Stop();
                VideoBox.Image = null;
                VideoBox.Invalidate();
                gray = false;
            }
            //Do contrário, é ligado
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
            if (gray)
            {
                Bitmap grayImage = filter.Apply(picture);
                VideoBox.Image = grayImage;
            }
            else
            {
                VideoBox.Image = picture;  
            }
                  
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

        private void GrayscaleButton_Click(object sender, EventArgs e)
        {
            gray = !gray;
        }
    }
}
