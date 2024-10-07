namespace CBTPreparation.Application.Abstractions.ApplicationService.ExternalDto
{
    public class SubjectApiResponse
    {
        public string Message { get; set; }
        public int Status { get; set; }
        public Dictionary<string, string> Subjects { get; set; } = new Dictionary<string, string>();
    }
}
