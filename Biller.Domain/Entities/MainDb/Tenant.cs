
namespace Biller.Domain.Entities.MainDb;

public class Tenant
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Company { get; set; }
    public string Email { get; set; }
    public string Subdomain { get; set; }
    public string ConnectionString { get; set; }
}
