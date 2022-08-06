
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Docely.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BaseController : Controller
    {
        protected readonly ISender _madiator;

        public BaseController(ISender madiator)
        {
            _madiator = madiator;
        }
    }
}
