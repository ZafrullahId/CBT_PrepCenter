using CBTPreparation.BuildingBlocks.Domain;
using CBTPreparation.Domain.Entity;

namespace Domain.Entity
{
    public class FreeOption : Option
    {
        internal FreeOption(string optionContent,
                            char optionAlpha,
                            bool isCorrect,
                            string? imageUrl = null) : base(optionContent, optionAlpha, isCorrect, imageUrl)
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
