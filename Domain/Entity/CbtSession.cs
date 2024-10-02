using CBTPreparation.BuildingBlocks.Domain.Exceptions;
using Blogger.BuildingBlocks.Domain;

namespace Domain.Entity
{
    public class CbtSession : Entity<CbtSessionId>
    {
        public double Score { get; private set; }
        public StudentId StudentId { get; private set; }
        public bool InProgress { get; private set; } = true;
        public TimeSpan Duration { get; private set; }
        public int NumberOfQuestion { get; private set; }
        public int NumberOfQuestionAttempted { get; private set; }
        public int NumberOfWrongAnswers { get; private set; }
        public int NumberOfCorrectAnswers { get; private set; }
        public int CurrentQuestionNumberInProgress { get; private set; } = 0;
        private readonly IList<SessionQuestion> _sessionQuestions = null!;
        public IReadOnlyCollection<SessionQuestion> SessionQuestions => [.. _sessionQuestions];
        private CbtSession(CbtSessionId cbtSessionId,
                           StudentId studentId,
                           double score,
                           TimeSpan duration,
                           int numberOfQuestionAttempted,
                           int numberOfQuestion,
                           int numberOfWrongAnswers,
                           int numberOfCorrectAnswers) : base(cbtSessionId)
        {
            Score = score;
            Duration = duration;
            StudentId = studentId;
            NumberOfQuestion = numberOfQuestion;
            NumberOfWrongAnswers = numberOfWrongAnswers;
            NumberOfCorrectAnswers = numberOfCorrectAnswers;
            NumberOfQuestionAttempted = numberOfQuestionAttempted;
        }
        public static CbtSession Create(double score,
                                        StudentId studentId,
                                        TimeSpan duration,
                                        int numberOfQuestionAttempted,
                                        int numberOfQuestion,
                                        int numberOfWrongAnswers,
                                        int numberOfCorrectAnswers)
        {
            // check if numberOfWrongAnswers or numberOfCorrectAnswers > numberOfQuestion
            if (numberOfCorrectAnswers > numberOfQuestion || numberOfWrongAnswers > numberOfQuestion)
            {
                throw new NumberOfQuestionIsLessException(numberOfQuestion, numberOfCorrectAnswers, numberOfWrongAnswers);
            }
            var session = new CbtSession(CbtSessionId.CreateUniqueId(),
                                         studentId,
                                         score,
                                         duration,
                                         numberOfQuestionAttempted,
                                         numberOfQuestion,
                                         numberOfWrongAnswers,
                                         numberOfCorrectAnswers);
            return session;
        }

    }
}
