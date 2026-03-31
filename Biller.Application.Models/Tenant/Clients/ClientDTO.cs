using Biller.Domain.Entities.Tenant;

namespace Biller.Application.Models.Tenant.Clients;

public class ClientDTO
{
    public int Id { get; set; }
    public string DomicilioFiscal { get; set; }
    public string CodigoPostal { get; set; }
    public string Nombre { get; set; }
    public string RazonSocial { get; set; }
    public string Rfc { get; set; }
    public int IdRegimenFiscal { get; set; }
    public int IdUsoCfdi { get; set; }

    public static ClientDTO FromEntity(Client client) => new()
    {
        Id              = client.Id,
        DomicilioFiscal = client.TaxAddress,
        CodigoPostal    = client.PostalCode,
        Nombre          = client.Name,
        RazonSocial     = client.BusinessName,
        Rfc             = client.TaxId,
        IdRegimenFiscal = client.TaxRegimeId
    };
}
