using Microsoft.AspNetCore.Builder;

namespace HttpUtility.Middlewares
{
    public static class GlobalExceptionMiddlewareExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder AddGlobalExceptionFilter(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
}
