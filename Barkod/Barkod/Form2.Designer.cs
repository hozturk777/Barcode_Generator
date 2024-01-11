namespace Barkod
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblKod = new Label();
            txtBox = new TextBox();
            btnBarkod = new Button();
            btnQRKod = new Button();
            imgBarcode = new PictureBox();
            btnSave = new Button();
            txtHeight = new TextBox();
            label1 = new Label();
            imgCode = new PictureBox();
            label2 = new Label();
            lblBusinessName = new Label();
            lblCodeName = new Label();
            label5 = new Label();
            txtMargin = new TextBox();
            lblProductCode = new Label();
            label3 = new Label();
            txtProductName = new TextBox();
            lblProductName = new Label();
            btnPrint = new Button();
            lblBusinessDomain = new Label();
            imgGet = new PictureBox();
            btnGet = new Button();
            progressBar1 = new ProgressBar();
            label4 = new Label();
            txtGetProductName = new TextBox();
            btnGetPrint = new Button();
            ((System.ComponentModel.ISupportInitialize)imgBarcode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imgCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imgGet).BeginInit();
            SuspendLayout();
            // 
            // lblKod
            // 
            lblKod.AutoSize = true;
            lblKod.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblKod.Location = new Point(320, 57);
            lblKod.Name = "lblKod";
            lblKod.Size = new Size(59, 20);
            lblKod.TabIndex = 0;
            lblKod.Text = "Kod Gir";
            // 
            // txtBox
            // 
            txtBox.Location = new Point(208, 99);
            txtBox.Name = "txtBox";
            txtBox.Size = new Size(275, 23);
            txtBox.TabIndex = 1;
            // 
            // btnBarkod
            // 
            btnBarkod.Location = new Point(196, 143);
            btnBarkod.Name = "btnBarkod";
            btnBarkod.Size = new Size(95, 33);
            btnBarkod.TabIndex = 2;
            btnBarkod.Text = "BARKOD";
            btnBarkod.UseVisualStyleBackColor = true;
            btnBarkod.Click += btnBarkod_Click;
            // 
            // btnQRKod
            // 
            btnQRKod.Location = new Point(297, 143);
            btnQRKod.Name = "btnQRKod";
            btnQRKod.Size = new Size(95, 33);
            btnQRKod.TabIndex = 3;
            btnQRKod.Text = "QR";
            btnQRKod.UseVisualStyleBackColor = true;
            btnQRKod.Click += btnQRKod_Click;
            // 
            // imgBarcode
            // 
            imgBarcode.BackColor = Color.Transparent;
            imgBarcode.BorderStyle = BorderStyle.FixedSingle;
            imgBarcode.Location = new Point(196, 214);
            imgBarcode.Name = "imgBarcode";
            imgBarcode.Size = new Size(234, 128);
            imgBarcode.TabIndex = 4;
            imgBarcode.TabStop = false;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(400, 143);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(95, 33);
            btnSave.TabIndex = 5;
            btnSave.Text = "KAYDET";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtHeight
            // 
            txtHeight.Location = new Point(21, 166);
            txtHeight.Name = "txtHeight";
            txtHeight.Size = new Size(100, 23);
            txtHeight.TabIndex = 6;
            txtHeight.TextChanged += txtHeight_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(38, 143);
            label1.Name = "label1";
            label1.Size = new Size(68, 20);
            label1.TabIndex = 7;
            label1.Text = "Yükseklik";
            // 
            // imgCode
            // 
            imgCode.BackColor = Color.Transparent;
            imgCode.Location = new Point(201, 239);
            imgCode.Name = "imgCode";
            imgCode.Size = new Size(215, 68);
            imgCode.TabIndex = 8;
            imgCode.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 6.5F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(76, 192);
            label2.Name = "label2";
            label2.Size = new Size(45, 12);
            label2.TabIndex = 9;
            label2.Text = "(max:150)";
            // 
            // lblBusinessName
            // 
            lblBusinessName.AutoSize = true;
            lblBusinessName.BackColor = Color.Transparent;
            lblBusinessName.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            lblBusinessName.Location = new Point(196, 218);
            lblBusinessName.Name = "lblBusinessName";
            lblBusinessName.Size = new Size(95, 13);
            lblBusinessName.TabIndex = 10;
            lblBusinessName.Text = "MestAyHediyelik";
            // 
            // lblCodeName
            // 
            lblCodeName.AutoSize = true;
            lblCodeName.Location = new Point(208, 419);
            lblCodeName.Name = "lblCodeName";
            lblCodeName.Size = new Size(0, 15);
            lblCodeName.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(46, 218);
            label5.Name = "label5";
            label5.Size = new Size(47, 20);
            label5.TabIndex = 14;
            label5.Text = "Aralık";
            // 
            // txtMargin
            // 
            txtMargin.Location = new Point(21, 241);
            txtMargin.Name = "txtMargin";
            txtMargin.Size = new Size(100, 23);
            txtMargin.TabIndex = 13;
            // 
            // lblProductCode
            // 
            lblProductCode.AutoSize = true;
            lblProductCode.Font = new Font("Segoe UI", 7F, FontStyle.Bold, GraphicsUnit.Point);
            lblProductCode.Location = new Point(196, 287);
            lblProductCode.Name = "lblProductCode";
            lblProductCode.Size = new Size(33, 12);
            lblProductCode.TabIndex = 15;
            lblProductCode.Text = "label3";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(36, 287);
            label3.Name = "label3";
            label3.Size = new Size(67, 20);
            label3.TabIndex = 17;
            label3.Text = "Ürün Adı";
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(21, 310);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(100, 23);
            txtProductName.TabIndex = 16;
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Font = new Font("Segoe UI", 7F, FontStyle.Bold, GraphicsUnit.Point);
            lblProductName.Location = new Point(196, 310);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(33, 12);
            lblProductName.TabIndex = 18;
            lblProductName.Text = "label4";
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(512, 300);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(95, 33);
            btnPrint.TabIndex = 19;
            btnPrint.Text = "Yazdır";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // lblBusinessDomain
            // 
            lblBusinessDomain.AutoSize = true;
            lblBusinessDomain.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            lblBusinessDomain.Location = new Point(284, 309);
            lblBusinessDomain.Name = "lblBusinessDomain";
            lblBusinessDomain.Size = new Size(146, 13);
            lblBusinessDomain.TabIndex = 11;
            lblBusinessDomain.Text = "www.mestayhediyelik.com";
            // 
            // imgGet
            // 
            imgGet.BackColor = Color.Transparent;
            imgGet.BorderStyle = BorderStyle.FixedSingle;
            imgGet.Location = new Point(196, 391);
            imgGet.Name = "imgGet";
            imgGet.Size = new Size(234, 128);
            imgGet.TabIndex = 20;
            imgGet.TabStop = false;
            // 
            // btnGet
            // 
            btnGet.Location = new Point(22, 486);
            btnGet.Name = "btnGet";
            btnGet.Size = new Size(100, 33);
            btnGet.TabIndex = 21;
            btnGet.Text = "Getir";
            btnGet.UseVisualStyleBackColor = true;
            btnGet.Click += btnGet_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(21, 357);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(651, 10);
            progressBar1.TabIndex = 22;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(38, 391);
            label4.Name = "label4";
            label4.Size = new Size(67, 20);
            label4.TabIndex = 24;
            label4.Text = "Ürün Adı";
            // 
            // txtGetProductName
            // 
            txtGetProductName.Location = new Point(22, 414);
            txtGetProductName.Name = "txtGetProductName";
            txtGetProductName.Size = new Size(100, 23);
            txtGetProductName.TabIndex = 23;
            // 
            // btnGetPrint
            // 
            btnGetPrint.Location = new Point(512, 486);
            btnGetPrint.Name = "btnGetPrint";
            btnGetPrint.Size = new Size(95, 33);
            btnGetPrint.TabIndex = 25;
            btnGetPrint.Text = "Yazdır";
            btnGetPrint.UseVisualStyleBackColor = true;
            btnGetPrint.Click += btnGetPrint_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 612);
            Controls.Add(btnGetPrint);
            Controls.Add(label4);
            Controls.Add(txtGetProductName);
            Controls.Add(progressBar1);
            Controls.Add(btnGet);
            Controls.Add(imgGet);
            Controls.Add(btnPrint);
            Controls.Add(lblProductName);
            Controls.Add(label3);
            Controls.Add(txtProductName);
            Controls.Add(lblProductCode);
            Controls.Add(label5);
            Controls.Add(txtMargin);
            Controls.Add(lblCodeName);
            Controls.Add(lblBusinessDomain);
            Controls.Add(lblBusinessName);
            Controls.Add(label2);
            Controls.Add(imgCode);
            Controls.Add(label1);
            Controls.Add(txtHeight);
            Controls.Add(btnSave);
            Controls.Add(imgBarcode);
            Controls.Add(btnQRKod);
            Controls.Add(btnBarkod);
            Controls.Add(txtBox);
            Controls.Add(lblKod);
            Name = "Form2";
            Text = "Barkod & QR Code v2.0";
            ((System.ComponentModel.ISupportInitialize)imgBarcode).EndInit();
            ((System.ComponentModel.ISupportInitialize)imgCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)imgGet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblKod;
        private TextBox txtBox;
        private Button btnBarkod;
        private Button btnQRKod;
        private PictureBox imgBarcode;
        private Button btnSave;
        private TextBox txtHeight;
        private Label label1;
        private PictureBox imgCode;
        private Label label2;
        private Label lblBusinessName;
        private Label lblCodeName;
        private Label label5;
        private TextBox txtMargin;
        private Label lblProductCode;
        private Label label3;
        private TextBox txtProductName;
        private Label lblProductName;
        private Button btnPrint;
        private Label lblBusinessDomain;
        private PictureBox imgGet;
        private Button btnGet;
        private ProgressBar progressBar1;
        private Label label4;
        private TextBox txtGetProductName;
        private Button btnGetPrint;
    }
}