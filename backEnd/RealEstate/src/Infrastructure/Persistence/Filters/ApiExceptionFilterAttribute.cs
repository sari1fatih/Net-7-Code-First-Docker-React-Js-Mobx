using System.Net;
using Common.Classes.Wrappers;
using Common.Enums;
using Common.Interfaces.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Persistence.Filters
{
    public sealed class ApiExceptionFilterAttribute : ExceptionFilterAttribute, IApiExceptionFilter
    {
        public ApiExceptionFilterAttribute()
        {
        }

        public override Task OnExceptionAsync(ExceptionContext context)
        {
            Response<object> response = new Response<object>()
            {
                data = default
            };
            Exception exception = context.Exception;

            switch (exception)
            {
                case Common.Classes.Exceptions.ApiException e:
                    // custom application error
                    response.apiResultType = ApiResultEnum.Warning;
                    response.statusCode = (int)HttpStatusCode.BadRequest;
                    response.message = e.Message;
                    break;
                case KeyNotFoundException e:
                    response.statusCode = (int)HttpStatusCode.NotFound;
                    response.apiResultType = ApiResultEnum.Error;
                    break;
                default:
                    response.statusCode = (int)HttpStatusCode.InternalServerError;
                    response.apiResultType = ApiResultEnum.Error;
                    response.message = "The recording(s) you are trying to view encountered an issue. Please try again later.";
                    break;
            }

            context.Result = new JsonResult(response)
            {
                StatusCode = response.statusCode,
            };

            context.ExceptionHandled = true;

            return Task.CompletedTask;

        }
    }
}

