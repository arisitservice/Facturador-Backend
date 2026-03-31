
namespace Biller.Presentation.Api.Modules.GlobalException;

public static class RegisterGlobalExceptionHandler
{
    public static void AddGlobalExceptionHandler(this IServiceCollection services)
    {
        services.AddTransient<GlobalExceptionHandler>();
    }

    public static void UseGlobalExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<GlobalExceptionHandler>();
    }
}
