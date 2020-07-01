using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;

namespace EmguCv_Tutorial_05
{
    public partial class Form1 : Form
    {

        Image<Bgr, Byte> InputImage;
        Image<Gray, Byte> GrayImage;

        public Form1()
        {
            InitializeComponent();
        }

        private void Gray_Click(object sender, EventArgs e)
        {
            GrayImage = InputImage.Convert<Gray, Byte>();
            pictureBox1.Image = GrayImage.Bitmap;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            String FileName = "D:\\Visual Studio 2019 workspace\\6a.png";
            InputImage = new Image<Bgr, byte>(FileName);

            if (InputImage == null)
            {
                MessageBox.Show("Failed to Read Image....!");
                return;
            }

            imageBox1.Image = InputImage;
        }

        private void btnHisto01_Click(object sender, EventArgs e)
        {
            DenseHistogram hist = new DenseHistogram(256, new RangeF(0, 255));
            hist.Calculate(new Image<Gray, Byte>[] { InputImage[0] }, false, null);

            Mat m = new Mat();
            hist.CopyTo(m);

            histogramBox1.AddHistogram("Blue Channel Histogram", Color.Blue, m, 256, new float[] { 0, 256 });
            histogramBox1.Refresh();
        }

        private void btnHisto02_Click(object sender, EventArgs e)
        {
            DenseHistogram hist = new DenseHistogram(256, new RangeF(0, 255));
            hist.Calculate(new Image<Gray, Byte>[] { GrayImage }, false, null);

            Mat m = new Mat();
            hist.CopyTo(m);

            histogramBox2.AddHistogram("Gray Scale Histogram", Color.Blue, m, 256, new float[] { 0, 256 });
            histogramBox2.Refresh();
        }
    }
}
