
using Biller.Domain.Entities.Tenant;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Biller.Infrastructure.Persistence.Contexts
{
    public class TenantDbContext : DbContext
    {

        public TenantDbContext(DbContextOptions<TenantDbContext> options) : base(options)
        {}

        public DbSet<Client> Clients { get; set; }
        public DbSet<TaxRegime> TaxRegimes { get; set; }
        public DbSet<TenantUser> TenantUsers { get; set; }

        //public DbSet<Domain.Entities.Emisor> Emisores { get; set; }
        //public DbSet<Domain.Entities.Cfdi> Cfdis { get; set; }
        //public DbSet<Domain.Entities.UsoCfdi> UsosCfdi { get; set; }
        //public DbSet<Domain.Entities.Moneda> Monedas { get; set; }
        //public DbSet<Domain.Entities.UnidadMedida> UnidadesMedida { get; set; }
        //public DbSet<Domain.Entities.Producto> Productos { get; set; }
        //public DbSet<Domain.Entities.CfdiConcepto> CfdiConceptos { get; set; }
        //public DbSet<Domain.Entities.CfdiComplementoPago> CfdiComplementosPago { get; set; }
        //public DbSet<Domain.Entities.MotivoCancelacion> MotivosCancelacion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var configurations = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.Namespace != null &&
                        t.Namespace.Contains("Biller.Infrastructure.Persistence.Configurations.TenantDb") &&
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
}
