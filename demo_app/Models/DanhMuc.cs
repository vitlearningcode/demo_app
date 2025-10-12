using System;
using System.Collections.Generic;

namespace demo_app.Models;

public partial class DanhMuc
{
    public int MaDm { get; set; }

    public string TenDm { get; set; } = null!;

    public string? MoTa { get; set; }

    public virtual ICollection<Mon> Mons { get; set; } = new List<Mon>();
}
