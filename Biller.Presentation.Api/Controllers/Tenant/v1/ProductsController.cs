using Biller.Application.Models.Tenant.Products;
using Biller.Application.UseCase.Tenant.Products.Queries.GetAllProductsQuery;
using Biller.Presentation.Api.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biller.Presentation.Api.Controllers.Tenant.v1;

[ApiController]
[Authorize]
[Route("api/Tenant/v1/[controller]")]
public class ProductsController : MainController
{
    private readonly ISender _sender;

    public ProductsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var response = new Response<IEnumerable<ProductDTO>>();
        var result = await _sender.Send(new GetAllProductsQuery());
        response.SetSuccessResponse(result);
        return GetActionResult(response);
    }
}
