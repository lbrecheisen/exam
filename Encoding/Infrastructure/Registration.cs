using Exam.Encoding.Domain.Abstractions;
using Exam.Encoding.Infrastructure.Encoders;
using Microsoft.Extensions.DependencyInjection;

namespace Exam.Encoding.Infrastructure
{
    public static class Registration
    {
        public static IServiceCollection UseInfrastructure(this IServiceCollection services)
        {
            return services
                .AddSingleton<ISentenceEncoder, SentenceEncoder>();
        }
    }
}
