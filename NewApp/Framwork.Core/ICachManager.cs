﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framwork.Core
{
    public interface ICachManager
    {
        void Expire(params string[] tags); 
    }

}