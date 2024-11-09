using Application.MapperProfiles;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Servicess
{
    public static class ServiceRegistration
    {
        public static void AddSaveApplicationService(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));
        }
    }

}
