using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abeesha.Infrastructure.Models;

[Table("Orders")]
public class OrderDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    public string? CustomerId { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public CustomerDbModel? Customer { get; set; } = null;

    [StringLength(1000)]
    public string? DeliveryAddress { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    public DateTime? OrderDate { get; set; }

    [Range(-999999999, 999999999)]
    public double? OrderTotal { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
