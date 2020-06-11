using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace BlogAPI.Middleware
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestResponseLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ILogger<RequestResponseLoggingMiddleware> logger)
        {
            if (context == null)
            {
                throw new ArgumentNullException($"{nameof(context)}");
            }

            //First, get the incoming request
            var request = await FormatRequest(context).ConfigureAwait(true);

            // Log request
            logger.LogDebug($"HTTP Request: {request}");

            //Format the response from the server
            var response = await FormatResponse(context).ConfigureAwait(true);

            // Log response
            logger.LogDebug($"HTTP Response: {response}");
        }

        private static async Task<string> FormatRequest(HttpContext context)
        {
            context.Request.EnableBuffering();

            string body;
            using (var streamReader = new StreamReader(context.Request.Body))
            {
                body = await streamReader.ReadToEndAsync().ConfigureAwait(true);
            }

            context.Request.Body.Seek(0, SeekOrigin.Begin);

            var headers = "\n";
            foreach (var header in context.Request.Headers)
            {
                var values = string.Join(',', header.Value.ToArray());
                headers += $"\tkey: {header.Key}, values: {values}\n";
            }

            string truncatedBody;
            if (body.Length > 100)
            {
                truncatedBody = body.Substring(0, 100);
            }
            else
            {
                truncatedBody = body;
            }

            return $"Headers: {headers}\n type: {context.Request.ContentType}\n scheme: {context.Request.Scheme}\n host+path: {context.Request.Host}{context.Request.Path}\n queryString: {context.Request.QueryString}\n body (first 50 chars): {truncatedBody}";
        }

        private async Task<string> FormatResponse(HttpContext context)
        {
            var originalBody = context.Response.Body;

            string text;
            using (var memStream = new MemoryStream())
            {
                context.Response.Body = memStream;

                await _next(context).ConfigureAwait(true);

                memStream.Seek(0, SeekOrigin.Begin);

                using (var streamReader = new StreamReader(memStream))
                {
                    text = await streamReader.ReadToEndAsync().ConfigureAwait(true);
                }

                memStream.Seek(0, SeekOrigin.Begin);

                await memStream.CopyToAsync(originalBody).ConfigureAwait(true);
            }

            context.Response.Body = originalBody;

            var headers = "\n";
            foreach (var header in context.Response.Headers)
            {
                var values = string.Join(',', header.Value.ToArray());
                headers += $"\tkey: {header.Key}, values: {values}\n";
            }

            string truncatedBody;
            if (text.Length > 100)
            {
                truncatedBody = text.Substring(0, 100);
            }
            else
            {
                truncatedBody = text;
            }


            //Return the string for the response, including the status code (e.g. 200, 404, 401, etc.)
            return $"Headers: {headers}\n statusCode: {context.Response.StatusCode}\n responseBody (first 50 chars): {truncatedBody}";
        }
    }
}
