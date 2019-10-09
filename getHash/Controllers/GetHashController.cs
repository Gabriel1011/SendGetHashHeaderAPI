using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace getHash.Controllers
{
    [Route("getHash")]
    [ApiController]
    public class GetHashController : ControllerBase
    {
        private readonly IHttpContextAccessor httpContext;

        private readonly IHttpContextFactory context;

        public GetHashController(IHttpContextAccessor httpContext, IHttpContextFactory context)
        {
            this.httpContext = httpContext;
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetHash()
        {
            string hash = httpContext?.HttpContext?.Request?.Headers["hash"].ToString();
            return Ok();
        }
    }
}