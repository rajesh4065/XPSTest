namespace XPS.Test.Console
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.IO;
    using XPS.Test.Common;
    using XPS.Test.DI;
    using XPS.Test.Services.Interfaces;
    public class Startup
    {
        private static IServiceProvider ServiceProvider;

        public Startup(string[] args)
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: false)
                 .AddEnvironmentVariables();

            var configuration = builder.Build();
            var serviceCollection = new ServiceCollection();
            serviceCollection.Configure<RangeConfigValues>(configuration.GetSection(nameof(RangeConfigValues)));
            serviceCollection.AddOptions();
            serviceCollection.AddLogging();
            serviceCollection.AddLoggerService();
            serviceCollection.AddServices();
            serviceCollection.AddRepositories();
            ServiceProvider = serviceCollection.BuildServiceProvider();

            var romanValueService = ServiceProvider.GetService<IRomanValueService>();
            var logger = ServiceProvider.GetService<ILogger>();
            logger.Info("Enter a number from 1 to 2000 to Get it's RomanNumerals");
            int number;
            var num = System.Console.ReadLine();
            if (int.TryParse(num, out number))
            {
                var result = romanValueService.GetRomanNumerals(number);
                if (!string.IsNullOrEmpty(result))
                {
                    logger.Info($"You entered number: {num}");
                    logger.Info($"its RomanNumerals is :{result}");
                }
                else
                {
                    logger.Info($"The number you have entered is not in range  1 to 2000: {num}");
                }
            }
            else
            {
                logger.Info($"Please enter a number from 1 to 2000");
            }

            System.Console.ReadLine();
        }
    }
}

