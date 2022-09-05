using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Commands.UpdatedProgrammingLanguage
{
    public class UpdatedProgrammingLanguageCommand:IRequest<UpdatedProgrammingLanguageDto>
    {
        public UpdatedProgrammingLanguageModel UpdatedProgrammingLanguageModel { get; set; }

        public class UpdatedProgrammingLanguageQueryHandler : IRequestHandler<UpdatedProgrammingLanguageCommand, UpdatedProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            public UpdatedProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedProgrammingLanguageDto> Handle(UpdatedProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage programmingLanguage = _mapper.Map<ProgrammingLanguage>(request.UpdatedProgrammingLanguageModel);
                ProgrammingLanguage  updatedProgrammingLanguage= await _programmingLanguageRepository.UpdateAsync(programmingLanguage);
                UpdatedProgrammingLanguageDto updatedProgrammingLanguageDto = _mapper.Map<UpdatedProgrammingLanguageDto>(updatedProgrammingLanguage);
                return updatedProgrammingLanguageDto;
            }
        }
    }
}
