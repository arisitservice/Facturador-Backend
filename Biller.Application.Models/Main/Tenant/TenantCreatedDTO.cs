namespace Biller.Application.Models.Main.Tenant;

public class TenantCreatedDTO
{
    public Guid TenantId { get; set; }
    public string Name { get; set; }
    public string Company { get; set; }
    public string Email { get; set; }
    public string Subdomain { get; set; }

    public User Owner { get; set; }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
