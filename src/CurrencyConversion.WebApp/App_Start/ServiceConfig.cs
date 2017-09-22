using System.Web.Http;
using CurrencyConversion.WebApp.DataAccess;
using LightInject;

namespace CurrencyConversion.WebApp
{
    public static class ServiceConfig
    {
        public static void RegisterServices()
        {
            var container = new ServiceContainer();

            var assembly = typeof(ServiceConfig).Assembly;
            var daoType = typeof(IDao);

            container.RegisterAssembly(
                assembly,
                () => new PerRequestLifeTime(),
                (serviceType, implementingType) => daoType.IsAssignableFrom(serviceType));

            container.RegisterApiControllers();
            container.EnablePerWebRequestScope();
            container.EnableWebApi(GlobalConfiguration.Configuration);
        }
    }
}
