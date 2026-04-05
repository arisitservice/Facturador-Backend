using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Models.Tenant.Products;
using Biller.Shared.ExtensionMethods;
using MediatR;

namespace Biller.Application.UseCase.Tenant.Products.Queries.GetAllProductsQuery;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDTO>>
{
    private readonly ITenantUnitOfWork _unitOfWork;

    public GetAllProductsHandler(ITenantUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ProductDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _unitOfWork.Products.GetAllAsync();
        return products.Select(x => x.CastTo<ProductDTO>()).ToList();
    }
}
