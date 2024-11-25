using Abeesha.APIs.Dtos;
using Abeesha.Infrastructure.Models;

namespace Abeesha.APIs.Extensions;

public static class OrdersExtensions
{
    public static Order ToDto(this OrderDbModel model)
    {
        return new Order
        {
            CreatedAt = model.CreatedAt,
            Customer = model.CustomerId,
            DeliveryAddress = model.DeliveryAddress,
            Id = model.Id,
            OrderDate = model.OrderDate,
            OrderTotal = model.OrderTotal,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static OrderDbModel ToModel(
        this OrderUpdateInput updateDto,
        OrderWhereUniqueInput uniqueId
    )
    {
        var order = new OrderDbModel
        {
            Id = uniqueId.Id,
            DeliveryAddress = updateDto.DeliveryAddress,
            OrderDate = updateDto.OrderDate,
            OrderTotal = updateDto.OrderTotal
        };

        if (updateDto.CreatedAt != null)
        {
            order.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Customer != null)
        {
            order.CustomerId = updateDto.Customer;
        }
        if (updateDto.UpdatedAt != null)
        {
            order.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return order;
    }
}
