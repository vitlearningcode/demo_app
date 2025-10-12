using System;
using System.Collections.Generic;

namespace demo_app.Models;

public partial class KhachHang
{
    public int MaKh { get; set; }

    public string? HoTen { get; set; }

    public string? Sdt { get; set; }

    public string? Email { get; set; }

    public int? DiemTl { get; set; }

    public bool? ThanhVien { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
}
