using System.Linq;
using MoreLinq;
using Exam.Encoding.Domain.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace Exam.Encoding.Infrastructure.Encoders
{
    internal class SentenceEncoder : ISentenceEncoder
    {
        public ValueTask<string> Encode(string sentence, CancellationToken cancellationToken = default)
        {
            var words = sentence
                .GroupAdjacent(char.IsLetter)
                .Select(group => group.ToArray() switch
                {
                    char[] { Length: 1 or 2 } word => string.Concat(word),
                    char[] word => $"{word[0]}{word[1..^1].Distinct().Count()}{word[^1]}",
                    _ => string.Empty
                });


            return new ValueTask<string>(string.Concat(words));
        }
    }
}