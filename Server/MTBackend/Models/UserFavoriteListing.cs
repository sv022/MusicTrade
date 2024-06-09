using System;
using System.Collections.Generic;

namespace MTBackend.Models;

public partial class UserFavoriteListing
{
    public long Userid { get; set; }

    public long Listingid { get; set; }

    public virtual Listing Listing { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
