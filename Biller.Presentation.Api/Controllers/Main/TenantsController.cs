using Biller.Application.Models.Main.Tenant;
using Biller.Application.UseCase.Main.Tenant.Commands.CreateTenantCommand;
using Biller.Presentation.Api.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Biller.Presentation.Api.Controllers.Main;

[ApiController]
[Route("api/main/[controller]")]
public class TenantsController : MainController
{
    private readonly IMediator mediator;

    public TenantsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost("Create")]
    [ProducesResponseType<Response<TenantCreatedDTO>>(StatusCodes.Status200OK)]
    [ProducesResponseType<Response<TenantCreatedDTO>>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateTenantCommand request)
    {
        var response = new Response<TenantCreatedDTO>();

        var result = await mediator.Send(request);
        response.SetSuccessResponse(result);

        return GetActionResult(response);
    }
}
