using System;
using System.Collections.Generic;

namespace VietKoiShow.Models;

public partial class Tblresult
{
    public string ResultId { get; set; } = null!;

    public string? KoiId { get; set; }

    public double? ResultScore { get; set; }

    public string? Prize { get; set; }

    public virtual TblkoiFish? Koi { get; set; }

    public virtual ICollection<TblkoiFish> TblkoiFishes { get; set; } = new List<TblkoiFish>();
}
