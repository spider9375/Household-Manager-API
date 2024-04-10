using System;
using System.Collections.Generic;

namespace HouseholdManagerApi.Models;

public partial class Item
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? TagId { get; set; }

    public string? Quantity { get; set; }

    public string? UnitOfMeasure { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public virtual Tag? Tag { get; set; }
}
