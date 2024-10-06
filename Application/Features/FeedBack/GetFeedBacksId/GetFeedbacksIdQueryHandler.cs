using CBTPreparation.Application.Shared;
using CBTPreparation.Domain.StudentAggregate;
using MapsterMapper;
using MediatR;

namespace CBTPreparation.Application.Features.FeedBack.GetFeedBacksId
{
    public class GetFeedbacksQueryHandler : IRequestHandler<GetFeedbacksIdQuery, GetFeedbacksIdQueryResponse>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public GetFeedbacksQueryHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<GetFeedbacksIdQueryResponse> Handle(GetFeedbacksIdQuery request, CancellationToken cancellationToken)
        {
            var feedbacks = await _studentRepository.GetAllFeedbackByStudentIdAsync(request.StudentId, cancellationToken);

            if (feedbacks is { Count: > 0 })
            {
                var mappedFeedbacks = _mapper.Map<GetFeedbacksIdQueryResponse>(feedbacks);
                return new GetFeedbacksIdQueryResponse(
                    feedbacks.Select(x => x.Comment),
                    new BaseResponse("Student Feedback Successfully Retrieved", false));
            }
            return new GetFeedbacksIdQueryResponse([], new BaseResponse("No Student Feedback Yet", false));
        }

    }
}
