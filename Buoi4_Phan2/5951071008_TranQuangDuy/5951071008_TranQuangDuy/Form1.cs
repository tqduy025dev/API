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

namespace _5951071008_TranQuangDuy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetStudentRecor();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TQD\SQLEXPRESS;Initial Catalog=DemoCRUD;Integrated Security=Trueq");
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void GetStudentRecor()
        {

            SqlCommand cmd = new SqlCommand("SELECT * FROM Students", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            StudentRecorData.DataSource = dt;

        }

        private bool IsValidData()
        {
            if (txtHo.Text == String.Empty
                || txtTen.Text == String.Empty
                || txtDiaChi.Text == String.Empty
                || string.IsNullOrEmpty(txtSDT.Text)
                || string.IsNullOrEmpty(txtSBD.Text))
            {
                MessageBox.Show("Có chỗ chưa nhập dữ liệu!!!", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Students VALUES" + "(@Name, @FatherName, RollNumber, @Address, @Mobile)", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Name", txtTen.Text);
                cmd.Parameters.AddWithValue("@FatherName", txtHo.Text);
                cmd.Parameters.AddWithValue("@RollNumber", txtSBD.Text);
                cmd.Parameters.AddWithValue("@Address", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@Mobile", txtSDT.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                GetStudentRecor();
            }
        }

        public int StudentID;
        private void StudentRecorData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            StudentID = Convert.ToInt32(StudentRecorData.Rows[0].Cells[0].Value);
            txtHo.Text = StudentRecorData.SelectedRows[0].Cells[1].Value.ToString();
            txtTen.Text = StudentRecorData.SelectedRows[0].Cells[2].Value.ToString();
            txtSBD.Text = StudentRecorData.SelectedRows[0].Cells[3].Value.ToString();
            txtDiaChi.Text = StudentRecorData.SelectedRows[0].Cells[4].Value.ToString();
            txtSDT.Text = StudentRecorData.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void ResetData()
        {
            txtHo.Text = "";
            txtDiaChi.Text = "";
            txtSBD.Text = "";
            txtSDT.Text = "";
            txtTen.Text = "";

        }



        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (StudentID > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE Students SET " +
                    "Name = @Name, FatherName = @FatherName, "
                    + "RollNumber = @RollNumber, Address = @Address, "
                    + "Mobile = @Mobile WHERE StudentID = @ID", con);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name", txtTen.Text);
                cmd.Parameters.AddWithValue("@FatherName", txtHo.Text);
                cmd.Parameters.AddWithValue("@RollNumber", txtSBD.Text);
                cmd.Parameters.AddWithValue("@Address", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@Mobile", txtSDT.Text);
                cmd.Parameters.AddWithValue("@ID", this.StudentID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                GetStudentRecor();
                ResetData();

            }
            else
            {
                MessageBox.Show("Cập nhật bị lỗi!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (StudentID > 0)
            {
                SqlCommand cmd = new SqlCommand("Delete from Students where StudentID = @ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", this.StudentID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                GetStudentRecor();
                ResetData();

            }
            else
            {
                MessageBox.Show("Cập nhật bị lỗi!!", "Lỗi!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
