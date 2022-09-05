using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage
{
    public class GetByIdProgrammingLanguageQuery : IRequest<GetByIdProgrammingLanguageDto>
    {
        public int Id { get; set; }

        public class GetByIdProgrammingLanguageQueryHandler : IRequestHandler<GetByIdProgrammingLanguageQuery, GetByIdProgrammingLanguageDto>
        {
            private IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguagesBusinessRules _programmingLanguagesBusinessRules;
            public GetByIdProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguagesBusinessRules programmingLanguagesBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguagesBusinessRules = programmingLanguagesBusinessRules;
            }

            public async Task<GetByIdProgrammingLanguageDto> Handle(GetByIdProgrammingLanguageQuery request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(x => x.Id == request.Id);

                _programmingLanguagesBusinessRules.ProgrammingLanguageIsNullRequest(programmingLanguage);

                GetByIdProgrammingLanguageDto getByIdProgrammingLanguageDto = _mapper.Map<GetByIdProgrammingLanguageDto>(programmingLanguage);

                return getByIdProgrammingLanguageDto;
            }
        }
    }
}
