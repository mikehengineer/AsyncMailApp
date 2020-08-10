using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncMail.Core;
using AsyncMail.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Async_Mail_App.Pages
{
    public class MailModel : PageModel
    {
        public IEnumerable<MailObject> mailbag { get; set; }
        [BindProperty(SupportsGet = true)] public string SearchTerm { get; set; }
        //declare and inject interface into constructor
        private readonly IMailData mail;
        public MailModel(IMailData mail)
        {
            this.mail = mail; 
        }
        public void OnGet(string searchTerm)
        {
            mailbag = mail.GetMailByName(SearchTerm);
        }
    }
}
