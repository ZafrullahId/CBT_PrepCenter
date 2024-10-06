using CBTPreparation.Domain.Common;

namespace CBTPreparation.Domain.CbtSessionAggregate
{
    public class PaidOption : Option
    {
        public SessionQuestionId SessionQuestionId { get; init; }
        internal PaidOption(char optionAlpha,
                            string optionContent,
                            bool isCorrect,
                            string? imageUrl,
                            SessionQuestionId sessionQuestionId) : base(optionContent, optionAlpha, isCorrect, imageUrl)
        {
            SessionQuestionId = sessionQuestionId;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return OptionContent;
            yield return OptionAlpha;
            yield return IsCorrect;
        }
    }
}
