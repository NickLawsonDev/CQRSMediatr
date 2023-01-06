using CQRSMediatr.Context;
using CQRSMediatr.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediatr.Features.ProductFeatures.Queries;

public record GetAllProductsQuery : IRequest<IEnumerable<Product>>;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
{
    private readonly IDbApplicationContext _context;
    public GetAllProductsQueryHandler(IDbApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
    {
        var productList = await _context.Products.ToListAsync(cancellationToken);
        if (productList == null)
        {
            return new List<Product>();
        }
        return productList.AsReadOnly();
    }
}