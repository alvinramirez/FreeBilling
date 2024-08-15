using FreeBilling.Data.Entities;

namespace FreeBilling.Web.Models
{
    public class TimeBillModel
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? CustomerId { get; set; }
        public double Hours { get; set; }
        public double BillingRate { get; set; }
        public DateTime? Date { get; set; }
        public string? WorkPerformed { get; set; }
    }
}
