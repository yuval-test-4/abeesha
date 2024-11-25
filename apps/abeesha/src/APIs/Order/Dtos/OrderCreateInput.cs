namespace Abeesha.APIs.Dtos;

public class OrderCreateInput
{
    public DateTime CreatedAt { get; set; }

    public Customer? Customer { get; set; }

    public string? DeliveryAddress { get; set; }

    public string? Id { get; set; }

    public DateTime? OrderDate { get; set; }

    public double? OrderTotal { get; set; }

    public DateTime UpdatedAt { get; set; }
}
