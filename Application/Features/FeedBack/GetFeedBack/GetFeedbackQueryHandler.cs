using CBTPreparation.Application.Shared;
using CBTPreparation.Domain.StudentAggregate;
using MediatR;

namespace CBTPreparation.Application.Features.Feedback.GetFeedback
{
    public class GetFeedbackQueryHandler(IStudentRepository _studentRepository) : IRequestHandler<GetFeedbackQuery, GetFeedbackQueryResponse>
    {
        public async Task<GetFeedbackQueryResponse> Handle(GetFeedbackQuery request, CancellationToken cancellationToken)
        {
            var feedback = await _studentRepository.GetFeedbackByIdAsync(request.FeedbackId, cancellationToken);

            if (feedback is null) { throw new FeedbackNotFoundException(feedback.Id); }

            return new GetFeedbackQueryResponse(
               feedback.Comment,
               new BaseResponse(
               "Comment Retrieved Successfully",
               true));
        }
    }
}
