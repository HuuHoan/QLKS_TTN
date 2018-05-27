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


	--insert DANGNHAP
	INSERT dbo.DANGNHAP( TaiKhoan, MatKhau )
	VALUES  ( N'admin','123456'),
			( N'a','a')
GO
    --insert NHANVIEN
	INSERT INTO NHANVIEN VALUES ('NV01',N'Sơn Tùng','Nam','1995-2-2','0165315415');
	INSERT INTO NHANVIEN VALUES ('NV02',N'Bích Phương',N'Nữ','1992-11-22','0981413520');
	INSERT INTO NHANVIEN VALUES ('NV03',N'Đàm Vĩnh Hưng','Nam','5-2-1997','01234512852');
	INSERT INTO NHANVIEN VALUES ('NV04',N'Chi Pu','Nam','1-2-1995','0982014165');
	INSERT INTO NHANVIEN VALUES ('NV05',N'Noo Phước Thịnh','Nam','1-7-2000','0978500132');
go

--PROC 
	--Proc DANGNHAP
	CREATE PROC DangKy(@Taikhoan NVARCHAR(30),@Matkhau NVARCHAR(30))
	AS
	BEGIN
		INSERT dbo.DANGNHAP( TaiKhoan, MatKhau )
		VALUES  ( @Taikhoan, @Matkhau )
	END
GO

	CREATE PROC dbo.KiemTraDN(@Username VARCHAR(50),@Pass varchar(50)) AS 
	BEGIN
		SELECT * FROM dbo.DANGNHAP WHERE TaiKhoan = @Username AND MatKhau = @Pass
	END
GO
	--Proc NHANVIEN
	CREATE PROCEDURE ADD_NHANVIEN(@MANV VARCHAR(8),@TENNV NVARCHAR(50),@GIOITINH NVARCHAR(5),@NGAYSINH DATE,@DIENTHOAI VARCHAR(11))
AS
BEGIN
		INSERT INTO NHANVIEN
		VALUES(@MANV,@TENNV,@GIOITINH,@NGAYSINH,@DIENTHOAI)
END
GO
	--Sua
CREATE PROCEDURE ALTER_NHANVIEN(@MANV VARCHAR(8),@TENNV NVARCHAR(50),@GIOITINH NVARCHAR(5),@NGAYSINH DATE,@DIENTHOAI VARCHAR(11))
AS
BEGIN
	UPDATE NHANVIEN
	SET TENNV=@TENNV,GIOITINH=@GIOITINH,NGAYSINH=@NGAYSINH,DIENTHOAI =@DIENTHOAI
	WHERE MANV=@MANV
			
END	
GO	
	--Xoa
CREATE PROCEDURE D_NHANVIEN(@MANV VARCHAR(8))
AS
BEGIN 
	DELETE FROM NHANVIEN
	WHERE MANV=@MANV
END		
GO





