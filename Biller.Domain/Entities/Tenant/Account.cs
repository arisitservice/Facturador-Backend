
using Biller.Domain.Entities.Common;

namespace Biller.Domain.Entities.Tenant;

public class Account:BaseAuditableEntity
{
    public string TenantName { get; set; }
    public string Company { get; set; }
    public string Image { get;  set; }
}
