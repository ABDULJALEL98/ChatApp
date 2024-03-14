using ChatApp.Application.Features.Message.Command.AddMessage;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Features.Message.Validator;

public class MessageValidator:AbstractValidator<AddMessageDto>
{
    public MessageValidator()
    {
        RuleFor(x => x.Content).NotNull().WithMessage(errorMessage: "{PropertyName} is not null ")
            .MinimumLength(minimumLength: 3).WithMessage(errorMessage: "{PropertyName} Min length {PropertyValue} ");

    }
}
