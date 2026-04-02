using Biller.Application.Infrastructure.Interface.Persistence;
using Biller.Application.Models.Tenant.TenantUsers;
using Biller.Application.UseCase.Exceptions;
using Biller.Application.UseCase.Servicea.Encrypt;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using FvValidationFailure = FluentValidation.Results.ValidationFailure;

namespace Biller.Application.UseCase.Tenant.TenantUsers.Commands.LoginTenantUserCommand;

public class LoginTenantUserHandler : IRequestHandler<LoginTenantUserCommand, LoginTenantUserDTO>
{
    private readonly ITenantUnitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;
    private readonly IPasswordEncriptionService passwordEncriptionService;

    public LoginTenantUserHandler(ITenantUnitOfWork unitOfWork, IConfiguration configuration, IPasswordEncriptionService passwordEncriptionService)
    {
        _unitOfWork = unitOfWork;
        _configuration = configuration;
        this.passwordEncriptionService = passwordEncriptionService;
    }

    public async Task<LoginTenantUserDTO> Handle(LoginTenantUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.TenantUsers.GetByEmailAsync(request.Email);

        if (user is null || !passwordEncriptionService.ValidatePassword(request.Password, user.PasswordHash))
            throw new ValidationExceptionCustom([new FvValidationFailure("Credentials", "Invalid email or password.")]);

        var expiresAt = DateTime.UtcNow.AddMinutes(
            double.Parse(_configuration["Jwt:ExpiresInMinutes"] ?? "60"));

        var token = GenerateToken(user.Id, user.Email, user.Username, user.UserType.ToString(), expiresAt);

        return new LoginTenantUserDTO
        {
            Id       = user.Id,
            Username = user.Username,
            Email    = user.Email,
            UserType = user.UserType.ToString(),
            Token    = token,
            ExpiresAt = expiresAt
        };
    }

    private string GenerateToken(int userId, string email, string username, string userType, DateTime expiresAt)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(JwtRegisteredClaimNames.Name, username),
            new Claim(ClaimTypes.Role, userType),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer:   _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims:   claims,
            expires:  expiresAt,
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
