namespace MiddlewareExample.Middlewares
{
    public class HelloMiddleware
    {
        RequestDelegate _next;
        public HelloMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContent)
        {
            // Custom operasyon...
            Console.WriteLine("Selamun aleykum");
            await _next.Invoke(httpContent);
            Console.WriteLine("Aleykum aleykum");
        }

    }
}
