using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;

namespace BlogAPI.Middleware
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate next;

        public RequestResponseLoggingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, ILogger<RequestResponseLoggingMiddleware> logger)
        {
            if (context == null)
            {
                throw new ArgumentNullException($"{nameof(context)}");
            }

            //First, get the incoming request
            string request = await FormatRequest(context).ConfigureAwait(true);

            // Log request
            logger.LogDebug($"HTTP Request: {request}");

            //Format the response from the server
            string response = await this.FormatResponse(context).ConfigureAwait(true);

            // Log response
            logger.LogDebug($"HTTP Response: {response}");
        }

        private static async Task<string> FormatRequest(HttpContext context)
        {
            context.Request.EnableBuffering();

            string body;
            using (var streamReader = new StreamReader(context.Request.Body, leaveOpen: true))
            {
                body = await streamReader.ReadToEndAsync().ConfigureAwait(true);
            }

            _ = context.Request.Body.Seek(0, SeekOrigin.Begin);

            string headers = "\n";
            foreach (KeyValuePair<string, StringValues> header in context.Request.Headers)
            {
                string values = string.Join(',', header.Value.ToArray());
                headers += $"\tkey: {header.Key}, values: {values}\n";
            }

            string truncatedBody = body.Length > 100 ? body[..100] : body;

            return $"Headers: {headers}\n type: {context.Request.ContentType}\n scheme: {context.Request.Scheme}\n host+path: {context.Request.Host}{context.Request.Path}\n queryString: {context.Request.QueryString}\n body (first 50 chars): {truncatedBody}";
        }

        private async Task<string> FormatResponse(HttpContext context)
        {
            Stream originalBody = context.Response.Body;

            string text;
            using (var memStream = new MemoryStream())
            {
                context.Response.Body = memStream;

                await this.next(context).ConfigureAwait(true);

                _ = memStream.Seek(0, SeekOrigin.Begin);

                using (var streamReader = new StreamReader(memStream, leaveOpen: true))
                {
                    text = await streamReader.ReadToEndAsync().ConfigureAwait(true);
                }

                _ = memStream.Seek(0, SeekOrigin.Begin);

                await memStream.CopyToAsync(originalBody).ConfigureAwait(true);
            }

            context.Response.Body = originalBody;

            string headers = "\n";
            foreach (KeyValuePair<string, StringValues> header in context.Response.Headers)
            {
                string values = string.Join(',', header.Value.ToArray());
                headers += $"\tkey: {header.Key}, values: {values}\n";
            }

            string truncatedBody = text.Length > 100 ? text[..100] : text;

            //Return the string for the response, including the status code (e.g. 200, 404, 401, etc.)
            return $"Headers: {headers}\n statusCode: {context.Response.StatusCode}\n responseBody (first 50 chars): {truncatedBody}";
        }
    }
}
