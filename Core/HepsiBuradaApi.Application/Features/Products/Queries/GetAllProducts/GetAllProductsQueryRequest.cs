using System;
using MediatR;

namespace HepsiBuradaApi.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryRequest : IRequest<GetAllProductsQueryResponse>
    {
        public int PageSize { get; set; } = 200;
        public int PageIndex { get; set; } = 0;
    }
}
