using Biller.Application.Models.Main.Tenant;
using MediatR;


namespace Biller.Application.UseCase.Main.Tenant.Commands.CreateTenantCommand;

public sealed class CreateTenantCommand: IRequest<TenantCreatedDTO>
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
