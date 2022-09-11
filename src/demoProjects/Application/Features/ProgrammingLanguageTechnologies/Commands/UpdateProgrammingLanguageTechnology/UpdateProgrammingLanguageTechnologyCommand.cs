using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Application.Features.ProgrammingLanguageTechnologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLanguageTechnologyCommand
{
    public class UpdateProgrammingLanguageTechnologyCommand : IRequest<UpdateProgrammingLanguageTechnologyDto>
    {
        public UpdateProgrammingLanguageTechnologyModel UpdateProgrammingLanguageTechnologyModel { get; set; }

        public class UpdateProgrammingLanguageTechnologyCommandHandler : IRequestHandler<UpdateProgrammingLanguageTechnologyCommand, UpdateProgrammingLanguageTechnologyDto>
        {
            private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
            private readonly IMapper _mapper;

            public UpdateProgrammingLanguageTechnologyCommandHandler(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, IMapper mapper)
            {
                _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<UpdateProgrammingLanguageTechnologyDto> Handle(UpdateProgrammingLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
                ProgrammingLanguageTechnology programmingLanguageTechnology = _mapper.Map<ProgrammingLanguageTechnology>(request.UpdateProgrammingLanguageTechnologyModel);
                ProgrammingLanguageTechnology createdProgrammingLanguageTechnology = await _programmingLanguageTechnologyRepository.UpdateAsync(programmingLanguageTechnology);
                UpdateProgrammingLanguageTechnologyDto updateProgrammingLanguageTechnologyDto = _mapper.Map<UpdateProgrammingLanguageTechnologyDto>(createdProgrammingLanguageTechnology);
                return updateProgrammingLanguageTechnologyDto;
            }
        }
    }
}
