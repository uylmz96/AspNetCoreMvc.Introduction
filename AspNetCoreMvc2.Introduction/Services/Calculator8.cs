﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvc2.Introduction.Services
{
    public class Calculator8 : ICalculator
    {
        public double Calculate(double amount)
        {
            return (amount * 0.8) + amount;
        }
    }
}