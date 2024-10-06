using System;
using System.Collections.Generic;

namespace VietKoiShow.Models;

public partial class Tblnews
{
    public string NewsId { get; set; } = null!;

    public string? NewsTypeId { get; set; }

    public string? UserId { get; set; }

    public DateOnly? Date { get; set; }

    public virtual TblnewsType? NewsType { get; set; }

    public virtual Tbluser? User { get; set; }
}
