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
    public class DeleteModel : PageModel
    {
        private readonly IMailData mailData;

        public MailObject mailObject { get; set; }

        public DeleteModel(IMailData mailData)
        {
            this.mailData = mailData;
        }
        public IActionResult OnGet(int mailId)
        {
            mailObject = mailData.GetById(mailId);
            if (mailObject == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int mailId)
        {
            var mail = mailData.Delete(mailId);
            mailData.Commit();

            if (mail == null)
            {
                return RedirectToPage("./NotFound");
            }
            return RedirectToPage("./MailDirectory");
        }
    }
}
