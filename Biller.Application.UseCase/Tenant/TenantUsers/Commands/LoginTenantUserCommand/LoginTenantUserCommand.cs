using Biller.Application.Models.Tenant.TenantUsers;
using MediatR;

namespace Biller.Application.UseCase.Tenant.TenantUsers.Commands.LoginTenantUserCommand;

public sealed class LoginTenantUserCommand : IRequest<LoginTenantUserDTO>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
