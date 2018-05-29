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

namespace QLKS_TTN
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
            txtTimKiem.ForeColor = Color.LightGray;
            txtTimKiem.Text = "Tìm kiếm";
            this.txtTimKiem.Leave += new System.EventHandler(this.txtTimKiem_Leave);
            this.txtTimKiem.Enter += new System.EventHandler(this.txtTimKiem_Enter);

            cbbTK.ForeColor = Color.LightGray;
            cbbTK.Text = "Tìm kiếm theo";
            this.cbbTK.Leave += new System.EventHandler(this.cbbTK_Leave);
            this.cbbTK.Enter += new System.EventHandler(this.cbbTK_Enter);
        }
        DataConnections con = new DataConnections();
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            this.ShowKH();
        }
        #region showdata
        List<string> list = new List<string>();
        public void ShowKH()
        {
            con.OpenConnection();
            btnSuaKH.Enabled = false;
            btnXoaKH.Enabled = false;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = " select * from KHACHHANG ";
            cmd.Connection = con.conn;

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string makh = reader.GetString(0);
                ListViewItem liv = new ListViewItem(reader.GetString(0));
                liv.SubItems.Add(reader.GetString(1));
                liv.SubItems.Add(reader.GetString(2));
                list.Add(makh);
                lvKH.Items.Add(liv);
            }
            reader.Close();
        }
        #endregion
        #region listview
        private void lvKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbMaKH.Enabled = false;
            btnThemKH.Enabled = false;
            btnSuaKH.Enabled = true;
            btnXoaKH.Enabled = true;
            if (lvKH.SelectedItems.Count == 0) return;
            ListViewItem liv = lvKH.SelectedItems[0];
            txbMaKH.Text = liv.SubItems[0].Text;
            txbTenKH.Text = liv.SubItems[1].Text;
            txtDienThoai.Text = liv.SubItems[2].Text;
        }
        #endregion
        #region database
        private void ThemKH()
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn thêm khách hàng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                con.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ADD_KHACHHANG";
                cmd.Connection = con.conn;

                cmd.Parameters.Add("@MAKH", SqlDbType.VarChar).Value = txbMaKH.Text;
                cmd.Parameters.Add("@TENKH", SqlDbType.NVarChar).Value = txbTenKH.Text;
                cmd.Parameters.Add("@DIENTHOAI", SqlDbType.VarChar).Value = txtDienThoai.Text;

                int ret = cmd.ExecuteNonQuery();
                lvKH.Items.Clear();
                if (ret > 0)
                    ShowKH();
                MessageBox.Show("Đã thêm thành công", "Thêm");
                
                txbMaKH.ResetText();
                txbTenKH.ResetText();
                txtDienThoai.ResetText();

            }
            else
            {
                lvKH.Items.Clear();
                ShowKH();
            }
        }
        private void SuaKH()
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn sửa khách hàng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                con.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ALTER_KHACHHANG";
                cmd.Connection = con.conn;
                cmd.Parameters.Add("@MAKH", SqlDbType.VarChar).Value = txbMaKH.Text;
                cmd.Parameters.Add("@TENKH", SqlDbType.NVarChar).Value = txbTenKH.Text;
                cmd.Parameters.Add("@DIENTHOAI", SqlDbType.VarChar).Value = txtDienThoai.Text;
                int ret = cmd.ExecuteNonQuery();
                lvKH.Items.Clear();
                if (ret > 0)
                    ShowKH();
                MessageBox.Show("Đã sửa thành công", "Sửa");
                txbMaKH.Enabled = true;
                txbMaKH.ResetText();
                txbTenKH.ResetText();
                txtDienThoai.ResetText();

            }
            else
            {
                lvKH.Items.Clear();
                ShowKH();
            }
        }
        private void XoaKH()
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn xóa khách hàng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                con.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "D_KHACHHANG";
                cmd.Connection = con.conn;

                cmd.Parameters.Add("@MAKH", SqlDbType.NVarChar).Value = txbMaKH.Text;
                int ret = cmd.ExecuteNonQuery();
                lvKH.Items.Clear();
                if (ret > 0)
                    ShowKH();
                MessageBox.Show("Đã xóa thành công !", "Xóa");
                btnThemKH.Enabled = true;
                txbMaKH.Enabled = true;
                
                txbMaKH.ResetText();
                txbTenKH.ResetText();
                txtDienThoai.ResetText();
 
            }
            else
            {
                btnThemKH.Enabled = true;
                txbMaKH.Enabled = true;
                txbMaKH.ResetText();
                txbTenKH.ResetText();
                txtDienThoai.ResetText();

                lvKH.Items.Clear();
                ShowKH();
            }
        }
        #endregion
        #region timkiem
        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")
            {
                txtTimKiem.Text = "Tìm kiếm";
                txtTimKiem.ForeColor = Color.Gray;
            }
        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "Tìm kiếm")
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = Color.Black;
            }
        }
        private void btnTimKiemDV_Click(object sender, EventArgs e)
        {
            if (cbbTK.SelectedIndex == 0)
            {
                string str = txtTimKiem.Text;
                con.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from KHACHHANG Where MAKH like '%" + str + "%'";
                cmd.Connection = con.conn;
                SqlDataReader reader = cmd.ExecuteReader();
                lvKH.Items.Clear();
                while (reader.Read())
                {
                    ListViewItem liv = new ListViewItem(reader.GetString(0));
                    liv.SubItems.Add(reader.GetString(1));
                    liv.SubItems.Add(reader.GetString(2));
                    lvKH.Items.Add(liv);
                }
                reader.Close();
            }
            else if (cbbTK.SelectedIndex == 1)
            {
                string str = txtTimKiem.Text;
                con.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from KHACHHANG Where TENKH like N'%" + str + "%'";
                cmd.Connection = con.conn;
                SqlDataReader reader = cmd.ExecuteReader();
                lvKH.Items.Clear();
                while (reader.Read())
                {
                    ListViewItem liv = new ListViewItem(reader.GetString(0));
                    liv.SubItems.Add(reader.GetString(1));
                    liv.SubItems.Add(reader.GetString(2));
                    lvKH.Items.Add(liv);

                }
                reader.Close();
            }
            else if (cbbTK.SelectedIndex == 2)
            {
                string str = txtTimKiem.Text;
                con.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from KHACHHANG Where DIENTHOAI like N'%" + str + "%'";
                cmd.Connection = con.conn;
                SqlDataReader reader = cmd.ExecuteReader();
                lvKH.Items.Clear();
                while (reader.Read())
                {
                    ListViewItem liv = new ListViewItem(reader.GetString(0));
                    liv.SubItems.Add(reader.GetString(1));
                    liv.SubItems.Add(reader.GetString(2));
                    lvKH.Items.Add(liv);
                }
                reader.Close();
            }
            else
            {
                MessageBox.Show("Yêu cầu chọn trường tìm kiếm");
            }
        }
        private void cbbTK_Enter(object sender, EventArgs e)
        {
            if (cbbTK.Text == "Tìm kiếm theo")
            {
                cbbTK.Text = "";
                cbbTK.ForeColor = Color.Black;
            }
        }

        private void cbbTK_Leave(object sender, EventArgs e)
        {
            if (cbbTK.Text == "")
            {
                cbbTK.Text = "Tìm kiếm theo";
                cbbTK.ForeColor = Color.Gray;
            }
        }
        #endregion
        #region Button
        private void btnThemKH_Click(object sender, EventArgs e)
        {
            if (txbMaKH.Text != "")
            {
                bool check = true;
                foreach (string us in list)
                {

                    if (us.Contains(txbMaKH.Text))
                    {
                        MessageBox.Show("Mã khách hàng đã tồn tại !");
                        check = false;
                        break;
                    }
                    check = true;
                }
                if (check == true)
                {
                    ListViewItem liv = new ListViewItem(txbMaKH.Text);
                    liv.SubItems.Add(txbTenKH.Text);
                    liv.SubItems.Add(txtDienThoai.Text);
                    lvKH.Items.Add(liv);
                    ThemKH();
                }
            }
            else
            {
                MessageBox.Show("Chưa nhập mã khách hàng", "Thông báo");
            }
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            btnThemKH.Enabled = true;
            if (lvKH.SelectedItems.Count == 0) return;
            ListViewItem liv = lvKH.SelectedItems[0];
            liv.SubItems[0].Text = txbMaKH.Text;
            liv.SubItems[1].Text = txbTenKH.Text;
            liv.SubItems[2].Text = txtDienThoai.Text;
            SuaKH();
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            if (lvKH.SelectedItems.Count != 0)
            {
                for (int i = 0; i < lvKH.Items.Count; i++)
                {
                    if (lvKH.Items[i].Selected)
                    {
                        lvKH.Items[i].Remove();
                        i--;
                    }
                }
                XoaKH();
            }
        }

        private void btnRs_Click(object sender, EventArgs e)
        {
            btnThemKH.Enabled = true;
            btnSuaKH.Enabled = false;
            btnXoaKH.Enabled = false;
            txbMaKH.Enabled = true;
            txbMaKH.ResetText();
            txbTenKH.ResetText();
            txtDienThoai.ResetText();

        }

        #endregion  
    }
}
