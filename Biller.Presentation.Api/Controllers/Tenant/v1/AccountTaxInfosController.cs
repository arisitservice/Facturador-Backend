using Biller.Application.Models.Tenant.AccountTaxInfos;
using Biller.Application.UseCase.Tenant.AccountTaxInfos.Commands.CreateAccountTaxInfoCommand;
using Biller.Application.UseCase.Tenant.AccountTaxInfos.Commands.DeleteAccountTaxInfoCommand;
using Biller.Application.UseCase.Tenant.AccountTaxInfos.Commands.UpdateAccountTaxInfoCommand;
using Biller.Application.UseCase.Tenant.AccountTaxInfos.Queries.GetAccountTaxInfoByIdQuery;
using Biller.Application.UseCase.Tenant.AccountTaxInfos.Queries.GetAllAccountTaxInfosQuery;
using Biller.Presentation.Api.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Biller.Presentation.Api.Controllers.Tenant.v1;

[ApiController]
[Authorize]
[Route("api/Tenant/v1/[controller]")]
public class AccountTaxInfosController : MainController
{
    private readonly IMediator mediator;

    public AccountTaxInfosController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost("Create")]
    [ProducesResponseType<Response<AccountTaxInfoDTO>>(StatusCodes.Status200OK)]
    [ProducesResponseType<Response<AccountTaxInfoDTO>>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateAccountTaxInfoCommand request)
    {
        var response = new Response<AccountTaxInfoDTO>();
        var result = await mediator.Send(request);
        response.SetSuccessResponse(result);
        return GetActionResult(response);
    }

    [HttpGet("GetAll")]
    [ProducesResponseType<Response<IEnumerable<AccountTaxInfoDTO>>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var response = new Response<IEnumerable<AccountTaxInfoDTO>>();
        var result = await mediator.Send(new GetAllAccountTaxInfosQuery());
        response.SetSuccessResponse(result);
        return GetActionResult(response);
    }

    [HttpGet("GetById/{id:int}")]
    [ProducesResponseType<Response<AccountTaxInfoDTO>>(StatusCodes.Status200OK)]
    [ProducesResponseType<Response<AccountTaxInfoDTO>>(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var response = new Response<AccountTaxInfoDTO>();
        var result = await mediator.Send(new GetAccountTaxInfoByIdQuery { Id = id });

        if (result is null)
        {
            response.SetErrorResponse(HttpStatusCode.NotFound, $"AccountTaxInfo with id {id} was not found.");
            return GetActionResult(response);
        }

        response.SetSuccessResponse(result);
        return GetActionResult(response);
    }

    [HttpPut("Update/{id:int}")]
    [ProducesResponseType<Response<AccountTaxInfoDTO>>(StatusCodes.Status200OK)]
    [ProducesResponseType<Response<AccountTaxInfoDTO>>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<Response<AccountTaxInfoDTO>>(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateAccountTaxInfoCommand request)
    {
        var response = new Response<AccountTaxInfoDTO>();
        request.Id = id;
        var result = await mediator.Send(request);
        response.SetSuccessResponse(result);
        return GetActionResult(response);
    }

    [HttpDelete("Delete/{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType<Response<AccountTaxInfoDTO>>(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteAccountTaxInfoCommand { Id = id });
        return NoContent();
    }
}
