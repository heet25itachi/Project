using System;
using System.Drawing;
using System.Windows.Forms;
using ZXing;


namespace barcode_generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string data = txtData.Text;

            if (string.IsNullOrWhiteSpace(data))
            {
                MessageBox.Show("Please enter data to generate the barcode.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var barcodeWriter = new BarcodeWriter
                {
                    Format = BarcodeFormat.CODE_128, 
                    Options = new ZXing.Common.EncodingOptions
                    {
                        Width = pictureBoxBarcode.Width,  
                        Height = pictureBoxBarcode.Height, 
                        Margin = 10               
                    }
                };

                Bitmap bitmap = barcodeWriter.Write(data);
                pictureBoxBarcode.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxBarcode.Image = bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating barcode: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
