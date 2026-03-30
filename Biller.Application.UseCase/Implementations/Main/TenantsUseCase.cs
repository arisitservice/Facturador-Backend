using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Infrastructure.Interface.Persistence.Services;
using Biller.Application.Models.Main;
using Biller.Application.UseCase.Contracts.Main;
using Biller.Domain.Entities.MainDb;
using Biller.Domain.Enums;
using Microsoft.Extensions.Configuration;
using Slugify;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace Biller.Application.UseCase.Implementations.Main;

public class TenantsUseCase : ITenantsUseCase
{
    private readonly IMainUnitOfWork _unitOfWork;
    private readonly ITenantDbService tenantDbService;
    private readonly IConfiguration configuration;
    public TenantsUseCase(IMainUnitOfWork unitOfWork, ITenantDbService tenantDbService, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        this.tenantDbService = tenantDbService;
        this.configuration = configuration;
    }

    public async Task<CreateTenantResponse> CrearAsync(CreateTenantRequest request)
    {
        var slugHelper = new SlugHelper();
        string subdomain = slugHelper.GenerateSlug(request.Tenant.Company);
        var connectionString = configuration["TenantConnectionStringTemplate"];

        if (string.IsNullOrEmpty(connectionString))
            throw new ArgumentNullException("TenantConnectionStringTemplate must be configured");

        connectionString = connectionString.Replace("{dbname}", "Tenant_" + subdomain);

        await tenantDbService.Create(connectionString);

        var tenant = new Tenant
        {
            Id               = Guid.NewGuid(),
            Name             = request.Tenant.Name,
            Company          = request.Tenant.Company,
            Email            = request.Owner.Email,
            Subdomain        = subdomain,
            ConnectionString = connectionString
        };

        await _unitOfWork.Tenants.AddAsync(tenant);

        var owner = new User
        {
            Username     = request.Owner.Username,
            Email        = request.Owner.Email,
            PasswordHash = HashPassword(request.Owner.Password),
            UserType     = UserType.Owner,
            TenantId     = tenant.Id,
            Created      = DateTime.UtcNow,
            CreatedBy    = request.Owner.Username
        };

        await _unitOfWork.Users.AddAsync(owner);
        await _unitOfWork.SaveChangesAsync();

        return new CreateTenantResponse
        {
            TenantId  = tenant.Id,
            Name      = tenant.Name,
            Company   = tenant.Company,
            Email     = tenant.Email,
            Subdomain = tenant.Subdomain,
            Owner     = new CreateTenantResponse.OwnerCreated
            {
                Id       = owner.Id,
                Username = owner.Username,
                Email    = owner.Email
            }
        };
    }

    private static string HashPassword(string password)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);
    }
}
