using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3_Demo4
{
    public partial class FormQuanLy : Form
    {
        public FormQuanLy()
        {
            InitializeComponent();
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }
        private void btn_user_Click(object sender, EventArgs e)
        {
            showSubMenu(panel_user);
        }
        private void setVisibleFalse()
        {
            ucThietLapTaiKhoan1.Visible = false;
            ucQuanLyNhanVien1.Visible = false;
        }
        private void btn_ThietLapTK_Click(object sender, EventArgs e)
        {
            setVisibleFalse();
            lbl_form.Text = "Thiết lập tài khoản";
            ucThietLapTaiKhoan1.Visible = true;
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
             if (MessageBox.Show("Do you want to logout?", "Logout message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
             {
                 Application.Exit();
             }
        }

        private void btn_QuanLyNV_Click(object sender, EventArgs e)
        {
            setVisibleFalse();
            lbl_form.Text = "Quản lý nhân viên";
            ucQuanLyNhanVien1.Visible = true;
        }
    }
}
