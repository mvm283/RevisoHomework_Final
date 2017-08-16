using RevisoHomework.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisoHomework.Persistance.EF.Mappings
{
     class ProjectMapping : EntityTypeConfiguration<ProjectModel>
    {
        public ProjectMapping()
        {
            ToTable("Cor.Project"); 
        }
    }
}
