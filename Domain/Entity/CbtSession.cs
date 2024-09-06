using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class CbtSession : AuditableEntity
    {
        public double Score { get; private set; }
        public Guid StudentId { get; private set; }
        public TimeSpan Duration { get; private set; }
        public int NumberOfQuestion { get; private set; }
        public int NumberOfWrongAnswers { get; private set; }
        public int NumberOfCorrectAnswers { get; private set; }
        public SessionResult SessionResult { get; private set; }
        public CbtSession(double score, TimeSpan duration, int numberOfQuestion, int numberOfWrongAnswers, int numberOfCorrectAnswers)
        {
            Score = score;
            Duration = duration;
            NumberOfQuestion = numberOfQuestion;
            NumberOfWrongAnswers = numberOfWrongAnswers;
            NumberOfCorrectAnswers = numberOfCorrectAnswers;
        }
        public static CbtSession Create(double score, TimeSpan duration, int numberOfQuestion, int numberOfWrongAnswers, int numberOfCorrectAnswers)
        {
            var session = new CbtSession(score, duration, numberOfQuestion, numberOfWrongAnswers, numberOfCorrectAnswers);
            return session;
        }
        
    }
}
