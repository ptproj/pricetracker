namespace BL
{
    public interface IPasswordHashHelper
    {
        string GenerateSalt(int nSalt);
        string HashPassword(string password, string salt, int nIterations, int nHash);
    }
}