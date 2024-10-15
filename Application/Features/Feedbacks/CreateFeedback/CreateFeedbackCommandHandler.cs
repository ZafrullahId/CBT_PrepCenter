using CBTPreparation.Application.Abstractions.Repositories;
using CBTPreparation.Application.Features.Students.GetStudent;
using CBTPreparation.Application.Shared;
using CBTPreparation.Domain;
using CBTPreparation.Domain.FeedbackAggregate;
using CBTPreparation.Domain.StudentAggregate;
using MediatR;

namespace CBTPreparation.Application.Features.Feedbacks.CreateFeedback
{
    public class CreateFeedbackCommandHandler(IStudentRepository _studentRepository, IFeedbackRepository _feedbackRepository, IUnitOfWorkRepository _unitOfWorkRepository) : IRequestHandler<CreateFeedbackCommand, CreateFeedbackCommandResponse>
    {
        public async Task<CreateFeedbackCommandResponse> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetStudentAsync(request.StudentId, cancellationToken);
            if (student is not { })
                throw new StudentNotFoundException(request.StudentId);

            var feedback = Feedback.Create(request.StudentId, request.Comment);

            await _feedbackRepository.CreateAsync(feedback, cancellationToken);


            return new CreateFeedbackCommandResponse(
                feedback.Id,
                feedback.Comment,
                new BaseResponse(
                "FeedBack Successfully Created",
                true));

        }
    }
}
