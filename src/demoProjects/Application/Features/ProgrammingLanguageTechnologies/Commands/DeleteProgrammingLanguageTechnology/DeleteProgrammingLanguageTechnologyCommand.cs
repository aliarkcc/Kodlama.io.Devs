using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Application.Features.ProgrammingLanguageTechnologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingLanguageTechnologies.Commands.DeleteProgrammingLanguageTechnologyCommand
{
    public class DeleteProgrammingLanguageTechnologyCommand: IRequest<DeleteProgrammingLanguageTechnologyDto>
    {
        public int Id { get; set; }

        public class DeleteProgrammingLanguageTechnologyCommandHandler : IRequestHandler<DeleteProgrammingLanguageTechnologyCommand, DeleteProgrammingLanguageTechnologyDto>
        {
            private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageTechnologiesBusinessRules _programmingLanguageTechnologiesBusinessRules;

            public DeleteProgrammingLanguageTechnologyCommandHandler(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, IMapper mapper, ProgrammingLanguageTechnologiesBusinessRules programmingLanguageTechnologiesBusinessRules)
            {
                _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
                _mapper = mapper;
                _programmingLanguageTechnologiesBusinessRules = programmingLanguageTechnologiesBusinessRules;
            }

            public async Task<DeleteProgrammingLanguageTechnologyDto> Handle(DeleteProgrammingLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
                ProgrammingLanguageTechnology? programmingLanguageTechnology = await _programmingLanguageTechnologyRepository.GetAsync(x => x.Id == request.Id);

                _programmingLanguageTechnologiesBusinessRules.ProgrammingLanguageTechnologyIsNullRequest(programmingLanguageTechnology);

                ProgrammingLanguageTechnology programming = await _programmingLanguageTechnologyRepository.DeleteAsync(programmingLanguageTechnology);
                DeleteProgrammingLanguageTechnologyDto deleteProgrammingLanguageTechnologyDto = _mapper.Map<DeleteProgrammingLanguageTechnologyDto>(programming);
                return deleteProgrammingLanguageTechnologyDto;
            }
        }
    }
}
