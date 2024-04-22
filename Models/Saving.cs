using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseholdManagerApi.Models;

public partial class Saving
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public uint Amount { get; set; }

    public int? Goal { get; set; }

    public string Currency { get; set; } = null!;

    [ForeignKey(nameof(Tag))]
    public int? TagId { get; set; }

    [ForeignKey(nameof(User))]
    public string UserId { get; set; } = null!;

    public virtual Tag? Tag { get; set; }

    public virtual IdentityUser User { get; set; } = null!;
}
