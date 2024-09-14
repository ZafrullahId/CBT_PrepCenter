using Application.Abstractions.Repositories;
using MapsterMapper;
using MediatR;

namespace Application.Features.FeedBack.GetFeedBacksId
{
    public class GetFeedbacksQueryHandler : IRequestHandler<GetFeedbacksIdQuery, List<GetFeedbacksIdQueryResponse>>
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMapper _mapper;

        public GetFeedbacksQueryHandler(IFeedbackRepository feedbackRepository, IMapper mapper)
        {
            _feedbackRepository = feedbackRepository;
            _mapper = mapper;
        }

        public async Task<List<GetFeedbacksIdQueryResponse>> Handle(GetFeedbacksIdQuery request, CancellationToken cancellationToken)
        {
            var feedbacks = await _feedbackRepository.GetAllAsyncId(request.StudentId,cancellationToken);

            if (feedbacks is { Count: > 0 })
            {
                var mappedFeedbacks = _mapper.Map<List<GetFeedbacksIdQueryResponse>>(feedbacks);
                return mappedFeedbacks;
            }

            return new List<GetFeedbacksIdQueryResponse>
            {
                new GetFeedbacksIdQueryResponse(string.Empty, new Shared.BaseResponse("No Student Feedback Yet", false))
            };
        }
    }
}
