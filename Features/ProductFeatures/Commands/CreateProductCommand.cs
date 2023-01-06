using CQRSMediatr.Context;
using CQRSMediatr.Models;
using MediatR;

namespace CQRSMediatr.Features.ProductFeatures.Commands;

public class CreateProductCommand : IRequest<int>
{
    public string Name { get; set; } = string.Empty;
    public string Barcode { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal BuyingPrice { get; set; }
    public decimal Rate { get; set; }
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IDbApplicationContext _context;
        public CreateProductCommandHandler(IDbApplicationContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Barcode = command.Barcode,
                Name = command.Name,
                BuyingPrice = command.BuyingPrice,
                Rate = command.Rate,
                Description = command.Description
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }
    }
}