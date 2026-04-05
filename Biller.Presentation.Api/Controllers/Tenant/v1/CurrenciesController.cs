using Biller.Application.Models.Tenant.Currencies;
using Biller.Application.UseCase.Tenant.Currencies.Queries.GetAllCurrenciesQuery;
using Biller.Presentation.Api.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biller.Presentation.Api.Controllers.Tenant.v1;

[ApiController]
[Authorize]
[Route("api/Tenant/v1/[controller]")]
public class CurrenciesController : MainController
{
    private readonly ISender _sender;

    public CurrenciesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var response = new Response<IEnumerable<CurrencyDTO>>();
        var result = await _sender.Send(new GetAllCurrenciesQuery());
        response.SetSuccessResponse(result);
        return GetActionResult(response);
    }
}
