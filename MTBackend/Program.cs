using MTBackend.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// 
// 

string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContent>(options => options.UseNpgsql(connection).UseSnakeCaseNamingConvention());

builder.Services.AddControllers();
builder.Services.AddMvcCore();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

app.MapControllerRoute(name: "default",
    pattern: "{controller=UserController}/{action=Index}/{id?}");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(options => options.AllowAnyOrigin());

app.Run();

