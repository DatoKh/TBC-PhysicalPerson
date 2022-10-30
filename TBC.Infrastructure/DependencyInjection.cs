using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TBC.Application.Infrastructure.Services;
using TBC.Domain.Entities.CityAggregate;
using TBC.Domain.Entities.PersonAggregate;
using TBC.Domain.SeedWork;
using TBC.Infrastructure.Persistence.Context;
using TBC.Infrastructure.Persistence.Repositories;
using TBC.Infrastructure.Persistence.UnitOfWork;
using TBC.Infrastructure.Services.FileService;

namespace TBC.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkSqlServer();
            services.AddEntityFrameworkProxies();
            services.AddDbContextPool<PersonDbContext>((serviceProvider, options) =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(configuration.GetConnectionString("PersonDatabase"));
                options.UseInternalServiceProvider(serviceProvider);
            });

            services.AddScoped<PersonDbContext>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //External Services
            services.AddScoped<IFileService, FileService>();

            return services;
        }
    }
}
