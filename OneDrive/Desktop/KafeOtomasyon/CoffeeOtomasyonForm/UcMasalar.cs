using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace CoffeeOtomasyonForm
{
    public partial class UcMasalar : UserControl
    {
        private List<UcMasaKart> masaKartlari = new List<UcMasaKart>();
        private Panel kategoriPanel;
        private Panel icerikPanel;
        private Label lblKategoriBaslik;
        private Guna2Button btnGeri;
        private string[] icecekKategorileri = new string[] { "Sıcak İçecekler", "Soğuk İçecekler", "Kahveler", "Çaylar" };
        private string aktifKategori = "Sıcak İçecekler";
        // Masaya içerik girildi mi bilgisini tut
        private HashSet<int> icerikGirilenMasalar = new HashSet<int>();
        // Her masa için içerik listesi
        private Dictionary<int, List<(string ad, decimal fiyat)>> masaIcerikleri = new Dictionary<int, List<(string ad, decimal fiyat)>>();
        private UcMasaIslem ucMasaIslem;
        private UcHesap ucHesap;
        private UcIcerik ucIcerik;

        public UcMasalar()
        {
            InitializeComponent();
            this.Load += UcMasalar_Load;
        }

        private void UcMasalar_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.Transparent;
            flowLayoutPanelMasalar.SuspendLayout();
            this.SuspendLayout();
            flowLayoutPanelMasalar.Controls.Clear();
            masaKartlari.Clear();
            icerikGirilenMasalar.Clear();
            int masaSayisi = 10; // Örnek veri

            for (int i = 1; i <= masaSayisi; i++)
            {
                UcMasaKart masa = new UcMasaKart();
                masa.MasaAdi = $"Masa {i}";
                masa.Durum = i % 2 == 0 ? "Dolu" : "Boş";
                masa.MasaId = i;
                masa.Width = 120;
                masa.Height = 100;
                masa.Margin = new Padding(5);
                masa.SetIconColor(Color.Gray); // Başlangıçta hepsi gri
                masaKartlari.Add(masa);
                flowLayoutPanelMasalar.Controls.Add(masa);
                masa.MouseClick += MasaKart_MouseClick;
            }
            flowLayoutPanelMasalar.ResumeLayout();
            this.ResumeLayout();
        }

        private void MasaKart_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && sender is UcMasaKart masa)
            {
                MasaKart_Click(masa);
            }
        }

        // Sadece kart arka planına tıklanınca kategori paneli aç
        private void MasaKart_Click(UcMasaKart masa)
        {
            seciliMasa = masa;
            flowLayoutPanelMasalar.Visible = false;
            ShowMasaIslem(masa);
        }

        // Seçili masa referansı
        private UcMasaKart seciliMasa = null;

        private void ShowMasaIslem(UcMasaKart masa)
        {
            // Eskiyi gizle/çıkar
            if (ucMasaIslem != null) { this.Controls.Remove(ucMasaIslem); ucMasaIslem.Dispose(); }
            ucMasaIslem = new UcMasaIslem();
            ucMasaIslem.GeriClicked += (s, e) => {
                ucMasaIslem.Visible = false;
                flowLayoutPanelMasalar.Visible = true;
            };
            ucMasaIslem.HesapClicked += (s, e) => {
                ShowHesap(masa);
            };
            ucMasaIslem.KategoriClicked += (kategori) => {
                ShowIcerik(masa, kategori);
            };
            this.Controls.Add(ucMasaIslem);
            ucMasaIslem.MasaAdi = masa.MasaAdi;
            ucMasaIslem.BringToFront();
            ucMasaIslem.Visible = true;
        }

        private void ShowIcerik(UcMasaKart masa, string kategori)
        {
            if (ucIcerik != null) { this.Controls.Remove(ucIcerik); ucIcerik.Dispose(); }
            ucIcerik = new UcIcerik();
            ucIcerik.GeriClicked += (s, e) => {
                ucIcerik.Visible = false;
                ucMasaIslem.Visible = true;
            };
            ucIcerik.IcerikEklendi += (ad, adet, fiyat) => {
                for (int i = 0; i < adet; i++)
                    MasaIcerikEkle(masa.MasaId, ad, fiyat);
                masa.SetIconColor(Color.Red);
                ucIcerik.Visible = false;
                ucMasaIslem.Visible = true;
            };
            this.Controls.Add(ucIcerik);
            ucIcerik.SetKategori(kategori);
            ucIcerik.BringToFront();
            ucIcerik.Visible = true;
            ucMasaIslem.Visible = false;
        }

        private void ShowHesap(UcMasaKart masa)
        {
            if (ucHesap != null) { this.Controls.Remove(ucHesap); ucHesap.Dispose(); }
            ucHesap = new UcHesap();
            ucHesap.GeriClicked += (s, e) => {
                ucHesap.Visible = false;
                ucMasaIslem.Visible = true;
            };
            ucHesap.HesapOdedildi += (s, e) => {
                // Hesabı sil
                if (masaIcerikleri.ContainsKey(masa.MasaId))
                    masaIcerikleri[masa.MasaId].Clear();
                masa.SetIconColor(Color.Gray);
                ucHesap.Visible = false;
                ucMasaIslem.Visible = true;
            };
            this.Controls.Add(ucHesap);
            var icerikler = masaIcerikleri.ContainsKey(masa.MasaId) ? masaIcerikleri[masa.MasaId] : new List<(string, decimal)>();
            ucHesap.SetIcerikler(icerikler);
            ucHesap.BringToFront();
            ucHesap.Visible = true;
            ucMasaIslem.Visible = false;
        }

        // Masaya içerik ekle (ikonunu kırmızı yap)
        private void MasaIcerikEkle(int masaId, string ad, decimal fiyat)
        {
            icerikGirilenMasalar.Add(masaId);
            var masa = masaKartlari.FirstOrDefault(m => m.MasaId == masaId);
            if (masa != null)
                masa.SetIconColor(Color.Red);
            if (!masaIcerikleri.ContainsKey(masaId))
                masaIcerikleri[masaId] = new List<(string, decimal)>();
            masaIcerikleri[masaId].Add((ad, fiyat));
        }

        // Kategoriye uygun örnek içecek ve fiyat
        private (string ad, decimal fiyat) OrnekIcerikVeFiyat(string kategori)
        {
            if (kategori == "Sıcak İçecekler") return ("Çay", 15);
            if (kategori == "Soğuk İçecekler") return ("Limonata", 30);
            if (kategori == "Kahveler") return ("Espresso", 40);
            if (kategori == "Çaylar") return ("Yeşil Çay", 25);
            return ("Ürün", 0);
        }

        private void GuncelleKategoriIcerik(string kategori)
        {
            if (lblKategoriBaslik != null)
            {
                lblKategoriBaslik.Text = kategori;
            }
            // İçerik panelinde başlık dışındaki kontrolleri temizle
            while (icerikPanel.Controls.Count > 1)
                icerikPanel.Controls.RemoveAt(1);

            // Kategoriye uygun örnek içecek ve fiyat
            var (ad, fiyat) = OrnekIcerikVeFiyat(kategori);
            Button btnIck = new Button();
            btnIck.Text = ad;
            btnIck.Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold);
            btnIck.Size = new Size(220, 70);
            btnIck.Location = new Point(40, 70);
            btnIck.BackColor = Color.FromArgb(129, 212, 250);
            btnIck.ForeColor = Color.FromArgb(34, 40, 49);
            btnIck.FlatStyle = FlatStyle.Flat;
            btnIck.TextAlign = ContentAlignment.MiddleLeft;
            btnIck.Padding = new Padding(16, 0, 0, 0);
            btnIck.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnIck.Click += (s, e) => {
                var result = MessageBox.Show($"{ad} + eklenecek. Onaylıyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes && seciliMasa != null)
                {
                    MasaIcerikEkle(seciliMasa.MasaId, ad, fiyat);
                }
            };
            icerikPanel.Controls.Add(btnIck);

            // Fiyatı sağ alt köşeye ekle (Label olarak butonun üstüne)
            Label lblFiyat = new Label();
            lblFiyat.Text = $"{fiyat}₺";
            lblFiyat.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold);
            lblFiyat.ForeColor = Color.FromArgb(34, 40, 49);
            lblFiyat.BackColor = Color.Transparent;
            lblFiyat.AutoSize = true;
            lblFiyat.Parent = btnIck;
            lblFiyat.Location = new Point(btnIck.Width - 60, btnIck.Height - 28);
            btnIck.Controls.Add(lblFiyat);

            // Çizgi (kategori altı)
            Panel line = new Panel();
            line.Height = 2;
            line.Width = icerikPanel.Width - 80;
            line.BackColor = Color.FromArgb(180, 180, 180);
            line.Location = new Point(40, 150);
            line.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            icerikPanel.Controls.Add(line);

            // Hesap butonu
            Button btnHesap = new Button();
            btnHesap.Text = "Hesap";
            btnHesap.Font = new System.Drawing.Font("Segoe UI", 13, System.Drawing.FontStyle.Bold);
            btnHesap.Size = new Size(220, 50);
            btnHesap.Location = new Point(40, 170);
            btnHesap.BackColor = Color.FromArgb(129, 199, 132);
            btnHesap.ForeColor = Color.FromArgb(34, 40, 49);
            btnHesap.FlatStyle = FlatStyle.Flat;
            btnHesap.Click += (s, e) => HesapGoster();
            icerikPanel.Controls.Add(btnHesap);

            if (seciliMasa != null)
            {
                if (icerikGirilenMasalar.Contains(seciliMasa.MasaId))
                    seciliMasa.SetIconColor(Color.Red);
                else
                    seciliMasa.SetIconColor(Color.Gray);
            }
        }

        private void HesapGoster()
        {
            if (seciliMasa == null) return;
            int masaId = seciliMasa.MasaId;
            if (!masaIcerikleri.ContainsKey(masaId) || masaIcerikleri[masaId].Count == 0)
            {
                MessageBox.Show("Bu masada hiç içerik yok.", "Hesap", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var icerikler = masaIcerikleri[masaId];
            StringBuilder sb = new StringBuilder();
            decimal toplam = 0;
            foreach (var (ad, fiyat) in icerikler)
            {
                sb.AppendLine($"{ad} - {fiyat}₺");
                toplam += fiyat;
            }
            sb.AppendLine($"---------------------\nToplam: {toplam}₺");
            MessageBox.Show(sb.ToString(), $"Masa {masaId} Hesabı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnGeri_Click(object sender, EventArgs e)
        {
            if (kategoriPanel != null)
            {
                kategoriPanel.Visible = false;
            }
            if (icerikPanel != null)
            {
                icerikPanel.Visible = false;
            }
            flowLayoutPanelMasalar.Visible = true;
            seciliMasa = null;
        }

        private void btnMasalar2_Click(object sender, EventArgs e)
        {

        }

        public List<string> GetUnpaidTables()
        {
            var result = new List<string>();
            foreach (var masa in masaKartlari)
            {
                if (masaIcerikleri.ContainsKey(masa.MasaId) && masaIcerikleri[masa.MasaId].Count > 0)
                {
                    result.Add(masa.MasaAdi);
                }
            }
            return result;
        }
    
    }
}
