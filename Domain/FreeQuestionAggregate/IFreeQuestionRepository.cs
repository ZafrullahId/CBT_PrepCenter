namespace CBTPreparation.Domain.FreeQuestionAggregate
{
    public interface IFreeQuestionRepository
    {
        Task CreateAsync(List<FreeQuestion> result, CancellationToken cancellationToken);
        Task DeleteOldQuestionsAsync(string subject, int numberToDelete);
        Task<FreeQuestion> GetSubjectName(string subjectName);
    }
}
