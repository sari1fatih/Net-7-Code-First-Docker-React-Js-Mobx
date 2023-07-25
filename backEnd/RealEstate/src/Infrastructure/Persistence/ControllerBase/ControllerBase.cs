using System.Collections;
using System.Net;
using Common.Classes.BaseLimits;
using Common.Classes.Wrappers;
using Common.Enums;
using Common.Interfaces.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Options;

namespace Persistence.ControllerBase
{
    [ApiController]
    [ServiceFilter(typeof(IApiExceptionFilter))]
    [EnableRateLimiting(nameof(IOptions<RateLimit>.Value.StandartSliding))]
    public class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        public IActionResult CreateActionResultInstance<T>(Response<T> response)
        {
            if (response.apiResultType == ApiResultEnum.Error)
            {
                return BadRequest(response);
            }
            if (response.data == null)
            {
                return StatusCode((int)HttpStatusCode.OK, response);
            }
            if (response.data is ICollection)
            {
                if (((ICollection)response.data).Count == 0)
                {
                    return StatusCode((int)HttpStatusCode.OK, response);
                }
            }
            return Ok(response);
        }
    }
}

