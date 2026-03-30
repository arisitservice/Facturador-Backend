using Biller.Application.Models.TaxRegimes;
using Biller.Application.UseCase.Contracts;
using Biller.Presentation.Api.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Biller.Presentation.Api.Controllers.v1;

[ApiController]
[Route("api/v1/[controller]")]
public class TaxRegimesController : MainController
{
    private readonly ITaxRegimesUseCase _taxRegimesUseCase;

    public TaxRegimesController(ITaxRegimesUseCase taxRegimesUseCase)
    {
        _taxRegimesUseCase = taxRegimesUseCase;
    }

    [HttpGet("GetAll")]
    [ProducesResponseType<Response<IEnumerable<TaxRegimeResponse>>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var response = new Response<IEnumerable<TaxRegimeResponse>>();
        var result = await _taxRegimesUseCase.GetAllAsync();
        response.SetSuccessResponse(result);
        return GetActionResult(response);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType<Response<TaxRegimeResponse>>(StatusCodes.Status200OK)]
    [ProducesResponseType<Response<TaxRegimeResponse>>(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var response = new Response<TaxRegimeResponse>();
        var result = await _taxRegimesUseCase.GetByIdAsync(id);

        if (result is null)
        {
            response.SetErrorResponse(HttpStatusCode.NotFound, $"TaxRegime with id {id} was not found.");
            return GetActionResult(response);
        }

        response.SetSuccessResponse(result);
        return GetActionResult(response);
    }
}
