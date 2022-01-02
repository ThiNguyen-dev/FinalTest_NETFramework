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
    public partial class Form2 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=LAPTOP-5NAK4AVR;Initial Catalog=QLKhoanThuNhap;User ID=sa;Password=123";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        ComboBox cb = new ComboBox();

        
        

        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select MaKhoan, SoTien, ThoiGian, GhiChu, TenLoaiHinhThuNhap from KhoanThuNhap inner join LoaiHinhThuNhap on KhoanThuNhap.MaLoaiHinhThuNhap = LoaiHinhThuNhap.MaLoaiHinhThuNhap";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            
        }
        public Form2()
        {
            InitializeComponent();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKhoan.ReadOnly = true;
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtMaKhoan.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtSoTien.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            dateTimeTG.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txtGhiChu.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            cbLoaiHinh.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
            string sql = "select * from LoaiHinhThuNhap";
            cbLoaiHinh.DataSource = Database.Singleton.loadCB(sql);
            cbLoaiHinh.DisplayMember = "TenLoaiHinhThuNhap";
            cbLoaiHinh.ValueMember = "MaLoaiHinhThuNhap";
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            
            command = connection.CreateCommand();
            command.CommandText = "insert into KhoanThuNhap values ('"+ txtMaKhoan.Text +"', '"+ txtSoTien.Text +"', '"+ dateTimeTG.Text +"', N'"+ txtGhiChu.Text+"', N'"+ Convert.ToString(cbLoaiHinh.SelectedValue) +"')";
            command.ExecuteNonQuery();
            loaddata();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from KhoanThuNhap where MaKhoan = '" + txtMaKhoan.Text + "'";
            command.ExecuteNonQuery();
            loaddata();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update KhoanThuNhap set SoTien = '"+ txtSoTien.Text+"',ThoiGian ='" +dateTimeTG.Text+ "',GhiChu = N'" + txtGhiChu.Text + "',MaLoaiHinhThuNhap = N'" + Convert.ToString(cbLoaiHinh.SelectedValue) +"' where MaKhoan = '"+txtMaKhoan.Text+"'";
            command.ExecuteNonQuery();
            loaddata();
        }
    }
}
