using barcode;
using Microsoft.Reporting.WinForms;
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
        OpenFileDialog openFileDialog = new OpenFileDialog();
        public Form2()
        {
            InitializeComponent();
            // txtOperations
            txtBusinessName.Text = "MestAyHediyelik";
            txtBusinessDomain.Text = "www.mestayhediyelik.com";
            txtHeight.Text = "40";
            txtMargin.Text = txtHeight.Text;
        }

        private void btnBarkod_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtHeight.Text, out _) || !int.TryParse(txtMargin.Text, out _))
            {
                MessageBox.Show("Lütfen Barkod Yüksekliği ya da Barkod No Aralığını sayı olarak giriniz !");
            }
            else if (string.IsNullOrEmpty(txtBox.Text))
            {
                MessageBox.Show("Lütfen Üretmek İstediğiniz Bir Kod Giriniz!");
            }
            else if (string.IsNullOrEmpty(txtProductName.Text))
            {
                MessageBox.Show("Lütfen Ürün Adı Giriniz!");
            }
            else
            {
                int Height = !string.IsNullOrEmpty(txtHeight.Text) ? int.Parse(txtHeight.Text) : 40;
                //int Width = !string.IsNullOrEmpty(txtWidth.Text) ? int.Parse(txtWidth.Text) : 60;

                Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                imgCode.Image = barcode.Draw(txtBox.Text, Height);
                imgCode.Width = imgCode.Image.Width;
                imgCode.Height = imgCode.Image.Height;

                // code name margin
                txtMargin.Text = txtHeight.Text;
                int topMarginValue = int.Parse(txtMargin.Text) != Height ? int.Parse(txtMargin.Text) : Height; // Üst marj miktarı    
                lblProductCode.Top = imgCode.Top + topMarginValue;
                lblProductCode.Text = txtBox.Text;

                // barkod height
                imgBarcode.Height = imgCode.Height + 65;
                //imgBarcode.Width = imgCode.Width + 50;

                // product name
                lblProductName.Text = txtProductName.Text;
                lblProductName.Top = imgBarcode.Height + 195;

                // business
                lblBusinessDomain.Top = imgBarcode.Height + 195;
                lblBusinessDomain.Text = txtBusinessDomain.Text;
                lblBusinessName.Text = txtBusinessName.Text;

            }


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
            int imgBarcode_Height = imgBarcode.Height;

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

                //byte[] imageBytes = GetBarcodeImageBytes();
                //Image image = ByteArrayToImage(imageBytes);

                // DataTable'a yeni bir satır ekleyin
                AppData.BarcodeRow newRow = barcodeTable.NewBarcodeRow();
                appData.Barcode.Clear();
                // Yeni satıra verileri ekle
                newRow.ProductName = txtBox.Text;
                newRow.BusinessName = lblBusinessName.Text;
                newRow.BusinessDomain = lblBusinessDomain.Text;
                //newRow.Image = imgCode.ToString();
                barcodeTable.Clear();
                appData.Barcode.Clear();

                // DataTable'a satırı ekle                
                for (int x = 0; x < 24; x++)
                {
                    appData.Barcode.AddBarcodeRow(txtBox.Text, lblBusinessName.Text, lblProductName.Text, ms.ToArray());
                }
            }

            using (frmReport frm = new frmReport(appData.Barcode))
            {
                frm.switchPath("3x8");
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    frm.ShowDialog();
                }
            }
        }

        public string saveBarCode()
        {
            // Programın bulunduğu dizini al
            string programDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // "barcode" adında bir klasör oluştur
            string barcodeDirectory = Path.Combine(programDirectory, "barcode");
            Directory.CreateDirectory(barcodeDirectory);

            // Kaydedilecek dosya yolunu belirle
            string filePath = Path.Combine(barcodeDirectory, $"{lblProductName.Text}.png");


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
                int imgBarcode_Height = imgBarcode.Height;

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

        private void btnGet_Click(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Bir Resim Seçin";
            openFileDialog.Filter = "PNG Dosyaları|*.png|Tüm Dosyalar|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileName = Path.GetFileNameWithoutExtension(filePath);

                // Bitmap dosyasını oku
                Bitmap loadedBitmap = new Bitmap(filePath);

                // Örneğin, resmi PictureBox'a göster
                imgGet.Image = loadedBitmap;
                txtGetProductName.Text = fileName;

                // Resmi işleyebilirsiniz, örneğin parçalara bölebilirsiniz
                //ProcessImage(loadedBitmap);
            }
        }

        private void btnGetPrint_Click(object sender, EventArgs e)
        {
            AppData appData = new AppData();
            string filePath = openFileDialog.FileName;


            using (MemoryStream ms = new MemoryStream())
            {
                Bitmap loadedBitmap = new Bitmap(filePath);
                // Barkodu ms içerisine kaydet
                //imgBarcode.Image.Save(ms, ImageFormat.Png);
                loadedBitmap.Save(ms, ImageFormat.Png);

                // Diyelim ki "Barcode" adında bir DataTable var
                AppData.BarcodeDataTable barcodeTable = appData.Barcode;

                //byte[] imageBytes = GetBarcodeImageBytes();
                //Image image = ByteArrayToImage(imageBytes);

                // DataTable'a yeni bir satır ekleyin
                AppData.BarcodeRow newRow = barcodeTable.NewBarcodeRow();
                appData.Barcode.Clear();
                // Yeni satıra verileri ekle
                newRow.ProductName = txtBox.Text;
                newRow.BusinessName = lblBusinessName.Text;
                newRow.BusinessDomain = lblBusinessDomain.Text;
                //newRow.Image = imgCode.ToString();
                barcodeTable.Clear();
                appData.Barcode.Clear();

                // DataTable'a satırı ekle                
                for (int x = 0; x < 24; x++)
                {
                    appData.Barcode.AddBarcodeRow(txtBox.Text, lblBusinessName.Text, lblProductName.Text, ms.ToArray());
                }
            }

            using (frmReport frm = new frmReport(appData.Barcode))
            {
                frm.switchPath("3x8");
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    frm.ShowDialog();
                }
            }
        }

        public OpenFileDialog fileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Bir Resim Seçin";
            openFileDialog.Filter = "PNG Dosyaları|*.png|Tüm Dosyalar|*.*";
            return openFileDialog;
        }
    }
}
