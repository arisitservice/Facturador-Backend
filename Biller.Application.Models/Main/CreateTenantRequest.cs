namespace Biller.Application.Models.Main;

public class CreateTenantRequest
{
    public TenantInfo Tenant { get; set; }
    public OwnerInfo Owner { get; set; }

    public class TenantInfo
    {
        public string Name { get; set; }
        public string Company { get; set; }
    }

    public class OwnerInfo
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
