﻿using Artemis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atermis.Data
{
    internal class CarAdvertDbContextProvider : ICarAdvertDbContextProvider
    {
        public CarAdvertDbContext Provide()
        {
            return new CarAdvertDbContext();
        }
    }
}