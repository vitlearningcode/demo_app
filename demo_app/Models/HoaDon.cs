using System;
using System.Collections.Generic;

namespace demo_app.Models;

public partial class HoaDon
{
    public int MaHd { get; set; }

    public string SoHd { get; set; } = null!;

    public int? MaBan { get; set; }

    public int MaNd { get; set; }

    public int? MaKh { get; set; }

    public DateTime? NgayTao { get; set; }

    public DateTime? NgayDong { get; set; }

    public string? TrangThai { get; set; }

    public decimal? TamTinh { get; set; }

    public decimal? Giam { get; set; }

    public decimal? Thue { get; set; }

    public decimal? PhiPv { get; set; }

    public decimal? TongTien { get; set; }

    public int? MaKm { get; set; }

    public virtual ICollection<CthoaDon> CthoaDons { get; set; } = new List<CthoaDon>();

    public virtual Ban? MaBanNavigation { get; set; }

    public virtual KhachHang? MaKhNavigation { get; set; }

    public virtual KhuyenMai? MaKmNavigation { get; set; }

    public virtual NguoiDung MaNdNavigation { get; set; } = null!;

    public virtual ICollection<ThanhToan> ThanhToans { get; set; } = new List<ThanhToan>();
}
