using CBTPreparation.Application.Abstractions.Repositories;
using CBTPreparation.Application.Shared;
using Domain.Entity;
using MediatR;

namespace CBTPreparation.Application.Features.FeedBack.CreateFeedBack
{
    public class CreateFeedbackCommandHandler(IStudentRepository _studentRepository, IFeedbackRepository _feedRepository, IUnitOfWorkRepository _unitOfWorkRepository) : IRequestHandler<CreateFeedbackCommand, CreateFeedbackCommandResponse>
    {
        public async Task<CreateFeedbackCommandResponse> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
        {
            var studentId = await _studentRepository.GetAsync(request.StudentId, cancellationToken);

            var feed = Feedback.Create(request.StudentId, request.Comment);

            await _feedRepository.CreateAsync(feed, cancellationToken);

            await _unitOfWorkRepository.SaveChangesAsync(cancellationToken);

            return new CreateFeedbackCommandResponse(
                feed.StudentId,
                feed.Comment,
                new BaseResponse(
                "FeedBack Successfully Created",
                true));

        }
    }
}
