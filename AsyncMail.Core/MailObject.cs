using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncMail.Core
{
    public class MailObject
    {
        public int Id { get; set; }
        public String Sender { get; set; }
        public String Recipient { get; set; }
        public String Subject { get; set; }
        public String Body { get; set; }
        public int Time { get; set; }
    }
}
