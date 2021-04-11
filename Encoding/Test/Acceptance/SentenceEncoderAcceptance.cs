using Exam.Encoding.Domain.Abstractions;
using Exam.Encoding.Infrastructure;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xbehave;
using Xunit;

namespace Exam.Encoding.Test.Acceptance
{
    public class SentenceEncoderAcceptance
    {
        private readonly ISentenceEncoder SentenceEncoder;

        public SentenceEncoderAcceptance()
        {
            var provider = new ServiceCollection().UseInfrastructure().BuildServiceProvider();

            SentenceEncoder = provider.GetService<ISentenceEncoder>()!;
        }

        [Scenario]
        [InlineData("Hello. This is a test.", "H2o. T2s is a t2t.")]
        [InlineData(" And, another one. ", " A1d, a5r o1e. ")]
        public void Encode(string sentence, string encoding)
        {
            string? result = null;

            "given a sentence".x(() =>
            {
                sentence.Should().NotBeNullOrEmpty();
            });

            "when encoding occurs".x(async () =>
            {
                result = await SentenceEncoder.Encode(sentence);
            });

            "then the result has a valid encoding".x(() =>
            {
                result.Should().Be(encoding);
            });
        }
    }
}
