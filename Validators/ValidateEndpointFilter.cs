
namespace FreeBilling.Web.Validators
{
    public class ValidateEndpointFilter<T> : IEndpointFilter
        where T : class
    {
        public ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            throw new NotImplementedException();
        }
    }
}
