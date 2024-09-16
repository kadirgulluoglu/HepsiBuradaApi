using HepsiBuradaApi.Application.Bases;
using HepsiBuradaApi.Application.DTOs;
using HepsiBuradaApi.Application.Interfaces;
using HepsiBuradaApi.Application.Interfaces.AutoMapper;
using HepsiBuradaApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HepsiBuradaApi.Application.Features.Brands.Queries.GetAllBrands;

public class GetAllBrandsQueryHandler : BaseHandler,
    IRequestHandler<GetAllBrandsQueryRequest, GetAllBrandsQueryResponse>
{
    public GetAllBrandsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) :
        base(unitOfWork, mapper, httpContextAccessor) { }

    public async Task<GetAllBrandsQueryResponse> Handle(GetAllBrandsQueryRequest request,
        CancellationToken cancellationToken)
    {
        var brands = await unitOfWork.GetReadRepository<Brand>().GetAllByPagingAsync();

        var brandMap = mapper.Map<BrandDto, Brand>(brands);


        // Yanıtı döndür
        return new GetAllBrandsQueryResponse()
        {
            Brands = brandMap,
            TotalCount = brandMap.Count
        };
    }
}
