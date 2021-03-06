﻿using RevisoHomework.Domain.Model;
using Framework.Domain.Model;
using Framework.Web.Kendo.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisoHomework.Domain.Contracts
{
    public interface ICustomerRepository : IRepository<long, CustomerModel>
    { 
        Task<GridResult<CustomerModel>> GetAllForGrid(int page, int pageSize, string filter, string sort);
    } 
}
