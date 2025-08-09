namespace CoffeeOtomasyonForm
{
    partial class UcSiparisler
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
            this.btnSiparis = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SuspendLayout();
            // 
            // btnSiparis
            // 
            this.btnSiparis.BorderRadius = 20;
            this.btnSiparis.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnSiparis.BorderThickness = 2;
            this.btnSiparis.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSiparis.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSiparis.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSiparis.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSiparis.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSiparis.FillColor = System.Drawing.Color.DimGray;
            this.btnSiparis.FillColor2 = System.Drawing.Color.Black;
            this.btnSiparis.Font = new System.Drawing.Font("Sylfaen", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSiparis.ForeColor = System.Drawing.Color.White;
            this.btnSiparis.Location = new System.Drawing.Point(295, 194);
            this.btnSiparis.Name = "btnSiparis";
            this.btnSiparis.Size = new System.Drawing.Size(215, 86);
            this.btnSiparis.TabIndex = 4;
            this.btnSiparis.Text = "Masalar";
            this.btnSiparis.Click += new System.EventHandler(this.btnSiparis_Click);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(132, 221);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(51, 15);
            this.guna2HtmlLabel1.TabIndex = 3;
            this.guna2HtmlLabel1.Text = "Masa Seç";
            // 
            // UcSiparisler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSiparis);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Name = "UcSiparisler";
            this.Size = new System.Drawing.Size(643, 474);
            this.Load += new System.EventHandler(this.UcSiparisler_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientTileButton btnSiparis;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}
