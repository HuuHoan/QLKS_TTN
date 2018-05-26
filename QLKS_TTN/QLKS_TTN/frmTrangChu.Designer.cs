namespace QLKS_TTN
{
    partial class frmTrangChu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNhanVien = new System.Windows.Forms.Button();
            this.btnKhachHang = new System.Windows.Forms.Button();
            this.btnHoaDon = new System.Windows.Forms.Button();
            this.btnDichVu = new System.Windows.Forms.Button();
            this.btnpDichVu = new System.Windows.Forms.Button();
            this.btnpDangKy = new System.Windows.Forms.Button();
            this.btnPhong = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label1.Location = new System.Drawing.Point(190, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(411, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "LỰA CHỌN CHỨC NĂNG";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label2.Location = new System.Drawing.Point(262, 402);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(526, 39);
            this.label2.TabIndex = 1;
            this.label2.Text = "HỌC VIỆN KỸ THUẬT QUÂN SỰ";
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNhanVien.Location = new System.Drawing.Point(120, 109);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(127, 77);
            this.btnNhanVien.TabIndex = 2;
            this.btnNhanVien.Text = "Quản lý Nhân Viên";
            this.btnNhanVien.UseVisualStyleBackColor = true;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnKhachHang.Location = new System.Drawing.Point(331, 109);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Size = new System.Drawing.Size(127, 77);
            this.btnKhachHang.TabIndex = 3;
            this.btnKhachHang.Text = "Quản lý Khách Hàng";
            this.btnKhachHang.UseVisualStyleBackColor = true;
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnHoaDon.Location = new System.Drawing.Point(551, 109);
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.Size = new System.Drawing.Size(127, 77);
            this.btnHoaDon.TabIndex = 4;
            this.btnHoaDon.Text = "Quản lý Hóa Đơn";
            this.btnHoaDon.UseVisualStyleBackColor = true;
            this.btnHoaDon.Click += new System.EventHandler(this.btnHoaDon_Click);
            // 
            // btnDichVu
            // 
            this.btnDichVu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDichVu.Location = new System.Drawing.Point(120, 239);
            this.btnDichVu.Name = "btnDichVu";
            this.btnDichVu.Size = new System.Drawing.Size(127, 77);
            this.btnDichVu.TabIndex = 5;
            this.btnDichVu.Text = "Quản lý Dịch Vụ";
            this.btnDichVu.UseVisualStyleBackColor = true;
            this.btnDichVu.Click += new System.EventHandler(this.btnDichVu_Click);
            // 
            // btnpDichVu
            // 
            this.btnpDichVu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnpDichVu.Location = new System.Drawing.Point(331, 239);
            this.btnpDichVu.Name = "btnpDichVu";
            this.btnpDichVu.Size = new System.Drawing.Size(127, 77);
            this.btnpDichVu.TabIndex = 6;
            this.btnpDichVu.Text = "Phiếu Dịch Vụ\r\n";
            this.btnpDichVu.UseVisualStyleBackColor = true;
            this.btnpDichVu.Click += new System.EventHandler(this.btnpDichVu_Click);
            // 
            // btnpDangKy
            // 
            this.btnpDangKy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnpDangKy.Location = new System.Drawing.Point(551, 239);
            this.btnpDangKy.Name = "btnpDangKy";
            this.btnpDangKy.Size = new System.Drawing.Size(127, 77);
            this.btnpDangKy.TabIndex = 7;
            this.btnpDangKy.Text = "Phiếu Đăng Ký";
            this.btnpDangKy.UseVisualStyleBackColor = true;
            this.btnpDangKy.Click += new System.EventHandler(this.btnpDangKy_Click);
            // 
            // btnPhong
            // 
            this.btnPhong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPhong.Location = new System.Drawing.Point(120, 345);
            this.btnPhong.Name = "btnPhong";
            this.btnPhong.Size = new System.Drawing.Size(127, 77);
            this.btnPhong.TabIndex = 8;
            this.btnPhong.Text = "Quản lý Phòng";
            this.btnPhong.UseVisualStyleBackColor = true;
            this.btnPhong.Click += new System.EventHandler(this.btnPhong_Click);
            // 
            // frmTrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPhong);
            this.Controls.Add(this.btnpDangKy);
            this.Controls.Add(this.btnpDichVu);
            this.Controls.Add(this.btnDichVu);
            this.Controls.Add(this.btnHoaDon);
            this.Controls.Add(this.btnKhachHang);
            this.Controls.Add(this.btnNhanVien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmTrangChu";
            this.Text = "CHÀO MỪNG ĐẾN VỚI PHẦM MỀM QUẢN LÝ KHÁCH SẠN";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNhanVien;
        private System.Windows.Forms.Button btnKhachHang;
        private System.Windows.Forms.Button btnHoaDon;
        private System.Windows.Forms.Button btnDichVu;
        private System.Windows.Forms.Button btnpDichVu;
        private System.Windows.Forms.Button btnpDangKy;
        private System.Windows.Forms.Button btnPhong;
    }
}