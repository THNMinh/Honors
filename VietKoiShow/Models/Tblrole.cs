using System;
using System.Collections.Generic;

namespace VietKoiShow.Models;

public partial class Tblrole
{
    public string RoleId { get; set; } = null!;

    public string? RoleName { get; set; }

    public string? RoleDescription { get; set; }

    public int? Experience { get; set; }

    public virtual ICollection<Tbluser> Tblusers { get; set; } = new List<Tbluser>();
}
