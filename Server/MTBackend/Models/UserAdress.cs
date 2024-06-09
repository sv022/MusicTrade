using System;
using System.Collections.Generic;

namespace MTBackend.Models;

public partial class UserAdress
{
    public long Id { get; set; }

    public long Userid { get; set; }

    public string Adress { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
