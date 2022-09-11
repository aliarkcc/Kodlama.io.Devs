using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Commands.UpdatedProgrammingLanguage
{
    public class UpdatedProgrammingLanguageCommand:IRequest<UpdatedProgrammingLanguageDto>
    {
        public UpdateProgrammingLanguageTechnologyDto UpdatedProgrammingLanguageModel { get; set; }

        public class UpdatedProgrammingLanguageQueryHandler : IRequestHandler<UpdatedProgrammingLanguageCommand, UpdatedProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguagesBusinessRules _programmingLanguagesBusinessRules;
            public UpdatedProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguagesBusinessRules programmingLanguagesBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguagesBusinessRules = programmingLanguagesBusinessRules;
            }

            public async Task<UpdatedProgrammingLanguageDto> Handle(UpdatedProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage programmingLanguage = _mapper.Map<ProgrammingLanguage>(request.UpdatedProgrammingLanguageModel);
                _programmingLanguagesBusinessRules.ProgrammingLanguageIsNullRequest(programmingLanguage);

                ProgrammingLanguage  updatedProgrammingLanguage= await _programmingLanguageRepository.UpdateAsync(programmingLanguage);
                UpdatedProgrammingLanguageDto updatedProgrammingLanguageDto = _mapper.Map<UpdatedProgrammingLanguageDto>(updatedProgrammingLanguage);
                return updatedProgrammingLanguageDto;
            }
        }
    }
}
