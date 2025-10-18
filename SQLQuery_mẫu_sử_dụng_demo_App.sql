-- HÃY THAY TÊN DATABASE CỦA BẠN VÀO ĐÂY
USE [demo];
GO

-- XÓA DỮ LIỆU CŨ VÀ RESET SỐ THỨ TỰ TỰ ĐỘNG TĂNG
DELETE FROM ThanhToan; DBCC CHECKIDENT ('ThanhToan', RESEED, 0);
DELETE FROM CTHoaDon; DBCC CHECKIDENT ('CTHoaDon', RESEED, 0);
DELETE FROM HoaDon; DBCC CHECKIDENT ('HoaDon', RESEED, 0);
DELETE FROM NguoiDung; DBCC CHECKIDENT ('NguoiDung', RESEED, 0);
DELETE FROM NhanVien; DBCC CHECKIDENT ('NhanVien', RESEED, 0);
DELETE FROM VaiTro; DBCC CHECKIDENT ('VaiTro', RESEED, 0);
DELETE FROM Mon; DBCC CHECKIDENT ('Mon', RESEED, 0);
DELETE FROM DanhMuc; DBCC CHECKIDENT ('DanhMuc', RESEED, 0);
DELETE FROM Ban; DBCC CHECKIDENT ('Ban', RESEED, 0);
GO

-- THÊM DỮ LIỆU MỚI

-- 1. Bảng Vai Trò
INSERT INTO VaiTro (TenVT) VALUES (N'Admin'),(N'Quản lý'),(N'Thu ngân');
GO

-- 2. Bảng Nhân Viên
INSERT INTO NhanVien (HoTen, SDT, Email, NgayVaoLam) VALUES
(N'Nguyễn Văn An', '090111222', 'an.nv@test.com', '2023-01-15'),
(N'Trần Thị Bình', '090333444', 'binh.tt@test.com', '2023-03-20');
GO

-- 3. Bảng Người Dùng
INSERT INTO NguoiDung (TenDN, MatKhau, MaNV, MaVT) VALUES
('admin', '123', 1, 1),
('thungan', '123', 2, 3);
GO

-- 4. Bảng Bàn
INSERT INTO Ban (TenBan, SoCho, TrangThai) VALUES
(N'Bàn 1', 4, N'Trống'), (N'Bàn 2', 4, N'Có khách'), (N'Bàn 3', 2, N'Trống'),
(N'Bàn 4', 2, N'Trống'), (N'Bàn 5', 6, N'Đã đặt'),(N'Bàn 6', 4, N'Trống');
GO

-- 5. Bảng Danh Mục Món
INSERT INTO DanhMuc (TenDM) VALUES (N'Cà phê'),(N'Trà'),(N'Bánh ngọt');
GO

-- 6. Bảng Món
INSERT INTO Mon (MaDM, TenMon, DonGia) VALUES
(1, N'Cà phê Đen', 25000), (1, N'Cà phê Sữa', 30000), (1, N'Bạc xỉu', 35000),
(2, N'Trà Đào', 40000), (2, N'Trà Vải', 40000), (3, N'Bánh Tiramisu', 35000),
(3, N'Bánh Sừng Bò', 20000);
GO

-- 7. TẠO HÓA ĐƠN VÀ CHI TIẾT HÓA ĐƠN (TRONG CÙNG 1 KHỐI LỆNH)
-- Bắt đầu khối lệnh
BEGIN
    -- Tạo hóa đơn cho Bàn 2
    INSERT INTO HoaDon (SoHD, MaBan, MaND, TrangThai) VALUES ('HD0001', 2, 2, N'Mở');
    
    -- Lấy MaHD của hóa đơn vừa tạo
    DECLARE @MaHD_Moi INT;
    SET @MaHD_Moi = SCOPE_IDENTITY();
    
    -- Thêm chi tiết cho hóa đơn đó
    INSERT INTO CTHoaDon (MaHD, MaMon, SL, DonGia) VALUES
    (@MaHD_Moi, 2, 1, 30000), -- Cà phê Sữa
    (@MaHD_Moi, 6, 2, 35000); -- Bánh Tiramisu
    
    -- Cập nhật tổng tiền cho hóa đơn
    UPDATE HoaDon
    SET TamTinh = (SELECT SUM(ThanhTien) FROM CTHoaDon WHERE MaHD = @MaHD_Moi)
    WHERE MaHD = @MaHD_Moi;
END
GO -- Kết thúc khối lệnh ở đây

-- In ra thông báo thành công
PRINT 'DA TAO DU LIEU MAU THANH CONG!';
GO
