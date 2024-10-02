using CBTPreparation.Application.Abstractions.Repositories;
using CBTPreparation.Application.Features.FeedBack.GetsFeedBack;
using CBTPreparation.Application.Shared;
using MapsterMapper;
using MediatR;

namespace CBTPreparation_Application.Features.FeedBack.GetsFeedBack
{
    public class GetFeedbacksQueryHandler : IRequestHandler<GetFeedbacksQuery, List<GetFeedbacksQueryResponse>>
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMapper _mapper;

        public GetFeedbacksQueryHandler(IFeedbackRepository feedbackRepository, IMapper mapper)
        {
            _feedbackRepository = feedbackRepository;
            _mapper = mapper;
        }

        public async Task<List<GetFeedbacksQueryResponse>> Handle(GetFeedbacksQuery request, CancellationToken cancellationToken)
        {
            var feedbacks = await _feedbackRepository.GetAllAsync(cancellationToken);

            if (feedbacks is { Count: > 0 })
            {
                var mappedFeedbacks = _mapper.Map<List<GetFeedbacksQueryResponse>>(feedbacks); 
                return mappedFeedbacks;
            }

            return new List<GetFeedbacksQueryResponse>
            {
                new GetFeedbacksQueryResponse(string.Empty, new BaseResponse("No FeedBacks Yet", false))
            };
        }
    }

}
