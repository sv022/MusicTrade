using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MTBackend.Models;

public class User (string Email, string Username, string Password, 
    string City, string Phone, DateOnly Signupdate)
{
    [Key]
    public long Id { get; set; }

    public string Email { get; set; } = Email;

    public string Username { get; set; } = Username;

    public string Password { get; set; } = Password;

    public string Phone { get; set; } = Phone;

    public DateOnly Signupdate { get; set; } = Signupdate;

    public string City { get; set; } = City;
    public string RefreshToken { get; set; } = "";

    public virtual ICollection<Listing> Listings { get; set; } = new List<Listing>();

    public virtual ICollection<UserAdress> UserAdresses { get; set; } = new List<UserAdress>();

    // public User() : this("temp", "temp", "temp", "temp", "temp", new DateOnly()){ }
}
