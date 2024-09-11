using MediatR;

namespace HepsiBuradaApi.Application.Features.Brands.Command.CreateBrands;

public class CreateBrandsCommandRequest : IRequest<Unit>
{
    public string Name { get; set; }
}
