
using CBTPreparation.BuildingBlocks.Domain;

namespace CBTPreparation.Domain.Entity
{
    public abstract class Option : ValueObject<Option>
    {

        public Option(string optionContent, char optionAlpha, bool isCorrect, string? imageUrl)
        {
            OptionContent = optionContent;
            OptionAlpha = optionAlpha;
            IsCorrect = isCorrect;
            ImageUrl = imageUrl;
        }

        public string OptionContent { get; init; }
        public char OptionAlpha { get; init; }
        public bool IsCorrect { get; init; }
        public string? ImageUrl { get; init; }


    }
}
