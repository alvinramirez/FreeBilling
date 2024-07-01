using FreeBilling.Data.Entities;
using FreeBilling.Web.Data;
using FreeBilling.Web.Services;
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

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseDeveloperExceptionPage();

app.UseDefaultFiles();

app.UseStaticFiles();

app.MapRazorPages();

app.MapGet("/api/timebills/{id:int}", async (IBillingRepository repository, int id) =>
{
    var bill = await repository.GetTimeBill(id);

    if (bill is null) Results.NotFound();

    return Results.Ok(bill);
})
    .WithName("GetTimeBill");

app.MapPost("api/timebills", async (IBillingRepository repository, TimeBill model) =>
{
    repository.AddEntity(model);
    if (await repository.SaveChanges())
    {
        return Results.CreatedAtRoute("GetTimeBill", new { id = model.Id }, model);
    }
    else
    {
        return Results.BadRequest();
    }
});

app.MapControllers();

app.Run();
