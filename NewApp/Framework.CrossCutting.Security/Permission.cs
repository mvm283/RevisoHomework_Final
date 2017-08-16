using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.CrossCutting.Security
{
    public struct Permission
    {
        public long Code { get; set; }
        public string Name { get; set; }

        public Permission(long code, string name) : this()
        {
            Code = code;
            Name = name;
        }
    }
}
