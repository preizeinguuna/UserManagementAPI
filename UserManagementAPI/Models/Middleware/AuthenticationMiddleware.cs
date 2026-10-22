using System.Text.Json;

namespace UserManagementAPI.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        private const string ValidToken = "TechHiveToken123";

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var authHeader =
                context.Request.Headers["Authorization"]
                .FirstOrDefault();

            if (string.IsNullOrEmpty(authHeader) ||
                authHeader != $"Bearer {ValidToken}")
            {
                context.Response.StatusCode = 401;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(
                    JsonSerializer.Serialize(new
                    {
                        error = "Unauthorized"
                    }));

                return;
            }

            await _next(context);
        }
    }
}