using System;
using System.Collections.Generic;

namespace MTBackend.Models;

public partial class Image
{
    public long Id { get; set; }

    public string Image1 { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
