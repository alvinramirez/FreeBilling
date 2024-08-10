using FreeBilling.Data.Entities;
using FreeBilling.Web.Data;

namespace FreeBilling.Web.Apis
{
    public static class TimeBillsApi
    {
        public static void Register(WebApplication app)
        {

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
                    var newBill = await repository.GetTimeBill(model.Id);
                    return Results.CreatedAtRoute("GetTimeBill", new { id = model.Id }, model);
                }
                else
                {
                    return Results.BadRequest();
                }
            });
        }
    }
}
