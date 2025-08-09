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
    public partial class Form1 : Form
    {
        private UcMasalar ucMasalar;
        public Form1()
        {
            InitializeComponent();
            // Panel'in adını kontrol et
            if (panelContent == null)
            {
                MessageBox.Show("panelContent paneli bulunamadı!");
                return;
            }
            ucMasalar = new UcMasalar();
            btnMasalar.Click += btnMasalar2_Click;
            btnSiparisler.Click += btnSiparisler_Click;
        }
          
        private void Form1_Load(object sender, EventArgs e)
        {
            PaneliTemizleVeUserControlYukle(ucMasalar);
        }
        private void PaneliTemizleVeUserControlYukle(UserControl yeniControl)
        {
            panelContent.Controls.Clear();
            yeniControl.Dock = DockStyle.Fill;
            yeniControl.BackColor = Color.Transparent; // Modern ve rahatlatıcı
            panelContent.Controls.Add(yeniControl);
        }
        private void btnMasalar2_Click(object sender, EventArgs e)
        {
            PaneliTemizleVeUserControlYukle(ucMasalar);
           
        }

        private void btnSiparisler_Click(object sender, EventArgs e)
        {
            PaneliTemizleVeUserControlYukle(new UcSiparisler());
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            // UcMasalar'dan ödenmemiş masaları al
            var unpaid = ucMasalar.GetUnpaidTables();
            if (unpaid.Count > 0)
            {
                string msg = "Ödenmemiş hesaplar var:\n" + string.Join("\n", unpaid) + "\nYine de çıkmak istiyor musunuz?";
                var result = MessageBox.Show(msg, "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                    Application.Exit();
            }
            else
            {
                Application.Exit();
            }
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

       

 
}
}
