using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Docely.Domain.Contract.Result
{
    public class Result
    {
        public bool Succeeded { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
