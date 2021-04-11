using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Exam.Encoding.Application
{
    internal static class Registration
    {
        public static IServiceCollection UseMassTransit(this IServiceCollection services)
        {
            services.AddGenericRequestClient();

            return services
                .AddMassTransitHostedService()
                .AddMassTransit(bus =>
                {
                    bus.AddConsumers(typeof(Registration).Assembly);

                    bus.UsingInMemory((ctx, cfg) =>
                    {
                        cfg.ConfigureEndpoints(ctx);
                    });
                });
        }
    }
}
