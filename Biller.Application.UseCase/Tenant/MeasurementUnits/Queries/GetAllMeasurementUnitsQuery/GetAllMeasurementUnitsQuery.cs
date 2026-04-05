using Biller.Application.Models.Tenant.MeasurementUnits;
using MediatR;

namespace Biller.Application.UseCase.Tenant.MeasurementUnits.Queries.GetAllMeasurementUnitsQuery;

public sealed class GetAllMeasurementUnitsQuery : IRequest<IEnumerable<MeasurementUnitDTO>>
{
}
