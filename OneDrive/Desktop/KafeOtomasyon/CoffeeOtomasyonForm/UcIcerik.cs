using System;
using System.Drawing;
using System.Windows.Forms;

namespace CoffeeOtomasyonForm
{
    public partial class UcIcerik : UserControl
    {
        private Label lblKategori;
        private Button btnGeri;
        public event EventHandler GeriClicked;
        public event Action<string, int, decimal> IcerikEklendi; // (ad, adet, fiyat)
        private Panel panelSag;
        private Label lblSeciliIcerik;
        private Button btnArttir;
        private Button btnAzalt;
        private Label lblAdet;
        private Button btnEkle;
        private string seciliIcerikAd;
        private decimal seciliIcerikFiyat;
        private int seciliAdet;

        public UcIcerik()
        {
            InitializeComponent();
            InitUI();
        }
        private void InitUI()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.WhiteSmoke;
            lblKategori = new Label();
            lblKategori.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblKategori.ForeColor = Color.FromArgb(34, 40, 49);
            lblKategori.Location = new Point(20, 20);
            lblKategori.Size = new Size(300, 40);
            this.Controls.Add(lblKategori);
            btnGeri = new Button();
            btnGeri.Text = "Geri";
            btnGeri.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnGeri.Size = new Size(100, 40);
            btnGeri.Location = new Point(20, 80);
            btnGeri.BackColor = Color.FromArgb(129, 212, 250);
            btnGeri.ForeColor = Color.FromArgb(34, 40, 49);
            btnGeri.FlatStyle = FlatStyle.Flat;
            btnGeri.Click += (s, e) => GeriClicked?.Invoke(this, EventArgs.Empty);
            this.Controls.Add(btnGeri);

            // Sıcak içecekler örneği: Çay
            Button btnCay = new Button();
            btnCay.Text = "Çay (15₺)";
            btnCay.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            btnCay.Size = new Size(220, 70);
            btnCay.Location = new Point(20, 150);
            btnCay.BackColor = Color.FromArgb(129, 212, 250);
            btnCay.ForeColor = Color.FromArgb(34, 40, 49);
            btnCay.FlatStyle = FlatStyle.Flat;
            btnCay.TextAlign = ContentAlignment.MiddleLeft;
            btnCay.Padding = new Padding(16, 0, 0, 0);
            btnCay.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnCay.Click += (s, e) => ShowSagPanel("Çay", 15);
            this.Controls.Add(btnCay);

            // Sağ panel (başta gizli)
            panelSag = new Panel();
            panelSag.Size = new Size(250, 200);
            panelSag.Location = new Point(300, 150);
            panelSag.BackColor = Color.FromArgb(236, 239, 241);
            panelSag.Visible = false;
            this.Controls.Add(panelSag);

            lblSeciliIcerik = new Label();
            lblSeciliIcerik.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblSeciliIcerik.ForeColor = Color.FromArgb(34, 40, 49);
            lblSeciliIcerik.Location = new Point(20, 10);
            lblSeciliIcerik.Size = new Size(200, 30);
            panelSag.Controls.Add(lblSeciliIcerik);

            btnAzalt = new Button();
            btnAzalt.Text = "-";
            btnAzalt.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            btnAzalt.Size = new Size(40, 40);
            btnAzalt.Location = new Point(20, 60);
            btnAzalt.Click += (s, e) => AdetDegistir(-1);
            panelSag.Controls.Add(btnAzalt);

            lblAdet = new Label();
            lblAdet.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblAdet.ForeColor = Color.FromArgb(34, 40, 49);
            lblAdet.Location = new Point(70, 60);
            lblAdet.Size = new Size(40, 40);
            lblAdet.TextAlign = ContentAlignment.MiddleCenter;
            panelSag.Controls.Add(lblAdet);

            btnArttir = new Button();
            btnArttir.Text = "+";
            btnArttir.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            btnArttir.Size = new Size(40, 40);
            btnArttir.Location = new Point(120, 60);
            btnArttir.Click += (s, e) => AdetDegistir(1);
            panelSag.Controls.Add(btnArttir);

            btnEkle = new Button();
            btnEkle.Text = "Ekle";
            btnEkle.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            btnEkle.Size = new Size(100, 40);
            btnEkle.Location = new Point(20, 120);
            btnEkle.BackColor = Color.FromArgb(129, 199, 132);
            btnEkle.ForeColor = Color.FromArgb(34, 40, 49);
            btnEkle.FlatStyle = FlatStyle.Flat;
            btnEkle.Click += (s, e) => {
                if (seciliAdet > 0)
                    IcerikEklendi?.Invoke(seciliIcerikAd, seciliAdet, seciliIcerikFiyat);
                panelSag.Visible = false;
            };
            panelSag.Controls.Add(btnEkle);
        }
        public void SetKategori(string kategori)
        {
            lblKategori.Text = $"Kategori: {kategori}";
            panelSag.Visible = false;
        }
        private void ShowSagPanel(string ad, decimal fiyat)
        {
            seciliIcerikAd = ad;
            seciliIcerikFiyat = fiyat;
            seciliAdet = 1;
            lblSeciliIcerik.Text = $"{ad} ({fiyat}₺)";
            lblAdet.Text = seciliAdet.ToString();
            panelSag.Visible = true;
        }
        private void AdetDegistir(int degisim)
        {
            seciliAdet = Math.Max(1, seciliAdet + degisim);
            lblAdet.Text = seciliAdet.ToString();
        }
    }
} 