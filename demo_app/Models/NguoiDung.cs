using System;
using System.Collections.Generic;

namespace demo_app.Models;

public partial class NguoiDung
{
    public int MaNd { get; set; }

    public string TenDn { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public int? MaNv { get; set; }

    public int MaVt { get; set; }

    public DateTime? NgayTao { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    public virtual NhanVien? MaNvNavigation { get; set; }

    public virtual VaiTro MaVtNavigation { get; set; } = null!;
}
