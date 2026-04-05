using Biller.Application.Models.Tenant.Products;
using MediatR;

namespace Biller.Application.UseCase.Tenant.Products.Queries.GetAllProductsQuery;

public sealed class GetAllProductsQuery : IRequest<IEnumerable<ProductDTO>>
{
}
