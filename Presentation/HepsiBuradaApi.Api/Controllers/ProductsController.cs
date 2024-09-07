using HepsiBuradaApi.Application.Features.Products.Command.CreateProduct;
using HepsiBuradaApi.Application.Features.Products.Command.DeleteProduct;
using HepsiBuradaApi.Application.Features.Products.Command.UpdateProduct;
using HepsiBuradaApi.Application.Features.Products.Queries.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace HepsiBuradaApi.Api.Controllers
{
    [Route("api/Product")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetProductsAll()
        {
            var response = await mediator.Send(new GetAllProductsQueryRequest());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
