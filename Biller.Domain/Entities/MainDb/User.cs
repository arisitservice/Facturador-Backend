

using Biller.Domain.Entities.Common;
using Biller.Domain.Enums;

namespace Biller.Domain.Entities.MainDb;

public class User: BaseAuditableEntity
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public UserType UserType { get; set; }
    public Guid TenantId { get; set; }
}
