namespace WindowsFormsApp1
{
    partial class BiletAlForm
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpTarih = new System.Windows.Forms.DateTimePicker();
            this.nudFiyat = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTren = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.koltukSeçToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbNereye = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbNereden = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudFiyat)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.listView1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(536, 13);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(796, 626);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Müşteri";
            this.columnHeader1.Width = 133;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Telefon";
            this.columnHeader2.Width = 135;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Cinsiyet";
            this.columnHeader3.Width = 79;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Nereden";
            this.columnHeader4.Width = 90;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Nereye";
            this.columnHeader5.Width = 91;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Koltuk No";
            this.columnHeader6.Width = 79;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Tarih";
            this.columnHeader7.Width = 84;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Fiyat";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Lavender;
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(299, 278);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tarih ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Lavender;
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Location = new System.Drawing.Point(299, 329);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fiyat";
            // 
            // dtpTarih
            // 
            this.dtpTarih.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTarih.Location = new System.Drawing.Point(376, 273);
            this.dtpTarih.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(136, 22);
            this.dtpTarih.TabIndex = 8;
            this.dtpTarih.ValueChanged += new System.EventHandler(this.TarihDegisti);
            // 
            // nudFiyat
            // 
            this.nudFiyat.Location = new System.Drawing.Point(378, 327);
            this.nudFiyat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudFiyat.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudFiyat.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudFiyat.Name = "nudFiyat";
            this.nudFiyat.Size = new System.Drawing.Size(135, 22);
            this.nudFiyat.TabIndex = 10;
            this.nudFiyat.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button1.Location = new System.Drawing.Point(335, 387);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 36);
            this.button1.TabIndex = 11;
            this.button1.Text = "KAYDET";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Kaydet_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Lavender;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label5.Location = new System.Drawing.Point(263, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 18);
            this.label5.TabIndex = 13;
            this.label5.Text = "Tren Seçiniz";
            // 
            // cmbTren
            // 
            this.cmbTren.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTren.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cmbTren.FormattingEnabled = true;
            this.cmbTren.Items.AddRange(new object[] {
            "İZMİR MAVİ",
            "EGE EKSPRESİ"});
            this.cmbTren.Location = new System.Drawing.Point(371, 88);
            this.cmbTren.Name = "cmbTren";
            this.cmbTren.Size = new System.Drawing.Size(136, 24);
            this.cmbTren.TabIndex = 14;
            this.cmbTren.SelectedIndexChanged += new System.EventHandler(this.TrenSecimiDegisti);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.koltukSeçToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(148, 28);
            // 
            // koltukSeçToolStripMenuItem
            // 
            this.koltukSeçToolStripMenuItem.Name = "koltukSeçToolStripMenuItem";
            this.koltukSeçToolStripMenuItem.Size = new System.Drawing.Size(147, 24);
            this.koltukSeçToolStripMenuItem.Text = "Koltuk Seç";
            this.koltukSeçToolStripMenuItem.Click += new System.EventHandler(this.KoltukSec_Click);
            // 
            // cmbNereye
            // 
            this.cmbNereye.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNereye.FormattingEnabled = true;
            this.cmbNereye.Items.AddRange(new object[] {
            "Ankara Gar",
            "Sincan",
            "Polatlı",
            "Beylikköprü",
            "Biçer",
            "Yunusemre",
            "Beylikova",
            "Alpu",
            "Eskişehir",
            "Kütahya",
            "Tavşanlı",
            "Balıköy",
            "Dursunbey",
            "Balıkesir",
            "Savaştepe",
            "Soma",
            "Kırkağaç",
            "Akhisar",
            "Saruhanlı",
            "Manisa",
            "Muradiye",
            "Menemen",
            "Çiğli",
            "İzmir(Basmane)"});
            this.cmbNereye.Location = new System.Drawing.Point(83, 98);
            this.cmbNereye.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbNereye.Name = "cmbNereye";
            this.cmbNereye.Size = new System.Drawing.Size(136, 24);
            this.cmbNereye.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Lavender;
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(6, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nereye";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Lavender;
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(6, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nereden";
            // 
            // cmbNereden
            // 
            this.cmbNereden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNereden.FormattingEnabled = true;
            this.cmbNereden.Items.AddRange(new object[] {
            "Ankara Gar",
            "Sincan",
            "Polatlı",
            "Beylikköprü",
            "Biçer",
            "Yunusemre",
            "Beylikova",
            "Alpu",
            "Eskişehir",
            "Kütahya",
            "Tavşanlı",
            "Balıköy",
            "Dursunbey",
            "Balıkesir",
            "Savaştepe",
            "Soma",
            "Kırkağaç",
            "Akhisar",
            "Saruhanlı",
            "Manisa",
            "Muradiye",
            "Menemen",
            "Çiğli",
            "İzmir(Basmane)"});
            this.cmbNereden.Location = new System.Drawing.Point(83, 43);
            this.cmbNereden.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbNereden.Name = "cmbNereden";
            this.cmbNereden.Size = new System.Drawing.Size(136, 24);
            this.cmbNereden.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cmbNereden);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbNereye);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.groupBox1.Location = new System.Drawing.Point(288, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 125);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "İSTİKAMET";
            // 
            // BiletAlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.bluebackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1357, 681);
            this.Controls.Add(this.cmbTren);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nudFiyat);
            this.Controls.Add(this.dtpTarih);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BiletAlForm";
            this.Text = "BiletAlForm";
            ((System.ComponentModel.ISupportInitialize)(this.nudFiyat)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpTarih;
        private System.Windows.Forms.NumericUpDown nudFiyat;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTren;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem koltukSeçToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbNereye;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbNereden;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
