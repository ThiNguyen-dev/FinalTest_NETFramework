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

namespace QLThuNhap
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=LAPTOP-5NAK4AVR;Initial Catalog=QLKhoanThuNhap;User ID=sa;Password=123";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from LoaiHinhThuNhap";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaLHTN.ReadOnly = true;
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtMaLHTN.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtTenLHTN.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "insert into LoaiHinhThuNhap values ('"+txtMaLHTN.Text+ "',N'" + txtTenLHTN.Text +"')";
            command.ExecuteNonQuery();
            loaddata();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from LoaiHinhThuNhap where MaLoaiHinhThuNhap = '" + txtMaLHTN.Text + "'";
            command.ExecuteNonQuery();
            loaddata();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update LoaiHinhThuNhap set TenLoaiHinhThuNhap = N'" + txtTenLHTN.Text + "'where MaLoaiHinhThuNhap = '"+txtMaLHTN.Text +"'";
            command.ExecuteNonQuery();
            loaddata();
        }
    }
}
