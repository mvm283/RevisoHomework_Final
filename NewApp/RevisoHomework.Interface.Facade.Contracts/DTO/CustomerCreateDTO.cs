using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisoHomework.Interface.Facade.Contracts.DTO
{
  public  class CustomerCreateDTO 
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
    }
}
