using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageCommand : IRequest<CreatedProgrammingLanguageDto>
    {
        public string ProgrammingLanguageName { get; set; }

        public class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand, CreatedProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguagesBusinessRules _programmingLanguagesBusinessRules;
            public CreateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguagesBusinessRules programmingLanguagesBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguagesBusinessRules = programmingLanguagesBusinessRules;
            }
            public async Task<CreatedProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programmingLanguagesBusinessRules.ProgrammingLanguageNameCanNotBeDuplicatedInserted(request.ProgrammingLanguageName);

                ProgrammingLanguage mappedPogrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage createProgrammingLanguage=await _programmingLanguageRepository.AddAsync(mappedPogrammingLanguage);
                CreatedProgrammingLanguageDto createdProgrammingLanguageDto = _mapper.Map<CreatedProgrammingLanguageDto>(createProgrammingLanguage);

                return createdProgrammingLanguageDto;
            }
        }
    }
}
