using Biller.Application.UseCase.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Biller.Presentation.Api.Controllers.v1;

[ApiController]
[Route("api/v1/[controller]")]
public class FacturacionController : ControllerBase
{
    private readonly ICrearComprobanteUseCase _crearComprobanteUseCase;

    public FacturacionController(ICrearComprobanteUseCase crearComprobanteUseCase)
    {
        _crearComprobanteUseCase = crearComprobanteUseCase;
    }

    [HttpGet]
    [ProducesResponseType<string>(StatusCodes.Status200OK, "application/xml")]
    public IActionResult Create()
    {
        var xml = _crearComprobanteUseCase.Create();
        return Content(xml, "application/xml");
    }
}
