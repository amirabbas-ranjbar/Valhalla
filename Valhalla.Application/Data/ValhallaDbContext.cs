using Microsoft.EntityFrameworkCore;
using Valhalla.Domain.Partner;

namespace Valhalla.Application.Data;

public class ValhallaDbContext : DbContext
{
    public const string DefaultSchema = "Valhalla";

  
    public ValhallaDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Partners> Partners { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        modelBuilder.HasDefaultSchema(DefaultSchema);
    }
}