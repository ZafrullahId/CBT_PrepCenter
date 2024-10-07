using CBTPreparation.Application.Features.Students.GetStudent;
using CBTPreparation.Application.Shared;
using CBTPreparation.Domain;
using CBTPreparation.Domain.StudentAggregate;
using MediatR;

namespace CBTPreparation.Application.Features.Feedback.CreateFeedback
{
    public class CreateFeedbackCommandHandler(IStudentRepository _studentRepository, IUnitOfWorkRepository _unitOfWorkRepository) : IRequestHandler<CreateFeedbackCommand, CreateFeedbackCommandResponse>
    {
        public async Task<CreateFeedbackCommandResponse> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetStudentAsync(request.StudentId, cancellationToken);
            if (student is not { })
                throw new StudentNotFoundException(request.StudentId);

            var feedback = student.AddFeedBack(request.Comment);

            //var feedback = Feedback.Create(request.StudentId, request.Comment);

            //await _studentRepository.CreateAsync(feedback, cancellationToken);

            await _unitOfWorkRepository.SaveChangesAsync(cancellationToken);

            return new CreateFeedbackCommandResponse(
                feedback.Id,
                feedback.Comment,
                new BaseResponse(
                "FeedBack Successfully Created",
                true));

        }
    }
}
