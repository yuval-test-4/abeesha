using Abeesha.Infrastructure;

namespace Abeesha.APIs;

public class LocationsService : LocationsServiceBase
{
    public LocationsService(AbeeshaDbContext context)
        : base(context) { }
}
