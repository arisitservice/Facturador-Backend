namespace Biller.Application.Models.Tenant.TenantUsers;

public class LoginTenantUserDTO
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string UserType { get; set; }
    public string Token { get; set; }
    public DateTime ExpiresAt { get; set; }
}
