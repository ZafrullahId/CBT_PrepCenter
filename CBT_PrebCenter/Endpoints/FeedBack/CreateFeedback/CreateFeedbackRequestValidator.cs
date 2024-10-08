﻿using CBTPreparation.APIs.Endpoints.FeedBack.CreateFeedback;
using FluentValidation;

namespace CBT.APIs.Endpoints.FeedBack.CreateFeedback
{
    public class CreateFeedbackRequestValidator  : AbstractValidator<CreateCommentRequest>
    {
        public CreateFeedbackRequestValidator()
        {

            RuleFor(p => p.Comment).Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage("Invalid Input.");
        }
    }
}
