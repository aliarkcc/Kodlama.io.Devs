using Domain.Entities;
using FluentValidation;

namespace Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage
{
    public class CreatedProgrammingLanguageCommandValidator:AbstractValidator<ProgrammingLanguage>
    {
        public CreatedProgrammingLanguageCommandValidator()
        {
            RuleFor(x => x.ProgrammingLanguageName).NotEmpty();
        }
    }
}
