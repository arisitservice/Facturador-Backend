namespace Biller.Application.Models.Main;

public class CreateTenantResponse
{
    public Guid TenantId { get; set; }
    public string Name { get; set; }
    public string Company { get; set; }
    public string Email { get; set; }
    public string Subdomain { get; set; }

    public OwnerCreated Owner { get; set; }

    public class OwnerCreated
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
