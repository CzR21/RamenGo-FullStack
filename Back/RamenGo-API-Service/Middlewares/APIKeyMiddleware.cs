using Microsoft.AspNetCore.Cors;
using RamenGo_API_Application.Models;
using RamenGo_API_Domain.Options;

namespace RamenGo_API_Service.Middlewares
{
    public class APIKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly APIKeyOption _apiKeyOption;

        public APIKeyMiddleware(RequestDelegate next, APIKeyOption apiKeyOption)
        {
            _next = next;
            _apiKeyOption = apiKeyOption;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path;

            //Librerar swagger
            if (path.StartsWithSegments("/swagger") || path == "/index.html")
            {
                await _next(context);
                return;
            }

            if (!context.Request.Headers.TryGetValue("x-api-key", out var extractedApiKey) || !_apiKeyOption.Secret.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsJsonAsync(new ErrorModel()
                {
                    Error = "x-api-key header missing"
                });
                
                return;
            }
            else
            {
                await _next(context);
            }
        }
    }
}
