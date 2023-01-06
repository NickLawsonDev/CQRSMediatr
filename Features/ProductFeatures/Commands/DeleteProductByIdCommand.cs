using CQRSMediatr.Context;
using CQRSMediatr.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediatr.Features.ProductFeatures.Commands;

public class DeleteProductByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, int>
        {
            private readonly IDbApplicationContext _context;
            public DeleteProductByIdCommandHandler(IDbApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
            {
                var product = _context.Products.First(a => a.Id == command.Id);
                if (product == null) return default;

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return product.Id;
            }
        }
    }