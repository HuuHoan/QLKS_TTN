﻿
create DATABASE QLKS_TTN
go
use QLKS_TTN
go

Create TABLE DANGNHAP
(
	TaiKhoan NVARCHAR(30),
	MatKhau VARCHAR(30)
)
GO
Create TABLE NHANVIEN
(
	MANV VARCHAR(8) PRIMARY KEY NOT NULL,
	TENNV NVARCHAR(50) NOT NULL,
	GIOITINH NVARCHAR(5) CHECK (GIOITINH IN (N'Nam',N'Nữ')),
	NGAYSINH DATE,
	DIENTHOAI VARCHAR(11)
)
GO
Create TABLE KHACHHANG
(
	MAKH VARCHAR(8) PRIMARY KEY NOT NULL,
	TENKH NVARCHAR(50) NOT NULL,
	DIENTHOAI VARCHAR(11)
)
GO
Create TABLE HOADON
(
	MAHD VARCHAR(8) PRIMARY KEY NOT NULL,
	MANV VARCHAR(8) REFERENCES NHANVIEN(MANV) ON DELETE CASCADE,
	MAPDK varchar(8) REFERENCES PHIEUDANGKI(MAPDK) ,
	NGAYTHANHTOAN DATE,
	TONGTIEN INT
)
GO
Create TABLE DICHVU
(
	MADV VARCHAR(8) PRIMARY KEY NOT NULL,
	TENDV NVARCHAR(50) NOT NULL,
	GIA INT
)
GO
Create TABLE PHIEUDICHVU
(
	 PRIMARY KEY(MAPDK,MADV),
	 MAPDK VARCHAR(8) REFERENCES PHIEUDANGKI(MAPDK) ON DELETE CASCADE,
	 MADV VARCHAR(8) REFERENCES DICHVU(MADV) ON DELETE CASCADE,
	 SOLUONG INT
)
GO
Create TABLE PHIEUDANGKI
(
	MAPDK VARCHAR(8) PRIMARY KEY NOT NULL , 
	MAKH VARCHAR(8) REFERENCES KHACHHANG(MAKH) ON DELETE CASCADE,
	MAPHONG VARCHAR(8) REFERENCES PHONG(MAPHONG) ON DELETE CASCADE,
	MANV VARCHAR(8) REFERENCES NHANVIEN(MANV) ON DELETE CASCADE,
	NGAYLAP DATE,
	TIENCOC INT
)
GO
Create TABLE PHONG
(
	MAPHONG VARCHAR(8) PRIMARY KEY NOT NULL,
	TENPHONG NVARCHAR(50),
	MALP VARCHAR(8) REFERENCES LOAIPHONG(MALP) ON DELETE CASCADE,
)
GO
Create TABLE LOAIPHONG
(
	MALP VARCHAR(8) PRIMARY KEY NOT NULL ,
	TENLP NVARCHAR(50)
)
GO


