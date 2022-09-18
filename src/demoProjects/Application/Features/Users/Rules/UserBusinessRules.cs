using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Domain.Entities;

namespace Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EmailExists(string email)
        {
            User? user=await _userRepository.GetAsync(x => x.Email == email);
            if (user != null) throw new ProgrammingLanguageException("Email Exists.");
        }
    }
}
