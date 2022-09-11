using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Application.Features.ProgrammingLanguageTechnologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingLanguageTechnologies.Queries.GetByIdProgrammingLanguageTechologies
{
    public class GetByIdProgrammingLanguageTechnologyQuery:IRequest<GetByIdProgrammingLanguageTechnologyDto>
    {
        public int Id { get; set; }

        public class GetByIdProgrammingLanguageTechnologyQueryHandler : IRequestHandler<GetByIdProgrammingLanguageTechnologyQuery, GetByIdProgrammingLanguageTechnologyDto>
        {
            private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageTechnologiesBusinessRules _programmingLanguageTechnologiesBusinessRules;
            public GetByIdProgrammingLanguageTechnologyQueryHandler(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, IMapper mapper, ProgrammingLanguageTechnologiesBusinessRules programmingLanguageTechnologiesBusinessRules)
            {
                _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
                _mapper = mapper;
                _programmingLanguageTechnologiesBusinessRules = programmingLanguageTechnologiesBusinessRules;
            }

            public async Task<GetByIdProgrammingLanguageTechnologyDto> Handle(GetByIdProgrammingLanguageTechnologyQuery request, CancellationToken cancellationToken)
            {
                ProgrammingLanguageTechnology? programmingLanguageTechnology = await _programmingLanguageTechnologyRepository.GetAsync(x => x.Id == request.Id);

                _programmingLanguageTechnologiesBusinessRules.ProgrammingLanguageTechnologyIsNullRequest(programmingLanguageTechnology);

                GetByIdProgrammingLanguageTechnologyDto getByIdProgrammingLanguageTechnologyDto = _mapper.Map<GetByIdProgrammingLanguageTechnologyDto>(programmingLanguageTechnology);
                return getByIdProgrammingLanguageTechnologyDto;
            }
        }
    }
}
