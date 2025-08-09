using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CoffeeOtomasyonForm
{
    public partial class UcMasaIslem : UserControl
    {
        private Label lblMasaAdi;
        private Button btnHesap;
        private Button btnGeri;
        private Label lblKategoriler;
        private Panel linePanel;
        private List<Button> kategoriButonlari = new List<Button>();
        public event EventHandler GeriClicked;
        public event EventHandler HesapClicked;
        public event Action<string> KategoriClicked;
        public string MasaAdi
        {
            get => lblMasaAdi.Text;
            set => lblMasaAdi.Text = value;
        }
        public UcMasaIslem()
        {
            InitializeComponent();
            InitUI();
        }
        private void InitUI()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.WhiteSmoke;

            lblMasaAdi = new Label();
            lblMasaAdi.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblMasaAdi.ForeColor = Color.FromArgb(34, 40, 49);
            lblMasaAdi.Location = new Point(20, 20);
            lblMasaAdi.Size = new Size(300, 40);
            this.Controls.Add(lblMasaAdi);

            btnHesap = new Button();
            btnHesap.Text = "Hesap";
            btnHesap.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            btnHesap.Size = new Size(220, 50);
            btnHesap.Location = new Point(20, 80);
            btnHesap.BackColor = Color.FromArgb(129, 199, 132);
            btnHesap.ForeColor = Color.FromArgb(34, 40, 49);
            btnHesap.FlatStyle = FlatStyle.Flat;
            btnHesap.Click += (s, e) => HesapClicked?.Invoke(this, EventArgs.Empty);
            this.Controls.Add(btnHesap);

            // Çizgi
            linePanel = new Panel();
            linePanel.Height = 2;
            linePanel.Width = btnHesap.Width;
            linePanel.BackColor = Color.FromArgb(180, 180, 180);
            linePanel.Location = new Point(btnHesap.Left, btnHesap.Bottom + 10);
            this.Controls.Add(linePanel);

            // Kategoriler label
            lblKategoriler = new Label();
            lblKategoriler.Text = "Kategoriler";
            lblKategoriler.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            lblKategoriler.ForeColor = Color.FromArgb(34, 40, 49);
            lblKategoriler.Location = new Point(btnHesap.Left, linePanel.Bottom + 10);
            lblKategoriler.Size = new Size(220, 30);
            this.Controls.Add(lblKategoriler);

            // Kategori butonları
            string[] kategoriler = { "Sıcak", "Soğuk", "Meşrubat" };
            int y = lblKategoriler.Bottom + 10;
            foreach (var kategori in kategoriler)
            {
                Button btnKategori = new Button();
                btnKategori.Text = kategori;
                btnKategori.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                btnKategori.Size = new Size(220, 40);
                btnKategori.Location = new Point(btnHesap.Left, y);
                btnKategori.BackColor = Color.FromArgb(129, 212, 250);
                btnKategori.ForeColor = Color.FromArgb(34, 40, 49);
                btnKategori.FlatStyle = FlatStyle.Flat;
                btnKategori.Click += (s, e) => KategoriClicked?.Invoke(kategori);
                this.Controls.Add(btnKategori);
                kategoriButonlari.Add(btnKategori);
                y += 50;
            }

            // Geri butonu en alta al
            btnGeri = new Button();
            btnGeri.Text = "Geri";
            btnGeri.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnGeri.Size = new Size(100, 40);
            btnGeri.BackColor = Color.FromArgb(129, 212, 250);
            btnGeri.ForeColor = Color.FromArgb(34, 40, 49);
            btnGeri.FlatStyle = FlatStyle.Flat;
            btnGeri.Click += (s, e) => GeriClicked?.Invoke(this, EventArgs.Empty);
            this.Controls.Add(btnGeri);
            // En alta yerleştir
            this.Resize += (s, e) => btnGeri.Location = new Point(btnHesap.Left, this.Height - btnGeri.Height - 20);
            btnGeri.Location = new Point(btnHesap.Left, this.Height - btnGeri.Height - 20);
        }
    }
} 