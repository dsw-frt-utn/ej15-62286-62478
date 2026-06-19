using System;
using System.Collections.Generic;
using System.Text;
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


}
}
