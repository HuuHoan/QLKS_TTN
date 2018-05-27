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
            frmKhachHang f = new frmKhachHang();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            frmHoaDon f = new frmHoaDon();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            frmDichVu f = new frmDichVu();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnPhong_Click(object sender, EventArgs e)
        {
            frmPhong f = new frmPhong();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnpDichVu_Click(object sender, EventArgs e)
        {
            frmPhieuDichVu f = new frmPhieuDichVu();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnpDangKy_Click(object sender, EventArgs e)
        {
            frmPhieuDangKy f = new frmPhieuDangKy();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
