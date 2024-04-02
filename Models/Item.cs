using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Item
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid CategoryId { get; set; }

    public virtual Tag Category { get; set; } = null!;
}
