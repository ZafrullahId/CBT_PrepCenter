using Domain.Common;
using Domain.Exceptions;

namespace Domain.Entity
{
    public class FreeQuestion : AuditableEntity
    {
        private readonly List<FreeOption> _freeOptions = new();
        public string SubjectName { get; private set; }
        public string QuestionContent { get; private set; }
        public string ExamType { get; private set; }
        public string ExamYear { get; private set; }
        public string? ImageUrl { get; private set; }
        public IReadOnlyCollection<FreeOption> FreeOptions => _freeOptions;
        private FreeQuestion(string questionContent,
                             string subjectName,
                             string examType,
                             string examYear,
                             string? imageUrl = null)
        {
            QuestionContent = questionContent;
            ImageUrl = imageUrl;
            SubjectName = subjectName;
            ExamType = examType;
            ExamYear = examYear;
        }
        public static FreeQuestion Create(string questionContent,
                                          string subjectName,
                                          string examType,
                                          string examYear,
                                          string? imageUrl = null)
        {
            if (string.IsNullOrWhiteSpace(questionContent))
            {
                throw new QuestionContentNullException("Question Cannot Be Null");
            }
            // validate subject name
            var question = new FreeQuestion(questionContent, subjectName, examType, examYear, imageUrl);
            return question;
        }
        public FreeOption AddOption(string optionContent,
                                    char optionAlpha,
                                    bool isCorrect,
                                    string? imageUrl = null)
        {
            // validation here
            var option = new FreeOption(this.Id,
                                        optionContent,
                                        optionAlpha,
                                        isCorrect,
                                        imageUrl);
            _freeOptions.Add(option);
            return option;
        }
    }
}
