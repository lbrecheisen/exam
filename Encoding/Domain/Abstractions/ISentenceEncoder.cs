using System.Threading;
using System.Threading.Tasks;

namespace Exam.Encoding.Domain.Abstractions
{
    public interface ISentenceEncoder
    {
        public ValueTask<string> Encode(string sentence, CancellationToken cancellationToken = default);
    }
}