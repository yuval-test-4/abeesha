using Microsoft.AspNetCore.Mvc;

namespace Abeesha.APIs;

[ApiController()]
public class OrdersController : OrdersControllerBase
{
    public OrdersController(IOrdersService service)
        : base(service) { }
}
