using Bogus;
using HepsiBuradaApi.Application.Bases;
using HepsiBuradaApi.Application.Interfaces;
using HepsiBuradaApi.Application.Interfaces.AutoMapper;
using HepsiBuradaApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HepsiBuradaApi.Application.Features.Brands.Command.CreateBrands;

public class CreateBrandsCommandHandler : BaseHandler, IRequestHandler<CreateBrandsCommandRequest, Unit>
{
    public CreateBrandsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        : base(unitOfWork, mapper, httpContextAccessor) { }

    public async Task<Unit> Handle(CreateBrandsCommandRequest request, CancellationToken cancellationToken)
    {
        Faker faker = new("tr");
        List<Brand> brands = new();

        for (int i = 0; i < 1000000; i++)
        {
            brands.Add(new(faker.Commerce.Department(1)));
        }

        await unitOfWork.GetWriteRepository<Brand>().AddRangeAsync(brands);
        await unitOfWork.SaveAsync();

        return Unit.Value;
    }
}
