using CompostaAqui.Application.Interfaces;
using CompostaAqui.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompostaAqui.Application
{
    public static class IoC
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationServices();
        }

        private static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IComposterService, ComposterService>();
        }
    }
}
