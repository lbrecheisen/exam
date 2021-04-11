namespace Exam.Encoding.Domain.Events
{
    public record SentenceEncoded
    {
        public string Sentence { get; init; } = string.Empty;
    }
}