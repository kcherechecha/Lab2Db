using System;
using System.Collections.Generic;

namespace DBLaba2Cherechecha.SqlModels;

public partial class Session
{
    public int SessionId { get; set; }

    public int? SessionNumber { get; set; }

    public int? FkMovieId { get; set; }

    public string? FkHallId { get; set; }

    public int? FkSessionStatusId { get; set; }

    public string? LastModifiedBy { get; set; }

    public byte[] LastModifiedOn { get; set; } = null!;

    public virtual Movie? FkMovie { get; set; }
}
