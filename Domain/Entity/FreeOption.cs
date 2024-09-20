using Domain.Common;

namespace Domain.Entity
{
    public class FreeOption : Option
    {
        public Guid FreeQuestionId { get; set; }
        public FreeQuestion? FreeQuestion { get; set; }

        internal FreeOption(Guid freeQuestionId,
                            string optionContent,
                            char optionAlpha,
                            bool isCorrect,
                            string? imageUrl = null) : base(optionContent, optionAlpha, isCorrect, imageUrl)
        {
            FreeQuestionId = freeQuestionId;
            OptionContent = optionContent;
            OptionAlpha = optionAlpha;
            IsCorrect = isCorrect;
            ImageUrl = imageUrl;
        }

    }
}
