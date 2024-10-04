﻿using CBTPreparation.BuildingBlocks.Domain;
using CBTPreparation.Domain.Common;

namespace CBTPreparation.Domain.FreeQuestionAggregate
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

        public static FreeOption Create(string optionContent,
                                char optionAlpha,
                                bool isCorrect,
                                string? imageUrl = null)
        {
            var option = new FreeOption(optionContent,
                                    optionAlpha,
                                    isCorrect,
                                    imageUrl);

            return option;
        }
    }
}
