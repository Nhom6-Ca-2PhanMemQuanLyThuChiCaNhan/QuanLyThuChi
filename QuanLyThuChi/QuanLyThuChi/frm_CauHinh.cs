using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuChi
{
    public partial class frm_CauHinh : Form
    {
        LoginResult CauHinh = new LoginResult();
        public frm_CauHinh()
        {
            InitializeComponent();
        }

        private void cb_Server_DropDown(object sender, EventArgs e)
        {
            DataTable dt = CauHinh.GetServerName();
            cb_Server.Items.Clear();
            foreach (System.Data.DataRow row in dt.Rows)
            {
                foreach (System.Data.DataColumn col in dt.Columns)
                {
                    cb_Server.Items.Add(row[col]);
                }
            }

        }

        private void cb_Database_DropDown(object sender, EventArgs e)
        {
            cb_Database.Items.Clear();
            List<string> _list = CauHinh.GetDatabaseName(cb_Server.Text, txt_UserName.Text, txt_Password.Text);
            if (_list == null)
            {
                MessageBox.Show("Thông tin cấu hình chưa chính xác");
                return;
            }
            foreach (string item in _list)
            {
                cb_Database.Items.Add(item);
            }

        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            CauHinh.ChangeConnectionString( cb_Server.Text, cb_Database.Text, txt_UserName.Text, txt_Password.Text);
            this.Close();
            LogIn frm = new LogIn();
            frm.Show();

        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_CauHinh_Load(object sender, EventArgs e)
        {
            
        }

        
       

 
    }
}
