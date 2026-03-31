using MediatR;


namespace Biller.Application.UseCase.Tenants.Bills.Commands.CreateBillCommand;

public sealed record CreateBillCommand: IRequest<string>
{
}
