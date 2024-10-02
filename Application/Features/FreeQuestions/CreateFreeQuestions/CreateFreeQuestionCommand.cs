using MediatR;
using Newtonsoft.Json;

namespace CBTPreparation.Application.Features.FreeQuestions.CreateFreeQuestions
{
    public class CreateFreeQuestionDataCommandRequest
    {
        [JsonProperty("question")]
        public string Question { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
        [JsonProperty("answer")]
        public string Answer { get; set; }
        [JsonProperty("examtype")]
        public string ExamType { get; set; }
        [JsonProperty("examyear")]
        public string ExamYear { get; set; }
        public CreateFreeQuestionDataOptionCommandRequest Option { get; set; }
    }
    public class CreateFreeQuestionDataOptionCommandRequest
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
    public record CreateFreeQuestionCommand([JsonProperty("subject")] string Subject,
                                            [JsonProperty("data")] List<CreateFreeQuestionDataCommandRequest> Data) : IRequest<CreateFreeQuestionCommandResponse>;
}
