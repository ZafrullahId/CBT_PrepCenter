using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Option : AuditableEntity
    {
        public char AlphaOpt {  get; private set; }
        public string OptContent { get; private set; } = default!;
        public Guid SessionQuestionId { get; private set; }
        public SessionQuestion? SessionQuestion { get; private set; }
        internal Option(char alphaOpt, string optContent, Guid sessionQuestionId)
        {
            AlphaOpt = alphaOpt;
            OptContent = optContent;
            SessionQuestionId = sessionQuestionId;
        }
    }
}
