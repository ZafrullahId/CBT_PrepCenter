using CBTPreparation.Application.Features.Feedbacks.CreateFeedback;
using CBTPreparation.Domain.StudentAggregate;
using Mapster;

namespace CBTPreparation.APIs.Endpoints.FeedBack.CreateFeedback
{
    public class CreateFeedbackMappingProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<CreateFeedbackRequest, CreateFeedbackCommand>()
                       .Map(x => x.StudentId, src => StudentId.Create(src.StudentId))
                       .Map(x => x.Comment, src => src.body.Comment);
        }
    }
}
