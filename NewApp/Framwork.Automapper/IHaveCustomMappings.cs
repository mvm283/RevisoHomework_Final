using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framwork.Automapper
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration configuration);
    }
}
