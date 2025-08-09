using System;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Drawing;

namespace CoffeeOtomasyonForm
{
    public partial class Form2 : Form
    {
        private Guna2TextBox txtUsername;
        private Guna2TextBox txtPassword;
        private Guna2Button btnLogin;
        private Guna2HtmlLabel lblTitle;

        public Form2()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Width = 420;
            this.Height = 600;
            this.BackColor = Color.FromArgb(34, 40, 49);
            this.Padding = new Padding(0);
            // Modern panel
            var panel = new Guna2Panel();
            panel.Size = new Size(370, 550);
            panel.Location = new Point((this.Width - panel.Width) / 2, (this.Height - panel.Height) / 2);
            panel.BorderRadius = 20;
            panel.FillColor = Color.White; // Tam opak, hata vermez
            panel.ShadowDecoration.Enabled = true;
            panel.ShadowDecoration.Depth = 10;
            this.Controls.Add(panel);

            // Kafe İsmi başlık (klasik Label)
            var lblKafeIsmi = new Label();
            lblKafeIsmi.Text = "Kafe İsmi";
            lblKafeIsmi.ForeColor = Color.FromArgb(34, 40, 49);
            lblKafeIsmi.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblKafeIsmi.AutoSize = false;
            lblKafeIsmi.TextAlign = ContentAlignment.MiddleCenter;
            lblKafeIsmi.Size = new Size(340, 40);
            lblKafeIsmi.Location = new Point(15, 30);
            lblKafeIsmi.BackColor = Color.Transparent;
            panel.Controls.Add(lblKafeIsmi);

            // Kullanıcı Girişi label (klasik Label)
            var lblGiris = new Label();
            lblGiris.Text = "Kullanıcı Girişi";
            lblGiris.ForeColor = Color.FromArgb(80, 80, 80);
            lblGiris.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblGiris.AutoSize = false;
            lblGiris.TextAlign = ContentAlignment.MiddleCenter;
            lblGiris.Size = new Size(340, 30);
            lblGiris.Location = new Point(15, 80);
            lblGiris.BackColor = Color.Transparent;
            panel.Controls.Add(lblGiris);

            txtUsername = new Guna2TextBox();
            txtUsername.PlaceholderText = "Kullanıcı Adı";
            txtUsername.Font = new Font("Segoe UI", 12);
            txtUsername.Size = new Size(340, 40);
            txtUsername.Location = new Point(15, 130);
            txtUsername.BorderRadius = 15;
            txtUsername.FillColor = Color.White;
            panel.Controls.Add(txtUsername);

            txtPassword = new Guna2TextBox();
            txtPassword.PlaceholderText = "Şifre";
            txtPassword.Font = new Font("Segoe UI", 12);
            txtPassword.Size = new Size(340, 40);
            txtPassword.Location = new Point(15, 195);
            txtPassword.PasswordChar = '●';
            txtPassword.BorderRadius = 15;
            txtPassword.FillColor = Color.White;
            panel.Controls.Add(txtPassword);

            btnLogin = new Guna2Button();
            btnLogin.Text = "Giriş Yap";
            btnLogin.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            btnLogin.Size = new Size(340, 45);
            btnLogin.Location = new Point(15, 270);
            btnLogin.BorderRadius = 20;
            btnLogin.FillColor = Color.FromArgb(129, 199, 132);
            btnLogin.ForeColor = Color.FromArgb(34, 40, 49);
            btnLogin.Click += BtnLogin_Click;
            panel.Controls.Add(btnLogin);
        }

        private void InitializeLoginControls()
        {
            lblTitle = new Guna2HtmlLabel();
            lblTitle.Text = "Kafe Otomasyon Giriş";
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 18, System.Drawing.FontStyle.Bold);
            lblTitle.AutoSize = false;
            lblTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            lblTitle.Size = new System.Drawing.Size(360, 40);
            lblTitle.Location = new System.Drawing.Point(20, 30);
            this.Controls.Add(lblTitle);

            txtUsername = new Guna2TextBox();
            txtUsername.PlaceholderText = "Kullanıcı Adı";
            txtUsername.Font = new System.Drawing.Font("Segoe UI", 12);
            txtUsername.Size = new System.Drawing.Size(360, 40);
            txtUsername.Location = new System.Drawing.Point(20, 90);
            txtUsername.BorderRadius = 15;
            this.Controls.Add(txtUsername);

            txtPassword = new Guna2TextBox();
            txtPassword.PlaceholderText = "Şifre";
            txtPassword.Font = new System.Drawing.Font("Segoe UI", 12);
            txtPassword.Size = new System.Drawing.Size(360, 40);
            txtPassword.Location = new System.Drawing.Point(20, 150);
            txtPassword.PasswordChar = '●';
            txtPassword.BorderRadius = 15;
            this.Controls.Add(txtPassword);

            btnLogin = new Guna2Button();
            btnLogin.Text = "Giriş Yap";
            btnLogin.Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold);
            btnLogin.Size = new System.Drawing.Size(360, 45);
            btnLogin.Location = new System.Drawing.Point(20, 210);
            btnLogin.BorderRadius = 20;
            btnLogin.FillColor = System.Drawing.Color.FromArgb(57, 62, 70);
            btnLogin.Click += BtnLogin_Click;
            this.Controls.Add(btnLogin);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Admin" && txtPassword.Text == "1234")
            {
                this.Hide();
                Form1 mainForm = new Form1();
                mainForm.FormClosed += (s, args) => this.Close();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
} 