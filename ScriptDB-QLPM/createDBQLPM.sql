/****** To insert Vietnames:  ******/
/****** 1. make sure script in Unicode-16 ******/
/****** 2. Put N before Vietnames text ******/
/******    Example: N'Lý Đạo Nam' ******/

USE [master]
GO

WHILE EXISTS(select NULL from sys.databases where name='QLPM')
BEGIN
    DECLARE @SQL varchar(max)
    SELECT @SQL = COALESCE(@SQL,'') + 'Kill ' + Convert(varchar, SPId) + ';'
    FROM MASTER..SysProcesses
    WHERE DBId = DB_ID(N'QLPM') AND SPId <> @@SPId
    EXEC(@SQL)
    DROP DATABASE [QLPM]
END
GO

/* Collation = SQL_Latin1_General_CP1_CI_AS */
CREATE DATABASE [QLPM]
GO
USE [QLPM]
GO
SET DATEFORMAT DMY
/*N'TẠO BẢNG HÓA ĐƠN'*/
CREATE TABLE [dbo].[tblHOADON](
	[maHD] [nvarchar](5) NOT NULL,
	[nglapHD] [smalldatetime] NOT NULL,
	[maPKB] [nvarchar](5) NOT NULL,
	[tongTien] [float] 
 CONSTRAINT [PK_tblHOADON] PRIMARY KEY CLUSTERED 
(
	[maHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
/*N'TẠO BẢNG LOẠI BỆNH'*/
CREATE TABLE [dbo].[tblBENH](
	[maBenh] [nvarchar](5) NOT NULL,
	[tenBenh] [nvarchar](50)NOT NULL,
 CONSTRAINT [PK_tblBENH] PRIMARY KEY CLUSTERED 
(
	[maBenh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
/*N'TẠO BẢNG PHIẾU KHÁM BỆNH'*/
CREATE TABLE [dbo].[tblPKB](
	[maPKB] [nvarchar](5) NOT NULL,
	[NgayKham] [smalldatetime] ,
	[TrieuChung] [nvarchar](50) ,
 CONSTRAINT [PK_tblPKB] PRIMARY KEY CLUSTERED 
(
	[maPKB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
/*CONSTRAINT fk_BENH_PKB
	FOREIGN KEY (maBenh)
	REFERENCES tblBENH (maBenh)
*/
) ON [PRIMARY]
/*N'TẠO BẢNG BỆNH NHÂN'*/
CREATE TABLE [dbo].[tblBENHNHAN](
	[maBN] [nvarchar](5) NOT NULL,
	[tenBN] [nvarchar](50) NOT NULL,
	[NgaySinh] [smalldatetime] NOT NULL,
	[DiaChi] [nvarchar](50) NOT NULL,
	[GioiTinh] [nvarchar](50) NOT NULL,
	[maPKB] [nvarchar](5) ,
 CONSTRAINT [PK_tblBENHNHAN] PRIMARY KEY CLUSTERED 
(
	[maBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
CONSTRAINT fk_PKB_BENHNHAN
   FOREIGN KEY (maPKB)
   REFERENCES tblPKB (maPKB)
) ON [PRIMARY]
/*N'TẠO BẢNG NHÂN VIÊN'*/
CREATE TABLE [dbo].[tblNHANVIEN](
	[maNV] [nvarchar](5) NOT NULL,
	[tenNV] [nvarchar](50) NOT NULL,
	[NgaySinh] [smalldatetime] NOT NULL,
	[DiaChi] [nvarchar](50) NOT NULL,
	[GioiTinh] [nvarchar](50) NOT NULL,
	[SoDT] [float] NOT NULL,
	[ChucVu] [nvarchar](50) NOT NULL,
	[maHD] [nvarchar](5) NOT NULL,
 CONSTRAINT [PK_tblNHANVIEN] PRIMARY KEY CLUSTERED 
(
	[maNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT fk_HOADON_NHANVIEN
   FOREIGN KEY (maHD)
   REFERENCES tblHOADON (maHD)
) ON [PRIMARY]
/*N'TẠO BẢNG THUỐC'*/
CREATE TABLE [dbo].[tblTHUOC](
	[maThuoc] [nvarchar](5) NOT NULL,
	[tenThuoc] [nvarchar](50)NOT NULL,
	[DVT] [nvarchar](10)NOT NULL,
	[Dongia] [float] NOT NULL,
	[CachDung] [nvarchar](20)NOT NULL,
 CONSTRAINT [PK_tblTHUOC] PRIMARY KEY CLUSTERED 
(
	[maThuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
/*N'TẠO BẢNG TOA'*/
CREATE TABLE [dbo].[tblTOA](
	[maToa] [nvarchar](5) NOT NULL,
	[ngKeToa] [smalldatetime] NOT NULL,
	[maPKB] [nvarchar](5) NOT NULL,
 CONSTRAINT [PK_tblTOA] PRIMARY KEY CLUSTERED 
(
	[maToa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
CONSTRAINT fk_TOA_PHIEUKHAMBENH
   FOREIGN KEY (maPKB)
   REFERENCES tblPKB (maPKB)
) ON [PRIMARY]
/*N'TẠO BẢNG KẾT QUẢ CHẨN ĐOÁN'*/
CREATE TABLE [dbo].[tblKQCHANDOAN](
	[maBenh] [nvarchar](5) NOT NULL,
	[maPKB] [nvarchar](5) NOT NULL,
	CONSTRAINT fk_KQ_BENH
   FOREIGN KEY (maBenh)
   REFERENCES tblBENH (maBenh),
	CONSTRAINT fk_KQ_PKB
   FOREIGN KEY (maPKB)
   REFERENCES tblPKB (maPKB)
) ON [PRIMARY]
/*N'TẠO BẢNG KÊ THUỐC'*/
CREATE TABLE [dbo].[tblKETHUOC](
	[maThuoc] [nvarchar](5) NOT NULL,
	[maToa] [nvarchar](5) NOT NULL,
	[soLuong] [int] NOT NULL,
	CONSTRAINT fk_KETHUOC_THUOC
   FOREIGN KEY (maThuoc)
   REFERENCES tblTHUOC (maThuoc),
	CONSTRAINT fk_KETHUOC_TOA
   FOREIGN KEY (maToa)
   REFERENCES tblTOA (maToa)
) ON [PRIMARY]



USE [QLPM]
GO
INSERT INTO[dbo].[tblBENHNHAN]([maBN],[tenBN],[GioiTinh],[NgaySinh],[DiaChi]) VALUES(1,N'Lý Văn A',N'Nam',N'1/1/1996',N'12 Nguyễn Thị Thập, P.Tân Hưng, Q.7, TP.HCM' )
INSERT INTO[dbo].[tblBENHNHAN]([maBN],[tenBN],[GioiTinh],[NgaySinh],[DiaChi]) VALUES(3,N'Trần Phương Thảo',N'Nữ',N'12/4/1998',N'12 Trần Hưng Đạo, P.2, Q.5, TP.HCM' )
INSERT INTO[dbo].[tblTHUOC]([maThuoc],[tenThuoc],[DVT],[Dongia],[CachDung]) VALUES(1,N'Paracetamol',N'Viên',N'2000',N'Uống' )
INSERT INTO[dbo].[tblTHUOC]([maThuoc],[tenThuoc],[DVT],[Dongia],[CachDung]) VALUES(2,N'Rifampin',N'Chai',N'50000',N'Tiêm' )
INSERT INTO [tblBENH] ([maBenh], [tenBenh]) VALUES (1,N'Cảm')
INSERT INTO [tblBENH] ([maBenh], [tenBenh]) VALUES (2,N'Viêm Xoan')

/*SELECT SUM(TH.Dongia*KT.soLuong) AS TIENTHUOC INTO TIENTHUOC FROM tblPKB PKB JOIN tblTOA T ON PKB.maPKB=T.maPKB JOIN tblKETHUOC KT ON T.maToa=KT.maToa JOIN tblTHUOC TH ON KT.maThuoc=TH.maThuoc WHERE PKB.maPKB='6'*/
/*N'Tạo ràng buộc khám tối đa trong ngày'*/
go
create trigger kham_toida1 
ON tblPKB 
FOR INSERT 
AS
BEGIN
	IF (Select Count(a.maPKB)
     From tblPKB a Inner Join INSERTED b On a.NgayKham = b.NgayKham)>40
	BEGIN
		PRINT N'Không được khám quá 40 bệnh nhân trong 1 ngày'
		ROLLBACK TRANSACTION
	END 
END
SELECT maPKB FROM [tblPKB]
SELECT MAX (KQ.MAPKB) AS MM from (SELECT CONVERT(float, tblPKB.maPKB) AS MAPKB FROM tblPKB ) AS KQ
SELECT * FROM [tblPKB] WHERE ([maPKB] LIKE CONCAT('%',6,'%')) OR ([NgayKham]='7/6/2019')