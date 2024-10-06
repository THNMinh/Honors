using System;
using System.Collections.Generic;

namespace VietKoiShow.Models;

public partial class Tblscore
{
    public string ScoreId { get; set; } = null!;

    public string? KoiId { get; set; }

    public string? CompId { get; set; }

    public string? UserId { get; set; }

    public double? ScoreShape { get; set; }

    public double? ScoreColor { get; set; }

    public double? ScorePattern { get; set; }

    public double? TotalScore { get; set; }

    public virtual Tblcompetition? Comp { get; set; }

    public virtual TblkoiFish? Koi { get; set; }

    public virtual Tbluser? User { get; set; }
}
