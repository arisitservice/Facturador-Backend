using Biller.Application.Models.Main;
using Biller.Application.UseCase.Contracts.Main;
using Biller.Presentation.Api.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace Biller.Presentation.Api.Controllers.Main;

[ApiController]
[Route("api/main/[controller]")]
public class TenantsController : MainController
{
    private readonly ITenantsUseCase _tenantsUseCase;

    public TenantsController(ITenantsUseCase tenantsUseCase)
    {
        _tenantsUseCase = tenantsUseCase;
    }

    [HttpPost("Create")]
    [ProducesResponseType<Response<CreateTenantResponse>>(StatusCodes.Status200OK)]
    [ProducesResponseType<Response<CreateTenantResponse>>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateTenantRequest request)
    {
        var response = new Response<CreateTenantResponse>();

        var validator = new CreateTenantRequestValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors
                .Select(e => new BaseError { Property = e.PropertyName, ErrorMessage = e.ErrorMessage })
                .ToList();

            response.SetValidationErrorResponse(errors);
            return GetActionResult(response);
        }

        var result = await _tenantsUseCase.CrearAsync(request);
        response.SetSuccessResponse(result);

        return GetActionResult(response);
    }
}
