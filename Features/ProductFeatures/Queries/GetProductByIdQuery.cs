using CQRSMediatr.Context;
using CQRSMediatr.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediatr.Features.ProductFeatures.Queries;

public record GetProductByIdQuery : IRequest<Product>
{
    public int Id { get; set; }
}

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly IDbApplicationContext _context;
    public GetProductByIdQueryHandler(IDbApplicationContext context)
    {
        _context = context;
    }

    public async Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        return await _context.Products.Where(a => a.Id == query.Id).FirstAsync(cancellationToken);
    }
}