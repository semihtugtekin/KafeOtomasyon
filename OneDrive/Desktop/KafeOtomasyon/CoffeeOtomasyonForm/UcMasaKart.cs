using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeOtomasyonForm
{
    public partial class UcMasaKart : UserControl
    {
        public string MasaAdi
        {
            get => lblMasaAdi.Text;
            set => lblMasaAdi.Text = value;
        }

        public string Durum
        {
            get => lblDurum.Text;
            set => lblDurum.Text = value;
        }

        // Masa ID gibi gizli bilgiler için:
        public int MasaId { get; set; }

        public UcMasaKart()
        {
            InitializeComponent();
            btnDetay.Click += BtnDetay_Click;
            // Forward MouseClick from all controls to parent
            this.lblMasaAdi.MouseClick += ForwardMouseClick;
            this.lblDurum.MouseClick += ForwardMouseClick;
            this.btnDetay.MouseClick += ForwardMouseClick;
            this.pictureBoxTableIcon.MouseClick += ForwardMouseClick;
        }

        private void ForwardMouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }

        private void BtnDetay_Click(object sender, EventArgs e)
        {
            // Örneğin sipariş formuna geçiş yapılabilir
            MessageBox.Show($"{MasaAdi} seçildi. Durum: {Durum}");
        }

        public void SetIconColor(Color color)
        {
            Bitmap bmp = new Bitmap(pictureBoxTableIcon.Width, pictureBoxTableIcon.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                using (Pen pen = new Pen(color, 6))
                {
                    // Masa simgesi: basit bir yuvarlak ve iki bacak
                    g.DrawEllipse(pen, 6, 10, 36, 20);
                    g.DrawLine(pen, 14, 30, 14, 44);
                    g.DrawLine(pen, 34, 30, 34, 44);
                }
            }
            pictureBoxTableIcon.Image = bmp;
        }
    }
}
