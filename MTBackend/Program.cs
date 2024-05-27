using MTBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MTBackend.Services;

DotNetEnv.Env.Load();
var builder = WebApplication.CreateBuilder(args);

// Configure database context
string? connection = builder.Configuration["CONNECTION_STRING"];
builder.Services.AddDbContext<AppDbContent>(options => options.UseNpgsql(connection).UseSnakeCaseNamingConvention());

// Configure core services
builder.Services.AddControllers();
builder.Services.AddMvcCore();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

// Configure custom services
builder.Services.AddTransient<ITokenService, TokenService>();

// Configure toket authentication
builder.Services.AddAuthentication("bearer")
    .AddJwtBearer("bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["SERVER_SIGNIN_PASSWORD"] + "")),
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero //the default for this setting is 5 minutes
        };

        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure middleware
app.UseHttpsRedirection();
app.UseCors(options => options.AllowAnyOrigin());
app.UseStaticFiles();

app.Run();
