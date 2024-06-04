using FreeBilling.Web.Pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FreeBilling.Web.Pages
{
    public class ContactModel : PageModel
    {
        public string Title { get; set; } = "Contact Me";
        public string Message { get; set; } = "";


        [BindProperty]
        public ContactViewModel Contact { get; set; } = new ContactViewModel();

        public void OnGet()
        {
        }

        public void OnPost(ContactViewModel model) 
        {
            Message = "Not Implemented";
        }
    }
}
