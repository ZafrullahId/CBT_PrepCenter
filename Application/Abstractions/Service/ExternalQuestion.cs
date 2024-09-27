namespace Application.Abstractions.Service
{
    public class ExternalQuestion
    {
        public string SubjectName { get; set; } = default!;
        public string QuestionContent { get; set; } = default!;
        public string ExamType { get; set; } = default!;
        public string ExamYear { get; set; } = default!;
        public string? ImageUrl { get; set; }
        public List<ExternalOption> Options { get; set; }
    }

    public class ExternalOption
    {
        public string Content { get; set; } = default!;
        public char OptionAlpha { get; set; }
        public bool IsCorrect { get; set; }
        public string? ImageUrl { get; set; }
    }
}