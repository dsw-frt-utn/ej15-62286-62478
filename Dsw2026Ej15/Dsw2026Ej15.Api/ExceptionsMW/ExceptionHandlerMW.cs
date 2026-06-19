using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Dsw2026Ej15.Domain.Exceptions
{
    public class ExceptionHandlerMW : Exception
    {
        public readonly RequestDelegate _next;

        public ExceptionHandlerMW (RequestDelegate next)
        { 
            _next = next; 
        }

        public async Task InvokeAsync (HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex) 
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            string message = "Ocurrió un error inesperado al ejecutar la solicitud";
            if (ex is ValidationException ve)
            {
                status = HttpStatusCode.BadRequest;
                message = ve.Message;
            }
            var result = JsonSerializer.Serialize(new { error = message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            await context.Response.WriteAsync(result);
        }
    }
}
