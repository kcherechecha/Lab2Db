using System;
using System.Collections.Generic;

namespace DBLaba2Cherechecha.SqlModels;

public partial class Movie
{
    public int MovieId { get; set; }

    public string? MovieName { get; set; }

    public int? MovieDuration { get; set; }

    public decimal? MovieRating { get; set; }

    public string? LastModifiedBy { get; set; }

    public byte[] LastModifiedOn { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
