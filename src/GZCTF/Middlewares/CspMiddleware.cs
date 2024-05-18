namespace GZCTF.Middlewares;

public class CspMiddleware(RequestDelegate next)
{
    const string CspString = "default-src 'self'; style-src 'self' 'unsafe-inline'; " +
        "img-src * 'self' data:; font-src * 'self' data:; object-src 'none'; frame-src 'none';";

    public Task InvokeAsync(HttpContext context)
    {
        context.Response.Headers.ContentSecurityPolicy = CspString;
        return next(context);
    }
}

public static class CspMiddlewareExtensions
{
    public static IApplicationBuilder UseCspMiddleware(this IApplicationBuilder builder) =>
        builder.UseMiddleware<CspMiddleware>();
}
