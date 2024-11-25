using Microsoft.AspNetCore.Mvc;

namespace Abeesha.APIs;

[ApiController()]
public class CustomersController : CustomersControllerBase
{
    public CustomersController(ICustomersService service)
        : base(service) { }
}
