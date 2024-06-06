using FreeBilling.Web.Pages.Models;
using FreeBilling.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FreeBilling.Web.Pages
{
    public class ContactModel : PageModel
    {
        private readonly IEmailService emailService;

        public ContactModel(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        public string Title { get; set; } = "Contact Me";
        public string Message { get; set; } = "";


        [BindProperty]
        public ContactViewModel Contact { get; set; } = new ContactViewModel()
        {

        };

        public void OnGet()
        {
        }

        public void OnPost(ContactViewModel model) 
        {
            if (ModelState.IsValid)
            {
                this.emailService.SendMail("alvin.ramirez48@gamil.com", Contact.Email, Contact.Subject, Contact.Body);
                Contact = new ContactViewModel();
                ModelState.Clear();
                Message = "Sent...";
            }
            else 
            {
                Message = "Please fix the errors before sending.";
            }
        }
    }
}
