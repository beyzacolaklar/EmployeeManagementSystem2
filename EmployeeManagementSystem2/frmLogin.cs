using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagementSystem2
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("YOUR_CONNECTION_STRING");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Username=@u AND Password=@p", conn);
            cmd.Parameters.AddWithValue("@u", txtUsername.Text);
            cmd.Parameters.AddWithValue("@p", txtPassword.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Giriş Başarılı!");
                frmMain main = new frmMain(txtUsername.Text); // kullanıcı adı geç
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre.");
            }
            conn.Close();

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Şifreler uyuşmuyor.");
                return;
            }
            SqlCommand cmd = new SqlCommand("INSERT INTO Users (Username, Password) VALUES (@u, @p)", conn);
            cmd.Parameters.AddWithValue("@u", txtUsername.Text);
            cmd.Parameters.AddWithValue("@p", txtPassword.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kayıt başarılı!");

        }
    }
}
