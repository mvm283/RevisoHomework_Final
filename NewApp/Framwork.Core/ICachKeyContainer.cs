using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framwork.Core
{
    public interface ICachKeyContainer
    {
        void Register(Type type, params string[] keys);
        List<string> Detect(Type type);
    }
    
}
