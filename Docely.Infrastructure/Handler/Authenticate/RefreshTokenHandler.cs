using Docely.Domain.Dto;
using Docely.Infrastructure.Queries;
using Docely.Infrastructure.Repository;
using Docely.Infrastructure.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docely.Infrastructure.Handler.Authenticate
{
    public class RefreshTokenHandler : IRequestHandler<TokenQuery, TokenDto>
    {
        private readonly IJwtTokenService _tokenService;
        private readonly IUserRepository _userRepository;

        public RefreshTokenHandler(IUserRepository userRepository, IJwtTokenService tokenService)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        public async Task<TokenDto> Handle(TokenQuery request, CancellationToken cancellationToken)
        {
            if(request == null || request.RefreshToken is null || request.RefreshToken is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var token = request.AccessToken;
            var refreshToken = request.RefreshToken;

            var principal = _tokenService.GetPrincipalFromExpiredToken(token);

            var user = await _userRepository.GetUserByLoginAsync(principal.Identity.Name);

            if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
                return null;

            var newAccessToken = _tokenService.GenerateAccessToken(principal.Claims.ToList());
            var newRefreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = newAccessToken;
            _userRepository.Update(user);
            await _userRepository.SaveAsync();

            return new TokenDto()
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken,
            };
        }
    }
}
