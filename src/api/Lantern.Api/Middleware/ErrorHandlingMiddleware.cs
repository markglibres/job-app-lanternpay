using System;
using System.Net;
using System.Threading.Tasks;
using Lantern.Core.SeedWork;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Lantern.Api.Middleware
{
    public class ErrorHandlingMiddleware : AbstractMiddlewareContext
    {
        public ErrorHandlingMiddleware(RequestDelegate next) : base(next)
        {
        }

        public override async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BusinessException exception)
            {
                await WriteErrorToResponse(
                    context,
                    exception.Message,
                    HttpStatusCode.BadRequest);
            }
            catch (Exception exception)
            {
                await WriteErrorToResponse(
                    context,
                    exception.Message,
                    HttpStatusCode.InternalServerError);
            }
        }

        private Task WriteErrorToResponse(
            HttpContext context,
            string message, 
            HttpStatusCode httpStatusCode)
        {
            var error = new
            {
                Message = message,
                StatusCode = (int) HttpStatusCode.BadRequest
            };
                
            context.Response.ContentType = "application/vnd.api+json";
            context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(error));
        }
    }
}