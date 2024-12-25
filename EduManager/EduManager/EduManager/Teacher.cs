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
    public partial class Teacher : Form
    {
        public Teacher()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-40HIMS0\SQLEXPRESS02;Initial Catalog=schooldb;Integrated Security=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("INSERT INTO teachertab VALUES (@teacherid,@teachername,@gender,@phone)", con);
            cnn.Parameters.AddWithValue("@Teacherid", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@TeacherName", textBox2.Text);
            cnn.Parameters.AddWithValue("@Gender", textBox3.Text);
            cnn.Parameters.AddWithValue("@Phone", textBox4.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Save Successfully.....!!!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-40HIMS0\SQLEXPRESS02;Initial Catalog=schooldb;Integrated Security=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("SELECT * FROM teachertab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-40HIMS0\SQLEXPRESS02;Initial Catalog=schooldb;Integrated Security=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("UPDATE teachertab SET teachername=@teachername, gender=@gender,phone=@phone WHERE teacherid=@teacherid", con);
            cnn.Parameters.AddWithValue("@Teacherid", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@TeacherName", textBox2.Text);
            cnn.Parameters.AddWithValue("@Gender", textBox3.Text);
            cnn.Parameters.AddWithValue("@Phone", textBox4.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Update Successfully.....!!!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-40HIMS0\SQLEXPRESS02;Initial Catalog=schooldb;Integrated Security=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("DELETE teachertab WHERE teacherid = @teacherid", con);
            cnn.Parameters.AddWithValue("@TeacherId", int.Parse(textBox1.Text));


            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted Successfully.....!!!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-40HIMS0\SQLEXPRESS02;Initial Catalog=schooldb;Integrated Security=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("SELECT * FROM teachertab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Teacher_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-40HIMS0\SQLEXPRESS02;Initial Catalog=schooldb;Integrated Security=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("SELECT * FROM teachertab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
