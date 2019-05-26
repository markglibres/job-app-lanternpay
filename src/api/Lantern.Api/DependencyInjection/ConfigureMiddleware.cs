using Lantern.Api.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Lantern.Api.DependencyInjection
{
    public static class ConfigureMiddlewareExtensions
    {
        public static IApplicationBuilder ConfigureMiddlewares(this IApplicationBuilder appBuilder)
        {
            appBuilder.UseMiddleware<ErrorHandlingMiddleware>();
            return appBuilder;
        }
    }
}