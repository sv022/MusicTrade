using System;
using System.Collections.Generic;

namespace MTBackend.Models;

public partial class Listing
{
    public long Id { get; set; }

    public long Ownerid { get; set; }

    public string Title { get; set; } = null!;

    public int Price { get; set; }

    public int Categoryid { get; set; }

    public bool Isexchangable { get; set; }

    public string Description { get; set; } = null!;

    public string Adress { get; set; } = null!;

    public string? Tags { get; set; }

    public DateOnly Publishdate { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual User Owner { get; set; } = null!;
}
