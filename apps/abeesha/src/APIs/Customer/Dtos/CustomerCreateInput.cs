namespace Abeesha.APIs.Dtos;

public class CustomerCreateInput
{
    public string? Address { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? Id { get; set; }

    public string? LastName { get; set; }

    public List<Order>? Orders { get; set; }

    public string? PhoneNumber { get; set; }

    public DateTime UpdatedAt { get; set; }
}