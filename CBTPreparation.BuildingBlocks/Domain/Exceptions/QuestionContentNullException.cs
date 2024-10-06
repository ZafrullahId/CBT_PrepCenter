namespace CBTPreparation.BuildingBlocks.Domain.Exceptions
{
    public class QuestionContentNullException : DomainException
    {
        private const string _message = "Question Cannot Be Null";
        public QuestionContentNullException() : base(_message)
        {

        }
    }
}
