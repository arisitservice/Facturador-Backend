
namespace Biller.Application.UseCase.Servicea.Encrypt;

public interface IPasswordEncriptionService
{
    string Encrypt(string password);
    bool ValidatePassword(string password, string encryptedPassword);
}

public class PasswordEncryptService : IPasswordEncriptionService
{
    public string Encrypt(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool ValidatePassword(string password, string encryptedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, encryptedPassword);
    }
}
