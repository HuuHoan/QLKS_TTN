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
    public partial class frmDichVu : Form
    {
        public frmDichVu()
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
        private void frmDichVu_Load(object sender, EventArgs e)
        {
            this.showDV();
        }
        #region showdata
        List<string> list = new List<string>();
        public void showDV()
        {
            con.OpenConnection();
            btnSuaDV.Enabled = false;
            btnXoaDV.Enabled = false;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = " select * from DICHVU ";
            cmd.Connection = con.conn;

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string madv = reader.GetString(0);
                ListViewItem liv = new ListViewItem(reader.GetString(0));
                liv.SubItems.Add(reader.GetString(1));
                liv.SubItems.Add(reader.GetInt32(2).ToString());
                list.Add(madv);
                lvDV.Items.Add(liv);
            }
            reader.Close();
        }
        #endregion
        #region listview
      
        private void lvDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbMaDV.Enabled = false;
            btnThemDV.Enabled = false;
            btnSuaDV.Enabled = true;
            btnXoaDV.Enabled = true;
            if (lvDV.SelectedItems.Count == 0) return;
            ListViewItem liv = lvDV.SelectedItems[0];
            txbMaDV.Text = liv.SubItems[0].Text;
            txbTenDV.Text = liv.SubItems[1].Text;
            txtGia.Text = liv.SubItems[2].Text;
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
                cmd.CommandText = "select * from DICHVU Where MADV like '%" + str + "%'";
                cmd.Connection = con.conn;
                SqlDataReader reader = cmd.ExecuteReader();
                lvDV.Items.Clear();
                while (reader.Read())
                {
                    ListViewItem liv = new ListViewItem(reader.GetString(0));
                    liv.SubItems.Add(reader.GetString(1));
                    liv.SubItems.Add(reader.GetInt32(2).ToString());
                    lvDV.Items.Add(liv);
                }
                reader.Close();
            }
            else if (cbbTK.SelectedIndex == 1)
            {
                string str = txtTimKiem.Text;
                con.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from DICHVU Where TENDV like N'%" + str + "%'";
                cmd.Connection = con.conn;
                SqlDataReader reader = cmd.ExecuteReader();
                lvDV.Items.Clear();
                while (reader.Read())
                {
                    ListViewItem liv = new ListViewItem(reader.GetString(0));
                    liv.SubItems.Add(reader.GetString(1));
                    liv.SubItems.Add(reader.GetInt32(2).ToString());
                    lvDV.Items.Add(liv);

                }
                reader.Close();
            }
            else if (cbbTK.SelectedIndex == 2)
            {
                string str = txtTimKiem.Text;
                con.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from DICHVU Where GIA like N'%" + str + "%'";
                cmd.Connection = con.conn;
                SqlDataReader reader = cmd.ExecuteReader();
                lvDV.Items.Clear();
                while (reader.Read())
                {
                    ListViewItem liv = new ListViewItem(reader.GetString(0));
                    liv.SubItems.Add(reader.GetString(1));
                    liv.SubItems.Add(reader.GetInt32(2).ToString());
                    lvDV.Items.Add(liv);
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
        private void ThemDV()
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn thêm dịch vụ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                con.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ADD_DICHVU";
                cmd.Connection = con.conn;

                cmd.Parameters.Add("@MADV", SqlDbType.VarChar).Value = txbMaDV.Text;
                cmd.Parameters.Add("@TENDV", SqlDbType.NVarChar).Value = txbTenDV.Text;
                cmd.Parameters.Add("@GIA", SqlDbType.Int).Value = txtGia.Text;

                int ret = cmd.ExecuteNonQuery();
                lvDV.Items.Clear();
                if (ret > 0)
                    showDV();
                MessageBox.Show("Đã thêm thành công", "Thêm");
               
                txbMaDV.ResetText();
                txbTenDV.ResetText();
                txtGia.ResetText();
            }
            else
            {
                lvDV.Items.Clear();
                showDV();
            }
        }
        private void SuaDV()
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn sửa dịch vụ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                con.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ALTER_DICHVU";
                cmd.Connection = con.conn;
                cmd.Parameters.Add("@MADV", SqlDbType.VarChar).Value = txbMaDV.Text;
                cmd.Parameters.Add("@TENDV", SqlDbType.NVarChar).Value = txbTenDV.Text;
                cmd.Parameters.Add("@GIA", SqlDbType.Int).Value = txtGia.Text;
                int ret = cmd.ExecuteNonQuery();
                lvDV.Items.Clear();
                if (ret > 0)
                    showDV();
                MessageBox.Show("Đã sửa thành công", "Sửa");
                txbMaDV.Enabled = true;
                txbMaDV.ResetText();
                txbTenDV.ResetText();
                txtGia.ResetText();
            }
            else
            {
                lvDV.Items.Clear();
                showDV();
            }
        }
        private void XoaDV()
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn xóa dịch vụ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                con.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "D_DICHVU";
                cmd.Connection = con.conn;

                cmd.Parameters.Add("@MADV", SqlDbType.NVarChar).Value = txbMaDV.Text;
                int ret = cmd.ExecuteNonQuery();
                lvDV.Items.Clear();
                if (ret > 0)
                    showDV();
                MessageBox.Show("Đã xóa thành công !", "Xóa");
                btnThemDV.Enabled = true;
                txbMaDV.Enabled = true;
                txbMaDV.ResetText();
                txbTenDV.ResetText();
                txtGia.ResetText();
            }
            else
            {
                btnThemDV.Enabled = true;
                txbMaDV.Enabled = true;
                txbMaDV.ResetText();
                txbTenDV.ResetText();
                txtGia.ResetText();
                lvDV.Items.Clear();
                showDV();
            }
        }

        #endregion
    
        #region button
        private void btnThemDV_Click(object sender, EventArgs e)
        {
            if (txbMaDV.Text != "")
            {
                bool check = true;
                foreach (string us in list)
                {

                    if (us.Contains(txbMaDV.Text))
                    {
                        MessageBox.Show("Mã dịch vụ đã tồn tại !");
                        check = false;
                        break;
                    }
                    check = true;
                }
                if (check == true)
                {
                    ListViewItem liv = new ListViewItem(txbMaDV.Text);
                    liv.SubItems.Add(txbTenDV.Text);
                    liv.SubItems.Add(txtGia.Text);
                    lvDV.Items.Add(liv);
                    ThemDV();
                }
            }
            else
            {
                MessageBox.Show("Chưa nhập mã dịch vụ", "Thông báo");
            }
        }

        private void btnSuaDV_Click(object sender, EventArgs e)
        {
            btnThemDV.Enabled = true;
            if (lvDV.SelectedItems.Count == 0) return;
            ListViewItem liv = lvDV.SelectedItems[0];
            liv.SubItems[0].Text = txbMaDV.Text;
            liv.SubItems[1].Text = txbTenDV.Text;
            liv.SubItems[2].Text = txtGia.Text;
            SuaDV();
        }

        private void btnXoaDV_Click(object sender, EventArgs e)
        {
            if (lvDV.SelectedItems.Count != 0)
            {
                for (int i = 0; i < lvDV.Items.Count; i++)
                {
                    if (lvDV.Items[i].Selected)
                    {
                        lvDV.Items[i].Remove();
                        i--;
                    }
                }
                XoaDV();
            }
        }
        private void btnRs_Click(object sender, EventArgs e)
        {
            btnThemDV.Enabled = true;
            btnSuaDV.Enabled = false;
            btnXoaDV.Enabled = false;
            txbMaDV.Enabled = true;
            txbMaDV.ResetText();
            txbTenDV.ResetText();
            txtGia.ResetText();
        }

        #endregion

        
    }
    
}
