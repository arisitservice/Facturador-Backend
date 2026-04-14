using Biller.Application.Models.Tenant.TaxRegimes;

namespace Biller.Application.Models.Tenant.Clients;

public class ClientDTO
{
    public int Id { get; set; }
    public string Name { get; set; }

    public IEnumerable<ClientTaxInfoDTO> ClientTaxInfos { get; set; }
}

