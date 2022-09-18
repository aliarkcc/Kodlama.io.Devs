using Application.Services.Repositories;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries.LoginUser
{
    public class LoginUserQuery : IRequest<AccessToken>
    {
        public UserForLoginDto UserForLoginDto { get; set; }

        public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, AccessToken>
        {
            private readonly IUserRepository _userRepository;
            private readonly ITokenHelper _tokenHelper;

            public LoginUserQueryHandler(IUserRepository userRepository, ITokenHelper tokenHelper)
            {
                _userRepository = userRepository;
                _tokenHelper = tokenHelper;
            }

            public async Task<AccessToken> Handle(LoginUserQuery request, CancellationToken cancellationToken)
            {

                User? user = await _userRepository.GetAsync(x => x.Email.ToLower() == request.UserForLoginDto.Email);

                if (user !=null)
                {
                    bool verifyPassword = HashingHelper.VerifyPasswordHash(request.UserForLoginDto.Password, user.PasswordHash, user.PasswordSalt);
                    if (verifyPassword)
                    {
                        AccessToken token = _tokenHelper.CreateToken(user, new List<OperationClaim>());
                        return token;
                    }
                }
                return  null;
            }
        }
    }
}
