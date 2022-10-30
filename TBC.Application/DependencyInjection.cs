using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TBC.Application.Infrastructure.Behaviours;

namespace TBC.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            AssemblyScanner.FindValidatorsInAssembly(typeof(DependencyInjection).Assembly).ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));

            services.AddMediatR(Assembly.GetExecutingAssembly()); 
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>)); 

            return services;
        }
    }
}
