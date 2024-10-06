using System;
using System.Collections.Generic;

namespace VietKoiShow.Models;

public partial class Tbluser
{
    public string UserId { get; set; } = null!;

    public string? RoleId { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? FullName { get; set; }

    public string? Phone { get; set; }

    public virtual Tblrole? Role { get; set; }

    public virtual ICollection<TblkoiFish> TblkoiFishes { get; set; } = new List<TblkoiFish>();

    public virtual ICollection<Tblnews> Tblnews { get; set; } = new List<Tblnews>();

    public virtual ICollection<Tblscore> Tblscores { get; set; } = new List<Tblscore>();
}
