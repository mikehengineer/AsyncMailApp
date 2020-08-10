using AsyncMail.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncMail.data
{
    public class AsyncMailDbContext :DbContext
    {
        public AsyncMailDbContext(DbContextOptions<AsyncMailDbContext> options):base(options)
        {

        }
        public DbSet<MailObject> MailBox { get; set; }
    }
}
