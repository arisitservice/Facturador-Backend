using Biller.Application.Models.Tenant.Clients;
using Biller.Application.UseCase.Tenant.ClientTaxInfos.Commands.CreateClientTaxInfoCommand;
using Biller.Application.UseCase.Tenant.ClientTaxInfos.Commands.DeleteClientTaxInfoCommand;
using Biller.Application.UseCase.Tenant.ClientTaxInfos.Commands.UpdateClientTaxInfoCommand;
using Biller.Application.UseCase.Tenant.ClientTaxInfos.Queries.GetAllClientTaxInfosQuery;
using Biller.Application.UseCase.Tenant.ClientTaxInfos.Queries.GetClientTaxInfoByIdQuery;
using Biller.Presentation.Api.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Biller.Presentation.Api.Controllers.Tenant.v1;

[ApiController]
[Authorize]
[Route("api/Tenant/v1/[controller]")]
public class ClientTaxInfosController : MainController
{
    private readonly IMediator mediator;

    public ClientTaxInfosController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost("Create")]
    [ProducesResponseType<Response<ClientTaxInfoDTO>>(StatusCodes.Status200OK)]
    [ProducesResponseType<Response<ClientTaxInfoDTO>>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateClientTaxInfoCommand request)
    {
        var response = new Response<ClientTaxInfoDTO>();
        var result = await mediator.Send(request);
        response.SetSuccessResponse(result);
        return GetActionResult(response);
    }

    [HttpGet("GetAllByClient/{clientId:int}")]
    [ProducesResponseType<Response<IEnumerable<ClientTaxInfoDTO>>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllByClient(int clientId)
    {
        var response = new Response<IEnumerable<ClientTaxInfoDTO>>();
        var result = await mediator.Send(new GetAllClientTaxInfosQuery { ClientId = clientId });
        response.SetSuccessResponse(result);
        return GetActionResult(response);
    }

    [HttpGet("GetById/{id:int}")]
    [ProducesResponseType<Response<ClientTaxInfoDTO>>(StatusCodes.Status200OK)]
    [ProducesResponseType<Response<ClientTaxInfoDTO>>(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var response = new Response<ClientTaxInfoDTO>();
        var result = await mediator.Send(new GetClientTaxInfoByIdQuery { Id = id });

        if (result is null)
        {
            response.SetErrorResponse(HttpStatusCode.NotFound, $"ClientTaxInfo with id {id} was not found.");
            return GetActionResult(response);
        }

        response.SetSuccessResponse(result);
        return GetActionResult(response);
    }

    [HttpPut("Update/{id:int}")]
    [ProducesResponseType<Response<ClientTaxInfoDTO>>(StatusCodes.Status200OK)]
    [ProducesResponseType<Response<ClientTaxInfoDTO>>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<Response<ClientTaxInfoDTO>>(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateClientTaxInfoCommand request)
    {
        var response = new Response<ClientTaxInfoDTO>();
        request.Id = id;
        var result = await mediator.Send(request);
        response.SetSuccessResponse(result);
        return GetActionResult(response);
    }

    [HttpDelete("Delete/{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType<Response<ClientTaxInfoDTO>>(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteClientTaxInfoCommand { Id = id });
        return NoContent();
    }
}
