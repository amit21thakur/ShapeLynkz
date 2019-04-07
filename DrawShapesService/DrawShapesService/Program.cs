using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace DrawShapesService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services => services.AddAutofac())
                .ConfigureLogging(ConfigureLogging)
                .UseStartup<Startup>()
                .UseSerilog()
                .Build();

        private static void ConfigureLogging(WebHostBuilderContext context, ILoggingBuilder builder)
        {

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(context.Configuration.GetSection(Constants.SeriLogFilePath).Value)
                .CreateLogger();
        }


    }

}
