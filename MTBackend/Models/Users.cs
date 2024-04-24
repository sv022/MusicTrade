using System.ComponentModel.DataAnnotations;


namespace MTBackend.Models 
{
    public class User(string Email, string Username, string Password, string City, string Phone, DateTime Signupdate)
    {
        [Key]
        public long Id{ get; set; }
        public string? Email { get; set; } = Email;
        public string? Username { get; set; } = Username;
        public string? Password { get; set; } = Password;
        public string? City { get; set; } = City;
        public string? Phone { get; set; } = Phone;
        public DateTime Signupdate { get; set; } = Signupdate;
    }
}


