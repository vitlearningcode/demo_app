using System;
using System.Collections.Generic;

namespace demo_app.Models;

public partial class KhuyenMai
{
    public int MaKm { get; set; }

    public string? MaCode { get; set; }

    public string? MoTa { get; set; }

    public decimal? GiamPt { get; set; }

    public decimal? GiamTien { get; set; }

    public DateTime? BatDau { get; set; }

    public DateTime? KetThuc { get; set; }

    public bool? HoatDong { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
}
