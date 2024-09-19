using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class SessionQuestion : AuditableEntity
    {
        private readonly List<PaidOption> _options = new();
        private SessionQuestion(Guid cbtSessionId, char chosenOption, string question, bool isChosenOptionCorrect)
        {
            CbtSessionId = cbtSessionId;
            ChosenOption = chosenOption;
            Question = question;
            IsChosenOptionCorrect = isChosenOptionCorrect;
        }
        public Guid CbtSessionId { get; private set; }
        public char ChosenOption { get; private set; }
        public bool IsChosenOptionCorrect { get; private set; }
        public CbtSession? CbtSession { get; private set; }
        public string Question { get; private set; } = default!;
        public IReadOnlyCollection<PaidOption> PaidOptions => _options;
        public static SessionQuestion Create(Guid cbtSessionId, char chosenOption, string question, bool isChosenOptionCorrect)
        {
            // check if 
            return new SessionQuestion(cbtSessionId,
                                       chosenOption,
                                       question,
                                       isChosenOptionCorrect);
        }
        public PaidOption AddOption(string optionContent, char optionAlpha, bool isCorrect, Guid sessionQuestionId, string? imageUrl = null)
        {
            var option = new PaidOption(sessionQuestionId,
                                        optionAlpha,
                                        optionContent,
                                        isCorrect,
                                        imageUrl);
            _options.Add(option);
            return option;
        }
    }
}
