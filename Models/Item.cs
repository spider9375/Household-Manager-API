using System;
using System.Collections.Generic;

namespace HouseholdManagerApi.Models;

public partial class Item
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CategoryId { get; set; }

    public virtual Tag Category { get; set; } = null!;
}
