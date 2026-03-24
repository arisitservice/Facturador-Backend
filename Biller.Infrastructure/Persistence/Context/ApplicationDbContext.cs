using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Biller.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Domain.Entities.Receptor> Receptores { get; set; }
        public DbSet<Domain.Entities.Emisor> Emisores { get; set; }
        public DbSet<Domain.Entities.Cfdi> Cfdis { get; set; }
        public DbSet<Domain.Entities.RegimenFiscal> RegimenesFiscales { get; set; }
        public DbSet<Domain.Entities.UsoCfdi> UsosCfdi { get; set; }
        public DbSet<Domain.Entities.Moneda> Monedas { get; set; }
        public DbSet<Domain.Entities.UnidadMedida> UnidadesMedida { get; set; }
        public DbSet<Domain.Entities.Producto> Productos { get; set; }
        public DbSet<Domain.Entities.CfdiConcepto> CfdiConceptos { get; set; }
        public DbSet<Domain.Entities.CfdiComplementoPago> CfdiComplementosPago { get; set; }
        public DbSet<Domain.Entities.MotivoCancelacion> MotivosCancelacion { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
