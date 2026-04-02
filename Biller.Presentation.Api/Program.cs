using Biller.Application.UseCase;
using Biller.Infrastructure;
using Biller.Infrastructure.Persistence.Seeders;
using Biller.Presentation.Api.Modules.GlobalException;
using Biller.Presentation.Api.Modules.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();


builder.Services.RegisterInfrastructureServicesServices(builder.Configuration);
builder.Services.AddUseCases();

builder.Services.AddGlobalExceptionHandler();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer           = true,
            ValidateAudience         = true,
            ValidateLifetime         = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer              = builder.Configuration["Jwt:Issuer"],
            ValidAudience            = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey         = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

await ApplicationDbSeeder.SeedAsync(app.Services);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseWhen(
    ctx => ctx.Request.Path.StartsWithSegments("/api/Tenant/v1"),
    branch => branch.UseMiddleware<TenantMiddleware>()
);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseGlobalExceptionMiddleware();

app.Run();
