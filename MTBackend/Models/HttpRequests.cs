namespace MTBackend.Models;

public class UserRegisterBody {
    public string? Email { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? City { get; set; }
    public string? Phone { get; set; }
}