using System.Net;
using Core;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Shop.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var exceptionMessage = context.Exception.Message;
        
        var statusCode = context.Exception switch
        {
            EntityNotFoundException => HttpStatusCode.NotFound,
            _ => HttpStatusCode.InternalServerError
        };
        
        context.HttpContext.Response.ContentType = ContentTypes.ApplicationJson;
        context.HttpContext.Response.StatusCode = (int)statusCode;

        context.Result = new JsonResult(new { errorMessage = exceptionMessage });
    }
}