using Docely.Domain.Dto;
using Docely.Infrastructure.Queries;
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
        public Task<TokenDto> Handle(TokenQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
