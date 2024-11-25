using Abeesha.APIs.Dtos;
using Abeesha.Infrastructure.Models;

namespace Abeesha.APIs.Extensions;

public static class LocationsExtensions
{
    public static Location ToDto(this LocationDbModel model)
    {
        return new Location
        {
            City = model.City,
            Country = model.Country,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            Latitude = model.Latitude,
            Longitude = model.Longitude,
            State = model.State,
            StreetAddress = model.StreetAddress,
            UpdatedAt = model.UpdatedAt,
            ZipCode = model.ZipCode,
        };
    }

    public static LocationDbModel ToModel(
        this LocationUpdateInput updateDto,
        LocationWhereUniqueInput uniqueId
    )
    {
        var location = new LocationDbModel
        {
            Id = uniqueId.Id,
            City = updateDto.City,
            Country = updateDto.Country,
            Latitude = updateDto.Latitude,
            Longitude = updateDto.Longitude,
            State = updateDto.State,
            StreetAddress = updateDto.StreetAddress,
            ZipCode = updateDto.ZipCode
        };

        if (updateDto.CreatedAt != null)
        {
            location.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            location.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return location;
    }
}
