using Biller.Domain.Entities.Common;

namespace Biller.Domain.Entities.Tenant;

public class Client: BaseAuditableEntity
{
    public string Name { get; set; }

    //Relationships
    public IEnumerable<ClientTaxInfo> ClientTaxInfos { get; set; }
}
