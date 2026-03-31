using Biller.Application.Models.Tenants.Clients;
using Biller.Application.UseCase.Tenants.Clients.Commands.CreateClientCommand;
using Biller.Presentation.Api.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Biller.Presentation.Api.Controllers.v1;

[ApiController]
[Route("api/v1/[controller]")]
public class ClientsController : MainController
{
    private readonly IMediator mediator;

    public ClientsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost("Create")]
    [ProducesResponseType<Response<ClientDTO>>(StatusCodes.Status201Created)]
    [ProducesResponseType<Response<ClientDTO>>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateClientCommand request)
    {
        var response = new Response<ClientDTO>();

        var result = await mediator.Send(request);
        response.SetSuccessResponse(result);

        return GetActionResult(response);
    }
}
