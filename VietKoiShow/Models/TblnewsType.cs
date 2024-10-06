using System;
using System.Collections.Generic;

namespace VietKoiShow.Models;

public partial class TblnewsType
{
    public string NewsTypeId { get; set; } = null!;

    public DateOnly? Date { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Tblnews> Tblnews { get; set; } = new List<Tblnews>();
}
