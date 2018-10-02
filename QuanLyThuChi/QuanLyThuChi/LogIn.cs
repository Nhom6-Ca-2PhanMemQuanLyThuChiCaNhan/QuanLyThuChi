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
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
            this.AcceptButton = btn_login;
        }
        LoginResult CauHinh = new LoginResult();

        private void btn_login_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txt_Username.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống" + lb_user.Text.ToLower());
                this.txt_Username.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.txt_Password.Text))
            {
                MessageBox.Show("Không được bỏ trống" + lb_pass.Text.ToLower());
                this.txt_Password.Focus();
                return;
            }
            int check_config = CauHinh.Check_Config();
            if (check_config == 0)
            {
                ProcessLogin();// Cấu hình phù hợp xử lý đăng nhập
            }

            else if (check_config == 1)
            {
                MessageBox.Show("Chuỗi cấu hình không tồn tại");// Xử lý cấu hình
                ProcessConfig();
            }
            else
            {
                MessageBox.Show("Chuỗi cấu hình không phù hợp");// Xử lý cấu hình
                ProcessConfig();
            } 
         }

        private void ProcessConfig()
        {
            this.Hide();
            frm_CauHinh frm = new frm_CauHinh();
            frm.Show();
        }

        private void ProcessLogin()
        {
            int result = LoginResult.Check_User(txt_Username.Text, txt_Password.Text);
            // Wrong username or pass
            if (result == 0)
            {
                MessageBox.Show("Sai " + lb_user.Text + " Hoặc " + lb_pass.Text);
                return;
            }
            // Account had been disabled
            else if (result == 1)
            {
                MessageBox.Show("Tài khoản bị khóa");
                return;
            }
            MainForm frm = new MainForm();
            frm.Show(); 
            this.Hide();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
               
        }

        private void LogIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn muốn thoát", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

    }
}
