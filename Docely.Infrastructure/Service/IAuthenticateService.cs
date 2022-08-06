using Docely.Domain.Contract.Result;
using Docely.Infrastructure.Queries;

namespace Docely.Infrastructure.Service
{
    public interface IAuthenticateService
    {
        public Task<AuthenticateResult> LoginAsync(LoginQuery loginQuery);
    }
}
