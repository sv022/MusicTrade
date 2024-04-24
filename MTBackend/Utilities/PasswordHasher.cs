using Microsoft.AspNetCore.Identity;

namespace MTBackend.Utilities;
public class PasswordHasher
{
    public string Hash(string password) => 
        BCrypt.Net.BCrypt.HashPassword(password);
    public bool Verify(string password, string hashedPassword) => 
        BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
}
