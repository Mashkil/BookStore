using BookStore.Data.Models;

namespace BookStore.Middleware
{
    public class APIAuthentification
    {
        private readonly RequestDelegate _next;
        private const string Apikey = "ApiKey";

        public APIAuthentification(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(Apikey, out var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Api key was not declared");
                return;
            }

            var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();
            var apikey = appSettings.GetSection("Authentication").Get<AuthenticationSettings>();

            if (!apikey.ApiKey.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Api key is wrong");
                return;
            }

            await _next(context);
        }
    }
}
