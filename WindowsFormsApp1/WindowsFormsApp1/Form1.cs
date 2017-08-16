using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging.Filters;
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

        // Criando o filtro grayscale (BT709)
        Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);

        bool gray = false;
        //bool compareMode = false;

        int maxWidth = 400, maxHeight = 200;

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
                RefImage.Image = null;
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
                VideoBox.Image = ScaleImage(grayImage, maxWidth, maxHeight);
            }
            else
            {
                VideoBox.Image = ScaleImage(picture, maxWidth, maxHeight);  
            }
                  
        }

        private void ImageDevice_Comparing(object sender, NewFrameEventArgs eventArgs)
        {
            
            Bitmap grayImage = ScaleImage(filter.Apply((Bitmap)eventArgs.Frame.Clone()), maxWidth, maxHeight);
            Bitmap reference = new Bitmap(ComparePic.Text);
            reference = ScaleImage(filter.Apply(reference), maxWidth, maxHeight);
            Bitmap picToShow = new Bitmap(reference.Width, reference.Height);
            Color pixelColorRef, pixelColor, newColor;


            for (int x = 0; x < reference.Width; x++)
            {
                for (int y = 0; y < reference.Height; y++)
                {
                    pixelColorRef = reference.GetPixel(x, y);
                    pixelColor = grayImage.GetPixel(x, y);
                    newColor = Color.FromArgb(Math.Abs(pixelColorRef.R - pixelColor.R), 
                        Math.Abs(pixelColorRef.G - pixelColor.G), Math.Abs(pixelColorRef.B - pixelColor.B));

                    picToShow.SetPixel(x, y, newColor);
                }
            }
            VideoBox.Image = picToShow;
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
            ComparePic.Text = PicName.Text;
        }

        private void GrayscaleButton_Click(object sender, EventArgs e)
        {
            gray = !gray;
        }

        private void CompButton_Click(object sender, EventArgs e)
        {

            if (ImageDevice.IsRunning)
            {
                
                RefImage.Image = ScaleImage(new Bitmap(ComparePic.Text), maxWidth, maxHeight);
                ImageDevice.Stop();
                VideoBox.Image = null;
                ImageDevice = new VideoCaptureDevice(Devices[WebcamsBox.SelectedIndex].MonikerString);
                ImageDevice.NewFrame += new NewFrameEventHandler(ImageDevice_Comparing);
                ImageDevice.Start();

            }
           
            
            
            
        }
        static public Bitmap ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            Bitmap bmp = new Bitmap(newImage);

            return bmp;
        }
    }
}
