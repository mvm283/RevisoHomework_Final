using Framework.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisoHomework.Domain.Model
{  
    public class CustomerModel : IAggregateRoot
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string Phone { get; set; } 
        public string Mobile { get; set; } 
        public string Address { get; set; }  
        public CustomerModel()
        {
        }
         

    }
}
