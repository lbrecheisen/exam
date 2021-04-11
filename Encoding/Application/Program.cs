using System.Threading.Tasks;
using Exam.Encoding.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Exam.Encoding.Application
{
    internal class Program
    {
        public static Task Main(string[] args) => Host
            .CreateDefaultBuilder(args)
            .ConfigureHostConfiguration(config =>
            {
                config.AddCommandLine(args);
                config.AddJsonFile("appsettings.json", optional: true);
            })
            .ConfigureServices((context, services) =>
            {
                services
                    .UseMassTransit()
                    .UseInfrastructure();

                services
                    .AddHostedService<Service>();
            })
            .RunConsoleAsync();
    }
}
