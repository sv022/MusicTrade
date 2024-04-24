using MTBackend.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure core services
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContent>(options => options.UseNpgsql(connection).UseSnakeCaseNamingConvention());

builder.Services.AddControllers();
builder.Services.AddMvcCore();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

// Configure controllers
app.MapControllerRoute(name: "default",
    pattern: "{controller=UserController}/{action=Index}/{id?}");
app.MapControllerRoute(name: "auth", 
    pattern: "{controller=AuthController}/{action=Index}/{id?}");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure middleware
app.UseHttpsRedirection();
app.UseCors(options => options.AllowAnyOrigin());

app.Run();

