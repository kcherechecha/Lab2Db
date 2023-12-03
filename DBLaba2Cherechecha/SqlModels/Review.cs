using System;
using System.Collections.Generic;

namespace DBLaba2Cherechecha.SqlModels;

public partial class Review
{
    public int ReviewId { get; set; }

    public int? FkMovieId { get; set; }

    public string? ReviewText { get; set; }

    public decimal? Rating { get; set; }

    public DateOnly? ReviewDate { get; set; }

    public string? LastModifiedBy { get; set; }

    public byte[] LastModifiedOn { get; set; } = null!;

    public virtual Movie? FkMovie { get; set; }
}
