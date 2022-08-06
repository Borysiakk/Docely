using Docely.Domain.Entity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Docely.Infrastructure.Service
{
    public interface IJwtTokenService
    {
        string GenerateRefreshToken();
        string GenerateAccessToken(List<Claim> claims);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
