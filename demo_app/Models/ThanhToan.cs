using System;
using System.Collections.Generic;

namespace demo_app.Models;

public partial class ThanhToan
{
    public int MaTt { get; set; }

    public int MaHd { get; set; }

    public decimal SoTien { get; set; }

    public string HinhThuc { get; set; } = null!;

    public DateTime? NgayTt { get; set; }

    public string? GhiChu { get; set; }

    public virtual HoaDon MaHdNavigation { get; set; } = null!;
}
