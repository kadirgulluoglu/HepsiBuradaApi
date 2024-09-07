using System;
using HepsiBuradaApi.Application.Bases;
using HepsiBuradaApi.Application.Interfaces;
using HepsiBuradaApi.Application.Interfaces.AutoMapper;
using HepsiBuradaApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HepsiBuradaApi.Application.Features.Products.Command.DeleteProduct
{
    public class DeleteProductCommandHandler : BaseHandler, IRequestHandler<DeleteProductCommandRequest, Unit>
    {
        public DeleteProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper,
            IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product? product = await unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id);
            product.IsDeleted = true;
            await unitOfWork.GetWriteRepository<Product>().UpdateAsync(product);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
