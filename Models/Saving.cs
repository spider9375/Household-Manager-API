using System;
using System.Collections.Generic;

namespace HouseholdManagerApi.Models;

public partial class Saving
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public uint Amount { get; set; }

    public int? Goal { get; set; }

    public string? Icon { get; set; }

    public string Currency { get; set; } = null!;

    public Guid TagId { get; set; }

    public virtual Tag Tag { get; set; } = null!;
}
