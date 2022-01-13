namespace XPS.Test.DI
{
    using Microsoft.Extensions.DependencyInjection;
    using XPS.Test.Domain.Implementation;
    using XPS.Test.Domain.Interfaces;
    using XPS.Test.Services.Implementation;
    using XPS.Test.Services.Interfaces;
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddLoggerService(this IServiceCollection services)
        {
            services.AddScoped<ILogger, ConsoleLogger>();
            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IRomanValueService, RomanValueService>();
            return services;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRomanDataRepository, RomanDataRepository>();
            return services;
        }

    }
}