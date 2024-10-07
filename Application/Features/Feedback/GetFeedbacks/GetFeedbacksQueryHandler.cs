using CBTPreparation.Application.Shared;
using CBTPreparation.Domain.StudentAggregate;
using MapsterMapper;
using MediatR;

namespace CBTPreparation.Application.Features.Feedback.GetFeedbacks
{
    public class GetFeedbacksQueryHandler : IRequestHandler<GetFeedbacksQuery, GetFeedbacksQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;

        public GetFeedbacksQueryHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<GetFeedbacksQueryResponse> Handle(GetFeedbacksQuery request, CancellationToken cancellationToken)
        {
            var feedbacks = await _studentRepository.GetAllFeedbacksAsync(cancellationToken);

            if (feedbacks is { Count: > 0 })
            {
                return new GetFeedbacksQueryResponse(
                    feedbacks.Select(x => x.Comment),
                    new BaseResponse("Student Feedback Successfully Retrieved", false));
            }

            return new GetFeedbacksQueryResponse([], new BaseResponse("No FeedBacks Yet", false));
        }
    }

}
