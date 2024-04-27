namespace MTBackend.Models;

public class UserSignUpBody {
    public required string Email { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string City { get; set; }
    public required string Phone { get; set; }
}

public class UserLoginBody {
    public required string Username { get; set; }
    public required string Password { get; set; }
}
public class TokenRefreshBody {
    public required string Token { get; set; }
    public required string RefreshToken { get; set; }
}