using Abeesha.Infrastructure;

namespace Abeesha.APIs;

public class OrdersService : OrdersServiceBase
{
    public OrdersService(AbeeshaDbContext context)
        : base(context) { }
}
