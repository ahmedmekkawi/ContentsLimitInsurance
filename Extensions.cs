using ContentsLimitInsurance.Interfaces;
using ContentsLimitInsurance.Services;

namespace ContentsLimitInsurance
{
    public static class Extensions
    {
        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            var assemblyInfrastructureSvc = typeof(Svc).Assembly;
            var registrationsInfrastructureSvc =
                from type in assemblyInfrastructureSvc.GetExportedTypes()
                where type.GetInterfaces().Any(x => x.IsAssignableFrom(typeof(ISvc)))
                where !type.IsAbstract
                select new { Service = type.GetInterfaces().Single(x => x.Name.Contains(type.Name)), Implementation = type };

            foreach (var reg in registrationsInfrastructureSvc)
            {
                services.AddScoped(reg.Service, reg.Implementation);
            }
        }
    }
}
