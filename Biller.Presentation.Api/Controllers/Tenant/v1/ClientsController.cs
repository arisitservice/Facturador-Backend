using Biller.Application.Models.Tenant.Clients;
using Biller.Application.UseCase.Tenant.Clients.Commands.CreateClientCommand;
using Biller.Application.UseCase.Tenant.Clients.Commands.DeleteClientCommand;
using Biller.Application.UseCase.Tenant.Clients.Commands.UpdateClientCommand;
using Biller.Application.UseCase.Tenant.Clients.Queries.GetAllClientsQuery;
using Biller.Application.UseCase.Tenant.Clients.Queries.GetClientByIdQuery;
using Biller.Presentation.Api.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Biller.Presentation.Api.Controllers.Tenant.v1;

[ApiController]
[Authorize]
[Route("api/Tenant/v1/[controller]")]
public class ClientsController : MainController
{
    private readonly IMediator mediator;

    public ClientsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost("Create")]
    [ProducesResponseType<Response<ClientDTO>>(StatusCodes.Status200OK)]
    [ProducesResponseType<Response<ClientDTO>>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateClientCommand request)
    {
        var response = new Response<ClientDTO>();
        var result = await mediator.Send(request);
        response.SetSuccessResponse(result);
        return GetActionResult(response);
    }

    [HttpGet("GetAll")]
    [ProducesResponseType<Response<IEnumerable<ClientDTO>>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var response = new Response<IEnumerable<ClientDTO>>();
        var result = await mediator.Send(new GetAllClientsQuery());
        response.SetSuccessResponse(result);
        return GetActionResult(response);
    }

    [HttpGet("GetById/{id:int}")]
    [ProducesResponseType<Response<ClientDTO>>(StatusCodes.Status200OK)]
    [ProducesResponseType<Response<ClientDTO>>(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var response = new Response<ClientDTO>();
        var result = await mediator.Send(new GetClientByIdQuery { Id = id });

        if (result is null)
        {
            response.SetErrorResponse(HttpStatusCode.NotFound, $"Client with id {id} was not found.");
            return GetActionResult(response);
        }

        response.SetSuccessResponse(result);
        return GetActionResult(response);
    }

    [HttpPut("Update/{id:int}")]
    [ProducesResponseType<Response<ClientDTO>>(StatusCodes.Status200OK)]
    [ProducesResponseType<Response<ClientDTO>>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<Response<ClientDTO>>(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateClientCommand request)
    {
        var response = new Response<ClientDTO>();
        request.Id = id;
        var result = await mediator.Send(request);
        response.SetSuccessResponse(result);
        return GetActionResult(response);
    }

    [HttpDelete("Delete/{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType<Response<ClientDTO>>(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteClientCommand { Id = id });
        return NoContent();
    }
}
