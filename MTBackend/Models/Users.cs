using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace MTBackend.Models 
{
    public class User {
        public User(long Id, string Username, int Cityid, string Phone, DateTime Signupdate, string Email)
        {
            this.Id = Id;
            this.Username = Username;
            this.Cityid = Cityid;
            this.Phone = Phone;
            this.Signupdate = Signupdate;
            this.Email = Email;
        }

        [Key]
        public long Id{ get; set; }
        public string? Username { get; set; }
        public int Cityid { get; set; }
        public string? Phone { get; set; }
        public DateTime Signupdate { get; set; }
        public string? Email { get; set; }
    }
}


