namespace eIdentificator.Domain.Interfaces
{
    public interface IPasswordHelper
    {
        string HashPassword(string password);
        bool VerifyPassword(string inputPassword, string storedPassword);
    }
}
