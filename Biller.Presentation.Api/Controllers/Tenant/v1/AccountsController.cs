using Biller.Application.Models.Tenant.Accounts;
using Biller.Application.UseCase.Tenant.Accounts.Commands.UpdateAccountCommand;
using Biller.Presentation.Api.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biller.Presentation.Api.Controllers.Tenant.v1;

[ApiController]
[Authorize]
[Route("api/Tenant/v1/[controller]")]
public class AccountsController : MainController
{
    private readonly IMediator mediator;

    public AccountsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPut("Update")]
    [ProducesResponseType<Response<AccountDTO>>(StatusCodes.Status200OK)]
    [ProducesResponseType<Response<AccountDTO>>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<Response<AccountDTO>>(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromForm] UpdateAccountCommand request)
    {
        var response = new Response<AccountDTO>();
        var result = await mediator.Send(request);
        response.SetSuccessResponse(result);
        return GetActionResult(response);
    }
}
