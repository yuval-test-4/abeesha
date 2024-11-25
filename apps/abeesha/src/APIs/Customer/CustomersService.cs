using Abeesha.Infrastructure;

namespace Abeesha.APIs;

public class CustomersService : CustomersServiceBase
{
    public CustomersService(AbeeshaDbContext context)
        : base(context) { }
}
