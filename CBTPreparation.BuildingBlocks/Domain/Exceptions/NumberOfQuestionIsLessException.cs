namespace CBTPreparation.BuildingBlocks.Domain.Exceptions
{
    public class NumberOfQuestionIsLessException : DomainException
    {
        private const string _message = "NumberOfQuestions `{0}` cannot be less than number numberOfCorrectAnswers `{1}` or numberOfWrongAnswers `{2}`";
        public NumberOfQuestionIsLessException(int numberOfQuestions,
                                               int numberOfCorrectAnswers,
                                               int numberOfWrongAnswers) : base(string.Format(_message, numberOfQuestions, numberOfCorrectAnswers, numberOfWrongAnswers))
        {

        }
    }
}
