namespace CoffeeOtomasyonForm
{
    partial class UcMasaKart
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMasaAdi = new System.Windows.Forms.Label();
            this.lblDurum = new System.Windows.Forms.Label();
            this.btnDetay = new System.Windows.Forms.Button();
            this.pictureBoxTableIcon = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // lblMasaAdi
            // 
            this.lblMasaAdi.AutoSize = true;
            this.lblMasaAdi.Location = new System.Drawing.Point(41, 69);
            this.lblMasaAdi.Name = "lblMasaAdi";
            this.lblMasaAdi.Size = new System.Drawing.Size(38, 13);
            this.lblMasaAdi.TabIndex = 0;
            this.lblMasaAdi.Text = "Durum";
            // 
            // lblDurum
            // 
            this.lblDurum.AutoSize = true;
            this.lblDurum.Location = new System.Drawing.Point(41, 107);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(47, 13);
            this.lblDurum.TabIndex = 0;
            this.lblDurum.Text = "MasaNo";
            // 
            // btnDetay
            // 
            this.btnDetay.Location = new System.Drawing.Point(44, 144);
            this.btnDetay.Name = "btnDetay";
            this.btnDetay.Size = new System.Drawing.Size(75, 23);
            this.btnDetay.TabIndex = 1;
            this.btnDetay.Text = "detay";
            this.btnDetay.UseVisualStyleBackColor = true;
            // 
            // pictureBoxTableIcon
            // 
            this.pictureBoxTableIcon.Size = new System.Drawing.Size(48, 48);
            this.pictureBoxTableIcon.Location = new System.Drawing.Point(36, 5);
            this.pictureBoxTableIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxTableIcon.Image = System.Drawing.SystemIcons.Information.ToBitmap(); // Placeholder icon
            this.Controls.Add(this.pictureBoxTableIcon);
            // 
            // UcMasaKart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDetay);
            this.Controls.Add(this.lblDurum);
            this.Controls.Add(this.lblMasaAdi);
            this.Controls.Add(this.pictureBoxTableIcon);
            this.Name = "UcMasaKart";
            this.Size = new System.Drawing.Size(181, 218);
          
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMasaAdi;
        private System.Windows.Forms.Label lblDurum;
        private System.Windows.Forms.Button btnDetay;
        private System.Windows.Forms.PictureBox pictureBoxTableIcon;
    }
}
