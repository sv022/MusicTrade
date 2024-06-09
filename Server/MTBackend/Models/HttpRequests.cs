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
public class UserPatchBody {
    public required string Email { get; set; }
    public required string Username { get; set; }
    public required string City { get; set; }
    public required string Phone { get; set; }
}
public class TokenRefreshBody {
    public required string Token { get; set; }
    public required string RefreshToken { get; set; }
}

public class PostListingBody {
    public required string title { get; set; }
    public required int price { get; set; }
    public required int categoryId { get; set; }
    public required bool isExchangable { get; set; }
    public required string description { get; set; }
    public required string adress { get; set; }
    public required string tags { get; set; }
    public required List<int> images { get; set; }
}
