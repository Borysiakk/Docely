using Docely.Domain.Contract.Result;
using Docely.Infrastructure.Queries;
using Docely.Infrastructure.Service;
using MediatR;

namespace Docely.Infrastructure.Handler.Authenticate
{
    public class LoginHandler :IRequestHandler<LoginQuery,AuthenticateResult>
    {
        private readonly IAuthenticateService _authenticateService;

        public LoginHandler(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        public async Task<AuthenticateResult> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            return await _authenticateService.LoginAsync(request);
        }
    }
}
