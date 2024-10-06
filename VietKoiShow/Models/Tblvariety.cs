using System;
using System.Collections.Generic;

namespace VietKoiShow.Models;

public partial class Tblvariety
{
    public string VarietyId { get; set; } = null!;

    public string? VarietyName { get; set; }

    public string? Origin { get; set; }

    public string? VarietyDescription { get; set; }

    public virtual ICollection<TblkoiFish> TblkoiFishes { get; set; } = new List<TblkoiFish>();
}
