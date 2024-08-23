using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HepsiBuradaApi.Application.Features.Products.Command.CreateProduct;
using HepsiBuradaApi.Application.Features.Products.Command.DeleteProduct;
using HepsiBuradaApi.Application.Features.Products.Command.UpdateProduct;
using HepsiBuradaApi.Application.Features.Products.Queries.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace HepsiBuradaApi.Api.Controllers
{
    [Route("api/")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet("Product")]
        public async Task<IActionResult> GetProductsAll()
        {
            var response = await mediator.Send(new GetAllProductsQueryRequest());
            return Ok(response);
        }

        [HttpPost("Product")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPut("Product")] 
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        } 

        [HttpDelete("Product")]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}

