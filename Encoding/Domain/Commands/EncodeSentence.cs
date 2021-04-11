namespace Exam.Encoding.Domain.Commands
{
    public record EncodeSentence
    {
        public string Sentence { get; init; } = string.Empty;
    }
}