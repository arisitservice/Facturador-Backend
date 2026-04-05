using Biller.Application.Models.Tenant.MeasurementUnits;
using Biller.Application.UseCase.Tenant.MeasurementUnits.Queries.GetAllMeasurementUnitsQuery;
using Biller.Presentation.Api.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biller.Presentation.Api.Controllers.Tenant.v1;

[ApiController]
[Authorize]
[Route("api/Tenant/v1/[controller]")]
public class MeasurementUnitsController : MainController
{
    private readonly ISender _sender;

    public MeasurementUnitsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var response = new Response<IEnumerable<MeasurementUnitDTO>>();
        var result = await _sender.Send(new GetAllMeasurementUnitsQuery());
        response.SetSuccessResponse(result);
        return GetActionResult(response);
    }
}
