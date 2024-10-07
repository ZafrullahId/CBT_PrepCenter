using CBTPreparation.APIs.Endpoints.FeedBack.GetFeedbacks;
using CBTPreparation.APIs.Filters;
using CBTPreparation.Application.Features.Feedback.GetStudentFeedbacks;
using CBTPreparation_Application.Abstractions;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CBTPreparation.APIs.Endpoints.FeedBack.GetStudentFeedback
{
    public class GetStudentFeedbackEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/feedbacks/student/{student-id:guid}", async (
                   [AsParameters] GetStudentFeedbackRequest request,
                    IMapper mapper,
                    IMediator mediator,
                    CancellationToken cancellationToken) =>
            {
                var command = mapper.Map<GetStudentFeedbackQuery>(request);
                var result = await mediator.Send(command, cancellationToken);

                return mapper.Map<IEnumerable<GetFeedbacksResponse>>(result);
            }).Validator<GetStudentFeedbackRequest>()
            .WithTags(EndpointSchema.Feedback);
        }
    }
}
