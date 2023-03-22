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

namespace PBL3_Demo4
{
    public partial class UCQuanLyNhanVien : UserControl
    {
        string strCon = @"Data Source=LAPTOP-0IQ7Q3Q3;Initial Catalog=testPBL;Integrated Security=True";
        SqlConnection sqlCon = null;
        public UCQuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void UCQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            HienThiDanhSach();
        }

        private void HienThiDanhSach()
        {
            if(listView1.Items.Count > 0) listView1.Items.Clear();
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            SqlCommand sqlCmd = new SqlCommand(strCon);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select * from NhanVien";
            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                string id = reader.GetString(0);
                string name = reader.GetString(1);
                string birth = reader.GetString(2);
                string address = reader.GetString(3);
                string sex = reader.GetString(4);
                string phoneNum = reader.GetString(5);
                string email = reader.GetString(6);

                ListViewItem lvi = new ListViewItem(id);
                lvi.SubItems.Add(name);
                lvi.SubItems.Add(birth);
                lvi.SubItems.Add(address);
                lvi.SubItems.Add(sex);
                lvi.SubItems.Add(phoneNum);
                lvi.SubItems.Add(email);
                listView1.Items.Add(lvi);
            }
            reader.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView1.SelectedItems == null) { return; }
            if(listView1.SelectedItems.Count > 0) {
                ListViewItem lvi = listView1.SelectedItems[0];

                string id = lvi.SubItems[0].Text;
                string name = lvi.SubItems[1].Text;
                string birth = lvi.SubItems[2].Text;
                string address = lvi.SubItems[3].Text;
                string sex = lvi.SubItems[4].Text;
                string phoneNum = lvi.SubItems[5].Text;
                string email = lvi.SubItems[6].Text;

                txt_ID.Text = id;
                txt_name.Text = name;
                txt_birth.Text = birth;
                txt_DiaChi.Text = address;
                if(sex == "Nam")
                {
                    radbtn_Nam.Checked = true;
                }
                else if(sex == "Nu")
                {
                    radbtn_Nu.Checked = true;
                }
                else
                {
                    radbtn_Nam.Checked = false;
                    radbtn_Nu.Checked = false;
                }
                txt_sdt.Text = phoneNum;
                txt_email.Text = email;
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            string id = txt_ID.Text.Trim();
            string name = txt_name.Text.Trim();
            string birth = txt_birth.Text.Trim();
            string address = txt_DiaChi.Text.Trim();
            string sex = "";
            if (radbtn_Nam.Checked)
            {
                sex = "Nam";
            }
            if (radbtn_Nu.Checked)
            {
                sex = "Nu";
            }
            string phoneNum = txt_sdt.Text.Trim();
            string email = txt_email.Text.Trim();

            SqlCommand sqlCmd = new SqlCommand(strCon);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "insert into NhanVien values('" + id + "',N'" + name + "','" + birth + "',N'" + address + "','" + sex + "','" + phoneNum + "','" + email + "')";
            sqlCmd.Connection = sqlCon;

            int kq =    sqlCmd.ExecuteNonQuery();
            if (kq < 0) MessageBox.Show("Them that bai!");
            else HienThiDanhSach();
        }
    }
}
