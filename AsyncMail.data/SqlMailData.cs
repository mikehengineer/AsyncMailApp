using AsyncMail.Core;
using System.Collections.Generic;
using System.Linq;

namespace AsyncMail.data
{
    public class SqlMailData : IMailData
    {
        private readonly AsyncMailDbContext db;

        public SqlMailData(AsyncMailDbContext db)
        {
            this.db = db;
        }
        public MailObject Add(MailObject newMail)
        {
            db.Add(newMail);
            return newMail;
        }

        public int Commit()
        {
            return db.SaveChanges(); 
        }

        public MailObject Delete(int id)
        {
            var mail = GetById(id);
            if(mail != null)
            {
                db.MailBox.Remove(mail);
            }
            return mail;
        }

        public MailObject GetById(int id)
        {
            return db.MailBox.Find(id);
        }

        public IEnumerable<MailObject> GetMailByName(string name)
        {
            var query = from r in db.MailBox
                        where r.Sender.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Sender
                        select r;
            return query;
        }
    }
}
