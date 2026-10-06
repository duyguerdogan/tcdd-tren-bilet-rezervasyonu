namespace WindowsFormsApp1
{
    partial class TrenSaatleriForm
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
            this.cmbStations = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblArrivalTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Lavender;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.IndianRed;
            this.label1.Location = new System.Drawing.Point(681, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Durak seçiniz:";
            // 
            // cmbStations
            // 
            this.cmbStations.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbStations.DropDownHeight = 210;
            this.cmbStations.DropDownWidth = 190;
            this.cmbStations.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbStations.ForeColor = System.Drawing.Color.IndianRed;
            this.cmbStations.FormattingEnabled = true;
            this.cmbStations.IntegralHeight = false;
            this.cmbStations.Location = new System.Drawing.Point(687, 169);
            this.cmbStations.Name = "cmbStations";
            this.cmbStations.Size = new System.Drawing.Size(164, 26);
            this.cmbStations.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.IndianRed;
            this.button1.Location = new System.Drawing.Point(717, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 48);
            this.button1.TabIndex = 2;
            this.button1.Text = "Hesapla";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // lblArrivalTime
            // 
            this.lblArrivalTime.AutoSize = true;
            this.lblArrivalTime.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lblArrivalTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblArrivalTime.ForeColor = System.Drawing.Color.Crimson;
            this.lblArrivalTime.Location = new System.Drawing.Point(243, 432);
            this.lblArrivalTime.Name = "lblArrivalTime";
            this.lblArrivalTime.Size = new System.Drawing.Size(0, 25);
            this.lblArrivalTime.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(211, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(528, 38);
            this.label2.TabIndex = 4;
            this.label2.Text = "TRENİM NE ZAMAN GELECEK?";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radioButton1.Location = new System.Drawing.Point(24, 167);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(118, 24);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "İZMİR MAVİ";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radioButton2.Location = new System.Drawing.Point(24, 197);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(152, 24);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.Text = "EGE EKSPRESİ";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Lavender;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.IndianRed;
            this.label3.Location = new System.Drawing.Point(18, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 32);
            this.label3.TabIndex = 7;
            this.label3.Text = "Treninizi Seçiniz:";
            // 
            // TrenSaatleriForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.images;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(952, 494);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblArrivalTime);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbStations);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "TrenSaatleriForm";
            this.Text = "TrenSaatleriForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbStations;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblArrivalTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label3;
    }
}
