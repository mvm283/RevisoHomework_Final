using Framwork.Application;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace Framwork.DataAccess.EF
{
    public class EFUnitOfWork  : IUnitOfWork
    {
        private DbContext context;
        public EFUnitOfWork(DbContext context)
        {
            this.context = context;    
        }

        public void Begin()
        {
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Rollback()
        {
        }
    }
}
