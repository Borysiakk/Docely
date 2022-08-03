using Docely.Domain.Contract;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Docely.Controllers
{
    public class AuthenticateController : BaseController
    {
        public AuthenticateController(ISender madiator) : base(madiator)
        {

        }

        public async Task<IActionResult> Login(LoginModelView login)
        {
            _madiator.Send();
            return Ok();
        }
    }
}
