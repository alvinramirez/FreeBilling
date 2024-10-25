using FluentValidation;
using FreeBilling.Web.Apis;
using FreeBilling.Web.Data;
using FreeBilling.Web.Services;
using FreeBilling.Web.Validators;
using Mapster;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using FreeBilling.Web.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.CodeAnalysis.FlowAnalysis;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("BillingDb") ?? throw new InvalidOperationException("Connection string 'BillingDb' not found.");

IConfigurationBuilder configBuilder = builder.Configuration;
configBuilder.Sources.Clear();
configBuilder.AddJsonFile("appsettings.json")
    .AddJsonFile("appsettings.development.json", true)
    .AddUserSecrets(Assembly.GetExecutingAssembly())
    .AddEnvironmentVariables()
    .AddCommandLine(args);
builder.Services.AddDbContext<BillingContext>();

builder.Services.AddIdentityApiEndpoints<TimeBillUser>(options =>
{
    options.SignIn.RequireConfirmedEmail = false;
    options.Password.RequiredLength = 8;
})
    .AddEntityFrameworkStores<BillingContext>();

builder.Services.AddAuthentication()
    .AddJwtBearer(cfg => 
    {
        cfg.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidIssuer = builder.Configuration["Token:Issuer"],
            ValidAudience = builder.Configuration["Token.Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Token:Key"]))
        };
    });

builder.Services.AddAuthorization(cfg =>
{
    cfg.AddPolicy("ApiPolicy", bldr =>
    {
        bldr.RequireAuthenticatedUser();
        bldr.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
    });
});

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("api", cfg =>
    {
        cfg.RequireAuthenticatedUser();
        cfg.AddAuthenticationSchemes(IdentityConstants.BearerScheme);
    });

builder.Services.AddScoped<IBillingRepository, BillingRepository>();

builder.Services.AddRazorPages();
builder.Services.AddTransient<IEmailService, DevTimeEmailServices>();

builder.Services.AddControllers();

builder.Services.AddValidatorsFromAssemblyContaining<TimeBillModelValidator>();

TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetEntryAssembly()!);

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Allows us to serve Index.cshtml as the default webpage
app.UseDefaultFiles();

// Allows us to serve files from wwwroot
app.UseStaticFiles();

// Add Routing
app.UseRouting();
app.UseAuthentication();

// Add Auth Middleware
app.UseAuthorization();

app.MapRazorPages();

TimeBillsApi.Register(app);
EmployeeApi.Register(app);

app.MapControllers();

// No route was found, go to the vue app
app.MapFallbackToPage("/customerBilling");

app.MapGroup("api/auth")
    .MapIdentityApi<TimeBillUser>();

app.Run();
