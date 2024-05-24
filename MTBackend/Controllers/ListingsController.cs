using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Net.Http.Headers;
using MTBackend.Models;
using MTBackend.Services;
using System.Linq;
using System.Security.Claims;

namespace MTBackend.Controllers;

[ApiController]
public class ListingsController : ControllerBase
{
    private AppDbContent db;
    public ListingsController(AppDbContent context){
        db = context;
    }

    [HttpGet("api/listings")]
    public ActionResult<IEnumerable<object>> GetListings(){
        var listings = db.Listings.Select(u => new {
                id = u.Id,
                title = u.Title,
                price = u.Price,
                category = u.Category,
                isExchangable = u.Isexchangable,
                description = u.Description,
                adress = u.Adress,
                tags = u.Tags,
                publishDate = u.Publishdate,
            }).ToList();
        if (listings == null) return NotFound();
        return listings; 
    }

    [HttpGet("api/listing/{id}")]
    public ActionResult<IEnumerable<object>> GetListing(int id){
        var listing = db.Listings.SingleOrDefault(u => u.Id == id);
        if (listing == null) return NotFound();
        return Ok(listing); 
    }

    [HttpPost("api/listing"), Authorize]
    public IActionResult PostListing(PostListingBody listingBody){

        string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

        if (listingBody == null) return BadRequest("No body recieved.");
        var newListing = new Listing {
            Ownerid = int.Parse(userId),
            Title = listingBody.title,
            Price = listingBody.price,
            Categoryid = listingBody.categoryId,
            Isexchangable = listingBody.isExchangable,
            Description = listingBody.description,
            Adress = listingBody.adress,
            Tags = listingBody.tags,
            Publishdate = DateOnly.FromDateTime(DateTime.Now),
        };
        try {
            db.Listings.Add(newListing);
            db.SaveChanges();
        } catch (Exception e) {
            return BadRequest($"Couldn't add listing: {e.Message}");
        }
        return Ok();
    }
}