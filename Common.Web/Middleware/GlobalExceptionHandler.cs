using Common.Web.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Common.Web.Middleware
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;       
        }

        public async Task Invoke(HttpContext context)
        {
            try { }
            catch (Exception ex)
            {
                await HandleExcceptionAsync(context, ex);
            }
        }

        private static Task HandleExcceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode status;
            var stackTrace = string.Empty;
            string message = "";

            var exceptionType = ex.GetType();

            if (exceptionType == typeof(BadRequestException))
            {
                message = ex.Message;
                status = HttpStatusCode.BadRequest;
                stackTrace = ex.StackTrace;
            }
            else if(exceptionType == typeof(NotFoundException))
            {
                message = ex.Message;
                status = HttpStatusCode.NotFound;
                stackTrace = ex.StackTrace;
            }
            else if (exceptionType == typeof(ForbiddenException))
            {
                message = ex.Message;
                status = HttpStatusCode.Forbidden;
                stackTrace = ex.StackTrace;
            }
            else if (exceptionType == typeof(UnauthorizedAccessException))
            {
                message = ex.Message;
                status = HttpStatusCode.Unauthorized;
                stackTrace = ex.StackTrace;
            }
            else
            {
                message = ex.Message;
                status = HttpStatusCode.InternalServerError;
                stackTrace = ex.StackTrace;
            }

            var exceptionResult = JsonSerializer.Serialize(new { error = message, stackTrace });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) status;

            return context.Response.WriteAsync(exceptionResult);
        }
    }
}
