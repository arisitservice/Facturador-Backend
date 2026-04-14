
using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Infrastructure.Interface.Persistence.Services;
using Biller.Application.Models.Main.Tenant;
using Biller.Application.UseCase.Servicea.Encrypt;
using Biller.Domain.Entities.Main;
using Biller.Domain.Enums.Tenant;
using MediatR;
using Microsoft.Extensions.Configuration;
using Slugify;
using System.Security.Cryptography;
using System.Text;

namespace Biller.Application.UseCase.Main.Tenant.Commands.CreateTenantCommand;

public class CreateTenantHandler : IRequestHandler<CreateTenantCommand, TenantCreatedDTO>
{
    private readonly IMainUnitOfWork _unitOfWork;
    private readonly ITenantDbService tenantDbService;
    private readonly IConfiguration configuration;
    private readonly IPasswordEncriptionService passwordEncriptionService;

    public CreateTenantHandler(IMainUnitOfWork unitOfWork, ITenantDbService tenantDbService, IConfiguration configuration, IPasswordEncriptionService passwordEncriptionService)
    {
        _unitOfWork = unitOfWork;
        this.tenantDbService = tenantDbService;
        this.configuration = configuration;
        this.passwordEncriptionService = passwordEncriptionService;
    }

    public async Task<TenantCreatedDTO> Handle(CreateTenantCommand request, CancellationToken cancellationToken)
    {
        var slugHelper = new SlugHelper();
        string subdomain = slugHelper.GenerateSlug(request.Tenant.Company).Replace(".", "");
        var connectionString = configuration["TenantConnectionStringTemplate"];

        if (string.IsNullOrEmpty(connectionString))
            throw new ArgumentNullException("TenantConnectionStringTemplate must be configured");

        connectionString = connectionString.Replace("{dbname}", "tenant-" + subdomain);


        var owner = new Biller.Domain.Entities.Tenant.TenantUser
        {
            Username = request.Owner.Username,
            Email = request.Owner.Email,
            PasswordHash = passwordEncriptionService.Encrypt(request.Owner.Password),
            UserType = TenantUserType.Owner,
            Status = Domain.Enums.Status.Active,
            Created = DateTime.UtcNow,
            CreatedBy = request.Owner.Username
        };

        var account = new Biller.Domain.Entities.Tenant.Account
        {
            TenantName = request.Tenant.Name,
            Company = request.Tenant.Company,
            Image = ""
        };

        await tenantDbService.Create(connectionString, owner, account);


        var tenant = new Domain.Entities.Main.Tenant
        {
            Id = Guid.NewGuid(),
            Name = request.Tenant.Name,
            Company = request.Tenant.Company,
            Email = request.Owner.Email,
            Subdomain = subdomain,
            ConnectionString = connectionString
        };

        await _unitOfWork.Tenants.AddAsync(tenant);
        await _unitOfWork.SaveChangesAsync();

        return new TenantCreatedDTO
        {
            TenantId = tenant.Id,
            Name = tenant.Name,
            Company = tenant.Company,
            Email = tenant.Email,
            Subdomain = tenant.Subdomain,
            Owner = new TenantCreatedDTO.User
            {
                Id = owner.Id,
                Username = owner.Username,
                Email = owner.Email
            }
        };
    }
}
