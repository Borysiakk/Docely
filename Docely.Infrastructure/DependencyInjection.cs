using Docely.Domain.Contract.Result;
using Docely.Infrastructure.Queries;
using Docely.Infrastructure.Repository;
using Docely.Infrastructure.Service;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Docely.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthenticateService, AuthenticateService>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}