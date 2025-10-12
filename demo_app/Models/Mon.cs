using System;
using System.Collections.Generic;

namespace demo_app.Models;

public partial class Mon
{
    public int MaMon { get; set; }

    public int? MaDm { get; set; }

    public string TenMon { get; set; } = null!;

    public decimal DonGia { get; set; }

    public decimal? GiaVon { get; set; }

    public bool? HoatDong { get; set; }

    public virtual ICollection<CthoaDon> CthoaDons { get; set; } = new List<CthoaDon>();

    public virtual DanhMuc? MaDmNavigation { get; set; }
}
