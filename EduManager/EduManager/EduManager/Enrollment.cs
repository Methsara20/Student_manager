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
    public partial class Enrollment : Form
    {
        public Enrollment()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                dateTimePicker2.CustomFormat = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-40HIMS0\SQLEXPRESS02;Initial Catalog=schooldb;Integrated Security=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("INSERT INTO entab VALUES (@eid,@studentname,@section,@enrolldate)", con);
            cnn.Parameters.AddWithValue("@EId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@StudentName", textBox2.Text);
            cnn.Parameters.AddWithValue("@Section", textBox3.Text);
            cnn.Parameters.AddWithValue("@EnrollDate", dateTimePicker2.Value);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Save Successfully.....!!!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-40HIMS0\SQLEXPRESS02;Initial Catalog=schooldb;Integrated Security=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("SELECT * FROM entab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-40HIMS0\SQLEXPRESS02;Initial Catalog=schooldb;Integrated Security=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("UPDATE entab SET studentname=@studentname, section=@section, enrolldate=@enrolldate WHERE eid=@eid", con);
            cnn.Parameters.AddWithValue("@EId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@StudentName", textBox2.Text);
            cnn.Parameters.AddWithValue("@Section", textBox3.Text);
            cnn.Parameters.AddWithValue("@EnrollDate", dateTimePicker2.Value);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Update Successfully.....!!!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-40HIMS0\SQLEXPRESS02;Initial Catalog=schooldb;Integrated Security=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("DELETE entab WHERE eid = @eid", con);
            cnn.Parameters.AddWithValue("@EId", int.Parse(textBox1.Text));


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

            SqlCommand cnn = new SqlCommand("SELECT * FROM entab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void Enrollment_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-40HIMS0\SQLEXPRESS02;Initial Catalog=schooldb;Integrated Security=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("SELECT * FROM entab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
