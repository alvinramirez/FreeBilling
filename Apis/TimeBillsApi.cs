using FluentValidation;
using FreeBilling.Data.Entities;
using FreeBilling.Web.Data;
using FreeBilling.Web.Models;
using FreeBilling.Web.Validators;
using Mapster;
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
                .AddEndpointFilter<ValidateEndpointFilter<TimeBillModel>>();
        }

        public static async Task<IResult> GetTimeBill(IBillingRepository repository, 
            int id)
        {
            var bill = await repository.GetTimeBill(id);

            if (bill is null) return Results.NotFound();

            return Results.Ok(bill);
        }

        public static async Task<IResult> PostTimeBill(IBillingRepository repository,
            IValidator<TimeBillModel> validator,
            TimeBillModel model)
        {
            var validation = validator.Validate(model);

            if (!validation.IsValid)
            {
                return Results.ValidationProblem(validation.ToDictionary());
            }

            var newEntity = model.Adapt<TimeBill>();

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
