using FreeBilling.Web.Data;
using FreeBilling.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BillingContext>();
builder.Services.AddRazorPages();
builder.Services.AddTransient<IEmailService, DevTimeEmailServices>();

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseDeveloperExceptionPage();

app.UseDefaultFiles();

app.UseStaticFiles();

app.MapRazorPages();

app.Run();
