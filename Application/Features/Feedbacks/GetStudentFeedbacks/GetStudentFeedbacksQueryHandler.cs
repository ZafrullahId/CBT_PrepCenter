using CBTPreparation.Application.Shared;
using CBTPreparation.Domain.StudentAggregate;
using MapsterMapper;
using MediatR;

namespace CBTPreparation.Application.Features.Feedbacks.GetStudentFeedbacks
{
    public class GetStudentFeedbacksQueryHandler : IRequestHandler<GetStudentFeedbackQuery, GetStudentFeedbackQueryResponse>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public GetStudentFeedbacksQueryHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<GetStudentFeedbackQueryResponse> Handle(GetStudentFeedbackQuery request, CancellationToken cancellationToken)
        {
            var feedbacks = await _studentRepository.GetAllFeedbackByStudentIdAsync(request.StudentId, cancellationToken);

            if (feedbacks is { Count: > 0 })
            {
                var mappedFeedbacks = _mapper.Map<GetStudentFeedbackQueryResponse>(feedbacks);
                return new GetStudentFeedbackQueryResponse(
                    feedbacks.Select(x => x.Comment),
                    new BaseResponse("Student Feedback Successfully Retrieved", false));
            }
            return new GetStudentFeedbackQueryResponse([], new BaseResponse("No Student Feedback Yet", false));
        }

    }
}
