using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Valhalla.Domain.Partner;

namespace Valhalla.Application.Data;

public class ValhallaDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public ValhallaDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public ValhallaDbContext(DbContextOptions<ValhallaDbContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ValhallaConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Partners>(entity =>
        {
            entity.ToTable(nameof(Partners));

            entity.Property(e => e.Id).HasColumnName("Id");
            
            entity.HasIndex(e => e.PartnerName, "PARAM_NAME_UNIQUE")
                .IsUnique();
            entity.Property(e => e.PartnerName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

        });
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ValhallaDbContext).Assembly);
    }
}