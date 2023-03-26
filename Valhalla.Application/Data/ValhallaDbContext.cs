using Microsoft.EntityFrameworkCore;
using Valhalla.Domain.Partner;

namespace Valhalla.Application.Data;

public class ValhallaDbContext : DbContext
{
    public DbSet<Partners> Partners { get; set; }

  
    public ValhallaDbContext(DbContextOptions options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Partners>().ToTable(nameof(Partners), t => t.ExcludeFromMigrations());
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ValhallaDbContext).Assembly);
    }
}