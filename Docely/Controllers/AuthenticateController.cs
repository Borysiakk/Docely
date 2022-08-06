using Docely.Domain.Contract;
using Docely.Domain.Contract.Result;
using Docely.Domain.Dto;
using Docely.Infrastructure.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Docely.Controllers
{
    public class AuthenticateController : BaseController
    {
        public AuthenticateController(ISender madiator) : base(madiator){}

        [HttpPost]
        public async Task<IActionResult> Login(LoginQuery login)
        {
            try
            {
                var result = await _madiator.Send(login) as AuthenticateResult;

                if (!result.Succeeded)
                    return new UnauthorizedObjectResult(result);

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Refresh(TokenQuery token)
        {
            var result = await _madiator.Send(token) as TokenDto;

            if(result == null)
                return Unauthorized();

            return new OkObjectResult(result);
        }
    }
}
