using Application.Features.GithubProfiles.Dtos;
using Application.Features.GithubProfiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GithubProfiles.Commands.UpdateGithubProfileCommands
{
    public class UpdateGithubProfileCommand : IRequest<UpdatedGithubProfileDto>
    {
        public int Id{ get; set; }
        public string ProfileName{ get; set; }

        public class UpdateGithubProfileCommandHandler : IRequestHandler<UpdateGithubProfileCommand, UpdatedGithubProfileDto>
        {
            private readonly IGithubProfilerRepository _githubProfilerRepository;
            private readonly IMapper _mapper;
            private readonly GithubProfileBusinessRules _rules;
            public UpdateGithubProfileCommandHandler(IGithubProfilerRepository githubProfilerRepository, IMapper mapper, GithubProfileBusinessRules rules)
            {
                _githubProfilerRepository = githubProfilerRepository;
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<UpdatedGithubProfileDto> Handle(UpdateGithubProfileCommand request, CancellationToken cancellationToken)
            {

                _rules.GithubProfileIsNullRequest(request.Id);
                GithubProfile githubProfile=await _rules.GithubProfileNameCanNotBeDuplicatedInserted(request.ProfileName);

                GithubProfile updatedGithubProfile = await _githubProfilerRepository.UpdateAsync(githubProfile);
                UpdatedGithubProfileDto updatedGithubProfileDto = _mapper.Map<UpdatedGithubProfileDto>(updatedGithubProfile);
                return updatedGithubProfileDto;
            }
        }
    }
}
