using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisoHomework.Interface.Facade.Contracts.DTO
{
  public  class ProjectTimesheetCreateDTO
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Comment { get; set; }
        public long Project_Id { get; set; }
    }
}
