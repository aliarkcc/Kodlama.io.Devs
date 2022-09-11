using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.ProgrammingLanguageTechnologies.Rules
{
    public class ProgrammingLanguageTechnologiesBusinessRules
    {
        private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;

        public ProgrammingLanguageTechnologiesBusinessRules(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository)
        {
            _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
        }

        public void ProgrammingLanguageTechnologyIsNullRequest(ProgrammingLanguageTechnology? programmingLanguageTechnology)
        {
            if (programmingLanguageTechnology == null) throw new ProgrammingLanguageException("Programming Language Technologies Not Found.");
        }
    }
}
