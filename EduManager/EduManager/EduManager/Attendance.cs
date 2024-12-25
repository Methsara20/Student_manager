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
    public partial class Attendance : Form
    {
        public Attendance()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-40HIMS0\SQLEXPRESS02;Initial Catalog=schooldb;Integrated Security=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("INSERT INTO attentab VALUES (@aid,@studentname,@status)", con);
            cnn.Parameters.AddWithValue("@AId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@StudentName", textBox2.Text);
            cnn.Parameters.AddWithValue("@Status", textBox3.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Save Successfully.....!!!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-40HIMS0\SQLEXPRESS02;Initial Catalog=schooldb;Integrated Security=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("SELECT * FROM attentab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-40HIMS0\SQLEXPRESS02;Initial Catalog=schooldb;Integrated Security=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("UPDATE attentab SET studentname=@studentname, status=@status WHERE aid=@aid", con);
            cnn.Parameters.AddWithValue("@AId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@StudentName", textBox2.Text);
            cnn.Parameters.AddWithValue("@Status", textBox3.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Update Successfully.....!!!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-40HIMS0\SQLEXPRESS02;Initial Catalog=schooldb;Integrated Security=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("DELETE attentab WHERE aid = @aid", con);
            cnn.Parameters.AddWithValue("@AId", int.Parse(textBox1.Text));


            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted Successfully.....!!!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-40HIMS0\SQLEXPRESS02;Initial Catalog=schooldb;Integrated Security=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("SELECT * FROM attentab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-40HIMS0\SQLEXPRESS02;Initial Catalog=schooldb;Integrated Security=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("SELECT * FROM attentab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
