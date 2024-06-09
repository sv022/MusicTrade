using System;
using System.Collections.Generic;

namespace MTBackend.Models;

public partial class ListingImage
{
    public long Listingid { get; set; }

    public long Imageid { get; set; }

    public long Id { get; set; }

    public virtual Image Image { get; set; } = null!;

    public virtual Listing Listing { get; set; } = null!;
}
