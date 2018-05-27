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

        #endregion

        #region timkiem

        #endregion

        #region database

        #endregion


    }
}
