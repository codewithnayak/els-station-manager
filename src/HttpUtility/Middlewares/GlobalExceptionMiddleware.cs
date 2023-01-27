using HttpUtility.Response;
using Microsoft.AspNetCore.Http;

namespace HttpUtility.Middlewares
{
    /// <summary>
    /// 
    /// </summary>
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                //TODO: Should ideally also log the message with error and stack trace .
                var response = new ResponseBase()
                {
                    Errors = new Error[]
                    {
                        new Error
                        {
                            Code = StatusCodes.Status500InternalServerError,
                            Message = "An error occurred .Please contact the administrator."
                        }
                    }
                };

                await httpContext.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));
            }
            
        }
    }
}
