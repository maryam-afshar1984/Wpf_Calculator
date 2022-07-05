﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Calculator.Models
{
    public class DataAccessFactory
    {
        public static CalculatorModel GetCalculatorModel()
        {
            return new CalculatorModel();
        }
    }
}
