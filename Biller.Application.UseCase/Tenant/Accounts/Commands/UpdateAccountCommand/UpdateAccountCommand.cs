using Biller.Application.Models.Tenant.Accounts;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Biller.Application.UseCase.Tenant.Accounts.Commands.UpdateAccountCommand;

public sealed class UpdateAccountCommand : IRequest<AccountDTO>
{
    public string TenantName { get; set; }
    public string Company { get; set; }
    public IFormFile Image { get; set; }
}
