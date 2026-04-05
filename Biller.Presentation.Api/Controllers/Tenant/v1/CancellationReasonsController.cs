using Biller.Application.Models.Tenant.CancellationReasons;
using Biller.Application.UseCase.Tenant.CancellationReasons.Queries.GetAllCancellationReasonsQuery;
using Biller.Presentation.Api.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biller.Presentation.Api.Controllers.Tenant.v1;

[ApiController]
[Authorize]
[Route("api/Tenant/v1/[controller]")]
public class CancellationReasonsController : MainController
{
    private readonly ISender _sender;

    public CancellationReasonsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var response = new Response<IEnumerable<CancellationReasonDTO>>();
        var result = await _sender.Send(new GetAllCancellationReasonsQuery());
        response.SetSuccessResponse(result);
        return GetActionResult(response);
    }
}
