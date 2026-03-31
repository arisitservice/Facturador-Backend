using MediatR;


namespace Biller.Application.UseCase.Tenant.Bills.Commands.CreateBillCommand;

public sealed record CreateBillCommand: IRequest<string>
{
}
