using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace QLThuNhap
{
     class Database
    {
        private SqlConnection connect;
        private SqlCommandBuilder cmd;
        string str = "Data Source=LAPTOP-5NAK4AVR;Initial Catalog=QLKhoanThuNhap;User ID=sa;Password=123";
        SqlDataAdapter adapter = new SqlDataAdapter();
        private static Database singleton = null;

        
        
        public static Database Singleton
        {
            get
            {
                if (singleton == null)
                {
                    singleton = new Database();
                }
                return singleton;
            }
        }
        private Database()
        {
            this.connect = new SqlConnection(str);
        }
        ComboBox cb = new ComboBox();
        public DataTable loadCB(string sql)
        {
            DataTable table = new DataTable();
            adapter = new SqlDataAdapter(sql, this.connect);
            adapter.Fill(table);
            return table;
        }
    }
}
