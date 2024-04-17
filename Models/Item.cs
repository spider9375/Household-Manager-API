using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseholdManagerApi.Models;

public partial class Item
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    [ForeignKey(nameof(Tag))]
    public int? TagId { get; set; }

    public string? Quantity { get; set; }

    public string? UnitOfMeasure { get; set; }

    public DateTime? ExpirationDate { get; set; }

    [ForeignKey(nameof(User))]
    public string UserId { get; set; } = null!;

    public virtual Tag? Tag { get; set; }

    public virtual IdentityUser User { get; set; } = null!;
}
