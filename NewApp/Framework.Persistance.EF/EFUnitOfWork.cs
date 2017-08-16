using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.Entity;
using Framework.Core;

namespace Framework.Persistance.EF
{
    public class EFUnitOfWork : IUnitOfWork
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
            this.context.SaveChanges();
        }

        public void RollBack()
        {
        }


    }
}
