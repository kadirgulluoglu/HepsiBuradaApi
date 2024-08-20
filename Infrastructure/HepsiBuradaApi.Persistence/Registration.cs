using HepsiBuradaApi.Application.Interfaces.Repositories;
using HepsiBuradaApi.Persistence.Context;
using HepsiBuradaApi.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace HepsiBuradaApi.Persistence
{
    public static class Registration
    {
        public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
            opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>)); 
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
        }
    }
} 

