using CBTPreparation.BuildingBlocks.Domain;
using CBTPreparation.BuildingBlocks.Domain.Exceptions;

namespace CBTPreparation.Domain.FreeQuestionAggregate;

public class FreeQuestion : AggregateRoot<FreeQuestionId>
{
    private readonly List<FreeOption> _freeOptions = null!;
    public string SubjectName { get; private set; }
    public string QuestionContent { get; private set; }
    public string ExamType { get; private set; }
    public string ExamYear { get; private set; }
    public string? ImageUrl { get; private set; }
    public IReadOnlyCollection<FreeOption> FreeOptions => [.._freeOptions];
    private FreeQuestion(FreeQuestionId freeQuestionId) : base(freeQuestionId)
    {
        _freeOptions = [];
    }
    private FreeQuestion() : this(null!) { }
    //private FreeQuestion(FreeQuestionId freeQuestionId,
    //                     string questionContent,
    //                     string subjectName,
    //                     string examType,
    //                     string examYear,
    //                     string? imageUrl = null) : base(freeQuestionId)
    //{
    //    QuestionContent = questionContent;
    //    ImageUrl = imageUrl;
    //    SubjectName = subjectName;
    //    ExamType = examType;
    //    ExamYear = examYear;
    //}
    public static FreeQuestion Create(string questionContent,
                                      string subjectName,
                                      string examType,
                                      string examYear,
                                      string? imageUrl = null)
    {
        if (string.IsNullOrWhiteSpace(questionContent))
        {
            throw new QuestionContentNullException();
        }
        // validate subject name
        var question = new FreeQuestion(FreeQuestionId.CreateUniqueId())
        {
            QuestionContent = questionContent,
            SubjectName = subjectName,
            ExamType = examType,
            ExamYear = examYear,
            ImageUrl = imageUrl
        };
        return question;
    }
    public FreeOption AddOption(FreeQuestionId freeQuestionId,
                                string optionContent,
                                char optionAlpha,
                                bool isCorrect,
                                string? imageUrl = null)
    {
        // validation here optionContent is not null
        var option = FreeOption.Create(freeQuestionId,
                                    optionContent,
                                    optionAlpha,
                                    isCorrect,
                                    imageUrl);
        _freeOptions.Add(option);
        return option;
    }
}
