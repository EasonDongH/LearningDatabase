﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.FactoryMethodPattern
{
    class ValunteerFactory : IFactory
    {
        public LeiFeng CreateLeiFeng()
        {
            return new Valunteer();
        }
    }
}
