using Framework.Persistance.EF;
using System.Linq;
using System;
using Framework.Web.Kendo.Helpers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Data.Entity;
using RevisoHomework.Domain.Model;
using RevisoHomework.Domain.Contracts;
using RevisoHomework.Persistance.EF;

namespace Accounting.Persistance.EF.Repositories
{
    public class CustomerRepository : BaseRepository<long, CustomerModel>, ICustomerRepository
    {
        public CustomerRepository(RevisoHomeworkDbContext dbContext) : base(dbContext)
        {
        } 

        public async virtual Task<GridResult<CustomerModel>> GetAllForGrid(int page, int pageSize, string filter, string sort)
        {
            List<GridSort> sorts = new List<GridSort>();
            var query = Context.Set<CustomerModel>().AsQueryable();

            if (filter.ToLower() != "undefined")
            {
                var filters = JsonConvert.DeserializeObject<GridFilter>(filter);
                FilterHelper.ProcessFilters(filters, ref query);
            }
            
            var count = await query.CountAsync();
            if (!sorts.Any()) query = query.OrderBy(a => a.Id);
            query = query.Skip((page - 1) * pageSize)
                .Take(pageSize);

            var result = await query.ToListAsync();
            return new GridResult<CustomerModel>(result, count);
        }

        public override long GetNextId()
        {
            throw new NotImplementedException();
        }
         
    }
}
