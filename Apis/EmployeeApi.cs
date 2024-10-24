using FreeBilling.Web.Data;

namespace FreeBilling.Web.Apis
{
    public static class EmployeeApis
    {
        public static void Register(WebApplication app)
        {
            app.MapGet("/api/employees", GetEmployees)
            .RequireAuthorization("ApiPolicy");
        }

        public static async Task<IResult> GetEmployees(IBillingRepository repository)
        {
            return Results.Ok(await repository.GetEmployees());
        }
    }
}
