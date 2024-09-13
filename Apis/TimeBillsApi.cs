using FluentValidation;
using FreeBilling.Data.Entities;
using FreeBilling.Web.Data;
using FreeBilling.Web.Models;
using FreeBilling.Web.Validators;
using Mapster;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace FreeBilling.Web.Apis
{
    public static class TimeBillsApi
    {
        public static void Register(WebApplication app)
        {
            app.MapGet("/api/timebills/{id:int}", GetTimeBill)
                .WithName("GetTimeBill")
                .RequireAuthorization("ApiPolicy");

            app.MapPost("api/timebills", PostTimeBill)
                .RequireAuthorization("ApiPolicy");
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
            TimeBillModel model,
            ClaimsPrincipal user)
        {
            var validation = validator.Validate(model);

            if (!validation.IsValid)
            {
                return Results.ValidationProblem(validation.ToDictionary());
            }

            var newEntity = model.Adapt<TimeBill>();

            var employee = await repository.GetEmployee(user.Identity?.Name!);

            if (employee is null) return Results.BadRequest("No employee with user's email");

            newEntity.EmployeeId = employee.Id;

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
