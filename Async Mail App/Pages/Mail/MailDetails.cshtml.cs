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
    public class MailBodyModel : PageModel
    {
        private readonly IMailData mailModel;
        public MailObject MailObject { get; set; }

        public MailBodyModel(IMailData mailModel)
        {
            this.mailModel = mailModel;
        }
        public IActionResult OnGet(int mailId)
        {
            MailObject = mailModel.GetById(mailId);
            if (MailObject == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}