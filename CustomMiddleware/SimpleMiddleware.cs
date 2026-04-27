namespace MyApp.CustomMiddleware
{
    public class SimpleMiddleware (RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine("Custom Middleware Executed"); // Example of custom logic that runs before the next middleware in the pipeline

            // Continue processing next pipeline request
            await _next(context);

            Console.WriteLine("Custom Middleware Completed"); // Example of custom logic that runs after the next middleware in the pipeline
        }
    }
}
