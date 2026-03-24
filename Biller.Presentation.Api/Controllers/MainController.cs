using Biller.Presentation.Api.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace Biller.Presentation.Api;

[Route("api/[controller]")]
[ApiController]
public class MainController : ControllerBase
{
    public IActionResult GetActionResult<T>(Response<T> response) => new ObjectResult(response) { StatusCode = response.StatusCode };
}
