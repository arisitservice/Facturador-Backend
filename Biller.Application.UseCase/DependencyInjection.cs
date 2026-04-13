using Biller.Application.UseCase.Behaviours;
using Biller.Application.UseCase.Servicea.Encrypt;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Biller.Application.UseCase;

public static class DependencyInjection
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(config =>
        {
            config.LicenseKey = "eyJhbGciOiJSUzI1NiIsImtpZCI6Ikx1Y2t5UGVubnlTb2Z0d2FyZUxpY2Vuc2VLZXkvYmJiMTNhY2I1OTkwNGQ4OWI0Y2IxYzg1ZjA4OGNjZjkiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2x1Y2t5cGVubnlzb2Z0d2FyZS5jb20iLCJhdWQiOiJMdWNreVBlbm55U29mdHdhcmUiLCJleHAiOiIxODA2ODgzMjAwIiwiaWF0IjoiMTc3NTQyNDA1NyIsImFjY291bnRfaWQiOiIwMTlkNWY4NGEyMDM3MDJkOTViZTViZDk1MTFmMDcxNSIsImN1c3RvbWVyX2lkIjoiY3RtXzAxa25mcmFjajM0eTh4ZHphYWptNHB0a2RqIiwic3ViX2lkIjoiLSIsImVkaXRpb24iOiIwIiwidHlwZSI6IjIifQ.pynDkcYESC4PKqGEQ7UtakTAGy8ZJW5cxxUt4HfkMqI3ARzru2DUUYQ4e0dy8Bf5jPxHTqyg6CtdSGlWKkegasoDfox-GiTcR75Bg-zb4qvoMH5p_PObGzmjnpSoM9VZ4xxwlQfKuwbqSCo_ff4d1zuJXZ3Jiqd3vJtif7SglHcqQTNZtnL-hcVk0aW0fadU6F3UWdFTQq6Qaisx6awf-feJxwO7cDMKr6tZIc6r0Xr0YFF-XUPRTsqFt2GAtl1ji5AX1tKRDlRAO2-2jUQ4yDMx42clc9B4FQpJxHYex1URC7jUI_t9FyvPYigedT3eoIr8RiUXPwc6QjtXrWSTqg";
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        });

        services.AddScoped<IPasswordEncriptionService, PasswordEncryptService>();

        return services;
    }
}
