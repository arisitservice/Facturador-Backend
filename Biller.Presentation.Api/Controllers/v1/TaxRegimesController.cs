using Biller.Application.Models.Tenants.TaxRegimes;
using Biller.Application.UseCase.Tenants.TaxRegimes.Queries.GetAllTaxRegimesQuery;
using Biller.Application.UseCase.Tenants.TaxRegimes.Queries.GetTaxRegimeByIdQuery;
using Biller.Presentation.Api.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Biller.Presentation.Api.Controllers.v1;

[ApiController]
[Route("api/v1/[controller]")]
public class TaxRegimesController : MainController
{
    private readonly ISender _sender;

    public TaxRegimesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    [ProducesResponseType<Response<IEnumerable<TaxRegimeDTO>>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var response = new Response<IEnumerable<TaxRegimeDTO>>();
        var result = await _sender.Send(new GetAllTaxRegimesQuery());
        response.SetSuccessResponse(result);
        return GetActionResult(response);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType<Response<TaxRegimeDTO>>(StatusCodes.Status200OK)]
    [ProducesResponseType<Response<TaxRegimeDTO>>(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var response = new Response<TaxRegimeDTO>();
        var result = await _sender.Send(new GetTaxRegimeByIdQuery { Id = id });

        if (result is null)
        {
            response.SetErrorResponse(HttpStatusCode.NotFound, $"TaxRegime with id {id} was not found.");
            return GetActionResult(response);
        }

        response.SetSuccessResponse(result);
        return GetActionResult(response);
    }
}
