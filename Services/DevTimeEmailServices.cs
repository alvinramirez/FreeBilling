namespace FreeBilling.Web.Services
{
    public class DevTimeEmailServices : IEmailService
    {
        private readonly ILogger<DevTimeEmailServices> logger;

        public DevTimeEmailServices(ILogger<DevTimeEmailServices> logger)
        {
            this.logger = logger;
        }
        public void SendMail(string to, string from, string subject, string body)
        {
            this.logger.LogInformation($"Sending Email to {to} with a subject of {subject}");
        }
    }
}
