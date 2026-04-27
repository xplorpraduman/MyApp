using System.Text.Json;

namespace MyApp.CustomMiddleware
{
    public class GlobalExceptionMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context); // Continue processing the next middleware in the pipeline
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex); // Replace with logger

                if (context.Response.HasStarted)
                {
                    throw;
                }

                context.Response.Clear();
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                var response = new { message = "An unexpected error occurred. Please try again later." };

                var json = JsonSerializer.Serialize(response);

                await context.Response.WriteAsync(json); // Write the JSON response to the client
            }
        }
    }
}
