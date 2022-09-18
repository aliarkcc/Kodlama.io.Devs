using Application.Features.GithubProfiles.Commands.CreateGithubProfileCommands;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.GithubProfiles.Rules
{
    public class GithubProfileBusinessRules
    {
        private readonly IGithubProfilerRepository _githubProfilerRepository;

        public GithubProfileBusinessRules(IGithubProfilerRepository githubProfilerRepository)
        {
            _githubProfilerRepository = githubProfilerRepository;
        }

        public async Task GithubProfileNameByUserIdCanNotBeDuplicatedInserted(CreateGitubProfileCommand createGitubProfileCommand)
        {
            GithubProfile? result = await _githubProfilerRepository.GetAsync(x => x.UserId == createGitubProfileCommand.UserId);
            if (result != null) throw new ProgrammingLanguageException("User Github Profile Exist.");
        }
        public async Task<GithubProfile> GithubProfileNameCanNotBeDuplicatedInserted(string profileAddress)
        {
            GithubProfile? result = await _githubProfilerRepository.GetAsync(x => x.ProfileAddress == profileAddress);
            if (result != null)
                throw new ProgrammingLanguageException("Github Profile Name Exist.");
            else
                return result;
        }
        public void GithubProfileIsNullRequest(GithubProfile? githubProfile)
        {
            if (githubProfile is null) throw new ProgrammingLanguageException("Github Profile Not Found.");
        }
        public async Task GithubProfileIsNullRequest(int id)
        {
            GithubProfile? result = await _githubProfilerRepository.GetAsync(x => x.Id == id);
            if (result is null) throw new ProgrammingLanguageException("Github Profile Not Found.");
        }
    }
}
