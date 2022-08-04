using Docely.Domain.Contract.Result;
using Docely.Domain.Query;
using Docely.Infrastructure.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docely.Infrastructure.Handler.Authenticate
{
    public class LoginHandler :IRequestHandler<LoginCommand, AuthenticateResult>
    {
        private readonly IAuthenticateService _authenticateService;

        public LoginHandler(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        public async Task<AuthenticateResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return await _authenticateService.LoginAsync(request);
        }
    }
}
