namespace Abeesha.APIs.Dtos;

public class OrderUpdateInput
{
    public DateTime? CreatedAt { get; set; }

    public string? Customer { get; set; }

    public string? DeliveryAddress { get; set; }

    public string? Id { get; set; }

    public DateTime? OrderDate { get; set; }

    public double? OrderTotal { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
