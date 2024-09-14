using Application.Abstractions.Repositories;
using Application.Features.FeedBack.GetFeedBack;
using Application.Features.Students.GetStudents;
using MapsterMapper;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.FeedBack.GetsFeedBack
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
                new GetFeedbacksQueryResponse(string.Empty, new Shared.BaseResponse("No FeedBacks Yet", false))
            };
        }
    }

}
