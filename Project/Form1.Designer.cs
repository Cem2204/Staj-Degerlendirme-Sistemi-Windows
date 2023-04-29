namespace Project
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.girisBTN = new System.Windows.Forms.Button();
            this.adCOMBO = new System.Windows.Forms.ComboBox();
            this.adSoyadLBL = new System.Windows.Forms.Label();
            this.parolaLBL = new System.Windows.Forms.Label();
            this.parolaTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // girisBTN
            // 
            this.girisBTN.BackColor = System.Drawing.Color.RosyBrown;
            this.girisBTN.Location = new System.Drawing.Point(214, 242);
            this.girisBTN.Name = "girisBTN";
            this.girisBTN.Size = new System.Drawing.Size(319, 40);
            this.girisBTN.TabIndex = 0;
            this.girisBTN.Text = "Giriş";
            this.girisBTN.UseVisualStyleBackColor = false;
            this.girisBTN.Click += new System.EventHandler(this.girisBTN_Click);
            // 
            // adCOMBO
            // 
            this.adCOMBO.FormattingEnabled = true;
            this.adCOMBO.Location = new System.Drawing.Point(320, 123);
            this.adCOMBO.Name = "adCOMBO";
            this.adCOMBO.Size = new System.Drawing.Size(213, 24);
            this.adCOMBO.TabIndex = 1;
            this.adCOMBO.SelectedIndexChanged += new System.EventHandler(this.adCOMBO_SelectedIndexChanged);
            // 
            // adSoyadLBL
            // 
            this.adSoyadLBL.AutoSize = true;
            this.adSoyadLBL.Location = new System.Drawing.Point(211, 126);
            this.adSoyadLBL.Name = "adSoyadLBL";
            this.adSoyadLBL.Size = new System.Drawing.Size(76, 16);
            this.adSoyadLBL.TabIndex = 2;
            this.adSoyadLBL.Text = "AD SOYAD";
            // 
            // parolaLBL
            // 
            this.parolaLBL.AutoSize = true;
            this.parolaLBL.Location = new System.Drawing.Point(211, 181);
            this.parolaLBL.Name = "parolaLBL";
            this.parolaLBL.Size = new System.Drawing.Size(61, 16);
            this.parolaLBL.TabIndex = 3;
            this.parolaLBL.Text = "PAROLA";
            // 
            // parolaTB
            // 
            this.parolaTB.Location = new System.Drawing.Point(320, 175);
            this.parolaTB.Name = "parolaTB";
            this.parolaTB.Size = new System.Drawing.Size(213, 22);
            this.parolaTB.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.parolaTB);
            this.Controls.Add(this.parolaLBL);
            this.Controls.Add(this.adSoyadLBL);
            this.Controls.Add(this.adCOMBO);
            this.Controls.Add(this.girisBTN);
            this.Name = "Form1";
            this.Text = "BİLGİSAYAR PROGRAMCILIĞI STAJ DEĞERLENDİRME GİRİŞ FORMU";
            this.Load += new System.EventHandler(this.Staj_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button girisBTN;
        private System.Windows.Forms.ComboBox adCOMBO;
        private System.Windows.Forms.Label adSoyadLBL;
        private System.Windows.Forms.Label parolaLBL;
        private System.Windows.Forms.TextBox parolaTB;
    }
}

