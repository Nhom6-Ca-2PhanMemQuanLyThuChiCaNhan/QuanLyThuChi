using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.UserSkins;
using DevExpress.Skins;
namespace QuanLyThuChi
{
    public partial class frm_PhieuThu : DevExpress.XtraEditors.XtraForm
    {
        public frm_PhieuThu()
        {
            InitializeComponent();
            DevExpress.UserSkins.BonusSkins.Register();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frm_LapPhieuThu f = new frm_LapPhieuThu();
            f.ShowDialog();

        }

       
    }
}