using Biller.Domain.Entities.Tenant;

namespace Biller.Application.Models.Tenant.Clients;

public class ClientDTO
{
    public int Id { get; set; }
    public string TaxAddress { get; set; }
    public string PostalCode { get; set; }
    public string Name { get; set; }
    public string BusinessName { get; set; }
    public string TaxId { get; set; }
    public int? TaxRegimeId { get; set; }
}
