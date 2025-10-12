using System;
using System.Collections.Generic;

namespace demo_app.Models;

public partial class Ban
{
    public int MaBan { get; set; }

    public string TenBan { get; set; } = null!;

    public int? SoCho { get; set; }

    public string? TrangThai { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
}
