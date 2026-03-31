
using Biller.Application.UseCase.Tenant.Bills.Commands.CreateBillCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Biller.Presentation.Api.Controllers.v1;

[ApiController]
[Route("/api/v1/[controller]")]
public class BillController : ControllerBase
{
    private readonly IMediator mediator;

    public BillController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType<string>(StatusCodes.Status200OK, "application/xml")]
    public async Task<IActionResult> Create()
    {
        var xml = await mediator.Send(new CreateBillCommand());
        return Content(xml, "application/xml");
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
