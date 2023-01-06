using CQRSMediatr.Context;
using MediatR;

namespace CQRSMediatr.Features.ProductFeatures.Commands;

public class UpdateProductCommand : IRequest<int> {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Barcode { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal BuyingPrice { get; set; }
    public decimal Rate { get; set; }
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IDbApplicationContext _context;
        public UpdateProductCommandHandler(IDbApplicationContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = _context.Products.Where(a => a.Id == command.Id).FirstOrDefault();
            if (product == null)
            {
                return default;
            }
            else
            {
                product.Barcode = command.Barcode;
                product.Name = command.Name;
                product.BuyingPrice = command.BuyingPrice;
                product.Rate = command.Rate;
                product.Description = command.Description;
                await _context.SaveChangesAsync();
                return product.Id;
            }
        }
    }
}