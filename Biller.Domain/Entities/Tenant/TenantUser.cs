

using Biller.Domain.Entities.Common;
using Biller.Domain.Enums;
using Biller.Domain.Enums.Tenant;

namespace Biller.Domain.Entities.Tenant;

public class TenantUser: BaseAuditableEntity
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public TenantUserType UserType { get; set; }
    public Status Status { get; set; }
}
