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
                .NotEmpty().WithMessage("{PropertyName} es requerido")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} no debe exceder los 50 caracteres ");
        }
        
    }
}
