using Blogger.BuildingBlocks.Domain;

namespace CBTPreparation.Domain.CbtSessionAggregate
{
    public class SessionQuestion : Entity<SessionQuestionId>
    {
        private readonly List<PaidOption> _options = new();
        private SessionQuestion(SessionQuestionId sessionQuestionId,
                                CbtSessionId cbtSessionId,
                                char chosenOption,
                                string question,
                                bool isChosenOptionCorrect) : base(sessionQuestionId)
        {
            CbtSessionId = cbtSessionId;
            ChosenOption = chosenOption;
            Question = question;
            IsChosenOptionCorrect = isChosenOptionCorrect;
        }
        public CbtSessionId CbtSessionId { get; private set; }
        public char ChosenOption { get; private set; }
        public bool IsChosenOptionCorrect { get; private set; }
        public string Question { get; private set; } = default!;
        public IReadOnlyCollection<PaidOption> PaidOptions => _options;
        public static SessionQuestion Create(char chosenOption,
                                             CbtSessionId cbtSessionId,
                                             string question,
                                             bool isChosenOptionCorrect)
        {
            // check if 
            return new SessionQuestion(SessionQuestionId.CreateUniqueId(),
                                       cbtSessionId,
                                       chosenOption,
                                       question,
                                       isChosenOptionCorrect);
        }
        public PaidOption AddOption(string optionContent,
                                    char optionAlpha,
                                    bool isCorrect,
                                    Guid sessionQuestionId,
                                    string? imageUrl = null)
        {
            var option = new PaidOption(optionAlpha,
                                        optionContent,
                                        isCorrect,
                                        imageUrl);
            _options.Add(option);
            return option;
        }
    }
}
