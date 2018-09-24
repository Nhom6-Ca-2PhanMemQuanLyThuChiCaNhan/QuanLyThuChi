using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace QuanLyThuChi
{
    public class LoginResult
    {
        public static LoginResult Invalid;
        public static LoginResult Disabled;
        public static LoginResult Success;
        public static int  Check_User(string pUser, string pPass)
        {
            SqlDataAdapter daUser = new SqlDataAdapter("select * from QL_NGUOI_DUNG where MANGUOIDUNG='" + pUser + "' and MATKHAU ='" + pPass + "'", Properties.Settings.Default.KetNoi);
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

        public void Void()
        { }
    }
}
