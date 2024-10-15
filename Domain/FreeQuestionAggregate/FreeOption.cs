using CBTPreparation.Domain.Common;

namespace CBTPreparation.Domain.FreeQuestionAggregate
{
    public class FreeOption : Option
    {
        public FreeQuestionId FreeQuestionId { get; set; }
        internal FreeOption(
                            FreeQuestionId freeQuestionId, 
                            string optionContent,
                            char optionAlpha,
                            bool isCorrect,
                            string? imageUrl = null) : base(optionContent, optionAlpha, isCorrect, imageUrl)
        {
            FreeQuestionId = freeQuestionId;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return OptionContent;
            yield return OptionAlpha;
            yield return IsCorrect;
        }

        public static FreeOption Create(
                                FreeQuestionId freeQuestionId, 
                                string optionContent,
                                char optionAlpha,
                                bool isCorrect,
                                string? imageUrl = null)
        {   
            var option = new FreeOption(freeQuestionId, optionContent,
                                    optionAlpha,
                                    isCorrect,
                                    imageUrl);

            return option;
        }
    }
}
