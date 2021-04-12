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
        [InlineData("a", "a0a")]
        [InlineData("aa", "a0a")]
        [InlineData("ab", "a0b")]
        [InlineData("aaa", "a1a")]
        [InlineData(" AbBa ", " A2a ")]
        [InlineData("This is a test.", "T2s i0s a0a t2t.")]
        [InlineData("The:quick,brown;fox-jumps/over|the*lazy@dog...", "T1e:q3k,b3n;f1x-j3s/o2r|t1e*l2y@d1g...")]
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
