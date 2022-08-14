using Docely.Domain.Dto;
using MediatR;


namespace Docely.Infrastructure.Queries
{
    public class TokenQuery : IRequest<TokenDto>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
