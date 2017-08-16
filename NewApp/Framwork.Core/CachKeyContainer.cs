using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framwork.Core
{
    public class CachKeyContainer : ICachKeyContainer
    {
        private Dictionary<Type, List<string>> container = new Dictionary<Type, List<string>>();
        public void Register(Type type, params string[] keys)
        {
            if (keys.Any())
            {
                var exists = container.ContainsKey(type);
                if (exists)
                {
                    container[type] = container[type].Union(keys.ToList()).ToList();
                }
                else
                {
                    container.Add(type, keys.ToList());
                }
            }
        }
        public List<string> Detect(Type type)
        {
            if (container.ContainsKey(type))
            {
                return container[type].ToList();
            }
            else
            {
                return new List<string>();
            }
        }


    }
}
