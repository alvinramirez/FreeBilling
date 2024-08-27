using Microsoft.AspNetCore.Identity;

namespace FreeBilling.Web.Data.Entities;

public class TimeBillUser : IdentityUser
{
    public DateTime DateOfBirth { get; set; }
}
