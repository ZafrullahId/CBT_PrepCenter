using CBTPreparation.Domain.StudentAggregate;
using MediatR;


namespace CBTPreparation.Application.Features.FeedBack.GetFeedBacksId
{
    public record GetFeedbacksIdQuery(StudentId StudentId) : IRequest<GetFeedbacksIdQueryResponse>;
}
