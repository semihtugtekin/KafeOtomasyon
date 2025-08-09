using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CoffeeOtomasyonForm
{
    public partial class UcHesap : UserControl
    {
        private ListView listViewIcerik;
        private Label lblToplam;
        private Button btnGeri;
        public event EventHandler GeriClicked;
        public event EventHandler HesapOdedildi;
        private Button btnHesapOdedildi;

        public UcHesap()
        {
            InitializeComponent();
            InitUI();
        }

        private void InitUI()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.WhiteSmoke;

            listViewIcerik = new ListView();
            listViewIcerik.View = View.Details;
            listViewIcerik.Columns.Add("İçerik", 180);
            listViewIcerik.Columns.Add("Fiyat", 80);
            listViewIcerik.FullRowSelect = true;
            listViewIcerik.Location = new Point(20, 20);
            listViewIcerik.Size = new Size(900, 500);
            this.Controls.Add(listViewIcerik);

            lblToplam = new Label();
            lblToplam.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblToplam.ForeColor = Color.FromArgb(34, 40, 49);
            lblToplam.Location = new Point(20, listViewIcerik.Bottom + 20);
            lblToplam.Size = new Size(300, 40);
            this.Controls.Add(lblToplam);

            btnGeri = new Button();
            btnGeri.Text = "Geri";
            btnGeri.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnGeri.Size = new Size(100, 40);
            btnGeri.Location = new Point(20, lblToplam.Bottom + 10);
            btnGeri.BackColor = Color.FromArgb(129, 199, 132);
            btnGeri.ForeColor = Color.FromArgb(34, 40, 49);
            btnGeri.FlatStyle = FlatStyle.Flat;
            btnGeri.Click += (s, e) => GeriClicked?.Invoke(this, EventArgs.Empty);
            this.Controls.Add(btnGeri);

            // Hesap ödendi butonu
            btnHesapOdedildi = new Button();
            btnHesapOdedildi.Text = "Hesap ödendi";
            btnHesapOdedildi.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnHesapOdedildi.Size = new Size(180, 40);
            btnHesapOdedildi.Location = new Point(140, lblToplam.Bottom + 10);
            btnHesapOdedildi.BackColor = Color.FromArgb(255, 99, 71);
            btnHesapOdedildi.ForeColor = Color.White;
            btnHesapOdedildi.FlatStyle = FlatStyle.Flat;
            btnHesapOdedildi.Click += (s, e) => {
                var result = MessageBox.Show("Hesap silinecek. Onaylıyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                    HesapOdedildi?.Invoke(this, EventArgs.Empty);
            };
            this.Controls.Add(btnHesapOdedildi);
        }

        public void SetIcerikler(List<(string ad, decimal fiyat)> icerikler)
        {
            listViewIcerik.Items.Clear();
            decimal toplam = 0;
            foreach (var (ad, fiyat) in icerikler)
            {
                var item = new ListViewItem(ad);
                item.SubItems.Add($"{fiyat}₺");
                listViewIcerik.Items.Add(item);
                toplam += fiyat;
            }
            lblToplam.Text = $"Toplam: {toplam}₺";
        }

        private void UcHesap_Load(object sender, EventArgs e)
        {

        }
    }
} 