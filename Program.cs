using FluentValidation;
using FreeBilling.Data.Entities;
using FreeBilling.Web.Apis;
using FreeBilling.Web.Data;
using FreeBilling.Web.Services;
using FreeBilling.Web.Validators;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

IConfigurationBuilder configBuilder = builder.Configuration;
configBuilder.Sources.Clear();
configBuilder.AddJsonFile("appsettings.json")
    .AddJsonFile("appsettings.development.json", true)
    .AddUserSecrets(Assembly.GetExecutingAssembly())
    .AddEnvironmentVariables()
    .AddCommandLine(args);
builder.Services.AddDbContext<BillingContext>();
builder.Services.AddScoped<IBillingRepository, BillingRepository>();

builder.Services.AddRazorPages();
builder.Services.AddTransient<IEmailService, DevTimeEmailServices>();

builder.Services.AddControllers();

builder.Services.AddValidatorsFromAssemblyContaining<TimeBillModelValidator>();

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseDeveloperExceptionPage();

app.UseDefaultFiles();

app.UseStaticFiles();

app.MapRazorPages();

TimeBillsApi.Register(app);

app.MapControllers();

app.Run();
