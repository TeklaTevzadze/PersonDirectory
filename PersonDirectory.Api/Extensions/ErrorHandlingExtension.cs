using Microsoft.AspNetCore.Builder;
using PersonDirectory.Api.Middlewares;

namespace PersonDirectory.Api.Extensions
{
    public static class ErrorHandlingExtension
    {
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
