using HepsiBuradaApi.Application.Features.Brands.Command.CreateBrands;
using HepsiBuradaApi.Application.Features.Brands.Queries.GetAllBrands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HepsiBuradaApi.Api.Controllers;

[Route("api/")]
[ApiController]
public class BrandsController : ControllerBase
{
    private readonly IMediator _mediator;

    public BrandsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Brand")]
    public async Task<IActionResult> PostBrand([FromBody] CreateBrandsCommandRequest request)
    {
        await _mediator.Send(request);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpGet("Brand")]
    public async Task<IActionResult> GetBrand()
    {
        await _mediator.Send(new GetAllBrandsQueryRequest());
        return StatusCode(StatusCodes.Status201Created);
    }
}
