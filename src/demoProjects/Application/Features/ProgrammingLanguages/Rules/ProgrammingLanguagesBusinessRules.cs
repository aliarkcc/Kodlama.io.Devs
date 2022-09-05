using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguagesBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguagesBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingLanguageNameCanNotBeDuplicatedInserted(string programmingLanguageName)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(x => x.ProgrammingLanguageName == programmingLanguageName);
            if (result.Items.Any()) throw new ProgrammingLanguageException("Programming Language Exists.");
        }
        public void ProgrammingLanguageIsNullRequest(ProgrammingLanguage? programmingLanguage)
        {
            if (programmingLanguage == null) throw new ProgrammingLanguageException("Programming Language Not Found.");
        }
    }
}
