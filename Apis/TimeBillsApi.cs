using FluentValidation;
using FreeBilling.Data.Entities;
using FreeBilling.Web.Data;
using FreeBilling.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace FreeBilling.Web.Apis
{
    public static class TimeBillsApi
    {
        public static void Register(WebApplication app)
        {
            var group = app.MapGroup("/api/timebills");

            group.MapGet("{id:int}", GetTimeBill)
                .WithName("GetTimeBill");

            group.MapPost("", PostTimeBill)
                .AddEndpointFilter(async (context, next) =>
                {
                    var validator = context.HttpContext.RequestServices.GetRequiredService<IValidator<TimeBillModel>>();

                    var model = context.Arguments
                    .OfType<TimeBillModel>()
                    .FirstOrDefault();

                    if (model is not null)
                    {
                        var validation = validator.Validate(model);

                        if (!validation.IsValid)
                        {
                            return Results.ValidationProblem(validation.ToDictionary());
                        }
                    }
                    return await next(context);
                });
        }

        public static async Task<IResult> GetTimeBill(IBillingRepository repository, 
            int id)
        {
            var bill = await repository.GetTimeBill(id);

            if (bill is null) return Results.NotFound();

            return Results.Ok(bill);
        }

        public static async Task<IResult> PostTimeBill(IBillingRepository repository,
            TimeBillModel model)
        {
            var newEntity = new TimeBill()
            {
                CustomerId = model.CustomerId,
                EmployeeId = model.EmployeeId,
                Hours = model.HoursWorked,
                BillingRate = model.Rate,
                Date = model.Date,
                WorkPerformed = model.Work
            };

            repository.AddEntity(newEntity);
            if (await repository.SaveChanges())
            {
                var newBill = await repository.GetTimeBill(newEntity.Id);
                return Results.CreatedAtRoute("GetTimeBill", new { id = model.Id }, newBill);
            }
            else
            {
                return Results.BadRequest();
            }
        }
    }
}
