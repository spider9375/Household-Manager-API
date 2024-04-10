using System;
using System.Collections.Generic;

namespace HouseholdManagerApi.Models;

public partial class Tag
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Color { get; set; }

    public string? Icon { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual ICollection<Saving> Savings { get; set; } = new List<Saving>();
}
