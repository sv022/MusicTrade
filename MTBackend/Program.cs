using MTBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Configure database context
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContent>(options => options.UseNpgsql(connection).UseSnakeCaseNamingConvention());

// Configure core services
builder.Services.AddControllers();
builder.Services.AddMvcCore();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

// Configure toket authentication
builder.Services.AddAuthentication("bearer")
    .AddJwtBearer("bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["serverSigningPassword"] + "")),
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero //the default for this setting is 5 minutes
        };

        options.Events = new JwtBearerEvents {
            OnAuthenticationFailed = context => {
                if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                    context.Response.Headers.Append("Token-Expired", "true");
                return Task.CompletedTask;
            }
        };
    });

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

