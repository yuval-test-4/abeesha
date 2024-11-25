using Abeesha.APIs;
using Abeesha.APIs.Common;
using Abeesha.APIs.Dtos;
using Abeesha.APIs.Errors;
using Abeesha.APIs.Extensions;
using Abeesha.Infrastructure;
using Abeesha.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Abeesha.APIs;

public abstract class LocationsServiceBase : ILocationsService
{
    protected readonly AbeeshaDbContext _context;

    public LocationsServiceBase(AbeeshaDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Location
    /// </summary>
    public async Task<Location> CreateLocation(LocationCreateInput createDto)
    {
        var location = new LocationDbModel
        {
            City = createDto.City,
            Country = createDto.Country,
            CreatedAt = createDto.CreatedAt,
            Latitude = createDto.Latitude,
            Longitude = createDto.Longitude,
            State = createDto.State,
            StreetAddress = createDto.StreetAddress,
            UpdatedAt = createDto.UpdatedAt,
            ZipCode = createDto.ZipCode
        };

        if (createDto.Id != null)
        {
            location.Id = createDto.Id;
        }

        _context.Locations.Add(location);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<LocationDbModel>(location.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Location
    /// </summary>
    public async Task DeleteLocation(LocationWhereUniqueInput uniqueId)
    {
        var location = await _context.Locations.FindAsync(uniqueId.Id);
        if (location == null)
        {
            throw new NotFoundException();
        }

        _context.Locations.Remove(location);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Locations
    /// </summary>
    public async Task<List<Location>> Locations(LocationFindManyArgs findManyArgs)
    {
        var locations = await _context
            .Locations.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return locations.ConvertAll(location => location.ToDto());
    }

    /// <summary>
    /// Meta data about Location records
    /// </summary>
    public async Task<MetadataDto> LocationsMeta(LocationFindManyArgs findManyArgs)
    {
        var count = await _context.Locations.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Location
    /// </summary>
    public async Task<Location> Location(LocationWhereUniqueInput uniqueId)
    {
        var locations = await this.Locations(
            new LocationFindManyArgs { Where = new LocationWhereInput { Id = uniqueId.Id } }
        );
        var location = locations.FirstOrDefault();
        if (location == null)
        {
            throw new NotFoundException();
        }

        return location;
    }

    /// <summary>
    /// Update one Location
    /// </summary>
    public async Task UpdateLocation(
        LocationWhereUniqueInput uniqueId,
        LocationUpdateInput updateDto
    )
    {
        var location = updateDto.ToModel(uniqueId);

        _context.Entry(location).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Locations.Any(e => e.Id == location.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
