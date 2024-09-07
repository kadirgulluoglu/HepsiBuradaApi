using System.Security.Claims;
using HepsiBuradaApi.Application.Interfaces;
using HepsiBuradaApi.Application.Interfaces.AutoMapper;
using Microsoft.AspNetCore.Http;

namespace HepsiBuradaApi.Application.Bases;

public class BaseHandler
{
    protected readonly IUnitOfWork unitOfWork;
    protected readonly IMapper mapper;
    public readonly IHttpContextAccessor httpContextAccessor;
    public readonly string userId;

    protected BaseHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.httpContextAccessor = httpContextAccessor;
        userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
