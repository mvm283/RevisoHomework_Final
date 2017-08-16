using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.ModelBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisoHomework.Web.Tests.Utile
{
    public class PerRequestChanger : IContributeComponentModelConstruction
    {
        public void ProcessModel(IKernel kernel, ComponentModel model)
        { 
                model.LifestyleType = LifestyleType.Transient;
            
        }
    }
}
