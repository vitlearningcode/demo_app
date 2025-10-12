using System;
using System.Collections.Generic;

namespace demo_app.Models;

public partial class VaiTro
{
    public int MaVt { get; set; }

    public string TenVt { get; set; } = null!;

    public virtual ICollection<NguoiDung> NguoiDungs { get; set; } = new List<NguoiDung>();
}
