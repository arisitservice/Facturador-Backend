
using Biller.Domain.Entities.Main;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Biller.Infrastructure.Persistence.Context;

public class MainDbContext : DbContext
{
    public MainDbContext(DbContextOptions<MainDbContext> options)
       : base(options)
    {
    }

    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var configurations = Assembly.GetExecutingAssembly()
        .GetTypes()
        .Where(t => t.Namespace != null &&
                    t.Namespace.Contains("Biller.Infrastructure.Persistence.Configurations.MainDb") &&
                    t.GetInterfaces().Any(i =>
                        i.IsGenericType &&
                        i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))).ToList();


        foreach (var config in configurations)
        {
            dynamic instance = Activator.CreateInstance(config);
            modelBuilder.ApplyConfiguration(instance);
        }
    }
}
