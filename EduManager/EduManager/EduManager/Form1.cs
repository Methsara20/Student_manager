using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EduManager
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-40HIMS0\SQLEXPRESS02;Initial Catalog=schooldb;Integrated Security=True;");
            con.Open();
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            SqlCommand cnn = new SqlCommand("SELECT Username, Password FROM logintab WHERE Username = '" + txtUsername.Text + "'AND Password'" + txtPassword.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                Main mn = new Main();
                mn.Show();
            }
            else
            {
                MessageBox.Show("Inavalid username or password");
            }
            con.Close();
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
