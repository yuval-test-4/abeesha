using Abeesha.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Abeesha.Infrastructure;

public class AbeeshaDbContext : IdentityDbContext<IdentityUser>
{
    public AbeeshaDbContext(DbContextOptions<AbeeshaDbContext> options)
        : base(options) { }

    public DbSet<CustomerDbModel> Customers { get; set; }

    public DbSet<OrderDbModel> Orders { get; set; }

    public DbSet<LocationDbModel> Locations { get; set; }
}
