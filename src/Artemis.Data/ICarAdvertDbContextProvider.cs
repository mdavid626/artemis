﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.Data
{
    public interface ICarAdvertDbContextProvider
    {
        CarAdvertDbContext Provide();
    }
}
