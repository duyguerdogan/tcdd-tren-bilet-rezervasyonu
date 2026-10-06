namespace WindowsFormsApp1
{
    partial class YolcuBilgileriForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtIsim = new System.Windows.Forms.TextBox();
            this.txtSoyisim = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mskdTelefon = new System.Windows.Forms.MaskedTextBox();
            this.rdbKadın = new System.Windows.Forms.RadioButton();
            this.rdbErkek = new System.Windows.Forms.RadioButton();
            this.btnTamam = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft PhagsPa", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(84, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "İsim";
            // 
            // txtIsim
            // 
            this.txtIsim.Location = new System.Drawing.Point(154, 49);
            this.txtIsim.Name = "txtIsim";
            this.txtIsim.Size = new System.Drawing.Size(133, 22);
            this.txtIsim.TabIndex = 1;
            // 
            // txtSoyisim
            // 
            this.txtSoyisim.Location = new System.Drawing.Point(154, 98);
            this.txtSoyisim.Name = "txtSoyisim";
            this.txtSoyisim.Size = new System.Drawing.Size(133, 22);
            this.txtSoyisim.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft PhagsPa", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(81, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Soyisim";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft PhagsPa", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(84, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Telefon";
            // 
            // mskdTelefon
            // 
            this.mskdTelefon.Location = new System.Drawing.Point(154, 152);
            this.mskdTelefon.Mask = "(999) 000-0000";
            this.mskdTelefon.Name = "mskdTelefon";
            this.mskdTelefon.Size = new System.Drawing.Size(133, 22);
            this.mskdTelefon.TabIndex = 5;
            // 
            // rdbKadın
            // 
            this.rdbKadın.AutoSize = true;
            this.rdbKadın.Checked = true;
            this.rdbKadın.Font = new System.Drawing.Font("Microsoft PhagsPa", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rdbKadın.Location = new System.Drawing.Point(116, 225);
            this.rdbKadın.Name = "rdbKadın";
            this.rdbKadın.Size = new System.Drawing.Size(61, 20);
            this.rdbKadın.TabIndex = 6;
            this.rdbKadın.TabStop = true;
            this.rdbKadın.Text = "Kadın";
            this.rdbKadın.UseVisualStyleBackColor = true;
            // 
            // rdbErkek
            // 
            this.rdbErkek.AutoSize = true;
            this.rdbErkek.Font = new System.Drawing.Font("Microsoft PhagsPa", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rdbErkek.Location = new System.Drawing.Point(196, 225);
            this.rdbErkek.Name = "rdbErkek";
            this.rdbErkek.Size = new System.Drawing.Size(62, 20);
            this.rdbErkek.TabIndex = 7;
            this.rdbErkek.Text = "Erkek";
            this.rdbErkek.UseVisualStyleBackColor = true;
            // 
            // btnTamam
            // 
            this.btnTamam.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnTamam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTamam.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTamam.Location = new System.Drawing.Point(213, 262);
            this.btnTamam.Name = "btnTamam";
            this.btnTamam.Size = new System.Drawing.Size(91, 23);
            this.btnTamam.TabIndex = 8;
            this.btnTamam.Text = "TAMAM";
            this.btnTamam.UseVisualStyleBackColor = false;
            this.btnTamam.Click += new System.EventHandler(this.Tamam_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnIptal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIptal.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnIptal.Location = new System.Drawing.Point(87, 262);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(91, 23);
            this.btnIptal.TabIndex = 9;
            this.btnIptal.Text = "İPTAL";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += new System.EventHandler(this.Iptal_Click);
            // 
            // YolcuBilgileriForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(375, 337);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnTamam);
            this.Controls.Add(this.rdbErkek);
            this.Controls.Add(this.rdbKadın);
            this.Controls.Add(this.mskdTelefon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSoyisim);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIsim);
            this.Controls.Add(this.label1);
            this.Name = "YolcuBilgileriForm";
            this.Text = "YolcuBilgileriForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTamam;
        private System.Windows.Forms.Button btnIptal;
        private System.Windows.Forms.TextBox txtIsim;
        private System.Windows.Forms.TextBox txtSoyisim;
        private System.Windows.Forms.MaskedTextBox mskdTelefon;
        private System.Windows.Forms.RadioButton rdbKadın;
        private System.Windows.Forms.RadioButton rdbErkek;
    }
}
