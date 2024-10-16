using CBTPreparation.APIs.Endpoints.FeedBack.GetFeedbacks;
using CBTPreparation.Application.Features.FeedBack.GetFeedBacksId;
using CBTPreparation_Application.Abstractions;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CBTPreparation.APIs.Endpoints.FeedBack.GetFeedbacksId
{
    public class GetFeedbacksIdEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/feedbackstudent-id/{feedbackstudent-id:guid}", async (
                   [AsParameters] GetFeedbacksIdRequest request,
                    [FromServices] IMapper mapper,
                    [FromServices] IMediator mediator,
                    CancellationToken cancellationToken) =>
            {
                var command = mapper.Map<GetFeedbacksIdQuery>(request);
                var result = await mediator.Send(command, cancellationToken);

                return mapper.Map<IEnumerable<GetFeedbacksResponse>>(result);
            });
        }
    }
}
