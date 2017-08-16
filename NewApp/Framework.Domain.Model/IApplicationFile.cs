using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain.Model
{
    public interface IApplicationFile
    {
        Guid Id { get; set; }
        string ContentType { get; set; }
        byte[] Content { get; set; }
    }
}
