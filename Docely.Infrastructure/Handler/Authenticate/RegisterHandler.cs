using Docely.Domain.Contract.Result;
using System.Security.Claims;
using Docely.Domain.Entity;
using Docely.Infrastructure.Queries;
using Docely.Infrastructure.Repository;
using Docely.Infrastructure.Service;
using MediatR;

using BC = BCrypt.Net.BCrypt;
namespace Docely.Infrastructure.Handler.Authenticate
{
    public class RegisterHandler :IRequestHandler<RegisterQuery,RegisterResult>
    {
        private readonly IJwtTokenService _tokenService;
        private readonly IUserRepository _userRepository;


        public RegisterHandler(IJwtTokenService tokenService, IUserRepository userRepository)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        public async Task<RegisterResult> Handle(RegisterQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (user != null)
            {
                return new RegisterResult()
                {
                    Succeeded = false,
                    Errors = new[] { "Email already taken" },
                };
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, request.Email),
                new Claim(ClaimTypes.Role, "Manager")
            };

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            await _userRepository.AddAsync(new User()
            {
                Login = request.Email.Split('@')[0],
                PasswordHash = BC.HashPassword(request.Password),
                PasswordSalt = "",
                Name = request.Name,
                SurName = request.SurName,
                Email = request.Email,
                RefreshToken = refreshToken,
                RefreshTokenExpiryTime = DateTime.Now.AddDays(7),
            });

            await _userRepository.SaveAsync();

            return new RegisterResult(){
                Succeeded = true
            };
        }
    }
}
