using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisoHomework.Interface.Facade.Contracts.DTO
{
   public class ProjectTimesheetDTO : ProjectTimesheetCreateDTO
    { 
        public long Id { get; set; }
        public string ProjectTitle { get; set; }
    }
}
