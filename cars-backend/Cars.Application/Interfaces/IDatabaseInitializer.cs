﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Application.Interfaces
{
    public interface IDatabaseInitializer
    {
        Task Initialize();
    }
}
