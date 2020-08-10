using AsyncMail.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncMail.data
{
    public interface IMailData
    {
        MailObject GetById(int id);
        IEnumerable<MailObject> GetMailByName(String name);
        MailObject Add(MailObject newMail);
        MailObject Delete(int id);
        int Commit();
    }
}
