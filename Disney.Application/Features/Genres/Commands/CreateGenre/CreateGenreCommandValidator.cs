using FluentValidation;

namespace Disney.Application.Features.Genres.Commands.CreateGenre
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(g => g.Name)
                .NotEmpty().WithMessage("{PropertyName} es requerido")
                .NotNull()
                .MaximumLength(20).WithMessage("{PropertyName} no debe exceder los 20 caracteres");
        }
    }
}
