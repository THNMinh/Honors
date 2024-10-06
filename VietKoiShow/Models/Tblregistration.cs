using System;
using System.Collections.Generic;

namespace VietKoiShow.Models;

public partial class Tblregistration
{
    public string RegistrationId { get; set; } = null!;

    public string? KoiId { get; set; }

    public string? CompId { get; set; }

    public int? Status { get; set; }

    public virtual Tblcompetition? Comp { get; set; }

    public virtual TblkoiFish? Koi { get; set; }
}
