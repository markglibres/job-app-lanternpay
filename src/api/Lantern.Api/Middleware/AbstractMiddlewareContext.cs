using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Lantern.Api.Middleware
{
    public abstract class AbstractMiddlewareContext
    {
        protected readonly RequestDelegate _next;

        protected AbstractMiddlewareContext(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public abstract Task Invoke(HttpContext context);
    }
}