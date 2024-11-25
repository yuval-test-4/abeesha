namespace Abeesha.APIs.Dtos;

public class LocationUpdateInput
{
    public string? City { get; set; }

    public string? Country { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public string? State { get; set; }

    public string? StreetAddress { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? ZipCode { get; set; }
}
