using Common.Web.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Host.WebApi
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddGlobalErrorHandler(this IApplicationBuilder applicationBuilder) => applicationBuilder.UseMiddleware<GlobalExceptionHandler>();
    }
}
