using System;
using System.Collections.Generic;

namespace VietKoiShow.Models;

public partial class Tblcategory
{
    public string CategoryId { get; set; } = null!;

    public string? CategoryName { get; set; }

    public string? Species { get; set; }

    public int? Size { get; set; }

    public int? Age { get; set; }

    public string? CategoryDescription { get; set; }

    public virtual ICollection<Tblcompetition> Tblcompetitions { get; set; } = new List<Tblcompetition>();
}
