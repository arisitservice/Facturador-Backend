using Biller.Application.Models.Tenant.TenantUsers;
using Biller.Application.UseCase.Tenant.TenantUsers.Commands.LoginTenantUserCommand;
using Biller.Presentation.Api.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Biller.Presentation.Api.Controllers.Tenant.v1;

[ApiController]
[Route("api/Tenant/v1/[controller]")]
public class AuthController : MainController
{
    private readonly ISender _sender;

    public AuthController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("Login")]
    [ProducesResponseType<Response<LoginTenantUserDTO>>(StatusCodes.Status200OK)]
    [ProducesResponseType<Response<LoginTenantUserDTO>>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromBody] LoginTenantUserCommand request)
    {
        var response = new Response<LoginTenantUserDTO>();
        var result = await _sender.Send(request);
        response.SetSuccessResponse(result);
        return GetActionResult(response);
    }
}
