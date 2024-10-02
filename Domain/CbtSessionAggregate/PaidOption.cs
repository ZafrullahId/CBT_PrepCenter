using CBTPreparation.Domain.Common;

namespace CBTPreparation.Domain.CbtSessionAggregate
{
    public class PaidOption : Option
    {
        internal PaidOption(char optionAlpha,
                            string optionContent,
                            bool isCorrect,
                            string? imageUrl) : base(optionContent, optionAlpha, isCorrect, imageUrl)
        {
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return OptionContent;
            yield return OptionAlpha;
            yield return IsCorrect;
        }
    }
}
