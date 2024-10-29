using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;
using NRG3.Bliss.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace NRG3.Bliss.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //TODO: Add database configuration modeling here
        
        builder.Entity<Service>().HasKey(s => s.Id);
        builder.Entity<Service>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Service>().Property(s => s.ServiceName).IsRequired().HasMaxLength(100);
        builder.Entity<Service>().Property(s => s.Price).IsRequired();
        builder.Entity<Service>().Property(s => s.Duration).IsRequired();
        builder.Entity<Service>().Property(s => s.Description).HasMaxLength(500);
        
        builder.Entity<Category>().HasKey(c => c.Id);
        builder.Entity<Category>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Category>().Property(c => c.Description).HasMaxLength(500);
        
        builder.Entity<Company>().HasKey(c => c.Id);
        builder.Entity<Company>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Company>().Property(c => c.Name).IsRequired().HasMaxLength(100);
        builder.Entity<Company>().Property(c => c.Ruc).HasMaxLength(11);
        
        builder.Entity<Category>()
            .HasMany(c => c.Services)
            .WithOne(s => s.Category)
            .HasForeignKey(s => s.CategoryId)
            .HasPrincipalKey(c => c.Id);
        
        builder.Entity<Company>()
            .HasMany(c => c.Services)
            .WithOne(s => s.Company)
            .HasForeignKey(s => s.CompanyId)
            .HasPrincipalKey(c => c.Id);
        
        builder.UseSnakeCaseNamingConvention();
    }
}