using Application.Features.GithubProfiles.Dtos;
using Application.Features.GithubProfiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GithubProfiles.Commands.CreateGithubProfileCommands
{
    public class CreateGitubProfileCommand:IRequest<CreateGithubProfileDto>
    {
        public int UserId { get; set; }
        public string ProfileUserName { get; set; }

        public class CreateGitubProfileCommandHandler : IRequestHandler<CreateGitubProfileCommand, CreateGithubProfileDto>
        {
            private readonly IGithubProfilerRepository _githubProfilerRepository;
            private readonly IMapper _mapper;
            private readonly GithubProfileBusinessRules _rules;

            public CreateGitubProfileCommandHandler(IGithubProfilerRepository githubProfilerRepository, IMapper mapper, GithubProfileBusinessRules rules)
            {
                _githubProfilerRepository = githubProfilerRepository;
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<CreateGithubProfileDto> Handle(CreateGitubProfileCommand request, CancellationToken cancellationToken)
            {
                await _rules.GithubProfileNameByUserIdCanNotBeDuplicatedInserted(request);
                await _rules.GithubProfileNameCanNotBeDuplicatedInserted(request.ProfileUserName);

                GithubProfile mappedGithubProfile = _mapper.Map<GithubProfile>(request);

                GithubProfile createdGithubProfile= await _githubProfilerRepository.AddAsync(mappedGithubProfile);
                CreateGithubProfileDto createdGitubProfileDto = _mapper.Map<CreateGithubProfileDto>(createdGithubProfile);
                return createdGitubProfileDto;
            }
        }
    }
}
