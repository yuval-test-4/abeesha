using Microsoft.AspNetCore.Mvc;

namespace Abeesha.APIs;

[ApiController()]
public class LocationsController : LocationsControllerBase
{
    public LocationsController(ILocationsService service)
        : base(service) { }
}
