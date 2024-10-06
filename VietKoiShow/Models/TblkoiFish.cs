﻿using System;
using System.Collections.Generic;

namespace VietKoiShow.Models;

public partial class TblkoiFish
{
    public string KoiId { get; set; } = null!;

    public string? VarietyId { get; set; }

    public string? UserId { get; set; }

    public string? ResultId { get; set; }

    public string? KoiName { get; set; }

    public int? Size { get; set; }

    public int? Age { get; set; }

    public virtual Tblresult? Result { get; set; }

    public virtual ICollection<Tblprediction> Tblpredictions { get; set; } = new List<Tblprediction>();

    public virtual ICollection<Tblregistration> Tblregistrations { get; set; } = new List<Tblregistration>();

    public virtual ICollection<Tblresult> Tblresults { get; set; } = new List<Tblresult>();

    public virtual ICollection<Tblscore> Tblscores { get; set; } = new List<Tblscore>();

    public virtual Tbluser? User { get; set; }

    public virtual Tblvariety? Variety { get; set; }
}
