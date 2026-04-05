using Biller.Application.Models.Tenant.CancellationReasons;
using MediatR;

namespace Biller.Application.UseCase.Tenant.CancellationReasons.Queries.GetAllCancellationReasonsQuery;

public sealed class GetAllCancellationReasonsQuery : IRequest<IEnumerable<CancellationReasonDTO>>
{
}
