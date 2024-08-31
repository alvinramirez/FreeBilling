using FluentValidation;
using FreeBilling.Data.Entities;
using FreeBilling.Web.Apis;
using FreeBilling.Web.Data;
using FreeBilling.Web.Services;
using FreeBilling.Web.Validators;
using Mapster;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FreeBilling.Web.Data.Entities;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("BillingContextConnection") ?? throw new InvalidOperationException("Connection string 'BillingContextConnection' not found.");

IConfigurationBuilder configBuilder = builder.Configuration;
configBuilder.Sources.Clear();
configBuilder.AddJsonFile("appsettings.json")
    .AddJsonFile("appsettings.development.json", true)
    .AddUserSecrets(Assembly.GetExecutingAssembly())
    .AddEnvironmentVariables()
    .AddCommandLine(args);
builder.Services.AddDbContext<BillingContext>();

builder.Services.AddDefaultIdentity<TimeBillUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<BillingContext>();
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

app.UseDeveloperExceptionPage();

// Allows us to serve index.html as the default webpage
app.UseDefaultFiles();

// Allows us to serve files from wwwroot
app.UseStaticFiles();

// Add Routing
app.UseRouting();

// Add Auth Middleware
app.UseAuthorization();

app.MapRazorPages();

TimeBillsApi.Register(app);

app.MapControllers();

app.Run();
