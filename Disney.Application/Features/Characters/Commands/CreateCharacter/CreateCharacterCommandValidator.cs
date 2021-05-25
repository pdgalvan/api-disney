using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;


namespace Disney.Application.Features.Characters.Commands.CreateCharacter
{
    public class CreateCharacterCommandValidator : AbstractValidator<CreateCharacterCommand>
    {
        public CreateCharacterCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed ... ");
        }
        
    }
}
