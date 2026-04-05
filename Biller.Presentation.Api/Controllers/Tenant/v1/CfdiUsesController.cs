using Biller.Application.Models.Tenant.CfdiUses;
using Biller.Application.UseCase.Tenant.CfdiUses.Queries.GetAllCfdiUsesQuery;
using Biller.Presentation.Api.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biller.Presentation.Api.Controllers.Tenant.v1;

[ApiController]
[Authorize]
[Route("api/Tenant/v1/[controller]")]
public class CfdiUsesController : MainController
{
    private readonly ISender _sender;

    public CfdiUsesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var response = new Response<IEnumerable<CfdiUseDTO>>();
        var result = await _sender.Send(new GetAllCfdiUsesQuery());
        response.SetSuccessResponse(result);
        return GetActionResult(response);
    }
}
