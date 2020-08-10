using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncMail.Core;
using AsyncMail.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Async_Mail_App.Pages.Mail
{
    public class MailCreate : PageModel
    {
        private readonly IMailData mail;
        [BindProperty] public MailObject MailObject { get; set; }

        public MailCreate(IMailData mail)
        {
            this.mail = mail;
        }
        public IActionResult OnGet()
        {
            MailObject = new MailObject();
            return Page();
        }

        public IActionResult OnPost()
        {
            mail.Add(MailObject);
            mail.Commit();
            return RedirectToPage("./MailDetails", new { mailId = MailObject.Id });
        }
    }
}
