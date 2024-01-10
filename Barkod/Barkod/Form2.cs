using barcode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Barkod
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnBarkod_Click(object sender, EventArgs e)
        {
            int Height = !string.IsNullOrEmpty(txtHeight.Text) ? int.Parse(txtHeight.Text) : 40;
            //int Width = !string.IsNullOrEmpty(txtWidth.Text) ? int.Parse(txtWidth.Text) : 60;

            Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            imgCode.Image = barcode.Draw(txtBox.Text, Height);
            imgCode.Width = imgCode.Image.Width;
            imgCode.Height = imgCode.Image.Height;

            // code name margin
            int topMarginValue = !string.IsNullOrEmpty(txtMargin.Text) ? int.Parse(txtMargin.Text) : Height; // Üst marj miktarı            
            lblProductCode.Top = imgCode.Top + topMarginValue;
            lblProductCode.Text = txtBox.Text;

            // barkod height
            imgBarcode.Height = imgCode.Height + 100;
            //imgBarcode.Width = imgCode.Width + 50;

            // product name
            lblProductName.Text = txtProductName.Text;
            lblProductName.Top = imgBarcode.Height + 160;
            lblBusinessDomain.Top = imgBarcode.Height + 160;
            //imgBarcode.Height = 10;
        }

        private void btnQRKod_Click(object sender, EventArgs e)
        {
            int Height = !string.IsNullOrEmpty(txtHeight.Text) ? int.Parse(txtHeight.Text) : 60;
            //int Width = !string.IsNullOrEmpty(txtWidth.Text) ? int.Parse(txtWidth.Text) : 60;

            Zen.Barcode.CodeQrBarcodeDraw qr = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            imgCode.Image = qr.Draw(txtBox.Text, Height);
        }



        private void btnSave_Click(object sender, EventArgs e)
        {

            // Yeni bir Bitmap oluştur
            int imgBarcode_Width = imgBarcode.Width;
            int imgBarcode_Height = imgBarcode.Height - 50;

            Bitmap bitmap = new Bitmap(imgBarcode_Width, imgBarcode_Height);

            // Bitmap üzerinde bir Graphics nesnesi oluştur
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                // imgBarcode'ı bitmap'e çiz
                g.Clear(Color.White);

                // Her bir label'ı ve pictureBox'ı çiz
                DrawControl(lblProductCode, g, imgBarcode, Color.Black, Color.White);
                DrawControl(lblBusinessName, g, imgBarcode, Color.Black, Color.White);
                DrawControl(lblBusinessDomain, g, imgBarcode, Color.Black, Color.White);
                DrawControl(lblProductName, g, imgBarcode, Color.Black, Color.White);
                DrawControl(imgCode, g, imgBarcode, Color.Black, Color.White);
            }

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Resim Dosyası";
            saveFile.Filter = "PNG| *.png";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                bitmap.Save(saveFile.FileName);
                MessageBox.Show("Kayıt İşlemi Başarılı");
            }
        }

        private void DrawControl(Control control, Graphics g, Control referenceControl, Color foreColor, Color backColor)
        {
            Bitmap controlImage = new Bitmap(control.Width, control.Height);

            // Kontrolü beyaz bir arkaplan üzerine çiz
            control.BackColor = backColor;
            control.ForeColor = foreColor;

            // Kontrolü bitmap'e çiz
            control.DrawToBitmap(controlImage, new Rectangle(Point.Empty, control.Size));
            g.DrawImage(controlImage, control.Left - referenceControl.Left, control.Top - referenceControl.Top);
        }

        private void txtHeight_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            AppData appData = new AppData();
            string filePath = saveBarCode();

            Bitmap bitmap = new Bitmap(filePath);

            using (MemoryStream ms = new MemoryStream())
            {

                // Barkodu ms içerisine kaydet
                //imgBarcode.Image.Save(ms, ImageFormat.Png);
                bitmap.Save(ms, ImageFormat.Png);

                // Diyelim ki "Barcode" adında bir DataTable var
                AppData.BarcodeDataTable barcodeTable = appData.Barcode;

                //for (int i = 0; i < 24; i++)
                //{
                    //byte[] imageBytes = GetBarcodeImageBytes();
                    //Image image = ByteArrayToImage(imageBytes);

                    // DataTable'a yeni bir satır ekleyin
                    AppData.BarcodeRow newRow = barcodeTable.NewBarcodeRow();
                appData.Barcode.Clear();
                    // Yeni satıra verileri ekleyin
                    newRow.ProductName = txtBox.Text;
                    newRow.BusinessName = lblBusinessName.Text;
                    newRow.BusinessDomain = lblBusinessDomain.Text;
                    //newRow.Image = imgCode.ToString();
                    barcodeTable.Clear();
                    appData.Barcode.Clear();
                    // DataTable'a satırı ekleyin
                    //barcodeTable.AddBarcodeRow(txtBox.Text, lblBusinessName.Text, lblProductName.Text, "deneme");                    
                    for (int x = 0; x < 24; x++)
                    {
                        appData.Barcode.AddBarcodeRow(txtBox.Text, lblBusinessName.Text, lblProductName.Text, ms.ToArray());
                    }
                //}

                // DataSet'i MemoryStream'e yazın veya başka işlemler yapın
                //appData.WriteXml(ms);

            }

            using (frmReport frm = new frmReport(appData.Barcode))
            {
                frm.ShowDialog();
            }
        }


        public string saveBarCode()
        {
            Random random = new Random();
            // Programın bulunduğu dizini al
            string programDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // "barcode" adında bir klasör oluştur
            string barcodeDirectory = Path.Combine(programDirectory, "barcode");
            Directory.CreateDirectory(barcodeDirectory);

            // Kaydedilecek dosya yolunu belirle
            string filePath = Path.Combine(barcodeDirectory, $"{lblProductName}.png");


            if (File.Exists(filePath))
            {
                // Dosya var
                //Console.WriteLine("Dosya mevcut.");
                return filePath;
            }
            else
            {
                // Yeni bir Bitmap oluştur

                int imgBarcode_Width = imgBarcode.Width;
                int imgBarcode_Height = imgBarcode.Height - 35;

                Bitmap bitmap = new Bitmap(imgBarcode_Width, imgBarcode_Height);

                // Bitmap üzerinde bir Graphics nesnesi oluştur
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    // imgBarcode'ı bitmap'e çiz
                    g.Clear(Color.White);

                    // Her bir label'ı ve pictureBox'ı çiz
                    DrawControl(lblProductCode, g, imgBarcode, Color.Black, Color.White);
                    DrawControl(lblBusinessName, g, imgBarcode, Color.Black, Color.White);
                    DrawControl(lblBusinessDomain, g, imgBarcode, Color.Black, Color.White);
                    DrawControl(lblProductName, g, imgBarcode, Color.Black, Color.White);
                    DrawControl(imgCode, g, imgBarcode, Color.Black, Color.White);
                }

                // Dosyayı belirlenen yere kaydet
                bitmap.Save(filePath);

                // Kaydetme işlemi tamamlandı mesajı göster
                MessageBox.Show("Kayıt İşlemi Başarılı. Dosya yolu: " + filePath);
                return filePath;
            }


        }

        //private byte[] ImageToByteArray(Image image)
        //{
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        //        return ms.ToArray();
        //    }
        //}

        //private Image ByteArrayToImage(byte[] byteArray)
        //{
        //    using (MemoryStream ms = new MemoryStream(byteArray))
        //    {
        //        return Image.FromStream(ms);
        //    }
        //}
    }
}
