using FreeBilling.Data.Entities;
using FreeBilling.Web.Data;

namespace FreeBilling.Web.Apis
{
    public static class TimeBillsApi
    {
        public static void Register(WebApplication app)
        {
            var group = app.MapGroup("/api/timebills");

            group.MapGet("{id:int}", GetTimeBill)
                .WithName("GetTimeBill");

            group.MapPost("", PostTimeBill);
        }

        public static async Task<IResult> GetTimeBill(IBillingRepository repository, 
            int id)
        {
            var bill = await repository.GetTimeBill(id);

            if (bill is null) return Results.NotFound();

            return Results.Ok(bill);
        }

        public static async Task<IResult> PostTimeBill(IBillingRepository repository, TimeBill model)
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
        }
    }
}
