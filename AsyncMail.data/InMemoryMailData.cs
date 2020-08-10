using AsyncMail.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AsyncMail.data
{
    public class InMemoryMailData : IMailData
    {
        readonly List<MailObject> mail;
        public InMemoryMailData()
        {
            mail = new List<MailObject>()
            {
                new MailObject { Id = 1, Sender = "Mike", Recipient = "John", Subject = "Coding", Body = "Coder's unite", Time = 1 },
                new MailObject { Id = 2, Sender = "Stacey", Recipient = "Sue", Subject = "Basketweaving", Body = "Awesome weave", Time = 1 },
                new MailObject { Id = 3, Sender = "John", Recipient = "Mike", Subject = "Basketweaving", Body = "Awesome weave", Time = 2 },
                new MailObject { Id = 4, Sender = "Brooke", Recipient = "Sue", Subject = "Basketweaving", Body = "Awesome weave", Time = 2 },
                new MailObject { Id = 5, Sender = "Mitch", Recipient = "Sue", Subject = "Basketweaving", Body = "Awesome weave", Time = 1 }
            };
        }

        public IEnumerable<MailObject> GetMailByName(string name)
        {
            return from r in mail
                   where string.IsNullOrEmpty(name) || r.Sender.StartsWith(name)
                   orderby r.Time
                   select r;
        }

        public MailObject GetById(int id)
        {
            return mail.SingleOrDefault(x => x.Id == id);
        }

        public MailObject Add(MailObject newMail)
        {
            mail.Add(newMail);
            newMail.Id = mail.Max(r => r.Id) + 1;
            return newMail;
        }

        public int Commit()
        {
            return 0;
        }

        public MailObject Delete(int id)
        {
            var mailDelete = mail.FirstOrDefault(r => r.Id == id);
            if(mailDelete != null)
            {
                mail.Remove(mailDelete);
            }
            return mailDelete;
        }
    }
}
