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

namespace EduManager
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            display();
            display1();
            display2();
            display3();
        }

        private void display()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-40HIMS0\SQLEXPRESS02;Initial Catalog=schooldb;Integrated Security=True;");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM studentid", con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if(count > 0)
            {
                lblCount.Text = Convert.ToString(count.ToString());
            }
            else
            {
                lblCount.Text = "0";
            }

            con.Close();
        }

        private void display1()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-40HIMS0\SQLEXPRESS02;Initial Catalog=schooldb;Integrated Security=True;");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM subtab", con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                lblCount1.Text = Convert.ToString(count.ToString());
            }
            else
            {
                lblCount1.Text = "0";
            }

            con.Close();
        }

        private void display2()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-40HIMS0\SQLEXPRESS02;Initial Catalog=schooldb;Integrated Security=True;");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM teachertab", con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                lblCount1.Text = Convert.ToString(count.ToString());
            }
            else
            {
                lblCount1.Text = "0";
            }

            con.Close();
        }

        private void display3()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-40HIMS0\SQLEXPRESS02;Initial Catalog=schooldb;Integrated Security=True;");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM entab", con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                lblCount1.Text = Convert.ToString(count.ToString());
            }
            else
            {
                lblCount1.Text = "0";
            }

            con.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
