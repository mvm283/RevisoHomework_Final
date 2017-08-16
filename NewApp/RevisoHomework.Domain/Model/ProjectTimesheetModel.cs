using Framework.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisoHomework.Domain.Model
{  
    public class ProjectTimesheetModel : IAggregateRoot
    {
        public long Id { get; set; } 
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Comment { get; set; }
        public virtual ProjectModel Project { get; set; }
        public ProjectTimesheetModel()
        {
        }
         

    }
}
