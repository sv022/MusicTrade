using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MTBackend.Models;

public partial class User
{
    public long Id { get; set; }

    public string Email { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public DateOnly Signupdate { get; set; }

    public string City { get; set; } = null!;

    public string? Refreshtoken { get; set; }

    public long? Avatarid { get; set; }

    public virtual Image? Avatar { get; set; }

    public virtual ICollection<Listing> Listings { get; set; } = new List<Listing>();

    public virtual ICollection<UserAdress> UserAdresses { get; set; } = new List<UserAdress>();
}
