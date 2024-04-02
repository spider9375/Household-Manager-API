using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

/// <summary>
/// nomenclature that hold all possible categories for every item in the household
/// </summary>
public partial class Tag
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Color { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual ICollection<Saving> Savings { get; set; } = new List<Saving>();
}
