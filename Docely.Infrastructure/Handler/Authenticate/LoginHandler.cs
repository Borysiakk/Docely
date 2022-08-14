using System.Net;
using System.Security.Claims;
using Docely.Domain.Contract.Result;
using Docely.Infrastructure.Converters;
using Docely.Infrastructure.Queries;
using Docely.Infrastructure.Repository;
using Docely.Infrastructure.Service;
using MediatR;

using BC = BCrypt.Net.BCrypt;
namespace Docely.Infrastructure.Handler.Authenticate
{
    public class LoginHandler :IRequestHandler<LoginQuery,AuthenticateResult>
    {
        private readonly IJwtTokenService _tokenService;
        private readonly IUserRepository _userRepository;


        public LoginHandler(IJwtTokenService tokenService, IUserRepository userRepository)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        public async Task<AuthenticateResult> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByLoginAsync(request.Login);
            if (user == null)
            {
                return new AuthenticateResult()
                {
                    Succeeded = false,
                    Errors = new[] { "" },
                    AuthDate = DateTime.Now,
                    StatusCode = HttpStatusCode.Unauthorized,
                };
            }

            var resultCheckPassword = BC.Verify(request.Password, user.PasswordHash);
            if(!resultCheckPassword)
            {
                return new AuthenticateResult()
                {
                    Succeeded = false,
                    Errors = new[] { "" },
                    AuthDate = DateTime.Now,
                    StatusCode = HttpStatusCode.Unauthorized,
                };
            }
            
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.Role, "Manager")
            };

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);

            _userRepository.Update(user);
            await _userRepository.SaveAsync();

            return new AuthenticateResult()
            {
                Succeeded = true,
                AuthDate = DateTime.Now,
                User = user.ToUserDto(),
                Token = accessToken,
                RefreshToken = refreshToken,
                StatusCode = HttpStatusCode.OK,
            };
        }
    }
}
