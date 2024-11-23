using FreeBilling.Web.Data;

namespace FreeBilling.Web.Apis
{
    public static class AuthApi
    {
        public static void Register(WebApplication app)
        {
            app.MapGet("/api/auth", GetAuth)
            .RequireAuthorization("ApiPolicy");
        }

        public static async Task<IResult> GetAuth(IBillingRepository repository)
        {
            return Results.Ok(await repository.GetAuth());
        }
    }
}
