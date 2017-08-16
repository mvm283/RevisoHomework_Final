using Framework.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisoHomework.Domain.Model
{  
    public class ProjectModel : IAggregateRoot
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public virtual CustomerModel Customer { get; set; } 
        public long Price { get; set; }
        public string Comment { get; set; }
        public ProjectModel()
        {
        }
         

    }
}
