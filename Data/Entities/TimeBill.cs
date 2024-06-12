using System.ComponentModel.DataAnnotations;

namespace FreeBilling.Data.Entities;

public class TimeBill
{
  public int Id { get; set; }
  public Employee? Employee { get; set; }
  public Customer? Customer { get; set; }
  public double Hours { get; set; }
  public double BillingRate { get; set; }
  public DateTime? Date { get; set; }
  public string? WorkPerformed { get; set; }
  public bool ClientRequested { get; set; }
  public string? Category { get; set; }
}
