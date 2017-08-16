using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisoHomework.Interface.Facade.Contracts.DTO
{
  public  class ProjectCreateDTO
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public long Customer_Id { get; set; }
        public long Price { get; set; }
        public string Comment { get; set; }
    }
}
