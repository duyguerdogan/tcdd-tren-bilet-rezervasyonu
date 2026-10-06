namespace WindowsFormsApp1
{
    partial class GirisForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnKayitOl = new System.Windows.Forms.Button();
            this.btnGirisYap = new System.Windows.Forms.Button();
            this.txtKayitKullaniciAdi = new System.Windows.Forms.TextBox();
            this.txtKayitParola = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGirisKullaniciAdi = new System.Windows.Forms.TextBox();
            this.txtGirisParola = new System.Windows.Forms.TextBox();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Calibri", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(137, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "KAYIT OL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Lavender;
            this.label2.Font = new System.Drawing.Font("Microsoft PhagsPa", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(23, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kullanıcı Adı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Lavender;
            this.label3.Font = new System.Drawing.Font("Microsoft PhagsPa", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(73, 321);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 31);
            this.label3.TabIndex = 2;
            this.label3.Text = "Parola";
            // 
            // btnKayitOl
            // 
            this.btnKayitOl.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnKayitOl.Font = new System.Drawing.Font("Microsoft PhagsPa", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKayitOl.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnKayitOl.Location = new System.Drawing.Point(170, 417);
            this.btnKayitOl.Name = "btnKayitOl";
            this.btnKayitOl.Size = new System.Drawing.Size(111, 37);
            this.btnKayitOl.TabIndex = 3;
            this.btnKayitOl.Text = "Kayıt Ol";
            this.btnKayitOl.UseVisualStyleBackColor = false;
            this.btnKayitOl.Click += new System.EventHandler(this.KayitOl_Click);
            // 
            // btnGirisYap
            // 
            this.btnGirisYap.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGirisYap.Font = new System.Drawing.Font("Microsoft PhagsPa", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGirisYap.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnGirisYap.Location = new System.Drawing.Point(676, 417);
            this.btnGirisYap.Name = "btnGirisYap";
            this.btnGirisYap.Size = new System.Drawing.Size(92, 37);
            this.btnGirisYap.TabIndex = 4;
            this.btnGirisYap.Text = "Giriş Yap";
            this.btnGirisYap.UseVisualStyleBackColor = false;
            this.btnGirisYap.Click += new System.EventHandler(this.GirisYap_Click);
            // 
            // txtKayitKullaniciAdi
            // 
            this.txtKayitKullaniciAdi.BackColor = System.Drawing.Color.Lavender;
            this.txtKayitKullaniciAdi.Location = new System.Drawing.Point(191, 236);
            this.txtKayitKullaniciAdi.Name = "txtKayitKullaniciAdi";
            this.txtKayitKullaniciAdi.Size = new System.Drawing.Size(196, 24);
            this.txtKayitKullaniciAdi.TabIndex = 5;
            // 
            // txtKayitParola
            // 
            this.txtKayitParola.BackColor = System.Drawing.Color.Lavender;
            this.txtKayitParola.Location = new System.Drawing.Point(191, 326);
            this.txtKayitParola.Name = "txtKayitParola";
            this.txtKayitParola.Size = new System.Drawing.Size(196, 24);
            this.txtKayitParola.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Lavender;
            this.label5.Font = new System.Drawing.Font("Microsoft PhagsPa", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label5.Location = new System.Drawing.Point(467, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 31);
            this.label5.TabIndex = 9;
            this.label5.Text = "Kullanıcı Adı";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Lavender;
            this.label6.Font = new System.Drawing.Font("Microsoft PhagsPa", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label6.Location = new System.Drawing.Point(536, 322);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 31);
            this.label6.TabIndex = 10;
            this.label6.Text = "Parola";
            // 
            // txtGirisKullaniciAdi
            // 
            this.txtGirisKullaniciAdi.BackColor = System.Drawing.Color.Lavender;
            this.txtGirisKullaniciAdi.Location = new System.Drawing.Point(639, 237);
            this.txtGirisKullaniciAdi.Name = "txtGirisKullaniciAdi";
            this.txtGirisKullaniciAdi.Size = new System.Drawing.Size(187, 24);
            this.txtGirisKullaniciAdi.TabIndex = 12;
            // 
            // txtGirisParola
            // 
            this.txtGirisParola.BackColor = System.Drawing.Color.Lavender;
            this.txtGirisParola.Location = new System.Drawing.Point(632, 329);
            this.txtGirisParola.Name = "txtGirisParola";
            this.txtGirisParola.Size = new System.Drawing.Size(194, 24);
            this.txtGirisParola.TabIndex = 14;
            // 
            // ımageList1
            // 
            this.ımageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ımageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label4
            // 
            this.label4.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label4.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.label4.Font = new System.Drawing.Font("Perpetua Titling MT", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(128, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(584, 72);
            this.label4.TabIndex = 15;
            this.label4.Text = "TRENİM NEREDE?";
            this.label4.UseMnemonic = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.kullanıcılogo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(398, 140);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 53);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.Font = new System.Drawing.Font("Calibri", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label7.Location = new System.Drawing.Point(584, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 40);
            this.label7.TabIndex = 17;
            this.label7.Text = "GİRİŞ YAP";
            // 
            // GirisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.maxresdefault;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(850, 657);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtGirisParola);
            this.Controls.Add(this.txtGirisKullaniciAdi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtKayitParola);
            this.Controls.Add(this.txtKayitKullaniciAdi);
            this.Controls.Add(this.btnGirisYap);
            this.Controls.Add(this.btnKayitOl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft PhagsPa", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "GirisForm";
            this.Text = "3";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnKayitOl;
        private System.Windows.Forms.Button btnGirisYap;
        private System.Windows.Forms.TextBox txtKayitKullaniciAdi;
        private System.Windows.Forms.TextBox txtKayitParola;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGirisKullaniciAdi;
        private System.Windows.Forms.TextBox txtGirisParola;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
    }
}


