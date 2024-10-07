using Newtonsoft.Json;

namespace CBTPreparation.Application.Abstractions.ApplicationService.ExternalDto
{
    public class SubjectResponse
    {
        public string Message { get; set; }
        public int Status { get; set; }
        [JsonProperty("subject")]
        public string Subject { get; set; }
        public List<QuestionData> Data { get; set; }
    }

    public class QuestionData
    {
        public int Id { get; set; }
        [JsonProperty("question")]
        public string Question { get; set; }
        public Option Option { get; set; }
        [JsonProperty("section")]
        public string Section { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
        [JsonProperty("answer")]
        public string Answer { get; set; }
        public string Solution { get; set; }
        [JsonProperty("examtype")]
        public string ExamType { get; set; }
        [JsonProperty("examyear")]
        public string ExamYear { get; set; }
    }

    public class Option
    {
        [JsonProperty("a")]
        public string A { get; set; }
        [JsonProperty("b")]
        public string B { get; set; }
        [JsonProperty("c")]
        public string C { get; set; }
        [JsonProperty("d")]
        public string D { get; set; }
    }

}
