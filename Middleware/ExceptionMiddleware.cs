using System.Net;
using Newtonsoft.Json;
using CareFinder.API.Exceptions;

namespace CareFinder.API.Middleware;

public class ExceptionMiddleware
{

  private readonly RequestDelegate _next;
  private readonly ILogger<ExceptionMiddleware> _logger;

  public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
  {
    this._next = next;
    this._logger = logger;
  }

  public async Task InvokeAsync(HttpContext httpContext)
  {
    try
    {
      await _next(httpContext);
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, $"Something went wrong in the {httpContext.Request.Path}");
      await HandleExceptionAsync(httpContext, ex);
    }
  }

  private Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
  {
    httpContext.Response.ContentType = "application/json";
    HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

    var errorDetails = new ErrorDetails
    {
      ErrorType = "Failure",
      ErrorMessage = ex.Message,
    };

    switch (ex)
    {
      case NotFoundException notFoundException:
        statusCode = HttpStatusCode.NotFound;
        errorDetails.ErrorType = "Not Found";
        break;
      default:
        break;
    }

    string response = JsonConvert.SerializeObject(errorDetails);
    httpContext.Response.StatusCode = (int)statusCode;
    return httpContext.Response.WriteAsync(response);
  }
}

public class ErrorDetails
{
  public string ErrorType { get; set; }
  public string ErrorMessage { get; set; }
}

