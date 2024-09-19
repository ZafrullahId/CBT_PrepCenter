using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class PaidOption : Option
    {
        public Guid SessionQuestionId { get; private set; }
        public SessionQuestion? SessionQuestion { get; private set; }
        internal PaidOption(Guid sessionQuestionId,
                            char optionAlpha,
                            string optionContent,
                            bool isCorrect,
                            string? imageUrl) : base(optionContent, optionAlpha, isCorrect, imageUrl)
        {
            SessionQuestionId = sessionQuestionId;
            OptionContent = optionContent;
            OptionAlpha = optionAlpha;
            IsCorrect = isCorrect;
            ImageUrl = imageUrl;
        }
    }
}
