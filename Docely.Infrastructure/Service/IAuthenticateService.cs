using Docely.Domain.Contract.Result;
using Docely.Domain.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docely.Infrastructure.Service
{
    public interface IAuthenticateService
    {
        public Task<AuthenticateResult> LoginAsync(LoginCommand loginQuery);
    }
}
