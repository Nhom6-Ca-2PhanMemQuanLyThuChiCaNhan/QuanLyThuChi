using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuChi
{
    public class LoginResult
    {
        public static int Check_User(string pUser, string pPass)
        {
            SqlDataAdapter daUser = new SqlDataAdapter("select * from QL_NGUOI_DUNG where MANGUOIDUNG='" + pUser + "' and MATKHAU ='" + pPass + "'", Properties.Settings.Default.ConnectStr);
            DataTable dt = new DataTable();
            daUser.Fill(dt);
            if (dt.Rows.Count == 0)
                return 0;// User không tồn tại
            else if (dt.Rows[0][2] == null || dt.Rows[0][2].ToString() == "False")
            {
                return 1;// Không hoạt động
            }
            return 2;// Đăng nhập thành công
        }

        public int Check_Config()
        {
            if (Properties.Settings.Default.ConnectStr == string.Empty)
                return 1;  //chuoi cau hinh khong ton tai
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectStr);
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                return 0;  // ket noi thanh cong , chuoi cau hinh hop le

            }
            catch
            {
                return 2; //chuoi cai hinh khong phu hop
            }

        }

        public  DataTable GetServerName()
        {
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            System.Data.DataTable table = instance.GetDataSources();
            return table;
        }

        public List<string> GetDatabaseName(string pServerName, string pUser, string pPass)
        {
            List<string> _list = new List<string>();
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT name FROM sys.databases", "Data Source="+pServerName+" ;Initial Catalog=" + "master" + ";User ID=" + pUser + ";pwd = " + pPass + "");
                da.Fill(dt);
                foreach (System.Data.DataRow row in dt.Rows)               
                {
                    foreach (System.Data.DataColumn col in dt.Columns)
                    {
                        _list.Add(row[col].ToString());
                    }
                }
            }
            catch
                {
                    return null;
                }
            return _list;
        }

        public void ChangeConnectionString(string pServerName, string pDataBase, string pUser, string pPass)
        {
            QuanLyThuChi.Properties.Settings.Default.ConnectStr = "Data Source=" + pServerName + ";Initial Catalog=" + pDataBase + ";User ID=" + pUser + ";pwd = " + pPass + "";
            Properties.Settings.Default.Save();
        }
    }
}
