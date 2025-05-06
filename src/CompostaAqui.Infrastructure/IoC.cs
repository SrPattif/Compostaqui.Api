using CompostaAqui.Domain.UnitOfWorks;
using CompostaAqui.Infrastructure.UnitOfWorks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompostaAqui.Infrastructure
{
    public static class IoC
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddUnitOfWork();
        }

        private static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWorkCompostaqui, UnitOfWorkCompostaqui>();
        }
    }
}
