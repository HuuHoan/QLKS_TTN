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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
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
        DataConnections con  = new DataConnections();
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            this.ShowNV();
        }
        #region showdata
        List<string> list = new List<string>();
        public void ShowNV()
        {
            con.OpenConnection();
            btnSuaNV.Enabled = false;
            btnXoaNV.Enabled = false;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = " select * from NHANVIEN ";
            cmd.Connection = con.conn;

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string manv = reader.GetString(0);
                ListViewItem liv = new ListViewItem(reader.GetString(0));
                liv.SubItems.Add(reader.GetString(1));
                liv.SubItems.Add(reader.GetString(2));
                liv.SubItems.Add(reader.GetDateTime(3).ToString());
                liv.SubItems.Add(reader.GetString(4));
                list.Add(manv);
                lvNV.Items.Add(liv);
            }
            reader.Close();
        }

        #endregion

        #region listview
        private void lvNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbMaNV.Enabled = false;
            btnThemNV.Enabled = false;
            btnSuaNV.Enabled = true;
            btnXoaNV.Enabled = true;
            if (lvNV.SelectedItems.Count == 0) return;
            ListViewItem liv = lvNV.SelectedItems[0];
            txbMaNV.Text = liv.SubItems[0].Text;
            txbTenNV.Text = liv.SubItems[1].Text;
            if (rdnam.Text.ToLower() == liv.SubItems[2].Text.ToLower())
            {
                rdnam.Checked = true;
                rdnu.Checked = false;
            }
            else
            {
                rdnu.Checked = true;
                rdnam.Checked = false;
            }
            dtngaysinh.Text = liv.SubItems[3].Text;
            txtdienthoai.Text = liv.SubItems[4].Text;
        }

        #endregion

        #region button
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            if (txbMaNV.Text != "")
            {
                bool check = true;
                foreach (string us in list)
                {

                    if (us.Contains(txbMaNV.Text))
                    {
                        MessageBox.Show("Mã nhân viên đã tồn tại !");
                        check = false;
                        break;
                    }
                    check = true;
                }
                if (check == true)
                {
                    ListViewItem liv = new ListViewItem(txbMaNV.Text);
                    liv.SubItems.Add(txbTenNV.Text);
                    if (rdnam.Checked == true)
                    {
                        liv.SubItems.Add(rdnam.Text);
                    }
                    else
                    {
                        liv.SubItems.Add(rdnu.Text);
                    }
                    liv.SubItems.Add(dtngaysinh.Text);
                    liv.SubItems.Add(txtdienthoai.Text);
                    lvNV.Items.Add(liv);
                    ThemNV();
                }
            }
            else
            {
                MessageBox.Show("Chưa nhập mã nhân viên", "Thông báo");
            }
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            btnThemNV.Enabled = true;
            if (lvNV.SelectedItems.Count == 0) return;
            ListViewItem liv = lvNV.SelectedItems[0];
            liv.SubItems[0].Text = txbMaNV.Text;
            liv.SubItems[1].Text = txbTenNV.Text;
            if (rdnam.Checked == true)
            {
                liv.SubItems[2].Text = rdnam.Text;
            }
            else
            {
                liv.SubItems[2].Text = rdnu.Text;
            }
            liv.SubItems[3].Text = dtngaysinh.Text;
            liv.SubItems[4].Text = txtdienthoai.Text;
            SuaNV();
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            if (lvNV.SelectedItems.Count != 0)
            {
                for (int i = 0; i < lvNV.Items.Count; i++)
                {
                    if (lvNV.Items[i].Selected)
                    {
                        lvNV.Items[i].Remove();
                        i--;
                    }
                }
                XoaNV();
            }
        }

        private void btnRs_Click(object sender, EventArgs e)
        {
            btnThemNV.Enabled = true;
            btnSuaNV.Enabled = false;
            btnXoaNV.Enabled = false;
            txbMaNV.Enabled = true;
            rdnam.Checked = false;
            rdnu.Checked = false;
            txbMaNV.ResetText();
            txbTenNV.ResetText();
            txtdienthoai.ResetText();
            dtngaysinh.ResetText();
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
        private void btnTimKiemNV_Click(object sender, EventArgs e)
        {
            if (cbbTK.SelectedIndex == 0)
            {
                string str = txtTimKiem.Text;
                con.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from NHANVIEN Where MANV like '%" + str + "%'";
                cmd.Connection = con.conn;
                SqlDataReader reader = cmd.ExecuteReader();
                lvNV.Items.Clear();
                while (reader.Read())
                {
                    ListViewItem liv = new ListViewItem(reader.GetString(0));
                    liv.SubItems.Add(reader.GetString(1));
                    liv.SubItems.Add(reader.GetString(2));
                    liv.SubItems.Add(reader.GetDateTime(3).ToString());
                    liv.SubItems.Add(reader.GetString(4));
                    lvNV.Items.Add(liv);
                }
                reader.Close();
            }
            else if (cbbTK.SelectedIndex == 1)
            {
                string str = txtTimKiem.Text;
                con.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from NHANVIEN Where HOTEN like N'%" + str + "%'";
                cmd.Connection = con.conn;
                SqlDataReader reader = cmd.ExecuteReader();
                lvNV.Items.Clear();
                while (reader.Read())
                {
                    ListViewItem liv = new ListViewItem(reader.GetString(0));
                    liv.SubItems.Add(reader.GetString(1));
                    liv.SubItems.Add(reader.GetString(2));
                    liv.SubItems.Add(reader.GetDateTime(3).ToString());
                    liv.SubItems.Add(reader.GetString(4));
                    lvNV.Items.Add(liv);

                }
                reader.Close();
            }
            else if (cbbTK.SelectedIndex == 2)
            {
                string str = txtTimKiem.Text;
                con.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from NHANVIEN Where NGAYSINH like N'%" + str + "%'";
                cmd.Connection = con.conn;
                SqlDataReader reader = cmd.ExecuteReader();
                lvNV.Items.Clear();
                while (reader.Read())
                {
                    ListViewItem liv = new ListViewItem(reader.GetString(0));
                    liv.SubItems.Add(reader.GetString(1));
                    liv.SubItems.Add(reader.GetString(2));
                    liv.SubItems.Add(reader.GetDateTime(3).ToString());
                    liv.SubItems.Add(reader.GetString(4));
                    lvNV.Items.Add(liv);
                }
                reader.Close();
            }
            else if (cbbTK.SelectedIndex == 3)
            {
                string str = txtTimKiem.Text;
                con.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from NHANVIEN Where DIENTHOAI like N'%" + str + "%'";
                cmd.Connection = con.conn;
                SqlDataReader reader = cmd.ExecuteReader();
                lvNV.Items.Clear();
                while (reader.Read())
                {
                    ListViewItem liv = new ListViewItem(reader.GetString(0));
                    liv.SubItems.Add(reader.GetString(1));
                    liv.SubItems.Add(reader.GetString(2));
                    liv.SubItems.Add(reader.GetDateTime(3).ToString());
                    liv.SubItems.Add(reader.GetString(4));
                    lvNV.Items.Add(liv);
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

        #region database
        private void ThemNV()
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn thêm nhân viên?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                con.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ADD_NHANVIEN";
                cmd.Connection = con.conn;

                cmd.Parameters.Add("@MANV", SqlDbType.VarChar).Value = txbMaNV.Text;
                cmd.Parameters.Add("@HOTEN", SqlDbType.NVarChar).Value = txbTenNV.Text;
                if (rdnam.Checked == true)
                {
                    cmd.Parameters.Add("@GIOITINH", SqlDbType.NVarChar).Value = rdnam.Text;
                }
                else
                {
                    cmd.Parameters.Add("@GIOITINH", SqlDbType.NVarChar).Value = rdnu.Text;
                }
                cmd.Parameters.Add("@NGAYSINH", SqlDbType.Date).Value = dtngaysinh.Value;

                cmd.Parameters.Add("@DIENTHOAI", SqlDbType.VarChar).Value = txtdienthoai.Text;

                int ret = cmd.ExecuteNonQuery();
                lvNV.Items.Clear();
                if (ret > 0)
                    ShowNV();
                MessageBox.Show("Đã thêm thành công", "Thêm");
                rdnam.Checked = false;
                rdnu.Checked = false;
                txbMaNV.ResetText();
                txbTenNV.ResetText();
                txtdienthoai.ResetText();
                dtngaysinh.ResetText();
            }
            else
            {
                lvNV.Items.Clear();
                ShowNV();
            }
        }
        private void SuaNV()
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn sửa nhân viên?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                con.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ALTER_NHANVIEN";
                cmd.Connection = con.conn;
                cmd.Parameters.Add("@MANV", SqlDbType.VarChar).Value = txbMaNV.Text;
                cmd.Parameters.Add("@HOTEN", SqlDbType.NVarChar).Value = txbTenNV.Text;
                if (rdnam.Checked == true)
                {
                    cmd.Parameters.Add("@GIOITINH", SqlDbType.NVarChar).Value = rdnam.Text;
                }
                else
                {
                    cmd.Parameters.Add("@GIOITINH", SqlDbType.NVarChar).Value = rdnu.Text;
                }
                cmd.Parameters.Add("@NGAYSINH", SqlDbType.Date).Value = dtngaysinh.Value;

                cmd.Parameters.Add("@DIENTHOAI", SqlDbType.VarChar).Value = txtdienthoai.Text;
                int ret = cmd.ExecuteNonQuery();
                lvNV.Items.Clear();
                if (ret > 0)
                    ShowNV();
                MessageBox.Show("Đã sửa thành công", "Sửa");
                txbMaNV.Enabled = true;
                rdnam.Checked = false;
                rdnu.Checked = false;
                txbMaNV.ResetText();
                txbTenNV.ResetText();
                txtdienthoai.ResetText();
                dtngaysinh.ResetText();
            }
            else
            {
                lvNV.Items.Clear();
                ShowNV();
            }
        }
        private void XoaNV()
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn xóa khách hàng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                con.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "D_NHANVIEN";
                cmd.Connection = con.conn;

                cmd.Parameters.Add("@MANV", SqlDbType.NVarChar).Value = txbMaNV.Text;
                int ret = cmd.ExecuteNonQuery();
                lvNV.Items.Clear();
                if (ret > 0)
                    ShowNV();
                MessageBox.Show("Đã xóa thành công !", "Xóa");
                btnThemNV.Enabled = true;
                txbMaNV.Enabled = true;
                rdnam.Checked = false;
                rdnu.Checked = false;
                txbMaNV.ResetText();
                txbTenNV.ResetText();
                txtdienthoai.ResetText();
                dtngaysinh.ResetText();
            }
            else
            {
                btnThemNV.Enabled = true;
                txbMaNV.Enabled = true;
                rdnam.Checked = false;
                rdnu.Checked = false;
                txbMaNV.ResetText();
                txbTenNV.ResetText();
                txtdienthoai.ResetText();
                dtngaysinh.ResetText();
                lvNV.Items.Clear();
                ShowNV();
            }
        }

        #endregion

       
    }
}
