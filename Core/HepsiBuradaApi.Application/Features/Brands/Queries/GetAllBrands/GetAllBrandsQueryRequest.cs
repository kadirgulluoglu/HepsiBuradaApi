using HepsiBuradaApi.Application.Interfaces.RedisCache;
using MediatR;

namespace HepsiBuradaApi.Application.Features.Brands.Queries.GetAllBrands;

public class GetAllBrandsQueryRequest : IRequest<GetAllBrandsQueryResponse>, ICacheableQuery
{
    public string CacheKey => "GetAllBrandi";
    public double CacheTime => 5;
}
