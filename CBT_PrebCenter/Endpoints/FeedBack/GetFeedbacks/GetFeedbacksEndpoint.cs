using CBTPreparation.Application.Features.FeedBack.GetsFeedBack;
using CBTPreparation.Application.Features.Students.GetStudents;
using CBTPreparation_Application.Abstractions;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CBTPreparation.APIs.Endpoints.FeedBack.GetFeedbacks
{
    public class GetFeedbacksEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/feedbacks/", async (
                   
                    [FromServices] IMapper mapper,
                    [FromServices] IMediator mediator,
                    CancellationToken cancellationToken) =>
            {
                var command = new GetFeedbacksQuery();
                var result = await mediator.Send(command, cancellationToken);

                return mapper.Map<IEnumerable<GetFeedbacksQuery>>(result);
            });
        }
    }
}
