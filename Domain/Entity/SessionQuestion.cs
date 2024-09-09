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
        private readonly List<Option> _options = new();
        public SessionQuestion(Guid cbtSessionId, char chosenOption, char? correctOption, string question)
        {
            CbtSessionId = cbtSessionId;
            ChosenOption = chosenOption;
            CorrectOption = correctOption;
            Question = question;
        }
        public Guid CbtSessionId { get; private set; }
        public char ChosenOption { get; private set; }
        public char? CorrectOption { get; private set; }
        public CbtSession CbtSession { get; private set; }
        public string Question { get; private set; } = default!;
        public IReadOnlyCollection<Option> Options => _options;
        public static SessionQuestion Create(Guid cbtSessionId, char chosenOption, char? correctOption, string question)
        {
            // check if 
            return new SessionQuestion(cbtSessionId, chosenOption, correctOption, question);
        }
        public Option AddOption(char alphaOpt, string opts, Guid sessionQuestionId)
        {
            var option = new Option(alphaOpt, opts, sessionQuestionId);
            _options.Add(option);
            return option;
        }
    }
}
