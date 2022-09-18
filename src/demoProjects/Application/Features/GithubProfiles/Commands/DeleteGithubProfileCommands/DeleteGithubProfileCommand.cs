using Application.Features.GithubProfiles.Dtos;
using Application.Features.GithubProfiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GithubProfiles.Commands.DeleteGithubProfileCommands
{
    public class DeleteGithubProfileCommand : IRequest<DeletedGithubProfileDto>
    {
        public int Id { get; set; }

        public class DeleteGithubProfileCommandHandler : IRequestHandler<DeleteGithubProfileCommand, DeletedGithubProfileDto>
        {
            private readonly IGithubProfilerRepository _githubProfilerRepository;
            private readonly IMapper _mapper;
            private readonly GithubProfileBusinessRules _rules;
            public DeleteGithubProfileCommandHandler(IGithubProfilerRepository githubProfilerRepository, IMapper mapper, GithubProfileBusinessRules rules)
            {
                _githubProfilerRepository = githubProfilerRepository;
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<DeletedGithubProfileDto> Handle(DeleteGithubProfileCommand request, CancellationToken cancellationToken)
            {
                GithubProfile? githubProfile = await _githubProfilerRepository.GetAsync(x => x.Id == request.Id);

                _rules.GithubProfileIsNullRequest(githubProfile);

                GithubProfile deletedGithubProfile = await _githubProfilerRepository.DeleteAsync(githubProfile);

                DeletedGithubProfileDto deletedGithubProfileDto = _mapper.Map<DeletedGithubProfileDto>(deletedGithubProfile);
                return deletedGithubProfileDto;
            }
        }
    }
}
