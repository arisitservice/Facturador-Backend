using Biller.Application.Models.Tenant.Cfdis;
using Biller.Application.UseCase.Tenant.Invoices.Commands.CreateIncomeInvoiceCommand;
using Biller.Presentation.Api.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biller.Presentation.Api.Controllers.Tenant.v1;

[ApiController]
[Authorize]
[Route("api/Tenant/v1/[controller]")]
public class InvoiceController : MainController
{
    private readonly IMediator mediator;

    public InvoiceController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost("CreateIncome")]
    [ProducesResponseType<CfdiDTO>(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateIncome([FromBody] CreateIncomeInvoiceCommand command)
    {
        var response = new Response<CfdiDTO>();
        var cfdiDto = await mediator.Send(command);
        response.SetSuccessResponse(cfdiDto);

        return GetActionResult(response);
    }

    [HttpGet("test")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Test()
    {
        return Ok(new
        {
            status = 200,
            data = new { message = "Hola mundo dsesde .NET con scalar yey !!!!" }
        });
    }
}
