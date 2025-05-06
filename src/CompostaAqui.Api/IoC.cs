using CompostaAqui.Application;
using CompostaAqui.Infrastructure;

namespace CompostaAqui.Api
{
    internal static class IoC
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddApplication(configuration);
            services.AddInfrastructure(configuration);
        }
    }
}
