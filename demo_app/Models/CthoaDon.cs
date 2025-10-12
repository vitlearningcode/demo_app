using System;
using System.Collections.Generic;

namespace demo_app.Models;

public partial class CthoaDon
{
    public int MaCthd { get; set; }

    public int MaHd { get; set; }

    public int MaMon { get; set; }

    public int Sl { get; set; }

    public decimal DonGia { get; set; }

    public decimal? Giam { get; set; }

    public decimal? ThanhTien { get; set; }

    public virtual HoaDon MaHdNavigation { get; set; } = null!;

    public virtual Mon MaMonNavigation { get; set; } = null!;
}
