using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Models.Tenant.MeasurementUnits;
using Biller.Shared.ExtensionMethods;
using MediatR;

namespace Biller.Application.UseCase.Tenant.MeasurementUnits.Queries.GetAllMeasurementUnitsQuery;

public class GetAllMeasurementUnitsHandler : IRequestHandler<GetAllMeasurementUnitsQuery, IEnumerable<MeasurementUnitDTO>>
{
    private readonly ITenantUnitOfWork _unitOfWork;

    public GetAllMeasurementUnitsHandler(ITenantUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<MeasurementUnitDTO>> Handle(GetAllMeasurementUnitsQuery request, CancellationToken cancellationToken)
    {
        var units = await _unitOfWork.MeasurementUnits.GetAllAsync();
        return units.Select(x => x.CastTo<MeasurementUnitDTO>()).ToList();
    }
}
