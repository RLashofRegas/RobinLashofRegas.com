using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

public class RequestResponseLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestResponseLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ILogger<RequestResponseLoggingMiddleware> logger)
    {
      //First, get the incoming request
      var request = await FormatRequest(context);

      // Log request
      logger.LogDebug($"HTTP Request: {request}");

      //Format the response from the server
      var response = await FormatResponse(context);

      // Log response
      logger.LogDebug($"HTTP Response: {response}");
    }

    private async Task<string> FormatRequest(HttpContext context)
    {
      context.Request.EnableBuffering();

      var body = await new StreamReader(context.Request.Body).ReadToEndAsync();

      context.Request.Body.Seek(0, SeekOrigin.Begin);

      var headers = "\n";
      foreach(var header in context.Request.Headers)
      {
        var values = string.Join(',', header.Value.ToArray());
        headers += $"\tkey: {header.Key}, values: {values}\n";
      }

      return $"Headers: {headers}\n type: {context.Request.ContentType}\n scheme: {context.Request.Scheme}\n host+path: {context.Request.Host}{context.Request.Path}\n queryString: {context.Request.QueryString}\n body: {body}";
    }

    private async Task<string> FormatResponse(HttpContext context)
    {
      Stream originalBody = context.Response.Body;
      
      string text;
      using (var memStream = new MemoryStream()) {
        context.Response.Body = memStream;

        await _next(context);

        memStream.Seek(0, SeekOrigin.Begin);
        text = await new StreamReader(memStream).ReadToEndAsync();
        memStream.Seek(0, SeekOrigin.Begin);

        await memStream.CopyToAsync(originalBody);
      }

      context.Response.Body = originalBody;

      //Return the string for the response, including the status code (e.g. 200, 404, 401, etc.)
      return $"statusCode: {context.Response.StatusCode}\n responseBody: {text}";
    }
}