using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abeesha.Infrastructure.Models;

[Table("Locations")]
public class LocationDbModel
{
    [StringLength(1000)]
    public string? City { get; set; }

    [StringLength(1000)]
    public string? Country { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [Range(-999999999, 999999999)]
    public double? Latitude { get; set; }

    [Range(-999999999, 999999999)]
    public double? Longitude { get; set; }

    [StringLength(1000)]
    public string? State { get; set; }

    [StringLength(1000)]
    public string? StreetAddress { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    [StringLength(1000)]
    public string? ZipCode { get; set; }
}
