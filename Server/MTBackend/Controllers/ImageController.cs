using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using MTBackend.Models;

namespace MTBackend.Controllers;

[ApiController]
public class ImageController : ControllerBase
{
    private AppDbContent db;
    public ImageController(AppDbContent context){
        db = context;
    }

    [HttpGet("api/image/{id}")]
    public ActionResult GetImage(int Id){
        var image = db.Images.Where(u => u.Id == Id).SingleOrDefault();
        if (image == null) return NotFound();

        try {
            byte[] bytes = Convert.FromBase64String(image.Image1);
            MemoryStream stream = new(bytes);
            var file = new FormFile(stream, 0, bytes.Length, image.Id.ToString(), image.Id.ToString());
            return File(stream, "image/png", image.Id.ToString());
        } catch (Exception e) {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("api/image")]
    public ActionResult PostImage([FromForm]IFormFile image){
        if (image.Length == 0) return BadRequest();
        try {
            using (var ms = new MemoryStream())
            {
                image.CopyTo(ms);
                var fileBytes = ms.ToArray();
                string s = Convert.ToBase64String(fileBytes);
                var newImage = new Image {Id = 0, Image1 = s};
                db.Images.Add(newImage);
                db.SaveChanges();
                return Ok(newImage.Id);
            }
        } catch (Exception e){
            return BadRequest(e.Message);
        }
    }
}