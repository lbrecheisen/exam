using System.Threading.Tasks;
using Exam.Encoding.Domain.Abstractions;
using Exam.Encoding.Domain.Commands;
using Exam.Encoding.Domain.Events;
using MassTransit;

namespace Exam.Encoding.Application.Consumers
{
    [PrimaryConstructor]
    public partial class EncodeSentenceConsumer : IConsumer<EncodeSentence>
    {
        public readonly ISentenceEncoder SentenceEncoder;

        public async Task Consume(ConsumeContext<EncodeSentence> context)
        {
            var sentence = await SentenceEncoder.Encode(context.Message.Sentence, context.CancellationToken);

            var sentenceEncoded = new SentenceEncoded
            {
                Sentence = sentence
            };
            await context.RespondAsync(sentenceEncoded);
        }
    }
}
