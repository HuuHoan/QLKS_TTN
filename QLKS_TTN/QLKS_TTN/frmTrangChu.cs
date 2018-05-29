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
    public partial class frmTrangChu : Form
    {
        public frmTrangChu()
        {
            InitializeComponent();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien f = new frmNhanVien();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            frmKhachHang frmkh = new frmKhachHang();
            this.Hide();
            frmkh.ShowDialog();
            this.Show();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            frmHoaDon frmhd = new frmHoaDon();
            this.Hide();
            frmhd.ShowDialog();
            this.Show();
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            frmDichVu frmdv = new frmDichVu();
            this.Hide();
            frmdv.ShowDialog();
            this.Show();
        }

        private void btnPhong_Click(object sender, EventArgs e)
        {
            frmPhong frmp = new frmPhong();
            this.Hide();
            frmp.ShowDialog();
            this.Show();
        }

        private void btnpDichVu_Click(object sender, EventArgs e)
        {
            frmPhieuDichVu frmpdv = new frmPhieuDichVu();
            this.Hide();
            frmpdv.ShowDialog();
            this.Show();
        }

        private void btnpDangKy_Click(object sender, EventArgs e)
        {
            frmPhieuDangKy frmdk = new frmPhieuDangKy();
            this.Hide();
            frmdk.ShowDialog();
            this.Show();
        }
    }
}
