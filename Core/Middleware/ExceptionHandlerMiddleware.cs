using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Core.Middleware
{
  public class ExceptionHandlerMiddleware
  {
    private RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
      _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
      try
      {
        await _next(httpContext);
      }
      catch (Exception e)
      {
        await HandleExceptionAsync(httpContext, e);
      }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception e)
    {
      httpContext.Response.ContentType = "application/json";
      httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

      string message = "Internal Server Error";
      var errorDetails = new ErrorDetails
      {
        StatusCode = httpContext.Response.StatusCode,
        Message = e.Message
      };
      await httpContext.Response.WriteAsync(JsonSerializer.Serialize(errorDetails));
    }
  }
}
