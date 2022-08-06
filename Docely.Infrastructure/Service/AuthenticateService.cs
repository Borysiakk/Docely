
using Docely.Domain.Contract.Result;
using Docely.Infrastructure.Converters;
using Docely.Infrastructure.Queries;
using Docely.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace Docely.Infrastructure.Service
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IJwtTokenService _tokenService;
        private readonly IUserRepository _userRepository;

        public AuthenticateService(IUserRepository userRepository, IJwtTokenService tokenService)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        public async Task<AuthenticateResult> LoginAsync(LoginQuery loginQuery)
        {
            var user = await _userRepository.GetUserByLoginAsync(loginQuery.Login);
            if (user == null)
            {
                return new AuthenticateResult()
                {
                    Succeeded = false,
                    AuthDate = DateTime.Now,
                    StatusCode = System.Net.HttpStatusCode.Unauthorized,
                };
            }

            var resultCheckPassword = BC.Verify(loginQuery.Password, user.PasswordHash);
            if(!resultCheckPassword)
            {
                return new AuthenticateResult()
                {
                    Succeeded = false,
                    AuthDate = DateTime.Now,
                    StatusCode = System.Net.HttpStatusCode.Unauthorized,
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
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
    }
}
