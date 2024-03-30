using CQRS1.Commands;
using CQRS1.Model;
using CQRS1.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;


//https://code-maze.com/cqrs-mediatr-in-aspnet-core/
namespace CQRS1.Controllers
{

    [Route("api/product")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator) => _mediator = mediator;


        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _mediator.Send(new GetProductsQuery());

            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Product product)
        {
            {
                await _mediator.Send(new AddProductCommand(product));

                return StatusCode(201);
            }

        }
    }

}
