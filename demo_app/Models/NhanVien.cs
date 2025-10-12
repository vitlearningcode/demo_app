using System;
using System.Collections.Generic;

namespace demo_app.Models;

public partial class NhanVien
{
    public int MaNv { get; set; }

    public string HoTen { get; set; } = null!;

    public string? Sdt { get; set; }

    public string? Email { get; set; }

    public DateOnly? NgayVaoLam { get; set; }

    public bool? TrangThai { get; set; }

    public virtual ICollection<NguoiDung> NguoiDungs { get; set; } = new List<NguoiDung>();
}
