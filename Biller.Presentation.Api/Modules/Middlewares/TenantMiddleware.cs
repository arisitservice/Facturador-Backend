using Biller.Infrastructure.Persistence.Context;
using Biller.Infrastructure.Persistence.Services;
using Biller.Shared;
using Microsoft.EntityFrameworkCore;

namespace Biller.Presentation.Api.Modules.Middlewares
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ITenantDbContextGenerator _factory;

        public TenantMiddleware(RequestDelegate next, ITenantDbContextGenerator factory)
        {
            _next = next;
            _factory = factory;
        }

        public async Task InvokeAsync(HttpContext context, MainDbContext mainDb)
        {
            if (!context.Request.Headers.TryGetValue("X-Tenant-Id", out var tenantIdHeader) ||
                !Guid.TryParse(tenantIdHeader, out var tenantId))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Missing or invalid X-Tenant-Id header.");
                return;
            }

            var tenant = await mainDb.Tenants.FirstOrDefaultAsync(t => t.Id == tenantId);

            if (tenant is null)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync("Tenant not found.");
                return;
            }

            var dbContext = _factory.CreateDbContext(tenant.ConnectionString);
            context.Items[Constants.HttpContextTenantDbContextKey] = dbContext;
            context.Items[Constants.HttpContextTenantEntityKey] = tenant;

            await _next(context);
        }
    }
}
