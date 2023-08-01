using BookStore.Data.Models;

namespace BookStore.Middleware
{
    public class APIKeyMiddleware
    {
        private readonly RequestDelegate _next;

        private const string APIKEYNAME = "ApiKey";

        public APIKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
            {
                context.Response.StatusCode = 401;

                await context.Response.WriteAsync("Api Key was not provided. (Using ApiKeyMiddleware) ");

                return;
            }

            var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();

            var apiKey = appSettings.GetSection("Authentication").Get<AuthenticationSettings>();

            if (!apiKey.ApiKey.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 401;

                await context.Response.WriteAsync("Unauthorized client. (Using ApiKeyMiddleware)");

                return;
            }

            await _next(context);
        }
    }
}
