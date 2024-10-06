using System;
using System.Collections.Generic;

namespace VietKoiShow.Models;

public partial class Tblcompetition
{
    public string CompId { get; set; } = null!;

    public string? CategoryId { get; set; }

    public string? CompName { get; set; }

    public string? CompDescription { get; set; }

    public string? Location { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public bool? Status { get; set; }

    public virtual Tblcategory? Category { get; set; }

    public virtual ICollection<Tblprediction> Tblpredictions { get; set; } = new List<Tblprediction>();

    public virtual ICollection<Tblregistration> Tblregistrations { get; set; } = new List<Tblregistration>();

    public virtual ICollection<Tblscore> Tblscores { get; set; } = new List<Tblscore>();
}
