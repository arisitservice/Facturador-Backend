using Biller.Application.Models.Receptores;
using Biller.Application.UseCase.Contracts;
using Biller.Presentation.Api.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace Biller.Presentation.Api.Controllers.v1;

[ApiController]
[Route("api/v1/[controller]")]
public class ReceptoresController : MainController
{
    private readonly IReceptoresUseCase _receptoresUseCase;

    public ReceptoresController(IReceptoresUseCase receptoresUseCase)
    {
        _receptoresUseCase = receptoresUseCase;
    }

    [HttpPost("Create")]
    [ProducesResponseType<Response<ReceptorResponse>>(StatusCodes.Status201Created)]
    [ProducesResponseType<Response<ReceptorResponse>>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] ReceptorRequest request)
    {
        var response = new Response<ReceptorResponse>();

        var validator = new ReceptorRequestValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(s => new BaseError() { Property = s.PropertyName, ErrorMessage = s.ErrorMessage }).ToList();
            response.SetValidationErrorResponse( errors );

            return GetActionResult(response);
        }

        var result = await _receptoresUseCase.CrearAsync(request);
        response.SetSuccessResponse(result);

        return GetActionResult(response);
    }
}
