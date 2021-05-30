using FluentValidation;

namespace Disney.Application.Features.Movies.Commands.CreateMovie
{
    public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty().WithMessage("{PropertyName} es requerido")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} no debe exceder los 50 caracteres");
        }
    }
}
