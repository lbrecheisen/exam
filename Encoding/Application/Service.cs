using System;
using System.Threading;
using System.Threading.Tasks;
using Exam.Encoding.Domain.Commands;
using Exam.Encoding.Domain.Events;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Exam.Encoding.Application
{
    [PrimaryConstructor]
    internal partial class Service : IHostedService
    {
        private readonly IConfiguration Configuration;
        private readonly IHostApplicationLifetime Lifetime;
        private readonly IRequestClient<EncodeSentence> Requester;

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var sentence = Configuration["sentence"];

            if (string.IsNullOrEmpty(sentence))
            {
                Console.Write("Sentence: ");
                sentence = Console.ReadLine() ?? string.Empty;
            }

            var encodeSentence = new EncodeSentence
            {
                Sentence = sentence
            };
            var sentenceEncoded = await Requester.GetResponse<SentenceEncoded>(encodeSentence);

            Console.WriteLine($"Encoding: {sentenceEncoded.Message.Sentence}");

            Lifetime.StopApplication();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
