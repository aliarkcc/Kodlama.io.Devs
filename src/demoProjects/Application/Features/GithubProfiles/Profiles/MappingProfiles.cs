using Application.Features.GithubProfiles.Commands.CreateGithubProfileCommands;
using Application.Features.GithubProfiles.Dtos;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.GithubProfiles.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<GithubProfile, CreateGitubProfileCommand>().ReverseMap();
            CreateMap<GithubProfile, CreateGithubProfileDto>().ReverseMap();
            CreateMap<GithubProfile, DeletedGithubProfileDto>().ReverseMap();
            CreateMap<GithubProfile, UpdatedGithubProfileDto>().ReverseMap();
        }
    }
}
