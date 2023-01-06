using CQRSMediatr.Features.ProductFeatures.Commands;
using CQRSMediatr.Features.ProductFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediatr.Controllers;

[Route("/product/")]
public class ProductController : Controller
{
    private IMediator _mediator => HttpContext.RequestServices.GetRequiredService<IMediator>();

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _mediator.Send(new GetAllProductsQuery()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _mediator.Send(new GetProductByIdQuery { Id = id }));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await _mediator.Send(new DeleteProductByIdCommand { Id = id }));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateProductCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }
        return Ok(await _mediator.Send(command));
    }
}