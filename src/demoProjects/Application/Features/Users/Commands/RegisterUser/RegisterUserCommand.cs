using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using MediatR;

namespace Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<CreatedUserDto>
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }

        public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, CreatedUserDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _rules;

            public RegisterUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules rules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<CreatedUserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                _rules.EmailExists(request.UserForRegisterDto.Email);

                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);
                User user = new()
                {
                    FirstName = request.UserForRegisterDto.FirstName,
                    LastName = request.UserForRegisterDto.LastName,
                    Email = request.UserForRegisterDto.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = true
                };

                User addUser = await _userRepository.AddAsync(user);
                CreatedUserDto createdUserDto = _mapper.Map <CreatedUserDto>(addUser);
                return createdUserDto;
            }
        }
    }
}
