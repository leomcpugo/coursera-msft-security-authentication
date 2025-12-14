using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Authentication
builder.Services
    .AddAuthentication("SafeVaultAuth")
    .AddCookie("SafeVaultAuth");

// Authorization
builder.Services.AddAuthorization();

var app = builder.Build();

// Middleware pipeline
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();